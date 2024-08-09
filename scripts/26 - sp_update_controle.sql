DELIMITER $$

CREATE PROCEDURE sp_update_controle()
BEGIN

  CREATE TEMPORARY TABLE `pix_temp` (
  `ID` varchar(22) DEFAULT NULL,
  `txID` varchar(36) DEFAULT NULL,
  `SolicitacaoPagador` varchar(80) DEFAULT NULL,
  `Original` decimal(12,2) DEFAULT NULL,
  `DataHora` datetime DEFAULT NULL,
  `Observacao` tinytext,
  `Status` varchar(32) DEFAULT NULL,
  `controle` int(10) unsigned NOT NULL,
  `UrlPix` varchar(255) DEFAULT NULL,
  `body` text
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8;

	SET @row_number = (Select MAX(controle) as controle From vendas);

	INSERT INTO pix_temp (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle)  
	SELECT p.crediarioid, c.nome as SolicitacaoPagador, p.valor, DATE_ADD(CURDATE(), INTERVAL 1 DAY) as data_vencimento, 'parcela do crediário',
	@row_number := @row_number + 1 AS controle

	FROM nascomercio.crediario as cr 
	   inner join clientes as c on cr.clienteid = c.cid
	   inner join parcelas as p on p.crediarioid = cr.cid
	WHERE DATE_FORMAT(p.datavencimento, '%d/%m/%Y') = DATE_FORMAT('2023-08-02', '%d/%m/%Y')
	AND dddcel is not null;


	INSERT INTO pix (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle)  
	select ID, SolicitacaoPagador, Original, DataHora, Observacao, controle
	from pix_temp;


END$$

DELIMITER ;
