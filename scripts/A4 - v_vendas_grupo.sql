CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `v_vendasgrupo` AS
    select 
        `vp`.`produto` AS `codigo`,
        `p`.`descricao` AS `produto`,
        `p`.`referencia` AS `referencia`,
        `c`.`nome` AS `cor`,
        `g`.`nome` AS `grupo`,
        `g`.`cid` AS `cd_grupo`,
        `vp`.`controle` AS `controle`,
        `vp`.`quantidade` AS `quantidade`,
        `vp`.`valor` AS `valor`,
        (`vp`.`quantidade` * `vp`.`valor`) AS `total_valor`
    from
        (((`vendasprodutos` `vp`
        join `produtos` `p` ON ((`p`.`codigo` = `vp`.`produto`)))
        join `categoria` `g` ON ((`g`.`cid` = `p`.`efdCodigoCategoria`)))
        join `cor` `c` ON ((`c`.`cid` = `p`.`cor_cid`)))