using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Usuario;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dUsuario> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dUsuario>("Usuario");
    }

    [BindProperty(SupportsGet = true)]
    public string? NomeCompleto { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dUsuario> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dUsuario { nomeCompleto = NomeCompleto ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dUsuario { cid = cid });
        TempData["Mensagem"] = "Usuário excluído com sucesso.";
        return RedirectToPage(new { NomeCompleto, Situacao });
    }
}
