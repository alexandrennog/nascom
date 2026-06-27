using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsGradeItem;

namespace ncPersistencia.nsGradeItem
{
    public class pGradeItem
    {
        public ColecaoGradeItem ConsultarReferencia(dGradeItem dados)
        {
            ColecaoGradeItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select p.referencia, p.descricao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " from produtos p ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "p.fornecedor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fabricante_cid, "p.fabricante_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.grupo_cid, "p.grupo_cid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                DataSet ds;
                if (dados.ordem == true)
                    ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " group by p.referencia order by p.descricao ");
                else
                    ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " group by p.referencia ");

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGradeItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGradeItem();
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Referência [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public dGradeItem ConsultarUltimaVenda(string referencia, dGradeItem gradeItem)
        {
            dGradeItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select v.data, c.nome ";
                string sqlFrom = " from vendasprodutos vp " +
                    " inner join vendas v " +
                    "   on v.controle = vp.controle " +
                    " inner join produtos p " +
                    "   on p.cid = vp.produto " +
                    " inner join cor c " +
                    "   on c.cid = p.cor_cid ";
                string sqlWhere = string.Empty;

                sqlWhere = MontarParametrosSQL(sqlWhere, referencia, "p.referencia");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.fabricante_cid, "p.fabricante_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.fornecedor_cid, "p.fornecedor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.grupo_cid, "p.grupo_cid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by v.data desc limit 1 ");

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dGradeItem();
                        DataRow row = dt.Rows[0];
                        retorno.dataUltimaVenda = RetornarData(row["data"]);
                        retorno.corMaterial = RetornarTexto(row["nome"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Ultima Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoGradeItem ConsultarProdutos(string referencia, dGradeItem gradeItem)
        {
            ColecaoGradeItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select p.cid, c.nome as corMat ";
                string sqlWhere = string.Empty;
                string sqlFrom = " from produtos p " +
                    "   inner join cor c " +
                    "     on c.cid = p.cor_cid ";

                sqlWhere = MontarParametrosSQL(sqlWhere, referencia, "p.referencia");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.fabricante_cid, "p.fabricante_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.fornecedor_cid, "p.fornecedor_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, gradeItem.grupo_cid, "p.grupo_cid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                DataSet ds;
                if (gradeItem.ordem == true)
                    ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by c.nome ");
                else
                    ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGradeItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGradeItem();
                            item.produto_cid = RetornarInteiro(row["cid"]);
                            item.corMaterial = RetornarTexto(row["corMat"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Produtos [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoGradeItem ConsultarItens(int pProdutoCid)
        {
            ColecaoGradeItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select " +
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

                var ds = acessoBanco.ExecutarDS(sqlSelect);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoGradeItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dGradeItem();
                            item.produto_cid = RetornarInteiro(row["produto"]);
                            item.item = RetornarInteiro(row["item"]);
                            item.tamanho = RetornarTexto(row["tamanho"]);
                            item.estoque = RetornarTexto(row["estoque"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.dataEntrada = RetornarData(row["dataEntrada"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Itens [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
