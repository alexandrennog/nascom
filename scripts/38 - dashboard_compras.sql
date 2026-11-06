-- =============================================================================
-- Painel de Compras: ticket medio, marca campea e oportunidades de reposicao
-- =============================================================================
-- Objetivo: responder direto, em uma tela, as perguntas que a cliente relatou
-- (ticket medio, qual marca mais vendeu, o que precisa repor) em vez de exigir
-- que ela interprete uma lista crua de dados.
--
-- Depende do script "37 - curva_abc_unificada.sql" (usa sp_curva_abc, que ja
-- existia, e a mesma v_vendas usada no resto do sistema). Nao cria tabela
-- persistente nova alem das temporarias de calculo.
-- =============================================================================

DELIMITER $$

-- 1) Resumo do periodo: ticket medio, faturamento total e marca campea
--    (em valor e em quantidade, que podem ser marcas diferentes).
DROP PROCEDURE IF EXISTS `sp_dashboard_compras_resumo` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_dashboard_compras_resumo`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE
)
BEGIN
    -- Corrigido em 17/09/2026: o SELECT final original referenciava cada
    -- tabela temporaria mais de uma vez (uma subquery pra cada coluna) - o
    -- MySQL nao deixa reabrir a mesma TEMPORARY TABLE dentro do mesmo
    -- comando ("Can't reopen table"), erro que so aparece na hora de rodar,
    -- nao na hora de criar a procedure. Resolvido lendo cada tabela
    -- temporaria uma unica vez, com SELECT ... INTO em variaveis, e so
    -- depois montando o SELECT final (que ai nao toca em nenhuma tabela
    -- temporaria, so nas variaveis).
    DECLARE v_qtd_vendas        INT;
    DECLARE v_faturamento_total DECIMAL(12,2);
    DECLARE v_ticket_medio      DECIMAL(12,2);
    DECLARE v_marca_valor       VARCHAR(255);
    DECLARE v_marca_valor_total DECIMAL(12,2);
    DECLARE v_marca_qtd         VARCHAR(255);
    DECLARE v_marca_qtd_total   DECIMAL(12,2);

    DROP TEMPORARY TABLE IF EXISTS tmp_vendas_periodo;
    DROP TEMPORARY TABLE IF EXISTS tmp_marca_valor;
    DROP TEMPORARY TABLE IF EXISTS tmp_marca_qtd;

    -- Ticket medio = faturamento total dividido pelo numero de vendas (controle),
    -- nao pelo numero de itens - uma venda com 3 pares conta como 1 venda.
    CREATE TEMPORARY TABLE tmp_vendas_periodo AS
    SELECT controle, SUM(quantidade * valorvenda) AS total_venda
    FROM v_vendas
    WHERE data BETWEEN p_data_inicio AND p_data_fim
    GROUP BY controle;

    CREATE TEMPORARY TABLE tmp_marca_valor AS
    SELECT fabricante, SUM(quantidade * valorvenda) AS total
    FROM v_vendas
    WHERE data BETWEEN p_data_inicio AND p_data_fim
    GROUP BY fabricante
    ORDER BY total DESC
    LIMIT 1;

    CREATE TEMPORARY TABLE tmp_marca_qtd AS
    SELECT fabricante, SUM(quantidade) AS total
    FROM v_vendas
    WHERE data BETWEEN p_data_inicio AND p_data_fim
    GROUP BY fabricante
    ORDER BY total DESC
    LIMIT 1;

    SELECT COUNT(*), ROUND(COALESCE(SUM(total_venda), 0), 2), ROUND(COALESCE(AVG(total_venda), 0), 2)
    INTO v_qtd_vendas, v_faturamento_total, v_ticket_medio
    FROM tmp_vendas_periodo;

    SELECT fabricante, ROUND(COALESCE(total, 0), 2)
    INTO v_marca_valor, v_marca_valor_total
    FROM tmp_marca_valor;

    SELECT fabricante, COALESCE(total, 0)
    INTO v_marca_qtd, v_marca_qtd_total
    FROM tmp_marca_qtd;

    DROP TEMPORARY TABLE IF EXISTS tmp_vendas_periodo;
    DROP TEMPORARY TABLE IF EXISTS tmp_marca_valor;
    DROP TEMPORARY TABLE IF EXISTS tmp_marca_qtd;

    SELECT
        p_data_inicio        AS periodo_inicio,
        p_data_fim           AS periodo_fim,
        v_qtd_vendas         AS qtd_vendas,
        v_faturamento_total  AS faturamento_total,
        v_ticket_medio       AS ticket_medio,
        v_marca_valor        AS marca_campea_valor,
        v_marca_valor_total  AS marca_campea_valor_total,
        v_marca_qtd          AS marca_campea_quantidade,
        v_marca_qtd_total    AS marca_campea_quantidade_total;
END $$

-- 2) Oportunidades de reposicao: reaproveita a Curva ABC por produto em
--    quantidade e destaca o que mais vendeu e esta com pouco estoque -
--    heuristica simples (estoque atual <= 20% do que foi vendido no periodo).
--    Isso e um ponto de partida, nao uma formula definitiva de ponto de pedido;
--    dá pra refinar depois com media de venda diaria e lead time do fornecedor.
DROP PROCEDURE IF EXISTS `sp_dashboard_compras_reposicao` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_dashboard_compras_reposicao`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE
)
BEGIN
    CALL sp_curva_abc(p_data_inicio, p_data_fim, 'Q');

    SELECT
        referencia,
        descricao,
        fabricante,
        faturamento    AS quantidade_vendida,
        estoque_atual,
        classe_abc
    FROM curva_abc_resultado
    WHERE classe_abc IN ('A', 'B')
      AND estoque_atual <= (faturamento * 0.2)
    ORDER BY faturamento DESC, estoque_atual ASC
    LIMIT 15;
END $$

DELIMITER ;
