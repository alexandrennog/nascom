using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaracteristicaController : ControllerBase
    {
        private readonly IsCaracteristica _caracteristica;
        public CaracteristicaController(IsCaracteristica caracteristica) { _caracteristica = caracteristica; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_caracteristica.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dCaracteristica dados)
        {
            try { return Ok(_caracteristica.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCID([FromQuery] int cid)
        {
            try { return Ok(_caracteristica.ConsultarPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarpornome")]
        public IActionResult ConsultarPorNome([FromQuery] string nome)
        {
            try { return Ok(_caracteristica.ConsultarPorNome(nome)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcodigo")]
        public IActionResult ConsultarPorCodigo([FromQuery] string codigo)
        {
            try { return Ok(_caracteristica.ConsultarPorCodigo(codigo)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dCaracteristica dados)
        {
            try { return Ok(_caracteristica.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dCaracteristica dados)
        {
            try { return Ok(_caracteristica.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dCaracteristica dados)
        {
            try { return Ok(_caracteristica.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}