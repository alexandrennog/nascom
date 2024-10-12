DELIMITER $$

CREATE PROCEDURE sp_backup()
BEGIN
    INSERT INTO nascomercio.recent_clients (nome, dddcel, celular)
    SELECT cl.nome, cl.dddcel, cl.celular
    FROM nascomercio.credpag as cr
    INNER JOIN nascomercio.clientes as cl ON cl.cid = cr.clienteId
    WHERE DATE_FORMAT(cr.data, '%d/%m/%Y') = DATE_FORMAT(DATE_ADD(NOW(), INTERVAL 1 DAY), '%d/%m/%Y')
    AND cl.celular IS NOT NULL;
END$$

DELIMITER ;



DELIMITER //

CREATE EVENT carrega_tabela 
ON SCHEDULE EVERY 1 DAY
DO 
  INSERT INTO nascomercio.recent_clients (nome, dddcel, celular)
		SELECT cl.nome, cl.dddcel, cl.celular
		FROM nascomercio.credpag as cr
		INNER join nascomercio.clientes as cl ON cl.cid = cr.clienteId
		WHERE DATE_FORMAT(data, '%d/%m/%Y') = DATE_FORMAT(DATE_ADD(now(), INTERVAL 1 DAY), '%d/%m/%Y')
		and cl.celular is not null;
		
		

DELIMITER ;


DELIMITER //

CREATE EVENT faz_backup
    ON SCHEDULE EVERY 1 DAY
    STARTS '2024-08-03 14:00:00'
    DO BEGIN
        
        CALL sp_backup();

    END$$


DELIMITER ;