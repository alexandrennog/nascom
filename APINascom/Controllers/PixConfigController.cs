using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixConfigController : ControllerBase
    {
        private readonly IsPixConfig _pixConfig;
        public PixConfigController(IsPixConfig pixConfig) { _pixConfig = pixConfig; }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dPixConfig dados)
        {
            try { return Ok(_pixConfig.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            try { return Ok(_pixConfig.Consultar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}