-- Consulta de produtoitem com filtros opcionais (descricao, referencia, valor).
-- Cada parametro só é aplicado quando informado (NULL ou '' = ignora o filtro).
--
-- Correção em relação à consulta original: os joins de `caracteristicas`
-- precisam amarrar cada linha de produtoitem ao seu tipo (codigoBarras/estoque/tamanho),
-- senão pi/pi2/pi3 podem casar com qualquer característica e duplicar/errar linhas.

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_consultar_produtoitem`(
	IN p_descricao  VARCHAR(50),
	IN p_referencia VARCHAR(20),
	IN p_valor      VARCHAR(30)
)
BEGIN
	SELECT
		p.cid        AS produtos_cid,
		p.descricao  AS descricao,
		p.referencia AS referencia,
		p.valorVenda AS valorVenda,
		pi.valor     AS valor,
		pi.item      AS item,
		pi2.valor    AS estoque,
		pi3.valor    AS tamanho,
		co.nome      AS cor
	FROM produtos p
	INNER JOIN cor co            ON co.cid = p.cor_cid
	INNER JOIN produtoitem pi    ON pi.produtos_cid = p.cid
	INNER JOIN caracteristicas c  ON c.cid = pi.caracteristicas_cid  AND c.codigo = 'codigoBarras'
	INNER JOIN produtoitem pi2   ON pi2.produtos_cid = p.cid AND pi2.item = pi.item
	INNER JOIN caracteristicas c2 ON c2.cid = pi2.caracteristicas_cid AND c2.codigo = 'estoque'
	INNER JOIN produtoitem pi3   ON pi3.produtos_cid = p.cid AND pi3.item = pi.item
	INNER JOIN caracteristicas c3 ON c3.cid = pi3.caracteristicas_cid AND c3.codigo = 'tamanho'
	WHERE pi2.valor > 0
		AND (p_descricao  IS NULL OR p_descricao  = '' OR p.descricao  LIKE CONCAT('%', p_descricao, '%'))
		AND (p_referencia IS NULL OR p_referencia = '' OR p.referencia LIKE CONCAT('%', p_referencia, '%'))
		AND (p_valor      IS NULL OR p_valor      = '' OR pi.valor      = p_valor)
	ORDER BY p.descricao, p.referencia, co.nome, pi3.valor;
END$$

DELIMITER ;

-- Exemplos de uso:
-- CALL sp_consultar_produtoitem('Absorvente interno', NULL, NULL);
-- CALL sp_consultar_produtoitem(NULL, 'REF123', NULL);
-- CALL sp_consultar_produtoitem(NULL, NULL, '7891234567890');
