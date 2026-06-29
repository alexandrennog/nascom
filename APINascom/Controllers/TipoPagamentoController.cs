using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly IsTipoPagamento _tipoPagamento;
        public TipoPagamentoController(IsTipoPagamento tipoPagamento) { _tipoPagamento = tipoPagamento; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoPagamento.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("retornarcodigo")]
        public IActionResult RetornarCodigo([FromQuery] int cid)
        {
            try { return Ok(_tipoPagamento.RetornarCodigo(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}