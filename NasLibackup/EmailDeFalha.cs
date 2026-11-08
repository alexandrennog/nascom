using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace NasLibackup
{
    // E-mail para o suporte quando o backup falha (ou so o envio para a nuvem
    // falha). Usa o SmtpClient do proprio .NET Framework (sem pacote extra).
    // Porta 587 com STARTTLS (Gmail, Outlook, Hostinger...). Sem destinatario
    // configurado, nao envia. Falha no e-mail nunca muda o resultado do backup.
    internal static class EmailDeFalha
    {
        public static bool Enviar(ConfiguracaoBackup cfg, ResultadoBackup resultado, LogBackup log)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cfg.EmailDestinatarios))
                {
                    log.Aviso("E-mail de falha nao enviado: preencha BackupEmailDestinatarios no app.config.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(cfg.SmtpServidor) || string.IsNullOrWhiteSpace(cfg.SmtpUsuario))
                {
                    log.Aviso("E-mail de falha nao enviado: falta servidor/usuario SMTP no app.config.");
                    return false;
                }

                string remetente = string.IsNullOrWhiteSpace(cfg.EmailRemetente) ? cfg.SmtpUsuario : cfg.EmailRemetente;

                using (var mensagem = new MailMessage())
                {
                    mensagem.From = new MailAddress(remetente, "Backup Nascomercio");
                    foreach (string destino in cfg.EmailDestinatarios.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (destino.Trim().Length > 0)
                            mensagem.To.Add(destino.Trim());
                    }

                    string tipo = resultado.Situacao == "P" ? "Backup so local (falhou o envio para a nuvem)" : "Falha no backup";
                    mensagem.Subject = tipo + " - " + cfg.Cliente + " / " + cfg.Loja;
                    mensagem.SubjectEncoding = Encoding.UTF8;
                    mensagem.BodyEncoding = Encoding.UTF8;

                    var corpo = new StringBuilder();
                    corpo.AppendLine(tipo + ".");
                    corpo.AppendLine();
                    corpo.AppendLine("Cliente: " + cfg.Cliente);
                    corpo.AppendLine("Loja: " + cfg.Loja);
                    corpo.AppendLine("Computador: " + Environment.MachineName);
                    corpo.AppendLine("Data/hora: " + resultado.Inicio.ToString("dd/MM/yyyy HH:mm:ss"));
                    corpo.AppendLine("Etapa: " + resultado.Etapa);
                    if (resultado.BackupLocalOk)
                        corpo.AppendLine("Backup local: " + resultado.ArquivoLocal);
                    corpo.AppendLine();
                    corpo.AppendLine("Erro: " + resultado.Mensagem);
                    corpo.AppendLine();
                    corpo.AppendLine("O log completo desta execucao vai em anexo.");
                    mensagem.Body = corpo.ToString();

                    if (!string.IsNullOrEmpty(log.Arquivo) && File.Exists(log.Arquivo))
                    {
                        // Copia o log para a memoria (o arquivo continua sendo escrito)
                        byte[] conteudo;
                        using (var fs = new FileStream(log.Arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            conteudo = ms.ToArray();
                        }
                        mensagem.Attachments.Add(new Attachment(new MemoryStream(conteudo), Path.GetFileName(log.Arquivo), "text/plain"));
                    }

                    using (var smtp = new SmtpClient(cfg.SmtpServidor, cfg.SmtpPorta))
                    {
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(cfg.SmtpUsuario, cfg.SmtpSenha);
                        smtp.Timeout = 60000;
                        smtp.Send(mensagem);
                    }
                }

                log.Info("E-mail de falha enviado para " + cfg.EmailDestinatarios + ".");
                return true;
            }
            catch (Exception e)
            {
                log.Aviso("Nao foi possivel enviar o e-mail de falha: " + e.Message);
                return false;
            }
        }
    }
}
