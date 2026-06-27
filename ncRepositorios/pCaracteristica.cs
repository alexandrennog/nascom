using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCaracteristica;

namespace ncPersistencia.nsCaracteristica
{
    public class pCaracteristica
    {
        public ColecaoCaracteristica Listar()
        {
            ColecaoCaracteristica retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, situacao, codigo From Caracteristicas Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaracteristica();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaracteristica();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCaracteristica Consultar(dCaracteristica dados)
        {
            ColecaoCaracteristica retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, situacao, codigo ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Caracteristicas ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nome, "nome");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "situacao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By nome");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaracteristica();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaracteristica();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCaracteristica dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Caracteristicas ( nome, situacao, codigo ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirTexto(dados.codigo) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Caracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCaracteristica dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Caracteristicas SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " codigo = " + PersistirTexto(dados.codigo) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Caracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCaracteristica dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Caracteristicas " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Caracteristica [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
