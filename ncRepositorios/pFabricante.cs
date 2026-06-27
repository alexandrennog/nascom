using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsFabricante;

namespace ncPersistencia.nsFabricante
{
    public class pFabricante : RepositorioBase, IpFabricante
    {
        public ColecaoFabricante Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, situacao FROM Fabricantes ORDER BY nome";
                    var lista = conn.Query<dFabricante>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoFabricante();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoFabricante Consultar(dFabricante dados)
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

                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, situacao FROM Fabricantes {where} ORDER BY nome";

                    var lista = conn.Query<dFabricante>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoFabricante();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dFabricante dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO Fabricantes (nome, situacao) VALUES (@nome, @situacao)";
                    conn.Execute(sql, new { nome = dados.nome, situacao = dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dFabricante dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE Fabricantes SET nome=@nome, situacao=@situacao WHERE cid=@cid";
                    return conn.Execute(sql, new { nome = dados.nome, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Fabricante [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dFabricante dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Fabricantes WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Fabricante [" + ToString() + "] - " + ex.Message); }
        }
    }
}
