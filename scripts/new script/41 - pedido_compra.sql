-- =============================================================================
-- Pedido de Compra por fabricante (marca) + baixa automatica na entrada
-- =============================================================================
-- Objetivo: tirar da planilha de Excel o controle "COMPRAS / PEDIDO x ENTREGA
-- x A RECEBER" que a loja faz por marca. O pedido e lancado item a item
-- (referencia + cor + tamanho, igual a grade do produto) e, quando a
-- mercadoria chega e e lancada na tela de Entrada de Estoque, o sistema da
-- baixa automatica no pedido em aberto mais antigo daquele mesmo item.
--
-- Regras combinadas com o usuario (27/10/2026):
--   * Um pedido por fabricante (marca).
--   * Desconto no pedido todo (em R$), rateado nos itens pelo valor bruto.
--   * Baixa automatica: entrada de estoque baixa primeiro o pedido em aberto
--     mais antigo (data do pedido, depois numero interno) do mesmo produto e
--     codigo de barras (tamanho).
--   * Valor da entrega = pares entregues x preco liquido do item no pedido.
--
-- Compatibilidade: escrito para MySQL 5.5 (sem funcoes de janela, sem CTE).
-- Rodar este script direto no MySQL de cada loja (mesma base da connection
-- string do app.config) antes de usar as telas novas. Pode rodar mais de uma
-- vez: as tabelas so sao criadas se ainda nao existirem e as procedures sao
-- recriadas.
--
-- Situacao do pedido:
--   A = Aberto (nada entregue ainda)
--   P = Parcial (parte entregue)
--   E = Entregue (tudo entregue)
--   C = Cancelado (nao recebe mais baixa e nao entra no relatorio)
-- =============================================================================

-- 1) Cabecalho do pedido -------------------------------------------------------
CREATE TABLE IF NOT EXISTS `pedidocompra` (
    `cid`              INT NOT NULL AUTO_INCREMENT,
    `numero`           VARCHAR(30)   NULL,            -- numero do pedido no fabricante/representante (opcional)
    `fabricante_cid`   INT NOT NULL,
    `data`             DATE NOT NULL,                 -- data do pedido (usada no filtro do relatorio)
    `previsaoEntrega`  DATE NULL,
    `descontoValor`    DECIMAL(12,2) NOT NULL DEFAULT 0.00,  -- desconto do pedido todo, em R$
    `situacao`         CHAR(1) NOT NULL DEFAULT 'A',
    `observacao`       VARCHAR(500)  NULL,
    `usuario_cid`      INT NULL,
    `dataInclusao`     DATETIME NULL,
    PRIMARY KEY (`cid`),
    KEY `ix_pedidocompra_data` (`data`),
    KEY `ix_pedidocompra_fabricante` (`fabricante_cid`, `situacao`)
) ENGINE=InnoDB;

-- 2) Itens do pedido (um por referencia + cor + tamanho) -------------------------
CREATE TABLE IF NOT EXISTS `pedidocompraitem` (
    `cid`                 INT NOT NULL AUTO_INCREMENT,
    `pedidocompra_cid`    INT NOT NULL,
    `produtos_cid`        INT NOT NULL,              -- produto = referencia + cor
    `codigoBarras`        VARCHAR(30) NOT NULL,      -- identifica o tamanho na grade do produto
    `tamanho`             VARCHAR(20)  NULL,         -- copia do tamanho, so para exibir
    `quantidade`          INT NOT NULL DEFAULT 0,    -- pares pedidos
    `valorUnitario`       DECIMAL(12,2) NOT NULL DEFAULT 0.00,  -- preco bruto do par
    `quantidadeEntregue`  INT NOT NULL DEFAULT 0,    -- atualizado pela baixa automatica
    PRIMARY KEY (`cid`),
    KEY `ix_pedidocompraitem_pedido` (`pedidocompra_cid`),
    KEY `ix_pedidocompraitem_baixa` (`produtos_cid`, `codigoBarras`)
) ENGINE=InnoDB;

-- 3) Historico das baixas (cada entrada de estoque que abateu um item) ----------
CREATE TABLE IF NOT EXISTS `pedidocomprabaixa` (
    `cid`                   INT NOT NULL AUTO_INCREMENT,
    `pedidocompra_cid`      INT NOT NULL,
    `pedidocompraitem_cid`  INT NOT NULL,
    `data`                  DATETIME NOT NULL,
    `quantidade`            INT NOT NULL,
    `notaFiscalNumero`      VARCHAR(20) NULL,
    `notaFiscalSerie`       VARCHAR(10) NULL,
    `usuario_cid`           INT NULL,
    PRIMARY KEY (`cid`),
    KEY `ix_pedidocomprabaixa_pedido` (`pedidocompra_cid`),
    KEY `ix_pedidocomprabaixa_item` (`pedidocompraitem_cid`)
) ENGINE=InnoDB;


DELIMITER $$

