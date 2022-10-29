DROP VIEW IF EXISTS `v_vendasvendedor`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `nascomercio`.`v_vendasvendedor` AS
select
`nascomercio`.`vendas`.`controle` AS `controle`,`nascomercio`.`vendas`.`data` AS `data`,
`nascomercio`.`vendas`.`total` AS `valorvenda`,`nascomercio`.`vendas`.`desconto` AS `desconto`,
`nascomercio`.`vendas`.`vendedor` AS `vendedor`,`nascomercio`.`clientes`.`nome` AS `nome`,
`nascomercio`.`vendas`.`troca` AS `troca`,`nascomercio`.`vendas`.`defeito` AS `defeito`,
`nascomercio`.`vendas`.`vale` AS `vale`
from
`nascomercio`.`vendas` join `nascomercio`.`clientes` on `nascomercio`.`vendas`.`clienteId` = `nascomercio`.`clientes`.`cid`
join `nascomercio`.`usuarios` on `nascomercio`.`vendas`.`vendedor` = `nascomercio`.`usuarios`.`usuario`
union all
 select `nascomercio`.`vales`.`controle` AS `controle`,`nascomercio`.`vales`.`data` AS `data`,
 `nascomercio`.`vales`.`total` AS `valorvenda`,`nascomercio`.`vales`.`desconto` AS `desconto`,
 `nascomercio`.`vales`.`vendedor` AS `vendedor`,`nascomercio`.`clientes`.`nome` AS `nome`,
 `nascomercio`.`vales`.`troca` AS `troca`,`nascomercio`.`vales`.`defeito` AS `defeito`,
 `nascomercio`.`vales`.`vale` AS `vale`
 from `nascomercio`.`vales` join `nascomercio`.`clientes` on`nascomercio`.`vales`.`clienteId` = `nascomercio`.`clientes`.`cid`
join `nascomercio`.`usuarios` on `nascomercio`.`vales`.`vendedor` = `nascomercio`.`usuarios`.`usuario`
;