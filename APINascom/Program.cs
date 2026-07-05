using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositorios;
using Servicos;


var builder = WebApplication.CreateBuilder(args);

// Configura a connection string para a camada de repositórios
RepositorioBase.ConnectionString = builder.Configuration.GetConnectionString("nascomercio")
    ?? throw new InvalidOperationException("ConnectionString 'nascomercio' não encontrada no appsettings.json");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Informe o token JWT: Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// ── Autenticação JWT ────────────────────────────────────────────────────────
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key não configurada");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

// ── Repositórios ──────────────────────────────────────────────────────────────
builder.Services.AddScoped<IpCaixa, pCaixa>();
builder.Services.AddScoped<IpCaracteristica, pCaracteristica>();
builder.Services.AddScoped<IpCaracteristicaItem, pCaracteristicaItem>();
builder.Services.AddScoped<IpCategoria, pCategoria>();
builder.Services.AddScoped<IpCheques, pCheques>();
builder.Services.AddScoped<IpCliente, pCliente>();
builder.Services.AddScoped<IpClienteEndereco, pClienteEndereco>();
builder.Services.AddScoped<IpClienteFinanceiro, pClienteFinanceiro>();
builder.Services.AddScoped<IpClienteProfissional, pClienteProfissional>();
builder.Services.AddScoped<IpCobranca, pCobranca>();
builder.Services.AddScoped<IpCondicao, pCondicao>();
builder.Services.AddScoped<IpContasPagar, pContasPagar>();
builder.Services.AddScoped<IpCor, pCor>();
builder.Services.AddScoped<IpCrediario, pCrediario>();
builder.Services.AddScoped<IpEfdArquivo, pEfdArquivo>();
builder.Services.AddScoped<IpEfdContabilidade, pEfdContabilidade>();
builder.Services.AddScoped<IpEfdEnderecoContato, pEfdEnderecoContato>();
builder.Services.AddScoped<IpEfdEntidade, pEfdEntidade>();
builder.Services.AddScoped<IpEfdUnidadeMedida, pEfdUnidadeMedida>();
builder.Services.AddScoped<IpEstado, pEstado>();
builder.Services.AddScoped<IpFabricante, pFabricante>();
builder.Services.AddScoped<IpFornecedor, pFornecedor>();
builder.Services.AddScoped<IpGiro, pGiro>();
builder.Services.AddScoped<IpGradeItem, pGradeItem>();
builder.Services.AddScoped<IpGrupo, pGrupo>();
builder.Services.AddScoped<IpLoja, pLoja>();
builder.Services.AddScoped<IpMunicipios, pMunicipios>();
builder.Services.AddScoped<IpNotaFiscalFornecedor, pNotaFiscalFornecedor>();
builder.Services.AddScoped<IpOrdemServico, pOrdemServico>();
builder.Services.AddScoped<IpParametro, pParametro>();
builder.Services.AddScoped<IpParcela, pParcela>();
builder.Services.AddScoped<IpPix, pPix>();
builder.Services.AddScoped<IpPreVenda, pPreVenda>();
builder.Services.AddScoped<IpPreVendaProduto, pPreVendaProduto>();
builder.Services.AddScoped<IpProduto, pProduto>();
builder.Services.AddScoped<IpProdutoEtiqueta, pProdutoEtiqueta>();
builder.Services.AddScoped<IpProdutoItem, pProdutoItem>();
builder.Services.AddScoped<IpProdutoTipo, pProdutoTipo>();
builder.Services.AddScoped<IpProdutoTipoCaracteristica, pProdutoTipoCaracteristica>();
builder.Services.AddScoped<IpServico, pServico>();
builder.Services.AddScoped<IpUsuario, pUsuario>();
builder.Services.AddScoped<IpUsuarioPerfil, pUsuarioPerfil>();
builder.Services.AddScoped<IpVeiculos, pVeiculos>();
builder.Services.AddScoped<IpVenda, pVenda>();
builder.Services.AddScoped<IpVendaProduto, pVendaProduto>();

