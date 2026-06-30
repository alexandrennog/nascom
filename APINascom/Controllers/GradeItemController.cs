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
    public class GradeItemController : ControllerBase
    {
        private readonly IsGradeItem _gradeItem;
        public GradeItemController(IsGradeItem gradeItem) { _gradeItem = gradeItem; }

        [HttpPost("consultarreferencia")]
        public IActionResult ConsultarReferencia([FromBody] dGradeItem pFiltro)
        {
            try { return Ok(_gradeItem.ConsultarReferencia(pFiltro)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarprodutos")]
        public IActionResult ConsultarProdutos([FromBody] ConsultarGradeItemProdutosRequest req)
        {
            try { return Ok(_gradeItem.ConsultarProdutos(req.PReferencia, req.PGradeItem)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultaritens/{pProdutoCid}")]
        public IActionResult ConsultarItens(int pProdutoCid)
        {
            try { return Ok(_gradeItem.ConsultarItens(pProdutoCid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarultimavenda")]
        public IActionResult ConsultarUltimaVenda([FromBody] ConsultarUltimaVendaGradeRequest req)
        {
            try { return Ok(_gradeItem.ConsultarUltimaVenda(req.Referencia, req.GradeItem)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
