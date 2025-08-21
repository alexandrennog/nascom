using DFe.Classes.Flags;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Emitente;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using tipos = DFeBR.EmissorNFe.Utilidade.Tipos;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        
        [TestMethod]
        public void RecuperarConfiguracaoEGerarXML()
        {


            ObterConfiguracao();

            // Arrange
            string xmlPath = "arquivo.xml";
            string xmlContent = @"<DARUMAFRAMEWORKSAT>
                                  <CONFIGURACAO>
                                    <estadoCFe>5</estadoCFe>
                                    <numeroSessao>175879</numeroSessao>
                                    <codigoDeAtivacao>123456789</codigoDeAtivacao>
                                    <ChaveConsulta>CFe35250618132314000103590013218770000632041148</ChaveConsulta>
                                    <vCFeLei12741>0.00</vCFeLei12741>
                                    <vCFeLei12741Porcentagem>0.00</vCFeLei12741Porcentagem>
                                    <VersaoDadosEnt>00.07</VersaoDadosEnt>
                                    <CaracterSeparador>;</CaracterSeparador>
                                    <SeparadorUsoFuturo>;</SeparadorUsoFuturo>
                                    <Logotipo>L</Logotipo>
                                    <Marca>Desconhecido</Marca>
                                    <LayoutImpressao>0</LayoutImpressao>
                                    <ImprimirMsgQrCode>0</ImprimirMsgQrCode>
                                  </CONFIGURACAO>
                                  <PGTOCARTAOMFE>
                                    <ChaveAcessoValidador></ChaveAcessoValidador>
                                    <ChaveRequisicao></ChaveRequisicao>
                                    <CodigoMoeda>BRL</CodigoMoeda>
                                    <IDEstabelecimento></IDEstabelecimento>
                                    <EmitirCupomNFCe>0</EmitirCupomNFCe>
                                    <IdFila></IdFila>
                                    <HabilitarControleAntiFraude>0</HabilitarControleAntiFraude>
                                  </PGTOCARTAOMFE>
                                  <LEIDOIMPOSTO>
                                    <MsgLeiDoImposto>Valor aproximado dos tributos deste cupom       (Lei Federal 12.741/2012)</MsgLeiDoImposto>
                                    <Habilitar>1</Habilitar>
                                    <ColunasArquivo>0;4;5;6;7;1;</ColunasArquivo>
                                    <LocalArquivoNCM>./IBPTAX.csv</LocalArquivoNCM>
                                    <SeparadorArquivo>;</SeparadorArquivo>
                                  </LEIDOIMPOSTO>
                                  <IDENTIFICACAO_CFE>
                                    <CNPJ>07925528000110</CNPJ>
                                    <signAC>VH91pRvHi/f8EFYb++EeANKDmNq7g5ltkMXmLIpn0RR7J6hiG4fP94pIRPYjkG+xPlaybtxf+xStsRnM1UmjOkNk1IcEbVYie0rpWj9RNlpfY7JzD3QydwMIWM1DUrKOx/CApyPw11M+qMGmMvOw9gjABgKUmeyPsQKzSD/LR/nHKMORkyVGoE73HlWreOug7+Ld7g1Fi5DzAA7xMvn2ZeBOYpygJXVJH5AV4aW8ByrjzTrIHjyJdtKV4exhccrTEpv2W3QljauN2ECWY0AUpZ+ZUtShVhnw4zD+4yAeEVIX8UgrrVHfH6pUqvciA2H77SFkcbccwjxGYNfurC+xig==</signAC>
                                    <numeroCaixa>001</numeroCaixa>
                                    <nNF>000063</nNF>
                                    <UrlQrcode>CFe35250618132314000103590013218770000632041148|20250614132953|409.80|08398041803|tz1i+/NQoiLoNfUU+q4hviNOGpOZ2XK4qaWvrJkzOyD2RNBSoB/E0N2i7BeuG0geN9aOItONhiyYabWdlsKvBKRcN79vkm/F2RQWoR9lZWbvyQyXtGpFwpnSbHUY0zE9z74/rEw4waCxh6YV/AeUnO/TUuo/39YNzzvGk1CpEeVOLTAROtwV9IpeltRxCcC1phA62K3hwDuUQSARvqRVrAXzasFYD00eFn5O0tEgL4I6z8cVeKMh3antkLxklh+h3Xo488GcwtPHBq4h5eP9uGBBVLncfdIUHw+k8GIrqjirr9EFvNxlg7cxgG77UcMitgXj+qlgTj9SLDd1YLX2RA==</UrlQrcode>
                                    <nSerie>001321877</nSerie>
                                    <DataHoraEmissao>20250614132953</DataHoraEmissao>
                                    <vTotalCfe>409.80</vTotalCfe>
                                    <obsFisco>Comete crime quem sonega</obsFisco>
                                  </IDENTIFICACAO_CFE>
                                  <DEST>
                                    <CNPJ></CNPJ>
                                    <CPF>08398041803</CPF>
                                    <xNome></xNome>
                                  </DEST>
                                  <EMIT>
                                    <CNPJ>18132314000103</CNPJ>
                                    <IE>286327361110</IE>
                                    <IM> </IM>
                                    <UF>SP</UF>
                                    <cRegTribISSQN>1</cRegTribISSQN>
                                    <indRatISSQN>N</indRatISSQN>
                                  </EMIT>
                                  <PROD>
                                    <cEAN> </cEAN>
                                    <CFOP>5102</CFOP>
                                    <indRegra>A</indRegra>
                                    <NCM>64042000</NCM>
                                  </PROD>
                                  <IMPOSTO>
                                    <ICMS>
                                      <ICMS00>
                                        <Orig>0</Orig>
                                        <CST>00</CST>
                                      </ICMS00>
                                      <ICMS40>
                                        <Orig></Orig>
                                        <CST></CST>
                                      </ICMS40>
                                      <ICMSSN102>
                                        <Orig></Orig>
                                        <CSOSN></CSOSN>
                                      </ICMSSN102>
                                      <ICMSSN900>
                                        <Orig></Orig>
                                        <CSOSN></CSOSN>
                                      </ICMSSN900>
                                    </ICMS>
                                    <ISSQN>
                                      <vDeducISSQN></vDeducISSQN>
                                      <vAliq></vAliq>
                                      <cMunFG></cMunFG>
                                      <cListServ></cListServ>
                                      <cServTribMun></cServTribMun>
                                      <cNatOp></cNatOp>
                                      <indIncFisc></indIncFisc>
                                    </ISSQN>
                                    <PIS>
                                      <PISALIQ>
                                        <CST></CST>
                                        <pPIS></pPIS>
                                      </PISALIQ>
                                      <PISQTDE>
                                        <CST></CST>
                                        <vAliqProd></vAliqProd>
                                      </PISQTDE>
                                      <PISNT>
                                        <CST>07</CST>
                                      </PISNT>
                                      <PISSN>
                                        <CST>00</CST>
                                      </PISSN>
                                      <PISOUTR>
                                        <CST></CST>
                                        <pPIS></pPIS>
                                        <vAliqProd></vAliqProd>
                                        <TipoAliq></TipoAliq>
                                      </PISOUTR>
                                    </PIS>
                                    <PISST>
                                      <pPIS></pPIS>
                                      <vAliqProd></vAliqProd>
                                      <TipoAliq></TipoAliq>
                                    </PISST>
                                    <COFINS>
                                      <COFINSALIQ>
                                        <CST></CST>
                                        <pCOFINS></pCOFINS>
                                      </COFINSALIQ>
                                      <COFINSQTDE>
                                        <CST></CST>
                                        <vAliqProd></vAliqProd>
                                      </COFINSQTDE>
                                      <COFINSNT>
                                        <CST>07</CST>
                                      </COFINSNT>
                                      <COFINSSN>
                                        <CST></CST>
                                      </COFINSSN>
                                      <COFINSOUTR>
                                        <CST></CST>
                                        <pCOFINS></pCOFINS>
                                        <vAliqProd></vAliqProd>
                                        <TipoAliq></TipoAliq>
                                      </COFINSOUTR>
                                    </COFINS>
                                    <COFINSST>
                                      <pCOFINS></pCOFINS>
                                      <vAliqProd></vAliqProd>
                                      <TipoAliq></TipoAliq>
                                    </COFINSST>
                                  </IMPOSTO>
                                </DARUMAFRAMEWORKSAT>";
            File.WriteAllText(xmlPath, xmlContent);

            //var ncfe = new NCFe();

            

            //// Act
            //var result = typeof(NCFe)
            //    .GetMethod("RecuperarConfiguracao", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            //    .Invoke(ncfe, null);

            //nfe = result as NCFe;



            //// Assert
            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(DarumaFrameworkSat));
        }

   
        private EmissorServicoConfig ObterConfiguracao()
        {
            var serial = "1916ea4a695178883a8f92b10d0fa013";

            var c1 = new EmissorServicoConfig(tipos.VersaoServico.Ve400, tipos.Estado.Sp, tipos.TipoAmbiente.Homologacao, tipos.IndicadorSincronizacao.Sincrono, 60000);
            c1.ConfiguraCSC("000001", "58C851CA-C1C7-413C-BBDB-3EC38CF5F39F");
            c1.ConfiguraEmitente("13712048000174", "", "JORDAN SORIDE COMERCIO LTDA", "SUPER BIKE",
                    "018738210", "", "38545300154", "4763603", CRT.SimplesNacional, "logradouro", "1", "", "Bairro", 2927408, "Municipio", "BA", "41320100",
                    null);
            c1.ConfiguraSchemaXSD(true, $@"{Environment.CurrentDirectory}\Schemas\versao4.00");
            c1.ConfiguraArquivoRetorno(true, @"D:\");
            c1.ConfiguraCertificadoA1Repositorio(serial);
            //Segurança para nao transmitir em produção
            //if (c1.Ambiente == DFe.Classes.Flags.TipoAmbiente.Producao) throw new Exception("Testes em produção não permitido.");
            return c1;
        }
    }
}