// ── Serviços ──────────────────────────────────────────────────────────────────
builder.Services.AddScoped<IsCaixa, rCaixa>();
builder.Services.AddScoped<IsCaracteristica, rCaracteristica>();
builder.Services.AddScoped<IsCaracteristicaItem, rCaracteristicaItem>();
builder.Services.AddScoped<IsCategoria, rCategoria>();
builder.Services.AddScoped<IsCheque, rCheque>();
builder.Services.AddScoped<IsCliente, rCliente>();
builder.Services.AddScoped<IsClienteEndereco, rClienteEndereco>();
builder.Services.AddScoped<IsClienteFinanceiro, rClienteFinanceiro>();
builder.Services.AddScoped<IsClienteProfissional, rClienteProfissional>();
builder.Services.AddScoped<IsCobranca, rCobranca>();
builder.Services.AddScoped<IsCondicao, rCondicao>();
builder.Services.AddScoped<IsContasPagar, rContasPagar>();
builder.Services.AddScoped<IsCor, rCor>();
builder.Services.AddScoped<IsCrediario, rCrediario>();
builder.Services.AddScoped<IsEfdArquivo, rEfdArquivo>();
builder.Services.AddScoped<IsEfdContabilidade, rEfdContabilidade>();
builder.Services.AddScoped<IsEfdEnderecoContato, rEfdEnderecoContato>();
builder.Services.AddScoped<IsEfdEntidade, rEfdEntidade>();
builder.Services.AddScoped<IsEfdFinalidadeArquivo, rEfdFinalidadeArquivo>();
builder.Services.AddScoped<IsEfdPerfilArquivoFiscal, rEfdPerfilArquivoFiscal>();
builder.Services.AddScoped<IsEfdTipoAtividade, rEfdTipoAtividade>();
builder.Services.AddScoped<IsEfdTipoPessoa, rEfdTipoPessoa>();
builder.Services.AddScoped<IsEfdUnidadeMedida, rEfdUnidadeMedida>();
builder.Services.AddScoped<IsEstado, rEstado>();
builder.Services.AddScoped<IsEstadoCivil, rEstadoCivil>();
builder.Services.AddScoped<IsFabricante, rFabricante>();
builder.Services.AddScoped<IsFornecedor, rFornecedor>();
builder.Services.AddScoped<IsGiro, rGiro>();
builder.Services.AddScoped<IsGradeItem, rGradeItem>();
builder.Services.AddScoped<IsGrupo, rGrupo>();
builder.Services.AddScoped<IsLoja, rLoja>();
builder.Services.AddScoped<IsMunicipios, rMunicipios>();
builder.Services.AddScoped<IsNotaFiscalFornecedor, rNotaFiscalFornecedor>();
builder.Services.AddScoped<IsOrdemServico, rOrdemServico>();
builder.Services.AddScoped<IsParametro, rParametro>();
builder.Services.AddScoped<IsPix, rPix>();
builder.Services.AddScoped<IsPixConfig, rPixConfig>();
builder.Services.AddScoped<IsPreVenda, rPreVenda>();
builder.Services.AddScoped<IsPreVendaProduto, rPreVendaProduto>();
builder.Services.AddScoped<IsProduto, rProduto>();
builder.Services.AddScoped<IsProdutoEtiqueta, rProdutoEtiqueta>();
builder.Services.AddScoped<IsProdutoItem, rProdutoItem>();
builder.Services.AddScoped<IsProdutoTipo, rProdutoTipo>();
builder.Services.AddScoped<IsProdutoTipoCaracteristica, rProdutoTipoCaracteristica>();
builder.Services.AddScoped<IsServico, rServico>();
builder.Services.AddScoped<IsSexo, rSexo>();
builder.Services.AddScoped<IsSimNao, rSimNao>();
builder.Services.AddScoped<IsSituacao, rSituacao>();
builder.Services.AddScoped<IsSituacaoNotaFiscal, rSituacaoNotaFiscal>();
builder.Services.AddScoped<IsTipoEmissao, rTipoEmissao>();
builder.Services.AddScoped<IsTipoFluxo, rTipoFluxo>();
builder.Services.AddScoped<IsTipoFrete, rTipoFrete>();
builder.Services.AddScoped<IsTipoNotaFiscal, rTipoNotaFiscal>();
builder.Services.AddScoped<IsTipoPagamento, rTipoPagamento>();
builder.Services.AddScoped<IsTipoResidencia, rTipoResidencia>();
builder.Services.AddScoped<IsJwt, rJwt>();
builder.Services.AddScoped<IpRefreshToken, pRefreshToken>();
builder.Services.AddScoped<IsRefreshToken, rRefreshToken>();
builder.Services.AddScoped<IsUsuario, rUsuario>();
builder.Services.AddScoped<IsUsuarioPerfil, rUsuarioPerfil>();
builder.Services.AddScoped<IsVeiculos, rVeiculos>();
builder.Services.AddScoped<IsVenda, rVenda>();
builder.Services.AddScoped<IsVendaProduto, rVendaProduto>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
