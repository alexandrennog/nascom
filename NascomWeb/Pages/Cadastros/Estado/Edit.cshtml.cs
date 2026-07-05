using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Estado;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dEstado> _client;

    public EditModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dEstado>("Estado");
    }

    [BindProperty]
    public dEstado Dados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dEstado { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");
        if (string.IsNullOrWhiteSpace(Dados.sigla))
            ModelState.AddModelError("Dados.sigla", "É necessário informar a Sigla.");

        if (!ModelState.IsValid) return Page();

        var incluindo = Dados.cid is null or 0;

        if (incluindo)
        {
            var duplicado = (await _client.ConsultarAsync(new dEstado { sigla = Dados.sigla })).Count > 0;
            if (duplicado)
            {
                ModelState.AddModelError("Dados.sigla", "Já existe um estado cadastrado com esta sigla.");
                return Page();
            }

            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Estado incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Estado alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
