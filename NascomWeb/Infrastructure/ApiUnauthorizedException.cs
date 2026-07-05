namespace NascomWeb.Infrastructure;

/// <summary>
/// Lançada quando a API responde 401 mesmo após a tentativa de silent refresh do JwtForwardingHandler.
/// Capturada globalmente pelo UnauthorizedRedirectFilter para deslogar e redirecionar ao /Login.
/// </summary>
public class ApiUnauthorizedException : Exception
{
    public ApiUnauthorizedException() : base("Sessão expirada ou inválida.") { }
}
