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
    public class ChequeController : ControllerBase
    {
        private readonly IsCheque _cheque;
        public ChequeController(IsCheque cheque) { _cheque = cheque; }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try { return Ok(_cheque.Listar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultar")]
        public IActionResult Consultar([FromBody] dCheques dados)
        {
            try { return Ok(_cheque.Consultar(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("consultarcheques")]
        public IActionResult ConsultarCheques([FromBody] dCheques dados)
        {
            try { return Ok(_cheque.ConsultarCheques(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir")]
        public IActionResult Incluir([FromBody] ColecaoCheques dadosCheques)
        {
            try { return Ok(_cheque.Incluir(dadosCheques)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("incluir2")]
        public IActionResult Incluir([FromBody] dCheques dados)
        {
            try { return Ok(_cheque.Incluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar([FromBody] AlterarChequeRequest req)
        {
            try { return Ok(_cheque.Alterar(req.Dados, req.DadosCheques)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("baixar")]
        public IActionResult Baixar()
        {
            try { return Ok(_cheque.Baixar()); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("excluir")]
        public IActionResult Excluir([FromBody] dCheques dados)
        {
            try { return Ok(_cheque.Excluir(dados)); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}