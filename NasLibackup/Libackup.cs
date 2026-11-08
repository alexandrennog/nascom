using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace NasLibackup
{
    // Backup do banco do Nascomercio (mesma rotina do NasBackup.exe, agora
    // dentro do sistema):
    //   1. gera o .sql com o mysqldump (sem travar as vendas)
    //   2. compacta em .zip na pasta local (directoryBackupPath) e confere o zip
    //   3. envia o .zip para o bucket da AWS S3 (3 tentativas)
    //   4. so depois do envio OK (e conferido), apaga da NUVEM os backups
    //      anteriores deste mesmo cliente/loja: na nuvem fica sempre so o ultimo
    //   5. apaga da pasta local os backups com mais de N dias (padrao 7)
    //   6. se algo falhar, manda e-mail para o suporte (se configurado)
    //
    // Nunca lanca excecao para quem chama: tudo volta no ResultadoBackup.
    // Roda fora da thread da tela (Task.Run), entao o sistema nao trava.
    public static class Libackup
    {
        // Um backup por vez neste computador (automatico x botao "backup agora")
        private static readonly SemaphoreSlim _emAndamento = new SemaphoreSlim(1, 1);

        public static bool EmAndamento
        {
            get { return _emAndamento.CurrentCount == 0; }
        }

        // Este computador consegue fazer o backup? (precisa do mysqldump.exe, ou
        // seja, ser o computador com o MySQL instalado). Usado para o backup
        // automatico nem tentar nos terminais de caixa.
        public static bool PodeFazerBackupNesteComputador(out string motivo)
        {
            try
            {
                DumpMySql.LocalizarMysqldump(ConfiguracaoBackup.Carregar().CaminhoMysqldump);
                motivo = "";
                return true;
            }
            catch (Exception e)
            {
                motivo = e.Message;
                return false;
            }
        }

        // connectionString: a mesma do nascomercio, com a senha ja descriptografada
        public static Task<ResultadoBackup> RotinaDeCriarBackup(string connectionString)
        {
            return Task.Run(() => Executar(connectionString));
        }

        private static ResultadoBackup Executar(string connectionString)
        {
            var resultado = new ResultadoBackup { Inicio = DateTime.Now, Etapa = "configuracao", Situacao = "F" };

            // .NET Framework: garante TLS 1.2 (AWS e e-mail) mesmo em Windows antigo
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            if (!_emAndamento.Wait(0))
            {
                resultado.Situacao = "A";
                resultado.Mensagem = "Já existe um backup em andamento neste computador.";
                resultado.Fim = DateTime.Now;
                return resultado;
            }

            ConfiguracaoBackup cfg = null;
            LogBackup log = null;
            string arquivoSql = null;

            try
            {
                cfg = ConfiguracaoBackup.Carregar();
                string pasta = cfg.PastaBackupNormalizada;
                Directory.CreateDirectory(pasta);

                log = new LogBackup(Path.Combine(pasta, "logs"));
                resultado.ArquivoLog = log.Arquivo;
                log.Info("Iniciando backup - cliente " + cfg.Cliente + " / loja " + cfg.Loja + " / computador " + Environment.MachineName);

                ValidarConfiguracao(cfg);

                // 1. Dump
                resultado.Etapa = "dump";
                string prefixo = PrefixoDoCliente(cfg);
                string nomeBase = prefixo + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                arquivoSql = Path.Combine(pasta, nomeBase + ".sql");
                DumpMySql.Exportar(connectionString, cfg.CaminhoMysqldump, arquivoSql, log);
                resultado.BytesBanco = new FileInfo(arquivoSql).Length;
                log.Info("Dump gerado: " + arquivoSql + " (" + resultado.BytesBanco + " bytes)");

                // 2. Zip local (este e o "backup local")
                resultado.Etapa = "zip";
                string arquivoZip = Zipar(arquivoSql);
                resultado.ArquivoLocal = arquivoZip;
                resultado.BytesZip = new FileInfo(arquivoZip).Length;
                log.Info("Zip gerado e conferido: " + arquivoZip + " (" + resultado.BytesZip + " bytes)");

                File.Delete(arquivoSql);
                arquivoSql = null;

                // A partir daqui o backup local ja existe
                resultado.Situacao = "P";

                // 3. Nuvem
                resultado.Etapa = "nuvem";
                resultado.Bucket = cfg.Bucket;
                resultado.ChaveNuvem = Path.GetFileName(arquivoZip);
                bool conferidoNaNuvem = EnviarParaS3(cfg, arquivoZip, log).GetAwaiter().GetResult();
                resultado.EnviadoNuvem = true;
                resultado.Situacao = "S";

                // 4. Nuvem: apaga os backups anteriores deste cliente/loja (fica so o de agora).
                // So se o arquivo novo foi conferido la. Problema aqui nao transforma
                // um backup bom em falha: fica registrado na mensagem.
                resultado.Etapa = "limpeza";
                string avisoNuvem = "";
                if (!conferidoNaNuvem)
                {
                    avisoNuvem = " Atenção: sem permissão para conferir o arquivo na nuvem, então os backups anteriores foram mantidos.";
                }
                else
                {
                    try
                    {
                        resultado.ApagadosNuvem = ApagarAnterioresNaNuvem(cfg, prefixo, resultado.ChaveNuvem, log).GetAwaiter().GetResult();
                    }
                    catch (Exception e)
                    {
                        avisoNuvem = " Atenção: não foi possível apagar o backup anterior da nuvem (" + MensagemCompleta(e) + ").";
                        log.Aviso("Backups anteriores nao apagados da nuvem: " + MensagemCompleta(e));
                    }
                }

                // 5. Local: apaga o que passou do prazo (BackupDiasRetencaoLocal)
                try
                {
                    resultado.ArquivosApagados = LimparAntigos(cfg, pasta, arquivoZip, log);
                }
                catch (Exception e)
                {
                    log.Aviso("Limpeza de arquivos antigos nao concluida: " + e.Message);
                }

                resultado.Etapa = "concluido";
                resultado.Mensagem = "Backup concluído: salvo no computador e na nuvem." +
                                     (resultado.ApagadosNuvem > 0
                                         ? " " + resultado.ApagadosNuvem + (resultado.ApagadosNuvem == 1 ? " backup anterior removido" : " backups anteriores removidos") + " da nuvem."
                                         : "") +
                                     avisoNuvem;
                log.Info("Backup concluido com sucesso.");
            }
            catch (Exception e)
            {
                resultado.Mensagem = MensagemCompleta(e);
                if (log != null)
                    log.Erro("Erro na etapa " + resultado.Etapa + ": " + e.Message, e);

                // .sql que sobrou de uma falha (o zip, se existir, fica como backup local)
                if (arquivoSql != null)
                {
                    try { if (File.Exists(arquivoSql)) File.Delete(arquivoSql); } catch { }
                }

                if (resultado.Situacao == "P")
                    resultado.Mensagem = "Backup salvo no computador, mas o envio para a nuvem falhou: " + resultado.Mensagem;

                if (cfg != null && log != null)
                    resultado.EmailEnviado = EmailDeFalha.Enviar(cfg, resultado, log);
            }
            finally
            {
                resultado.Fim = DateTime.Now;
                _emAndamento.Release();
            }

            return resultado;
        }

        private static void ValidarConfiguracao(ConfiguracaoBackup cfg)
        {
            if (string.IsNullOrWhiteSpace(cfg.Bucket))
                throw new InvalidOperationException("Configuração incompleta: a chave bucketName está vazia no app.config.");
            if (string.IsNullOrWhiteSpace(cfg.AwsAccessKeyId) || string.IsNullOrWhiteSpace(cfg.AwsSecretAccessKey))
                throw new InvalidOperationException("Configuração incompleta: as chaves BackupAwsAccessKeyId / BackupAwsSecretAccessKey estão vazias no app.config.");
        }

        // Compacta arquivo -> arquivo (sem carregar o banco na memoria) e confere
        // o zip antes de o .sql ser apagado (mesma verificacao do NasBackup.exe)
        private static string Zipar(string arquivoSql)
        {
            string zipPath = Path.Combine(Path.GetDirectoryName(arquivoSql), Path.GetFileNameWithoutExtension(arquivoSql) + ".zip");

            try
            {
                ZiparEConferir(arquivoSql, zipPath);
            }
            catch
            {
                // Zip pela metade (disco cheio, etc.) nao pode ficar parecendo backup bom
                try { if (File.Exists(zipPath)) File.Delete(zipPath); } catch { }
                throw;
            }

            return zipPath;
        }

        private static void ZiparEConferir(string arquivoSql, string zipPath)
        {
            using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
            using (var zip = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(arquivoSql, Path.GetFileName(arquivoSql), CompressionLevel.Fastest);
            }

            using (var zip = ZipFile.OpenRead(zipPath))
            {
                if (zip.Entries.Count != 1)
                    throw new InvalidOperationException("O zip gerado não tem exatamente um arquivo: " + zipPath);

                long lidos = 0;
                var buffer = new byte[81920];
                using (var entrada = zip.Entries[0].Open())
                {
                    int n;
                    while ((n = entrada.Read(buffer, 0, buffer.Length)) > 0)
                        lidos += n;
                }

                if (lidos != new FileInfo(arquivoSql).Length)
                    throw new InvalidOperationException("O zip gerado não confere com o arquivo original: " + zipPath);
            }
        }

        // "backup_nascomercio_<cliente>_<loja>_" - todo backup deste cliente/loja comeca assim
        private static string PrefixoDoCliente(ConfiguracaoBackup cfg)
        {
            return "backup_nascomercio_" + LimparNome(cfg.Cliente) + "_" + LimparNome(cfg.Loja) + "_";
        }

        private static AmazonS3Client CriarClienteS3(ConfiguracaoBackup cfg)
        {
            var s3Config = new AmazonS3Config { Timeout = TimeSpan.FromHours(2) };

            if (string.IsNullOrWhiteSpace(cfg.AwsServiceUrl))
            {
                s3Config.RegionEndpoint = RegionEndpoint.GetBySystemName(cfg.AwsRegiao);
            }
            else
            {
                // Servidor compativel com S3 (teste local, outro provedor)
                s3Config.ServiceURL = cfg.AwsServiceUrl;
                s3Config.AuthenticationRegion = cfg.AwsRegiao;
                s3Config.ForcePathStyle = true;
            }

            return new AmazonS3Client(cfg.AwsAccessKeyId, cfg.AwsSecretAccessKey, s3Config);
        }

        // Apaga da nuvem os backups ANTERIORES deste cliente/loja, deixando so o
        // que acabou de subir (chaveAtual). So considera arquivos com o nome exato
        // do backup (prefixo + data_hora.zip), nunca outros arquivos do bucket.
        private static async Task<int> ApagarAnterioresNaNuvem(ConfiguracaoBackup cfg, string prefixo, string chaveAtual, LogBackup log)
        {
            var padrao = new Regex("^" + Regex.Escape(prefixo) + @"\d{8}_\d{6}\.zip$", RegexOptions.IgnoreCase);
            var anteriores = new List<string>();

            using (var s3 = CriarClienteS3(cfg))
            {
                var pedido = new ListObjectsV2Request { BucketName = cfg.Bucket, Prefix = prefixo };
                ListObjectsV2Response resposta;
                do
                {
                    resposta = await s3.ListObjectsV2Async(pedido).ConfigureAwait(false);
                    foreach (S3Object objeto in resposta.S3Objects)
                    {
                        if (!string.Equals(objeto.Key, chaveAtual, StringComparison.OrdinalIgnoreCase) && padrao.IsMatch(objeto.Key))
                            anteriores.Add(objeto.Key);
                    }
                    pedido.ContinuationToken = resposta.NextContinuationToken;
                } while (resposta.IsTruncated == true);

                if (anteriores.Count == 0)
                {
                    log.Info("Nenhum backup anterior deste cliente/loja na nuvem.");
                    return 0;
                }

                int apagados = 0;
                // DeleteObjects aceita ate 1000 chaves por chamada
                for (int i = 0; i < anteriores.Count; i += 1000)
                {
                    var lote = anteriores.Skip(i).Take(1000).ToList();
                    var apagar = new DeleteObjectsRequest
                    {
                        BucketName = cfg.Bucket,
                        Objects = lote.Select(k => new KeyVersion { Key = k }).ToList(),
                        Quiet = false
                    };
                    DeleteObjectsResponse r = await s3.DeleteObjectsAsync(apagar).ConfigureAwait(false);
                    foreach (var apagado in r.DeletedObjects)
                    {
                        apagados++;
                        log.Info("Backup anterior apagado da nuvem: " + apagado.Key);
                    }
                }

                if (apagados < anteriores.Count)
                    throw new InvalidOperationException((anteriores.Count - apagados) + " backup(s) anterior(es) não foram apagados da nuvem");

                return apagados;
            }
        }

        // Devolve True quando o arquivo foi enviado E conferido na nuvem; False
        // quando foi enviado mas a chave da AWS nao tem permissao para conferir
        // (s3:GetObject) - nesse caso nada e apagado da nuvem.
        private static async Task<bool> EnviarParaS3(ConfiguracaoBackup cfg, string arquivoZip, LogBackup log)
        {
            string chave = Path.GetFileName(arquivoZip);
            long tamanhoLocal = new FileInfo(arquivoZip).Length;
            const int tentativas = 3;

            using (var s3 = CriarClienteS3(cfg))
            using (var transfer = new TransferUtility(s3))
            {
                for (int tentativa = 1; ; tentativa++)
                {
                    try
                    {
                        log.Info("Enviando " + chave + " para o bucket " + cfg.Bucket + " (tentativa " + tentativa + "/" + tentativas + ")");
                        await transfer.UploadAsync(new TransferUtilityUploadRequest
                        {
                            BucketName = cfg.Bucket,
                            Key = chave,
                            FilePath = arquivoZip
                        }).ConfigureAwait(false);

                        // Confere se o arquivo esta mesmo la, inteiro, ANTES de qualquer
                        // backup anterior ser apagado da nuvem
                        GetObjectMetadataResponse info;
                        try
                        {
                            info = await s3.GetObjectMetadataAsync(cfg.Bucket, chave).ConfigureAwait(false);
                        }
                        catch (AmazonS3Exception e) when (e.StatusCode == HttpStatusCode.Forbidden)
                        {
                            log.Aviso("Arquivo enviado, mas a chave da AWS nao tem permissao para conferir (s3:GetObject). Backups anteriores na nuvem serao mantidos.");
                            return false;
                        }
                        if (info.ContentLength != tamanhoLocal)
                            throw new InvalidOperationException("O arquivo na nuvem ficou com " + info.ContentLength + " bytes, o local tem " + tamanhoLocal + ".");

                        log.Info("Arquivo enviado e conferido na nuvem (" + info.ContentLength + " bytes).");
                        return true;
                    }
                    catch (Exception e) when (tentativa < tentativas)
                    {
                        log.Aviso("Falha no envio (tentativa " + tentativa + "/" + tentativas + "): " + e.Message);
                        await Task.Delay(TimeSpan.FromSeconds(30 * tentativa)).ConfigureAwait(false);
                    }
                }
            }
        }

        // Apaga zips e logs antigos. Falha aqui so gera aviso no log.
        private static int LimparAntigos(ConfiguracaoBackup cfg, string pasta, string manter, LogBackup log)
        {
            int apagados = 0;
            apagados += ApagarMaisAntigosQue(pasta, "backup_nascomercio_*.zip", cfg.DiasRetencaoLocal, manter, log);
            apagados += ApagarMaisAntigosQue(pasta, "backup_nascomercio_*.sql", cfg.DiasRetencaoLocal, manter, log);
            apagados += ApagarMaisAntigosQue(Path.Combine(pasta, "logs"), "NasLibackup-*.txt", cfg.DiasRetencaoLogs, null, log);
            return apagados;
        }

        private static int ApagarMaisAntigosQue(string pasta, string padrao, int dias, string manter, LogBackup log)
        {
            if (dias <= 0 || !Directory.Exists(pasta))
                return 0;

            int apagados = 0;
            DateTime limite = DateTime.Now.AddDays(-dias);

            foreach (string arquivo in Directory.EnumerateFiles(pasta, padrao, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    if (manter != null && string.Equals(Path.GetFullPath(arquivo), Path.GetFullPath(manter), StringComparison.OrdinalIgnoreCase))
                        continue;

                    if (File.GetLastWriteTime(arquivo) < limite)
                    {
                        File.Delete(arquivo);
                        apagados++;
                        log.Info("Arquivo antigo apagado: " + arquivo);
                    }
                }
                catch (Exception e)
                {
                    log.Aviso("Nao foi possivel apagar " + arquivo + ": " + e.Message);
                }
            }

            return apagados;
        }

        private static string LimparNome(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "sem_nome";
            foreach (char c in Path.GetInvalidFileNameChars())
                texto = texto.Replace(c, '_');
            return texto.Trim().Replace(' ', '_');
        }

        private static string MensagemCompleta(Exception e)
        {
            var ae = e as AggregateException;
            if (ae != null && ae.InnerExceptions.Count == 1)
                e = ae.InnerExceptions[0];

            var s3 = e as AmazonS3Exception;
            if (s3 != null)
                return "AWS S3: " + s3.Message + (string.IsNullOrEmpty(s3.ErrorCode) ? "" : " (" + s3.ErrorCode + ")");

            return e.Message;
        }
    }
}
