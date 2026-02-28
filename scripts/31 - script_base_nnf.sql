CREATE TABLE `basennf` (
  `seqNFe` int(11) NOT NULL AUTO_INCREMENT,
  `chnfe` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`seqNFe`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



SELECT SUBSTRING(chNFe, 25, 9) as cupom, DATE_FORMAT(dhrecbto, '%d/%m/%Y') as datavenda, total 
FROM nascomercio.vendas
 INNER JOIN nascomercio.infprot ON chNFe = chave and cstat = 100
where chave is not null and data >= '2026-01-01' and data <= '2026-02-01';


