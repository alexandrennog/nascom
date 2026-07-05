using System.Net.Http.Json;
using Modelos;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client dedicado ao vínculo ProdutoTipo &lt;-&gt; Característica (tabela de junção,
/// PK própria mas consultada/excluída por produtoTipo_cid via querystring).
/// </summary>
public class ProdutoTipoCaracteristicaApiClient
{
    private readonly HttpClient _http;

    public ProdutoTipoCaracteristicaApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(CrudApiClientFactory.HttpClientName);
    }

    public async Task<List<dProdutoTipoCaracteristica>> ConsultarPorProdutoTipoAsync(int produtoTipoCid)
    {
        var resposta = await _http.PostAsync($"api/ProdutoTipoCaracteristica/consultarporprodutotipo?produtoTipo_cid={produtoTipoCid}", null);
        await GarantirSucessoAsync(resposta);
        var lista = await resposta.Content.ReadFromJsonAsync<List<dProdutoTipoCaracteristica>>();
        return lista ?? new List<dProdutoTipoCaracteristica>();
    }

    public async Task IncluirAsync(int produtoTipoCid, int caracteristicaCid)
    {
        var resposta = await _http.PostAsJsonAsync("api/ProdutoTipoCaracteristica/incluir", new dProdutoTipoCaracteristica
        {
            produtoTipo_cid = produtoTipoCid,
            caracteristica_cid = caracteristicaCid
        });
        await GarantirSucessoAsync(resposta);
    }

    public async Task ExcluirAsync(int cid)
        => await GarantirSucessoAsync(await _http.DeleteAsync($"api/ProdutoTipoCaracteristica/excluir?cid={cid}"));

    private static async Task GarantirSucessoAsync(HttpResponseMessage resposta)
    {
        if (resposta.IsSuccessStatusCode) return;
        if (resposta.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new ApiUnauthorizedException();

        var mensagem = await resposta.Content.ReadAsStringAsync();
        throw new ApiException(string.IsNullOrWhiteSpace(mensagem) ? "Falha ao comunicar com a API." : mensagem);
    }
}
