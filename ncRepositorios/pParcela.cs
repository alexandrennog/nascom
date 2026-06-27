using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCrediario;

namespace ncPersistencia.nsCrediario
{
    public class pParcela
    {
        public ColecaoParcelas Listar()
        {
            ColecaoParcelas retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, crediarioid, codigoBarras, " +
                    "dataemissao, datavencimento, valor, valorreceber, valorpago, situacao, observacao From Parcelas";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParcelas();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParcelas();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.crediarioId = RetornarInteiro(row["crediarioid"]);
                            item.dataEmissao = RetornarData(row["dataemissao"]);
                            item.dataVecimento = RetornarData(row["datavencimento"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.valorReceber = RetornarDecimal(row["valorreceber"]);
                            item.valorPago = RetornarDecimal(row["valorpago"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.observacao = RetornarTexto(row["observacao"]);
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

        public ColecaoParcelas Consultar(dParcelas dados)
        {
            ColecaoParcelas retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, crediarioid, codigoBarras, " +
                    "dataemissao, datavencimento, valor, valorreceber, valorpago, situacao, datapagamento, observacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From parcelas ";

                if (dados.cid != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");

                if (dados.crediarioId != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.crediarioId, "crediarioid");

                if (dados.codigoBarras != null)
                {
                    if (dados.codigoBarras.Trim() != "")
                        sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigoBarras, "codigoBarras");
                }

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParcelas();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParcelas();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.crediarioId = RetornarInteiro(row["crediarioid"]);
                            item.dataEmissao = RetornarData(row["dataemissao"]);
                            item.dataVecimento = RetornarData(row["datavencimento"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.valorReceber = RetornarDecimal(row["valorreceber"]);
                            item.valorPago = RetornarDecimal(row["valorpago"]);
                            item.dataPagamento = RetornarData(row["datapagamento"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.observacao = RetornarTexto(row["observacao"]);
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

        public ColecaoParcelas ConsultarParcelasCliente(int codCliente)
        {
            ColecaoParcelas retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select parcelas.cid, parcelas.crediarioid, parcelas.codigoBarras, " +
                    "parcelas.dataemissao, parcelas.datavencimento, parcelas.valor," +
                    "parcelas.valorreceber, parcelas.valorpago, parcelas.situacao, parcelas.datapagamento, parcelas.observacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From parcelas inner join crediario on parcelas.crediarioid = crediario.cid";

                if (codCliente != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, codCliente, "clienteid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParcelas();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParcelas();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.crediarioId = RetornarInteiro(row["crediarioid"]);
                            item.dataEmissao = RetornarData(row["dataemissao"]);
                            item.dataVecimento = RetornarData(row["datavencimento"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.valorReceber = RetornarDecimal(row["valorreceber"]);
                            item.valorPago = RetornarDecimal(row["valorpago"]);
                            item.dataPagamento = RetornarData(row["datapagamento"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.observacao = RetornarTexto(row["observacao"]);
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

        public ColecaoParcelas ConsultarParcelasVencidas(int codCliente)
        {
            ColecaoParcelas retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select parcelas.cid, parcelas.crediarioid, parcelas.codigoBarras, " +
                    "parcelas.dataemissao, parcelas.datavencimento, parcelas.valor," +
                    "parcelas.valorreceber, parcelas.valorpago, parcelas.situacao, parcelas.datapagamento ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From parcelas inner join crediario on parcelas.crediarioid = crediario.cid";

                if (codCliente != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, codCliente, "clienteid");

                if (codCliente != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, " datavencimento < date(now()) ");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " order by parcelas.datavencimento ");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParcelas();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParcelas();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigoBarras = RetornarTexto(row["codigoBarras"]);
                            item.crediarioId = RetornarInteiro(row["crediarioid"]);
                            item.dataEmissao = RetornarData(row["dataemissao"]);
                            item.dataVecimento = RetornarData(row["datavencimento"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.valorReceber = RetornarDecimal(row["valorreceber"]);
                            item.valorPago = RetornarDecimal(row["valorpago"]);
                            item.dataPagamento = RetornarData(row["datapagamento"]);
                            item.situacao = RetornarTexto(row["situacao"]);
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

        public int Incluir(dParcelas dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " parcelas (crediarioid, codigoBarras, " +
                    "dataemissao, datavencimento, valor, valorreceber, valorpago, datapagamento, situacao, observacao) " +
                    " VALUES (" +
                    PersistirInteiro(dados.crediarioId) + "," +
                    PersistirTexto(dados.codigoBarras) + "," +
                    PersistirData(dados.dataEmissao) + "," +
                    PersistirData(dados.dataVecimento) + "," +
                    PersistirDecimal(dados.valor) + "," +
                    PersistirDecimal(dados.valorReceber) + "," +
                    PersistirDecimal(dados.valorPago) + "," +
                    PersistirData(dados.dataPagamento) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.observacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Crediario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoParcelas ConsultarPagamentos(dParcelas dados)
        {
            ColecaoParcelas retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select parcelasid, valorpago, datapagamento, diasAtraso ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From parcelaspag ";

                if (dados.crediarioId != 0)
                    sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "parcelasid");

                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;

                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoParcelas();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dParcelas();
                            item.cid = RetornarInteiro(row["parcelasid"]);
                            item.valorPago = RetornarDecimal(row["valorpago"]);
                            item.dataPagamento = RetornarData(row["datapagamento"]);
                            item.diasAtraso = RetornarInteiro(row["diasAtraso"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Pagamentos[" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int IncluirPagamento(dParcelas dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " parcelaspag (parcelasid, valorpago, datapagamento, diasAtraso) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirDecimal(dados.valorPago) + "," +
                    PersistirData(dados.dataPagamento) + "," +
                    PersistirInteiro(dados.diasAtraso) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Pagamento [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Corrigir()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = "update parcelas set valorreceber = 0.0 where situacao = '01' and valorreceber <= valorpago;";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em corrigir parcelas [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dParcelas dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE parcelas SET " +
                    " codigoBarras = " + PersistirTexto(dados.codigoBarras) + "," +
                    " crediarioId = " + PersistirInteiro(dados.crediarioId) + "," +
                    " dataEmissao = " + PersistirData(dados.dataEmissao) + "," +
                    " dataVencimento = " + PersistirData(dados.dataVecimento) + "," +
                    " valor = " + PersistirDecimal(dados.valor) + "," +
                    " valorreceber = " + PersistirDecimal(dados.valorReceber) + "," +
                    " valorpago = " + PersistirDecimal(dados.valorPago) + "," +
                    " dataPagamento = " + PersistirData(dados.dataPagamento) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " observacao = " + PersistirTexto(dados.observacao) +
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

        public int Excluir(dParcelas dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM parcelas " +
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
    }
}
