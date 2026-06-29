using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoTipoController : ControllerBase
    {
        private readonly IsProdutoTipo _produtoTipo;
        public ProdutoTipoController(IsProdutoTipo produtoTipo) { _produtoTipo = produtoTipo; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_produtoTipo.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dProdutoTipo dados)
        {
            try { return Ok(_produtoTipo.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_produtoTipo.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dProdutoTipo dados)
        {
            try { return Ok(_produtoTipo.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dProdutoTipo dados)
        {
            try { return Ok(_produtoTipo.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dProdutoTipo dados)
        {
            try { return Ok(_produtoTipo.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}