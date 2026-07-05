using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages.Cadastros.Municipios;

public class IndexModel : PageModel
{
    private readonly CrudApiClient<dMunicipios> _client;
    private readonly CrudApiClientFactory _factory;
    private readonly HttpClient _http;

    public IndexModel(CrudApiClientFactory factory, IHttpClientFactory httpClientFactory)
    {
        _factory = factory;
        _client = factory.Create<dMunicipios>("Municipios");
        _http = httpClientFactory.CreateClient(CrudApiClientFactory.HttpClientName);
    }

    [BindProperty(SupportsGet = true)]
    public string? Nome { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? EstadoCid { get; set; }

    public List<dMunicipios> Resultados { get; set; } = new();
    public List<dEstado> Estados { get; set; } = new();

    public async Task OnGetAsync()
    {
        Estados = await _factory.Create<dEstado>("Estado").ListarAsync();

        if (EstadoCid is int estadoCid && estadoCid > 0)
        {
            var resposta = await _http.GetAsync($"api/Municipios/listarporestados?estados_cid={estadoCid}");
            if (!resposta.IsSuccessStatusCode)
            {
                if (resposta.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new ApiUnauthorizedException();
                throw new ApiException(await resposta.Content.ReadAsStringAsync());
            }

            var lista = await resposta.Content.ReadFromJsonAsync<List<dMunicipios>>();
            Resultados = lista ?? new List<dMunicipios>();

            if (!string.IsNullOrWhiteSpace(Nome))
                Resultados = Resultados.Where(m => m.nome?.Contains(Nome, StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
        else
        {
            Resultados = await _client.ConsultarAsync(new dMunicipios { nome = Nome ?? string.Empty });
        }
    }

    public async Task<IActionResult> OnPostExcluirAsync(int cid)
    {
        await _client.ExcluirAsync(new dMunicipios { cid = cid });
        TempData["Mensagem"] = "Município excluído com sucesso.";
        return RedirectToPage(new { Nome, EstadoCid });
    }
}
