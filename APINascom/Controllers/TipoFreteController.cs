using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFreteController : ControllerBase
    {
        private readonly IsTipoFrete _tipoFrete;
        public TipoFreteController(IsTipoFrete tipoFrete) { _tipoFrete = tipoFrete; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoFrete.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_tipoFrete.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}