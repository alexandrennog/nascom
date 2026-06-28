using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum;
using ncModelos;

namespace ncRepositorios
{
    public class pProdutoItem : RepositorioBase, IpProdutoItem
    {
        public ColecaoProdutoItem Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dProdutoItem>("SELECT produtos_cid, item, caracteristicas_cid, valor FROM produtoitem").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem Consultar(dProdutoItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.produtos_cid != 0) { conditions.Add("produtos_cid=@produtos_cid"); p.Add("produtos_cid", dados.produtos_cid); }
                    if (dados.item != 0) { conditions.Add("item=@item"); p.Add("item", dados.item); }
                    if (dados.caracteristicas_cid != 0) { conditions.Add("caracteristicas_cid=@caracteristicas_cid"); p.Add("caracteristicas_cid", dados.caracteristicas_cid); }
                    if (!string.IsNullOrEmpty(dados.valor)) { conditions.Add("valor=@valor"); p.Add("valor", dados.valor); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT pi.produtos_cid, pi.item, pi.caracteristicas_cid, pi.valor, c.nome AS caracteristicas_nome, c.codigo AS caracteristicas_codigo FROM produtoitem pi INNER JOIN caracteristicas c ON c.cid = pi.caracteristicas_cid {where} ORDER BY pi.produtos_cid, pi.item";
                    var lista = conn.Query<dProdutoItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    conditions.Add("c.codigo = 'codigoBarras'");
                    conditions.Add("c2.codigo = 'estoque'");
                    conditions.Add("c3.codigo = 'tamanho'");
                    if (emEstoque) conditions.Add("pi2.valor > 0");
                    if (!string.IsNullOrEmpty(descricao)) { conditions.Add("p.descricao LIKE @descricao"); p.Add("descricao", $"%{descricao}%"); }
                    if (!string.IsNullOrEmpty(referencia)) { conditions.Add("p.referencia LIKE @referencia"); p.Add("referencia", $"%{referencia}%"); }
                    if (!string.IsNullOrEmpty(codigoBarras)) { conditions.Add("pi.valor=@codigoBarras"); p.Add("codigoBarras", codigoBarras); }
                    var where = "WHERE " + string.Join(" AND ", conditions);
                    var sql = $@"SELECT p.cid AS produtos_cid, p.descricao AS produtos_descricao, p.referencia AS Produtos_Referencia, p.valorVenda AS Produtos_ValorVenda,
                        pi.valor, pi.item,
                        pi2.valor AS produtos_estoque,
                        pi3.valor AS Produtos_Tamanho,
                        co.nome AS Produtos_Cor
                        FROM produtos p
                        INNER JOIN cor co ON co.cid = p.cor_cid
                        INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid
                        INNER JOIN caracteristicas c ON c.cid = pi.caracteristicas_cid
                        INNER JOIN produtoitem pi2 ON pi2.produtos_cid = p.cid AND pi2.item = pi.item
                        INNER JOIN caracteristicas c2 ON c2.cid = pi2.caracteristicas_cid
                        INNER JOIN produtoitem pi3 ON pi3.produtos_cid = p.cid AND pi3.item = pi.item
                        INNER JOIN caracteristicas c3 ON c3.cid = pi3.caracteristicas_cid
                        {where}
                        ORDER BY p.descricao, p.referencia, co.nome, pi3.valor";
                    var lista = conn.Query<dProdutoItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public decimal ConsultarEstoque(string codigoBarras)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("codigoBarras", codigoBarras);
                    return conn.QueryFirstOrDefault<decimal?>(
                        @"SELECT pi1.valor FROM produtoitem pi1
                        INNER JOIN produtoitem pi2 ON pi2.item = pi1.item AND pi2.produtos_cid = pi1.produtos_cid
                        INNER JOIN caracteristicas c1 ON c1.cid = pi1.caracteristicas_cid AND c1.codigo = 'estoque'
                        WHERE pi2.valor = @codigoBarras", p) ?? 0;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Estoque [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoProdutoItem ConsultarQuantidadeItem(int produto_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("produtos_cid", produto_cid);
                    var lista = conn.Query<dProdutoItem>("SELECT DISTINCT produtos_cid, item FROM produtoitem WHERE produtos_cid=@produtos_cid", p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int? ConsultarUltimoItem(int produto_cid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("produtos_cid", produto_cid);
                    return conn.QueryFirstOrDefault<int?>("SELECT MAX(item) FROM produtoitem WHERE produtos_cid=@produtos_cid", p);
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public string ConsultarUltimoCodigoBarras()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.QueryFirstOrDefault<string>(
                        @"SELECT IFNULL(MAX(pi.valor), '10000000000000') AS codigoBarras
                        FROM produtoitem pi
                        INNER JOIN caracteristicas c ON c.cid = pi.caracteristicas_cid AND c.codigo = 'codigoBarras'
                        WHERE CONVERT(IFNULL(pi.valor, 0), UNSIGNED) > 10000000000000");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dProdutoItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO produtoitem (produtos_cid, item, caracteristicas_cid, valor) VALUES (@produtos_cid, @item, @caracteristicas_cid, @valor)",
                        new { dados.produtos_cid, dados.item, dados.caracteristicas_cid, dados.valor });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dProdutoItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE produtoitem SET valor=@valor WHERE produtos_cid=@produtos_cid AND item=@item AND caracteristicas_cid=@caracteristicas_cid",
                        new { dados.valor, dados.produtos_cid, dados.item, dados.caracteristicas_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int AlterarEstoque(string codigoBarras, decimal quantidade, bool somar)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    string setClause = somar
                        ? "SET pi.valor = CAST(pi.valor AS DECIMAL(10,2)) + @quantidade"
                        : "SET pi.valor = @quantidade";

                    string sql = $@"UPDATE produtoitem pi
                        INNER JOIN produtoitem pi2 ON pi2.produtos_cid = pi.produtos_cid AND pi2.item = pi.item
                        INNER JOIN caracteristicas c  ON c.cid  = pi.caracteristicas_cid  AND c.codigo  = 'estoque'
                        INNER JOIN caracteristicas c2 ON c2.cid = pi2.caracteristicas_cid AND c2.codigo = 'codigoBarras'
                        {setClause}
                        WHERE pi2.valor = @codigoBarras";

                    return conn.Execute(sql, new { codigoBarras, quantidade });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em AlterarEstoque ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dProdutoItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtoitem WHERE produtos_cid=@produtos_cid AND item=@item AND caracteristicas_cid=@caracteristicas_cid",
                        new { dados.produtos_cid, dados.item, dados.caracteristicas_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirPorProduto(dProdutoItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM produtoitem WHERE produtos_cid=@produtos_cid", new { dados.produtos_cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
