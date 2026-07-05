using System.Net.Http.Json;
using Modelos;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Client dedicado ao Auth, usando um HttpClient "cru" (sem o JwtForwardingHandler),
/// para não entrar em loop de refresh ao chamar login/refresh/logout.
/// </summary>
public class AuthApiClient
{
    private readonly HttpClient _http;

    public AuthApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<dTokenResposta?> LoginAsync(string usuario, string senha)
    {
        var resposta = await _http.PostAsJsonAsync("api/Auth/login", new dLogin { Usuario = usuario, Senha = senha });
        if (!resposta.IsSuccessStatusCode) return null;
        return await resposta.Content.ReadFromJsonAsync<dTokenResposta>();
    }

    public async Task<dTokenResposta?> RefreshAsync(string refreshToken)
    {
        var resposta = await _http.PostAsJsonAsync("api/Auth/refresh", new dRefreshTokenRequest { RefreshToken = refreshToken });
        if (!resposta.IsSuccessStatusCode) return null;
        return await resposta.Content.ReadFromJsonAsync<dTokenResposta>();
    }

    public async Task LogoutAsync(string refreshToken)
    {
        try
        {
            await _http.PostAsJsonAsync("api/Auth/logout", new dRefreshTokenRequest { RefreshToken = refreshToken });
        }
        catch
        {
            // Best-effort: se a API estiver fora, ainda assim encerramos a sessão local.
        }
    }
}
