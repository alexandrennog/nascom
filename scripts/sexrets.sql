DROP TABLE IF EXISTS `InstanceSecretDB`.`Secrets`;
CREATE TABLE  `InstanceSecretDB`.`Secrets` (
  `Lojista` int NOT NULL,
  `Controle` int NOT NULL,
  `Chave` varchar(36) NOT NULL,
  `AppKey` varchar(40) NOT NULL,
  `ClientId` varchar(135) NOT NULL,
  `clientSecret` varchar(235) NOT NULL,
  PRIMARY KEY (`Lojista`,`Controle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;