using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdUnidadeMedidaController : ControllerBase
    {
        private readonly IsEfdUnidadeMedida _efdUnidadeMedida;
        public EfdUnidadeMedidaController(IsEfdUnidadeMedida efdUnidadeMedida) { _efdUnidadeMedida = efdUnidadeMedida; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_efdUnidadeMedida.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dEfdUnidadeMedida dados)
        {
            try { return Ok(_efdUnidadeMedida.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] dEfdUnidadeMedida dados)
        {
            try { return Ok(_efdUnidadeMedida.Salvar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dEfdUnidadeMedida dados)
        {
            try { return Ok(_efdUnidadeMedida.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}