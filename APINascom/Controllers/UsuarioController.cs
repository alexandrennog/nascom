using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IsUsuario _usuario;
        public UsuarioController(IsUsuario usuario) { _usuario = usuario; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_usuario.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dUsuario dados)
        {
            try { return Ok(_usuario.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporadm")]
        public IActionResult ConsultarPorADM([FromBody] dUsuario dados)
        {
            try { return Ok(_usuario.ConsultarPorADM(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCid([FromQuery] int cid)
        {
            try { return Ok(_usuario.ConsultarPorCid(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporemail")]
        public IActionResult ConsultarPorEmail([FromQuery] string email)
        {
            try { return Ok(_usuario.ConsultarPorEmail(email)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dUsuario dados)
        {
            try { return Ok(_usuario.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dUsuario dados)
        {
            try { return Ok(_usuario.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dUsuario dados)
        {
            try { return Ok(_usuario.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}