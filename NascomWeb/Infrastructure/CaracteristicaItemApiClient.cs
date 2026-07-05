using System.Net.Http.Json;
using Modelos;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client dedicado aos valores possíveis de uma Característica (ex.: "Tamanho" -> P/M/G),
/// 1:N por caracteristicas_cid, com PK própria.
/// </summary>
public class CaracteristicaItemApiClient
{
    private readonly HttpClient _http;

    public CaracteristicaItemApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(CrudApiClientFactory.HttpClientName);
    }

    public async Task<List<dCaracteristicaItem>> ConsultarPorCaracteristicaAsync(int caracteristicaCid)
    {
        var resposta = await _http.PostAsync($"api/CaracteristicaItem/consultarporcaracteristica?caracteristica_cid={caracteristicaCid}", null);
        await GarantirSucessoAsync(resposta);
        var lista = await resposta.Content.ReadFromJsonAsync<List<dCaracteristicaItem>>();
        return lista ?? new List<dCaracteristicaItem>();
    }

    public async Task IncluirAsync(int caracteristicaCid, string valor)
    {
        var resposta = await _http.PostAsJsonAsync("api/CaracteristicaItem/incluir", new dCaracteristicaItem
        {
            caracteristicas_cid = caracteristicaCid,
            valor = valor
        });
        await GarantirSucessoAsync(resposta);
    }

    public async Task ExcluirAsync(int cid)
        => await GarantirSucessoAsync(await _http.DeleteAsync($"api/CaracteristicaItem/excluirporcid?cid={cid}"));

    private static async Task GarantirSucessoAsync(HttpResponseMessage resposta)
    {
        if (resposta.IsSuccessStatusCode) return;
        if (resposta.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new ApiUnauthorizedException();

        var mensagem = await resposta.Content.ReadAsStringAsync();
        throw new ApiException(string.IsNullOrWhiteSpace(mensagem) ? "Falha ao comunicar com a API." : mensagem);
    }
}
