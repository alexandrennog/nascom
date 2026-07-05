using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.ProdutoTipo;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dProdutoTipo> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dProdutoTipo>("ProdutoTipo");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dProdutoTipo> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dProdutoTipo { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dProdutoTipo { cid = cid });
        TempData["Mensagem"] = "Tipo de produto excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
