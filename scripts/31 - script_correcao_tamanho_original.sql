ALTER TABLE `nascomercio`.`credpag` 
CHANGE COLUMN `Original` `Original` DECIMAL(10,2) NOT NULL DEFAULT '0.00' ;

ALTER TABLE `nascomercio`.`prevendas` 
CHANGE COLUMN `Original` `Original` DECIMAL(10,2) NOT NULL DEFAULT '0.00' ;

ALTER TABLE `nascomercio`.`vales` 
CHANGE COLUMN `Original` `Original` DECIMAL(10,2) NOT NULL DEFAULT '0.00' ;

ALTER TABLE `nascomercio`.`vendas` 
CHANGE COLUMN `Original` `Original` DECIMAL(10,2) NOT NULL DEFAULT '0.00' ;

ALTER TABLE `nascomercio`.`pix` 
CHANGE COLUMN `Original` `Original` DECIMAL(10,2) NOT NULL DEFAULT '0.00' ;
