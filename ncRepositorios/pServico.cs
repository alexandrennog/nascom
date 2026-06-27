using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsServico;

namespace ncPersistencia.nsServico
{
    public class pServico
    {
        public ColecaoServico Listar()
        {
            ColecaoServico retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, valor, situacao From Servico ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoServico();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dServico();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Servico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoServico Consultar(dServico dados)
        {
            ColecaoServico retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, valor, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Servico ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoServico();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dServico();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.valor = RetornarDecimal(row["valor"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Servico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Servico ( nome, valor, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirDecimal(dados.valor) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Servico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Servico SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " valor = " + PersistirDecimal(dados.valor) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Servico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dServico dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Servico " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Servico [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
