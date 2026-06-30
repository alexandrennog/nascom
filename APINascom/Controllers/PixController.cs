using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PixController : ControllerBase
    {
        private readonly IsPix _pix;
        public PixController(IsPix pix) { _pix = pix; }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dPix dados)
        {
            try { return Ok(_pix.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromQuery] string tx)
        {
            try { return Ok(_pix.Consultar(tx)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromBody] dPix dados)
        {
            try { return Ok(_pix.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}