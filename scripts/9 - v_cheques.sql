DROP VIEW IF EXISTS `v_cheques`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_cheques` AS
select `cheques`.`cid` AS `cid`,`cheques`.`valor` AS `valor`,`cheques`.`dataemissao` AS `dataemissao`,
`cheques`.`datadeposito` AS `datadeposito`,`cheques`.`numero` AS `numero`,`clientes`.`nome` AS `nome`,
`nascomercio`.`cheques`.`banconome` AS `banco`,`nascomercio`.`cheques`.`agencia` AS `agencia`,
`nascomercio`.`cheques`.`conta` AS `conta`,`nascomercio`.`cheques`.`baixado` AS `baixado`
from (`cheques` left join `clientes` on((`nascomercio`.`cheques`.`clienteid` = `nascomercio`.`clientes`.`cid`)));