using LibNF65.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using Unimake.Business.DFe;
using Unimake.Business.DFe.Security;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Servicos.NFCe;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;
using Unimake.Security.Platform;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;
using XmlNFe = Unimake.Business.DFe.Xml.NFe;
using Unimake.Business.Security;
using CertificadoDigital = Unimake.Business.Security.CertificadoDigital;

namespace LibNF65
{
    public class NFCe65
    {
        X509Certificate2 x509Cert;
        static string chaveAcesso = string.Empty;

        public static void GerarNF(List<dVendaProduto> produtos)
        {

            var configuracao = new Unimake.Business.DFe.Servicos.Configuracao
            {
                TipoDFe = TipoDFe.NFCe,
                CertificadoArquivo = ConfigurationManager.AppSettings["CertificadoArquivo"],
                CertificadoSenha = ConfigurationManager.AppSettings["CertificadoSenha"],
                TipoAmbiente = TipoAmbiente.Homologacao,
                UsaCertificadoDigital = true,
                CSC = ConfigurationManager.AppSettings["CSC"],
                CSCIDToken = int.Parse(ConfigurationManager.AppSettings["CSCIDToken"]),
                SchemaVersao = ConfigurationManager.AppSettings["SchemaVersao"],
                VersaoConfiguracao = ConfigurationManager.AppSettings["VersaoConfiguracao"]
            };
            var infCons = new InfCons
            {
                CNPJ = ConfigurationManager.AppSettings["CNPJ"],
                UF = UFBrasil.SP
            };

            var consCad = new ConsCad
            {
                Versao = "2.00",
                InfCons = infCons
            };


            var objNFCe = new NasNFCe();


            string caminhoCertificado = ConfigurationManager.AppSettings["CertificadoArquivo"];
            string senhaCertificado = ConfigurationManager.AppSettings["CertificadoSenha"];

            // 2. Carregar o certificado
            var certificado = new CertificadoDigital
            {

            };

            X509Certificate2 x509Cert = certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado);

            // 3. Executando a consulta
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            consultaCadastro.Executar();

            // 4. Interpretando o resultado
            var resultado = consultaCadastro.Result; // Retorno do objeto
            var retornoWs = consultaCadastro.RetornoWSString; // XML raw

            string cUF = "35"; // Código da UF do emitente (SP = 35)
            DateTime dhEmi = DateTime.Now; // Data e hora de emissão
            string cnpjEmitente = resultado.InfCons.CNPJ; // CNPJ do emitente (14 dígitos)

            int serie = 1; // Série da nota fiscal
            int nNF = GerarNF(); // Número da nota fiscal  //TODO informar o controle
            int cNF = XMLUtility.GerarCodigoNumerico(nNF); // Código Numérico Aleatório (cNF)

            var conteudoChave = new XMLUtility.ConteudoChaveDFe
            {

            };

            conteudoChave.UFEmissor = UFBrasil.SP;
            conteudoChave.TipoEmissao = TipoEmissao.Normal;
            conteudoChave.Modelo = ModeloDFe.NFCe;
            conteudoChave.Serie = serie;
            conteudoChave.CodigoNumerico = XMLUtility.GerarCodigoNumerico(nNF).ToString();
            conteudoChave.CNPJCPFEmissor = cnpjEmitente;
            conteudoChave.NumeroDoctoFiscal = nNF;
            conteudoChave.AnoEmissao = DateTime.Now.ToString("yy");
            conteudoChave.MesEmissao = DateTime.Now.ToString("MM");

            var configImposto = RecuperarConfiguracao();

            var prods = objNFCe.RecuperarProdutos(produtos, nNF, configuracao, configImposto);


            var xml = new XmlNFe.EnviNFe
            {
                Versao = "4.00",
                IdLote = GerarIdLote(),
                IndSinc = SimNao.Sim,
                NFe = new List<XmlNFe.NFe> { prods }
            };

            chaveAcesso = xml.NFe.First().InfNFe.FirstOrDefault().Chave;

            var xmlString = XMLUtility.Serializar<XmlNFe.NFe>(xml.NFe.First());


            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString.InnerXml);
            xmlDoc.Save("NFs\\" + chaveAcesso + "-procnfe.xml");

            // With the corrected code:
            if (!AssinaturaDigital.EstaAssinado(xmlDoc, "infNFe"))
            {
                AssinaturaDigital.Assinar(xmlDoc, "infNFe", x509Cert, AlgorithmType.Sha1, false);
            }
 
            bool validar = true;
            if (validar)
            {
                var validador = new ValidarSchema();
                validador.Validar(xmlString, "NFe");
            }

            var autorizacao = new ServicoNFCe.Autorizacao(xml, configuracao);
            autorizacao.Executar();


            var ret = ConsultarCupomNFCe("NFs\\" + chaveAcesso, x509Cert);

            //var nfce = new NFCeModel();

