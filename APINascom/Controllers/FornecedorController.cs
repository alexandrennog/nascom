using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IsFornecedor _fornecedor;
        public FornecedorController(IsFornecedor fornecedor) { _fornecedor = fornecedor; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_fornecedor.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dFornecedor dados)
        {
            try { return Ok(_fornecedor.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_fornecedor.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dFornecedor dados)
        {
            try { return Ok(_fornecedor.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("importar")]
        public IActionResult Importar([FromBody] dFornecedor dados)
        {
            try { return Ok(_fornecedor.Importar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dFornecedor dados)
        {
            try { return Ok(_fornecedor.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dFornecedor dados)
        {
            try { return Ok(_fornecedor.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}