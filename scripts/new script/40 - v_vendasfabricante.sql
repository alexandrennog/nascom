-- View usada pelo relatório "Vendas x Fabricante" (fRelatorioVendasFabricante.vb).
-- Segue o mesmo padrão da view v_vendasfornecedor (vendas normais + vales, agrupado por fabricante).
-- Rodar este script direto no MySQL da loja (mesma base da connection string do app.config) antes de usar a tela nova.
--
-- OBS: produtos nao tem coluna "cor" direta, so "cor_cid" (FK pra tabela cor) -- por isso o join com `cor`.
--
-- OBS2: "quantidade" e "total_valor" aqui sao convertidos explicitamente pra SIGNED (em vez de
-- ficarem como INT UNSIGNED, que e' o tipo real da coluna em vendasprodutos/valesprodutos). O
-- relatorio "Vendas por Fabricante" estava vindo com a coluna Quantidade sempre em branco -- os
-- outros campos (texto) vinham certos, so os numericos vindos como UNSIGNED de dentro de uma VIEW
-- deram problema no binding do ReportViewer/MySqlDataAdapter. Convertendo pra SIGNED aqui evita
-- esse problema (os valores nunca sao negativos na pratica, entao não tem perda nenhuma).

DROP VIEW IF EXISTS `nascomercio`.`v_vendasfabricante`;

CREATE
    ALGORITHM = UNDEFINED
    DEFINER = `root`@`localhost`
    SQL SECURITY DEFINER
VIEW `v_vendasfabricante` AS
    select
        `produtos`.`codigo`            AS `codigo`,
        `produtos`.`descricao`         AS `produto`,
        `produtos`.`referencia`        AS `referencia`,
        `cor`.`nome`                   AS `cor`,
        `fabricantes`.`nome`           AS `fabricante`,
        `fabricantes`.`cid`            AS `cd_fabricante`,
        `vendasprodutos`.`controle`    AS `controle`,
        CAST(`vendasprodutos`.`quantidade` AS SIGNED) AS `quantidade`,
        `vendasprodutos`.`valor`       AS `valor`,
        CAST((`vendasprodutos`.`quantidade` * `vendasprodutos`.`valor`) AS DECIMAL(14,2)) AS `total_valor`,
        `vendas`.`data`                AS `data`
    from
        ((((`vendasprodutos`
        join `produtos` ON ((`vendasprodutos`.`produto` = `produtos`.`cid`)))
        join `vendas` ON ((`vendasprodutos`.`controle` = `vendas`.`controle`)))
        join `fabricantes` ON ((`produtos`.`fabricante_cid` = `fabricantes`.`cid`)))
        left join `cor` ON ((`produtos`.`cor_cid` = `cor`.`cid`)))
    union all select
        `produtos`.`codigo`            AS `codigo`,
        `produtos`.`descricao`         AS `produto`,
        `produtos`.`referencia`        AS `referencia`,
        `cor`.`nome`                   AS `cor`,
        `fabricantes`.`nome`           AS `fabricante`,
        `fabricantes`.`cid`            AS `cd_fabricante`,
        `valesprodutos`.`controle`     AS `controle`,
        CAST(`valesprodutos`.`quantidade` AS SIGNED) AS `quantidade`,
        `valesprodutos`.`valor`        AS `valor`,
        CAST((`valesprodutos`.`quantidade` * `valesprodutos`.`valor`) AS DECIMAL(14,2)) AS `total_valor`,
        `vales`.`data`                 AS `data`
    from
        ((((`valesprodutos`
        join `produtos` ON ((`valesprodutos`.`produto` = `produtos`.`cid`)))
        join `vales` ON ((`valesprodutos`.`controle` = `vales`.`controle`)))
        join `fabricantes` ON ((`produtos`.`fabricante_cid` = `fabricantes`.`cid`)))
        left join `cor` ON ((`produtos`.`cor_cid` = `cor`.`cid`)));
