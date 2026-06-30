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
    public class CrediarioController : ControllerBase
    {
        private readonly IsCrediario _crediario;
        public CrediarioController(IsCrediario crediario) { _crediario = crediario; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_crediario.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarmax")]
        public IActionResult ConsultarMax()
        {
            try { return Ok(_crediario.ConsultarMax()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dCrediario dados)
        {
            try { return Ok(_crediario.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarparcelas")]
        public IActionResult ConsultarParcelas([FromBody] dParcelas dados)
        {
            try { return Ok(_crediario.ConsultarParcelas(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarparcelaspagamentos")]
        public IActionResult ConsultarParcelasPagamentos([FromBody] dParcelas dados)
        {
            try { return Ok(_crediario.ConsultarParcelasPagamentos(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarparcela/{cid}")]
        public IActionResult ConsultarParcela(int cid)
        {
            try { return Ok(_crediario.ConsultarParcela(cid)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarparcelascliente/{codCliente}")]
        public IActionResult ConsultarParcelasCliente(int codCliente)
        {
            try { return Ok(_crediario.ConsultarParcelasCliente(codCliente)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("consultarparcelasvencidas/{codCliente}")]
        public IActionResult ConsultarParcelasVencidas(int codCliente)
        {
            try { return Ok(_crediario.ConsultarParcelasVencidas(codCliente)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] IncluirCrediarioRequest req)
        {
            try { return Ok(_crediario.Incluir(req.Dados, req.DadosParcelas)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluircrediario")]
        public IActionResult IncluirCrediario([FromBody] dCrediario dados)
        {
            try { return Ok(_crediario.IncluirCrediario(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluirparcela")]
        public IActionResult IncluirParcela([FromBody] dParcelas dadosParcela)
        {
            try { return Ok(_crediario.IncluirParcela(dadosParcela)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] AlterarCrediarioRequest req)
        {
            try { return Ok(_crediario.Alterar(req.Dados, req.DadosParcelas)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("gravarpagamentoparcelas")]
        public IActionResult GravarPagamentoParcelas([FromBody] ColecaoParcelas dadosParcelas)
        {
            try { return Ok(_crediario.GravarPagamentoParcelas(dadosParcelas)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("renegociar")]
        public IActionResult Renegociar([FromBody] RenegociarCrediarioRequest req)
        {
            try { return Ok(_crediario.Renegociar(req.Dados, req.DadosParcelas)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarcrediario")]
        public IActionResult AlterarCrediario([FromBody] dCrediario dados)
        {
            try { return Ok(_crediario.AlterarCrediario(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterarcontrole")]
        public IActionResult AlterarControle([FromBody] dCrediario dados)
        {
            try { return Ok(_crediario.AlterarControle(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dCrediario dados)
        {
            try { return Ok(_crediario.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("corrigirparcelas")]
        public IActionResult CorrigirParcelas()
        {
            try { return Ok(_crediario.CorrigirParcelas()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
