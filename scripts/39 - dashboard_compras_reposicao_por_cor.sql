-- =============================================================================
-- Painel de Compras - Reposicao: quebra por referencia + cor, exclui
-- fabricante/produto inativo e estoque negativo
-- =============================================================================
-- Contexto (feedback da cliente, ouvido em audio, sobre o Painel de Compras):
--   1) A lista de "precisa repor" mostrava so uma linha por produto (ex.:
--      "Havaiana Top"), somando TODAS as cores juntas. Pra um produto com
--      10+ cores cadastradas, isso obriga a cliente a abrir cor por cor pra
--      descobrir qual delas realmente esta em falta - o relatorio deveria
--      dizer isso direto (ex.: "Top, cor Preta").
--   2) Marca/produto que a loja parou de trabalhar ha anos (ex.: "Dijian",
--      que nem tem fabrica mais) ainda aparecia na lista, porque o calculo
--      olha só pro historico de vendas dentro do periodo escolhido, sem
--      checar se o cadastro segue ativo.
--   3) Um desses itens descontinuados aparecia com estoque atual NEGATIVO -
--      sintoma de erro de lancamento de estoque (nao e uma quantidade real
--      a repor, e ruido).
--
-- Substitui so a procedure sp_dashboard_compras_reposicao (script 38). A
-- sp_dashboard_compras_resumo (ticket medio / marca campea) NAO muda.
--
-- Por que nao reaproveitar mais sp_curva_abc/curva_abc_resultado: aquele
-- calculo agrupa por referencia apenas, e e usado por outros relatorios que
-- devem continuar nessa granularidade (Curva ABC, Curva ABC por Fabricante -
-- script 37). Mudar a granularidade dali afetaria esses outros relatorios.
-- Esta procedure passa a ter calculo proprio, direto em cima de
-- vendasprodutos/valesprodutos + produtos, na MESMA granularidade que
-- v_estoque e a consulta de Estoque (fRelatorioEstoque) ja usam: por
-- produtos.cid, que e unico por referencia+cor (confirmado em
-- pParametro.ConsultarEstoque - a mesma consulta usada pela tela de
-- Relatorio de Estoque).
--
-- Como aplicar: rodar este script no MySQL de cada loja (mesmo processo ja
-- usado pros scripts anteriores). Nao apaga nem altera dados de venda ou
-- estoque - so troca a definicao da procedure.
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
    );

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
    );

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
    -- do vendido), agora tambem excluindo estoque negativo.
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
    LIMIT 15;

    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_vendas;
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_estoque;
    DROP TEMPORARY TABLE IF EXISTS tmp_reposicao_classificado;

END $$

DELIMITER ;
