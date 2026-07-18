-- InnoDB explícito em todas as tabelas: sem isso, FOREIGN KEY é
-- silenciosamente IGNORADA se o engine cair em MyISAM (MyISAM não suporta FK).
-- Charset explícito: utf8 (5.5 não tem suporte confiável a utf8mb4) para
-- acentuação de razão social/descrição.

CREATE TABLE empresa (
    id_empresa INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
    cnpj CHAR(14) NOT NULL,                 -- CHAR: tamanho fixo, mais eficiente que VARCHAR
    razao_social VARCHAR(150) NOT NULL,

    crt TINYINT UNSIGNED NOT NULL,          -- só 1,2,3 -> INT (4 bytes) era desperdício
    -- 1 Simples Nacional
    -- 2 Simples Nacional excesso sublimite
    -- 3 Regime Normal

    uf CHAR(2),
    municipio INT UNSIGNED,

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- TIMESTAMP: único tipo com default automático no 5.5

    UNIQUE KEY uk_empresa_cnpj (cnpj)       -- CNPJ é chave de negócio; garante unicidade e acelera busca
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE produto (
    id_produto INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,

    codigo VARCHAR(60) NOT NULL,
    descricao VARCHAR(200) NOT NULL,

    ncm CHAR(8),
    cest CHAR(7),

    unidade VARCHAR(6),

    ativo TINYINT(1) UNSIGNED NOT NULL DEFAULT 1,  -- BIT dá dor de cabeça no MySql.Data.MySqlClient
                                                     -- (retorna UInt64/byte[] em vez de bool); TINYINT(1) é direto

    UNIQUE KEY uk_produto_codigo (codigo),
    KEY idx_produto_ncm (ncm)               -- usado em regra fiscal por NCM
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE regra_tributaria (

    id_regra INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,

    descricao VARCHAR(150),

    crt TINYINT UNSIGNED,

    uf_origem CHAR(2),
    uf_destino CHAR(2),

    tipo_operacao ENUM('E','S') NOT NULL,   -- ENUM (1 byte) + validação no próprio banco
    -- E = Entrada
    -- S = Saída

    modelo_documento TINYINT UNSIGNED,      -- só 55/65 -> cabe em TINYINT
    -- 65 NFC-e
    -- 55 NF-e

    inicio_vigencia DATE,
    fim_vigencia DATE,

    ativo TINYINT(1) UNSIGNED NOT NULL DEFAULT 1,

    -- Índice composto: cobre o padrão de busca típico de resolução de regra
    -- fiscal por operação (UF origem/destino, tipo, modelo, CRT, vigência).
    -- Sem isso, cada emissão de nota faz table scan em regra_tributaria.
    KEY idx_regra_busca (uf_origem, uf_destino, tipo_operacao, modelo_documento, crt, ativo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE produto_regra_tributaria (

    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,

    id_produto INT UNSIGNED NOT NULL,
    id_regra INT UNSIGNED NOT NULL,

    UNIQUE KEY uk_produto_regra (id_produto, id_regra),  -- evita vínculo duplicado
                                                           -- e já serve de índice p/ join por id_produto

    FOREIGN KEY (id_produto)
        REFERENCES produto(id_produto),

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE imposto_icms (

    id_regra INT UNSIGNED PRIMARY KEY,

    origem TINYINT UNSIGNED,   -- 0/1 -> TINYINT
    -- 0 Nacional
    -- 1 Estrangeira

    cst VARCHAR(3),
    csosn VARCHAR(4),

    aliquota DECIMAL(5,2),
    reducao_base DECIMAL(5,2),
    modalidade_bc TINYINT UNSIGNED,

    aliquota_st DECIMAL(5,2),
    margem_valor_agregado DECIMAL(7,2),

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE imposto_pis (

    id_regra INT UNSIGNED PRIMARY KEY,

    cst VARCHAR(2),
    aliquota DECIMAL(5,4),

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE imposto_cofins (

    id_regra INT UNSIGNED PRIMARY KEY,

    cst VARCHAR(2),
    aliquota DECIMAL(5,4),

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE imposto_ipi (

    id_regra INT UNSIGNED PRIMARY KEY,

    cst VARCHAR(2),
    aliquota DECIMAL(5,2),
    codigo_enquadramento VARCHAR(3),

    -- FK estava faltando aqui (as outras tabelas imposto_* têm) — inconsistência
    -- que permitia id_regra órfão apontando pra regra inexistente.
    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE imposto_ibs_cbs (

    id_regra INT UNSIGNED PRIMARY KEY,

    cst_ibs_cbs VARCHAR(3),
    c_class_trib VARCHAR(6),

    aliquota_ibs_uf DECIMAL(6,4),
    aliquota_ibs_municipio DECIMAL(6,4),
    aliquota_cbs DECIMAL(6,4),

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE regra_cfop (

    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,

    id_regra INT UNSIGNED NOT NULL,
    cfop CHAR(4) NOT NULL,

    UNIQUE KEY uk_regra_cfop (id_regra, cfop),  -- evita CFOP duplicado pra mesma regra

    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE historico_regra_tributaria (

    id BIGINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,

    id_regra INT UNSIGNED NOT NULL,

    usuario VARCHAR(100),

    data_alteracao DATETIME NOT NULL,  -- sem DEFAULT CURRENT_TIMESTAMP (não suportado em DATETIME no 5.5);
                                        -- setar via aplicação (NOW()) no INSERT

    valor_anterior TEXT,   -- JSON não existe no 5.5; TEXT guarda o mesmo conteúdo serializado
    valor_novo TEXT,

    -- FK estava faltando -> histórico podia referenciar regra inexistente/já excluída
    FOREIGN KEY (id_regra)
        REFERENCES regra_tributaria(id_regra),

    KEY idx_historico_regra_data (id_regra, data_alteracao)  -- consulta típica de auditoria: por regra + período
) ENGINE=InnoDB DEFAULT CHARSET=utf8;