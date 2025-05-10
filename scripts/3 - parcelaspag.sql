DROP TABLE IF EXISTS `nascomercio`.`parcelaspag`;
CREATE TABLE  `nascomercio`.`parcelaspag` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `parcelasid` int(10) unsigned NOT NULL,
  `valorPago` decimal(10,2) NOT NULL,
  `dataPagamento` datetime NOT NULL,
  `diasAtraso` varchar(45) NOT NULL,
  PRIMARY KEY (`cid`),
  KEY `FK_parcelaspag_1` (`parcelasid`),
  CONSTRAINT `FK_parcelaspag_1` FOREIGN KEY (`parcelasid`) REFERENCES `parcelas` (`cid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;