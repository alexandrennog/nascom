ALTER TABLE `nascomercio`.`prevendas` ADD COLUMN `ordemServico` VARCHAR(10) AFTER `vendedor`;
ALTER TABLE `nascomercio`.`vendas` ADD COLUMN `ordemServico` VARCHAR(10) AFTER `crediarioPagamento`;
