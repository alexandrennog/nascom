using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdFinalidadeArquivoController : ControllerBase
    {
        private readonly IsEfdFinalidadeArquivo _efdFinalidadeArquivo;
        public EfdFinalidadeArquivoController(IsEfdFinalidadeArquivo efdFinalidadeArquivo) { _efdFinalidadeArquivo = efdFinalidadeArquivo; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_efdFinalidadeArquivo.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}