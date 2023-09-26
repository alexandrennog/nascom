DROP TABLE IF EXISTS `nascomercio`.`pixconfig`;
CREATE TABLE  `nascomercio`.`pixconfig` (
  `Banco` varchar(40) DEFAULT NULL,
  `Cliente` int(11) DEFAULT NULL,
  `Cpf` varchar(11) DEFAULT NULL,
  `Cnpj` varchar(15) DEFAULT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `chave` varchar(40) DEFAULT NULL,
  `UrlPix` varchar(255) DEFAULT NULL
  `Client_id` varchar(134) DEFAULT NULL,
  `client_secret` varchar(234) DEFAULT NULL,
  `PathCertificate` varchar(255) DEFAULT NULL,
  `PassCertificate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS `nascomercio`.`pix`;
CREATE TABLE  `nascomercio`.`pix` (
  `ID` varchar(22) DEFAULT NULL,
  `txID` varchar(36) DEFAULT NULL,
  `SolicitacaoPagador` varchar(80) DEFAULT NULL,
  `Original` decimal(5,2) DEFAULT NULL,
  `DataHora` datetime DEFAULT NULL,
  `Observacao` tinytext,
  `Status` varchar(32) DEFAULT NULL,
  `controle` int(10) unsigned NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;