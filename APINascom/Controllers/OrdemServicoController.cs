using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemServicoController : ControllerBase
    {
        private readonly IsOrdemServico _ordemServico;
        public OrdemServicoController(IsOrdemServico ordemServico) { _ordemServico = ordemServico; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_ordemServico.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dOrdemServico dados)
        {
            try { return Ok(_ordemServico.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarmax")]
        public IActionResult ConsultarMax()
        {
            try { return Ok(_ordemServico.ConsultarMax()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dOrdemServico dados)
        {
            try { return Ok(_ordemServico.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dOrdemServico dados)
        {
            try { return Ok(_ordemServico.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dOrdemServico dados)
        {
            try { return Ok(_ordemServico.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}