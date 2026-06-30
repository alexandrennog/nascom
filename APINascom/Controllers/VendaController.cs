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
    public class VendaController : ControllerBase
    {
        private readonly IsVenda _venda;
        public VendaController(IsVenda venda) { _venda = venda; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_venda.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("listarvendasnfe")]
        public IActionResult ListarVendasNfe([FromQuery] string dataIni, [FromQuery] string dataFim)
        {
            try { return Ok(_venda.ListarVendasNfe(dataIni, dataFim)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("listarvendasabc")]
        public IActionResult ListarVendasABC([FromQuery] string dataIni, [FromQuery] string dataFim, [FromQuery] string tipo)
        {
            try { return Ok(_venda.ListarVendasABC(dataIni, dataFim, tipo)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dVenda dados)
        {
            try { return Ok(_venda.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarpix")]
        public IActionResult ConsultarPix([FromBody] dVenda dados)
        {
            try { return Ok(_venda.ConsultarPix(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarvendasporvendedor")]
        public IActionResult ConsultarVendasPorVendedor([FromBody] dVendasPorVendedor dados)
        {
            try { return Ok(_venda.ConsultarVendasPorVendedor(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarvendasdaloja")]
        public IActionResult ConsultarVendasDaLoja([FromBody] dVendasPorVendedor dados)
        {
            try { return Ok(_venda.ConsultarVendasDaLoja(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarcrediariopix")]
        public IActionResult ConsultarCrediarioPix([FromBody] dVenda dados)
        {
            try { return Ok(_venda.ConsultarCrediarioPix(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultartroca")]
        public IActionResult ConsultarTroca([FromBody] dVenda dados)
        {
            try { return Ok(_venda.ConsultarTroca(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarultimavenda")]
        public IActionResult ConsultarUltimaVenda([FromQuery] int produto_cid)
        {
            try { return Ok(_venda.ConsultarUltimaVenda(produto_cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarmax")]
        public IActionResult ConsultarMax()
        {
            try { return Ok(_venda.ConsultarMax()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] IncluirVendaRequest req)
        {
            try { return Ok(_venda.Incluir(req.Dados, req.DadosProdutos)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirnnf")]
        public IActionResult IncluirnNF([FromBody] dBasennf dados)
        {
            try { return Ok(_venda.IncluirnNF(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirtroca")]
        public IActionResult IncluirTroca([FromBody] IncluirTrocaVendaRequest req)
        {
            try { return Ok(_venda.IncluirTroca(req.Dados, req.DadosProdutos)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirvale")]
        public IActionResult IncluirVale([FromBody] dVenda dados)
        {
            try { return Ok(_venda.IncluirVale(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluircrediariopagamento")]
        public IActionResult IncluirCrediarioPagamento([FromBody] dVenda dados)
        {
            try { return Ok(_venda.IncluirCrediarioPagamento(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] dVenda dados)
        {
            try { return Ok(_venda.Alterar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar2")]
        public IActionResult Alterar([FromQuery] string controle, [FromQuery] string chave)
        {
            try { return Ok(_venda.Alterar(controle, chave)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarbasennf")]
        public IActionResult AlterarBaseNnf([FromBody] dBasennf dados)
        {
            try { return Ok(_venda.AlterarBaseNnf(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dVenda dados)
        {
            try { return Ok(_venda.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluirvale")]
        public IActionResult ExcluirVale([FromBody] dVenda dados)
        {
            try { return Ok(_venda.ExcluirVale(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarfechamento")]
        public IActionResult ConsultarFechamento([FromBody] dVenda dados)
        {
            try { return Ok(_venda.ConsultarFechamento(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}