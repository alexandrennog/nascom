using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsProdutoEtiqueta;

namespace ncPersistencia.nsProdutoEtiqueta
{
    public class pProdutoEtiqueta
    {
        public ColecaoProdutoEtiqueta Listar(string dataDe, string dataAte, int ImprimeTodos)
        {
            ColecaoProdutoEtiqueta retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select data, impressao, produto_cid, produtoItem_codigoBarras, quantidade, " +
                    " usuario_cid, usuario_nomeCompleto, referencia, c.nome as cor";
                string sqlWhere = string.Empty;
                string sqlFrom = " From LogEstoque le " +
                    " inner join produtos p on p.cid = le.produto_cid " +
                    " inner join cor c on p.cor_cid = c.cid " +
                    " inner join produtoitem pi on pi.valor = le.produtoItem_codigoBarras ";

                if (!string.IsNullOrEmpty(dataDe))
                {
                    if (!sqlWhere.Trim().Equals(string.Empty))
                        sqlWhere = sqlWhere + " AND ";
                    sqlWhere = sqlWhere + " data >= '" + dataDe + "'";
                }

                if (!string.IsNullOrEmpty(dataAte))
                {
                    if (!sqlWhere.Trim().Equals(string.Empty))
                        sqlWhere = sqlWhere + " AND ";
                    sqlWhere = sqlWhere + " data <= '" + dataAte + "'";
                }

                if (ImprimeTodos == 0)
                {
                    if (!sqlWhere.Trim().Equals(string.Empty))
                        sqlWhere = sqlWhere + " AND ";
                    sqlWhere = sqlWhere + " impressao is null";
                }

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoProdutoEtiqueta();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dProdutoEtiqueta();
                            item.data = RetornarData(row["data"]);
                            item.impressao = RetornarTexto(row["impressao"]);
                            item.produto_cid = RetornarInteiro(row["produto_cid"]);
                            item.produtoItem_codigoBarras = RetornarTexto(row["produtoItem_codigoBarras"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.usuario_cid = RetornarInteiro(row["usuario_cid"]);
                            item.usuario_nomeCompleto = RetornarTexto(row["usuario_nomeCompleto"]);
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.cor = RetornarTexto(row["cor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(string data, string produto, string codigoBarras)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE logEstoque SET " +
                    " impressao = 'S' " +
                    " WHERE " +
                    " produto_cid = " + PersistirInteiro(Convert.ToInt32(produto)) + " AND " +
                    " produtoItem_codigoBarras = " + PersistirTexto(codigoBarras);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Produto [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
