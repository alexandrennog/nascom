using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Fabricante;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dFabricante> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dFabricante>("Fabricante");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dFabricante> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dFabricante { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dFabricante { cid = cid });
        TempData["Mensagem"] = "Fabricante excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
