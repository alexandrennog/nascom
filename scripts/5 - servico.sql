DROP TABLE IF EXISTS `nascomercio`.`servico`;
CREATE TABLE  `nascomercio`.`servico` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `situacao` char(1) NOT NULL,
  PRIMARY KEY (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;