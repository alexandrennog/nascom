DROP VIEW IF EXISTS `v_vendassintetico`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_vendassintetico` AS
select `vendas`.`controle` AS `controle`,`vendas`.`data` AS `data`,`vendas`.`total` AS `valorvenda`,`vendas`.`desconto` AS `desconto`,
`vendas`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,`vendas`.`troca` AS `troca`,`vendas`.`defeito` AS `defeito`,
`vendas`.`vale` AS `vale`, `vendas`.`valeEmitido` AS `valeEmitido`
from (`vendas` join `clientes` on((`vendas`.`clienteId` = `clientes`.`cid`)))
union all
select `vales`.`controle` AS `controle`,`vales`.`data` AS `data`,`vales`.`total` AS `valorvenda`,`vales`.`desconto` AS `desconto`,
`vales`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,`vales`.`troca` AS `troca`,`vales`.`defeito` AS `defeito`,
`vales`.`vale` AS `vale`, `vales`.`valeEmitido` AS `valeEmitido`
from (`vales` join `clientes` on((`vales`.`clienteId` = `clientes`.`cid`)));