using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPerfilController : ControllerBase
    {
        private readonly IsUsuarioPerfil _usuarioPerfil;
        public UsuarioPerfilController(IsUsuarioPerfil usuarioPerfil) { _usuarioPerfil = usuarioPerfil; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_usuarioPerfil.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dUsuarioPerfil dados)
        {
            try { return Ok(_usuarioPerfil.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_usuarioPerfil.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dUsuarioPerfil dados)
        {
            try { return Ok(_usuarioPerfil.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dUsuarioPerfil dados)
        {
            try { return Ok(_usuarioPerfil.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dUsuarioPerfil dados)
        {
            try { return Ok(_usuarioPerfil.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}