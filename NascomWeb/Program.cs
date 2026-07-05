using Microsoft.AspNetCore.Authentication.Cookies;
using NascomWeb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new UnauthorizedRedirectFilter());
    options.Conventions.AuthorizeFolder("/Cadastros");
});

builder.Services.AddHttpContextAccessor();

// ── Autenticação: cookie local guarda o JWT da API (nunca exposto ao navegador/JS) ──
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Login";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // acompanha a validade do refresh token
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });
builder.Services.AddAuthorization();

// ── HTTP clients para a APINascom ───────────────────────────────────────────────
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"]
    ?? throw new InvalidOperationException("ApiSettings:BaseUrl não configurada");

// Client "cru" usado só pelo AuthController (login/refresh/logout) - sem o forwarding handler,
// para não entrar em loop de refresh.
builder.Services.AddHttpClient<AuthApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddTransient<JwtForwardingHandler>();
builder.Services.AddHttpClient(CrudApiClientFactory.HttpClientName, client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<JwtForwardingHandler>();

builder.Services.AddScoped<CrudApiClientFactory>();
builder.Services.AddScoped<ClienteApiClient>();
builder.Services.AddScoped<ProdutoTipoCaracteristicaApiClient>();
builder.Services.AddScoped<ProdutoApiClient>();
builder.Services.AddScoped<CaracteristicaItemApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
