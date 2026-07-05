using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NascomWeb.Infrastructure;

/// <summary>
/// Filtro global: qualquer ApiUnauthorizedException (token/refresh inválido ou expirado)
/// derruba a sessão local e manda para o Login, em vez de estourar erro 500 na página.
/// </summary>
public class UnauthorizedRedirectFilter : IAsyncExceptionFilter
{
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is not ApiUnauthorizedException) return;

        await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        var returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
        context.Result = new RedirectToPageResult("/Login", new { returnUrl });
        context.ExceptionHandled = true;
    }
}
