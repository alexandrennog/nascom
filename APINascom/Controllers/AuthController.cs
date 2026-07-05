using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IsUsuario _usuario;
        private readonly IsJwt _jwt;
        private readonly IsRefreshToken _refreshToken;

        public AuthController(IsUsuario usuario, IsJwt jwt, IsRefreshToken refreshToken)
        {
            _usuario = usuario;
            _jwt = jwt;
            _refreshToken = refreshToken;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] dLogin dados)
        {
            try
            {
                if (string.IsNullOrEmpty(dados?.Usuario) || string.IsNullOrEmpty(dados?.Senha))
                    return BadRequest("Usuário e senha são obrigatórios");

                var lista = _usuario.Consultar(new dUsuario { usuario = dados.Usuario });
                var usuario = lista != null && lista.Count > 0 ? lista[0] : null;

                if (usuario == null || usuario.situacao != "A")
                    return Unauthorized("Usuário ou senha inválidos");

                if (!BCrypt.Net.BCrypt.Verify(dados.Senha, usuario.senha))
                    return Unauthorized("Usuário ou senha inválidos");

                return Ok(GerarResposta(usuario));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] dRefreshTokenRequest dados)
        {
            try
            {
                if (string.IsNullOrEmpty(dados?.RefreshToken))
                    return BadRequest("RefreshToken é obrigatório");

                var refreshToken = _refreshToken.ConsultarValido(dados.RefreshToken);
                if (refreshToken == null)
                    return Unauthorized("Refresh token inválido ou expirado");

                var lista = _usuario.Consultar(new dUsuario { cid = refreshToken.usuario_cid });
                var usuario = lista != null && lista.Count > 0 ? lista[0] : null;

                if (usuario == null || usuario.situacao != "A")
                    return Unauthorized("Usuário inválido");

                // Rotação: revoga o refresh token usado e emite um novo junto com o novo access token
                _refreshToken.Revogar(dados.RefreshToken);

                return Ok(GerarResposta(usuario));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] dRefreshTokenRequest dados)
        {
            try
            {
                if (!string.IsNullOrEmpty(dados?.RefreshToken))
                    _refreshToken.Revogar(dados.RefreshToken);

                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        private dTokenResposta GerarResposta(dUsuario usuario)
        {
            var token = _jwt.GerarToken(usuario);
            var refreshToken = _refreshToken.Gerar(usuario.cid!.Value);

            token.RefreshToken = refreshToken.token;
            token.RefreshTokenExpiracao = refreshToken.expiracao;

            return token;
        }
    }
}
