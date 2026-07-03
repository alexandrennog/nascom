CREATE TABLE `ranking_resultado_quantidade` (
  `data_inicio` date DEFAULT NULL,
  `data_fim` date DEFAULT NULL,
  `fabricante` varchar(255) DEFAULT NULL,
  `valor` int(11) DEFAULT NULL,
  `individual` decimal(10,2) DEFAULT NULL,
  `acumulado` decimal(10,2) DEFAULT NULL,
  `classificacao_abc` varchar(255) DEFAULT NULL,
  `estrategia_sugerida` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `ranking_resultado_valor` (
  `data_inicio` date DEFAULT NULL,
  `data_fim` date DEFAULT NULL,
  `fabricante` varchar(255) DEFAULT NULL,
  `valor` decimal(15,2) DEFAULT NULL,
  `individual` decimal(10,2) DEFAULT NULL,
  `acumulado` decimal(10,2) DEFAULT NULL,
  `classificacao_abc` varchar(255) DEFAULT NULL,
  `estrategia_sugerida` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc_fornecedores`(
    IN p_data_inicio DATE,
    IN p_data_fim DATE
)
BEGIN
    DECLARE v_total_geral DECIMAL(18,4) DEFAULT 0;

        DROP TEMPORARY TABLE IF EXISTS tmp_vendas_fornecedor;
    DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
    truncate table ranking_resultado_valor;

    CREATE TEMPORARY TABLE tmp_vendas_fornecedor (
        fabricante    VARCHAR(255),
        receita_total DECIMAL(18,4)
    ) ENGINE = MEMORY;

    CREATE TEMPORARY TABLE tmp_ranking (
        fabricante           VARCHAR(255),
        receita_total        DECIMAL(18,4),
        receita_acumulada    DECIMAL(18,4),
        percentual_acumulado DECIMAL(18,6)
    ) ENGINE = MEMORY;

        INSERT INTO tmp_vendas_fornecedor (fabricante, receita_total)
    SELECT 
        fabricante,
        SUM(quantidade * valorvenda)
    FROM v_vendas
    WHERE data BETWEEN p_data_inicio AND p_data_fim
    GROUP BY fabricante
    ORDER BY SUM(quantidade * valorvenda) DESC;

        SELECT SUM(receita_total) INTO v_total_geral
    FROM tmp_vendas_fornecedor;

        IF v_total_geral IS NULL OR v_total_geral = 0 THEN
        SET v_total_geral = 1;
    END IF;

        SET @acumulado := 0;

    INSERT INTO tmp_ranking (fabricante, receita_total, receita_acumulada, percentual_acumulado)
    SELECT
        fabricante,
        receita_total,
        @acumulado := @acumulado + receita_total,
        @acumulado / v_total_geral
    FROM tmp_vendas_fornecedor
    ORDER BY receita_total DESC;

    	insert into ranking_resultado_valor
    SELECT
        p_data_inicio AS periodo_inicio,
        p_data_fim    AS periodo_fim,
        fabricante,
        ROUND(receita_total, 2) AS total,
        CAST(ROUND(receita_total / v_total_geral * 100, 2) AS DECIMAL(10,2)) AS percentual,
        CAST(ROUND(percentual_acumulado * 100, 2)          AS DECIMAL(10,2)) AS percentual_acumulado,
        CASE
            WHEN percentual_acumulado <= 0.80 THEN 'A - Prioridade Alta'
            WHEN percentual_acumulado <= 0.95 THEN 'B - Prioridade Média'
            ELSE                                   'C - Prioridade Baixa'
        END AS classificacao_abc,
        CASE
            WHEN percentual_acumulado <= 0.80 THEN 'Estoque sempre disponivel | Negociar melhores condicoes'
            WHEN percentual_acumulado <= 0.95 THEN 'Estoque moderado | Buscar prazos melhores'
            ELSE                                   'Reduzir estoque | Negociar devolucao ou troca'
        END AS estrategia_sugerida
    FROM tmp_ranking
    ORDER BY receita_total DESC;

END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc_fornecedores_quantidade`(
    IN p_data_inicio DATE,
    IN p_data_fim DATE
)
BEGIN
    DROP TEMPORARY TABLE IF EXISTS tmp_vendas_fornecedor;
    DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
	truncate table ranking_resultado_quantidade;
    
        CREATE TEMPORARY TABLE tmp_vendas_fornecedor
    ENGINE = MEMORY
    SELECT 
        `fabricante`,
        SUM(`quantidade`) AS quantidade_total
    FROM `v_vendas`
    WHERE `data` BETWEEN p_data_inicio AND p_data_fim
    GROUP BY `fabricante`;
    
        SET @total_geral = (SELECT SUM(quantidade_total) FROM tmp_vendas_fornecedor);
    
        CREATE TEMPORARY TABLE tmp_ranking
    ENGINE = MEMORY
    SELECT 
        *,
        @qtd_acumulada := @qtd_acumulada + quantidade_total AS quantidade_acumulada,
        @qtd_acumulada / @total_geral AS percentual_acumulado,
        quantidade_total / @total_geral AS percentual_individual
    FROM tmp_vendas_fornecedor
    CROSS JOIN (SELECT @qtd_acumulada := 0) AS vars
    ORDER BY quantidade_total DESC;
    
        UPDATE tmp_ranking 
    SET percentual_acumulado = quantidade_acumulada / @total_geral;
    
        insert into ranking_resultado_quantidade
    SELECT 
        p_data_inicio AS periodo_inicio,
        p_data_fim AS periodo_fim,
        `fabricante`,
        `quantidade_total` AS total,
        ROUND(`percentual_individual` * 100, 2) AS percentual,
        ROUND(`percentual_acumulado` * 100, 2) AS percentual_acumulado,
        CASE 
            WHEN `percentual_acumulado` <= 0.80 THEN 'A - Prioridade Alta'
            WHEN `percentual_acumulado` <= 0.95 THEN 'B - Prioridade Média'
            ELSE 'C - Prioridade Baixa'
        END AS classificacao_abc,
        CASE 
            WHEN `percentual_acumulado` <= 0.80 THEN 'Estoque sempre disponivel | Negociar melhores condicoes'
            WHEN `percentual_acumulado` <= 0.95 THEN 'Estoque moderado | Buscar prazos melhores'
            ELSE 'Reduzir estoque | Negociar devolucao ou troca'
        END AS estrategia_sugerida
    FROM tmp_ranking
    ORDER BY total desc;
END$$
DELIMITER ;
