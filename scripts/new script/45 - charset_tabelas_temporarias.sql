-- =============================================================================
-- Correcao: "Incorrect string value ... for column 'cor'" na Curva ABC
-- =============================================================================
-- Erro na tela Curva ABC (lista de reposicao):
--   Erro em ListarReposicao ... Incorrect string value: '\xE2\x94\x9C\xC3\xA7...'
--   for column 'cor' at row 7
--
-- Causa: as tabelas temporarias das procedures eram criadas sem charset, entao
-- usam o padrao do banco (latin1). Os cadastros (cor, produtos, fabricantes)
-- sao utf8 e alguns nomes tem caracteres que nao existem no latin1 (ex.: um
-- nome de cor gravado com acento quebrado, "├ç" no lugar de "Ç"). Ao copiar
-- esse nome para a tabela temporaria o MySQL (modo estrito) recusa.
--
-- Correcao: as tabelas temporarias passam a ser utf8, igual aos cadastros.
-- Recria (sem mudar mais nada):
--   - sp_dashboard_compras_reposicao (script 39) - a que deu o erro
--   - sp_curva_abc (script 33) - mesmo problema com descricao/fabricante
--
-- Como aplicar: rodar no MySQL de cada loja. Pode rodar mais de uma vez.
-- Nao mexe em dados.
-- =============================================================================

DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_dashboard_compras_reposicao` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_dashboard_compras_reposicao`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE
)
BEGIN

    -- PASSO 1: vendas (vendas + vales, igual a v_vendas) agrupadas por
    -- produtos.cid - ou seja, por referencia + cor, ja que cada cor de um
    -- mesmo produto e um "produtos.cid" separado. Exclui fabricante/produto
    -- inativo (situacao = 'I') direto aqui.
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_vendas;
    CREATE TEMPORARY TABLE tmp_reposicao_vendas (
        produto_cid        INT,
        referencia         VARCHAR(50),
        descricao          VARCHAR(255),
        fabricante         VARCHAR(100),
        cor                VARCHAR(100),
        quantidade_vendida DECIMAL(18,4),
        INDEX idx_produto (produto_cid)
    ) DEFAULT CHARSET=utf8;

    INSERT INTO tmp_reposicao_vendas
        (produto_cid, referencia, descricao, fabricante, cor, quantidade_vendida)
    SELECT
        p.cid,
        p.referencia,
        p.descricao,
        f.nome,
        c.nome,
        SUM(q.quantidade)
    FROM (
        SELECT vp.produto AS produto, vp.quantidade AS quantidade
        FROM vendasprodutos vp
        INNER JOIN vendas v ON v.controle = vp.controle
        WHERE v.data BETWEEN p_data_inicio AND p_data_fim
        UNION ALL
        SELECT vlp.produto AS produto, vlp.quantidade AS quantidade
        FROM valesprodutos vlp
        INNER JOIN vales vl ON vl.controle = vlp.controle
        WHERE vl.data BETWEEN p_data_inicio AND p_data_fim
    ) q
    INNER JOIN produtos p ON p.cid = q.produto
    LEFT JOIN fabricantes f ON f.cid = p.fabricante_cid
    LEFT JOIN cor c ON c.cid = p.cor_cid
    WHERE COALESCE(p.situacao, 'A') <> 'I'
      AND COALESCE(f.situacao, 'A') <> 'I'
      -- Cobre o caso de uma cor especifica ter sido descontinuada mesmo com o
      -- produto/fabricante em si ainda ativos (ex.: pararam de fazer uma cor,
      -- mas a referencia continua em linha nas outras cores).
      AND COALESCE(c.situacao, 'A') <> 'I'
    GROUP BY p.cid, p.referencia, p.descricao, f.nome, c.nome;

    SELECT SUM(quantidade_vendida) INTO @total_geral FROM tmp_reposicao_vendas;

    -- PASSO 2: estoque atual por produtos.cid (mesma fonte - v_estoque - e
    -- mesmo agrupamento que a consulta de Estoque ja usa).
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_estoque;
    CREATE TEMPORARY TABLE tmp_reposicao_estoque (
        produto_cid   INT,
        estoque_atual DECIMAL(18,4),
        INDEX idx_produto (produto_cid)
    );

    INSERT INTO tmp_reposicao_estoque (produto_cid, estoque_atual)
    SELECT e.cid, SUM(e.valor)
    FROM v_estoque e
    WHERE e.cid IN (SELECT produto_cid FROM tmp_reposicao_vendas)
    GROUP BY e.cid;

    -- PASSO 3: classificacao ABC (por quantidade) na mesma logica de
    -- sp_curva_abc, so que agora por referencia+cor em vez de so referencia.
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_classificado;
    CREATE TEMPORARY TABLE tmp_reposicao_classificado (
        referencia         VARCHAR(50),
        descricao          VARCHAR(255),
        fabricante         VARCHAR(100),
        cor                VARCHAR(100),
        quantidade_vendida DECIMAL(18,4),
        estoque_atual      DECIMAL(18,4),
        classe_abc         VARCHAR(1)
    ) DEFAULT CHARSET=utf8;

    SET @acumulado := 0;

    INSERT INTO tmp_reposicao_classificado
    SELECT
        v.referencia,
        v.descricao,
        v.fabricante,
        v.cor,
        v.quantidade_vendida,
        COALESCE(e.estoque_atual, 0),
        CASE
            WHEN (@acumulado := @acumulado + v.quantidade_vendida) / @total_geral <= 0.80 THEN 'A'
            WHEN (@acumulado / @total_geral) <= 0.95 THEN 'B'
            ELSE 'C'
        END
    FROM tmp_reposicao_vendas v
    LEFT JOIN tmp_reposicao_estoque e ON e.produto_cid = v.produto_cid
    ORDER BY v.quantidade_vendida DESC;

    -- PASSO 4: mesmo filtro/heuristica de antes (classe A/B, estoque <= 20%
    -- do vendido), agora tambem excluindo estoque negativo. LIMIT subiu de 15
    -- para 50: como a lista passou a ser por cor em vez de por produto, o
    -- mesmo numero de produtos diferentes agora ocupa mais linhas (varias
    -- cores de um mesmo top-seller) - um limite baixo ficaria raso demais pra
    -- mostrar produtos variados.
    SELECT
        referencia,
        descricao,
        fabricante,
        cor,
        quantidade_vendida,
        estoque_atual,
        classe_abc
    FROM tmp_reposicao_classificado
    WHERE classe_abc IN ('A', 'B')
      AND estoque_atual >= 0
      AND estoque_atual <= (quantidade_vendida * 0.2)
    ORDER BY quantidade_vendida DESC, estoque_atual ASC
    LIMIT 50;

    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_vendas;
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_estoque;
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_classificado;

