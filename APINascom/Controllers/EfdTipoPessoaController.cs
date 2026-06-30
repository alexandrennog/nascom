using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EfdTipoPessoaController : ControllerBase
    {
        private readonly IsEfdTipoPessoa _efdTipoPessoa;
        public EfdTipoPessoaController(IsEfdTipoPessoa efdTipoPessoa) { _efdTipoPessoa = efdTipoPessoa; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_efdTipoPessoa.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}