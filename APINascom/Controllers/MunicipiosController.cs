using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IsMunicipios _municipios;
        public MunicipiosController(IsMunicipios municipios) { _municipios = municipios; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_municipios.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("listarporestados")]
        public IActionResult ListarPorEstados([FromQuery] int estados_cid)
        {
            try { return Ok(_municipios.ListarPorEstados(estados_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dMunicipios dados)
        {
            try { return Ok(_municipios.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar2")]
        public IActionResult Consultar([FromQuery] int cid)
        {
            try { return Ok(_municipios.Consultar(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dMunicipios dados)
        {
            try { return Ok(_municipios.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("importar")]
        public IActionResult Importar([FromBody] dMunicipios dados)
        {
            try { return Ok(_municipios.Importar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dMunicipios dados)
        {
            try { return Ok(_municipios.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dMunicipios dados)
        {
            try { return Ok(_municipios.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}