CREATE TABLE `nascomercio`.`categoria` (
  `cid` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `situacao` CHAR(1) NOT NULL,
  PRIMARY KEY (`cid`)
)
ENGINE = InnoDB;

ALTER TABLE `nascomercio`.`produtos` ADD COLUMN `efdCodigoCategoria` VARCHAR(10) AFTER `efdIntegracao`;
