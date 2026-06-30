using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteEnderecoController : ControllerBase
    {
        private readonly IsClienteEndereco _clienteEndereco;
        public ClienteEnderecoController(IsClienteEndereco clienteEndereco) { _clienteEndereco = clienteEndereco; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_clienteEndereco.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dClienteEndereco dados)
        {
            try { return Ok(_clienteEndereco.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCID([FromQuery] int cid)
        {
            try { return Ok(_clienteEndereco.ConsultarPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dClienteEndereco dados)
        {
            try { return Ok(_clienteEndereco.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporcliente")]
        public IActionResult ExcluirPorCliente([FromQuery] int cliente_cid)
        {
            try { return Ok(_clienteEndereco.ExcluirPorCliente(cliente_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}