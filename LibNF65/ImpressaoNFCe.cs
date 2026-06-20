using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using Unimake.Business.DFe.Xml.NFe;

namespace LibNF65
{
    public class ImpressaoNFCe
    {
        private readonly NfeProc nfeProc;
        private PrintDocument printDoc;
        private int linhaAtual;
        private const int LARGURA_PAGINA = 280; // Largura em pixels para bobina 80mm
        private Font fonteTitulo = new Font("Arial", 10, FontStyle.Bold);
        private Font fonteNormal = new Font("Arial", 8, FontStyle.Regular);
        private Font fontePequena = new Font("Arial", 7, FontStyle.Regular);

        public ImpressaoNFCe(NfeProc nfceProc)
        {
            this.nfeProc = nfceProc;
            ConfigurarImpressao();
        }

        private void ConfigurarImpressao()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(ImprimirPagina);

            // Configurar para impressora térmica
            PaperSize tamanhoPapel = new PaperSize("NFCe", 280, 2000);
            printDoc.DefaultPageSettings.PaperSize = tamanhoPapel;
            printDoc.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
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
                // Dados da NFC-e
                var nfe = nfeProc.NFe;
                var infNFe = nfe.InfNFe.FirstOrDefault();
                var emit = infNFe.Emit;
                var dest = infNFe.Dest;
                var total = infNFe.Total;

                // Cabeçalho - Dados do Emitente
                ImprimirTextoAlinhado(g, emit.XFant ?? emit.XNome, fonteTitulo, Brushes.Black, StringAlignment.Center);
                ImprimirTextoAlinhado(g, $"CNPJ: {FormatarCNPJ(emit.CNPJ)}", fonteNormal, Brushes.Black, StringAlignment.Center);

                // Endereço
                var enderEmit = emit.EnderEmit;
                ImprimirTextoAlinhado(g, $"{enderEmit.XLgr}, {enderEmit.Nro}", fontePequena, Brushes.Black, StringAlignment.Center);
                ImprimirTextoAlinhado(g, $"{enderEmit.XBairro} - {enderEmit.XMun}/{enderEmit.UF}", fontePequena, Brushes.Black, StringAlignment.Center);

                linhaAtual += 5;
                DesenharLinha(g);

                // Título do Documento
                ImprimirTextoAlinhado(g, "CUPOM FISCAL ELETRÔNICO - SAT", fonteTitulo, Brushes.Black, StringAlignment.Center);
                ImprimirTextoAlinhado(g, "NFC-e", fonteTitulo, Brushes.Black, StringAlignment.Center);

                DesenharLinha(g);

                // Produtos
                ImprimirTextoAlinhado(g, "PRODUTOS", fonteTitulo, Brushes.Black, StringAlignment.Center);
                linhaAtual += 5;

                foreach (var det in infNFe.Det)
                {
                    var prod = det.Prod;

                    // Nome do produto
                    ImprimirTexto(g, $"{prod.XProd}", fonteNormal, Brushes.Black, 5);

                    // Código, quantidade, valor unitário e total
                    string linhaProd = $"Cód: {prod.CProd}";
                    ImprimirTexto(g, linhaProd, fontePequena, Brushes.Black, 5);

                    string linhaValores = $"Qtd: {prod.QCom:N3} x R$ {prod.VUnCom:N2} = R$ {prod.VProd:N2}";
                    ImprimirTexto(g, linhaValores, fontePequena, Brushes.Black, 5);

                    linhaAtual += 3;
                }

                DesenharLinha(g);

                // Totais
                ImprimirTextoAlinhado(g, "TOTAIS", fonteTitulo, Brushes.Black, StringAlignment.Center);
                ImprimirTexto(g, $"Quantidade Total de Itens: {infNFe.Det.Count}", fonteNormal, Brushes.Black, 5);
                ImprimirTexto(g, $"Subtotal: R$ {total.ICMSTot.VProd:N2}", fonteNormal, Brushes.Black, 5);
                ImprimirTexto(g, $"Descontos: R$ {total.ICMSTot.VDesc:N2}", fonteNormal, Brushes.Black, 5);
                ImprimirTexto(g, $"VALOR TOTAL: R$ {total.ICMSTot.VNF:N2}", fonteTitulo, Brushes.Black, 5);

