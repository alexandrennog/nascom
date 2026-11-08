using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace NasLibackup
{
    // Tudo o que o backup precisa vem do app.config do nascomercio
    // (<appSettings>). As chaves e o que cada uma faz estao comentadas la.
    public class ConfiguracaoBackup
    {
        // Ja existiam no app.config antes da integracao
        public string Cliente { get; set; }
        public string Loja { get; set; }
        public string Bucket { get; set; }
        public string PastaBackup { get; set; }

        // AWS (mesmos dados que o NasBackup.exe usava)
        public string AwsAccessKeyId { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsRegiao { get; set; }
        // Opcional: endereco de um servidor compativel com S3 (vazio = AWS)
        public string AwsServiceUrl { get; set; }

        // mysqldump.exe (vazio = procura sozinho)
        public string CaminhoMysqldump { get; set; }

        public int DiasRetencaoLocal { get; set; }
        public int DiasRetencaoLogs { get; set; }

        // E-mail de falha
        public string EmailDestinatarios { get; set; }
        public string EmailRemetente { get; set; }
        public string SmtpServidor { get; set; }
        public int SmtpPorta { get; set; }
        public string SmtpUsuario { get; set; }
        public string SmtpSenha { get; set; }

        public static ConfiguracaoBackup Carregar()
        {
            var c = new ConfiguracaoBackup();

            c.Cliente = Ler("Cliente");
            c.Loja = Ler("Loja");
            c.Bucket = Ler("bucketName");
            c.PastaBackup = Ler("directoryBackupPath");
            if (string.IsNullOrWhiteSpace(c.PastaBackup))
                c.PastaBackup = @"C:\nascomercio\backup\";

            c.AwsAccessKeyId = Ler("BackupAwsAccessKeyId");
            c.AwsSecretAccessKey = Ler("BackupAwsSecretAccessKey");
            c.AwsRegiao = Ler("BackupAwsRegiao");
            c.AwsServiceUrl = Ler("BackupAwsServiceUrl");
            if (string.IsNullOrWhiteSpace(c.AwsRegiao))
                c.AwsRegiao = "us-east-1";

            c.CaminhoMysqldump = Ler("BackupMysqldump");
            // Chave antiga da tela de Backup (pasta bin do MySQL), usada como dica
            if (string.IsNullOrWhiteSpace(c.CaminhoMysqldump))
            {
                string pastaBin = Ler("BD_APLICATIVO");
                if (!string.IsNullOrWhiteSpace(pastaBin))
                    c.CaminhoMysqldump = Path.Combine(pastaBin.Trim().Trim('"'), "mysqldump.exe");
            }

            c.DiasRetencaoLocal = LerInteiro("BackupDiasRetencaoLocal", 7);
            c.DiasRetencaoLogs = LerInteiro("BackupDiasRetencaoLogs", 30);

            c.EmailDestinatarios = Ler("BackupEmailDestinatarios");
            c.SmtpServidor = Ler("BackupSmtpServidor");
            c.SmtpPorta = LerInteiro("BackupSmtpPorta", 587);
            c.SmtpUsuario = Ler("BackupSmtpUsuario");
            c.SmtpSenha = Ler("BackupSmtpSenha");
            c.EmailRemetente = Ler("BackupEmailRemetente");

            // Sem SMTP proprio: usa a conta de e-mail que o sistema ja tem
            // configurada (nascomercioMail / nascomercioPass, Gmail)
            if (string.IsNullOrWhiteSpace(c.SmtpUsuario))
            {
                string contaSistema = Ler("nascomercioMail");
                if (!string.IsNullOrWhiteSpace(contaSistema))
                {
                    c.SmtpUsuario = contaSistema;
                    c.SmtpSenha = Ler("nascomercioPass");
                    if (string.IsNullOrWhiteSpace(c.SmtpServidor))
                        c.SmtpServidor = "smtp.gmail.com";
                }
            }

            return c;
        }

        // Pasta onde ficam os .zip (e a subpasta "logs")
        public string PastaBackupNormalizada
        {
            get
            {
                // O app.config antigo tem "C:\\nascomercio\\backup\\" (barras dobradas);
                // o Windows aceita, mas normaliza para o log ficar legivel. Preserva o
                // "\\" do inicio de pasta de rede (\\servidor\backup).
                string p = (PastaBackup ?? "").Trim().Trim('"');
                bool rede = p.StartsWith(@"\\");
                string resto = rede ? p.Substring(2) : p;
                while (resto.Contains(@"\\"))
                    resto = resto.Replace(@"\\", @"\");
                return Path.GetFullPath(rede ? @"\\" + resto : resto);
            }
        }

        private static string Ler(string chave)
        {
            string valor = ConfigurationManager.AppSettings[chave];
            return valor == null ? "" : valor.Trim();
        }

        private static int LerInteiro(string chave, int padrao)
        {
            int valor;
            return int.TryParse(Ler(chave), NumberStyles.Integer, CultureInfo.InvariantCulture, out valor) ? valor : padrao;
        }
    }
}
