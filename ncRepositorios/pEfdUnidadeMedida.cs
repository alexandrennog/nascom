using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public class pEfdUnidadeMedida
    {
        public ColecaoEfdUnidadeMedida Listar()
        {
            ColecaoEfdUnidadeMedida retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select codigo, descricao From EfdUnidadeMedida Order By descricao ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoEfdUnidadeMedida();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dEfdUnidadeMedida();
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.descricao = RetornarTexto(row["descricao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados)
        {
            dEfdUnidadeMedida retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select codigo, descricao ";
                string sqlFrom = " From EfdUnidadeMedida ";
                string sqlWhere = string.Empty;
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descricao, "descricao");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere + " Order By descricao ");
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new dEfdUnidadeMedida();
                        retorno.codigo = RetornarTexto(dt.Rows[0]["codigo"]);
                        retorno.descricao = RetornarTexto(dt.Rows[0]["descricao"]);
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dEfdUnidadeMedida dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM EfdUnidadeMedida " +
                    " WHERE codigo = " + PersistirTexto(dados.codigo);
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dEfdUnidadeMedida dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " EfdUnidadeMedida ( codigo, descricao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.descricao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dEfdUnidadeMedida dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE EfdUnidadeMedida SET " +
                    " descricao = " + PersistirTexto(dados.descricao) +
                    " WHERE " +
                    " codigo = " + dados.codigo;
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar EfdUnidadeMedida [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
