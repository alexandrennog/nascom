using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsProduto;

namespace ncPersistencia.nsProduto
{
    public class pProdutoTipo : RepositorioBase, IpProdutoTipo
    {
        public ColecaoProdutoTipo Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dProdutoTipo>("SELECT cid, nome, situacao FROM produtotipos ORDER BY nome").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoTipo();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoTipo Consultar(dProdutoTipo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.nome)) { conditions.Add("nome=@nome"); p.Add("nome", dados.nome); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT cid, nome, situacao FROM produtotipos {where} ORDER BY nome";
                    var lista = conn.Query<dProdutoTipo>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoTipo();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoTipo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO produtotipos (cid, nome, situacao) VALUES (@cid, @nome, @situacao)",
                        new { dados.cid, dados.nome, dados.situacao });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProdutoTipo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE produtotipos SET nome=@nome, situacao=@situacao WHERE cid=@cid",
                        new { dados.nome, dados.situacao, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProdutoTipo dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtotipos WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipo [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
