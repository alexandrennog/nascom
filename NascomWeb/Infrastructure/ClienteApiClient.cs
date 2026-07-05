using System.Net.Http.Json;
using Modelos;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client dedicado ao domínio Cliente: a entidade principal segue o padrão CRUD uniforme,
/// mas as sub-entidades (Endereço/Financeiro/Profissional) são 1:1 por cliente_cid (sem PK
/// própria) e Veículos é 1:N com PK própria — por isso não cabem no CrudApiClient genérico.
/// </summary>
public class ClienteApiClient
{
    private readonly HttpClient _http;

    public ClienteApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(CrudApiClientFactory.HttpClientName);
    }

    // ── Cliente (dados gerais) ──────────────────────────────────────────────
    public Task<List<dCliente>> ConsultarAsync(dCliente filtro) => PostELerListaAsync<dCliente>("api/Cliente/consultar", filtro);

    public async Task<int> IncluirAsync(dCliente dados)
    {
        var resposta = await _http.PostAsJsonAsync("api/Cliente/incluir", dados);
        await GarantirSucessoAsync(resposta);
        return await resposta.Content.ReadFromJsonAsync<int>();
    }

    public async Task AlterarAsync(dCliente dados)
    {
        var resposta = await _http.PutAsJsonAsync("api/Cliente/alterar", dados);
        await GarantirSucessoAsync(resposta);
    }

    public async Task ExcluirAsync(int cid)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "api/Cliente/excluir")
        {
            Content = JsonContent.Create(new dCliente { cid = cid })
        };
        await GarantirSucessoAsync(await _http.SendAsync(request));
    }

    // ── Endereço (1:1 por cliente_cid, sem PK própria: upsert = excluir + incluir) ──
    public Task<List<dClienteEndereco>> ConsultarEnderecoAsync(int clienteCid)
        => PostELerListaAsync<dClienteEndereco>("api/ClienteEndereco/consultar", new dClienteEndereco { cliente_cid = clienteCid });

    public async Task SalvarEnderecoAsync(dClienteEndereco dados)
    {
        await ExcluirEnderecoPorClienteAsync(dados.cliente_cid!.Value);
        var resposta = await _http.PostAsJsonAsync("api/ClienteEndereco/incluir", dados);
        await GarantirSucessoAsync(resposta);
    }

    public async Task ExcluirEnderecoPorClienteAsync(int clienteCid)
        => await GarantirSucessoAsync(await _http.DeleteAsync($"api/ClienteEndereco/excluirporcliente?cliente_cid={clienteCid}"));

    // ── Financeiro (1:1 por cliente_cid, com Alterar: upsert = consulta e decide) ──
    public Task<List<dClienteFinanceiro>> ConsultarFinanceiroAsync(int clienteCid)
        => PostELerListaAsync<dClienteFinanceiro>("api/ClienteFinanceiro/consultar", new dClienteFinanceiro { cliente_cid = clienteCid });

    public async Task SalvarFinanceiroAsync(dClienteFinanceiro dados)
    {
        var existente = await ConsultarFinanceiroAsync(dados.cliente_cid!.Value);
        if (existente.Count > 0)
            await GarantirSucessoAsync(await _http.PutAsJsonAsync("api/ClienteFinanceiro/alterar", dados));
        else
            await GarantirSucessoAsync(await _http.PostAsJsonAsync("api/ClienteFinanceiro/incluir", dados));
    }

    // ── Profissional (mesma forma do Financeiro) ────────────────────────────
    public Task<List<dClienteProfissional>> ConsultarProfissionalAsync(int clienteCid)
        => PostELerListaAsync<dClienteProfissional>("api/ClienteProfissional/consultar", new dClienteProfissional { cliente_cid = clienteCid });

    public async Task SalvarProfissionalAsync(dClienteProfissional dados)
    {
        var existente = await ConsultarProfissionalAsync(dados.cliente_cid!.Value);
        if (existente.Count > 0)
            await GarantirSucessoAsync(await _http.PutAsJsonAsync("api/ClienteProfissional/alterar", dados));
        else
            await GarantirSucessoAsync(await _http.PostAsJsonAsync("api/ClienteProfissional/incluir", dados));
    }

    // ── Veículos (1:N, com PK própria) ──────────────────────────────────────
    public Task<List<dVeiculos>> ConsultarVeiculosAsync(int clienteId)
        => PostELerListaAsync<dVeiculos>("api/Veiculos/consultar", new dVeiculos { clienteId = clienteId });

    public async Task AdicionarVeiculoAsync(dVeiculos dados)
        => await GarantirSucessoAsync(await _http.PostAsJsonAsync("api/Veiculos/incluir2", dados));

    public async Task RemoverVeiculoAsync(int cid)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, "api/Veiculos/excluir")
        {
            Content = JsonContent.Create(new dVeiculos { cid = cid })
        };
        await GarantirSucessoAsync(await _http.SendAsync(request));
    }

    private async Task<List<T>> PostELerListaAsync<T>(string url, object filtro)
    {
        var resposta = await _http.PostAsJsonAsync(url, filtro);
        await GarantirSucessoAsync(resposta);
        if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent) return new List<T>();
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
