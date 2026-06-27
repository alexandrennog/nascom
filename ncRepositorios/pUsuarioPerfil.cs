using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using static ncNComum.nsFuncoes.cFuncoes;
using nsUsuarioPerfil;

namespace ncPersistencia.nsUsuarioPerfil
{
    public class pUsuarioPerfil
    {
        public ColecaoUsuarioPerfil Listar()
        {
            ColecaoUsuarioPerfil retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, codigo, nome, situacao From usuarioperfil ";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoUsuarioPerfil();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dUsuarioPerfil();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.codigo = RetornarTexto(row["codigo"]);
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
                throw new ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados)
        {
            ColecaoUsuarioPerfil retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select cid, codigo, nome, situacao ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From usuarioperfil ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.codigo, "codigo");
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
                        retorno = new ColecaoUsuarioPerfil();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dUsuarioPerfil();
                            item.cid = Convert.ToInt32(row["cid"]);
                            item.nome = RetornarTexto(row["nome"]);
                            item.codigo = RetornarTexto(row["codigo"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Incluir(dUsuarioPerfil dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " usuarioperfil (codigo, nome, situacao) " +
                    " VALUES (" +
                    PersistirTexto(dados.codigo) + "," +
                    PersistirTexto(dados.nome) + "," +
                    PersistirTexto(dados.situacao) + ")";
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dUsuarioPerfil dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE usuarioperfil SET " +
                    " codigo = " + PersistirTexto(dados.codigo) + "," +
                    " nome = " + PersistirTexto(dados.nome) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dUsuarioPerfil dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM usuarioperfil " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
