using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreVendaController : ControllerBase
    {
        private readonly IsPreVenda _preVenda;
        public PreVendaController(IsPreVenda preVenda) { _preVenda = preVenda; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_preVenda.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dVenda dados)
        {
            try { return Ok(_preVenda.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarmax")]
        public IActionResult ConsultarMax()
        {
            try { return Ok(_preVenda.ConsultarMax()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dVenda dados)
        {
            try { return Ok(_preVenda.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dVenda dados)
        {
            try { return Ok(_preVenda.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dVenda dados)
        {
            try { return Ok(_preVenda.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}