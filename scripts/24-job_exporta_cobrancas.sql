-- Create the stored procedure
DELIMITER //

CREATE 
    EVENT `exporta_cobrancas` 
    ON SCHEDULE EVERY '1 13' DAY_HOUR
    DO BEGIN
        
        call sp_update_controle();

    END;


DELIMITER ;


-- Enable the event scheduler
SET GLOBAL event_scheduler = ON;




