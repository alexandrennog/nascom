using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;

namespace ncPersistencia.nsEstado
{
    public class pEstado
    {
        public ColecaoEstado Listar()
        {
            ColecaoEstado retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, sigla, nome, situacao From Estados Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoEstado();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dEstado();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.sigla = RetornarTexto(row["sigla"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Estado [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoEstado Consultar(dEstado dados)
        {
            ColecaoEstado retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, sigla, nome, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Estados ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.sigla, "sigla");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By nome");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoEstado();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dEstado();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.sigla = RetornarTexto(row["sigla"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Estado [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEstado dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Estados ( sigla, nome, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.sigla) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Estado [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEstado dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Estados SET " +
                    " sigla = " + PersistirTexto(dados.sigla) + "," +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Estado [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dEstado dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Estados " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Estado [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
