using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsProduto;

namespace ncPersistencia.nsProduto
{
    public class pProdutoItem
    {
        public ColecaoProdutoItem Listar()
        {
            ColecaoProdutoItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select produtos_cid, item, caracteristicas_cid, valor From produtoitem ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoItem();
                            item.produtos_cid = RetornarInteiro(row["produtos_cid"]);
                            item.item = RetornarInteiro(row["item"]);
                            item.caracteristicas_cid = RetornarInteiro(row["caracteristicas_cid"]);
                            item.valor = RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProdutoItem Consultar(dProdutoItem dados)
        {
            ColecaoProdutoItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select pi.produtos_cid, pi.item, pi.caracteristicas_cid, pi.valor, c.nome, c.codigo ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From produtoitem pi Inner Join caracteristicas c " +
                    " On c.cid = pi.caracteristicas_cid ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.produtos_cid, "produtos_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.item, "item");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.caracteristicas_cid, "caracteristicas_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valor, "valor");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by pi.produtos_cid, pi.item ");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoItem();
                            item.produtos_cid = RetornarInteiro(row["produtos_cid"]);
                            item.item = RetornarInteiro(row["item"]);
                            item.caracteristicas_cid = RetornarInteiro(row["caracteristicas_cid"]);
                            item.valor = RetornarTexto(row["valor"]);
                            item.caracteristicas_nome = RetornarTexto(row["nome"]);
                            item.caracteristicas_codigo = RetornarTexto(row["codigo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProdutoItem ConsultarProdutoItem(string descricao, string codigoBarras, string referencia, bool emEstoque)
        {
            ColecaoProdutoItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select p.cid as 'produtos_cid', p.descricao as 'descricao', p.referencia as 'referencia', p.valorVenda as 'valorVenda', " +
                    " pi.valor as 'valor', pi.item as 'item', pi2.valor as 'estoque', pi3.valor as 'tamanho', co.nome as 'cor' ";
                string sqlWhere = " c.codigo = 'codigoBarras' and c2.codigo = 'estoque' and c3.codigo = 'tamanho'";
                string sqlFrom = " from produtos p " +
                    " inner join cor co on co.cid = p.cor_cid " +
                    " inner join produtoitem pi on pi.produtos_cid = p.cid " +
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " +
                    " inner join produtoitem pi2 on pi2.produtos_cid = p.cid and pi2.item = pi.item " +
                    " inner join caracteristicas c2 on c2.cid = pi2.caracteristicas_cid " +
                    " inner join produtoitem pi3  on pi3.produtos_cid = p.cid and pi3.item = pi.item " +
                    " inner join caracteristicas c3  on c3.cid = pi3.caracteristicas_cid ";

                if (emEstoque)
                    sqlWhere += " and pi2.valor > 0 ";

                sqlWhere = MontarParametrosSQL(sqlWhere, descricao, "p.descricao", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, referencia, "p.referencia", true);
                sqlWhere = MontarParametrosSQL(sqlWhere, codigoBarras, "pi.valor");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by p.descricao, p.referencia, co.nome, pi3.valor");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoItem();
                            item.produtos_descricao = RetornarTexto(row["descricao"]);
                            item.produtos_estoque = RetornarTexto(row["estoque"]);
                            item.produtos_cid = RetornarInteiro(row["produtos_cid"]);
                            item.item = RetornarInteiro(row["item"]);
                            item.valor = RetornarTexto(row["valor"]);
                            item.Produtos_ValorVenda = RetornarDecimal(row["ValorVenda"]);
                            item.Produtos_Referencia = RetornarTexto(row["Referencia"]);
                            item.Produtos_Tamanho = RetornarTexto(row["tamanho"]);
                            item.Produtos_Cor = RetornarTexto(row["cor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public decimal ConsultarEstoque(string codigoBarras)
        {
            decimal retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select pi1.valor " +
                    " from produtoitem pi1 " +
                    " inner join produtoitem pi2 " +
                    " on pi2.item = pi1.item " +
                    " and pi2.produtos_cid = pi1.produtos_cid " +
                    " inner join caracteristicas c1 " +
                    " on c1.cid = pi1.caracteristicas_cid " +
                    " and c1.codigo = 'estoque' " +
                    " where pi2.valor = '" + codigoBarras + "' ";

                var ds = acessoBanco.ExecutarDS(sqlSelect);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        retorno = RetornarDecimal(row["valor"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Consultar Estoque [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProdutoItem ConsultarQuantidadeItem(int produto_cid)
        {
            ColecaoProdutoItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select distinct pi.produtos_cid, pi.item From produtoitem pi " +
                    " WHERE produtos_cid = " + produto_cid;
                var ds = acessoBanco.ExecutarDS(sqlSelect);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoItem();
                            item.produtos_cid = RetornarInteiro(row["produtos_cid"]);
                            item.item = RetornarInteiro(row["item"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int? ConsultarUltimoItem(int produto_cid)
        {
            int? retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select max(pi.item) as item from produtoitem pi " +
                    " where pi.produtos_cid = " +
                    PersistirInteiro(produto_cid);
                var ds = acessoBanco.ExecutarDS(sqlSelect);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                        retorno = RetornarInteiro(dt.Rows[0]["item"]);
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public string ConsultarUltimoCodigoBarras()
        {
            string retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " select ifnull(max(pi.valor), '10000000000000') as codigoBarras " +
                    " from produtoitem pi " +
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " +
                    " and c.codigo = 'codigoBarras' " +
                    " where convert(ifnull(pi.valor, 0),unsigned) > 10000000000000 ";
                var ds = acessoBanco.ExecutarDS(sqlSelect);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                        retorno = dt.Rows[0]["codigoBarras"].ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dProdutoItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " produtoitem (produtos_cid, item, caracteristicas_cid, valor ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.produtos_cid) + "," +
                    PersistirInteiro(dados.item) + "," +
                    PersistirInteiro(dados.caracteristicas_cid) + "," +
                    PersistirTexto(dados.valor) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dProdutoItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE produtoitem SET " +
                    " valor = " + PersistirTexto(dados.valor) +
                    " WHERE " +
                    " produtos_cid = " + PersistirInteiro(dados.produtos_cid) + " AND " +
                    " item = " + PersistirInteiro(dados.item) + " AND " +
                    " caracteristicas_cid = " + PersistirInteiro(dados.caracteristicas_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dProdutoItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtoitem " +
                    " WHERE " +
                    " produtos_cid = " + PersistirInteiro(dados.produtos_cid) + " AND " +
                    " item = " + PersistirInteiro(dados.item) + " AND " +
                    " caracteristicas_cid = " + PersistirInteiro(dados.caracteristicas_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorProduto(dProdutoItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtoitem " +
                    " WHERE " +
                    " produtos_cid = " + PersistirInteiro(dados.produtos_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
