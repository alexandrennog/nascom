CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc_fornecedores`(
    IN p_data_inicio DATE,
    IN p_data_fim DATE
)
BEGIN
    -- Tabela temporária para armazenar vendas por fornecedor
    DROP TEMPORARY TABLE IF EXISTS tmp_vendas_fornecedor;
    DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
    
    -- Calcula o total vendido por fabricante no período
    CREATE TEMPORARY TABLE tmp_vendas_fornecedor
    ENGINE = MEMORY
    SELECT 
        `fabricante`,
        SUM(`quantidade` * `valorvenda`) AS receita_total
    FROM `v_vendas`
    WHERE `data` BETWEEN p_data_inicio AND p_data_fim
    GROUP BY `fabricante`;
    
    -- Calcula o total geral das vendas no período
    SET @total_geral = (SELECT SUM(receita_total) FROM tmp_vendas_fornecedor);
    
    -- Cria tabela com ranking e percentuais
    CREATE TEMPORARY TABLE tmp_ranking
    ENGINE = MEMORY
    SELECT 
        *,
        @receita_acumulada := @receita_acumulada + receita_total AS receita_acumulada,
        @receita_acumulada / @total_geral AS percentual_acumulado,
        receita_total / @total_geral AS percentual_individual
    FROM tmp_vendas_fornecedor
    CROSS JOIN (SELECT @receita_acumulada := 0, @ordem := 0) AS vars
    ORDER BY receita_total DESC;
    
    -- Atualiza o percentual acumulado corrigindo o cálculo
    UPDATE tmp_ranking 
    SET percentual_acumulado = receita_acumulada / @total_geral;
    
    -- Retorna o resultado final
    SELECT 
        p_data_inicio AS periodo_inicio,
        p_data_fim AS periodo_fim,
        `fabricante`,
        ROUND(`receita_total`, 2) AS receita_total,
        ROUND(`percentual_individual` * 100, 2) AS percentual_receita,
        ROUND(`percentual_acumulado` * 100, 2) AS percentual_acumulado,
        CASE 
            WHEN `percentual_acumulado` <= 0.80 THEN 'A - Prioridade Alta'
            WHEN `percentual_acumulado` <= 0.95 THEN 'B - Prioridade Média'
            ELSE 'C - Prioridade Baixa'
        END AS classificacao_abc,
        CASE 
            WHEN `percentual_acumulado` <= 0.80 THEN '✅ Estoque sempre disponivel | Negociar melhores condicoes'
            WHEN `percentual_acumulado` <= 0.95 THEN '⚠️ Estoque moderado | Buscar prazos melhores'
            ELSE '❌ Reduzir estoque | Negociar devolucao ou troca'
        END AS estrategia_sugerida
    FROM tmp_ranking
    ORDER BY percentual_acumulado;
    
    -- Limpa as tabelas temporárias
    DROP TEMPORARY TABLE IF EXISTS tmp_vendas_fornecedor;
    DROP TEMPORARY TABLE IF EXISTS tmp_ranking;
END