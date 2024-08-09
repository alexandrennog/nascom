CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_backup`()
BEGIN

INSERT INTO nascomercio.recent_clients (nome, dddcel, celular, data_cobranca)
SELECT cl.nome, cl.dddcel, cl.celular, DATE_ADD(CURDATE(), INTERVAL 1 DAY)
FROM nascomercio.credpag as cr
INNER join nascomercio.clientes as cl ON cl.cid = cr.clienteId
WHERE DATE_FORMAT(data, '%d/%m/%Y') = DATE_FORMAT(CURDATE(), '%d/%m/%Y')
and cl.celular is not null;


SELECT cl.nome, cl.dddcel, cl.celular, DATE_ADD(CURDATE(), INTERVAL 1 DAY)
FROM nascomercio.credpag as cr
INNER join nascomercio.clientes as cl ON cl.cid = cr.clienteId
WHERE DATE_FORMAT(data, '%d/%m/%Y') = DATE_FORMAT('2024-05-27', '%d/%m/%Y')
and cl.celular is not null
INTO OUTFILE 'D:\\Projetos0\\orders.csv'
		FIELDS TERMINATED BY ','
		ENCLOSED BY '"'
		LINES TERMINATED BY '\n';


END

-- Create the stored procedure
DELIMITER //

CREATE EVENT faz_backup
    ON SCHEDULE EVERY 1 DAY
    DO 
        CALL sp_backup();


DELIMITER ;


-- Enable the event scheduler
SET GLOBAL event_scheduler = ON;