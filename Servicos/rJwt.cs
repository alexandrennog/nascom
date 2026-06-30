using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;

namespace Servicos
{
    public class rJwt : IsJwt
    {
        private readonly IConfiguration _configuracao;

        public rJwt(IConfiguration configuracao) { _configuracao = configuracao; }

        private static string MapearPerfil(string codigo)
        {
            return codigo switch
            {
                "a" => "Administrador",
                "g" => "Gerente",
                "c" => "Caixa",
                "v" => "Vendedor",
                _ => "Indefinido"
            };
        }

        public dTokenResposta GerarToken(dUsuario usuario)
        {
            var chave = _configuracao["Jwt:Key"]
                ?? throw new InvalidOperationException("Jwt:Key não configurada");
            var issuer = _configuracao["Jwt:Issuer"];
            var audience = _configuracao["Jwt:Audience"];
            var minutos = int.Parse(_configuracao["Jwt:ExpiracaoMinutos"] ?? "480");

            var perfil = MapearPerfil(usuario.usuarioPerfil_codigo);
            var expiracao = DateTime.UtcNow.AddMinutes(minutos);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.cid.ToString()),
                new Claim(ClaimTypes.Name, usuario.nomeCompleto ?? string.Empty),
                new Claim(ClaimTypes.Email, usuario.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, perfil),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var credenciais = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiracao,
                signingCredentials: credenciais);

            return new dTokenResposta
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao,
                NomeCompleto = usuario.nomeCompleto,
                Perfil = perfil
            };
        }
    }
}
