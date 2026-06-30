using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoEmissaoController : ControllerBase
    {
        private readonly IsTipoEmissao _tipoEmissao;
        public TipoEmissaoController(IsTipoEmissao tipoEmissao) { _tipoEmissao = tipoEmissao; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoEmissao.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_tipoEmissao.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}