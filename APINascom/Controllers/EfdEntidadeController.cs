using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdEntidadeController : ControllerBase
    {
        private readonly IsEfdEntidade _efdEntidade;
        public EfdEntidadeController(IsEfdEntidade efdEntidade) { _efdEntidade = efdEntidade; }

        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            try { return Ok(_efdEntidade.Consultar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] dEfdEntidade dados)
        {
            try { return Ok(_efdEntidade.Salvar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir()
        {
            try { return Ok(_efdEntidade.Excluir()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}