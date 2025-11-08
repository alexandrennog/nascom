using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Xml;

namespace LibNF65
{
    public class NFCeModel
    {
        public string ChaveAcesso { get; set; }
        public string NumeroNota { get; set; }
        public string Serie { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Protocolo { get; set; }
        public DateTime DataAutorizacao { get; set; }

        // Emitente
        public string EmitenteCNPJ { get; set; }
        public string EmitenteNome { get; set; }
        public string EmitenteFantasia { get; set; }
        public string EmitenteEndereco { get; set; }
        public string EmitenteBairro { get; set; }
        public string EmitenteCidade { get; set; }
        public string EmitenteUF { get; set; }
        public string EmitenteIE { get; set; }

        // Destinatário
        public string DestCPFCNPJ { get; set; }
        public string DestNome { get; set; }

        // Produtos
        public class Produto
        {
            public int Item { get; set; }
            public string Codigo { get; set; }
            public string Descricao { get; set; }
            public decimal Quantidade { get; set; }
            public string Unidade { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal ValorTotal { get; set; }
        }

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        // Pagamentos
        public class Pagamento
        {
            public string FormaPagamento { get; set; }
            public decimal Valor { get; set; }
        }

        public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

        // Totais
        public decimal QuantidadeTotal { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }

        // QR Code e URL
        public string QRCodeUrl { get; set; }
        public string UrlConsulta { get; set; }

        // Informações Adicionais
        public string InformacoesAdicionais { get; set; }
    }

    public class ImpressaoNFCeSP
    {
        private NFCeModel nfce;
        private PrintDocument printDoc;
        private int linhaAtual;
        private const int LARGURA_PAGINA = 280; // 80mm em pixels
        private const int MARGEM = 5;

        private Font fonteTitulo = new Font("Arial", 10, FontStyle.Bold);
        private Font fonteNormal = new Font("Arial", 8, FontStyle.Regular);
        private Font fontePequena = new Font("Arial", 7, FontStyle.Regular);
        private Font fonteNegrito = new Font("Arial", 8, FontStyle.Bold);

        public ImpressaoNFCeSP(NFCeModel nfce)
        {
            this.nfce = nfce;
            ConfigurarImpressao();
        }

        private void ConfigurarImpressao()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += ImprimirPagina;

            // Configurar papel para impressora térmica 80mm
            PaperSize tamanhoPapel = new PaperSize("NFCe", 280, 2000);
            printDoc.DefaultPageSettings.PaperSize = tamanhoPapel;
            printDoc.DefaultPageSettings.Margins = new Margins(MARGEM, MARGEM, MARGEM, MARGEM);
        }

        public void Imprimir(string nomeImpressora = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(nomeImpressora))
                {
                    printDoc.PrinterSettings.PrinterName = nomeImpressora;
                }

                printDoc.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao imprimir NFC-e: {ex.Message}", ex);
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            linhaAtual = 10;

            try
            {
                // Cabeçalho - Identificação do Estabelecimento
                ImprimirCentralizado(g, nfce.EmitenteFantasia ?? nfce.EmitenteNome, fonteTitulo);
                ImprimirCentralizado(g, nfce.EmitenteNome, fonteNormal);
                ImprimirCentralizado(g, $"CNPJ: {FormatarCNPJ(nfce.EmitenteCNPJ)}", fonteNormal);
                ImprimirCentralizado(g, $"IE: {nfce.EmitenteIE}", fonteNormal);

                // Endereço do Emitente
                ImprimirCentralizado(g, nfce.EmitenteEndereco, fontePequena);
                ImprimirCentralizado(g, $"{nfce.EmitenteBairro} - {nfce.EmitenteCidade}/{nfce.EmitenteUF}", fontePequena);

                linhaAtual += 5;
                DesenharLinha(g);

                // Identificação do Documento
                ImprimirCentralizado(g, "DOCUMENTO AUXILIAR DA NOTA FISCAL DE", fonteNormal);
                ImprimirCentralizado(g, "CONSUMIDOR ELETRÔNICA", fonteNormal);
                linhaAtual += 3;
                ImprimirCentralizado(g, "NFC-e - Modelo 65", fonteTitulo);

                DesenharLinha(g);

                // Dados da Nota
                ImprimirTexto(g, $"Nº: {nfce.NumeroNota.PadLeft(9, '0')}", fonteNormal, MARGEM);
                ImprimirTexto(g, $"Série: {nfce.Serie}", fonteNormal, MARGEM);
                ImprimirTexto(g, $"Emissão: {nfce.DataEmissao:dd/MM/yyyy HH:mm:ss}", fonteNormal, MARGEM);

                // Destinatário (se houver)
                if (!string.IsNullOrEmpty(nfce.DestCPFCNPJ))
                {
                    linhaAtual += 3;
                    DesenharLinha(g);
                    ImprimirCentralizado(g, "CONSUMIDOR", fonteTitulo);
                    ImprimirTexto(g, $"CPF/CNPJ: {FormatarCPFCNPJ(nfce.DestCPFCNPJ)}", fonteNormal, MARGEM);
                    if (!string.IsNullOrEmpty(nfce.DestNome))
                    {
                        ImprimirTexto(g, $"Nome: {nfce.DestNome}", fonteNormal, MARGEM);
                    }
                }

                DesenharLinha(g);

                // Lista de Produtos
                ImprimirCentralizado(g, "ITENS", fonteTitulo);
                linhaAtual += 3;

                foreach (var produto in nfce.Produtos)
                {
                    // Descrição do produto
                    ImprimirTexto(g, $"{produto.Item:000} - {produto.Descricao}", fonteNormal, MARGEM);

                    // Código do produto
                    ImprimirTexto(g, $"    Cód: {produto.Codigo}", fontePequena, MARGEM);

                    // Quantidade, Unitário e Total
                    string linhaValor = $"    {produto.Quantidade:N3} {produto.Unidade} x {produto.ValorUnitario:N2} = {produto.ValorTotal:N2}";
                    ImprimirTexto(g, linhaValor, fontePequena, MARGEM);

                    linhaAtual += 2;
                }

                DesenharLinha(g);

                // Totais
                ImprimirCentralizado(g, "TOTAIS", fonteTitulo);
                ImprimirTexto(g, $"Qtd. Total de Itens: {nfce.QuantidadeTotal:N0}", fonteNormal, MARGEM);
                ImprimirTexto(g, $"Valor Total dos Produtos: R$ {nfce.ValorProdutos:N2}", fonteNormal, MARGEM);

                if (nfce.ValorDesconto > 0)
                {
                    ImprimirTexto(g, $"Descontos: R$ {nfce.ValorDesconto:N2}", fonteNormal, MARGEM);
                }

                ImprimirTexto(g, $"VALOR TOTAL: R$ {nfce.ValorTotal:N2}", fonteTitulo, MARGEM);

                DesenharLinha(g);

                // Formas de Pagamento
                ImprimirCentralizado(g, "FORMA DE PAGAMENTO", fonteTitulo);

                foreach (var pagamento in nfce.Pagamentos)
                {
                    ImprimirTexto(g, $"{pagamento.FormaPagamento}: R$ {pagamento.Valor:N2}", fonteNormal, MARGEM);
                }

                DesenharLinha(g);

                // Informações sobre Tributos
                ImprimirCentralizado(g, "Tributos Totais Incidentes (Lei Federal 12.741/2012)", fontePequena);

                linhaAtual += 5;
                DesenharLinha(g);

                // Consulta via Chave de Acesso
                ImprimirCentralizado(g, "CONSULTE PELA CHAVE DE ACESSO", fonteTitulo);

                string chaveFormatada = FormatarChaveAcesso(nfce.ChaveAcesso);
                ImprimirCentralizado(g, chaveFormatada, fontePequena);

                linhaAtual += 10;

                // QR Code
                if (!string.IsNullOrEmpty(nfce.QRCodeUrl))
                {
                    ImprimirQRCode(g, nfce.QRCodeUrl);
                }

                linhaAtual += 10;

                // Protocolo de Autorização
                if (!string.IsNullOrEmpty(nfce.Protocolo))
                {
                    DesenharLinha(g);
                    ImprimirCentralizado(g, "PROTOCOLO DE AUTORIZAÇÃO", fonteTitulo);
                    ImprimirCentralizado(g, nfce.Protocolo, fonteNormal);
                    ImprimirCentralizado(g, $"{nfce.DataAutorizacao:dd/MM/yyyy HH:mm:ss}", fontePequena);
                }

                linhaAtual += 5;

                // URL de Consulta
                if (!string.IsNullOrEmpty(nfce.UrlConsulta))
                {
                    DesenharLinha(g);
                    ImprimirCentralizado(g, "Consulta via leitor de QR Code", fontePequena);
                    ImprimirCentralizado(g, nfce.UrlConsulta, fontePequena);
                }

                // Informações Adicionais
                if (!string.IsNullOrEmpty(nfce.InformacoesAdicionais))
                {
                    linhaAtual += 5;
                    DesenharLinha(g);
                    ImprimirCentralizado(g, "INFORMAÇÕES ADICIONAIS", fonteTitulo);
                    ImprimirTextoQuebraLinha(g, nfce.InformacoesAdicionais, fontePequena, MARGEM);
                }

                linhaAtual += 10;

                // Rodapé
                DesenharLinha(g);
                ImprimirCentralizado(g, "Consulte pela Chave de Acesso em", fontePequena);
                ImprimirCentralizado(g, "https://www.nfce.fazenda.sp.gov.br/", fontePequena);
                linhaAtual += 5;
                ImprimirCentralizado(g, "OBRIGADO PELA PREFERÊNCIA!", fonteNegrito);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar impressão: {ex.Message}", ex);
            }

            e.HasMorePages = false;
        }

