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
        ) AS
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
        ) AS
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
        ) AS
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
        ) AS
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