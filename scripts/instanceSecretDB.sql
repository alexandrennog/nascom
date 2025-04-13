USE instanceSecretDB;


CREATE TABLE Secrets (
 Controle int(10) NOT NULL,
 AppKey VARCHAR(40) NOT NULL,
 ClientId VARCHAR(135) NOT NULL,
 clientSecret  VARCHAR(235) NOT NULL,
 PRIMARY KEY (Controle));
