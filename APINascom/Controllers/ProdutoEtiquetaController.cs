using Microsoft.AspNetCore.Mvc;
using Modelos;
using Servicos;

namespace APINascom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoEtiquetaController : ControllerBase
    {
        private readonly IsProdutoEtiqueta _produtoEtiqueta;
        public ProdutoEtiquetaController(IsProdutoEtiqueta produtoEtiqueta) { _produtoEtiqueta = produtoEtiqueta; }

        [HttpGet("listar")]
        public IActionResult Listar([FromQuery] string dataDe, [FromQuery] string dataAte, [FromQuery] int ImprimeTodos)
        {
            try { return Ok(_produtoEtiqueta.Listar(dataDe, dataAte, ImprimeTodos)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromQuery] string data, [FromQuery] string produto, [FromQuery] string codigoBarras)
        {
            try { return Ok(_produtoEtiqueta.Alterar(data, produto, codigoBarras)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}