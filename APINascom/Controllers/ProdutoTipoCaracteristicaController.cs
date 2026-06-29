using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoTipoCaracteristicaController : ControllerBase
    {
        private readonly IsProdutoTipoCaracteristica _produtoTipoCaracteristica;
        public ProdutoTipoCaracteristicaController(IsProdutoTipoCaracteristica produtoTipoCaracteristica) { _produtoTipoCaracteristica = produtoTipoCaracteristica; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_produtoTipoCaracteristica.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dProdutoTipoCaracteristica dados)
        {
            try { return Ok(_produtoTipoCaracteristica.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporprodutotipo")]
        public IActionResult ConsultarPorProdutoTipo([FromQuery] int produtoTipo_cid)
        {
            try { return Ok(_produtoTipoCaracteristica.ConsultarPorProdutoTipo(produtoTipo_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dProdutoTipoCaracteristica dados)
        {
            try { return Ok(_produtoTipoCaracteristica.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporprodutotipo")]
        public IActionResult ExcluirPorProdutoTipo([FromQuery] int produtoTipo_cid)
        {
            try { return Ok(_produtoTipoCaracteristica.ExcluirPorProdutoTipo(produtoTipo_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporcaracteristica")]
        public IActionResult ExcluirPorCaracteristica([FromQuery] int caracteristica_cid)
        {
            try { return Ok(_produtoTipoCaracteristica.ExcluirPorCaracteristica(caracteristica_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromQuery] int cid)
        {
            try { return Ok(_produtoTipoCaracteristica.Excluir(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}