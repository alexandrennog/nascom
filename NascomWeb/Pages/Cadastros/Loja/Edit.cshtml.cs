using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Loja;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dLoja> _client;
    private readonly CrudApiClientFactory _factory;

    public EditModel(CrudApiClientFactory factory)
    {
        _factory = factory;
        _client = factory.Create<dLoja>("Loja");
    }

    [BindProperty]
    public dLoja Dados { get; set; } = new() { situacao = "A" };

    public List<dEstado> Estados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Estados = await _factory.Create<dEstado>("Estado").ListarAsync();

        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dLoja { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nomeFantasia))
            ModelState.AddModelError("Dados.nomeFantasia", "É necessário informar o Nome Fantasia.");

        if (!ModelState.IsValid)
        {
            Estados = await _factory.Create<dEstado>("Estado").ListarAsync();
            return Page();
        }

        if (Dados.cid is null or 0)
        {
            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Loja incluída com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Loja alterada com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
