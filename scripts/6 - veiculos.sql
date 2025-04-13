DROP TABLE IF EXISTS `nascomercio`.`veiculo`;
CREATE TABLE  `nascomercio`.`veiculo` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `clienteid` int(10) unsigned NOT NULL,
  `placa` varchar(8) NOT NULL,
  `marca` varchar(45) DEFAULT NULL,
  `modelo` varchar(45) DEFAULT NULL,
  `cor` varchar(45) DEFAULT NULL,
  `ano` varchar(9) DEFAULT NULL,
  `combustivel` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`cid`),
  KEY `FK_Veiculo_1` (`clienteid`),
  CONSTRAINT `FK_Veiculo_1` FOREIGN KEY (`clienteid`) REFERENCES `clientes` (`cid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;