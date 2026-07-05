using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.UsuarioPerfil;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dUsuarioPerfil> _client;

    public EditModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dUsuarioPerfil>("UsuarioPerfil");
    }

    [BindProperty]
    public dUsuarioPerfil Dados { get; set; } = new() { situacao = "A" };

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dUsuarioPerfil { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");
        if (string.IsNullOrWhiteSpace(Dados.codigo))
            ModelState.AddModelError("Dados.codigo", "É necessário informar o Código.");

        if (!ModelState.IsValid) return Page();

        if (Dados.cid is null or 0)
        {
            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Perfil incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Perfil alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
