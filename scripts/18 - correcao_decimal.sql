DELIMITER $$

DROP FUNCTION IF EXISTS `isNumeric` $$
CREATE DEFINER=`root`@`localhost` FUNCTION `isNumeric`(
  input VARCHAR(255)
) RETURNS int(11)
    DETERMINISTIC
RETURN input REGEXP '/[^A-Z]/ig' $$

DELIMITER ;


DROP VIEW IF EXISTS `v_estoque`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_estoque` AS
select `p`.`cid` AS `cid`,`p`.`codigo` AS `codigo`,`p`.`descricao` AS `descricao`,`p`.`produtoTipo_cid` AS `produtoTipo_cid`,
`p`.`fornecedor_cid` AS `fornecedor_cid`,`p`.`situacao` AS `situacao`,`p`.`dataInclusao` AS `dataInclusao`,`p`.`valorCompra` AS `valorCompra`,
`p`.`valorVenda` AS `valorVenda`,`p`.`imagem` AS `imagem`,`p`.`fabricante_cid` AS `fabricante_cid`,`p`.`referencia` AS `referencia`,
`i`.`produtos_cid` AS `produtos_cid`,`i`.`item` AS `item`,`i`.`caracteristicas_cid` AS `caracteristicas_cid`,
format(replace(i.valor,',', '.'),0) as valor,
`f`.`nome` AS `fabricante`,`o`.`nome` AS `fornecedor`
from (((`produtos` `p` join `produtoitem` `i` on((`p`.`cid` = `i`.`produtos_cid`)))
join `fabricantes` `f` on((`f`.`cid` = `p`.`fabricante_cid`)))
join `fornecedores` `o` on((`o`.`cid` = `p`.`fornecedor_cid`)))
where (`i`.`caracteristicas_cid` = 2)
and isNumeric(valor) = 0
and 0 = (SELECT valor FROM parametros where  descricao = 'IsDecimal')

union all

select `p`.`cid` AS `cid`,`p`.`codigo` AS `codigo`,`p`.`descricao` AS `descricao`,`p`.`produtoTipo_cid` AS `produtoTipo_cid`,
`p`.`fornecedor_cid` AS `fornecedor_cid`,`p`.`situacao` AS `situacao`,`p`.`dataInclusao` AS `dataInclusao`,`p`.`valorCompra` AS `valorCompra`,
`p`.`valorVenda` AS `valorVenda`,`p`.`imagem` AS `imagem`,`p`.`fabricante_cid` AS `fabricante_cid`,`p`.`referencia` AS `referencia`,
`i`.`produtos_cid` AS `produtos_cid`,`i`.`item` AS `item`,`i`.`caracteristicas_cid` AS `caracteristicas_cid`,
format(replace(i.valor,',', '.'),2) as valor,
`f`.`nome` AS `fabricante`,`o`.`nome` AS `fornecedor`
from (((`produtos` `p` join `produtoitem` `i` on((`p`.`cid` = `i`.`produtos_cid`)))
join `fabricantes` `f` on((`f`.`cid` = `p`.`fabricante_cid`)))
join `fornecedores` `o` on((`o`.`cid` = `p`.`fornecedor_cid`)))
where (`i`.`caracteristicas_cid` = 2)
and isNumeric(valor) = 0
and 1 = (SELECT valor FROM parametros where  descricao = 'IsDecimal');