using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages;

[AllowAnonymous]
public class LoginModel : PageModel
{
    private readonly AuthApiClient _authApiClient;

    public LoginModel(AuthApiClient authApiClient)
    {
        _authApiClient = authApiClient;
    }

    [BindProperty]
    public string Usuario { get; set; } = string.Empty;

    [BindProperty]
    public string Senha { get; set; } = string.Empty;

    public string? ReturnUrl { get; set; }
    public string? Erro { get; set; }

    public void OnGet(string? returnUrl)
    {
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl)
    {
        ReturnUrl = returnUrl;

        if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Senha))
        {
            Erro = "Informe usuário e senha.";
            return Page();
        }

        var token = await _authApiClient.LoginAsync(Usuario, Senha);
        if (token == null)
        {
            Erro = "Usuário ou senha inválidos.";
            return Page();
        }

        // O cid do usuário vem do claim "sub" do próprio JWT emitido pela API (rJwt.GerarToken).
        // Não é exposto em dTokenResposta, mas é necessário para os endpoints que registram
        // auditoria (ex.: Produto incluircompleto/alterarcompleto exigem um dUsuario completo).
        var cidUsuario = ExtrairClaimSubDoJwt(token.Token);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, token.NomeCompleto ?? Usuario),
            new(ClaimTypes.Role, token.Perfil ?? string.Empty),
            new("login_usuario", Usuario)
        };
        if (!string.IsNullOrEmpty(cidUsuario))
            claims.Add(new Claim(ClaimTypes.NameIdentifier, cidUsuario));
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = new DateTimeOffset(token.RefreshTokenExpiracao, TimeSpan.Zero)
        };
        properties.StoreTokens(new[]
        {
            new AuthenticationToken { Name = "access_token", Value = token.Token },
            new AuthenticationToken { Name = "access_token_expires", Value = new DateTimeOffset(token.Expiracao, TimeSpan.Zero).ToString("o") },
            new AuthenticationToken { Name = "refresh_token", Value = token.RefreshToken }
        });

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);

        return RedirectToPage("/Index");
    }

    /// <summary>
    /// Decodifica manualmente o payload do JWT (sem validar assinatura — o token acabou de ser
    /// recebido da própria API via HTTPS) para ler o claim "sub", evitando depender do pacote
    /// System.IdentityModel.Tokens.Jwt (não referenciado no NascomWeb).
    /// </summary>
    private static string? ExtrairClaimSubDoJwt(string jwt)
    {
        var partes = jwt.Split('.');
        if (partes.Length < 2) return null;

        var payload = partes[1].Replace('-', '+').Replace('_', '/');
        switch (payload.Length % 4)
        {
            case 2: payload += "=="; break;
            case 3: payload += "="; break;
        }

        var json = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(payload));
        using var documento = JsonDocument.Parse(json);
        return documento.RootElement.TryGetProperty("sub", out var sub) ? sub.GetString() : null;
    }
}
