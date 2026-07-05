CREATE TABLE usuario_refresh_token (
  cid INT NOT NULL AUTO_INCREMENT,
  usuario_cid INT NOT NULL,
  token VARCHAR(150) NOT NULL,
  expiracao DATETIME NOT NULL,
  revogado TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (cid),
  UNIQUE KEY uk_usuario_refresh_token_token (token),
  KEY ix_usuario_refresh_token_usuario (usuario_cid),
  CONSTRAINT fk_usuario_refresh_token_usuario FOREIGN KEY (usuario_cid) REFERENCES usuarios (cid)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
