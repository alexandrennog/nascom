using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SituacaoNotaFiscalController : ControllerBase
    {
        private readonly IsSituacaoNotaFiscal _situacaoNotaFiscal;
        public SituacaoNotaFiscalController(IsSituacaoNotaFiscal situacaoNotaFiscal) { _situacaoNotaFiscal = situacaoNotaFiscal; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_situacaoNotaFiscal.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_situacaoNotaFiscal.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}