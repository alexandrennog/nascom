DELIMITER $$

DROP PROCEDURE IF EXISTS `sp_recuperavendas` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendas`(IN nomevendedor varchar(30), IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS

SELECT vendedor, (SELECT count(*)
FROM nascomercio.vendas
where data >= dtIni and data <= dtFim and valorvenda>0
and vendedor = v.vendedor) as totalvendas, Sum(valorvenda) as valor, fu_getqtdprods(vendedor, dtIni, dtFim) as qtdprod
FROM nascomercio.v_vendassintetico as v
Where data >= dtIni and data <= dtFim
and vendedor = ifnull(nomevendedor, vendedor)
group by vendedor;

select vendedor, COALESCE(totalvendas,0) as totalvendas, valor, qtdprod ,valor/(totalvendas) as ticket ,  qtdprod/(totalvendas) as pa
from vendas_range
where vendedor = ifnull(nomevendedor, vendedor)
and totalvendas > 0
order by valor desc;

END $$

DELIMITER ;