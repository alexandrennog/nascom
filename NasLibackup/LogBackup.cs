using System;
using System.IO;

namespace NasLibackup
{
    // Log de cada execucao em <pasta do backup>\logs\NasLibackup-AAAAMMDD-HHMMSS.txt
    // (vai anexado no e-mail de falha). Erro ao gravar log nunca derruba o backup.
    internal class LogBackup
    {
        private readonly object _trava = new object();

        public string Arquivo { get; private set; }

        public LogBackup(string pastaLogs)
        {
            try
            {
                Directory.CreateDirectory(pastaLogs);
                Arquivo = Path.Combine(pastaLogs, "NasLibackup-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt");
            }
            catch
            {
                Arquivo = null;
            }
        }

        public void Info(string mensagem) { Gravar("Information", mensagem); }
        public void Aviso(string mensagem) { Gravar("Warning", mensagem); }

        public void Erro(string mensagem, Exception erro)
        {
            Gravar("Error", erro == null ? mensagem : mensagem + Environment.NewLine + erro);
        }

        private void Gravar(string nivel, string mensagem)
        {
            if (Arquivo == null)
                return;

            lock (_trava)
            {
                try
                {
                    File.AppendAllText(Arquivo, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " [" + nivel + "] " + mensagem + Environment.NewLine);
                }
                catch
                {
                    // log nunca pode derrubar o backup
                }
            }
        }
    }
}
