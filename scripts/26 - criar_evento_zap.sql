
-- Enable the event scheduler
SET GLOBAL event_scheduler = ON;


-- Create the stored procedure
DELIMITER //



CREATE EVENT exporta_cobrancas
ON SCHEDULE EVERY 1 DAY
STARTS '2025-02-04 14:00:00'
DO
   CALL sp_update_controle();



DELIMITER ;






