-- Migra os registros da tabela `product` para `produtos`.
-- Mapeamento definido a partir do schema atual de `produtos`
-- (colunas ean_gtin, cest, ncm, cfop adicionadas na migração "34 - add_col_produtos.sql").
-- Campos sem correspondência em `product` (codigo, valorCompra, imagem, referencia,
-- estoqueMinimo, cfop, efdIntegracao, efdCodigoCategoria, produtoTipo_cid, fornecedor_cid,
-- fabricante_cid, cor_cid, grupo_cid) são inseridos como NULL.

INSERT INTO `produtos`
	(descricao, situacao, dataInclusao, valorVenda, aliquota,
	 efdUnidadeMedidaCodigo, ncm, cest, ean_gtin)
SELECT
	LEFT(p.nome, 50)        AS descricao,
	'A'                      AS situacao,
	NOW()                    AS dataInclusao,
	p.preco                  AS valorVenda,
	LEFT(p.tributacao, 5)    AS aliquota,
	LEFT(p.unidade, 3)       AS efdUnidadeMedidaCodigo,
	p.ncm                    AS ncm,
	CAST(p.cest AS CHAR)     AS cest,
	CAST(p.EAN_GTIN AS CHAR) AS ean_gtin
FROM `product` p;
