using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsOrdemServico;

namespace ncPersistencia.nsOrdemServico
{
    public class pOrdemServico
    {
        public ColecaoOrdemServico Listar()
        {
            ColecaoOrdemServico retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao  From OrdemServico ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoOrdemServico();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dOrdemServico();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.observacoes = RetornarTexto(row["observacoes"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar OS [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoOrdemServico Consultar(dOrdemServico dados)
        {
            ColecaoOrdemServico retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From OrdemServico ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoOrdemServico();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dOrdemServico();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.clienteid = RetornarInteiro(row["clienteid"]);
                            item.veiculoid = RetornarInteiro(row["veiculoid"]);
                            item.observacoes = RetornarTexto(row["observacoes"]);
                            item.emissao = RetornarTexto(row["emissao"]);
                            item.vendedor = RetornarTexto(row["vendedor"]);
                            item.loja = RetornarTexto(row["loja"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar OS [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int ConsultarMax()
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select MAX(cid) as cid";
                string sqlFrom = " From ordemservico ";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                            retorno = row["cid"] == DBNull.Value ? 0 : RetornarInteiro(row["cid"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em ConsultarMax ordemservico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dOrdemServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " OrdemServico ( clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.clienteid) + "," +
                    PersistirInteiro(dados.veiculoid) + "," +
                    PersistirTexto(dados.observacoes) + "," +
                    PersistirDataHora(dados.emissao) + "," +
                    PersistirTexto(dados.vendedor) + "," +
                    PersistirTexto(dados.loja) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir OS [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dOrdemServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE OrdemServico SET " +
                    " clienteid = " + PersistirInteiro(dados.clienteid) + "," +
                    " veiculoid = " + PersistirInteiro(dados.veiculoid) + "," +
                    " observacoes = " + PersistirTexto(dados.observacoes) + "," +
                    " vendedor = " + PersistirTexto(dados.vendedor) + "," +
                    " loja = " + PersistirTexto(dados.loja) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar OS [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dOrdemServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM OrdemServico " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir OS [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
