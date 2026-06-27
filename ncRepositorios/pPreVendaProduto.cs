using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pPreVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            ColecaoVendaProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select controle, produto, item, quantidade, codigobarras, descricao, referencia, valor From prevendaproduto";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVendaProduto();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVendaProduto();
                            item.controle = RetornarInteiro(row["controle"]);
                            item.produtoId = RetornarInteiro(row["produto"]);
                            item.itemId = RetornarInteiro(row["item"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.codigobarras = RetornarTexto(row["codigobarras"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar PreVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            ColecaoVendaProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT pv.controle, pv.produto, pv.item, pv.quantidade, pv.codigobarras, pv.descricao, pv.referencia, pv.valor, p.aliquota ";
                string sqlWhere = string.Empty;
                string sqlFrom = " FROM prevendaproduto pv INNER JOIN produtos p ON pv.produto = p.cid ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.controle, "controle");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVendaProduto();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVendaProduto();
                            item.controle = RetornarInteiro(row["controle"]);
                            item.produtoId = RetornarInteiro(row["produto"]);
                            item.itemId = RetornarInteiro(row["item"]);
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.codigobarras = RetornarTexto(row["codigobarras"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.referencia = RetornarTexto(row["referencia"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.aliquota = RetornarTexto(row["aliquota"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar PreVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " prevendaproduto (controle, produto, item, quantidade, codigobarras, descricao, referencia, valor) " +
                    " VALUES (" +
                    PersistirTexto(dados.controle) + "," +
                    PersistirTexto(dados.produtoId) + "," +
                    PersistirTexto(dados.itemId) + "," +
                    PersistirDecimal(dados.quantidade) + "," +
                    PersistirTexto(dados.codigobarras) + "," +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirTexto(dados.referencia) + "," +
                    PersistirDecimal(dados.valor) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE prevendaproduto SET " +
                    " produto = " + PersistirTexto(dados.produtoId) + "," +
                    " item = " + PersistirTexto(dados.itemId) + "," +
                    " quantidade = " + PersistirDecimal(dados.quantidade) + "," +
                    " codigobarras = " + PersistirTexto(dados.codigobarras) + "," +
                    " descricao = " + PersistirTexto(dados.descricao) + "," +
                    " referencia = " + PersistirTexto(dados.referencia) + "," +
                    " valor = " + PersistirDecimal(dados.valor) +
                    " WHERE " +
                    " controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar PreVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM prevendaproduto " +
                    " WHERE controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir PreVenda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
