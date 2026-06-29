using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pProdutoEtiqueta : RepositorioBase, IpProdutoEtiqueta
    {
        public ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(dataDe)) { conditions.Add("data >= @dataDe"); p.Add("dataDe", dataDe); }
                    if (!string.IsNullOrEmpty(dataAte)) { conditions.Add("data <= @dataAte"); p.Add("dataAte", dataAte); }
                    if (ImprimeTodos == 0) { conditions.Add("impressao IS NULL"); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $@"SELECT data, impressao, produto_cid, produtoItem_codigoBarras, quantidade, usuario_cid, usuario_nomeCompleto, referencia, c.nome AS cor
                        FROM LogEstoque le
                        INNER JOIN produtos p ON p.cid = le.produto_cid
                        INNER JOIN cor c ON p.cor_cid = c.cid
                        INNER JOIN produtoitem pi ON pi.valor = le.produtoItem_codigoBarras
                        {where}";
                    var lista = conn.Query<dProdutoEtiqueta>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoProdutoEtiqueta();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(string data, string produto, string codigoBarras)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE logEstoque SET impressao='S' WHERE produto_cid=@produto_cid AND produtoItem_codigoBarras=@codigoBarras",
                        new { produto_cid = Convert.ToInt32(produto), codigoBarras });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
