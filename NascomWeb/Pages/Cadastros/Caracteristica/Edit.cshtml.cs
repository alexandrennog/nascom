using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Caracteristica;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dCaracteristica> _client;
    private readonly CaracteristicaItemApiClient _itemClient;

    public EditModel(CrudApiClientFactory factory, CaracteristicaItemApiClient itemClient)
    {
        _client = factory.Create<dCaracteristica>("Caracteristica");
        _itemClient = itemClient;
    }

    [BindProperty]
    public dCaracteristica Dados { get; set; } = new() { situacao = "A" };

    [BindProperty]
    public string? NovoValor { get; set; }

    public List<dCaracteristicaItem> Itens { get; set; } = new();

    public bool CaracteristicaJaSalva => Dados.cid is int cid && cid > 0;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dCaracteristica { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
            Itens = await _itemClient.ConsultarPorCaracteristicaAsync(cid);
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
            var duplicado = (await _client.ConsultarAsync(new dCaracteristica { nome = Dados.nome })).Count > 0;
            if (duplicado)
            {
                ModelState.AddModelError("Dados.nome", "Já existe uma característica cadastrada com este nome.");
                return Page();
            }

            var novoCid = await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Característica incluída com sucesso.";
            return RedirectToPage(new { id = novoCid });
        }

        await _client.AlterarAsync(Dados);
        TempData["Mensagem"] = "Característica alterada com sucesso.";
        return RedirectToPage(new { id = Dados.cid });
    }

    public async Task<IActionResult> OnPostAdicionarItemAsync(int id)
    {
        if (!string.IsNullOrWhiteSpace(NovoValor))
        {
            await _itemClient.IncluirAsync(id, NovoValor);
            TempData["Mensagem"] = "Valor adicionado com sucesso.";
        }

        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostRemoverItemAsync(int id, int itemCid)
    {
        await _itemClient.ExcluirAsync(itemCid);
        TempData["Mensagem"] = "Valor removido com sucesso.";
        return RedirectToPage(new { id });
    }
}
