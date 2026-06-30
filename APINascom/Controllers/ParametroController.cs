using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParametroController : ControllerBase
    {
        private readonly IsParametro _parametro;
        public ParametroController(IsParametro parametro) { _parametro = parametro; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_parametro.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dParametro dados)
        {
            try { return Ok(_parametro.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarestoque")]
        public IActionResult ConsultarEstoque([FromBody] dParametroEstoque dados)
        {
            try { return Ok(_parametro.ConsultarEstoque(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_parametro.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dParametro dados)
        {
            try { return Ok(_parametro.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dParametro dados)
        {
            try { return Ok(_parametro.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dParametro dados)
        {
            try { return Ok(_parametro.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}