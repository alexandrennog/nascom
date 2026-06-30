using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;
using APINascom.Requests;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IsProduto _produto;
        public ProdutoController(IsProduto produto) { _produto = produto; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_produto.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dProduto dados)
        {
            try { return Ok(_produto.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultargradeentrada")]
        public IActionResult ConsultarGradeEntrada([FromBody] dProduto dados)
        {
            try { return Ok(_produto.ConsultarGradeEntrada(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultar/{cid}")]
        public IActionResult ConsultarPorCid(int cid)
        {
            try { return Ok(_produto.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarproximocid")]
        public IActionResult ConsultarProximoCID()
        {
            try { return Ok(_produto.ConsultarProximoCID()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dProduto dados)
        {
            try { return Ok(_produto.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("importar")]
        public IActionResult Importar([FromBody] dProduto dados)
        {
            try { return Ok(_produto.Importar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluircompleto")]
        public IActionResult IncluirCompleto([FromBody] IncluirProdutoCompletoRequest req)
        {
            try { return Ok(_produto.Incluir(req.Dados, req.ColecaoItem, req.Usuario)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dProduto dados)
        {
            try { return Ok(_produto.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarcompleto")]
        public IActionResult AlterarCompleto([FromBody] AlterarProdutoCompletoRequest req)
        {
            try { return Ok(_produto.Alterar(req.Dados, req.ColecaoItem, req.Usuario)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] ExcluirProdutoRequest req)
        {
            try { return Ok(_produto.Excluir(req.Dados, req.Usuario)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
