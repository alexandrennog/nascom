using System.Globalization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Anexa o access token JWT (guardado no cookie de autenticação) em toda chamada à API.
/// Se o token estiver perto de expirar, faz o silent refresh via /api/Auth/refresh antes
/// de prosseguir, atualizando o cookie com o novo par access/refresh token.
/// </summary>
public class JwtForwardingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AuthApiClient _authApiClient;

    public JwtForwardingHandler(IHttpContextAccessor httpContextAccessor, AuthApiClient authApiClient)
    {
        _httpContextAccessor = httpContextAccessor;
        _authApiClient = authApiClient;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            var accessToken = await httpContext.GetTokenAsync("access_token");
            var expiresRaw = await httpContext.GetTokenAsync("access_token_expires");
            var refreshToken = await httpContext.GetTokenAsync("refresh_token");

            var expirado = DateTimeOffset.TryParse(expiresRaw, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var expira)
                && expira <= DateTimeOffset.UtcNow.AddSeconds(30);

            if (expirado && !string.IsNullOrEmpty(refreshToken))
            {
                var renovado = await _authApiClient.RefreshAsync(refreshToken);
                if (renovado != null)
                {
                    accessToken = renovado.Token;
                    await AtualizarTokensNoCookieAsync(httpContext, renovado.Token, renovado.Expiracao, renovado.RefreshToken);
                }
            }

            if (!string.IsNullOrEmpty(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            throw new ApiUnauthorizedException();

        return response;
    }

    internal static async Task AtualizarTokensNoCookieAsync(HttpContext httpContext, string accessToken, DateTime accessExpiraUtc, string refreshToken)
    {
        var authResult = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!authResult.Succeeded || authResult.Principal == null) return;

        var properties = authResult.Properties ?? new AuthenticationProperties();
        properties.UpdateTokenValue("access_token", accessToken);
        properties.UpdateTokenValue("access_token_expires", new DateTimeOffset(accessExpiraUtc, TimeSpan.Zero).ToString("o", CultureInfo.InvariantCulture));
        properties.UpdateTokenValue("refresh_token", refreshToken);

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, authResult.Principal, properties);
    }
}
