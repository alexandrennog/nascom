using System.Net.Http.Json;
using Modelos;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client dedicado ao domínio Produto. A grade (variações de tamanho/cor/etc.) é modelada na API
/// como linhas EAV em ProdutoItem (uma linha por característica, agrupadas por "item"), e qualquer
/// gravação de produto com grade (incluircompleto/alterarcompleto) reescreve TODAS as linhas —
/// por isso é preciso sempre reenviar as linhas existentes junto com a nova ao salvar.
/// </summary>
public class ProdutoApiClient
{
    private readonly HttpClient _http;

    public ProdutoApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(CrudApiClientFactory.HttpClientName);
    }

    public Task<List<dProduto>> ConsultarAsync(dProduto filtro) => PostELerListaAsync<dProduto>("api/Produto/consultar", filtro);

    public async Task<dProduto?> ConsultarPorCidAsync(int cid)
    {
        var resposta = await _http.GetAsync($"api/Produto/consultar/{cid}");
        await GarantirSucessoAsync(resposta);
        return await resposta.Content.ReadFromJsonAsync<dProduto>();
    }

    public async Task<int> IncluirCompletoAsync(dProduto dados, List<List<dProdutoItem>> colecaoItem, dUsuario usuario)
    {
        var resposta = await _http.PostAsJsonAsync("api/Produto/incluircompleto", new
        {
            Dados = dados,
            ColecaoItem = colecaoItem,
            Usuario = usuario
        });
        await GarantirSucessoAsync(resposta);
        return await resposta.Content.ReadFromJsonAsync<int>();
    }

    public async Task AlterarCompletoAsync(dProduto dados, List<List<dProdutoItem>> colecaoItem, dUsuario usuario)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, "api/Produto/alterarcompleto")
        {
            Content = JsonContent.Create(new
            {
                Dados = dados,
                ColecaoItem = colecaoItem,
                Usuario = usuario
            })
        };
        await GarantirSucessoAsync(await _http.SendAsync(request));
    }

    public async Task ExcluirAsync(dProduto dados, dUsuario usuario)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "api/Produto/excluir")
        {
            Content = JsonContent.Create(new { Dados = dados, Usuario = usuario })
        };
        await GarantirSucessoAsync(await _http.SendAsync(request));
    }

    // ── Grade (ProdutoItem, EAV) ─────────────────────────────────────────────
    public async Task<List<dProdutoItem>> ConsultarGradePorProdutoAsync(int produtoCid)
    {
        var resposta = await _http.PostAsync($"api/ProdutoItem/consultarporproduto?produto_cid={produtoCid}", null);
        await GarantirSucessoAsync(resposta);
        var lista = await resposta.Content.ReadFromJsonAsync<List<dProdutoItem>>();
        return lista ?? new List<dProdutoItem>();
    }

    private async Task<List<T>> PostELerListaAsync<T>(string url, object filtro)
    {
        var resposta = await _http.PostAsJsonAsync(url, filtro);
        await GarantirSucessoAsync(resposta);
        var lista = await resposta.Content.ReadFromJsonAsync<List<T>>();
        return lista ?? new List<T>();
    }

    private static async Task GarantirSucessoAsync(HttpResponseMessage resposta)
    {
        if (resposta.IsSuccessStatusCode) return;
        if (resposta.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new ApiUnauthorizedException();

        var mensagem = await resposta.Content.ReadAsStringAsync();
        throw new ApiException(string.IsNullOrWhiteSpace(mensagem) ? "Falha ao comunicar com a API." : mensagem);
    }
}
