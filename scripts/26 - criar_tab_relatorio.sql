
CREATE TABLE `tbrelatorioloja` (
  `vendedor` varchar(45) NOT NULL,
  `totalvendas` int(10) NOT NULL,
  `qtdprod` decimal(10,2) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `ticket` decimal(10,2) NOT NULL,
  `pa` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
  
  
  
 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_view_vendas_loja`(IN usuario varchar(20), IN dtIni datetime, IN dtFim datetime)
BEGIN

delete from tbrelatorioloja where usuario = usuario; 

Select @totVendas := (select count(*) FROM nascomercio.v_vendas Where data between dtIni AND dtFim) as totVendas;  
Select @totProd := ((Select count(*)   FROM nascomercio.vendasprodutos  where controle In(Select controle FROM nascomercio.v_vendas Where data between dtIni AND dtFim))) as totProd;  
select @valor := (SELECT sum(valorvenda) FROM nascomercio.v_vendas  Where data between dtIni AND dtFim) as valor;  

iNSERT INTO tbrelatorioloja( usuario, nome, vendedor, totalvendas, qtdprod, valor, ticket, pa)
Select v.vendedor, count(*)  as totalvendas, vp.qtdprod, ve.valor, ve.valor/count(*) as ticket, vp.qtdprod/count(*) as pa   
From nascomercio.vendas as v  inner join usuarios as u ON v.vendedor = u.usuario inner join (SELECT vendedor, count(*) As qtdprod      From nascomercio.vendas as v      inner join nascomercio.vendasprodutos as vp ON v.controle = vp.controle    Where data between dtIni AND dtFim group by vendedor) as vp ON vp.vendedor = v.vendedor   inner join (SELECT vendedor, sum(valorvenda) as valor   FROM nascomercio.v_vendas   Where data between dtIni AND dtFim  group by vendedor) as ve ON ve.vendedor = v.vendedor   Where data between dtIni AND dtFim  group by vendedor  
union all 
select '' as vendedor, @totVendas as totalvendas, @totProd as qtdprod, @valor, @valor/@totVendas as ticket, @totProd/@totVendas as pa;

END