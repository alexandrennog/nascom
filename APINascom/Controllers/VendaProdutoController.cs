using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VendaProdutoController : ControllerBase
    {
        private readonly IsVendaProduto _vendaProduto;
        public VendaProdutoController(IsVendaProduto vendaProduto) { _vendaProduto = vendaProduto; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_vendaProduto.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultartroca")]
        public IActionResult ConsultarTroca([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.ConsultarTroca(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirtroca")]
        public IActionResult ExcluirTroca([FromBody] dVendaProduto dados)
        {
            try { return Ok(_vendaProduto.ExcluirTroca(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluircontrole")]
        public IActionResult ExcluirControle([FromQuery] int controle)
        {
            try { return Ok(_vendaProduto.ExcluirControle(controle)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluircontroletroca")]
        public IActionResult ExcluirControleTroca([FromQuery] int controle)
        {
            try { return Ok(_vendaProduto.ExcluirControleTroca(controle)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}