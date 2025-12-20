ALTER TABLE usuarios
MODIFY COLUMN senha VARCHAR(50) DEFAULT NULL;

alter table usuarios add email varchar(80)

drop table `nascomercio`.`parametros`;

CREATE TABLE `parametros` (
  `cid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) NOT NULL,
  `valor` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

ALTER TABLE parametros AUTO_INCREMENT = 1;


INSERT INTO parametros (descricao, valor) VALUES
('Juros diários', '0,0033'),
('Dias tolerância crediário', '3'),
('Cobrar juros tolerância crediário', 'Sim'),
('Tempo primeira parcela', '30'),
('Entrar quantidade no caixa', 'Não'),
('Loja com mais de um caixa', 'Não'),
('Número de Remessa', '1'),
('Minimo para Negativar', '1,00'),
('Fechar tela caixa', 'Não'),
('Chave de Validação', 'yLVK3b492kYrofXBtPWIDkJpIZGWyJMs6q1fwooiIQ0='),
('Mensagem impressão', 'CUPOM SEM VALIDADE FISCAL'),
('Código de Instalação', '621866056'),
('Data de Expiração', '2186-06-22'),
('Impressora Cupom', 'LPT2'),
('Cortar Papel', 'LPT1'),
('Segunda Via', '40x25'),
('Impressora Etiqueta', 'Não'),
('Tamanho Etiqueta', 'Não'),
('Ordem de Servico', 'Sim'),
('DiretorioFoto', 'C:\\Nascomercio\\foto')
('IsDecimal', '0'),
('Security', '0'),
('Instancias', '4'),
('UsarPIX', '1'),
('Imprime data etiqueta', '0');




ALTER TABLE `credpag` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `prevendas` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `vales` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0;
ALTER TABLE `vendas` ADD `Original` decimal(5,2) NOT NULL DEFAULT 0; 
ALTER TABLE `pix` ADD `controle` int(10) unsigned NOT NULL;