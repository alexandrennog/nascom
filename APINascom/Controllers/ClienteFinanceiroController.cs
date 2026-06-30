using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteFinanceiroController : ControllerBase
    {
        private readonly IsClienteFinanceiro _clienteFinanceiro;
        public ClienteFinanceiroController(IsClienteFinanceiro clienteFinanceiro) { _clienteFinanceiro = clienteFinanceiro; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_clienteFinanceiro.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dClienteFinanceiro dados)
        {
            try { return Ok(_clienteFinanceiro.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dClienteFinanceiro dados)
        {
            try { return Ok(_clienteFinanceiro.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dClienteFinanceiro dados)
        {
            try { return Ok(_clienteFinanceiro.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporcliente")]
        public IActionResult ExcluirPorCliente([FromQuery] int cliente_cid)
        {
            try { return Ok(_clienteFinanceiro.ExcluirPorCliente(cliente_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}