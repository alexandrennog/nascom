ALTER TABLE `vendas` ADD COLUMN `chave` varchar(45);
ALTER TABLE lojas ADD `inscestadual` varchar(20) DEFAULT NULL;

CREATE TABLE `infprot` (
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
