DROP VIEW IF EXISTS `v_vendassintetico`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_vendassintetico` AS
select `vendas`.`controle` AS `controle`,`vendas`.`data` AS `data`,
`vendas`.`total` - `vendas`.`troco`AS `valorTotal`,
`vendas`.`desconto` AS `desconto`,`vendas`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,
`vendas`.`troca` AS `troca`,`vendas`.`defeito` AS `defeito`,`vendas`.`vale` AS `vale`,
`vendas`.`valeEmitido` AS `valeEmitido`,
`vendas`.`crediario` + `vendas`.`dinheiro` + `vendas`.`cheque` +`vendas`.`chequePre` +`vendas`.`Original` + `vendas`.`cartaoDebito`+ `vendas`.`cartaoCredito`-`vendas`.`troco` AS `valorvenda`
from (`vendas` join `clientes` on((`vendas`.`clienteId` = `clientes`.`cid`)))
union all
select `vales`.`controle` AS `controle`,`vales`.`data` AS `data`,
`vales`.`total` - `vales`.`troco` AS `valorTotal`,
`vales`.`desconto` AS `desconto`,`vales`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,
`vales`.`troca` AS `troca`,`vales`.`defeito` AS `defeito`,`vales`.`vale` AS `vale`,
`vales`.`valeEmitido` AS `valeEmitido`,
`vales`.`crediario` + `vales`.`dinheiro` + `vales`.`cheque` +`vales`.`chequePre` +`vales`.`Original` + `vales`.`cartaoDebito`+ `vales`.`cartaoCredito`-`vales`.`troco` AS `valorvenda`
from (`vales` join `clientes` on((`vales`.`clienteId` = `clientes`.`cid`)));