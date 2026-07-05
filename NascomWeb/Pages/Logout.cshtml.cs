using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NascomWeb.Infrastructure;

namespace NascomWeb.Pages;

public class LogoutModel : PageModel
{
    private readonly AuthApiClient _authApiClient;

    public LogoutModel(AuthApiClient authApiClient)
    {
        _authApiClient = authApiClient;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
        if (!string.IsNullOrEmpty(refreshToken))
            await _authApiClient.LogoutAsync(refreshToken);

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Login");
    }
}
