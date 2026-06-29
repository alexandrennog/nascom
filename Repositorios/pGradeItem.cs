using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pGradeItem : RepositorioBase, IpGradeItem
    {
        public ColecaoGradeItem ConsultarReferencia(dGradeItem dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.fornecedor_cid != null && dados.fornecedor_cid != 0) { conditions.Add("p.fornecedor_cid=@fornecedor_cid"); p.Add("fornecedor_cid", dados.fornecedor_cid); }
                    if (dados.fabricante_cid != null && dados.fabricante_cid != 0) { conditions.Add("p.fabricante_cid=@fabricante_cid"); p.Add("fabricante_cid", dados.fabricante_cid); }
                    if (dados.grupo_cid != null && dados.grupo_cid != 0) { conditions.Add("p.grupo_cid=@grupo_cid"); p.Add("grupo_cid", dados.grupo_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var order = dados.ordem ? "ORDER BY p.descricao" : "";
                    var sql = $"SELECT p.referencia, p.descricao FROM produtos p {where} GROUP BY p.referencia {order}";
                    var lista = conn.Query<dGradeItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGradeItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Referência [" + ToString() + "] - " + ex.Message);
            }
        }

        public dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(referencia)) { conditions.Add("p.referencia=@referencia"); p.Add("referencia", referencia); }
                    if (gradeItem.fabricante_cid != null && gradeItem.fabricante_cid != 0) { conditions.Add("p.fabricante_cid=@fabricante_cid"); p.Add("fabricante_cid", gradeItem.fabricante_cid); }
                    if (gradeItem.fornecedor_cid != null && gradeItem.fornecedor_cid != 0) { conditions.Add("p.fornecedor_cid=@fornecedor_cid"); p.Add("fornecedor_cid", gradeItem.fornecedor_cid); }
                    if (gradeItem.grupo_cid != null && gradeItem.grupo_cid != 0) { conditions.Add("p.grupo_cid=@grupo_cid"); p.Add("grupo_cid", gradeItem.grupo_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT v.data AS dataUltimaVenda, c.nome AS corMaterial " +
                              $"FROM vendasprodutos vp " +
                              $"INNER JOIN vendas v ON v.controle = vp.controle " +
                              $"INNER JOIN produtos p ON p.cid = vp.produto " +
                              $"INNER JOIN cor c ON c.cid = p.cor_cid " +
                              $"{where} ORDER BY v.data DESC LIMIT 1";
                    return conn.QueryFirstOrDefault<dGradeItem>(sql, p);
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Ultima Venda [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeItem ConsultarProdutos(string referencia, dGradeItem gradeItem)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (!string.IsNullOrEmpty(referencia)) { conditions.Add("p.referencia=@referencia"); p.Add("referencia", referencia); }
                    if (gradeItem.fabricante_cid != null && gradeItem.fabricante_cid != 0) { conditions.Add("p.fabricante_cid=@fabricante_cid"); p.Add("fabricante_cid", gradeItem.fabricante_cid); }
                    if (gradeItem.fornecedor_cid != null && gradeItem.fornecedor_cid != 0) { conditions.Add("p.fornecedor_cid=@fornecedor_cid"); p.Add("fornecedor_cid", gradeItem.fornecedor_cid); }
                    if (gradeItem.grupo_cid != null && gradeItem.grupo_cid != 0) { conditions.Add("p.grupo_cid=@grupo_cid"); p.Add("grupo_cid", gradeItem.grupo_cid); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var order = gradeItem.ordem ? "ORDER BY c.nome" : "";
                    var sql = $"SELECT p.cid AS produto_cid, c.nome AS corMaterial " +
                              $"FROM produtos p INNER JOIN cor c ON c.cid = p.cor_cid {where} {order}";
                    var lista = conn.Query<dGradeItem>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGradeItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Produtos [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoGradeItem ConsultarItens(int pProdutoCid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    string sql = " select " +
                        "   tabProduto.produto, tabProduto.item, tabProduto.tamanho, " +
                        "   tabProduto.estoque, tabProduto.codigoBarras, tabProduto.dataEntrada, " +
                        "   ifnull(sum(le2.quantidade), 0) as quantidade " +
                        " from " +
                        "   ( " +
                        " select distinct " +
                        "   pi.produtos_cid as produto, pi.item, tabTamanho.valor as tamanho, " +
                        "   tabEstoque.valor as estoque, tabBarra.valor as codigoBarras, " +
                        "   tabData.data as dataEntrada " +
                        " from " +
                        "   produtoitem pi " +
                        "   inner join " +
                        "     ( " +
                        "       select pi1.* from produtoitem pi1 " +
                        "       where pi1.produtos_cid = " + pProdutoCid.ToString() + " and pi1.caracteristicas_cid = 3 " +
                        "     ) as tabTamanho " +
                        "     on tabTamanho.produtos_cid = pi.produtos_cid and tabTamanho.item = pi.item " +
                        "   inner join " +
                        "     ( " +
                        "       select pi2.* from produtoitem pi2 " +
                        "       where pi2.produtos_cid = " + pProdutoCid.ToString() + " and pi2.caracteristicas_cid = 2 " +
                        "     ) as tabEstoque " +
                        "     on tabEstoque.produtos_cid = pi.produtos_cid and tabEstoque.item = pi.item " +
                        "   inner join " +
                        "     ( " +
                        "       select pi3.* from produtoitem pi3 " +
                        "       where pi3.produtos_cid = " + pProdutoCid.ToString() + " and pi3.caracteristicas_cid = 1 " +
                        "     ) as tabBarra " +
                        "     on tabBarra.produtos_cid = pi.produtos_cid and tabBarra.item = pi.item " +
                        "   left outer join " +
                        "     ( " +
                        "       select distinct DATE_FORMAT(le1.data,'%Y-%m-%d') as data, le1.produto_cid " +
                        "       from logestoque le1 where le1.produto_cid = " + pProdutoCid.ToString() + " " +
                        "       order by le1.data desc limit 1 " +
                        "     ) as tabData " +
                        "     on tabData.produto_cid = pi.produtos_cid " +
                        " where " +
                        "   pi.produtos_cid = " + pProdutoCid.ToString() + " " +
                        "   ) as tabProduto " +
                        " left outer join " +
                        "   logestoque le2 " +
                        "   on le2.produto_cid = tabProduto.produto and " +
                        "      le2.produtoItem_codigoBarras = tabProduto.codigoBarras and " +
                        "      DATE_FORMAT(le2.data,'%Y-%m-%d') = DATE_FORMAT(tabProduto.dataEntrada,'%Y-%m-%d') " +
                        " group by " +
                        "   tabProduto.produto, tabProduto.item, tabProduto.tamanho, " +
                        "   tabProduto.estoque, tabProduto.codigoBarras, tabProduto.dataEntrada " +
                        " order by " +
                        "   tabProduto.tamanho ";

                    var lista = conn.Query<dGradeItem>(sql).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoGradeItem();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Consultar Itens [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
