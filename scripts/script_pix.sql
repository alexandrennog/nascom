DROP TABLE IF EXISTS `nascomercio`.`pixconfig`;
CREATE TABLE `nascomercio`.`pixconfig` (
  `Banco` varchar(40) DEFAULT NULL,
  `Cliente` int(11) DEFAULT NULL,
  `Cpf` varchar(11) DEFAULT NULL,
  `Cnpj` varchar(15) DEFAULT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `chave` varchar(60) DEFAULT NULL,
  `Client_id` varchar(134) DEFAULT NULL,
  `client_secret` varchar(234) DEFAULT NULL,
  `PathCertificate` varchar(255) DEFAULT NULL,
  `PassCertificate` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



DROP TABLE IF EXISTS `nascomercio`.`pix`;
CREATE TABLE `nascomercio`.`pix` (
  `ID` varchar(22) NOT NULL,
  `txID` varchar(36) DEFAULT NULL,
  `SolicitacaoPagador` varchar(80) DEFAULT NULL,
  `Original` decimal(12,2) DEFAULT NULL,
  `DataHora` datetime DEFAULT NULL,
  `Observacao` tinytext,
  `Status` varchar(32) DEFAULT NULL,
  `controle` int(10) unsigned NOT NULL,
  `UrlPix` varchar(255) DEFAULT NULL,
  `body` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



//Configuração com chaves Nascom
insert into pixconfig (`Banco` ,   `Cliente`,   `Cpf` ,  `Cnpj` ,  `Nome` ,  `chave` ,  `Client_id` ,  `client_secret` ,
  `PathCertificate`,   `PassCertificate` ,  `Email`)
  
  select 'MercadoPago',0,'','07925528000111', 'Alexandre Nogueira',	'APP_USR-38adb782-d748-44e4-8016-5ce431619a4e',	'8737633699267465',	'SAVyBHcttfl7ti9bCqrvAfcz3iTYqR4Z','','', 'alexandre@nascom.com.br';
  