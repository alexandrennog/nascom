using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteProfissionalController : ControllerBase
    {
        private readonly IsClienteProfissional _clienteProfissional;
        public ClienteProfissionalController(IsClienteProfissional clienteProfissional) { _clienteProfissional = clienteProfissional; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_clienteProfissional.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dClienteProfissional dados)
        {
            try { return Ok(_clienteProfissional.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dClienteProfissional dados)
        {
            try { return Ok(_clienteProfissional.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dClienteProfissional dados)
        {
            try { return Ok(_clienteProfissional.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporcliente")]
        public IActionResult ExcluirPorCliente([FromQuery] int cliente_cid)
        {
            try { return Ok(_clienteProfissional.ExcluirPorCliente(cliente_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}