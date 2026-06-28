using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pCondicao : RepositorioBase, IpCondicao
    {
        public ColecaoCondicao Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, nome, desconto, situacao FROM condicao WHERE situacao='A' ORDER BY nome";
                    var lista = conn.Query<dCondicao>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCondicao();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Listar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public ColecaoCondicao Consultar(dCondicao dados)
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
                    var sql = $"SELECT cid, nome, desconto, situacao FROM condicao {where} ORDER BY nome";

                    var lista = conn.Query<dCondicao>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoCondicao();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Consultar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Incluir(dCondicao dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO condicao (nome, desconto, situacao) VALUES (@nome, @desconto, @situacao)";
                    conn.Execute(sql, new { nome = dados.nome, desconto = dados.desconto, situacao = dados.situacao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Alterar(dCondicao dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "UPDATE condicao SET nome=@nome, desconto=@desconto, situacao=@situacao WHERE cid=@cid";
                    return conn.Execute(sql, new { nome = dados.nome, desconto = dados.desconto, situacao = dados.situacao, cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Alterar Condicao [" + ToString() + "] - " + ex.Message); }
        }

        public int Excluir(dCondicao dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM condicao WHERE cid=@cid", new { cid = dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Excluir Condicao [" + ToString() + "] - " + ex.Message); }
        }
    }
}
