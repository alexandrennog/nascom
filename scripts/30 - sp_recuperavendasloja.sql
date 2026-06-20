DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_recuperavendasloja` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendasloja`(IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS

SELECT (SELECT count(*)
FROM nascomercio.vendas
where data >= dtIni and data <= dtFim and valorvenda>0) as totalvendas, Sum(valorvenda)  as valor, fu_getqtdprods(null, dtIni, dtFim) as qtdprod
FROM nascomercio.v_vendassintetico as v
Where data >= dtIni and data <= dtFim;

select (totalvendas) as totalvendas, valor, qtdprod ,valor/(totalvendas) as ticket ,  qtdprod/(totalvendas) as pa
from vendas_range
where totalvendas > 0
order by valor desc;

END $$

DELIMITER ;