using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Categoria;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dCategoria> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dCategoria>("Categoria");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dCategoria> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dCategoria { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dCategoria { cid = cid });
        TempData["Mensagem"] = "Categoria excluída com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