        private void ImprimirQRCode(Graphics g, string textoQRCode)
        {
            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(textoQRCode, QRCodeGenerator.ECCLevel.M))
                using (QRCode qrCode = new QRCode(qrCodeData))
                using (Bitmap qrCodeImage = qrCode.GetGraphic(5))
                {
                    int tamanhoQR = 150;
                    int x = (LARGURA_PAGINA - tamanhoQR) / 2;
                    g.DrawImage(qrCodeImage, x, linhaAtual, tamanhoQR, tamanhoQR);
                    linhaAtual += tamanhoQR + 5;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar QR Code: {ex.Message}");
            }
        }

        private void ImprimirTexto(Graphics g, string texto, Font fonte, int x)
        {
            g.DrawString(texto, fonte, Brushes.Black, x, linhaAtual);
            linhaAtual += (int)Math.Ceiling(g.MeasureString(texto, fonte, LARGURA_PAGINA - (2 * MARGEM)).Height);
        }

        private void ImprimirCentralizado(Graphics g, string texto, Font fonte)
        {
            StringFormat formato = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };

            RectangleF area = new RectangleF(0, linhaAtual, LARGURA_PAGINA, fonte.Height * 2);
            g.DrawString(texto, fonte, Brushes.Black, area, formato);
            linhaAtual += (int)Math.Ceiling(g.MeasureString(texto, fonte, LARGURA_PAGINA).Height);
        }

        private void ImprimirTextoQuebraLinha(Graphics g, string texto, Font fonte, int x)
        {
            string[] linhas = texto.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linha in linhas)
            {
                ImprimirTexto(g, linha, fonte, x);
            }
        }

        private void DesenharLinha(Graphics g)
        {
            g.DrawLine(Pens.Black, MARGEM, linhaAtual, LARGURA_PAGINA - MARGEM, linhaAtual);
            linhaAtual += 5;
        }

        private string FormatarCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        private string FormatarCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
                return cpf;

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        private string FormatarCPFCNPJ(string documento)
        {
            if (string.IsNullOrEmpty(documento))
                return documento;

            if (documento.Length == 11)
                return FormatarCPF(documento);
            else if (documento.Length == 14)
                return FormatarCNPJ(documento);

            return documento;
        }

        private string FormatarChaveAcesso(string chave)
        {
            if (string.IsNullOrEmpty(chave) || chave.Length != 44)
                return chave;

            return $"{chave.Substring(0, 4)} {chave.Substring(4, 4)} {chave.Substring(8, 4)} {chave.Substring(12, 4)} " +
                   $"{chave.Substring(16, 4)} {chave.Substring(20, 4)} {chave.Substring(24, 4)} {chave.Substring(28, 4)} " +
                   $"{chave.Substring(32, 4)} {chave.Substring(36, 4)} {chave.Substring(40, 4)}";
        }
    }

    // Parser XML para NFC-e
    public class NFCeXMLParser
    {
        public static NFCeModel ParseXML(string caminhoXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(caminhoXml);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");

            NFCeModel nfce = new NFCeModel();

            // Identificação
            XmlNode ide = doc.SelectSingleNode("//nfe:ide", nsmgr);
            if (ide != null)
            {
                nfce.NumeroNota = ide.SelectSingleNode("nfe:nNF", nsmgr)?.InnerText;
                nfce.Serie = ide.SelectSingleNode("nfe:serie", nsmgr)?.InnerText;
                string dhEmi = ide.SelectSingleNode("nfe:dhEmi", nsmgr)?.InnerText;
                if (DateTime.TryParse(dhEmi, out DateTime dataEmissao))
                    nfce.DataEmissao = dataEmissao;
            }

            // Chave de Acesso
            XmlNode infNFe = doc.SelectSingleNode("//nfe:infNFe", nsmgr);
            if (infNFe != null)
            {
                nfce.ChaveAcesso = infNFe.Attributes["Id"]?.Value.Replace("NFe", "");
            }

            // Emitente
            XmlNode emit = doc.SelectSingleNode("//nfe:emit", nsmgr);
            if (emit != null)
            {
                nfce.EmitenteCNPJ = emit.SelectSingleNode("nfe:CNPJ", nsmgr)?.InnerText;
                nfce.EmitenteNome = emit.SelectSingleNode("nfe:xNome", nsmgr)?.InnerText;
                nfce.EmitenteFantasia = emit.SelectSingleNode("nfe:xFant", nsmgr)?.InnerText;
                nfce.EmitenteIE = emit.SelectSingleNode("nfe:IE", nsmgr)?.InnerText;

                XmlNode enderEmit = emit.SelectSingleNode("nfe:enderEmit", nsmgr);
                if (enderEmit != null)
                {
                    string logradouro = enderEmit.SelectSingleNode("nfe:xLgr", nsmgr)?.InnerText;
                    string numero = enderEmit.SelectSingleNode("nfe:nro", nsmgr)?.InnerText;
                    nfce.EmitenteEndereco = $"{logradouro}, {numero}";
                    nfce.EmitenteBairro = enderEmit.SelectSingleNode("nfe:xBairro", nsmgr)?.InnerText;
                    nfce.EmitenteCidade = enderEmit.SelectSingleNode("nfe:xMun", nsmgr)?.InnerText;
                    nfce.EmitenteUF = enderEmit.SelectSingleNode("nfe:UF", nsmgr)?.InnerText;
                }
            }

            // Destinatário
            XmlNode dest = doc.SelectSingleNode("//nfe:dest", nsmgr);
            if (dest != null)
            {
                nfce.DestCPFCNPJ = dest.SelectSingleNode("nfe:CPF", nsmgr)?.InnerText ??
                                   dest.SelectSingleNode("nfe:CNPJ", nsmgr)?.InnerText;
                nfce.DestNome = dest.SelectSingleNode("nfe:xNome", nsmgr)?.InnerText;
            }

            // Produtos
            XmlNodeList produtos = doc.SelectNodes("//nfe:det", nsmgr);
            foreach (XmlNode det in produtos)
            {
                XmlNode prod = det.SelectSingleNode("nfe:prod", nsmgr);
                if (prod != null)
                {
                    var produto = new NFCeModel.Produto
                    {
                        Item = int.Parse(det.Attributes["nItem"]?.Value ?? "0"),
                        Codigo = prod.SelectSingleNode("nfe:cProd", nsmgr)?.InnerText,
                        Descricao = prod.SelectSingleNode("nfe:xProd", nsmgr)?.InnerText,
                        Quantidade = decimal.Parse(prod.SelectSingleNode("nfe:qCom", nsmgr)?.InnerText ?? "0"),
                        Unidade = prod.SelectSingleNode("nfe:uCom", nsmgr)?.InnerText,
                        ValorUnitario = decimal.Parse(prod.SelectSingleNode("nfe:vUnCom", nsmgr)?.InnerText ?? "0"),
                        ValorTotal = decimal.Parse(prod.SelectSingleNode("nfe:vProd", nsmgr)?.InnerText ?? "0")
                    };
                    nfce.Produtos.Add(produto);
                }
            }

            // Totais
            XmlNode total = doc.SelectSingleNode("//nfe:total/nfe:ICMSTot", nsmgr);
            if (total != null)
            {
                nfce.ValorProdutos = decimal.Parse(total.SelectSingleNode("nfe:vProd", nsmgr)?.InnerText ?? "0");
                nfce.ValorDesconto = decimal.Parse(total.SelectSingleNode("nfe:vDesc", nsmgr)?.InnerText ?? "0");
                nfce.ValorTotal = decimal.Parse(total.SelectSingleNode("nfe:vNF", nsmgr)?.InnerText ?? "0");
            }

            nfce.QuantidadeTotal = nfce.Produtos.Count;

            // Pagamentos
            XmlNodeList pagamentos = doc.SelectNodes("//nfe:pag/nfe:detPag", nsmgr);
            foreach (XmlNode pag in pagamentos)
            {
                string tPag = pag.SelectSingleNode("nfe:tPag", nsmgr)?.InnerText;
                decimal vPag = decimal.Parse(pag.SelectSingleNode("nfe:vPag", nsmgr)?.InnerText ?? "0");

                nfce.Pagamentos.Add(new NFCeModel.Pagamento
                {
                    FormaPagamento = ObterDescricaoFormaPagamento(tPag),
                    Valor = vPag
                });
            }

            // Protocolo
            XmlNode protNFe = doc.SelectSingleNode("//nfe:protNFe/nfe:infProt", nsmgr);
            if (protNFe != null)
            {
                nfce.Protocolo = protNFe.SelectSingleNode("nfe:nProt", nsmgr)?.InnerText;
                string dhRecbto = protNFe.SelectSingleNode("nfe:dhRecbto", nsmgr)?.InnerText;
                if (DateTime.TryParse(dhRecbto, out DateTime dataAut))
                    nfce.DataAutorizacao = dataAut;
            }

            // QR Code
            XmlNode infNFeSupl = doc.SelectSingleNode("//nfe:infNFeSupl", nsmgr);
            if (infNFeSupl != null)
            {
                nfce.QRCodeUrl = infNFeSupl.SelectSingleNode("nfe:qrCode", nsmgr)?.InnerText;
                nfce.UrlConsulta = infNFeSupl.SelectSingleNode("nfe:urlChave", nsmgr)?.InnerText;
            }

            // Informações Adicionais
            XmlNode infAdic = doc.SelectSingleNode("//nfe:infAdic", nsmgr);
            if (infAdic != null)
            {
                nfce.InformacoesAdicionais = infAdic.SelectSingleNode("nfe:infCpl", nsmgr)?.InnerText;
            }

            return nfce;
        }

        private static string ObterDescricaoFormaPagamento(string codigo)
        {
            switch (codigo)
            {
                case "01":
                    return "Dinheiro";
                case "02":
                    return "Cheque";
                case "03":
                    return "Cartão de Crédito";
                case "04":
                    return "Cartão de Débito";
                case "05":
                    return "Crédito Loja";
                case "10":
                    return "Vale Alimentação";
                case "11":
                    return "Vale Refeição";
                case "12":
                    return "Vale Presente";
                case "13":
                    return "Vale Combustível";
                case "15":
                    return "Boleto Bancário";
                case "16":
                    return "Depósito Bancário";
                case "17":
                    return "PIX";
                case "18":
                    return "Transferência bancária";
                case "19":
                    return "Cashback";
                case "90":
                    return "Sem pagamento";
                case "99":
                    return "Outros";
                default:
                    return "Não especificado";
            }
        }

    }

}