-- 4) Recalcula a situacao de um pedido a partir dos itens -----------------------
--    Nao mexe em pedido Cancelado.
DROP PROCEDURE IF EXISTS `sp_pedidocompra_atualizar_situacao` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pedidocompra_atualizar_situacao`(
    IN p_pedido_cid INT
)
BEGIN
    DECLARE v_pedido    INT DEFAULT 0;
    DECLARE v_entregue  INT DEFAULT 0;

    SELECT COALESCE(SUM(quantidade), 0), COALESCE(SUM(quantidadeEntregue), 0)
      INTO v_pedido, v_entregue
      FROM pedidocompraitem
     WHERE pedidocompra_cid = p_pedido_cid;

    UPDATE pedidocompra
       SET situacao = CASE
                          WHEN v_entregue <= 0 THEN 'A'
                          WHEN v_entregue >= v_pedido THEN 'E'
                          ELSE 'P'
                      END
     WHERE cid = p_pedido_cid
       AND situacao <> 'C';
END $$


-- 5) Baixa automatica de uma entrada de estoque nos pedidos em aberto ------------
--    Chamada pela tela de Entrada de Estoque, uma vez para cada tamanho
--    (codigo de barras) que entrou. Abate primeiro o pedido mais antigo; se a
--    quantidade que entrou for maior que o que falta naquele pedido, o resto
--    vai para o proximo pedido em aberto do mesmo item, e assim por diante.
--    O que sobrar (entrada sem pedido) simplesmente nao gera baixa.
--
--    Devolve uma linha com: quantidade_baixada, quantidade_sem_pedido e
--    pedidos (lista dos pedidos que receberam baixa, para avisar o operador).
DROP PROCEDURE IF EXISTS `sp_pedidocompra_baixar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pedidocompra_baixar`(
    IN p_produtos_cid     INT,
    IN p_codigo_barras    VARCHAR(30),
    IN p_quantidade       INT,
    IN p_nf_numero        VARCHAR(20),
    IN p_nf_serie         VARCHAR(10),
    IN p_usuario_cid      INT
)
BEGIN
    DECLARE v_restante     INT DEFAULT 0;
    DECLARE v_item_cid     INT DEFAULT NULL;
    DECLARE v_pedido_cid   INT DEFAULT NULL;
    DECLARE v_falta        INT DEFAULT 0;
    DECLARE v_abater       INT DEFAULT 0;
    DECLARE v_baixado      INT DEFAULT 0;
    DECLARE v_pedidos      VARCHAR(500) DEFAULT '';
    DECLARE v_rotulo       VARCHAR(40) DEFAULT '';

    -- Qualquer erro desfaz a baixa inteira (a entrada de estoque em si ja foi
    -- gravada antes, pela tela; so a baixa no pedido e desfeita).
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    SET v_restante = COALESCE(p_quantidade, 0);

    START TRANSACTION;

    baixa: WHILE v_restante > 0 DO

        SET v_item_cid = NULL;
        SET v_pedido_cid = NULL;
        SET v_falta = 0;

        -- Item em aberto mais antigo desse produto + tamanho.
        -- FOR UPDATE trava a linha: dois caixas dando entrada ao mesmo tempo
        -- nao abatem a mesma quantidade duas vezes.
        SELECT i.cid, i.pedidocompra_cid, (i.quantidade - i.quantidadeEntregue)
          INTO v_item_cid, v_pedido_cid, v_falta
          FROM pedidocompraitem i
         INNER JOIN pedidocompra p ON p.cid = i.pedidocompra_cid
         WHERE i.produtos_cid = p_produtos_cid
           AND i.codigoBarras = p_codigo_barras
           AND p.situacao IN ('A', 'P')
           AND i.quantidade > i.quantidadeEntregue
         ORDER BY p.data, p.cid, i.cid
         LIMIT 1
           FOR UPDATE;

        IF v_item_cid IS NULL THEN
            LEAVE baixa;
        END IF;

        SET v_abater = LEAST(v_falta, v_restante);

        UPDATE pedidocompraitem
           SET quantidadeEntregue = quantidadeEntregue + v_abater
         WHERE cid = v_item_cid;

        INSERT INTO pedidocomprabaixa
            (pedidocompra_cid, pedidocompraitem_cid, data, quantidade, notaFiscalNumero, notaFiscalSerie, usuario_cid)
        VALUES
            (v_pedido_cid, v_item_cid, NOW(), v_abater, p_nf_numero, p_nf_serie, p_usuario_cid);

        CALL sp_pedidocompra_atualizar_situacao(v_pedido_cid);

        SELECT COALESCE(NULLIF(TRIM(numero), ''), CONCAT('#', cid))
          INTO v_rotulo
          FROM pedidocompra
         WHERE cid = v_pedido_cid;

        IF LOCATE(CONCAT('|', v_rotulo, '|'), CONCAT('|', REPLACE(v_pedidos, ', ', '|'), '|')) = 0 THEN
            SET v_pedidos = IF(v_pedidos = '', v_rotulo, CONCAT(v_pedidos, ', ', v_rotulo));
        END IF;

        SET v_baixado  = v_baixado + v_abater;
        SET v_restante = v_restante - v_abater;

    END WHILE baixa;

    COMMIT;

    SELECT v_baixado  AS quantidade_baixada,
           v_restante AS quantidade_sem_pedido,
           v_pedidos  AS pedidos;
END $$

DELIMITER ;
