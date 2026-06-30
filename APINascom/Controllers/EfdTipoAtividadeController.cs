using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdTipoAtividadeController : ControllerBase
    {
        private readonly IsEfdTipoAtividade _efdTipoAtividade;
        public EfdTipoAtividadeController(IsEfdTipoAtividade efdTipoAtividade) { _efdTipoAtividade = efdTipoAtividade; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_efdTipoAtividade.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}