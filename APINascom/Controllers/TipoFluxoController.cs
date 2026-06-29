using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFluxoController : ControllerBase
    {
        private readonly IsTipoFluxo _tipoFluxo;
        public TipoFluxoController(IsTipoFluxo tipoFluxo) { _tipoFluxo = tipoFluxo; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoFluxo.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_tipoFluxo.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}