using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalFornecedorController : ControllerBase
    {
        private readonly IsNotaFiscalFornecedor _notaFiscalFornecedor;
        public NotaFiscalFornecedorController(IsNotaFiscalFornecedor notaFiscalFornecedor) { _notaFiscalFornecedor = notaFiscalFornecedor; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_notaFiscalFornecedor.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dNotaFiscalFornecedor dados)
        {
            try { return Ok(_notaFiscalFornecedor.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("selecionar")]
        public IActionResult Selecionar([FromQuery] string numero, [FromQuery] string serie)
        {
            try { return Ok(_notaFiscalFornecedor.Selecionar(numero, serie)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dNotaFiscalFornecedor dados)
        {
            try { return Ok(_notaFiscalFornecedor.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dNotaFiscalFornecedor dados)
        {
            try { return Ok(_notaFiscalFornecedor.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dNotaFiscalFornecedor dados)
        {
            try { return Ok(_notaFiscalFornecedor.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}