using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Parametro;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dParametro> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dParametro>("Parametro");
    }

    [BindProperty(SupportsGet = true)]
    public string? Descricao { get; set; }

    public List<dParametro> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dParametro { descricao = Descricao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dParametro { cid = cid });
        TempData["Mensagem"] = "Parâmetro excluído com sucesso.";
        return RedirectToPage(new { Descricao });
    }
}
