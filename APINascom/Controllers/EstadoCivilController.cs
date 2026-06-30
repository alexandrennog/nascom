using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoCivilController : ControllerBase
    {
        private readonly IsEstadoCivil _estadoCivil;
        public EstadoCivilController(IsEstadoCivil estadoCivil) { _estadoCivil = estadoCivil; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_estadoCivil.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}