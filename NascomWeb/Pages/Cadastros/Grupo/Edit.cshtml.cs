using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Grupo;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dGrupo> _client;

    public EditModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dGrupo>("Grupo");
    }

    [BindProperty]
    public dGrupo Dados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dGrupo { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");

        if (!ModelState.IsValid) return Page();

        var incluindo = Dados.cid is null or 0;

        if (incluindo)
        {
            var duplicado = (await _client.ConsultarAsync(new dGrupo { nome = Dados.nome })).Count > 0;
            if (duplicado)
            {
                ModelState.AddModelError("Dados.nome", "Já existe um grupo cadastrado com este nome.");
                return Page();
            }

            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Grupo incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Grupo alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