                DesenharLinha(g);

                // Forma de Pagamento
                ImprimirTextoAlinhado(g, "FORMA DE PAGAMENTO", fonteTitulo, Brushes.Black, StringAlignment.Center);

                if (infNFe.Pag?.DetPag != null)
                {
                    foreach (var pag in infNFe.Pag.DetPag)
                    {
                        var tipoPag = pag.TPag;
                        string formaPag = ObterDescricaoFormaPagamento((int)pag.TPag);
                        ImprimirTexto(g, $"{formaPag}: R$ {pag.VPag:N2}", fonteNormal, Brushes.Black, 5);
                    }
                }

                DesenharLinha(g);

                // Dados da NFC-e
                ImprimirTextoAlinhado(g, "DADOS DA NFC-e", fonteTitulo, Brushes.Black, StringAlignment.Center);
                ImprimirTexto(g, $"Número: {infNFe.Ide.NNF.ToString().PadLeft(9, '0')}", fontePequena, Brushes.Black, 5);
                ImprimirTexto(g, $"Série: {infNFe.Ide.Serie}", fontePequena, Brushes.Black, 5);
                ImprimirTexto(g, $"Emissão: {infNFe.Ide.DhEmi:dd/MM/yyyy HH:mm:ss}", fontePequena, Brushes.Black, 5);

                // Protocolo de Autorização
                if (nfeProc.ProtNFe?.InfProt != null)
                {
                    ImprimirTexto(g, $"Protocolo: {nfeProc.ProtNFe.InfProt.NProt}", fontePequena, Brushes.Black, 5);
                    ImprimirTexto(g, $"Data Autorização: {nfeProc.ProtNFe.InfProt.DhRecbto:dd/MM/yyyy HH:mm:ss}", fontePequena, Brushes.Black, 5);
                }

                linhaAtual += 10;

                // QR Code
                //ImprimirQRCode(g, infNFe.InfNFeSupl.QrCode);
                string qrCode = nfe.InfNFeSupl?.QrCode;
                if (!string.IsNullOrEmpty(qrCode))
                {
                    ImprimirQRCode(g, qrCode);
                }
                else
                {
                    // Fallback: tentar obter da URL do QR Code se existir
                    qrCode = infNFe.InfAdic?.InfCpl;
                    if (!string.IsNullOrEmpty(qrCode) && qrCode.Contains("http"))
                    {
                        ImprimirQRCode(g, qrCode);
                    }
                }

                linhaAtual += 10;

                // Chave de Acesso
                ImprimirTextoAlinhado(g, "Chave de Acesso", fonteTitulo, Brushes.Black, StringAlignment.Center);
                string chaveFormatada = FormatarChaveAcesso(infNFe.Id.Replace("NFe", ""));
                ImprimirTextoAlinhado(g, chaveFormatada, fontePequena, Brushes.Black, StringAlignment.Center);

                linhaAtual += 10;

                // Informações Adicionais
                if (!string.IsNullOrEmpty(infNFe.InfAdic?.InfCpl))
                {
                    DesenharLinha(g);
                    ImprimirTextoAlinhado(g, "INFORMAÇÕES ADICIONAIS", fonteTitulo, Brushes.Black, StringAlignment.Center);
                    ImprimirTextoQuebraLinha(g, infNFe.InfAdic.InfCpl, fontePequena, Brushes.Black, 5);
                }

                linhaAtual += 10;

