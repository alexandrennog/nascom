using System;
using System.Data;
using ncNComum.nsAcessoBD;
using ncNComum.nsExcecao;
using nsModelos;
using static ncNComum.nsFuncoes.cFuncoes;



namespace ncPersistencia.nsUsuario
{
    public class pUsuario
    {
        public ColecaoUsuario Listar()
        {
            ColecaoUsuario retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " Select cid, nomeCompleto, senha, situacao, usuario, descontoProduto, descontoPedido, " +
                    " comissao, usuarioPerfil_cid, email From usuarios where situacao like 'A'";
                var ds = acessoBanco.ExecutarDS(comandoSQL);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoUsuario();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dUsuario();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nomeCompleto = RetornarTexto(row["nomeCompleto"]);
                            item.senha = RetornarTexto(row["senha"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.usuario = RetornarTexto(row["usuario"]);
                            item.descontoProduto = RetornarDecimal(row["descontoProduto"]);
                            item.descontoPedido = RetornarDecimal(row["descontoPedido"]);
                            item.comissao = RetornarDecimal(row["comissao"]);
                            item.usuarioPerfil_cid = RetornarInteiro(row["usuarioPerfil_cid"]);
                            item.Email = RetornarTexto(row["email"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw new ExcecaoNascomercio("Erro em Listar Usuario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public ColecaoUsuario Consultar(dUsuario dados)
        {
            ColecaoUsuario retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select u.cid, u.nomeCompleto, u.senha, u.situacao, u.usuario, u.usuarioPerfil_cid, " +
                    " up.codigo, u.descontoPedido, u.descontoProduto, u.comissao, email ";
                string sqlWhere = string.Empty;
                string sqlFrom = " From usuarios u INNER JOIN usuarioperfil up " +
                    " ON up.cid = u.usuarioPerfil_cid ";
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.cid, "u.cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.usuario, "u.usuario");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.senha, "u.senha");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.situacao, "u.situacao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.nomeCompleto, "u.nomeCompleto");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.usuarioPerfil_cid, "u.usuarioPerfil_cid");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descontoProduto, "u.descontoProduto");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.descontoPedido, "u.descontoPedido");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.comissao, "u.comissao");
                sqlWhere = MontarParametrosSQL(sqlWhere, dados.Email, "u.email");
                if (!sqlWhere.Equals(string.Empty))
                    sqlWhere = " WHERE " + sqlWhere;
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom + " " + sqlWhere);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoUsuario();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dUsuario();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nomeCompleto = RetornarTexto(row["nomeCompleto"]);
                            item.senha = RetornarTexto(row["senha"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.usuario = RetornarTexto(row["usuario"]);
                            item.usuarioPerfil_cid = RetornarInteiro(row["usuarioPerfil_cid"]);
                            item.usuarioPerfil_codigo = RetornarTexto(row["codigo"]);
                            item.descontoProduto = RetornarDecimal(row["descontoProduto"]);
                            item.descontoPedido = RetornarDecimal(row["descontoPedido"]);
                            item.comissao = RetornarDecimal(row["comissao"]);
                            item.Email = RetornarTexto(row["email"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw ex;
            }
            return retorno;
        }

        public ColecaoUsuario ConsultarADM(string perfil)
        {
            ColecaoUsuario retorno = null;
            try
            {
                var acessoBanco = new cAcessoBD();
                string sqlSelect = " Select u.cid, u.nomeCompleto, u.senha, u.situacao, u.usuario, u.usuarioPerfil_cid, " +
                    " up.codigo, u.descontoPedido, u.descontoProduto, u.comissao, u.email ";
                string sqlFrom = " From usuarios u INNER JOIN usuarioperfil up " +
                    " ON up.cid = u.usuarioPerfil_cid " +
                    $"where up.nome = '{perfil}'" +
                    "and u.email IS NOT NULL;";
                var ds = acessoBanco.ExecutarDS(sqlSelect + " " + sqlFrom);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        retorno = new ColecaoUsuario();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new dUsuario();
                            item.cid = RetornarInteiro(row["cid"]);
                            item.nomeCompleto = RetornarTexto(row["nomeCompleto"]);
                            item.senha = RetornarTexto(row["senha"]);
                            item.situacao = RetornarTexto(row["situacao"]);
                            item.usuario = RetornarTexto(row["usuario"]);
                            item.usuarioPerfil_cid = RetornarInteiro(row["usuarioPerfil_cid"]);
                            item.usuarioPerfil_codigo = RetornarTexto(row["codigo"]);
                            item.descontoProduto = RetornarDecimal(row["descontoProduto"]);
                            item.descontoPedido = RetornarDecimal(row["descontoPedido"]);
                            item.comissao = RetornarDecimal(row["comissao"]);
                            item.Email = RetornarTexto(row["email"]);
                            retorno.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = null;
                throw ex;
            }
            return retorno;
        }

        public int Incluir(dUsuario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " INSERT INTO " +
                    " usuarios (usuario, senha, nomeCompleto, situacao, descontoProduto, descontoPedido, " +
                    " comissao, email, usuarioPerfil_cid) " +
                    " VALUES (" +
                    PersistirTexto(dados.usuario) + "," +
                    PersistirTexto(dados.senha) + "," +
                    PersistirTexto(dados.nomeCompleto) + "," +
                    PersistirTexto(dados.situacao) + "," +
                    PersistirDecimal(dados.descontoProduto) + "," +
                    PersistirDecimal(dados.descontoPedido) + "," +
                    PersistirDecimal(dados.comissao) + "," +
                    PersistirTexto(dados.Email) + "," +
                    PersistirInteiro(dados.usuarioPerfil_cid) + ")";
                retorno = acessoBanco.ExecutarCID(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Incluir Usuario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Alterar(dUsuario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " UPDATE usuarios SET " +
                    " usuario = " + PersistirTexto(dados.usuario) + "," +
                    " senha = " + PersistirTexto(dados.senha) + "," +
                    " nomeCompleto = " + PersistirTexto(dados.nomeCompleto) + "," +
                    " situacao = " + PersistirTexto(dados.situacao) + "," +
                    " descontoProduto = " + PersistirDecimal(dados.descontoProduto) + "," +
                    " descontoPedido = " + PersistirDecimal(dados.descontoPedido) + "," +
                    " comissao = " + PersistirDecimal(dados.comissao) + "," +
                    " usuarioPerfil_cid = " + PersistirInteiro(dados.usuarioPerfil_cid) + "," +
                    " email = " + PersistirTexto(dados.Email) +
                    " WHERE " +
                    " cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Alterar Usuario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }

        public int Excluir(dUsuario dados)
        {
            int retorno = 0;
            try
            {
                var acessoBanco = new cAcessoBD();
                string comandoSQL = " DELETE FROM usuarios " +
                    " WHERE cid = " + dados.cid.ToString();
                retorno = acessoBanco.ExecutarINT(comandoSQL);
            }
            catch (Exception ex)
            {
                retorno = 0;
                throw new ExcecaoNascomercio("Erro em Excluir Usuario [" + ToString() + "] - " + ex.Message);
            }
            return retorno;
        }
    }
}
