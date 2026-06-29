using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pServico : RepositorioBase, IpServico
    {
        public ColecaoServico Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, valor, situacao FROM Servico";
                    var lista = conn.Query<dServico>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoServico();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoServico Consultar(dServico dados)
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
                    var sql = $"SELECT cid, nome, valor, situacao FROM Servico {where}";

                    var lista = conn.Query<dServico>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoServico();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO Servico (nome, valor, situacao) VALUES (@nome, @valor, @situacao)";
                    conn.Execute(sql, new { nome = dados.nome, valor = dados.valor, situacao = dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE Servico SET nome=@nome, valor=@valor, situacao=@situacao WHERE cid=@cid";
                    return conn.Execute(sql, new { nome = dados.nome, valor = dados.valor, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Servico [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dServico dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM Servico WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Servico [" + ToString() + "] - " + ex.Message); }
        }
    }
}
