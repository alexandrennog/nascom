using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SituacaoController : ControllerBase
    {
        private readonly IsSituacao _situacao;
        public SituacaoController(IsSituacao situacao) { _situacao = situacao; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_situacao.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("listarfinan")]
        public IActionResult ListarFinan()
        {
            try { return Ok(_situacao.ListarFinan()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}