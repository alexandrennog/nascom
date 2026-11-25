using System;

namespace NasLibackup
{
    // O que aconteceu numa execucao do backup. O nascomercio grava isso na
    // tabela "backupnuvem" (historico que alimenta o Relatorio de Backups).
    public class ResultadoBackup
    {
        // S = sucesso (local + nuvem)
        // P = parcial (backup local OK, mas o envio para a nuvem falhou)
        // F = falha (nao gerou backup)
        // A = nao executou porque ja tinha outro backup em andamento neste computador
        public string Situacao { get; set; }

        // Ultima etapa alcancada: configuracao, dump, zip, nuvem, limpeza, concluido
        public string Etapa { get; set; }
        public string Mensagem { get; set; }

        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public string ArquivoLocal { get; set; }
        public long BytesBanco { get; set; }
        public long BytesZip { get; set; }

        public bool EnviadoNuvem { get; set; }
        public string Bucket { get; set; }
        public string ChaveNuvem { get; set; }

        // Backups antigos apagados da pasta local (passaram do prazo)
        public int ArquivosApagados { get; set; }
        // Backups anteriores deste cliente/loja apagados da nuvem (fica so o ultimo)
        public int ApagadosNuvem { get; set; }
        public bool EmailEnviado { get; set; }
        public string ArquivoLog { get; set; }

        public bool Sucesso { get { return Situacao == "S"; } }

        // Backup local existe (S ou P)
        public bool BackupLocalOk { get { return Situacao == "S" || Situacao == "P"; } }

        public TimeSpan Duracao { get { return Fim > Inicio ? Fim - Inicio : TimeSpan.Zero; } }

        public string DescricaoSituacao
        {
            get
            {
                switch (Situacao)
                {
                    case "S": return "Sucesso";
                    case "P": return "Parcial (so local)";
                    case "F": return "Falha";
                    case "A": return "Ja em andamento";
                    default: return Situacao;
                }
            }
        }
    }
}
