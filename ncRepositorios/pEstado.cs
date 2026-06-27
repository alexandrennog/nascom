using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;

namespace ncPersistencia.nsEstado
{
    public class pEstado : RepositorioBase, IpEstado
    {
        public ColecaoEstado Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, sigla, nome, situacao FROM Estados ORDER BY nome";
                    var lista = conn.Query<dEstado>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoEstado();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoEstado Consultar(dEstado dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();

                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid = @cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.sigla)) { conditions.Add("sigla = @sigla"); p.Add("sigla", dados.sigla); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome = @nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao = @situacao"); p.Add("situacao", dados.situacao); }

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, sigla, nome, situacao FROM Estados {where} ORDER BY nome";

                    var lista = conn.Query<dEstado>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoEstado();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dEstado dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO Estados (sigla, nome, situacao) VALUES (@sigla, @nome, @situacao)";
                    conn.Execute(sql, new { sigla = dados.sigla, nome = dados.nome, situacao = dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dEstado dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE Estados SET sigla=@sigla, nome=@nome, situacao=@situacao WHERE cid=@cid";
                    return conn.Execute(sql, new { sigla = dados.sigla, nome = dados.nome, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Estado [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dEstado dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Estados WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Estado [" + ToString() + "] - " + ex.Message); }
        }
    }
}
