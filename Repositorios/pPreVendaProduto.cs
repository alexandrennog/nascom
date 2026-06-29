using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pPreVendaProduto : RepositorioBase, IpPreVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dVendaProduto>(
                        "SELECT controle, produto AS produtoId, item AS itemId, quantidade, codigobarras, descricao, referencia, valor FROM prevendaproduto").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoVendaProduto();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar PreVenda [" + ToString() + "] - " + ex.Message);
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
                    var sql = $"SELECT pv.controle, pv.produto AS produtoId, pv.item AS itemId, pv.quantidade, pv.codigobarras, pv.descricao, pv.referencia, pv.valor, p.aliquota FROM prevendaproduto pv INNER JOIN produtos p ON pv.produto = p.cid {where}";
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
                throw new ExcecaoNascomercio("Erro em Consultar PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Incluir(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("INSERT INTO prevendaproduto (controle, produto, item, quantidade, codigobarras, descricao, referencia, valor) VALUES (@controle, @produtoId, @itemId, @quantidade, @codigobarras, @descricao, @referencia, @valor)",
                        new { dados.controle, dados.produtoId, dados.itemId, dados.quantidade, dados.codigobarras, dados.descricao, dados.referencia, dados.valor });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE prevendaproduto SET produto=@produtoId, item=@itemId, quantidade=@quantidade, codigobarras=@codigobarras, descricao=@descricao, referencia=@referencia, valor=@valor WHERE controle=@controle",
                        new { dados.produtoId, dados.itemId, dados.quantidade, dados.codigobarras, dados.descricao, dados.referencia, dados.valor, dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dVendaProduto dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM prevendaproduto WHERE controle=@controle", new { dados.controle });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
