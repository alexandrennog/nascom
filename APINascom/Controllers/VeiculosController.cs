using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IsVeiculos _veiculos;
        public VeiculosController(IsVeiculos veiculos) { _veiculos = veiculos; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_veiculos.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dVeiculos dados)
        {
            try { return Ok(_veiculos.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCID([FromQuery] int cid)
        {
            try { return Ok(_veiculos.ConsultarPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] ColecaoVeiculos dadosVeiculos)
        {
            try { return Ok(_veiculos.Incluir(dadosVeiculos)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir2")]
        public IActionResult Incluir([FromBody] dVeiculos dados)
        {
            try { return Ok(_veiculos.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] ColecaoVeiculos dadosVeiculos)
        {
            try { return Ok(_veiculos.Alterar(dadosVeiculos)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dVeiculos dados)
        {
            try { return Ok(_veiculos.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirveiculoscliente")]
        public IActionResult ExcluirVeiculosCliente([FromBody] dVeiculos dados)
        {
            try { return Ok(_veiculos.ExcluirVeiculosCliente(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}