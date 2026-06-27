using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCrediario;

namespace ncPersistencia.nsCrediario
{
    public class pCrediario
    {
        public ColecaoCrediario Listar()
        {
            ColecaoCrediario retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, controle, usuarioId, clienteId, " +
                    "parcelas, valortotal, valorpago, saldodevedor, dataVenda From crediario";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCrediario();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCrediario();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.controle = RetornarInteiro(row["controle"]);
                            item.ValorTotal = PersistirDecimal(row["valortotal"]);
                            item.ValorTotal = PersistirDecimal(row["valorpago"]);
                            item.ValorTotal = PersistirDecimal(row["saldodevedor"]);
                            item.usuarioId = RetornarInteiro(row["usuarioId"]);
                            item.clienteId = RetornarInteiro(row["clienteId"]);
                            item.Parcelas = PersistirInteiro(row["parcelas"]);
                            item.DataVenda = RetornarData(row["dataVenda"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Crediário [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ConsultarMax()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select MAX(controle) as controle";
                string sqlFrom = " From crediario ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                            retorno = row["controle"] == DBNull.Value ? 0 : RetornarInteiro(row["controle"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em ConsultarMax Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCrediario Consultar(dCrediario dados)
        {
            ColecaoCrediario retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, controle, usuarioId, clienteId, " +
                    "parcelas, valortotal, valorpago, saldodevedor, dataVenda ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From crediario ";
                if (dados.cid != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                if (dados.controle != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.controle, "controle");
                if (dados.usuarioId != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.usuarioId, "usuarioId");
                if (dados.clienteId != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.clienteId, "clienteId");
                if (dados.SaldoDevedor > 0.001m)
                {
                    if (!sqlWhere.Equals(string.Empty))
                        sqlWhere += " AND saldodevedor > 0.001 ";
                    else
                        sqlWhere = " saldodevedor > 0.001 ";
                }
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by year(dataVenda), month(dataVenda)");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCrediario();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCrediario();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.controle = RetornarInteiro(row["controle"]);
                            item.usuarioId = RetornarInteiro(row["usuarioId"]);
                            item.clienteId = RetornarInteiro(row["clienteId"]);
                            item.Parcelas = RetornarInteiro(row["parcelas"]);
                            item.ValorTotal = RetornarDecimal(row["valortotal"]);
                            item.ValorPago = RetornarDecimal(row["valorpago"]);
                            item.SaldoDevedor = RetornarDecimal(row["saldodevedor"]);
                            item.DataVenda = RetornarData(row["dataVenda"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Crediario[" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCrediario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " crediario (controle, usuarioId, clienteId, observacao, " +
                    "parcelas, valortotal, valorpago, saldodevedor, dataVenda, loja_cid, terminal) " +
                    " VALUES (" +
                    PersistirTexto(dados.controle) + "," +
                    PersistirTexto(dados.usuarioId) + "," +
                    PersistirTexto(dados.clienteId) + "," +
                    PersistirTexto(dados.NotaFiscal) + "," +
                    PersistirInteiro(dados.Parcelas) + "," +
                    PersistirDecimal(dados.ValorTotal) + "," +
                    PersistirDecimal(dados.ValorPago) + "," +
                    PersistirDecimal(dados.SaldoDevedor) + "," +
                    PersistirData(dados.DataVenda) + "," +
                    PersistirInteiro(dados.LojaId) + "," +
                    PersistirTexto(dados.Terminal) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCrediario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE crediario SET " +
                    " controle = " + PersistirInteiro(dados.controle) + "," +
                    " usuarioId = " + PersistirTexto(dados.usuarioId) + "," +
                    " clienteId = " + PersistirTexto(dados.clienteId) + "," +
                    " parcelas = " + PersistirInteiro(dados.Parcelas) + "," +
                    " valortotal = " + PersistirDecimal(dados.ValorTotal) + "," +
                    " valorpago = " + PersistirDecimal(dados.ValorPago) + "," +
                    " dataVenda = " + PersistirData(dados.DataVenda) + "," +
                    " saldodevedor = " + PersistirDecimal(dados.SaldoDevedor) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int AlterarControle(dCrediario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE crediario SET " +
                    " controle = " + PersistirInteiro(dados.controle) +
                    " WHERE " +
                    " controle = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCrediario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM crediario " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirParcelas(dCrediario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM parcelas " +
                    " WHERE crediarioid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
