-- Create the stored procedure
DELIMITER //



-- Enable the event scheduler
SET GLOBAL event_scheduler = ON;

CREATE EVENT exporta_cobrancas
ON SCHEDULE EVERY 1 DAY
STARTS CURRENT_TIMESTAMP
DO
   CALL sp_update_controle();


DELIMITER ;






