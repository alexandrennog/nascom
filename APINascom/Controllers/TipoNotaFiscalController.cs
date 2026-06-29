using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoNotaFiscalController : ControllerBase
    {
        private readonly IsTipoNotaFiscal _tipoNotaFiscal;
        public TipoNotaFiscalController(IsTipoNotaFiscal tipoNotaFiscal) { _tipoNotaFiscal = tipoNotaFiscal; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoNotaFiscal.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_tipoNotaFiscal.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}