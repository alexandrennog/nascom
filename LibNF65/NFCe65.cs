using LibNF65.Interfaces;
using LibNF65.Modelo;
using LibNF65.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using Unimake.Business.DFe;
using Unimake.Business.DFe.Security;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Servicos.NFCe;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;
using Unimake.Business.Security;
using Unimake.Security.Platform;
using CertificadoDigital = Unimake.Business.Security.CertificadoDigital;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;
using XmlNFe = Unimake.Business.DFe.Xml.NFe;

namespace LibNF65
{
    public class NFCe65
    {
        X509Certificate2 x509Cert;
        static string chaveAcesso = string.Empty;

        public static string GerarNF(List<ProdutoVendido> produtos, X509Certificate2 x509Cert)
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
            //var certificado = new CertificadoDigital
            //{

            //};
            //X509Certificate2 x509Cert = CarregarCertificado(caminhoCertificado, senhaCertificado, certificado);

            // 3. Executando a consulta
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            consultaCadastro.Executar();

            // 4. Interpretando o resultado
            var resultado = consultaCadastro.Result; // Retorno do objeto
            var retornoWs = consultaCadastro.RetornoWSString; // XML raw

            string cUF = resultado.InfCons.CUF.ToString(); // Código da UF do emitente (SP = 35)
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

            var prods = objNFCe.RecuperarProdutos(produtos, nNF, configuracao, configImposto, resultado, x509Cert);


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
            xmlDoc.Save("NFs\\" + chaveAcesso + ".xml");

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

            //var ret = ConsultarCupomNFCe("NFs\\" + chaveAcesso, x509Cert);

            //var nfce = new NFCeModel();

            IInfProtRepository repository = new InfProtRepository();

            var infoProdutoService = new InfoProdutoService();
            infoProdutoService.AdicionarInfoProduto(new InfoProduto
            {
                ChNFe = chaveAcesso,
                VerAplic = autorizacao.Result.ProtNFe.InfProt.VerAplic,
                DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime,
                NProt = autorizacao.Result.ProtNFe.InfProt.NProt,
                DigVal = autorizacao.Result.ProtNFe.InfProt.DigVal,
                CStat = autorizacao.Result.ProtNFe.InfProt.CStat,
                XMotivo = autorizacao.Result.ProtNFe.InfProt.XMotivo,
                CMsg = autorizacao.Result.ProtNFe.InfProt.CMsg?.ToString(),
                XMsg = autorizacao.Result.ProtNFe.InfProt.XMsg
            }, repository);


            Imprimir(chaveAcesso);

            // Para imprimir direto
            // impressao.Imprimir("Nome_da_Impressora");

            //objNFCe.EventoCancelamentoNFCe(chaveAcesso, x509Cert);

            ///////////objNFCe.ImprimirDANFe(chaveAcesso);

            ///////////var retConsulta = objNFCe.ConsultarCupom(configuracao, chaveAcesso);


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
                        //autorizacao.GravarXmlDistribuicao(@"c:\testenfe\");
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

            return chaveAcesso;

        }
        public static void CancelarNFe(string chave, X509Certificate2 x509Cert, string nProt)
        {
            var objNFCe = new NasNFCe();
            objNFCe.EventoCancelamentoNFCe(chave, x509Cert, nProt);
        }
        public static void Imprimir(string chaveAcesso)
        {
            NFCeModel nfce = NFCeXMLParser.ParseXML("NFs\\" + chaveAcesso + ".xml");
            nfce.QRCodeUrl = NasNFCe.GerarQRCode(chaveAcesso);   // XMLParser. GerarUrlQRCode(nfce, configuracao);

            // Imprimir
            ImpressaoNFCeSP impressao = new ImpressaoNFCeSP(nfce);

            // Para visualizar antes de imprimir
            impressao.Imprimir(null);  // VisualizarImpressao();
        }

        private static X509Certificate2 CarregarCertificado(string caminhoCertificado, string senhaCertificado, CertificadoDigital certificado)
        {
            return certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado);
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
                string _xml = @"C:\\Users\\jjail\\Projetos\\nascom\\nascomercio\\DarumaFrameWork_SAT.xml";
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
