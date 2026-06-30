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

        public AuthController(IsUsuario usuario, IsJwt jwt)
        {
            _usuario = usuario;
            _jwt = jwt;
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

                return Ok(_jwt.GerarToken(usuario));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