//        // Exemplo de uso
//        public class Program
//        {
//            public static void Main(string[] args)
//            {
//                try
//                {
//                    Console.WriteLine("=== IMPRESSÃO NFC-e MODELO 65 - SÃO PAULO ===\n");

//                    // OPÇÃO 1: Ler de arquivo XML
//                    string caminhoXml = @"C:\NFCe\35240312345678901234550010000000011000000010-nfeproc.xml";

//                    if (System.IO.File.Exists(caminhoXml))
//                    {
//                        // Parser do XML
//                        NFCeModel nfce = NFCeXMLParser.ParseXML(caminhoXml);

//                        // Imprimir
//                        ImpressaoNFCeSP impressao = new ImpressaoNFCeSP(nfce);

//                        // Para visualizar antes de imprimir
// impressao.VisualizarImpressao();

//                        // Para imprimir direto
//                        // impressao.Imprimir("Nome_da_Impressora");

//                        Console.WriteLine("Impressão concluída!");
//                    }
//                    else
//                    {
//                        // OPÇÃO 2: Criar manualmente (para testes)
//                        NFCeModel nfceExemplo = CriarNFCeExemplo();

//                        ImpressaoNFCeSP impressao = new ImpressaoNFCeSP(nfceExemplo);
//                        impressao.VisualizarImpressao();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Erro: {ex.Message}");
//                    Console.WriteLine($"StackTrace: {ex.StackTrace}");
//                }

