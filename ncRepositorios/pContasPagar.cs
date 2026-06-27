using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsContasPagar;

namespace ncPersistencia.nsContasPagar
{
    public class pContasPagar
    {
        public ColecaoContasPagar Listar()
        {
            ColecaoContasPagar retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select * From ContasPagar ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoContasPagar();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dContasPagar();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.dataEmissao = RetornarTexto(row["dataEmissao"]);
                            item.dataVencimento = RetornarTexto(row["dataVencimento"]);
                            item.dataPagamento = RetornarTexto(row["dataPagamento"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.fornecedor = RetornarTexto(row["fornecedor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoContasPagar Consultar(dContasPagar dados)
        {
            ColecaoContasPagar retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select * ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From ContasPagar ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descricao, "descricao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valor, "valor");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataEmissao, "dataEmissao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataVencimento, "dataVencimento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.dataPagamento, "dataPagamento");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.fornecedor, "fornecedor");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoContasPagar();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dContasPagar();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.dataEmissao = RetornarTexto(row["dataEmissao"]);
                            item.dataVencimento = RetornarTexto(row["dataVencimento"]);
                            item.dataPagamento = RetornarTexto(row["dataPagamento"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.fornecedor = RetornarTexto(row["fornecedor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dContasPagar dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " ContasPagar ( descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor ) " +
                    " VALUES (" +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirDecimal(dados.valor) + "," +
                    PersistirData(dados.dataEmissao) + "," +
                    PersistirData(dados.dataVencimento) + "," +
                    PersistirData(dados.dataPagamento) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.fornecedor) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dContasPagar dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " ContasPagar ( cid, descricao, valor, dataEmissao, dataVencimento, dataPagamento, situacao, fornecedor ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirTexto(dados.descricao) + "," +
                    PersistirDecimal(dados.valor) + "," +
                    PersistirData(dados.dataEmissao) + "," +
                    PersistirData(dados.dataVencimento) + "," +
                    PersistirData(dados.dataPagamento) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.fornecedor) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dContasPagar dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE ContasPagar SET " +
                    " descricao = " + PersistirTexto(dados.descricao) + "," +
                    " valor = " + PersistirDecimal(dados.valor) + "," +
                    " dataEmissao = " + PersistirData(dados.dataEmissao) + "," +
                    " dataVencimento = " + PersistirData(dados.dataVencimento) + "," +
                    " dataPagamento = " + PersistirData(dados.dataPagamento) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " fornecedor = " + PersistirTexto(dados.fornecedor) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dContasPagar dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM ContasPagar " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir ContasPagar [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
