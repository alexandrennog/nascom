using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SexoController : ControllerBase
    {
        private readonly IsSexo _sexo;
        public SexoController(IsSexo sexo) { _sexo = sexo; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_sexo.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}