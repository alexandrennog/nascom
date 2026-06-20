ALTER TABLE produtos
ADD COLUMN `cfop` varchar(4) DEFAULT NULL;

ALTER TABLE produtos
ADD COLUMN `ean_gtin` varchar(14) DEFAULT NULL;

ALTER TABLE produtos
ADD COLUMN `cest` varchar(7) DEFAULT NULL;


ALTER TABLE produtos
ADD COLUMN `ncm` varchar(150) DEFAULT NULL;



nome, unidade, preço, tributação, ncm, cest, 