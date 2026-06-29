using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoItemController : ControllerBase
    {
        private readonly IsProdutoItem _produtoItem;
        public ProdutoItemController(IsProdutoItem produtoItem) { _produtoItem = produtoItem; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_produtoItem.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarultimoitem")]
        public IActionResult ConsultarUltimoItem([FromQuery] int produto_cid)
        {
            try { return Ok(_produtoItem.ConsultarUltimoItem(produto_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarultimocodigobarras")]
        public IActionResult ConsultarUltimoCodigoBarras()
        {
            try { return Ok(_produtoItem.ConsultarUltimoCodigoBarras()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("selecionar")]
        public IActionResult Selecionar([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.Selecionar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarquantidadeitem")]
        public IActionResult ConsultarQuantidadeItem([FromQuery] int produtos_cid)
        {
            try { return Ok(_produtoItem.ConsultarQuantidadeItem(produtos_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarprodutoitem")]
        public IActionResult ConsultarProdutoItem([FromQuery] string descricao, [FromQuery] string codigoBarras, [FromQuery] string referencia, [FromQuery] bool emEstoque)
        {
            try { return Ok(_produtoItem.ConsultarProdutoItem(descricao, codigoBarras, referencia, emEstoque)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporproduto")]
        public IActionResult ConsultarPorProduto([FromQuery] int produto_cid)
        {
            try { return Ok(_produtoItem.ConsultarPorProduto(produto_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirlistaitem")]
        public IActionResult IncluirListaItem([FromBody] ColecaoProdutoItem colecao)
        {
            try { return Ok(_produtoItem.IncluirListaItem(colecao)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarestoque")]
        public IActionResult AlterarEstoque([FromQuery] string codigoBarras, [FromQuery] decimal quantidade)
        {
            try { return Ok(_produtoItem.AlterarEstoque(codigoBarras, quantidade)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarestoque2")]
        public IActionResult AlterarEstoque([FromQuery] string codigoBarras, [FromQuery] decimal quantidade, [FromQuery] bool somar)
        {
            try { return Ok(_produtoItem.AlterarEstoque(codigoBarras, quantidade, somar)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporproduto")]
        public IActionResult ExcluirPorProduto([FromBody] dProdutoItem dados)
        {
            try { return Ok(_produtoItem.ExcluirPorProduto(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporproduto2")]
        public IActionResult ExcluirPorProduto([FromQuery] int produtos_cid)
        {
            try { return Ok(_produtoItem.ExcluirPorProduto(produtos_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}