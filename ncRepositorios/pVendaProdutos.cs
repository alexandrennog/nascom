using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pVendaProduto
    {
        public ColecaoVendaProduto Listar()
        {
            ColecaoVendaProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select controle, produto, quantidade, item, valor From vendasprodutos";
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
                            item.quantidade = RetornarDecimal(row["quantidade"]);
                            item.itemId = RetornarInteiro(row["item"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVendaProduto Consultar(dVendaProduto dados)
        {
            ColecaoVendaProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT controle, produto, v.item, quantidade, pi.valor as codigobarras, descricao, referencia, v.valor ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From vendasprodutos v ";
                sqlFrom += " inner join produtos p on cid = produto ";
                sqlFrom += " inner join produtoitem pi on produtos_cid = produto and v.item = pi.item and caracteristicas_cid =1 ";

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
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoVendaProduto ConsultarTroca(dVendaProduto dados)
        {
            ColecaoVendaProduto retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " SELECT controle, produto, v.item, quantidade, pi.valor as codigobarras, descricao, referencia, v.valor ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From valesprodutos v ";
                sqlFrom += " inner join produtos p on cid = produto ";
                sqlFrom += " inner join produtoitem pi on produtos_cid = produto and v.item = pi.item and caracteristicas_cid =1 ";

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
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar troca [" + ToString() + "] - " + ex.Message);
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
                    " vendasprodutos (controle, produto, quantidade, item, valor) " +
                    " VALUES (" +
                    PersistirInteiro(dados.controle) + "," +
                    PersistirInteiro(dados.produtoId) + "," +
                    PersistirDecimal(dados.quantidade) + "," +
                    PersistirInteiro(dados.itemId) + "," +
                    PersistirDecimal(dados.valor) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirTroca(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " valesprodutos (controle, produto, quantidade, item, valor) " +
                    " VALUES (" +
                    PersistirInteiro(dados.controle) + "," +
                    PersistirInteiro(dados.produtoId) + "," +
                    PersistirDecimal(dados.quantidade) + "," +
                    PersistirInteiro(dados.itemId) + "," +
                    PersistirDecimal(dados.valor) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Troca [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE vendasprodutos SET " +
                    " valor = " + PersistirDecimal(dados.valor) + "," +
                    " quantidade = " + PersistirDecimal(dados.quantidade) +
                    " WHERE " +
                    " controle = " + PersistirInteiro(dados.controle) +
                    " and produto = " + PersistirInteiro(dados.produtoId) +
                    " and item = " + PersistirInteiro(dados.itemId);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dVendaProduto dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM vendasprodutos " +
                    " WHERE " +
                    " controle = " + PersistirInteiro(dados.controle) +
                    " and produto = " + PersistirInteiro(dados.produtoId) +
                    " and item = " + PersistirInteiro(dados.itemId);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirControle(int controle)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM vendasprodutos " +
                    " WHERE " +
                    " controle = " + PersistirInteiro(controle);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirControleTroca(int controle)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM valesprodutos " +
                    " WHERE " +
                    " controle = " + PersistirInteiro(controle);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
