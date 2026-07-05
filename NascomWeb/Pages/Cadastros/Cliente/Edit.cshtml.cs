using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Cliente;

public class EditModel : PageModel
{
    private readonly ClienteApiClient _clienteClient;
    private readonly CrudApiClientFactory _factory;

    public EditModel(ClienteApiClient clienteClient, CrudApiClientFactory factory)
    {
        _clienteClient = clienteClient;
        _factory = factory;
    }

    [BindProperty]
    public dCliente Dados { get; set; } = new() { situacao = "A" };

    [BindProperty]
    public dClienteEndereco Endereco { get; set; } = new();

    [BindProperty]
    public dClienteFinanceiro Financeiro { get; set; } = new();

    [BindProperty]
    public dClienteProfissional Profissional { get; set; } = new();

    [BindProperty]
    public dVeiculos NovoVeiculo { get; set; } = new();

    public List<dVeiculos> Veiculos { get; set; } = new();

    public List<Modelos.dEstado> Estados { get; set; } = new();
    public List<dEstadoCivil> EstadosCivis { get; set; } = new();
    public List<dSexo> Sexos { get; set; } = new();
    public List<dTipoResidencia> TiposResidencia { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string Tab { get; set; } = "geral";

    public bool ClienteJaSalvo => Dados.cid is int cid && cid > 0;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        await CarregarListasApoioAsync();

        if (id is int cid && cid > 0)
        {
            var existente = (await _clienteClient.ConsultarAsync(new dCliente { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");

            Dados = existente;
            await CarregarSubDadosAsync(cid);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostDadosGeraisAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");

        if (!ModelState.IsValid)
        {
            await CarregarListasApoioAsync();
            if (Dados.cid is int cid and > 0) await CarregarSubDadosAsync(cid);
            return Page();
        }

        int cidSalvo;
        if (Dados.cid is null or 0)
        {
            cidSalvo = await _clienteClient.IncluirAsync(Dados);
            TempData["Mensagem"] = "Cliente incluído com sucesso.";
        }
        else
        {
            await _clienteClient.AlterarAsync(Dados);
            cidSalvo = Dados.cid.Value;
            TempData["Mensagem"] = "Cliente alterado com sucesso.";
        }

        return RedirectToPage(new { id = cidSalvo, tab = "geral" });
    }

    public async Task<IActionResult> OnPostEnderecoAsync(int id)
    {
        Endereco.cliente_cid = id;
        await _clienteClient.SalvarEnderecoAsync(Endereco);
        TempData["Mensagem"] = "Endereço salvo com sucesso.";
        return RedirectToPage(new { id, tab = "endereco" });
    }

    public async Task<IActionResult> OnPostFinanceiroAsync(int id)
    {
        Financeiro.cliente_cid = id;
        await _clienteClient.SalvarFinanceiroAsync(Financeiro);
        TempData["Mensagem"] = "Dados financeiros salvos com sucesso.";
        return RedirectToPage(new { id, tab = "financeiro" });
    }

    public async Task<IActionResult> OnPostProfissionalAsync(int id)
    {
        Profissional.cliente_cid = id;
        await _clienteClient.SalvarProfissionalAsync(Profissional);
        TempData["Mensagem"] = "Dados profissionais salvos com sucesso.";
        return RedirectToPage(new { id, tab = "profissional" });
    }

    public async Task<IActionResult> OnPostVeiculoAdicionarAsync(int id)
    {
        if (!string.IsNullOrWhiteSpace(NovoVeiculo.Placa))
        {
            NovoVeiculo.clienteId = id;
            await _clienteClient.AdicionarVeiculoAsync(NovoVeiculo);
            TempData["Mensagem"] = "Veículo adicionado com sucesso.";
        }

        return RedirectToPage(new { id, tab = "veiculos" });
    }

    public async Task<IActionResult> OnPostVeiculoRemoverAsync(int id, int veiculoCid)
    {
        await _clienteClient.RemoverVeiculoAsync(veiculoCid);
        TempData["Mensagem"] = "Veículo removido com sucesso.";
        return RedirectToPage(new { id, tab = "veiculos" });
    }

    private async Task CarregarSubDadosAsync(int clienteCid)
    {
        Endereco = (await _clienteClient.ConsultarEnderecoAsync(clienteCid)).FirstOrDefault() ?? new dClienteEndereco { cliente_cid = clienteCid };
        Financeiro = (await _clienteClient.ConsultarFinanceiroAsync(clienteCid)).FirstOrDefault() ?? new dClienteFinanceiro { cliente_cid = clienteCid };
        Profissional = (await _clienteClient.ConsultarProfissionalAsync(clienteCid)).FirstOrDefault() ?? new dClienteProfissional { cliente_cid = clienteCid };
        Veiculos = await _clienteClient.ConsultarVeiculosAsync(clienteCid);
    }

    private async Task CarregarListasApoioAsync()
    {
        Estados = await _factory.Create<Modelos.dEstado>("Estado").ListarAsync();
        EstadosCivis = await _factory.Create<dEstadoCivil>("EstadoCivil").ListarAsync();
        Sexos = await _factory.Create<dSexo>("Sexo").ListarAsync();
        TiposResidencia = await _factory.Create<dTipoResidencia>("TipoResidencia").ListarAsync();
    }
}
