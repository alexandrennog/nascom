using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsVenda;

namespace ncPersistencia.nsVenda
{
    public class pPreVenda
    {
        public ColecaoVenda Listar()
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select controle, usuarioId, clienteId, data, " +
                    "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, " +
                    "parcelas, desconto, condicao, troca, vale, defeito, total, Original From prevendas";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = RetornarInteiro(row["controle"]);
                            item.usuarioId = RetornarInteiro(row["usuarioId"]);
                            item.clienteId = RetornarInteiro(row["clienteId"]);
                            item.Data = RetornarData(row["data"]);
                            item.Dinheiro = RetornarDecimal(row["dinheiro"]);
                            item.Pix = RetornarDecimal(row["Original"]);
                            item.Cheque = RetornarDecimal(row["cheque"]);
                            item.ChequePre = RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = RetornarDecimal(row["cartaodedito"]);
                            item.CartaoCredito = RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = RetornarDecimal(row["crediario"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Parcelas = RetornarInteiro(row["parcelas"]);
                            item.Desconto = RetornarDecimal(row["desconto"]);
                            item.Condicao = RetornarInteiro(row["condicao"]);
                            item.Troca = RetornarDecimal(row["troca"]);
                            item.Vale = RetornarDecimal(row["vale"]);
                            item.Defeito = RetornarDecimal(row["defeito"]);
                            item.Total = RetornarDecimal(row["total"]);
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

        public ColecaoVenda Consultar(dVenda dados)
        {
            ColecaoVenda retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select controle, usuarioId, clienteId, data, vendedor, " +
                    "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, " +
                    "parcelas, desconto, condicao, troca, vale, defeito, total, vendedor, ordemservico, Original ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From prevendas ";

                sqlWhere = MontarParametrosSQL(sqlWhere, dados.controle, "controle");

                if (dados.Terminal != "")
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.Terminal, "terminal");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoVenda();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dVenda();
                            item.controle = RetornarInteiro(row["controle"]);
                            item.usuarioId = RetornarInteiro(row["usuarioId"]);
                            item.clienteId = RetornarInteiro(row["clienteId"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.Data = RetornarData(row["data"]);
                            item.Dinheiro = RetornarDecimal(row["dinheiro"]);
                            item.Pix = RetornarDecimal(row["Original"]);
                            item.Cheque = RetornarDecimal(row["cheque"]);
                            item.ChequePre = RetornarDecimal(row["chequepre"]);
                            item.CartaoDebito = RetornarDecimal(row["cartaodebito"]);
                            item.CartaoCredito = RetornarDecimal(row["cartaocredito"]);
                            item.Crediario = RetornarDecimal(row["crediario"]);
                            item.Terminal = RetornarTexto(row["terminal"]);
                            item.Parcelas = RetornarInteiro(row["parcelas"]);
                            item.Desconto = RetornarDecimal(row["desconto"]);
                            item.Condicao = RetornarInteiro(row["condicao"]);
                            item.Troca = RetornarDecimal(row["troca"]);
                            item.Vale = RetornarDecimal(row["vale"]);
                            item.Defeito = RetornarDecimal(row["defeito"]);
                            item.Total = RetornarDecimal(row["total"]);
                            item.Vendedor = RetornarTexto(row["vendedor"]);
                            item.ordemServicoId = RetornarTexto(row["ordemservico"]);
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

        public int ConsultarMax()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select MAX(controle) as controle";
                string sqlFrom = " From prevendas ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            retorno = row["controle"] == DBNull.Value ? 0 : RetornarInteiro(row["controle"]);
                        }
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

        public int Incluir(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " prevendas (controle, usuarioId, clienteId, data, " +
                    "dinheiro, cheque, chequepre, cartaodebito, cartaocredito, crediario, terminal, ordemServico, " +
                    "parcelas, desconto, condicao, troca, vale, defeito, total, Original) " +
                    " VALUES (" +
                    PersistirInteiro(dados.controle) + "," +
                    PersistirInteiro(dados.usuarioId) + "," +
                    PersistirInteiro(dados.clienteId) + "," +
                    PersistirData(dados.Data) + "," +
                    PersistirDecimal(dados.Dinheiro) + "," +
                    PersistirDecimal(dados.Cheque) + "," +
                    PersistirDecimal(dados.ChequePre) + "," +
                    PersistirDecimal(dados.CartaoDebito) + "," +
                    PersistirDecimal(dados.CartaoCredito) + "," +
                    PersistirDecimal(dados.Crediario) + "," +
                    PersistirTexto(dados.Terminal) + "," +
                    PersistirTexto(dados.ordemServicoId) + "," +
                    PersistirInteiro(dados.Parcelas) + "," +
                    PersistirDecimal(dados.Desconto) + "," +
                    PersistirInteiro(dados.Condicao) + "," +
                    PersistirDecimal(dados.Troca) + "," +
                    PersistirDecimal(dados.Vale) + "," +
                    PersistirDecimal(dados.Defeito) + "," +
                    PersistirDecimal(dados.Total) + "," +
                    PersistirDecimal(dados.Pix) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE prevendas SET " +
                    " usuarioId = " + PersistirInteiro(dados.usuarioId) + "," +
                    " clienteId = " + PersistirInteiro(dados.clienteId) + "," +
                    " data = " + PersistirData(dados.Data) + "," +
                    " dinheiro = " + PersistirDecimal(dados.Dinheiro) + "," +
                    " cheque = " + PersistirDecimal(dados.Cheque) + "," +
                    " chequepre = " + PersistirDecimal(dados.ChequePre) + "," +
                    " cartaodebito = " + PersistirDecimal(dados.CartaoDebito) + "," +
                    " cartaocredito = " + PersistirDecimal(dados.CartaoCredito) + "," +
                    " crediario = " + PersistirDecimal(dados.Crediario) + "," +
                    " terminal = " + PersistirTexto(dados.Terminal) + "," +
                    " ordemservico = " + PersistirTexto(dados.ordemServicoId) + "," +
                    " parcelas = " + PersistirInteiro(dados.Parcelas) + "," +
                    " desconto = " + PersistirDecimal(dados.Desconto) + "," +
                    " condicao = " + PersistirInteiro(dados.Condicao) + "," +
                    " troca = " + PersistirDecimal(dados.Troca) + "," +
                    " vale = " + PersistirDecimal(dados.Vale) + "," +
                    " defeito = " + PersistirDecimal(dados.Defeito) + "," +
                    " vendedor = " + PersistirTexto(dados.Vendedor) + "," +
                    " Original = " + PersistirDecimal(dados.Pix) + "," +
                    " total = " + PersistirDecimal(dados.Total) +
                    " WHERE " +
                    " controle = " + dados.controle.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Venda [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dVenda dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM prevendas " +
                    " WHERE controle = " + dados.controle.ToString();
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
