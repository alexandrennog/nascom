using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Parametro;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dParametro> _client;

    public EditModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dParametro>("Parametro");
    }

    [BindProperty]
    public dParametro Dados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dParametro { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.descricao))
            ModelState.AddModelError("Dados.descricao", "É necessário informar a Descrição.");

        if (!ModelState.IsValid) return Page();

        if (Dados.cid is null or 0)
        {
            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Parâmetro incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Parâmetro alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
