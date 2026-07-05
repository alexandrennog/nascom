using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Cliente;

public class IndexModel : PageModel
{
    private readonly ClienteApiClient _client;

    public IndexModel(ClienteApiClient client)
    {
        _client = client;
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dCliente> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dCliente { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(cid);
        TempData["Mensagem"] = "Cliente excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
