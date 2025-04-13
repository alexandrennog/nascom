SET GLOBAL event_scheduler = ON;

ALTER TABLE `pixconfig` 
MODIFY COLUMN `chave` varchar(60) DEFAULT NULL;


alter table pixconfig ADD COLUMN   `Email` varchar(255) DEFAULT NULL



CREATE TABLE `cobrancas_automaticas` (
  `codigocliente` int(10) DEFAULT NULL,
  `crediarioid` int(10) DEFAULT NULL,
  `parcelaidid` int(10) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `celular` varchar(80) DEFAULT NULL,
  `email` varchar(80) DEFAULT NULL,  
  `sucesso` varchar(1) DEFAULT NULL,
  `pix_code` varchar(255) DEFAULT NULL,
  `data_cobranca` date DEFAULT NULL,
  `datavencimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



CREATE TABLE `zapconfig` (
  `chave` varchar(250) DEFAULT NULL,
  `Client_id` varchar(30) DEFAULT NULL,
  `client_secret` varchar(50) DEFAULT NULL,
  `DataRenovacao` datetime DEFAULT NULL  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



INSERT INTO `nascomercio`.`zapconfig`
(`chave`,
`Client_id`,
`client_secret`,
`DataRenovacao`)
VALUES
('EAAVKluc85ZAYBO8EtatE0Jv3gBmYIjdXIKmaQ2cEFxc6bJbQrRXZB1VYSNRfJrl4gXZAnhkpPNhOZBN4jQZCnc3CXkW6FDkOH0SYs37LbtTNnFLjOXxCziVPgvCLZApvKIZCNkvVKBkGZBjVGLa3jLjWzjzOqpkrtbnmosjhAa8zcey8JiFQs5fhvzdeu2H8YYxcnlZC1MYbQZANTwtZAW7s3XJyNHWWCS3pO5HIMkZD',
'1489386868630934',
'd0a7a59876dd1d4d432269894602b3de',
'2024-10-20 08:00:00');