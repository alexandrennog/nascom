-- =============================================================================
-- Historico de emissao da NFC-e (tabela basennf) - relatorio "NFC-e Emitidas"
-- =============================================================================
-- A tabela basennf ja existia (script 32): seqNFe = numero da NFC-e e
-- chnfe = chave de acesso (ou "temporario"/"FALHA_EMISSAO"). Este script
-- acrescenta o que faltava para acompanhar cada emissao:
--
--   controle         venda (vendas.controle)
--   dataEmissao      data/hora da (ultima) tentativa de emissao
--   situacao         E = em andamento | A = autorizada | R = rejeitada pela SEFAZ
--                    F = falha (comunicacao/erro antes de chegar na SEFAZ)
--                    C = cancelada | S = substituida (reemitida com outro numero)
--   cStat/mensagem   retorno da SEFAZ (ou o erro tecnico)
--   protocolo        protocolo de autorizacao / dataAutorizacao
--   caminhoXml       onde o XML foi gravado (no computador que emitiu)
--   computador       computador que emitiu (o XML fica na pasta NFs dele)
--   cpfConsumidor    CPF/CNPJ informado na nota (usado na reemissao)
--   tentativas       quantas vezes o sistema tentou emitir esse numero
--   substituidaPor   numero novo, quando a nota foi reemitida com outro numero
--
-- Notas emitidas antes deste script: o script preenche o que da para
-- recuperar (venda e valor pela chave gravada na venda; data, protocolo e
-- retorno da SEFAZ pela tabela infprot; canceladas pelo evento gravado).
-- Falhas antigas nao tinham a venda gravada: o script tenta achar a venda
-- pela ordem dos numeros (so liga quando ha uma unica venda sem nota entre
-- as duas notas autorizadas vizinhas); senao fica so com a data aproximada.
--
-- Como aplicar: rodar no MySQL de cada loja (mesmo processo dos scripts
-- anteriores). Pode rodar mais de uma vez. MySQL 5.1+.
-- =============================================================================

-- Os textos deste script tem acento: garante que o cliente envie em UTF-8
SET NAMES utf8;

-- O MySQL Workbench vem com "safe update mode" ligado, que bloqueia os UPDATEs
-- de preenchimento abaixo (Error Code 1175). Desliga so nesta conexao e
-- volta como estava no fim do script.
SET @nc_safe_updates = @@SQL_SAFE_UPDATES;
SET SQL_SAFE_UPDATES = 0;

