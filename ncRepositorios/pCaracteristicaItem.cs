using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCaracteristica;

namespace ncPersistencia.nsCaracteristica
{
    public class pCaracteristicaItem
    {
        public ColecaoCaracteristicaItem Listar()
        {
            ColecaoCaracteristicaItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, caracteristicas_cid, valor From caracteristicaitem ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaracteristicaItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaracteristicaItem();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.caracteristicas_cid = RetornarInteiro(row["caracteristicas_cid"]);
                            item.valor = RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCaracteristicaItem Consultar(dCaracteristicaItem dados)
        {
            ColecaoCaracteristicaItem retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, caracteristicas_cid, valor ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From caracteristicaitem ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.caracteristicas_cid, "caracteristicas_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.valor, "valor");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCaracteristicaItem();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCaracteristicaItem();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.caracteristicas_cid = RetornarInteiro(row["caracteristicas_cid"]);
                            item.valor = RetornarTexto(row["valor"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCaracteristicaItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " caracteristicaitem ( caracteristicas_cid, valor ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.caracteristicas_cid) + "," +
                    PersistirTexto(dados.valor) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCaracteristicaItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE caracteristicaitem SET " +
                    " caracteristicas_cid = " + PersistirInteiro(dados.caracteristicas_cid) + "," +
                    " valor = " + PersistirTexto(dados.valor) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCaracteristicaItem dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM caracteristicaitem " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
