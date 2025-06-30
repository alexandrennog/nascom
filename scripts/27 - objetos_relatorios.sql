
DELIMITER $$
DROP FUNCTION IF EXISTS `fu_getqtdprods` $$
CREATE DEFINER=`root`@`localhost` FUNCTION `fu_getqtdprods`(nomevendedor VARCHAR(30),
    dtIni DATETIME,
    dtFim DATETIME) RETURNS int(11)
BEGIN

DECLARE qtdprodutos INT;
DECLARE qtdvales INT;

	SELECT sum(quantidade) INTO qtdvales
	FROM nascomercio.vales as v
		inner join nascomercio.valesprodutos as vp ON vp.controle = v.controle
    Where data >= dtIni and data <= dtFim
    and vendedor = ifnull(nomevendedor, vendedor)
	and vp.produto <> 4055;


	SELECT sum(quantidade) INTO qtdprodutos
	FROM nascomercio.vendas as v
		inner join nascomercio.vendasprodutos as vp ON vp.controle = v.controle
    Where data >= dtIni and data <= dtFim
	and vendedor = ifnull(nomevendedor, vendedor)
	and vp.produto <> 4055;

    RETURN ifNull(qtdprodutos,0) + IfNull(qtdvales,0);

END$$

DELIMITER;

DELIMITER $$
DROP PROCEDURE IF EXISTS `sp_recuperavendas` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendas`(IN nomevendedor varchar(30), IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS

SELECT vendedor, (SELECT count(*)
FROM nascomercio.vendas
where data >= dtIni and data <= dtFim
and vendedor = v.vendedor) as totalvendas, Sum(valorvenda)-((Sum(troca)+Sum(defeito))-(Sum(valeEmitido)) + Sum(vale)) as valor, fu_getqtdprods(vendedor, dtIni, dtFim) as qtdprod
FROM nascomercio.v_vendassintetico as v
Where data >= dtIni and data <= dtFim
and vendedor = ifnull(nomevendedor, vendedor)
group by vendedor;

select vendedor, (totalvendas -1) as totalvendas, valor, qtdprod ,valor/(totalvendas - 1) as ticket ,  qtdprod/(totalvendas - 1) as pa
from vendas_range
where vendedor = ifnull(nomevendedor, vendedor)
order by valor desc;

END$$

DELIMITER;

DELIMITER $$
DROP PROCEDURE IF EXISTS `sp_recuperavendasloja` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_recuperavendasloja`(IN dtIni datetime, IN dtFim datetime)
BEGIN

DROP TEMPORARY TABLE IF EXISTS vendas_range;
CREATE TEMPORARY TABLE vendas_range
AS

SELECT (SELECT count(*)
FROM nascomercio.vendas
where data >= dtIni and data <= dtFim) as totalvendas, Sum(valorvenda)-((Sum(troca)+Sum(defeito))-(Sum(valeEmitido)) + Sum(vale)) as valor, fu_getqtdprods(null, dtIni, dtFim) as qtdprod
FROM nascomercio.v_vendassintetico as v
Where data >= dtIni and data <= dtFim;

select (totalvendas -1) as totalvendas, valor, qtdprod ,valor/(totalvendas - 1) as ticket ,  qtdprod/(totalvendas - 1) as pa
from vendas_range
order by valor desc;

END$$

DELIMITER;

