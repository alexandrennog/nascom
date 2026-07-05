using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Condicao;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dCondicao> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dCondicao>("Condicao");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dCondicao> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dCondicao { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dCondicao { cid = cid });
        TempData["Mensagem"] = "Condição excluída com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
