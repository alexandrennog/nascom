using LibNF65.Interfaces;
using LibNF65.Modelo;
using LibNF65.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
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
        // Pasta base ABSOLUTA para os XMLs das NFC-e.
        // Usar caminho absoluto evita que a leitura/gravação dependa do
        // diretório de trabalho atual (Environment.CurrentDirectory), que
        // pode ser alterado internamente por bibliotecas de terceiros
        // (assinatura, validação de schema, chamadas SOAP, etc.) durante
        // a execução de GerarNF, causando "arquivo não encontrado" na
        // hora de imprimir mesmo com a nota autorizada com sucesso.
        private static readonly string PastaBase =
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NFs");

        private static string CaminhoArquivo(string chave) =>
            System.IO.Path.Combine(PastaBase, chave + ".xml");

        private static string CaminhoArquivoOK(string chave) =>
            System.IO.Path.Combine(PastaBase, "OK", chave + ".xml");

        private static string CaminhoArquivoNOK(string chave) =>
            System.IO.Path.Combine(PastaBase, "NOK", chave + ".xml");

        public static string GerarNF(List<ProdutoVendido> produtos, X509Certificate2 x509Cert, List<MeioPagamentoNascom> meiosPagamentos, string cpf, string controle, int nNFTemp)
        {
            // chaveAcesso agora é variável LOCAL, não mais campo estático da classe.
            // Antes, "static string chaveAcesso" era um estado global compartilhado por
            // TODAS as chamadas de GerarNF. Em um PDV que pode processar vendas em
            // paralelo (múltiplas threads / múltiplos terminais usando a mesma lib),
            // isso podia causar uma venda sobrescrever a chave de outra antes da
            // impressão ou da movimentação do arquivo (OK/NOK) — imprimindo o cupom
            // errado ou movendo o XML errado.
            string chaveAcesso;

            PixConfig pixConfig = GetPixConfig();

            int cscIdToken;
            if (!int.TryParse(ConfigurationManager.AppSettings["CSCIDToken"], out cscIdToken))
            {
                throw new Exception("Configuração inválida: 'CSCIDToken' não encontrado ou não é um número válido no arquivo de configuração.");
            }

            var configuracao = new Unimake.Business.DFe.Servicos.Configuracao
            {
                TipoDFe = TipoDFe.NFCe,
                CertificadoArquivo = pixConfig.PathCertificate,
                CertificadoSenha = pixConfig.PassCertificate,
                TipoAmbiente = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
                UsaCertificadoDigital = true,
                CSC = ConfigurationManager.AppSettings["CSC"],
                CSCIDToken = cscIdToken,
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

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // 3. Executando a consulta
            var consultaCadastro = new ConsultaCadastro(consCad, configuracao);
            try
            {
                consultaCadastro.Executar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao consultar cadastro na SEFAZ: {ex.Message}", ex);
            }

            // 4. Interpretando o resultado
            var resultado = consultaCadastro.Result; // Retorno do objeto
            var retornoWs = consultaCadastro.RetornoWSString; // XML raw

            string cUF = resultado.InfCons.CUF.ToString(); // Código da UF do emitente (SP = 35)
            DateTime dhEmi = DateTime.Now; // Data e hora de emissão
            string cnpjEmitente = resultado.InfCons.CNPJ; // CNPJ do emitente (14 dígitos)

            var configImposto = RecuperarConfiguracao();

            var prods = objNFCe.RecuperarProdutos(produtos, nNFTemp, configuracao, configImposto, resultado, x509Cert, meiosPagamentos, cpf, controle);

            var xml = new XmlNFe.EnviNFe
            {
                Versao = "4.00",
                IdLote = GerarIdLote(),
                IndSinc = SimNao.Sim,
                NFe = new List<XmlNFe.NFe> { prods }
            };

            chaveAcesso = xml.NFe.First().InfNFe.FirstOrDefault().Chave;

            var xmlString = XMLUtility.Serializar<XmlNFe.NFe>(xml.NFe.First());
            CriarDiretorios();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString.InnerXml);
            xmlDoc.Save(CaminhoArquivo(chaveAcesso));

            try
            {
                if (!AssinaturaDigital.EstaAssinado(xmlDoc, "infNFe"))
                {
                    AssinaturaDigital.Assinar(xmlDoc, "infNFe", x509Cert, AlgorithmType.Sha1, false);

                    // Regrava o XML já assinado, para que o arquivo em disco
                    // (usado depois na impressão/reimpressão) contenha a assinatura.
                    xmlDoc.Save(CaminhoArquivo(chaveAcesso));
                }
            }
            catch (Exception ex)
            {
                MoverArquivo(chaveAcesso, false);
                throw new Exception($"Falha ao assinar digitalmente o XML da NFC-e {chaveAcesso}: {ex.Message}", ex);
            }

            bool validar = true;
            if (validar)
            {
                try
                {
                    var validador = new ValidarSchema();
                    validador.Validar(xmlString, "NFe");
                }
                catch (Exception ex)
                {
                    MoverArquivo(chaveAcesso, false);
                    throw new Exception($"XML da NFC-e {chaveAcesso} não passou na validação de schema: {ex.Message}", ex);
                }
            }

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var autorizacao = new ServicoNFCe.Autorizacao(xml, configuracao);
            try
            {
                autorizacao.Executar();
            }
            catch (Exception ex)
            {
                // Falha de comunicação com a SEFAZ (timeout, indisponibilidade, etc).
                // Não sabemos se a nota foi ou não autorizada do lado da SEFAZ, então
                // movemos para NOK para que seja tratada manualmente (consulta de
                // situação / reenvio), em vez de deixar o XML "solto" na pasta raiz.
                MoverArquivo(chaveAcesso, false);
                throw new Exception($"Falha ao comunicar com a SEFAZ para autorizar a NFC-e {chaveAcesso}: {ex.Message}", ex);
            }

            // A partir daqui, só seguimos se realmente recebemos um protocolo de
            // resposta da SEFAZ. Antes, quando autorizacao.Result.ProtNFe vinha nulo
            // (ex.: rejeição de lote), o código: (a) já ia estourar NullReferenceException
            // no AdicionarInfoProduto logo abaixo, OU, se isso não acontecesse, o XML
            // ficava esquecido na pasta raiz sem aviso nenhum ao operador do caixa.
            if (autorizacao.Result?.ProtNFe == null)
            {
                MoverArquivo(chaveAcesso, false);
                MessageBox.Show($"A SEFAZ não retornou um protocolo de autorização para a NFC-e {chaveAcesso}. Verifique a situação da nota antes de liberar o cupom.");
                return chaveAcesso;
            }

            var infProt = autorizacao.Result.ProtNFe.InfProt;

            IInfProtRepository repository = new InfProtRepository();
            var infoProdutoService = new InfoProdutoService();
            infoProdutoService.AdicionarInfoProduto(new InfoProduto
            {
                ChNFe = chaveAcesso,
                VerAplic = infProt.VerAplic,
                DhRecbto = infProt.DhRecbto.DateTime,
                NProt = infProt.NProt,
                DigVal = infProt.DigVal,
                CStat = infProt.CStat,
                XMotivo = infProt.XMotivo,
                CMsg = infProt.CMsg?.ToString(),
                XMsg = infProt.XMsg
            }, repository);

            switch (infProt.CStat)
            {
                case 100: //Autorizado o uso da NFe
                    // Impressão só acontece DEPOIS de confirmar CStat == 100.
                    // Antes, Imprimir(chaveAcesso) era chamado incondicionalmente,
                    // então uma nota REJEITADA pela SEFAZ ainda assim gerava um
                    // cupom impresso para o cliente — problema fiscal sério.
                    Imprimir(chaveAcesso);
                    MoverArquivo(chaveAcesso, true);
                    break;
                default:
                    MessageBox.Show($"Ocorreu um erro ao comunicar com a SEFAZ {infProt.CStat}: {infProt.XMotivo}");
                    MoverArquivo(chaveAcesso, false);
                    break;
            }

            return chaveAcesso;
        }

        private static void CriarDiretorios()
        {
            if (!Directory.Exists(PastaBase))
            {
                Directory.CreateDirectory(PastaBase);
                Directory.CreateDirectory(System.IO.Path.Combine(PastaBase, "OK"));
                Directory.CreateDirectory(System.IO.Path.Combine(PastaBase, "NOK"));
            }
            else
            {
                if (!Directory.Exists(System.IO.Path.Combine(PastaBase, "OK")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(PastaBase, "OK"));
                }
                if (!Directory.Exists(System.IO.Path.Combine(PastaBase, "NOK")))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(PastaBase, "NOK"));
                }
            }
        }

        private static void MoverArquivo(string chaveAcesso, bool sucesso)
        {
            string sourcePath = CaminhoArquivo(chaveAcesso);
            string destinationPath = sucesso ? CaminhoArquivoOK(chaveAcesso) : CaminhoArquivoNOK(chaveAcesso);

            if (!File.Exists(sourcePath))
            {
                return;
            }

            try
            {
                // File.Move lança exceção se o destino já existir (ex.: reprocessamento
                // da mesma chave). Removemos o destino antigo antes de mover para evitar
                // que uma IOException aqui derrube o fluxo inteiro depois que a nota já
                // foi autorizada/rejeitada pela SEFAZ.
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Move(sourcePath, destinationPath);
            }
            catch (Exception ex)
            {
                // Não relançamos: nesse ponto a NFC-e já foi processada pela SEFAZ
                // (autorizada ou rejeitada). Uma falha ao mover o arquivo de pasta
                // não pode mascarar o resultado fiscal real da operação. Registramos
                // o erro para investigação, mas o XML original permanece na pasta
                // raiz (PastaBase) em vez de ser perdido.
                MessageBox.Show($"Atenção: a NFC-e {chaveAcesso} foi processada, mas houve falha ao mover o arquivo XML para a pasta {(sucesso ? "OK" : "NOK")}: {ex.Message}");
            }
        }

        public static bool CancelarNFe(string chave, X509Certificate2 x509Cert, string nProt)
        {
            bool retorno = false;
            IInfProtRepository repository = new InfProtRepository();

            var infoProdutoService = new InfoProdutoService();
            var ret = infoProdutoService.BuscarPorChNFe(chave, repository);

            var objNFCe = new NasNFCe();
            var retCancelamento = objNFCe.EventoCancelamentoNFCe(chave, x509Cert, ret.NProt);

            if (retCancelamento.Result.CStat == 128) //Lote de evento processado com sucesso
            {
                switch (retCancelamento.Result.RetEvento[0].InfEvento.CStat)
                {
                    case 135: //Evento homologado
                        infoProdutoService.UpdateEvent(chave, retCancelamento.Result.RetEvento[0].InfEvento.XEvento, ret.NProt, repository);
                        retorno = true;
                        break;
                    case 155: //Evento homologado fora do prazo permitido
                        infoProdutoService.UpdateEvent(chave, retCancelamento.Result.RetEvento[0].InfEvento.XEvento, ret.NProt, repository);
                        retorno = true;
                        break;

                    default:
                        //Tratamentos necessários quando o evento é rejeitado
                        break;
                }
            }

            return retorno;
        }

        public static void Imprimir(string chaveAcesso)
        {
            NFCeModel nfce = NFCeXMLParser.ParseXML(CaminhoArquivo(chaveAcesso));
            nfce.QRCodeUrl = NasNFCe.GerarQRCode(chaveAcesso);   // XMLParser. GerarUrlQRCode(nfce, configuracao);

            // Imprimir
            ImpressaoNFCeSP impressao = new ImpressaoNFCeSP(nfce);

            // Para visualizar antes de imprimir
            impressao.Imprimir(null);  // VisualizarImpressao();
        }

        private static PixConfig GetPixConfig()
        {
            IInfProtRepository repository = new InfProtRepository();

            var infoProdutoService = new InfoProdutoService();
            return infoProdutoService.GetPixConfig(repository);
        }

        public static PixConfig ConsultarConfig()
        {
            PixConfig config = GetPixConfig();

            return config;
        }

        public static void Reimprimir(string chaveAcesso)
        {
            NFCeModel nfce;
            try
            {
                nfce = NFCeXMLParser.ParseXML(CaminhoArquivoOK(chaveAcesso));
            }
            catch (FileNotFoundException)
            {
                nfce = NFCeXMLParser.ParseXML(CaminhoArquivoNOK(chaveAcesso));
            }

            if (nfce == null)
            {
                throw new Exception("NFC-e não encontrada para reimpressão.");
            }

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

        private static DarumaFrameworkSat RecuperarConfiguracao()
        {
            try
            {
                string _xml = ConfigurationManager.AppSettings["pathRelatorio"] + "DarumaFrameWork_SAT.xml";
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
                TpAmb = ConfigurationManager.AppSettings["TipoAmbiente"] == "1" ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
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