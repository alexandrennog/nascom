using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Usuario;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dUsuario> _client;
    private readonly CrudApiClientFactory _factory;

    public EditModel(CrudApiClientFactory factory)
    {
        _factory = factory;
        _client = factory.Create<dUsuario>("Usuario");
    }

    [BindProperty]
    public dUsuario Dados { get; set; } = new() { situacao = "A" };

    /// <summary>Campo separado para nunca exibir o hash da senha existente no formulário.</summary>
    [BindProperty]
    public string? NovaSenha { get; set; }

    public List<dUsuarioPerfil> Perfis { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Perfis = await _factory.Create<dUsuarioPerfil>("UsuarioPerfil").ListarAsync();

        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dUsuario { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            existente.senha = string.Empty;
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var incluindo = Dados.cid is null or 0;

        if (string.IsNullOrWhiteSpace(Dados.usuario))
            ModelState.AddModelError("Dados.usuario", "É necessário informar o Usuário.");
        if (string.IsNullOrWhiteSpace(Dados.nomeCompleto))
            ModelState.AddModelError("Dados.nomeCompleto", "É necessário informar o Nome Completo.");
        if (Dados.usuarioPerfil_cid is null or 0)
            ModelState.AddModelError("Dados.usuarioPerfil_cid", "É necessário selecionar o Perfil.");
        if (incluindo && string.IsNullOrWhiteSpace(NovaSenha))
            ModelState.AddModelError(nameof(NovaSenha), "É necessário informar a Senha para um novo usuário.");

        if (!ModelState.IsValid)
        {
            Perfis = await _factory.Create<dUsuarioPerfil>("UsuarioPerfil").ListarAsync();
            return Page();
        }

        Dados.senha = NovaSenha ?? string.Empty;

        if (incluindo)
        {
            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Usuário incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Usuário alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
