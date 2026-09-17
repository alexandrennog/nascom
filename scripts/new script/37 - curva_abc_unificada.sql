-- =============================================================================
-- Unificacao da Curva ABC (por produto e por fabricante)
-- =============================================================================
-- Contexto: existiam duas implementacoes paralelas de Curva ABC:
--   1) sp_curva_abc (script 33)              -> por referencia/produto, ja cruza
--      com estoque atual (v_estoque) e grava em curva_abc_resultado.
--   2) sp_curva_abc_fornecedores / _quantidade (scripts 35 e 36) -> por fabricante,
--      usada hoje pelo relatorio "Curva ABC" (fRelatorioVendasABC.vb).
--
-- Dois problemas encontrados na (2):
--   - O script 36 (variante "quantidade") e uma copia literal do script 35
--     (variante "valor"): cria a MESMA procedure sp_curva_abc_fornecedores, sem
--     nunca implementar a agregacao por quantidade. Ou seja, o botao "Quantidade"
--     do relatorio de Curva ABC muito provavelmente falha ou usa sempre o calculo
--     de valor.
--   - As duas procedures leem o resultado de tabelas ranking_resultado_valor /
--     ranking_resultado_quantidade que NAO existem em nenhum script versionado.
--
-- Solucao: eliminar a implementacao (2) e derivar a visao por fabricante da MESMA
-- base de calculo que a Curva ABC por produto ja usa (curva_abc_resultado),
-- preenchida por sp_curva_abc. Um unico calculo, duas visoes (produto e
-- fabricante), sempre consistentes entre si.
--
-- Como aplicar: rodar este script inteiro no MySQL de cada loja (mesmo processo
-- ja usado para os scripts anteriores). Nao apaga nem altera dados de venda.
-- =============================================================================

CREATE TABLE IF NOT EXISTS `curva_abc_fabricante` (
  `fabricante`           VARCHAR(100)   DEFAULT NULL,
  `faturamento`          DECIMAL(18,2)  DEFAULT NULL,  -- valor OU quantidade, conforme p_tipo
  `perc_individual`      DECIMAL(7,2)   DEFAULT NULL,
  `perc_acumulado`       DECIMAL(7,2)   DEFAULT NULL,
  `classe_abc`           VARCHAR(1)     DEFAULT NULL,
  `estrategia_sugerida`  VARCHAR(120)   DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_curva_abc_por_fabricante` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_curva_abc_por_fabricante`(
    IN p_data_inicio DATE,
    IN p_data_fim    DATE,
    IN p_tipo        CHAR(1)   -- 'V' = por Valor | 'Q' = por Quantidade
)
BEGIN
    -- Reaproveita o calculo que sp_curva_abc ja faz por produto (mesmo periodo e
    -- mesmo tipo) e so agrupa o resultado por fabricante em cima dele. Evita
    -- manter uma segunda logica de calculo divergente.
    CALL sp_curva_abc(p_data_inicio, p_data_fim, p_tipo);

    TRUNCATE TABLE curva_abc_fabricante;

    DROP TEMPORARY TABLE IF EXISTS tmp_fab;
    CREATE TEMPORARY TABLE tmp_fab AS
    SELECT
        COALESCE(fabricante, '(sem fabricante)') AS fabricante,
        SUM(faturamento) AS faturamento
    FROM curva_abc_resultado
    GROUP BY COALESCE(fabricante, '(sem fabricante)');

    SELECT SUM(faturamento) INTO @total_fab FROM tmp_fab;

    SET @acumulado_fab := 0;

    INSERT INTO curva_abc_fabricante
        (fabricante, faturamento, perc_individual, perc_acumulado, classe_abc, estrategia_sugerida)
    SELECT
        fabricante,
        faturamento,
        ROUND((faturamento / @total_fab) * 100, 2) AS perc_individual,
        ROUND((@acumulado_fab := @acumulado_fab + faturamento) / @total_fab * 100, 2) AS perc_acumulado,
        CASE
            WHEN (@acumulado_fab / @total_fab) <= 0.80 THEN 'A'
            WHEN (@acumulado_fab / @total_fab) <= 0.95 THEN 'B'
            ELSE 'C'
        END AS classe_abc,
        CASE
            WHEN (@acumulado_fab / @total_fab) <= 0.80 THEN 'Estoque sempre disponivel | Negociar melhores condicoes'
            WHEN (@acumulado_fab / @total_fab) <= 0.95 THEN 'Estoque moderado | Buscar prazos melhores'
            ELSE 'Reduzir estoque | Negociar devolucao ou troca'
        END AS estrategia_sugerida
    FROM tmp_fab
    ORDER BY faturamento DESC;

    DROP TEMPORARY TABLE IF EXISTS tmp_fab;

    -- Formato de saida compativel com o que pVenda.ListarVendasABC ja espera
    -- (mesmos nomes de coluna que as procedures antigas devolviam).
    SELECT
        p_data_inicio AS periodo_inicio,
        p_data_fim    AS periodo_fim,
        fabricante,
        faturamento   AS valor,
        perc_individual AS individual,
        perc_acumulado  AS acumulado,
        CASE classe_abc
            WHEN 'A' THEN 'A - Prioridade Alta'
            WHEN 'B' THEN 'B - Prioridade Média'
            ELSE 'C - Prioridade Baixa'
        END AS classificacao_abc,
        estrategia_sugerida
    FROM curva_abc_fabricante
    ORDER BY perc_acumulado;
END $$

DELIMITER ;

-- Remove as duas procedures antigas (a de "quantidade" nunca funcionou de fato;
-- a de "valor" fica substituida por sp_curva_abc_por_fabricante).
DROP PROCEDURE IF EXISTS `sp_curva_abc_fornecedores`;
DROP PROCEDURE IF EXISTS `sp_curva_abc_fornecedores_quantidade`;

-- Observacao operacional: assim como sp_curva_abc, esta procedure faz TRUNCATE
-- em uma tabela de resultado compartilhada (curva_abc_fabricante /
-- curva_abc_resultado) antes de recalcular. Se dois terminais rodarem a Curva
-- ABC ao mesmo tempo na mesma loja, um pode ver o resultado do outro pela metade.
-- Isso ja era uma limitacao da implementacao original de sp_curva_abc; nao foi
-- introduzida por este script. Para eliminar de vez, o proximo passo seria
-- parametrizar as tabelas de resultado por sessao/usuario, ou devolver o
-- resultado direto por SELECT sem passar por tabela intermediaria.
