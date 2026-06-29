using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CobrancaController : ControllerBase
    {
        private readonly IsCobranca _cobranca;
        public CobrancaController(IsCobranca cobranca) { _cobranca = cobranca; }

        [HttpPost("consultarcobrancas")]
        public IActionResult ConsultarCobrancas([FromBody] dCobrancaAutomatica dados)
        {
            try { return Ok(_cobranca.ConsultarCobrancas(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}