using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pVendaProduto : RepositorioBase, IpVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dVendaProduto>(
                        "SELECT controle, produto AS produtoId, quantidade, item AS itemId, valor FROM vendasprodutos").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVendaProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT controle, produto AS produtoId, v.item AS itemId, quantidade, pi.valor AS codigobarras, descricao, referencia, v.valor
                        FROM vendasprodutos v
                        INNER JOIN produtos p ON cid = produto
                        INNER JOIN produtoitem pi ON produtos_cid = produto AND v.item = pi.item AND caracteristicas_cid = 1
                        {where}";
                    var lista = conn.Query<dVendaProduto>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVendaProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoVendaProduto ConsultarTroca(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.controle != 0) { conditions.Add("controle=@controle"); p.Add("controle", dados.controle); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT controle, produto AS produtoId, v.item AS itemId, quantidade, pi.valor AS codigobarras, descricao, referencia, v.valor
                        FROM valesprodutos v
                        INNER JOIN produtos p ON cid = produto
                        INNER JOIN produtoitem pi ON produtos_cid = produto AND v.item = pi.item AND caracteristicas_cid = 1
                        {where}";
                    var lista = conn.Query<dVendaProduto>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVendaProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar troca [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO vendasprodutos (controle, produto, quantidade, item, valor) VALUES (@controle, @produtoId, @quantidade, @itemId, @valor)",
                        new { dados.controle, dados.produtoId, dados.quantidade, dados.itemId, dados.valor });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int IncluirTroca(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO valesprodutos (controle, produto, quantidade, item, valor) VALUES (@controle, @produtoId, @quantidade, @itemId, @valor)",
                        new { dados.controle, dados.produtoId, dados.quantidade, dados.itemId, dados.valor });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Troca [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE vendasprodutos SET valor=@valor, quantidade=@quantidade WHERE controle=@controle AND produto=@produtoId AND item=@itemId",
                        new { dados.valor, dados.quantidade, dados.controle, dados.produtoId, dados.itemId });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM vendasprodutos WHERE controle=@controle AND produto=@produtoId AND item=@itemId",
                        new { dados.controle, dados.produtoId, dados.itemId });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirControle(int controle)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM vendasprodutos WHERE controle=@controle", new { controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int ExcluirControleTroca(int controle)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM valesprodutos WHERE controle=@controle", new { controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
