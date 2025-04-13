DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_update_controle`()
BEGIN

INSERT INTO nascomercio.cobrancas_automaticas (codigocliente, crediarioid, parcelaidid, valor, nome, email, celular, datavencimento)
SELECT c.cid, p.crediarioid, p.cid, p.valor, c.nome as SolicitacaoPagador,  email, concat(dddcel, celular) as celular, DATE_ADD(CURDATE(), INTERVAL 1 DAY) as data_vencimento
FROM nascomercio.crediario as cr 
   inner join clientes as c on cr.clienteid = c.cid
   inner join parcelas as p on p.crediarioid = cr.cid
WHERE DATE_FORMAT(p.datavencimento, '%d/%m/%Y') = DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL 1 DAY), '%d/%m/%Y')
AND dddcel is not null
AND p.valorPago = 0.00;



set @total = (Select MAX(controle) as controle From vendas);

INSERT INTO pix (ID, SolicitacaoPagador, Original, DataHora, Observacao, controle) 
select *,  @total:=@total + 1 as numlinha
from (
SELECT p.cid, c.nome as SolicitacaoPagador, p.valor, DATE_ADD(CURDATE(), INTERVAL 1 DAY) as data_vencimento, 'parcela do crediário'
FROM nascomercio.crediario as cr 
   inner join clientes as c on cr.clienteid = c.cid
   inner join parcelas as p on p.crediarioid = cr.cid
WHERE DATE_FORMAT(p.datavencimento, '%d/%m/%Y') = DATE_FORMAT(DATE_ADD(CURDATE(), INTERVAL 1 DAY), '%d/%m/%Y')
AND dddcel is not null
AND p.valorPago = 0.00
) as lista;


END$$

DELIMITER ;
