using System.Net.Http.Json;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client HTTP genérico para o padrão de endpoints da API (listar/consultar/incluir/alterar/excluir),
/// parametrizado pelo DTO da entidade (reaproveitado do projeto Modelos). Evita reescrever a mesma
/// chamada HTTP para cada uma das entidades de cadastro.
/// </summary>
public class CrudApiClient<TDto> where TDto : class
{
    private readonly HttpClient _http;
    private readonly string _recurso;

    public CrudApiClient(HttpClient http, string recurso)
    {
        _http = http;
        _recurso = recurso;
    }

    public async Task<List<TDto>> ListarAsync()
    {
        var resposta = await _http.GetAsync($"api/{_recurso}/listar");
        return await LerListaOuVaziaAsync(resposta);
    }

    public async Task<List<TDto>> ConsultarAsync(TDto filtro)
    {
        var resposta = await _http.PostAsJsonAsync($"api/{_recurso}/consultar", filtro);
        return await LerListaOuVaziaAsync(resposta);
    }

    public async Task<int> IncluirAsync(TDto dados)
    {
        var resposta = await _http.PostAsJsonAsync($"api/{_recurso}/incluir", dados);
        await GarantirSucessoAsync(resposta);
        return await resposta.Content.ReadFromJsonAsync<int>();
    }

    public async Task AlterarAsync(TDto dados)
    {
        var resposta = await _http.PutAsJsonAsync($"api/{_recurso}/alterar", dados);
        await GarantirSucessoAsync(resposta);
    }

    public async Task ExcluirAsync(TDto dados)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"api/{_recurso}/excluir")
        {
            Content = JsonContent.Create(dados)
        };
        var resposta = await _http.SendAsync(request);
        await GarantirSucessoAsync(resposta);
    }

    private static async Task<List<TDto>> LerListaOuVaziaAsync(HttpResponseMessage resposta)
    {
        await GarantirSucessoAsync(resposta);
        if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent) return new List<TDto>();
        var lista = await resposta.Content.ReadFromJsonAsync<List<TDto>>();
        return lista ?? new List<TDto>();
    }

    private static async Task GarantirSucessoAsync(HttpResponseMessage resposta)
    {
        if (resposta.IsSuccessStatusCode) return;
        if (resposta.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new ApiUnauthorizedException();

        var mensagem = await resposta.Content.ReadAsStringAsync();
        throw new ApiException(string.IsNullOrWhiteSpace(mensagem) ? "Falha ao comunicar com a API." : mensagem);
    }
}
