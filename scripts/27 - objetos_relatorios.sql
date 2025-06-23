CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendasloja`(IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS

select count(*) As totalvendas, ROUND(sum(valorvenda), 2) As valor, fu_getqtdprods(vendedor, dtIni, dtFim) as qtdprod
FROM nascomercio.v_vendas as v
Where data >= dtIni
and data <= dtFim;

select * , valor/totalvendas as ticket, qtdprod/totalvendas as pa
from vendas_range;

END


CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendas`(IN nomevendedor varchar(30), IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS
select *
FROM nascomercio.v_vendas
Where data >= dtIni
and data <= dtFim
and vendedor = ifnull(nomevendedor, vendedor);

SELECT count(*) into @qtdprodutos
FROM nascomercio.vendasprodutos
where controle in (select controle
FROM vendas_range);

select vendedor, count(*) As totalvendas, @qtdprodutos as qtdprod, ROUND(sum(valorvenda), 2) As valor, 
 ROUND(sum(valorvenda) / count(*), 2) As ticket, ROUND(@qtdprodutos / count(*), 2) as pa 
FROM vendas_range
 group by vendedor
 order by valor desc;
 
END




CREATE DEFINER=`root`@`localhost` FUNCTION `fu_getqtdprods`(nomevendedor varchar(30), dtIni datetime, dtFim datetime) RETURNS int(11)
BEGIN

SELECT count(*) into @qtdprodutos
FROM nascomercio.vendasprodutos
where controle in (select controle
FROM nascomercio.v_vendas
where vendedor = nomevendedor
and data >= dtIni 
and data <= dtFim);

RETURN @qtdprodutos;
END