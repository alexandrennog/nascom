using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Municipios;

public class EditModel : PageModel
{
    private readonly CrudApiClient<dMunicipios> _client;
    private readonly CrudApiClientFactory _factory;

    public EditModel(CrudApiClientFactory factory)
    {
        _factory = factory;
        _client = factory.Create<dMunicipios>("Municipios");
    }

    [BindProperty]
    public dMunicipios Dados { get; set; } = new() { situacao = "A" };

    public List<dEstado> Estados { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Estados = await _factory.Create<dEstado>("Estado").ListarAsync();

        if (id is int cid && cid > 0)
        {
            var existente = (await _client.ConsultarAsync(new dMunicipios { cid = cid })).FirstOrDefault();
            if (existente == null) return RedirectToPage("Index");
            Dados = existente;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(Dados.nome))
            ModelState.AddModelError("Dados.nome", "É necessário informar o Nome.");
        if (Dados.estados_cid <= 0)
            ModelState.AddModelError("Dados.estados_cid", "É necessário selecionar o Estado.");

        if (!ModelState.IsValid)
        {
            Estados = await _factory.Create<dEstado>("Estado").ListarAsync();
            return Page();
        }

        if (Dados.cid is null or 0)
        {
            await _client.IncluirAsync(Dados);
            TempData["Mensagem"] = "Município incluído com sucesso.";
        }
        else
        {
            await _client.AlterarAsync(Dados);
            TempData["Mensagem"] = "Município alterado com sucesso.";
        }

        return RedirectToPage("Index");
    }
}
