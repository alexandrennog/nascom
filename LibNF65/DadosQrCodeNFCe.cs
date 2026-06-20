using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace LibNF65
{

    public class DadosQrCodeNFCe
    {
        public string ChaveAcesso { get; set; }
        public string VersaoQrCode { get; set; } = "2";
        public int Ambiente { get; set; } = 2; // 1-Produção, 2-Homologação
        public string CpfCnpjConsumidor { get; set; }
        public DateTime DataHoraEmissao { get; set; } = DateTime.Now;
        public decimal ValorTotal { get; set; }
        public decimal ValorIcms { get; set; }
        public string DigVal { get; set; }
    }

    public class ServicoQrCodeNFCe
    {
        private readonly string[] _urlsBase = {
        "https://homologacao.nfce.fazenda.sp.gov.br/qrcode", // SP - Homologação
        "https://nfe.fazenda.sp.gov.br/qrcode"           // SP - Produção
    };

        public string GerarUrlConsulta(DadosQrCodeNFCe dados)
        {
            ValidarDados(dados);

            // Selecionar URL base conforme ambiente e estado
            var urlBase = SelecionarUrlBase(dados.ChaveAcesso, dados.Ambiente);

            // Calcular diferença de dias desde 01/01/2000
            var dataBase = new DateTime(2000, 1, 1);
            var diasDiff = (int)(dados.DataHoraEmissao - dataBase).TotalDays;

            // Construir parâmetros
            var parametros = $"{dados.ChaveAcesso}|{dados.VersaoQrCode}|{dados.Ambiente}|{diasDiff}";

            // Adicionar campos opcionais
            if (!string.IsNullOrEmpty(dados.CpfCnpjConsumidor))
            {
                parametros += $"|{dados.CpfCnpjConsumidor}";
            }

            if (dados.ValorTotal > 0)
            {
                parametros += $"|{dados.ValorTotal:F2}";
            }

            if (dados.ValorIcms > 0)
            {
                parametros += $"|{dados.ValorIcms:F2}";
            }

            if (!string.IsNullOrEmpty(dados.DigVal))
            {
                parametros += $"|{dados.DigVal}";
            }

            return $"{urlBase}?p={parametros}";
        }

        public Bitmap GerarImagemQrCode(DadosQrCodeNFCe dados, int tamanho = 256)
        {
            var url = GerarUrlConsulta(dados);
            return GerarImagemQrCodeFromUrl(url, tamanho);
        }

        public Bitmap GerarImagemQrCodeFromUrl(string url, int tamanho = 256)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.M))
            using (var qrCode = new QRCode(qrCodeData))
            {
                return qrCode.GetGraphic(20, Color.Black, Color.White, true);
            }
        }

        public string GerarQrCodeBase64(DadosQrCodeNFCe dados, int tamanho = 256)
        {
            using (var imagem = GerarImagemQrCode(dados, tamanho))
            using (var ms = new System.IO.MemoryStream())
            {
                imagem.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private void ValidarDados(DadosQrCodeNFCe dados)
        {
            if (string.IsNullOrEmpty(dados.ChaveAcesso) || dados.ChaveAcesso.Length != 44)
                throw new ArgumentException("Chave de acesso deve ter 44 caracteres");

            if (dados.Ambiente != 1 && dados.Ambiente != 2)
                throw new ArgumentException("Ambiente deve ser 1 (Produção) ou 2 (Homologação)");
        }

        private string SelecionarUrlBase(string chaveAcesso, int ambiente)
        {
            // Extrair UF da chave de acesso (posições 0-1)
            var uf = chaveAcesso.Substring(0, 2);

            // Compatível com .NET Framework 4.7.2 — sem 'switch expressions'
            if (uf == "43")
            {
                return ambiente == 1 ?
                    "https://nfce.sefaz.rs.gov.br/ws/qrCode" :
                    "https://dfe-portal.svrs.rs.gov.br/nfce/qrCode";
            }
            else if (uf == "35")
            {
                return ambiente == 1 ?
                    "https://nfe.fazenda.sp.gov.br/qrcode" :
                    "https://homologacao.nfce.fazenda.sp.gov.br/qrcode";
            }
            else
            {
                return ambiente == 1 ?
                    string.Format("https://nfce.sefaz.{0}.gov.br/qrCode", uf) :
                    string.Format("https://homologacao.nfce.sefaz.{0}.gov.br/qrCode", uf);
            }
        }
    }
}
