using System;
using Dapper;
using Comum;
using Modelos;

namespace Repositorios
{
    public class pRefreshToken : RepositorioBase, IpRefreshToken
    {
        public int Incluir(dRefreshToken dados)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "INSERT INTO usuario_refresh_token (usuario_cid, token, expiracao, revogado) VALUES (@usuario_cid, @token, @expiracao, 0)";
                    conn.Execute(sql, new { dados.usuario_cid, dados.token, dados.expiracao });
                    return (int)conn.ExecuteScalar<long>("SELECT LAST_INSERT_ID()");
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Incluir RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public dRefreshToken ConsultarValido(string token)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    var sql = "SELECT cid, usuario_cid, token, expiracao, revogado FROM usuario_refresh_token WHERE token=@token AND revogado = 0 AND expiracao > UTC_TIMESTAMP()";
                    return conn.QueryFirstOrDefault<dRefreshToken>(sql, new { token });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarValido RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public void Revogar(string token)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("UPDATE usuario_refresh_token SET revogado = 1 WHERE token=@token", new { token });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Revogar RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public void RevogarTodosPorUsuario(int usuarioCid)
        {
            try
            {
                using (var conn = CriarConexao())
                {
                    conn.Execute("UPDATE usuario_refresh_token SET revogado = 1 WHERE usuario_cid=@usuarioCid AND revogado = 0", new { usuarioCid });
                }
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em RevogarTodosPorUsuario RefreshToken [" + ToString() + "] - " + ex.Message); }
        }
    }
}
