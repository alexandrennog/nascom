using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCliente;

namespace ncPersistencia.nsCliente
{
    public class pClienteFinanceiro
    {
        public ColecaoClienteFinanceiro Listar()
        {
            ColecaoClienteFinanceiro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select limite, situacaoCrediario, cliente_cid, " +
                    "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes " +
                    " From clientefinanceiro ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteFinanceiro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteFinanceiro();
                            item.limite = RetornarDecimal(row["limite"]);
                            item.situacaoCrediario = RetornarTexto(row["situacaoCrediario"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            item.banco1 = RetornarTexto(row["banco1"]);
                            item.banco2 = RetornarTexto(row["banco2"]);
                            item.agencia1 = RetornarTexto(row["agencia1"]);
                            item.agencia2 = RetornarTexto(row["agencia2"]);
                            item.conta1 = RetornarTexto(row["conta1"]);
                            item.conta2 = RetornarTexto(row["conta2"]);
                            item.gerente1 = RetornarTexto(row["gerente1"]);
                            item.gerente2 = RetornarTexto(row["gerente2"]);
                            item.referencia1 = RetornarTexto(row["referencia1"]);
                            item.referencia2 = RetornarTexto(row["referencia2"]);
                            item.telefone1 = RetornarTexto(row["telefone1"]);
                            item.telefone2 = RetornarTexto(row["telefone2"]);
                            item.ddd1 = RetornarTexto(row["ddd1"]);
                            item.ddd2 = RetornarTexto(row["ddd2"]);
                            item.observacoes = RetornarTexto(row["observacoes"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados)
        {
            ColecaoClienteFinanceiro retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select limite, situacaoCrediario, cliente_cid, " +
                    "banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From clientefinanceiro ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.limite, "limite");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacaoCrediario, "situacaoCrediario");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cliente_cid, "cliente_cid");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoClienteFinanceiro();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dClienteFinanceiro();
                            item.limite = RetornarDecimal(row["limite"]);
                            item.situacaoCrediario = RetornarTexto(row["situacaoCrediario"]);
                            item.cliente_cid = RetornarInteiro(row["cliente_cid"]);
                            item.banco1 = RetornarTexto(row["banco1"]);
                            item.banco2 = RetornarTexto(row["banco2"]);
                            item.agencia1 = RetornarTexto(row["agencia1"]);
                            item.agencia2 = RetornarTexto(row["agencia2"]);
                            item.conta1 = RetornarTexto(row["conta1"]);
                            item.conta2 = RetornarTexto(row["conta2"]);
                            item.gerente1 = RetornarTexto(row["gerente1"]);
                            item.gerente2 = RetornarTexto(row["gerente2"]);
                            item.referencia1 = RetornarTexto(row["referencia1"]);
                            item.referencia2 = RetornarTexto(row["referencia2"]);
                            item.telefone1 = RetornarTexto(row["telefone1"]);
                            item.telefone2 = RetornarTexto(row["telefone2"]);
                            item.ddd1 = RetornarTexto(row["ddd1"]);
                            item.ddd2 = RetornarTexto(row["ddd2"]);
                            item.observacoes = RetornarTexto(row["observacoes"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dClienteFinanceiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " clientefinanceiro (limite, situacaoCrediario, cliente_cid, " +
                    " banco1, banco2, agencia1, agencia2, conta1, conta2, gerente1, gerente2, referencia1, referencia2, ddd1, ddd2, telefone1, telefone2, observacoes) " +
                    " VALUES (" +
                    PersistirDecimal(dados.limite) + "," +
                    PersistirTexto(dados.situacaoCrediario) + "," +
                    PersistirInteiro(dados.cliente_cid) + "," +
                    PersistirTexto(dados.banco1) + "," +
                    PersistirTexto(dados.banco2) + "," +
                    PersistirTexto(dados.agencia1) + "," +
                    PersistirTexto(dados.agencia2) + "," +
                    PersistirTexto(dados.conta1) + "," +
                    PersistirTexto(dados.conta2) + "," +
                    PersistirTexto(dados.gerente1) + "," +
                    PersistirTexto(dados.gerente2) + "," +
                    PersistirTexto(dados.referencia1) + "," +
                    PersistirTexto(dados.referencia2) + "," +
                    PersistirTexto(dados.ddd1) + "," +
                    PersistirTexto(dados.ddd2) + "," +
                    PersistirTexto(dados.telefone1) + "," +
                    PersistirTexto(dados.telefone2) + "," +
                    PersistirTexto(dados.observacoes) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dClienteFinanceiro dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE clientefinanceiro SET " +
                    " limite = " + PersistirDecimal(dados.limite) + "," +
                    " situacaoCrediario = " + PersistirTexto(dados.situacaoCrediario) + "," +
                    " banco1 = " + PersistirTexto(dados.banco1) + "," +
                    " banco2 = " + PersistirTexto(dados.banco2) + "," +
                    " agencia1 = " + PersistirTexto(dados.agencia1) + "," +
                    " agencia2 = " + PersistirTexto(dados.agencia2) + "," +
                    " conta1 = " + PersistirTexto(dados.conta1) + "," +
                    " conta2 = " + PersistirTexto(dados.conta2) + "," +
                    " gerente1 = " + PersistirTexto(dados.gerente1) + "," +
                    " gerente2 = " + PersistirTexto(dados.gerente2) + "," +
                    " referencia1 = " + PersistirTexto(dados.referencia1) + "," +
                    " referencia2 = " + PersistirTexto(dados.referencia2) + "," +
                    " ddd1 = " + PersistirTexto(dados.ddd1) + "," +
                    " ddd2 = " + PersistirTexto(dados.ddd2) + "," +
                    " telefone1 = " + PersistirTexto(dados.telefone1) + "," +
                    " telefone2 = " + PersistirTexto(dados.telefone2) + "," +
                    " observacoes = " + PersistirTexto(dados.observacoes) +
                    " WHERE " +
                    " cliente_cid = " + PersistirInteiro(dados.cliente_cid);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ExcluirPorCliente(int cliente_cid)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM clientefinanceiro " +
                    " WHERE cliente_cid = " + cliente_cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cliente - Financeiro [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
