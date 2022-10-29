DROP TABLE IF EXISTS `nascomercio`.`caixa`;
CREATE TABLE  `nascomercio`.`caixa` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `situacao` varchar(10) NOT NULL,
  `data` datetime NOT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  `nome` varchar(45) NOT NULL,
  PRIMARY KEY (`cid`),
  KEY `FK_caixa_1` (`usuario`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;