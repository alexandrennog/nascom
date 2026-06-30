using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdPerfilArquivoFiscalController : ControllerBase
    {
        private readonly IsEfdPerfilArquivoFiscal _efdPerfilArquivoFiscal;
        public EfdPerfilArquivoFiscalController(IsEfdPerfilArquivoFiscal efdPerfilArquivoFiscal) { _efdPerfilArquivoFiscal = efdPerfilArquivoFiscal; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_efdPerfilArquivoFiscal.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}