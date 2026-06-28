using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pGiro : RepositorioBase, IpGiro
    {
        public ColecaoGiro Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dGiro>(
                        "SELECT produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                        "usuario_cid, usuario_nomeCompleto, situacao FROM Giro").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGiro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGiro Consultar(dGiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.produto_cid != null && dados.produto_cid != 0) { conditions.Add("produto_cid=@produto_cid"); p.Add("produto_cid", dados.produto_cid); }
                    if (!string.IsNullOrEmpty(dados.codigoBarras)) { conditions.Add("codigoBarras=@codigoBarras"); p.Add("codigoBarras", dados.codigoBarras); }
                    if (!string.IsNullOrEmpty(dados.dataInicio)) { conditions.Add("dataInicio=@dataInicio"); p.Add("dataInicio", dados.dataInicio); }
                    if (!string.IsNullOrEmpty(dados.dataFim)) { conditions.Add("dataFim=@dataFim"); p.Add("dataFim", dados.dataFim); }
                    if (dados.dias != null && dados.dias != 0) { conditions.Add("dias=@dias"); p.Add("dias", dados.dias); }
                    if (dados.quantidade != null && dados.quantidade != 0) { conditions.Add("quantidade=@quantidade"); p.Add("quantidade", dados.quantidade); }
                    if (dados.usuario_cid != null && dados.usuario_cid != 0) { conditions.Add("usuario_cid=@usuario_cid"); p.Add("usuario_cid", dados.usuario_cid); }
                    if (!string.IsNullOrEmpty(dados.usuario_nomeCompleto)) { conditions.Add("usuario_nomeCompleto=@usuario_nomeCompleto"); p.Add("usuario_nomeCompleto", dados.usuario_nomeCompleto); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                              $"usuario_cid, usuario_nomeCompleto, situacao FROM Giro {where}";
                    var lista = conn.Query<dGiro>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGiro();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dGiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO Giro (produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                        "usuario_cid, usuario_nomeCompleto, situacao) " +
                        "VALUES (@produto_cid, @codigoBarras, @dataInicio, @dataFim, @dias, @quantidade, @dataAtual, " +
                        "@usuario_cid, @usuario_nomeCompleto, @situacao)",
                        new {
                            produto_cid = dados.produto_cid, codigoBarras = dados.codigoBarras,
                            dataInicio = dados.dataInicio, dataFim = dados.dataFim, dias = dados.dias,
                            quantidade = dados.quantidade, dataAtual = dados.dataAtual,
                            usuario_cid = dados.usuario_cid, usuario_nomeCompleto = dados.usuario_nomeCompleto,
                            situacao = dados.situacao
                        });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Importar(dGiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute(
                        "INSERT INTO Giro (produto_cid, codigoBarras, dataInicio, dataFim, dias, quantidade, dataAtual, " +
                        "usuario_cid, usuario_nomeCompleto, situacao) " +
                        "VALUES (@produto_cid, @codigoBarras, @dataInicio, @dataFim, @dias, @quantidade, @dataAtual, " +
                        "@usuario_cid, @usuario_nomeCompleto, @situacao)",
                        new {
                            produto_cid = dados.produto_cid, codigoBarras = dados.codigoBarras,
                            dataInicio = dados.dataInicio, dataFim = dados.dataFim, dias = dados.dias,
                            quantidade = dados.quantidade, dataAtual = dados.dataAtual,
                            usuario_cid = dados.usuario_cid, usuario_nomeCompleto = dados.usuario_nomeCompleto,
                            situacao = dados.situacao
                        });
                    return 1;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Importar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dGiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "UPDATE Giro SET dataInicio=@dataInicio, dataFim=@dataFim, dias=@dias, quantidade=@quantidade, " +
                        "dataAtual=@dataAtual, usuario_cid=@usuario_cid, usuario_nomeCompleto=@usuario_nomeCompleto, situacao=@situacao " +
                        "WHERE produto_cid=@produto_cid AND codigoBarras=@codigoBarras",
                        new {
                            dataInicio = dados.dataInicio, dataFim = dados.dataFim, dias = dados.dias,
                            quantidade = dados.quantidade, dataAtual = dados.dataAtual,
                            usuario_cid = dados.usuario_cid, usuario_nomeCompleto = dados.usuario_nomeCompleto,
                            situacao = dados.situacao, produto_cid = dados.produto_cid, codigoBarras = dados.codigoBarras
                        });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Giro [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dGiro dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute(
                        "DELETE FROM Giro WHERE produto_cid=@produto_cid AND codigoBarras=@codigoBarras",
                        new { produto_cid = dados.produto_cid, codigoBarras = dados.codigoBarras });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Giro [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
