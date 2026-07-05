using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Cor;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dCor> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dCor>("Cor");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dCor> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dCor { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dCor { cid = cid });
        TempData["Mensagem"] = "Cor excluída com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
