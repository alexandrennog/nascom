using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
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