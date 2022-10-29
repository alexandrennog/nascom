DROP TABLE IF EXISTS `nascomercio`.`ordemservico`;
CREATE TABLE  `nascomercio`.`ordemservico` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `clienteid` int(10) unsigned NOT NULL,
  `veiculoid` int(10) unsigned NOT NULL,
  `observacoes` varchar(1000) NOT NULL,
  `emissao` datetime NOT NULL,
  `vendedor` varchar(45) NOT NULL,
  `loja` varchar(45) NOT NULL,
  `situacao` varchar(10) NOT NULL,
  PRIMARY KEY (`cid`),
  KEY `FK_OrdemServico_1` (`clienteid`),
  KEY `FK_OrdemServico_2` (`veiculoid`),
  CONSTRAINT `FK_OrdemServico_1` FOREIGN KEY (`clienteid`) REFERENCES `clientes` (`cid`),
  CONSTRAINT `FK_OrdemServico_2` FOREIGN KEY (`veiculoid`) REFERENCES `veiculo` (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;