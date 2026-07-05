using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Grupo;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dGrupo> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dGrupo>("Grupo");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dGrupo> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dGrupo { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dGrupo { cid = cid });
        TempData["Mensagem"] = "Grupo excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