-- Tabelas que ja deveriam existir (scripts 29 e 32) - garante para lojas novas
CREATE TABLE IF NOT EXISTS `basennf` (
  `seqNFe` int(11) NOT NULL AUTO_INCREMENT,
  `chnfe` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`seqNFe`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `infprot` (
  `chnfe` varchar(50) DEFAULT NULL,
  `tpamb` int(11) DEFAULT NULL,
  `veraplic` varchar(20) DEFAULT NULL,
  `dhrecbto` datetime DEFAULT NULL,
  `nprot` varchar(50) DEFAULT NULL,
  `digval` varchar(100) DEFAULT NULL,
  `cstat` int(11) DEFAULT NULL,
  `xmotivo` varchar(255) DEFAULT NULL,
  `cmsg` varchar(50) DEFAULT NULL,
  `xmsg` varchar(255) DEFAULT NULL,
  `xEvento` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Auxiliares (removidas no fim): coluna/indice so se ainda nao existir
DROP PROCEDURE IF EXISTS nc_add_coluna;
DROP PROCEDURE IF EXISTS nc_add_indice;

DELIMITER $$
CREATE PROCEDURE nc_add_coluna(IN pTabela VARCHAR(64), IN pColuna VARCHAR(64), IN pDefinicao VARCHAR(500))
BEGIN
  IF NOT EXISTS (SELECT 1 FROM information_schema.columns
                  WHERE table_schema = DATABASE() AND table_name = pTabela AND column_name = pColuna) THEN
    SET @nc_sql = CONCAT('ALTER TABLE `', pTabela, '` ADD COLUMN `', pColuna, '` ', pDefinicao);
    PREPARE nc_st FROM @nc_sql;
    EXECUTE nc_st;
    DEALLOCATE PREPARE nc_st;
  END IF;
END$$

CREATE PROCEDURE nc_add_indice(IN pTabela VARCHAR(64), IN pIndice VARCHAR(64), IN pColunas VARCHAR(200))
BEGIN
  IF NOT EXISTS (SELECT 1 FROM information_schema.statistics
                  WHERE table_schema = DATABASE() AND table_name = pTabela AND index_name = pIndice) THEN
    SET @nc_sql = CONCAT('ALTER TABLE `', pTabela, '` ADD INDEX `', pIndice, '` (', pColunas, ')');
    PREPARE nc_st FROM @nc_sql;
    EXECUTE nc_st;
    DEALLOCATE PREPARE nc_st;
  END IF;
END$$
DELIMITER ;

CALL nc_add_coluna('vendas',  'chave',           'VARCHAR(45) NULL');

CALL nc_add_coluna('basennf', 'controle',        'INT(11) NULL');
CALL nc_add_coluna('basennf', 'dataEmissao',     'DATETIME NULL');
CALL nc_add_coluna('basennf', 'situacao',        'CHAR(1) NULL');
CALL nc_add_coluna('basennf', 'cStat',           'INT(11) NULL');
CALL nc_add_coluna('basennf', 'mensagem',        'VARCHAR(1000) NULL');
CALL nc_add_coluna('basennf', 'protocolo',       'VARCHAR(30) NULL');
CALL nc_add_coluna('basennf', 'dataAutorizacao', 'DATETIME NULL');
CALL nc_add_coluna('basennf', 'caminhoXml',      'VARCHAR(500) NULL');
CALL nc_add_coluna('basennf', 'cpfConsumidor',   'VARCHAR(14) NULL');
CALL nc_add_coluna('basennf', 'valor',           'DECIMAL(10,2) NULL');
CALL nc_add_coluna('basennf', 'terminal',        'VARCHAR(60) NULL');
CALL nc_add_coluna('basennf', 'computador',      'VARCHAR(60) NULL');
CALL nc_add_coluna('basennf', 'usuario_cid',     'INT(11) NULL');
CALL nc_add_coluna('basennf', 'usuarioNome',     'VARCHAR(100) NULL');
CALL nc_add_coluna('basennf', 'tentativas',      'INT(11) NOT NULL DEFAULT 1');
CALL nc_add_coluna('basennf', 'substituidaPor',  'INT(11) NULL');
CALL nc_add_coluna('basennf', 'dataAtualizacao', 'DATETIME NULL');

CALL nc_add_indice('basennf', 'idx_basennf_dataEmissao', '`dataEmissao`');
CALL nc_add_indice('basennf', 'idx_basennf_controle',    '`controle`');
CALL nc_add_indice('basennf', 'idx_basennf_chnfe',       '`chnfe`');

-- -----------------------------------------------------------------------------
-- Notas anteriores ao historico (situacao ainda vazia)
-- -----------------------------------------------------------------------------

-- 1. Situacao pela chave gravada
UPDATE basennf
   SET situacao = 'A'
 WHERE situacao IS NULL AND chnfe REGEXP '^[0-9]{44}$';

UPDATE basennf
   SET situacao = 'F',
       mensagem = 'Falha na emissão (registro anterior ao histórico, sem o motivo).'
 WHERE situacao IS NULL;

-- 2. Autorizadas: venda, valor, data e terminal pela chave gravada na venda
UPDATE basennf b
  JOIN vendas v ON v.chave = b.chnfe
   SET b.controle    = v.controle,
       b.valor       = v.total,
       b.dataEmissao = v.data,
       b.terminal    = v.terminal
 WHERE b.controle IS NULL
   AND b.situacao = 'A'
   AND v.chave REGEXP '^[0-9]{44}$';

-- 3. Retorno da SEFAZ guardado na infprot (protocolo, data, motivo, cancelamento)
--    So a linha da autorizacao (100/150): a infprot tambem guarda tentativas rejeitadas
UPDATE basennf b
  JOIN infprot i ON i.chnfe = b.chnfe AND i.cstat IN (100, 150)
   SET b.protocolo       = IFNULL(b.protocolo, i.nprot),
       b.cStat           = IFNULL(b.cStat, i.cstat),
       b.mensagem        = IFNULL(b.mensagem, i.xmotivo),
       b.dataAutorizacao = IFNULL(b.dataAutorizacao, i.dhrecbto),
       b.dataEmissao     = IFNULL(b.dataEmissao, i.dhrecbto)
 WHERE b.situacao = 'A';

UPDATE basennf b
  JOIN infprot i ON i.chnfe = b.chnfe
   SET b.situacao = 'C',
       b.mensagem = CONCAT('Cancelada: ', i.xEvento)
 WHERE b.situacao = 'A'
   AND i.xEvento IS NOT NULL AND i.xEvento <> '';

-- 4. Falhas antigas: venda (quando da para saber com seguranca) e data aproximada
DROP TEMPORARY TABLE IF EXISTS tmp_nf_datas;
CREATE TEMPORARY TABLE tmp_nf_datas (seqNFe INT PRIMARY KEY, dataEmissao DATETIME);
INSERT INTO tmp_nf_datas
  SELECT seqNFe, dataEmissao FROM basennf WHERE dataEmissao IS NOT NULL;

DROP TEMPORARY TABLE IF EXISTS tmp_nf_falha;
CREATE TEMPORARY TABLE tmp_nf_falha (
  seqNFe    INT PRIMARY KEY,
  antes     DATETIME NULL,     -- nota com data imediatamente anterior
  depois    DATETIME NULL,     -- nota com data imediatamente posterior
  qtdGap    INT NULL,          -- falhas entre as mesmas duas notas
  qtdVendas INT NULL,          -- vendas sem nota nesse intervalo
  controle  INT NULL
);
INSERT INTO tmp_nf_falha (seqNFe)
  SELECT seqNFe FROM basennf WHERE dataEmissao IS NULL AND controle IS NULL;

UPDATE tmp_nf_falha f
   SET antes = (SELECT d.dataEmissao FROM tmp_nf_datas d WHERE d.seqNFe < f.seqNFe ORDER BY d.seqNFe DESC LIMIT 1);
UPDATE tmp_nf_falha f
   SET depois = (SELECT d.dataEmissao FROM tmp_nf_datas d WHERE d.seqNFe > f.seqNFe ORDER BY d.seqNFe LIMIT 1);

DROP TEMPORARY TABLE IF EXISTS tmp_nf_falha2;
CREATE TEMPORARY TABLE tmp_nf_falha2 (seqNFe INT PRIMARY KEY, antes DATETIME NULL, depois DATETIME NULL);
INSERT INTO tmp_nf_falha2 SELECT seqNFe, antes, depois FROM tmp_nf_falha;

UPDATE tmp_nf_falha f
   SET qtdGap = (SELECT COUNT(*) FROM tmp_nf_falha2 g
                  WHERE g.antes <=> f.antes AND g.depois <=> f.depois);

-- vendas que ficaram sem nota e que ainda nao estao ligadas a nenhum numero
DROP TEMPORARY TABLE IF EXISTS tmp_nf_venda;
CREATE TEMPORARY TABLE tmp_nf_venda (controle INT PRIMARY KEY, data DATETIME, total DECIMAL(10,2), terminal VARCHAR(25), KEY (data));
INSERT INTO tmp_nf_venda
  SELECT v.controle, v.data, v.total, v.terminal
    FROM vendas v
   WHERE v.chave IN ('FALHA_EMISSAO', 'temporario')
     AND NOT EXISTS (SELECT 1 FROM basennf b WHERE b.controle = v.controle);

UPDATE tmp_nf_falha f
   SET qtdVendas = (SELECT COUNT(*) FROM tmp_nf_venda v
                     WHERE v.data >= f.antes AND v.data <= IFNULL(f.depois, NOW()))
 WHERE f.antes IS NOT NULL AND f.qtdGap = 1;

UPDATE tmp_nf_falha f
   SET controle = (SELECT v.controle FROM tmp_nf_venda v
                    WHERE v.data >= f.antes AND v.data <= IFNULL(f.depois, NOW()) LIMIT 1)
 WHERE f.qtdVendas = 1;

UPDATE basennf b
  JOIN tmp_nf_falha f ON f.seqNFe = b.seqNFe
  JOIN tmp_nf_venda v ON v.controle = f.controle
   SET b.controle    = v.controle,
       b.valor       = v.total,
       b.terminal    = v.terminal,
       b.dataEmissao = v.data,
       b.mensagem    = 'Falha na emissão (registro anterior ao histórico, sem o motivo). Venda identificada pela ordem das notas.'
 WHERE b.controle IS NULL;

UPDATE basennf b
  JOIN tmp_nf_falha f ON f.seqNFe = b.seqNFe
   SET b.dataEmissao = IFNULL(f.antes, f.depois),
       b.mensagem    = 'Falha na emissão (registro anterior ao histórico, sem o motivo). Data aproximada; venda não identificada.'
 WHERE b.dataEmissao IS NULL
   AND (f.antes IS NOT NULL OR f.depois IS NOT NULL);

DROP TEMPORARY TABLE IF EXISTS tmp_nf_datas;
DROP TEMPORARY TABLE IF EXISTS tmp_nf_falha;
DROP TEMPORARY TABLE IF EXISTS tmp_nf_falha2;
DROP TEMPORARY TABLE IF EXISTS tmp_nf_venda;

DROP PROCEDURE IF EXISTS nc_add_coluna;
DROP PROCEDURE IF EXISTS nc_add_indice;

SET SQL_SAFE_UPDATES = IFNULL(@nc_safe_updates, 1);
