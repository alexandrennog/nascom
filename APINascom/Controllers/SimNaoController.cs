using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimNaoController : ControllerBase
    {
        private readonly IsSimNao _simNao;
        public SimNaoController(IsSimNao simNao) { _simNao = simNao; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_simNao.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}