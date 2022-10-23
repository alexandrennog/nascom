DROP VIEW `nascomercio`.`v_vendas`;
CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `v_vendas` AS
    select 
        `vendas`.`controle` AS `controle`,
        `vendas`.`data` AS `data`,
        `produtos`.`descricao` AS `descricao`,
        `vendasprodutos`.`quantidade` AS `quantidade`,
        `produtos`.`valorCompra` AS `valorcompra`,
        `vendasprodutos`.`valor` AS `valorvenda`,
        `vendas`.`desconto` AS `desconto`,
        `vendas`.`vendedor` AS `vendedor`,
        `clientes`.`nome` AS `nome`,
        `vendas`.`troca` AS `troca`,
        `fabricantes`.`nome` AS `fabricante`,
        `produtos`.`referencia` AS `referencia`
    from
        ((((`vendasprodutos`
        join `produtos` ON ((`vendasprodutos`.`produto` = `produtos`.`cid`)))
        join `vendas` ON ((`vendasprodutos`.`controle` = `vendas`.`controle`)))
        join `clientes` ON ((`vendas`.`clienteId` = `clientes`.`cid`)))
        join `fabricantes` ON ((`produtos`.`fabricante_cid` = `fabricantes`.`cid`))) 
    union all select 
        `vales`.`controle` AS `controle`,
        `vales`.`data` AS `data`,
        `produtos`.`descricao` AS `descricao`,
        `valesprodutos`.`quantidade` AS `quantidade`,
        `produtos`.`valorCompra` AS `valorcompra`,
        `valesprodutos`.`valor` AS `valorvenda`,
        `vales`.`desconto` AS `desconto`,
        `vales`.`vendedor` AS `vendedor`,
        `clientes`.`nome` AS `nome`,
        `vales`.`troca` AS `troca`,
        `fabricantes`.`nome` AS `fabricante`,
        `produtos`.`referencia` AS `referencia`
    from
        ((((`valesprodutos`
        join `produtos` ON ((`valesprodutos`.`produto` = `produtos`.`cid`)))
        join `vales` ON ((`valesprodutos`.`controle` = `vales`.`controle`)))
        join `clientes` ON ((`vales`.`clienteId` = `clientes`.`cid`)))
        join `fabricantes` ON ((`produtos`.`fabricante_cid` = `fabricantes`.`cid`)))