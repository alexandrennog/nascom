
DROP TABLE IF EXISTS `nascomercio`.`pix`;

DROP TABLE IF EXISTS `nascomercio`.`pixconfig`;





DROP TABLE IF EXISTS `nascomercio`.`pix`;
CREATE TABLE  `nascomercio`.`pix` (
  `ID` varchar(22) DEFAULT NULL,
  `txID` varchar(36) DEFAULT NULL,
  `SolicitacaoPagador` varchar(80) DEFAULT NULL,
  `Original` decimal(5,2) DEFAULT NULL,
  `DataHora` datetime DEFAULT NULL,
  `Observacao` tinytext,
  `Status` varchar(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `nascomercio`.`pixconfig`;
CREATE TABLE  `nascomercio`.`pixconfig` (
  `Cliente` int(11) DEFAULT NULL,
  `Cpf` varchar(11) DEFAULT NULL,
  `Cnpj` varchar(15) DEFAULT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `chave` varchar(36) DEFAULT NULL,
  `Appkey`  varchar(40) DEFAULT NULL,
  `Client_id`  varchar(134) DEFAULT NULL,
  `client_secret`  varchar(234) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

insert into `nascomercio`.`pixconfig` (Cliente, Cpf, Cnpj, Nome, chave, Appkey, Client_id, client_secret)
  VALUES (20,'12345678909','','Yuri Roberto Jorge Barros', '7f6844d0-de89-47e5-9ef7-e0a35a681615', '7f6844d0-de89-47e5-9ef7-e0a35a681615', 'eyJpZCI6ImY3NDAxY2YtYTljOC00MjMzLTliY2IiLCJjb2RpZ29QdWJsaWNhZG9yIjowLCJjb2RpZ29Tb2Z0d2FyZSI6NDIzOTcsInNlcXVlbmNpYWxJbnN0YWxhY2FvIjoxfQ', 'eyJpZCI6IjA0Yjc3NWYtYmE3Ny00NzRjLTk2NjctZjliYiIsImNvZGlnb1B1YmxpY2Fkb3IiOjAsImNvZGlnb1NvZnR3YXJlIjo0MjM5Nywic2VxdWVuY2lhbEluc3RhbGFjYW8iOjEsInNlcXVlbmNpYWxDcmVkZW5jaWFsIjoxLCJhbWJpZW50ZSI6ImhvbW9sb2dhY2FvIiwiaWF0IjoxNjYxMjk4OTgxODI5fQ');
  
  
ALTER TABLE `credpag` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `prevendas` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `vales` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `vendas` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0; 
ALTER TABLE `pix` ADD `controle` int(10) unsigned NOT NULL;

  
  
 
DROP VIEW IF EXISTS `nascomercio`.`v_fechamento`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW  `nascomercio`.`v_fechamento` AS select `vendas`.`controle` AS `controle`,`vendas`.`clienteId` AS `clienteId`,`vendas`.`usuarioId` AS `usuarioId`,`vendas`.`data` AS `data`,`vendas`.`dinheiro` AS `dinheiro`,`vendas`.`Original` AS `pix`,`vendas`.`cheque` AS `cheque`,`vendas`.`chequePre` AS `chequePre`,`vendas`.`cartaoDebito` AS `cartaoDebito`,`vendas`.`cartaoCredito` AS `cartaoCredito`,`vendas`.`crediario` AS `crediario`,`vendas`.`parcelas` AS `parcelas`,`vendas`.`desconto` AS `desconto`,`vendas`.`condicao` AS `condicao`,`vendas`.`recebido` AS `recebido`,`vendas`.`troco` AS `troco`,`vendas`.`total` AS `total`,`vendas`.`troca` AS `troca`,`vendas`.`vale` AS `vale`,`vendas`.`defeito` AS `defeito`,`vendas`.`terminal` AS `terminal`,`vendas`.`retirada` AS `retirada`,`vendas`.`valeEmitido` AS `valeEmitido`,`vendas`.`vendedor` AS `vendedor`,`vendas`.`caixa` AS `caixa`,`vendas`.`crediarioPagamento` AS `crediarioPagamento` from `vendas` union all select `vales`.`controle` AS `controle`,`vales`.`clienteId` AS `clienteId`,`vales`.`usuarioId` AS `usuarioId`,`vales`.`data` AS `data`,`vales`.`dinheiro` AS `dinheiro`,`vales`.`Original` AS `pix`,`vales`.`cheque` AS `cheque`,`vales`.`chequePre` AS `chequePre`,`vales`.`cartaoDebito` AS `cartaoDebito`,`vales`.`cartaoCredito` AS `cartaoCredito`,`vales`.`crediario` AS `crediario`,`vales`.`parcelas` AS `parcelas`,`vales`.`desconto` AS `desconto`,`vales`.`condicao` AS `condicao`,`vales`.`recebido` AS `recebido`,`vales`.`troco` AS `troco`,`vales`.`total` AS `total`,`vales`.`troca` AS `troca`,`vales`.`vale` AS `vale`,`vales`.`defeito` AS `defeito`,`vales`.`terminal` AS `terminal`,`vales`.`retirada` AS `retirada`,`vales`.`valeEmitido` AS `valeEmitido`,`vales`.`vendedor` AS `vendedor`,`vales`.`caixa` AS `caixa`,`vales`.`crediarioPagamento` AS `crediarioPagamento` from `vales` union all select `credpag`.`controle` AS `controle`,`credpag`.`clienteId` AS `clienteId`,`credpag`.`usuarioId` AS `usuarioId`,`credpag`.`data` AS `data`,`credpag`.`dinheiro` AS `dinheiro`,`credpag`.`Original` AS `pix`,`credpag`.`cheque` AS `cheque`,`credpag`.`chequePre` AS `chequePre`,`credpag`.`cartaoDebito` AS `cartaoDebito`,`credpag`.`cartaoCredito` AS `cartaoCredito`,`credpag`.`crediario` AS `crediario`,`credpag`.`parcelas` AS `parcelas`,`credpag`.`desconto` AS `desconto`,`credpag`.`condicao` AS `condicao`,`credpag`.`recebido` AS `recebido`,`credpag`.`troco` AS `troco`,`credpag`.`total` AS `total`,`credpag`.`troca` AS `troca`,`credpag`.`vale` AS `vale`,`credpag`.`defeito` AS `defeito`,`credpag`.`terminal` AS `terminal`,`credpag`.`retirada` AS `retirada`,`credpag`.`valeEmitido` AS `valeEmitido`,`credpag`.`vendedor` AS `vendedor`,`credpag`.`caixa` AS `caixa`,`credpag`.`crediarioPagamento` AS `crediarioPagamento` from `credpag`;


DROP VIEW IF EXISTS `v_fechamento`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_fechamento` AS
select `vendas`.`controle` AS `controle`,`vendas`.`clienteId` AS `clienteId`,`vendas`.`usuarioId` AS `usuarioId`,`vendas`.`data` AS `data`,
`vendas`.`dinheiro` AS `dinheiro`,`vendas`.`Original` AS `pix`,`vendas`.`cheque` AS `cheque`,`vendas`.`chequePre` AS `chequePre`,
`vendas`.`cartaoDebito` AS `cartaoDebito`,`vendas`.`cartaoCredito` AS `cartaoCredito`,`vendas`.`crediario` AS `crediario`,
`vendas`.`parcelas` AS `parcelas`,`vendas`.`desconto` AS `desconto`,`vendas`.`condicao` AS `condicao`,`vendas`.`recebido` AS `recebido`,
`vendas`.`troco` AS `troco`,`vendas`.`total` AS `total`,`vendas`.`troca` AS `troca`,`vendas`.`vale` AS `vale`,`vendas`.`defeito` AS `defeito`,
`vendas`.`terminal` AS `terminal`,`vendas`.`retirada` AS `retirada`,`vendas`.`valeEmitido` AS `valeEmitido`,`vendas`.`vendedor` AS `vendedor`,
`vendas`.`caixa` AS `caixa`,`vendas`.`crediarioPagamento` AS `crediarioPagamento` from `vendas`
union all
select `vales`.`controle` AS `controle`,`vales`.`clienteId` AS `clienteId`,`vales`.`usuarioId` AS `usuarioId`,`vales`.`data` AS `data`,
`vales`.`dinheiro` AS `dinheiro`,`vales`.`Original` AS `pix`,`vales`.`cheque` AS `cheque`,`vales`.`chequePre` AS `chequePre`,`vales`.`cartaoDebito` AS `cartaoDebito`,
`vales`.`cartaoCredito` AS `cartaoCredito`,`vales`.`crediario` AS `crediario`,`vales`.`parcelas` AS `parcelas`,`vales`.`desconto` AS `desconto`,
`vales`.`condicao` AS `condicao`,`vales`.`recebido` AS `recebido`,`vales`.`troco` AS `troco`,`vales`.`total` AS `total`,`vales`.`troca` AS `troca`,
`vales`.`vale` AS `vale`,`vales`.`defeito` AS `defeito`,`vales`.`terminal` AS `terminal`,`vales`.`retirada` AS `retirada`,
`vales`.`valeEmitido` AS `valeEmitido`,`vales`.`vendedor` AS `vendedor`,`vales`.`caixa` AS `caixa`,
`vales`.`crediarioPagamento` AS `crediarioPagamento` from `vales`
union all
select `credpag`.`controle` AS `controle`,`credpag`.`clienteId` AS `clienteId`,`credpag`.`usuarioId` AS `usuarioId`,
`credpag`.`data` AS `data`,`credpag`.`dinheiro` AS `dinheiro`,`credpag`.`Original` AS `pix`,`credpag`.`cheque` AS `cheque`,`credpag`.`chequePre` AS `chequePre`,
`credpag`.`cartaoDebito` AS `cartaoDebito`,`credpag`.`cartaoCredito` AS `cartaoCredito`,`credpag`.`crediario` AS `crediario`,
`credpag`.`parcelas` AS `parcelas`,`credpag`.`desconto` AS `desconto`,`credpag`.`condicao` AS `condicao`,`credpag`.`recebido` AS `recebido`,
`credpag`.`troco` AS `troco`,`credpag`.`total` AS `total`,`credpag`.`troca` AS `troca`,`credpag`.`vale` AS `vale`,`credpag`.`defeito` AS `defeito`,
`credpag`.`terminal` AS `terminal`,`credpag`.`retirada` AS `retirada`,`credpag`.`valeEmitido` AS `valeEmitido`,`credpag`.`vendedor` AS `vendedor`,
`credpag`.`caixa` AS `caixa`,`credpag`.`crediarioPagamento` AS `crediarioPagamento` from `credpag`;



DROP VIEW IF EXISTS `v_vendas`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_vendas` 
AS 
select `vendas`.`controle` AS `controle`,`vendas`.`data` AS `data`,`produtos`.`descricao` AS `descricao`,`vendasprodutos`.`quantidade` AS `quantidade`,`produtos`.`valorCompra` AS `valorcompra`,`vendasprodutos`.`valor` AS `valorvenda`,`vendas`.`desconto` AS `desconto`,`vendas`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,`vendas`.`troca` AS `troca`,`fabricantes`.`nome` AS `fabricante`,`produtos`.`referencia` AS `referencia` from ((((`vendasprodutos` join `produtos` on((`vendasprodutos`.`produto` = `produtos`.`cid`))) join `vendas` on((`vendasprodutos`.`controle` = `vendas`.`controle`))) join `clientes` on((`vendas`.`clienteId` = `clientes`.`cid`))) join `fabricantes` on((`produtos`.`fabricante_cid` = `fabricantes`.`cid`))) 
union all 
select `vales`.`controle` AS `controle`,`vales`.`data` AS `data`,`produtos`.`descricao` AS `descricao`,`vendasprodutos`.`quantidade` AS `quantidade`,`produtos`.`valorCompra` AS `valorcompra`,`vendasprodutos`.`valor` AS `valorvenda`,`vales`.`desconto` AS `desconto`,`vales`.`vendedor` AS `vendedor`,`clientes`.`nome` AS `nome`,`vales`.`troca` AS `troca`,`fabricantes`.`nome` AS `fabricante`,`produtos`.`referencia` AS `referencia` from ((((`vendasprodutos` join `produtos` on((`vendasprodutos`.`produto` = `produtos`.`cid`))) join `vales` on((`vendasprodutos`.`controle` = `vales`.`controle`))) join `clientes` on((`vales`.`clienteId` = `clientes`.`cid`))) join `fabricantes` on((`produtos`.`fabricante_cid` = `fabricantes`.`cid`)));



INSERT INTO parametros(cid, descricao, valor)
select 21, 'IsDecimal', 1


INSERT INTO parametros(cid, descricao, valor)
select 22, 'Security', 1


INSERT INTO parametros(cid, descricao, valor)
select 23, 'Instancias', 3
