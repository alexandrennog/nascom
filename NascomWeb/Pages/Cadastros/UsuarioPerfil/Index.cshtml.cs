using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.UsuarioPerfil;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dUsuarioPerfil> _client;

    public IndexModel(CrudApiClientFactory factory)
    {
        _client = factory.Create<dUsuarioPerfil>("UsuarioPerfil");
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dUsuarioPerfil> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dUsuarioPerfil { nome = Nome ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dUsuarioPerfil { cid = cid });
        TempData["Mensagem"] = "Perfil excluído com sucesso.";
        return RedirectToPage(new { Nome, Situacao });
    }
}
