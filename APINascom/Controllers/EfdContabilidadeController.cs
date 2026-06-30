using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdContabilidadeController : ControllerBase
    {
        private readonly IsEfdContabilidade _efdContabilidade;
        public EfdContabilidadeController(IsEfdContabilidade efdContabilidade) { _efdContabilidade = efdContabilidade; }

        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            try { return Ok(_efdContabilidade.Consultar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] dEfdContabilidade dados)
        {
            try { return Ok(_efdContabilidade.Salvar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir()
        {
            try { return Ok(_efdContabilidade.Excluir()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}