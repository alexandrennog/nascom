DROP TABLE IF EXISTS `nascomercio`.`pixconfig`;
CREATE TABLE  `nascomercio`.`pixconfig` (
  `Cliente` int(11) DEFAULT NULL,
  `Cpf` varchar(11) DEFAULT NULL,
  `Cnpj` varchar(15) DEFAULT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `chave` varchar(40) DEFAULT NULL,
  `Appkey` varchar(40) DEFAULT NULL,
  `Client_id` varchar(134) DEFAULT NULL,
  `client_secret` varchar(234) DEFAULT NULL,
  `PathCertificate` varchar(255) DEFAULT NULL,
  `PassCertificate` varchar(255) DEFAULT NULL
) ENGINE=InnoDB;