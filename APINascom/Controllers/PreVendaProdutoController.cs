using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PreVendaProdutoController : ControllerBase
    {
        private readonly IsPreVendaProduto _preVendaProduto;
        public PreVendaProdutoController(IsPreVendaProduto preVendaProduto) { _preVendaProduto = preVendaProduto; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_preVendaProduto.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dVendaProduto dados)
        {
            try { return Ok(_preVendaProduto.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dVendaProduto dados)
        {
            try { return Ok(_preVendaProduto.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dVendaProduto dados)
        {
            try { return Ok(_preVendaProduto.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dVendaProduto dados)
        {
            try { return Ok(_preVendaProduto.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}