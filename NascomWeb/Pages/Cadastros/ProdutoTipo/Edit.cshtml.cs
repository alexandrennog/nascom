using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.ProdutoTipo;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dProdutoTipo> _client;
    private readonly CrudApiClientFactory _factory;
    private readonly ProdutoTipoCaracteristicaApiClient _vinculoClient;

    public EditModel(CrudApiClientFactory factory, ProdutoTipoCaracteristicaApiClient vinculoClient)
    {
        _factory = factory;
        _client = factory.Create<dProdutoTipo>("ProdutoTipo");
        _vinculoClient = vinculoClient;
    }

    [BindProperty]
    public dProdutoTipo Dados { get; set; } = new() { situacao = "A" };

    [BindProperty]
    public int CaracteristicaSelecionada { get; set; }

    public List<dProdutoTipoCaracteristica> Caracteristicas { get; set; } = new();
    public List<dCaracteristica> TodasCaracteristicas { get; set; } = new();

    public bool TipoJaSalvo => Dados.cid is int cid && cid > 0;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dProdutoTipo { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
            await CarregarCaracteristicasAsync(cid);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");

        if (!ModelState.IsValid) return Page();

        if (Dados.cid is null or 0)
        {
            var novoCid = await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Tipo de produto incluído com sucesso.";
            return RedirectToPage(new { id = novoCid });
        }

        await _client.AlterarAsync(Dados);
        TempData["Mensagem"] = "Tipo de produto alterado com sucesso.";
        return RedirectToPage(new { id = Dados.cid });
    }

    public async Task<IActionResult> OnPostAdicionarCaracteristicaAsync(int id)
    {
        if (CaracteristicaSelecionada > 0)
        {
            await _vinculoClient.IncluirAsync(id, CaracteristicaSelecionada);
            TempData["Mensagem"] = "Característica vinculada com sucesso.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostRemoverCaracteristicaAsync(int id, int vinculoCid)
    {
        await _vinculoClient.ExcluirAsync(vinculoCid);
        TempData["Mensagem"] = "Vínculo removido com sucesso.";
        return RedirectToPage(new { id });
    }

    private async Task CarregarCaracteristicasAsync(int produtoTipoCid)
    {
        Caracteristicas = await _vinculoClient.ConsultarPorProdutoTipoAsync(produtoTipoCid);
        TodasCaracteristicas = await _factory.Create<dCaracteristica>("Caracteristica").ListarAsync();
    }
}
