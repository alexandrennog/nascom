ALTER TABLE `vendas` ADD COLUMN `chave` varchar(45)


CREATE TABLE `infprot` (
  `chnfe` varchar(50) DEFAULT NULL,
  `tpamb` int(11) DEFAULT NULL,
  `veraplic` varchar(20) DEFAULT NULL,
  `dhrecbto` datetime DEFAULT NULL,
  `nprot` varchar(50) DEFAULT NULL,
  `digval` varchar(100) DEFAULT NULL,
  `cstat` int(11) DEFAULT NULL,
  `xmotivo` varchar(255) DEFAULT NULL,
  `cmsg` varchar(50) DEFAULT NULL,
  `xmsg` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



ALTER TABLE lojas ADD `inscestadual` varchar(20) DEFAULT NULL

ALTER TABLE infprot ADD `xEvento` varchar(255) DEFAULT NULL;


CREATE TABLE `lojas` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nomeFantasia` varchar(100) DEFAULT NULL,
  `logradouro` varchar(100) DEFAULT NULL,
  `cidade` varchar(100) DEFAULT NULL,
  `numero` int(10) unsigned DEFAULT NULL,
  `complemento` varchar(100) DEFAULT NULL,
  `bairro` varchar(100) DEFAULT NULL,
  `estado_cid` tinyint(3) unsigned DEFAULT NULL,
  `cep` int(10) unsigned DEFAULT NULL,
  `ddd` int(10) unsigned DEFAULT NULL,
  `telefone` int(10) unsigned DEFAULT NULL,
  `ramal` int(10) unsigned DEFAULT NULL,
  `nomeContato` varchar(100) DEFAULT NULL,
  `razaoSocial` varchar(100) DEFAULT NULL,
  `cnpj` varchar(20) DEFAULT NULL,
  `codigo` varchar(10) DEFAULT NULL,
  `situacao` varchar(1) DEFAULT NULL,
  `spc_codigo_associado` varchar(8) DEFAULT NULL,
  `spc_nome_informante` varchar(35) DEFAULT NULL,
  `spc_controle_informante` varchar(10) DEFAULT NULL,
  `inscestadual` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`cid`),
  KEY `FK_lojas_estados` (`estado_cid`),
  CONSTRAINT `FK_lojas_estados` FOREIGN KEY (`estado_cid`) REFERENCES `estados` (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
