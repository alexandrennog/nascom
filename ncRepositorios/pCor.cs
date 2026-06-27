using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsCor;

namespace ncPersistencia.nsCor
{
    public class pCor
    {
        public ColecaoCor Listar()
        {
            ColecaoCor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nome, situacao From Cor Order By nome ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoCor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCor();
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
                throw new ExcecaoNascomercio("Erro em Listar Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoCor Consultar(dCor dados)
        {
            ColecaoCor retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, nome, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From Cor ";
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
                        retorno = new ColecaoCor();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dCor();
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
                throw new ExcecaoNascomercio("Erro em Consultar Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dCor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Cor ( nome, situacao ) " +
                    " VALUES (" +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Importar(dCor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " Cor ( cid, nome, situacao ) " +
                    " VALUES (" +
                    PersistirInteiro(dados.cid) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Importar Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dCor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE Cor SET " +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dCor dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM Cor " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Cor [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
