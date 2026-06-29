using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoResidenciaController : ControllerBase
    {
        private readonly IsTipoResidencia _tipoResidencia;
        public TipoResidenciaController(IsTipoResidencia tipoResidencia) { _tipoResidencia = tipoResidencia; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_tipoResidencia.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}