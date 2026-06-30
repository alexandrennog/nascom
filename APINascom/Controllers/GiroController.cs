using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GiroController : ControllerBase
    {
        private readonly IsGiro _giro;
        public GiroController(IsGiro giro) { _giro = giro; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_giro.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dGiro dados)
        {
            try { return Ok(_giro.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int produto_cid, [FromQuery] string codigoBarras)
        {
            try { return Ok(_giro.Consultar(produto_cid, codigoBarras)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dGiro dados)
        {
            try { return Ok(_giro.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("importar")]
        public IActionResult Importar([FromBody] dGiro dados)
        {
            try { return Ok(_giro.Importar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dGiro dados)
        {
            try { return Ok(_giro.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dGiro dados)
        {
            try { return Ok(_giro.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}