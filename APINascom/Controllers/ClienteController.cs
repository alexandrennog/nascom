using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IsCliente _cliente;
        public ClienteController(IsCliente cliente) { _cliente = cliente; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_cliente.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dCliente dados)
        {
            try { return Ok(_cliente.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCID([FromQuery] int cid)
        {
            try { return Ok(_cliente.ConsultarPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dCliente dados)
        {
            try { return Ok(_cliente.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirimportacao")]
        public IActionResult IncluirImportacao([FromBody] dCliente dados)
        {
            try { return Ok(_cliente.IncluirImportacao(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dCliente dados)
        {
            try { return Ok(_cliente.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dCliente dados)
        {
            try { return Ok(_cliente.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}