//                Console.WriteLine("\nPressione qualquer tecla para sair...");
//                Console.ReadKey();
//            }

//            // Método auxiliar para criar NFC-e de exemplo
//            private static NFCeModel CriarNFCeExemplo()
//            {
//                return new NFCeModel
//                {
//                    ChaveAcesso = "35240312345678901234550010000000011000000010",
//                    NumeroNota = "1",
//                    Serie = "1",
//                    DataEmissao = DateTime.Now,
//                    Protocolo = "123456789012345",
//                    DataAutorizacao = DateTime.Now,

//                    EmitenteCNPJ = "12345678901234",
//                    EmitenteNome = "EMPRESA EXEMPLO LTDA",
//                    EmitenteFantasia = "LOJA EXEMPLO",
//                    EmitenteEndereco = "RUA EXEMPLO, 123",
//                    EmitenteBairro = "CENTRO",
//                    EmitenteCidade = "SÃO PAULO",
//                    EmitenteUF = "SP",
//                    EmitenteIE = "123456789012",

//                    DestCPFCNPJ = "12345678901",
//                    DestNome = "CLIENTE EXEMPLO",

//                    Produtos = new List<NFCeModel.Produto>
//                {
//                    new NFCeModel.Produto
//                    {
//                        Item = 1,
//                        Codigo = "001",
//                        Descricao = "PRODUTO EXEMPLO 1",
//                        Quantidade = 2,
//                        Unidade = "UN",
//                        ValorUnitario = 10.50m,
//                        ValorTotal = 21.00m
//                    },
//}
