using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Loja;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dLoja> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dLoja>("Loja");
    }

    [BindProperty(SupportsGet = true)]
    public string? NomeFantasia { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dLoja> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dLoja { nomeFantasia = NomeFantasia ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dLoja { cid = cid });
        TempData["Mensagem"] = "Loja excluída com sucesso.";
        return RedirectToPage(new { NomeFantasia, Situacao });
    }
}
