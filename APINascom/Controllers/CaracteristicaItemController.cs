using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaracteristicaItemController : ControllerBase
    {
        private readonly IsCaracteristicaItem _caracteristicaItem;
        public CaracteristicaItemController(IsCaracteristicaItem caracteristicaItem) { _caracteristicaItem = caracteristicaItem; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_caracteristicaItem.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dCaracteristicaItem dados)
        {
            try { return Ok(_caracteristicaItem.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcid")]
        public IActionResult ConsultarPorCID([FromQuery] int cid)
        {
            try { return Ok(_caracteristicaItem.ConsultarPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarporcaracteristica")]
        public IActionResult ConsultarPorCaracteristica([FromQuery] int caracteristica_cid)
        {
            try { return Ok(_caracteristicaItem.ConsultarPorCaracteristica(caracteristica_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] dCaracteristicaItem dados)
        {
            try { return Ok(_caracteristicaItem.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dCaracteristicaItem dados)
        {
            try { return Ok(_caracteristicaItem.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dCaracteristicaItem dados)
        {
            try { return Ok(_caracteristicaItem.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirporcid")]
        public IActionResult ExcluirPorCID([FromQuery] int cid)
        {
            try { return Ok(_caracteristicaItem.ExcluirPorCID(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}