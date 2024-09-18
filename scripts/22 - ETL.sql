SET GLOBAL event_scheduler = ON;


CREATE TABLE `cobrancas_automaticas` (
  `crediarioid` int(10) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `dddcel` varchar(10) DEFAULT NULL,
  `celular` varchar(20) DEFAULT NULL,
  `sucesso` varchar(1) DEFAULT NULL,
  `pix_code` varchar(255) DEFAULT NULL,
  `data_cobranca` date DEFAULT NULL,
  `datavencimento` datetime DEFAULT NULL	
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


INSERT INTO nascomercio.cobrancas_automaticas (nome, dddcel, celular, data_cobranca)
SELECT cl.nome, cl.dddcel, cl.celular
FROM nascomercio.credpag as cr
INNER join nascomercio.clientes as cl ON cl.cid = cr.clienteId
WHERE DATE_FORMAT(data, '%d/%m/%Y') = DATE_FORMAT('2024-05-27', '%d/%m/%Y')
and cl.celular is not null;

