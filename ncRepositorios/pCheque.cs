using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCheques;

namespace ncPersistencia.nsCheques
{
    public class pCheques
    {
        public ColecaoCheques Listar()
        {
            ColecaoCheques retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select * From cheques ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCheques();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCheques();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.emitente = RetornarTexto(row["emitente"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.dataEmissao = RetornarTexto(row["dataEmissao"]);
                            item.dataDeposito = RetornarTexto(row["dataDeposito"]);
                            item.banco = RetornarTexto(row["banco"]);
                            item.agencia = RetornarTexto(row["agencia"]);
                            item.conta = RetornarTexto(row["conta"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.baixado = RetornarTexto(row["baixado"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCheques Consultar(dCheques dados)
        {
            ColecaoCheques retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select * ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From cheques ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.emitente, "emitente");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valor, "valor");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEmissao, "dataEmissao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataDeposito, "dataDeposito");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.banco, "banco");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.agencia, "agencia");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.conta, "conta");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.numero, "numero");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.baixado, "baixado");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCheques();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCheques();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.emitente = RetornarTexto(row["emitente"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.dataEmissao = RetornarTexto(row["dataEmissao"]);
                            item.dataDeposito = RetornarTexto(row["dataDeposito"]);
                            item.banco = RetornarTexto(row["banco"]);
                            item.agencia = RetornarTexto(row["agencia"]);
                            item.conta = RetornarTexto(row["conta"]);
                            item.numero = RetornarTexto(row["numero"]);
                            item.baixado = RetornarTexto(row["baixado"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCheques dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " cheques ( emitente, valor, dataEmissao, dataDeposito, banco, agencia, conta, numero, baixado ) " +
                    " VALUES (" +
                    PersistirTexto(dados.emitente) + "," +
                    PersistirDecimal(dados.valor) + "," +
                    PersistirData(dados.dataEmissao) + "," +
                    PersistirData(dados.dataDeposito) + "," +
                    PersistirTexto(dados.banco) + "," +
                    PersistirTexto(dados.agencia) + "," +
                    PersistirTexto(dados.conta) + "," +
                    PersistirTexto(dados.numero) + "," +
                    PersistirTexto(dados.baixado) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCheques dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE cheques SET " +
                    " emitente = " + PersistirTexto(dados.emitente) + "," +
                    " valor = " + PersistirDecimal(dados.valor) + "," +
                    " dataEmissao = " + PersistirData(dados.dataEmissao) + "," +
                    " dataDeposito = " + PersistirData(dados.dataDeposito) + "," +
                    " banco = " + PersistirTexto(dados.banco) + "," +
                    " agencia = " + PersistirTexto(dados.agencia) + "," +
                    " conta = " + PersistirTexto(dados.conta) + "," +
                    " numero = " + PersistirTexto(dados.numero) + "," +
                    " baixado = " + PersistirTexto(dados.baixado) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Baixar()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE cheques SET baixado='Sim' WHERE dataDeposito < date(now()) ";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Baixar Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCheques dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM cheques " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cheques [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
