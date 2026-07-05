using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Fabricante;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dFabricante> _client;

    public EditModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dFabricante>("Fabricante");
    }

    [BindProperty]
    public dFabricante Dados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dFabricante { cid = cid })).FirstOrDefault();
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
            var duplicado = (await _client.ConsultarAsync(new dFabricante { nome = Dados.nome })).Count > 0;
            if (duplicado)
            {
                ModelState.AddModelError("Dados.nome", "Já existe um fabricante cadastrado com este nome.");
                return Page();
            }

            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Fabricante incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Fabricante alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
