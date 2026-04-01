CREATE TABLE `curva_abc_resultado` (
  `referencia` varchar(20) DEFAULT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `faturamento` decimal(43,2) DEFAULT NULL,
  `perc_individual` decimal(49,2) DEFAULT NULL,
  `perc_acumulado` decimal(50,2) DEFAULT NULL,
  `classe_abc` varchar(1) DEFAULT NULL,
  `fabricante` varchar(100) DEFAULT NULL,
  `fornecedor` varchar(100) DEFAULT NULL,
  `estoque_atual` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE,
    IN p_tipo        CHAR(1)   -- 'V' = por Valor  |  'Q' = por Quantidade
)
BEGIN

    SET @acumulado := 0;
    TRUNCATE TABLE curva_abc_resultado;

    IF p_tipo = 'V' THEN

        -- -------------------------------------------------------
        -- CURVA ABC POR VALOR (FATURAMENTO)
        -- -------------------------------------------------------
        DROP TEMPORARY TABLE IF EXISTS tmp_faturamento;
        CREATE TEMPORARY TABLE tmp_faturamento AS
        SELECT
            v.referencia,
            v.descricao,
            SUM(v.quantidade * v.valorvenda) AS faturamento,
            t.total_faturamento
        FROM v_vendas v
        JOIN (
            SELECT SUM(quantidade * valorvenda) AS total_faturamento
            FROM v_vendas
            WHERE data >= p_data_inicio
              AND data <= p_data_fim
        ) t ON 1 = 1
        WHERE v.data >= p_data_inicio
          AND v.data <= p_data_fim
        GROUP BY v.referencia, v.descricao, t.total_faturamento
        ORDER BY faturamento DESC;

        DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
        CREATE TEMPORARY TABLE tmp_ranking AS
        SELECT
            referencia,
            descricao,
            faturamento,
            total_faturamento,
            @acumulado := @acumulado + faturamento AS acumulado
        FROM tmp_faturamento
        ORDER BY faturamento DESC;

        INSERT INTO `nascomercio`.`curva_abc_resultado`
        (
            `referencia`, `descricao`, `faturamento`,
            `perc_individual`, `perc_acumulado`, `classe_abc`,
            `fabricante`, `fornecedor`, `estoque_atual`
        )
        SELECT
            r.referencia,
            r.descricao,
            r.faturamento,
            ROUND((r.faturamento / r.total_faturamento) * 100, 2) AS perc_individual,
            ROUND((r.acumulado   / r.total_faturamento) * 100, 2) AS perc_acumulado,
            CASE
                WHEN (r.acumulado / r.total_faturamento) <= 0.80 THEN 'A'
                WHEN (r.acumulado / r.total_faturamento) <= 0.95 THEN 'B'
                ELSE 'C'
            END AS classe_abc,
            e.fabricante,
            e.fornecedor,
            COALESCE(e.estoque_atual, 0) AS estoque_atual
        FROM tmp_ranking r
        LEFT JOIN (
            SELECT referencia, fabricante, fornecedor, SUM(valor) AS estoque_atual
            FROM v_estoque
            GROUP BY referencia, fabricante, fornecedor
        ) e ON r.referencia = e.referencia
        ORDER BY r.faturamento DESC;

        DROP TEMPORARY TABLE IF EXISTS tmp_faturamento;

    ELSE

        -- -------------------------------------------------------
        -- CURVA ABC POR QUANTIDADE
        -- -------------------------------------------------------
        DROP TEMPORARY TABLE IF EXISTS tmp_quantidade;
        CREATE TEMPORARY TABLE tmp_quantidade AS
        SELECT
            v.referencia,
            v.descricao,
            SUM(v.quantidade) AS total_itens,
            t.total_geral
        FROM v_vendas v
        JOIN (
            SELECT SUM(quantidade) AS total_geral
            FROM v_vendas
            WHERE data >= p_data_inicio
              AND data <= p_data_fim
        ) t ON 1 = 1
        WHERE v.data >= p_data_inicio
          AND v.data <= p_data_fim
        GROUP BY v.referencia, v.descricao, t.total_geral
        ORDER BY total_itens DESC;

        DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
        CREATE TEMPORARY TABLE tmp_ranking AS
        SELECT
            referencia,
            descricao,
            total_itens,
            total_geral,
            @acumulado := @acumulado + total_itens AS acumulado
        FROM tmp_quantidade
        ORDER BY total_itens DESC;

        INSERT INTO `nascomercio`.`curva_abc_resultado`
        (
            `referencia`, `descricao`, `faturamento`,
            `perc_individual`, `perc_acumulado`, `classe_abc`,
            `fabricante`, `fornecedor`, `estoque_atual`
        )
        SELECT
            r.referencia,
            r.descricao,
            r.total_itens                                            AS faturamento,
            ROUND((r.total_itens / r.total_geral) * 100, 2)         AS perc_individual,
            ROUND((r.acumulado   / r.total_geral) * 100, 2)         AS perc_acumulado,
            CASE
                WHEN (r.acumulado / r.total_geral) <= 0.80 THEN 'A'
                WHEN (r.acumulado / r.total_geral) <= 0.95 THEN 'B'
                ELSE 'C'
            END AS classe_abc,
            e.fabricante,
            e.fornecedor,
            COALESCE(e.estoque_atual, 0) AS estoque_atual
        FROM tmp_ranking r
        LEFT JOIN (
            SELECT referencia, fabricante, fornecedor, SUM(valor) AS estoque_atual
            FROM v_estoque
            GROUP BY referencia, fabricante, fornecedor
        ) e ON r.referencia = e.referencia
        ORDER BY r.total_itens DESC;

        DROP TEMPORARY TABLE IF EXISTS tmp_quantidade;

    END IF;

    -- Limpeza comum
    DROP TEMPORARY TABLE IF EXISTS tmp_ranking;

    SELECT * FROM nascomercio.curva_abc_resultado;

END