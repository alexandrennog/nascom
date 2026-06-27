using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsProduto;

namespace ncPersistencia.nsProduto
{
    public class pProdutoTipoCaracteristica
    {
        public ColecaoProdutoTipoCaracteristica Listar()
        {
            ColecaoProdutoTipoCaracteristica retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome, c.codigo " +
                    " From produtotipocaracteristica ptc " +
                    " inner join caracteristicas c on c.cid = ptc.caracteristica_cid ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoTipoCaracteristica();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoTipoCaracteristica();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.produtoTipo_cid = RetornarInteiro(row["produtoTipo_cid"]);
                            item.caracteristica_cid = RetornarInteiro(row["caracteristica_cid"]);
                            item.caracteristica_nome = RetornarTexto(row["nome"]);
                            item.caracteristica_codigo = RetornarTexto(row["codigo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProdutoTipoCaracteristica ConsultarPorProdutoTipo(int produtoTipo_cid)
        {
            ColecaoProdutoTipoCaracteristica retorno = null;
            try
            {
                var dados = new dProdutoTipoCaracteristica();
                dados.produtoTipo_cid = produtoTipo_cid;
                retorno = Consultar(dados);
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoProdutoTipoCaracteristica Consultar(dProdutoTipoCaracteristica dados)
        {
            ColecaoProdutoTipoCaracteristica retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome, c.codigo, " +
                    " (select count(*) from caracteristicaitem where caracteristicas_cid = ptc.caracteristica_cid) as quantidade ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From produtotipocaracteristica ptc " +
                    " inner join caracteristicas c on c.cid = ptc.caracteristica_cid ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.produtoTipo_cid, "produtoTipo_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.caracteristica_cid, "caracteristica_cid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by c.nome ");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoTipoCaracteristica();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoTipoCaracteristica();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.produtoTipo_cid = RetornarInteiro(row["produtoTipo_cid"]);
                            item.caracteristica_cid = RetornarInteiro(row["caracteristica_cid"]);
                            item.caracteristica_nome = RetornarTexto(row["nome"]);
                            item.caracteristica_codigo = RetornarTexto(row["codigo"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dProdutoTipoCaracteristica dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " produtotipocaracteristica (produtoTipo_cid, caracteristica_cid ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.produtoTipo_cid) + "," +
                    PersistirInteiro(dados.caracteristica_cid) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorProdutoTipo(int produtoTipo_cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtotipocaracteristica " +
                    " WHERE " +
                    " produtoTipo_cid = " + PersistirInteiro(produtoTipo_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorCaracteristica(int caracteristica_cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtotipocaracteristica " +
                    " WHERE " +
                    " caracteristica_cid = " + PersistirInteiro(caracteristica_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(int cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM produtotipocaracteristica " +
                    " WHERE " +
                    " cid = " + PersistirInteiro(cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
