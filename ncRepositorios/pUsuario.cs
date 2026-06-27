using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using ncNComum.nsExcecao;
using nsModelos;

namespace ncPersistencia.nsUsuario
{
    public class pUsuario : RepositorioBase, IpUsuario
    {
        public ColecaoUsuario Listar()
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var lista = conn.Query<dUsuario>(
                        "SELECT cid, nomeCompleto, senha, situacao, usuario, descontoProduto, descontoPedido, comissao, usuarioPerfil_cid, email AS Email FROM usuarios WHERE situacao LIKE 'A'").AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoUsuario();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Listar Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public ColecaoUsuario Consultar(dUsuario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var conditions = new List<string>();
                    var p = new DynamicParameters();
                    if (dados.cid != 0) { conditions.Add("u.cid=@cid"); p.Add("cid", dados.cid); }
                    if (!string.IsNullOrEmpty(dados.usuario)) { conditions.Add("u.usuario=@usuario"); p.Add("usuario", dados.usuario); }
                    if (!string.IsNullOrEmpty(dados.senha)) { conditions.Add("u.senha=@senha"); p.Add("senha", dados.senha); }
                    if (!string.IsNullOrEmpty(dados.situacao)) { conditions.Add("u.situacao=@situacao"); p.Add("situacao", dados.situacao); }
                    if (!string.IsNullOrEmpty(dados.nomeCompleto)) { conditions.Add("u.nomeCompleto=@nomeCompleto"); p.Add("nomeCompleto", dados.nomeCompleto); }
                    if (dados.usuarioPerfil_cid != 0) { conditions.Add("u.usuarioPerfil_cid=@usuarioPerfil_cid"); p.Add("usuarioPerfil_cid", dados.usuarioPerfil_cid); }
                    if (dados.descontoProduto != 0) { conditions.Add("u.descontoProduto=@descontoProduto"); p.Add("descontoProduto", dados.descontoProduto); }
                    if (dados.descontoPedido != 0) { conditions.Add("u.descontoPedido=@descontoPedido"); p.Add("descontoPedido", dados.descontoPedido); }
                    if (dados.comissao != 0) { conditions.Add("u.comissao=@comissao"); p.Add("comissao", dados.comissao); }
                    if (!string.IsNullOrEmpty(dados.Email)) { conditions.Add("u.email=@email"); p.Add("email", dados.Email); }
                    var where = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
                    var sql = $"SELECT u.cid, u.nomeCompleto, u.senha, u.situacao, u.usuario, u.usuarioPerfil_cid, up.codigo AS usuarioPerfil_codigo, u.descontoPedido, u.descontoProduto, u.comissao, u.email AS Email FROM usuarios u INNER JOIN usuarioperfil up ON up.cid = u.usuarioPerfil_cid {where}";
                    var lista = conn.Query<dUsuario>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoUsuario();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColecaoUsuario ConsultarADM(string perfil)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var p = new DynamicParameters();
                    p.Add("perfil", perfil);
                    var sql = "SELECT u.cid, u.nomeCompleto, u.senha, u.situacao, u.usuario, u.usuarioPerfil_cid, up.codigo AS usuarioPerfil_codigo, u.descontoPedido, u.descontoProduto, u.comissao, u.email AS Email FROM usuarios u INNER JOIN usuarioperfil up ON up.cid = u.usuarioPerfil_cid WHERE up.nome=@perfil AND u.email IS NOT NULL";
                    var lista = conn.Query<dUsuario>(sql, p).AsList();
                    if (lista.Count == 0) return null;
                    var retorno = new ColecaoUsuario();
                    retorno.AddRange(lista);
                    return retorno;
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Incluir(dUsuario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("INSERT INTO usuarios (usuario, senha, nomeCompleto, situacao, descontoProduto, descontoPedido, comissao, email, usuarioPerfil_cid) VALUES (@usuario, @senha, @nomeCompleto, @situacao, @descontoProduto, @descontoPedido, @comissao, @Email, @usuarioPerfil_cid)",
                        new { dados.usuario, dados.senha, dados.nomeCompleto, dados.situacao, dados.descontoProduto, dados.descontoPedido, dados.comissao, dados.Email, dados.usuarioPerfil_cid });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Incluir Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Alterar(dUsuario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("UPDATE usuarios SET usuario=@usuario, senha=@senha, nomeCompleto=@nomeCompleto, situacao=@situacao, descontoProduto=@descontoProduto, descontoPedido=@descontoPedido, comissao=@comissao, usuarioPerfil_cid=@usuarioPerfil_cid, email=@Email WHERE cid=@cid",
                        new { dados.usuario, dados.senha, dados.nomeCompleto, dados.situacao, dados.descontoProduto, dados.descontoPedido, dados.comissao, dados.usuarioPerfil_cid, dados.Email, dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Alterar Usuario [" + ToString() + "] - " + ex.Message);
            }
        }

        public int Excluir(dUsuario dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    return conn.Execute("DELETE FROM usuarios WHERE cid=@cid", new { dados.cid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex)
            {
                throw new ExcecaoNascomercio("Erro em Excluir Usuario [" + ToString() + "] - " + ex.Message);
            }
        }
    }
}
