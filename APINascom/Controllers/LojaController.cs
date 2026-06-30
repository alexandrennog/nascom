using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        private readonly IsLoja _loja;
        public LojaController(IsLoja loja) { _loja = loja; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_loja.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dLoja dados)
        {
            try { return Ok(_loja.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_loja.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dLoja dados)
        {
            try { return Ok(_loja.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dLoja dados)
        {
            try { return Ok(_loja.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dLoja dados)
        {
            try { return Ok(_loja.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}