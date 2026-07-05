using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Fornecedor;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dFornecedor> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dFornecedor>("Fornecedor");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dFornecedor> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dFornecedor { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dFornecedor { cid = cid });
        TempData["Mensagem"] = "Fornecedor excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
