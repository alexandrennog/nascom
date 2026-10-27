-- =============================================================================
-- Relatorio Compras x Vendas x Estoque (Relatorios > "Compras x Vendas x Estoque",
-- tela fRelatorioComprasVendas)
-- =============================================================================
-- Pedido da cliente (audio de 27/10/2026): cruzar o que entrou de compra no
-- estoque com o que foi vendido e com o que sobrou, por marca/produto, para
-- decidir a recompra ("comprei 100, vendi 30, tem 70 - compro mais ou nao?").
--
-- Usa so dados que o sistema ja grava (nenhuma tabela nova):
--   * Comprou  = entradas de estoque no periodo (tabela logestoque - gravada
--                pela tela de Entrada de Estoque e pelo cadastro de produto;
--                so recebe quantidade positiva).
--   * Vendeu   = vendas + vales no periodo (vendasprodutos/valesprodutos, as
--                mesmas fontes do Painel de Compras / script 39).
--   * Estoque  = estoque de HOJE de cada tamanho (produtoitem, caracteristica
--                2 = estoque; 1 = codigo de barras; 3 = tamanho - mesmos ids
--                usados em pGradeItem).
--
-- Entra na lista todo produto (referencia + cor) que teve compra OU venda no
-- periodo. Fabricante/produto/cor inativos ficam de fora (mesma regra do
-- script 39). O % vendido e a situacao (Repor / Normal / Vendeu pouco) sao
-- calculados na tela, para poder mudar a regra sem mexer no banco.
--
-- Parametros:
--   p_data_inicio, p_data_fim  periodo (a data final e inclusiva, mesmo que a
--                              coluna de data tenha hora)
--   p_fabricante_cid           NULL = todos
--   p_por_tamanho              0 = uma linha por referencia + cor
--                              1 = uma linha por tamanho
--
-- Como aplicar: rodar no MySQL de cada loja (mesmo processo dos scripts
-- anteriores). Nao altera dados - so cria a procedure. Pode rodar de novo.
-- Compativel com MySQL 5.5.
-- =============================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_dashboard_compras_x_vendas` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_dashboard_compras_x_vendas`(
    IN p_data_inicio    DATE,
    IN p_data_fim       DATE,
    IN p_fabricante_cid INT,
    IN p_por_tamanho    TINYINT
)
BEGIN
    DECLARE v_fim_exclusivo DATETIME;

    -- "ate 31/10" inclui o dia 31 inteiro, mesmo se a coluna guardar hora
    SET v_fim_exclusivo = DATE_ADD(p_data_fim, INTERVAL 1 DAY);

    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_mov;
    CREATE TEMPORARY TABLE tmp_cxv_mov (
        produto_cid INT NOT NULL,
        item        INT NOT NULL,
        comprado    DECIMAL(18,4) NOT NULL DEFAULT 0,
        vendido     DECIMAL(18,4) NOT NULL DEFAULT 0,
        INDEX idx_mov (produto_cid, item)
    );

    -- 1) Compras: entradas de estoque do periodo. O logestoque guarda o codigo
    --    de barras; o tamanho (item da grade) vem do produtoitem.
    INSERT INTO tmp_cxv_mov (produto_cid, item, comprado)
    SELECT le.produto_cid, cb.item, SUM(le.quantidade)
      FROM logestoque le
     INNER JOIN produtoitem cb
             ON cb.produtos_cid = le.produto_cid
            AND cb.caracteristicas_cid = 1
            AND cb.valor = le.produtoItem_codigoBarras
     WHERE le.data >= p_data_inicio
       AND le.data <  v_fim_exclusivo
       AND le.quantidade > 0
     GROUP BY le.produto_cid, cb.item;

    -- 2) Vendas (vendas + vales) do periodo, por produto e tamanho
    INSERT INTO tmp_cxv_mov (produto_cid, item, vendido)
    SELECT q.produto, q.item, SUM(q.quantidade)
      FROM (
            SELECT vp.produto, vp.item, vp.quantidade
              FROM vendasprodutos vp
             INNER JOIN vendas v ON v.controle = vp.controle
             WHERE v.data >= p_data_inicio
               AND v.data <  v_fim_exclusivo
            UNION ALL
            SELECT vlp.produto, vlp.item, vlp.quantidade
              FROM valesprodutos vlp
             INNER JOIN vales vl ON vl.controle = vlp.controle
             WHERE vl.data >= p_data_inicio
               AND vl.data <  v_fim_exclusivo
           ) q
     GROUP BY q.produto, q.item;

    -- 3) Junta compra e venda do mesmo tamanho numa linha so
    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_item;
    CREATE TEMPORARY TABLE tmp_cxv_item (
        produto_cid INT NOT NULL,
        item        INT NOT NULL,
        comprado    DECIMAL(18,4) NOT NULL,
        vendido     DECIMAL(18,4) NOT NULL,
        PRIMARY KEY (produto_cid, item)
    );

    INSERT INTO tmp_cxv_item (produto_cid, item, comprado, vendido)
    SELECT m.produto_cid, m.item, SUM(m.comprado), SUM(m.vendido)
      FROM tmp_cxv_mov m
     INNER JOIN produtos p ON p.cid = m.produto_cid
      LEFT JOIN fabricantes f ON f.cid = p.fabricante_cid
      LEFT JOIN cor c ON c.cid = p.cor_cid
     WHERE COALESCE(p.situacao, 'A') <> 'I'
       AND COALESCE(f.situacao, 'A') <> 'I'
       AND COALESCE(c.situacao, 'A') <> 'I'
       AND (p_fabricante_cid IS NULL OR p.fabricante_cid = p_fabricante_cid)
     GROUP BY m.produto_cid, m.item;

    -- 4) Estoque de hoje: todos os tamanhos dos produtos da lista (inclusive
    --    tamanho que nao teve compra nem venda no periodo, para o total do
    --    produto bater com o estoque real dele).
    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_estoque;
    CREATE TEMPORARY TABLE tmp_cxv_estoque (
        produto_cid INT NOT NULL,
        item        INT NOT NULL,
        estoque     DECIMAL(18,4) NOT NULL,
        PRIMARY KEY (produto_cid, item)
    );

    INSERT INTO tmp_cxv_estoque (produto_cid, item, estoque)
    -- (o estoque fica gravado como texto: valor vazio/invalido conta como 0 em
    -- vez de derrubar a consulta com "Truncated incorrect DECIMAL value")
    SELECT es.produtos_cid, es.item,
           MAX(CASE WHEN TRIM(es.valor) REGEXP '^-?[0-9]+([.,][0-9]+)?$'
                    THEN CAST(REPLACE(TRIM(es.valor), ',', '.') AS DECIMAL(18,4))
                    ELSE 0 END)
      FROM (SELECT DISTINCT produto_cid FROM tmp_cxv_item) d
     INNER JOIN produtoitem es
             ON es.produtos_cid = d.produto_cid
            AND es.caracteristicas_cid = 2
     GROUP BY es.produtos_cid, es.item;

    -- Tamanho com estoque mas sem movimento no periodo tambem aparece (zerado)
    -- quando a lista e por tamanho
    INSERT IGNORE INTO tmp_cxv_item (produto_cid, item, comprado, vendido)
    SELECT e.produto_cid, e.item, 0, 0
      FROM tmp_cxv_estoque e;

    -- 5) Resultado
    IF p_por_tamanho = 1 THEN

        SELECT f.nome                         AS fabricante,
               p.cid                          AS produto_cid,
               p.referencia                   AS referencia,
               p.descricao                    AS descricao,
               c.nome                         AS cor,
               COALESCE(tm.valor, '')         AS tamanho,
               CAST(i.comprado AS SIGNED)     AS comprado,
               CAST(i.vendido AS SIGNED)      AS vendido,
               CAST(COALESCE(e.estoque, 0) AS SIGNED) AS estoque
          FROM tmp_cxv_item i
         INNER JOIN produtos p ON p.cid = i.produto_cid
          LEFT JOIN fabricantes f ON f.cid = p.fabricante_cid
          LEFT JOIN cor c ON c.cid = p.cor_cid
          LEFT JOIN tmp_cxv_estoque e ON e.produto_cid = i.produto_cid AND e.item = i.item
          LEFT JOIN produtoitem tm
                 ON tm.produtos_cid = i.produto_cid
                AND tm.item = i.item
                AND tm.caracteristicas_cid = 3
         ORDER BY f.nome, p.referencia, c.nome, p.cid, tm.valor + 0, tm.valor;

    ELSE

        SELECT f.nome                         AS fabricante,
               p.cid                          AS produto_cid,
               p.referencia                   AS referencia,
               p.descricao                    AS descricao,
               c.nome                         AS cor,
               ''                             AS tamanho,
               CAST(SUM(i.comprado) AS SIGNED) AS comprado,
               CAST(SUM(i.vendido) AS SIGNED)  AS vendido,
               CAST(SUM(COALESCE(e.estoque, 0)) AS SIGNED) AS estoque
          FROM tmp_cxv_item i
         INNER JOIN produtos p ON p.cid = i.produto_cid
          LEFT JOIN fabricantes f ON f.cid = p.fabricante_cid
          LEFT JOIN cor c ON c.cid = p.cor_cid
          LEFT JOIN tmp_cxv_estoque e ON e.produto_cid = i.produto_cid AND e.item = i.item
         GROUP BY f.nome, p.cid, p.referencia, p.descricao, c.nome
         ORDER BY f.nome, p.referencia, c.nome, p.cid;

    END IF;

    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_mov;
    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_item;
    DROP TEMPORARY TABLE IF EXISTS tmp_cxv_estoque;

END $$

DELIMITER ;
