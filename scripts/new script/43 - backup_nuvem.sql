-- =============================================================================
-- Backup local + nuvem (AWS S3) integrado ao Nascomercio - historico
-- =============================================================================
-- Cada execucao do backup (automatica depois do login, ou pelo botao
-- "Fazer backup agora" na tela de Backup) grava uma linha aqui. E daqui que
-- sai o Relatorio de Backups (Relatorios > "Backups").
--
-- tipo:     A = automatico (depois do login) | M = manual (botao)
-- situacao: E = em andamento | S = sucesso (local + nuvem)
--           P = parcial (backup local OK, envio para a nuvem falhou)
-- F = falha (nao gerou backup)
--
-- chaveDia: data do backup AUTOMATICO, com indice UNICO. E o que garante um
--           backup automatico por dia por loja mesmo com varios terminais
--           abrindo o sistema ao mesmo tempo: so o primeiro consegue gravar a
--           linha do dia. Se o backup do dia falhar, o sistema limpa a chave e
--           o proximo login tenta de novo. Backup manual grava NULL (sempre roda).
--
-- Como aplicar: rodar no MySQL de cada loja (mesmo processo dos scripts
-- anteriores). So cria a tabela; pode rodar mais de uma vez. MySQL 5.1+.
-- =============================================================================

CREATE TABLE IF NOT EXISTS `backupnuvem` (
  `cid`              INT(11)      NOT NULL AUTO_INCREMENT,
  `dataInicio`       DATETIME     NOT NULL,
  `dataFim`          DATETIME     NULL,
  `chaveDia`         DATE         NULL,
  `tipo`             CHAR(1)      NOT NULL DEFAULT 'A',
  `situacao`         CHAR(1)      NOT NULL DEFAULT 'E',
  `etapa`            VARCHAR(20)  NULL,
  `terminal`         VARCHAR(60)  NULL,
  `computador`       VARCHAR(60)  NULL,
  `usuario_cid`      INT(11)      NULL,
  `usuarioNome`      VARCHAR(100) NULL,
  `arquivo`          VARCHAR(255) NULL,
  `bytesBanco`       BIGINT       NOT NULL DEFAULT 0,
  `bytesZip`         BIGINT       NOT NULL DEFAULT 0,
  `enviadoNuvem`     CHAR(1)      NOT NULL DEFAULT 'N',
  `bucket`           VARCHAR(100) NULL,
  `chaveNuvem`       VARCHAR(255) NULL,
  `arquivosApagados` INT(11)      NOT NULL DEFAULT 0,
  `emailEnviado`     CHAR(1)      NOT NULL DEFAULT 'N',
  `mensagem`         TEXT         NULL,
  PRIMARY KEY (`cid`),
  UNIQUE KEY `uk_backupnuvem_chavedia` (`chaveDia`),
  KEY `idx_backupnuvem_datainicio` (`dataInicio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
