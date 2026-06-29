using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EfdArquivoController : ControllerBase
    {
        private readonly IsEfdArquivo _efdArquivo;
        public EfdArquivoController(IsEfdArquivo efdArquivo) { _efdArquivo = efdArquivo; }

        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            try { return Ok(_efdArquivo.Consultar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] dEfdArquivo dados)
        {
            try { return Ok(_efdArquivo.Salvar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir()
        {
            try { return Ok(_efdArquivo.Excluir()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}