using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Produto;

public class IndexModel : PageModel
{
    private readonly ProdutoApiClient _client;

    public IndexModel(ProdutoApiClient client)
    {
        _client = client;
    }

    [BindProperty(SupportsGet = true)]
    public string? Descricao { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Situacao { get; set; }

    public List<dProduto> Resultados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Resultados = await _client.ConsultarAsync(new dProduto { descricao = Descricao ?? string.Empty, situacao = Situacao ?? string.Empty });
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        var produto = await _client.ConsultarPorCidAsync(cid);
        if (produto != null)
        {
            await _client.ExcluirAsync(produto, ObterUsuarioLogado());
            TempData["Mensagem"] = "Produto excluído com sucesso.";
        }

        return RedirectToPage(new { Descricao, Situacao });
    }

    private dUsuario ObterUsuarioLogado()
    {
        var cidStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return new dUsuario
        {
            cid = int.TryParse(cidStr, out var cid) ? cid : null,
            usuario = User.FindFirst("login_usuario")?.Value ?? string.Empty,
            nomeCompleto = User.Identity?.Name ?? string.Empty
        };
    }
}
