using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Caracteristica;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dCaracteristica> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dCaracteristica>("Caracteristica");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dCaracteristica> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dCaracteristica { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dCaracteristica { cid = cid });
        TempData["Mensagem"] = "Característica excluída com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
