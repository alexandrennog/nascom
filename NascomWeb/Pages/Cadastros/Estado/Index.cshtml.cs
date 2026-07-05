using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Estado;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dEstado> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dEstado>("Estado");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dEstado> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dEstado { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dEstado { cid = cid });
        TempData["Mensagem"] = "Estado excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