                // Rodapé
                DesenharLinha(g);
                ImprimirTextoAlinhado(g, "Consulte pela Chave de Acesso em", fontePequena, Brushes.Black, StringAlignment.Center);
                ImprimirTextoAlinhado(g, "https://www.nfce.fazenda.sp.gov.br/", fontePequena, Brushes.Black, StringAlignment.Center);

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
                    // Centralizar QR Code
                    int x = (LARGURA_PAGINA - 150) / 2;
                    g.DrawImage(qrCodeImage, x, linhaAtual, 150, 150);
                    linhaAtual += 155;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar QR Code: {ex.Message}");
            }
        }

        private void ImprimirTexto(Graphics g, string texto, Font fonte, Brush cor, int x)
        {
            g.DrawString(texto, fonte, cor, x, linhaAtual);
            linhaAtual += (int)g.MeasureString(texto, fonte).Height;
        }

        private void ImprimirTextoAlinhado(Graphics g, string texto, Font fonte, Brush cor, StringAlignment alinhamento)
        {
            StringFormat formato = new StringFormat
            {
                Alignment = alinhamento,
                LineAlignment = StringAlignment.Near
            };

            RectangleF area = new RectangleF(0, linhaAtual, LARGURA_PAGINA, fonte.Height * 2);
            g.DrawString(texto, fonte, cor, area, formato);
            linhaAtual += (int)g.MeasureString(texto, fonte).Height;
        }

        private void ImprimirTextoQuebraLinha(Graphics g, string texto, Font fonte, Brush cor, int x)
        {
            string[] linhas = texto.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linha in linhas)
            {
                ImprimirTexto(g, linha, fonte, cor, x);
            }
        }

        private void DesenharLinha(Graphics g)
        {
            g.DrawLine(Pens.Black, 5, linhaAtual, LARGURA_PAGINA - 5, linhaAtual);
            linhaAtual += 5;
        }

        private string FormatarCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        private string FormatarChaveAcesso(string chave)
        {
            if (string.IsNullOrEmpty(chave) || chave.Length != 44)
                return chave;

            return $"{chave.Substring(0, 4)} {chave.Substring(4, 4)} {chave.Substring(8, 4)} {chave.Substring(12, 4)} " +
                   $"{chave.Substring(16, 4)} {chave.Substring(20, 4)} {chave.Substring(24, 4)} {chave.Substring(28, 4)} " +
                   $"{chave.Substring(32, 4)} {chave.Substring(36, 4)} {chave.Substring(40, 4)}";
        }

        private string ObterDescricaoFormaPagamento(int tipoPagamento)
        {
            switch (tipoPagamento)
            {
                case 1:
                    return "Dinheiro";
                case 2:
                    return "Cheque";
                case 3:
                    return "Cartão de Crédito";
                case 4:
                    return "Cartão de Débito";
                case 5:
                    return "Crédito Loja";
                case 10:
                    return "Vale Alimentação";
                case 11:
                    return "Vale Refeição";
                case 12:
                    return "Vale Presente";
                case 13:
                    return "Vale Combustível";
                case 15:
                    return "Boleto Bancário";
                case 16:
                    return "Depósito Bancário";
                case 17:
                    return "PIX";
                case 18:
                    return "Transferência bancária";
                case 19:
                    return "Cashback";
                case 90:
                    return "Sem pagamento";
                case 99:
                    return "Outros";
                default:
                    return "Não especificado";
            }
        }

    }

    // Exemplo de uso
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        try
    //        {
    //            // Carregar o XML da NFC-e processada
    //            string caminhoXml = @"C:\NFCe\35240312345678901234550010000000011000000010-nfeproc.xml";

    //            // Desserializar o XML usando Unimake
    //            NfeProc nfeProc = new NfeProc().LerXML<NfeProc>(caminhoXml);

    //            // Criar instância da impressão
    //            ImpressaoNFCe impressao = new ImpressaoNFCe(nfeProc);

    //            // Imprimir (deixe vazio para usar impressora padrão ou especifique o nome)
    //            impressao.Imprimir("Nome_da_Impressora_Termica");

    //            Console.WriteLine("NFC-e impressa com sucesso!");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Erro: {ex.Message}");
    //        }
    //    }
    //}
}