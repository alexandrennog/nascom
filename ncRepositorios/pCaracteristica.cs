using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsCaracteristica;

namespace ncPersistencia.nsCaracteristica
{
    public class pCaracteristica : RepositorioBase, IpCaracteristica
    {
        public ColecaoCaracteristica Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, situacao, codigo FROM Caracteristicas ORDER BY nome";
                    var lista = conn.Query<dCaracteristica>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaracteristica();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCaracteristica Consultar(dCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();

                    if (dados.cid != null && dados.cid != 0) { conditions.Add("cid = @cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome = @nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao = @situacao"); p.Add("situacao", dados.situacao); }
                    if (!string.IsNullOrEmpty(dados.codigo)) { conditions.Add("codigo = @codigo"); p.Add("codigo", dados.codigo); }

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, situacao, codigo FROM Caracteristicas {where} ORDER BY nome";

                    var lista = conn.Query<dCaracteristica>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCaracteristica();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO Caracteristicas (nome, situacao, codigo) VALUES (@nome, @situacao, @codigo)";
                    conn.Execute(sql, new { nome = dados.nome, situacao = dados.situacao, codigo = dados.codigo });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE Caracteristicas SET nome=@nome, situacao=@situacao, codigo=@codigo WHERE cid=@cid";
                    return conn.Execute(sql, new { nome = dados.nome, situacao = dados.situacao, codigo = dados.codigo, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Caracteristica [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCaracteristica dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Caracteristicas WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Caracteristica [" + ToString() + "] - " + ex.Message); }
        }
    }
}
