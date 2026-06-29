using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EfdEnderecoContatoController : ControllerBase
    {
        private readonly IsEfdEnderecoContato _efdEnderecoContato;
        public EfdEnderecoContatoController(IsEfdEnderecoContato efdEnderecoContato) { _efdEnderecoContato = efdEnderecoContato; }

        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            try { return Ok(_efdEnderecoContato.Consultar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] dEfdEnderecoContato dados)
        {
            try { return Ok(_efdEnderecoContato.Salvar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir()
        {
            try { return Ok(_efdEnderecoContato.Excluir()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}