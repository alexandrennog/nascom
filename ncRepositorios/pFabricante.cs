using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsFabricante;

namespace ncPersistencia.nsFabricante
{
    public class pFabricante
    {
        public ColecaoFabricante Listar()
        {
            ColecaoFabricante retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, situacao From Fabricantes Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoFabricante();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dFabricante();
                            item.cid = RetornarInteiro(row["cid"]);
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
                throw new ExcecaoNascomercio("Erro em Listar Fabricante [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoFabricante Consultar(dFabricante dados)
        {
            ColecaoFabricante retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Fabricantes ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
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
                        retorno = new ColecaoFabricante();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dFabricante();
                            item.cid = RetornarInteiro(row["cid"]);
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
                throw new ExcecaoNascomercio("Erro em Consultar Fabricante [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dFabricante dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Fabricantes ( nome, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Fabricante [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dFabricante dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Fabricantes SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Fabricante [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dFabricante dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Fabricantes " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Fabricante [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