            NFCeModel nfce = NFCeXMLParser.ParseXML("NFs\\" + chaveAcesso + "-procnfe.xml");
            nfce.QRCodeUrl = NasNFCe.GerarQRCode(chaveAcesso);   // XMLParser. GerarUrlQRCode(nfce, configuracao);

            // Imprimir
            ImpressaoNFCeSP impressao = new ImpressaoNFCeSP(nfce);

            // Para visualizar antes de imprimir
            impressao.Imprimir(null);  // VisualizarImpressao();

            // Para imprimir direto
            // impressao.Imprimir("Nome_da_Impressora");


            //var impressaoNFCeSP = new ImpressaoNFCeSP(nfce);


            objNFCe.EventoCancelamentoNFCe(chaveAcesso, x509Cert);

            objNFCe.ImprimirDANFe(chaveAcesso);

            ////////var retConsulta = objNFCe.ConsultarCupom(configuracao, chaveAcesso);


            if (autorizacao.Result.ProtNFe != null)
            {
                switch (autorizacao.Result.ProtNFe.InfProt.CStat)
                {
                    case 100: //Autorizado o uso da NFe
                    case 110: //Uso Denegado
                    case 150: //Autorizado o uso da NF-e, autorização fora de prazo
                    case 205: //NF-e está denegada na base de dados da SEFAZ [nRec:999999999999999]
                    case 301: //Uso Denegado: Irregularidade fiscal do emitente
                    case 302: //Uso Denegado: Irregularidade fiscal do destinatário
                    case 303: //Uso Denegado: Destinatário não habilitado a operar na UF
                        autorizacao.GravarXmlDistribuicao(@"c:\testenfe\");
                        //var docProcNFe = autorizacao.NfeProcResult.GerarXML(); //Gerar o Objeto para pegar a string e gravar em banco de dados

                        //Como é assíncrono, tenho que prever a possibilidade de ter mais de uma NFe no lote, então teremos vários XMLs com protocolos.
                        //Se no seu caso vc enviar sempre uma única nota, só vai passar uma única vez no foreach
                        foreach (var item in autorizacao.NfeProcResults.Values)
                        {
                            var docProcNFe = item.GerarXML();
                            var stringXml = docProcNFe.OuterXml;
                        }

                        break;

                    default:
                        //NF Rejeitada
                        break;
                }
            }

        }

        public static string GerarIdLote()
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public static int GerarNF()
        {
            var random = new Random();
            int cNF = random.Next(0, 99999999);
            return cNF;
        }

        private static DarumaFrameworkSat RecuperarConfiguracao()
        {
            try
            {
                string _xml = @"C:\\Users\\jjail\\Projetos\\NFCeProject\\DarumaFrameWork_SAT.xml";
                var xmlContent = File.ReadAllText(_xml);
                return DeserializarXml(xmlContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler arquivo XML: {ex.Message}", ex);
            }
        }

        private static string ConsultarCupomNFCe(string chaveAcesso, X509Certificate2 x509Cert)
        {
            var xml = new XmlNFe.ConsSitNFe
            {
                Versao = "4.00",
                TpAmb = TipoAmbiente.Homologacao,
                ChNFe = chaveAcesso
            };

            var configuracao = new Unimake.Business.DFe.Servicos.Configuracao
            {
                TipoDFe = TipoDFe.NFCe,
                TipoEmissao = TipoEmissao.Normal,
                CertificadoDigital = x509Cert
                
            };

            var consultaProtocolo = new ServicoNFCe.ConsultaProtocolo(xml, configuracao);

            consultaProtocolo.Executar();

            return consultaProtocolo.Result.CStat + " - " + consultaProtocolo.Result.XMotivo;
        }

        public static void Imprimir(string doc)
        {
            // Carregar o XML da NFC-e processada
            string caminhoXml = @"C:\Users\jjail\Projetos\NFCeProject\bin\Debug\net8.0\35251036650283000164650011234765251184915530-procnfe.xml";

            var xmlDoc = new XmlDocument();
            using (FileStream fileStream = new FileStream(caminhoXml, FileMode.Open, FileAccess.Read))
            {
                xmlDoc.Load(fileStream);
            }

            var nfeProc = new NfeProc();
            nfeProc = nfeProc.LerXML<NfeProc>(xmlDoc);

            // Criar instância da impressão
            ImpressaoNFCe impressao = new ImpressaoNFCe(nfeProc);

            // Imprimir (deixe vazio para usar impressora padrão ou especifique o nome)
            impressao.Imprimir("Nome_da_Impressora_Termica");
        }

        private static DarumaFrameworkSat DeserializarXml(string xmlContent)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(DarumaFrameworkSat));

                using (var reader = new StringReader(xmlContent))
                {
                    return (DarumaFrameworkSat)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deserializar XML: {ex.Message}", ex);
            }
        }
    }
}