END $$

DELIMITER ;


DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_curva_abc` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE,
    IN p_tipo        CHAR(1)   -- 'V' = por Valor  |  'Q' = por Quantidade
)
BEGIN

    TRUNCATE TABLE curva_abc_resultado;

    IF p_tipo = 'V' THEN

        -- -------------------------------------------------------
        -- CURVA ABC POR VALOR (FATURAMENTO)
        -- -------------------------------------------------------

        -- PASSO 1: uma unica passagem em v_vendas para agrupamento
        -- ERRO 3/4 CORRIGIDO: ORDER BY removido da temp table
        DROP TEMPORARY TABLE IF EXISTS tmp_faturamento;
        CREATE TEMPORARY TABLE tmp_faturamento (
            referencia  VARCHAR(50),
            descricao   VARCHAR(255),
            faturamento DECIMAL(18,4),
            INDEX idx_ref (referencia)
        ) DEFAULT CHARSET=utf8 AS
        SELECT
            v.referencia,
            v.descricao,
            SUM(v.quantidade * v.valorvenda) AS faturamento
        FROM v_vendas v
        WHERE v.data BETWEEN p_data_inicio AND p_data_fim
        GROUP BY v.referencia, v.descricao;

        -- PASSO 2: total extraido da temp ja criada — sem segundo scan em v_vendas
        -- ERRO 3 CORRIGIDO: elimina leitura dupla de v_vendas
        SELECT SUM(faturamento)
        INTO   @total_faturamento
        FROM   tmp_faturamento;

        -- PASSO 3: estoque filtrado apenas pelas referencias existentes em tmp_faturamento
        -- ERRO 4 CORRIGIDO: evita agregar todo o catalogo de estoque desnecessariamente
        DROP TEMPORARY TABLE IF EXISTS tmp_estoque;
        CREATE TEMPORARY TABLE tmp_estoque (
            referencia    VARCHAR(50),
            fabricante    VARCHAR(100),
            fornecedor    VARCHAR(100),
            estoque_atual DECIMAL(18,4),
            INDEX idx_ref (referencia)
        ) DEFAULT CHARSET=utf8 AS
        SELECT
            e.referencia,
            e.fabricante,
            e.fornecedor,
            SUM(e.valor) AS estoque_atual
        FROM v_estoque e
        WHERE e.referencia IN (SELECT referencia FROM tmp_faturamento)
        GROUP BY e.referencia, e.fabricante, e.fornecedor;

        -- PASSO 4: acumulado inline com ORDER BY garantido somente aqui
        SET @acumulado := 0;

        INSERT INTO `nascomercio`.`curva_abc_resultado`
        (
            `referencia`, `descricao`, `faturamento`,
            `perc_individual`, `perc_acumulado`, `classe_abc`,
            `fabricante`, `fornecedor`, `estoque_atual`
        )
        SELECT
            f.referencia,
            f.descricao,
            f.faturamento,
            ROUND((f.faturamento / @total_faturamento) * 100, 2)                            AS perc_individual,
            ROUND((@acumulado := @acumulado + f.faturamento) / @total_faturamento * 100, 2) AS perc_acumulado,
            CASE
                WHEN (@acumulado / @total_faturamento) <= 0.80 THEN 'A'
                WHEN (@acumulado / @total_faturamento) <= 0.95 THEN 'B'
                ELSE 'C'
            END                                                                             AS classe_abc,
            e.fabricante,
            e.fornecedor,
            COALESCE(e.estoque_atual, 0)                                                    AS estoque_atual
        FROM tmp_faturamento f
        LEFT JOIN tmp_estoque e ON f.referencia = e.referencia
        ORDER BY f.faturamento DESC;

        -- Limpeza
        DROP TEMPORARY TABLE IF EXISTS tmp_faturamento;
        DROP TEMPORARY TABLE IF EXISTS tmp_estoque;

    ELSE

        -- -------------------------------------------------------
        -- CURVA ABC POR QUANTIDADE
        -- -------------------------------------------------------

        -- PASSO 1: uma unica passagem em v_vendas para agrupamento
        -- ERRO 2 CORRIGIDO: comentario duplicado removido
        DROP TEMPORARY TABLE IF EXISTS tmp_quantidade;
        CREATE TEMPORARY TABLE tmp_quantidade (
            referencia  VARCHAR(50),
            descricao   VARCHAR(255),
            total_itens DECIMAL(18,4),
            INDEX idx_ref (referencia)
        ) DEFAULT CHARSET=utf8 AS
        SELECT
            v.referencia,
            v.descricao,
            SUM(v.quantidade) AS total_itens
        FROM v_vendas v
        WHERE v.data BETWEEN p_data_inicio AND p_data_fim
        GROUP BY v.referencia, v.descricao;

        -- PASSO 2: total extraido da temp ja criada — sem segundo scan em v_vendas
        SELECT SUM(total_itens)
        INTO   @total_geral
        FROM   tmp_quantidade;

        -- PASSO 3: estoque filtrado apenas pelas referencias existentes em tmp_quantidade
        DROP TEMPORARY TABLE IF EXISTS tmp_estoque;
        CREATE TEMPORARY TABLE tmp_estoque (
            referencia    VARCHAR(50),
            fabricante    VARCHAR(100),
            fornecedor    VARCHAR(100),
            estoque_atual DECIMAL(18,4),
            INDEX idx_ref (referencia)
        ) DEFAULT CHARSET=utf8 AS
        SELECT
            e.referencia,
            e.fabricante,
            e.fornecedor,
            SUM(e.valor) AS estoque_atual
        FROM v_estoque e
        WHERE e.referencia IN (SELECT referencia FROM tmp_quantidade)
        GROUP BY e.referencia, e.fabricante, e.fornecedor;

        -- PASSO 4: acumulado inline com ORDER BY garantido somente aqui
        SET @acumulado := 0;

        INSERT INTO `nascomercio`.`curva_abc_resultado`
        (
            `referencia`, `descricao`, `faturamento`,
            `perc_individual`, `perc_acumulado`, `classe_abc`,
            `fabricante`, `fornecedor`, `estoque_atual`
        )
        SELECT
            q.referencia,
            q.descricao,
            q.total_itens                                                              AS faturamento,
            ROUND((q.total_itens / @total_geral) * 100, 2)                            AS perc_individual,
            ROUND((@acumulado := @acumulado + q.total_itens) / @total_geral * 100, 2) AS perc_acumulado,
            CASE
                WHEN (@acumulado / @total_geral) <= 0.80 THEN 'A'
                WHEN (@acumulado / @total_geral) <= 0.95 THEN 'B'
                ELSE 'C'
            END                                                                        AS classe_abc,
            e.fabricante,
            e.fornecedor,
            COALESCE(e.estoque_atual, 0)                                               AS estoque_atual
        FROM tmp_quantidade q
        LEFT JOIN tmp_estoque e ON q.referencia = e.referencia
        ORDER BY q.total_itens DESC;

        -- Limpeza
        DROP TEMPORARY TABLE IF EXISTS tmp_quantidade;
        DROP TEMPORARY TABLE IF EXISTS tmp_estoque;

    END IF;  -- ERRO 1 CORRIGIDO: fechamento do bloco IF/ELSE que estava ausente

    SELECT * FROM nascomercio.curva_abc_resultado;

END $$

DELIMITER ;
