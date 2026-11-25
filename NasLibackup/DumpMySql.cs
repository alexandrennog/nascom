using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace NasLibackup
{
    // Gera o .sql do banco com o mysqldump.exe do proprio MySQL instalado.
    //
    // Por que mysqldump e nao a biblioteca MySqlBackup.NET do NasBackup.exe:
    // ela precisa do MySql.Data 8 ou mais novo (ou do MySqlConnector), e o
    // nascomercio roda com o MySql.Data antigo (5.x/6.x). As duas versoes no
    // mesmo .exe dariam conflito de DLL. O mysqldump e o utilitario oficial,
    // sempre da mesma versao do servidor, e nao precisa de nenhum pacote novo.
    internal static class DumpMySql
    {
        public static void Exportar(string connectionString, string caminhoMysqldump, string arquivoSql, LogBackup log)
        {
            var dados = LerConexao(connectionString);
            string exe = LocalizarMysqldump(caminhoMysqldump);
            log.Info("mysqldump: " + exe);

            // Senha num arquivo de opcoes temporario (--defaults-extra-file, tem que
            // ser o 1o argumento): nao aparece na linha de comando nem no log e
            // funciona em qualquer versao do MySQL (5.x, 8.x).
            string arquivoSenha = CriarArquivoSenha(dados.Senha);
            try
            {
                ExecutarMysqldump(exe, dados, arquivoSenha, arquivoSql, log);
            }
            finally
            {
                try { File.Delete(arquivoSenha); } catch { }
            }

            var info = new FileInfo(arquivoSql);
            if (!info.Exists || info.Length == 0)
                throw new InvalidOperationException("O arquivo de backup não foi gerado ou está vazio: " + arquivoSql);

            // O mysqldump so escreve "-- Dump completed" no fim quando terminou tudo
            if (!TerminouCompleto(arquivoSql))
                throw new InvalidOperationException("O backup ficou incompleto (o mysqldump não terminou): " + arquivoSql);
        }

        private static void ExecutarMysqldump(string exe, DadosConexao dados, string arquivoSenha, string arquivoSql, LogBackup log)
        {
            var args = new StringBuilder();
            args.Append("--defaults-extra-file=").Append(Aspas(arquivoSenha));
            args.Append(" --host=").Append(Aspas(dados.Servidor));
            args.Append(" --port=").Append(dados.Porta);
            args.Append(" --user=").Append(Aspas(dados.Usuario));
            // Sem travar as tabelas (o caixa continua vendendo durante o backup)
            args.Append(" --single-transaction");
            args.Append(" --quick");
            // Procedures/functions (ex.: as do pedido de compra) e triggers
            args.Append(" --routines --triggers");
            args.Append(" --hex-blob");
            args.Append(" --default-character-set=utf8");
            args.Append(" --result-file=").Append(Aspas(arquivoSql));
            args.Append(" ").Append(Aspas(dados.Banco));

            var psi = new ProcessStartInfo(exe, args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = Path.GetDirectoryName(exe)
            };
            using (var processo = Process.Start(psi))
            {
                // Le a saida de erro em paralelo para o processo nao travar com buffer cheio
                var erroTask = processo.StandardError.ReadToEndAsync();
                var saidaTask = processo.StandardOutput.ReadToEndAsync();

                if (!processo.WaitForExit((int)TimeSpan.FromHours(3).TotalMilliseconds))
                {
                    try { processo.Kill(); } catch { }
                    throw new InvalidOperationException("O mysqldump passou de 3 horas e foi interrompido.");
                }
                processo.WaitForExit();

                string erro = (erroTask.Result ?? "").Trim();
                if (processo.ExitCode != 0)
                    throw new InvalidOperationException("O mysqldump terminou com erro (código " + processo.ExitCode + "): " + erro);
                if (erro.Length > 0)
                    log.Aviso("mysqldump avisou: " + erro);
            }
        }

        // Arquivo temporario so com a senha, apagado logo depois do dump
        private static string CriarArquivoSenha(string senha)
        {
            string arquivo = Path.Combine(Path.GetTempPath(), "naslibackup_" + Guid.NewGuid().ToString("N") + ".cnf");
            string valor = (senha ?? "").Replace("\\", "\\\\").Replace("\"", "\\\"");
            // Sem BOM: o MySQL nao entende arquivo de opcoes com BOM
            File.WriteAllText(arquivo, "[client]\r\npassword=\"" + valor + "\"\r\n", new UTF8Encoding(false));
            return arquivo;
        }

        private static bool TerminouCompleto(string arquivoSql)
        {
            using (var fs = new FileStream(arquivoSql, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long tamanho = Math.Min(fs.Length, 4096);
                fs.Seek(-tamanho, SeekOrigin.End);
                var buffer = new byte[tamanho];
                int lidos = fs.Read(buffer, 0, buffer.Length);
                string fim = Encoding.ASCII.GetString(buffer, 0, lidos);
                return fim.IndexOf("Dump completed", StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        internal static string LocalizarMysqldump(string configurado)
        {
            var candidatos = new List<string>();
            if (!string.IsNullOrWhiteSpace(configurado))
                candidatos.Add(configurado.Trim().Trim('"'));

            // Instalacoes padrao do MySQL (5.1, 5.5, 5.7, 8.0...) nas duas pastas de programas
            foreach (string raiz in new[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                @"C:\Program Files",
                @"C:\Program Files (x86)"
            }.Where(r => !string.IsNullOrEmpty(r)).Distinct(StringComparer.OrdinalIgnoreCase))
            {
                string pastaMySql = Path.Combine(raiz, "MySQL");
                try
                {
                    if (Directory.Exists(pastaMySql))
                    {
                        candidatos.AddRange(Directory.GetDirectories(pastaMySql)
                            .OrderByDescending(d => d, StringComparer.OrdinalIgnoreCase)
                            .Select(d => Path.Combine(d, "bin", "mysqldump.exe")));
                    }
                }
                catch
                {
                    // pasta sem permissao: segue procurando
                }
            }

            foreach (string c in candidatos)
            {
                if (File.Exists(c))
                    return c;
            }

            throw new FileNotFoundException(
                "mysqldump.exe não encontrado. O backup precisa rodar no computador que tem o MySQL instalado " +
                "(o servidor) ou o caminho deve ser informado na chave BackupMysqldump do app.config. Procurado em: " +
                string.Join("; ", candidatos));
        }

        private class DadosConexao
        {
            public string Servidor = "localhost";
            public string Porta = "3306";
            public string Usuario = "root";
            public string Senha = "";
            public string Banco = "nascomercio";
        }

        // Le a mesma connection string do nascomercio (ja com a senha descriptografada)
        private static DadosConexao LerConexao(string connectionString)
        {
            var b = new DbConnectionStringBuilder { ConnectionString = connectionString };
            var d = new DadosConexao();

            d.Servidor = Primeiro(b, d.Servidor, "Data Source", "Server", "Host", "Datasource", "Address");
            d.Porta = Primeiro(b, d.Porta, "Port");
            d.Usuario = Primeiro(b, d.Usuario, "User ID", "Uid", "User", "Username", "User name");
            d.Senha = Primeiro(b, d.Senha, "Password", "Pwd");
            d.Banco = Primeiro(b, d.Banco, "Database", "Initial Catalog");

            // "Data Source=host:3307" tambem e aceito
            int doisPontos = d.Servidor.LastIndexOf(':');
            if (doisPontos > 0 && d.Servidor.IndexOf(':') == doisPontos)
            {
                d.Porta = d.Servidor.Substring(doisPontos + 1);
                d.Servidor = d.Servidor.Substring(0, doisPontos);
            }

            return d;
        }

        private static string Primeiro(DbConnectionStringBuilder b, string padrao, params string[] chaves)
        {
            foreach (string chave in chaves)
            {
                object valor;
                if (b.TryGetValue(chave, out valor) && valor != null && valor.ToString().Trim().Length > 0)
                    return valor.ToString().Trim();
            }
            return padrao;
        }

        private static string Aspas(string valor)
        {
            return "\"" + (valor ?? "").Replace("\"", "\\\"") + "\"";
        }
    }
}
