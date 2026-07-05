using System;
using System.Security.Cryptography;
using Comum;
using Microsoft.Extensions.Configuration;
using Repositorios;
using Modelos;

namespace Servicos
{
    public class rRefreshToken : IsRefreshToken
    {
        private readonly IpRefreshToken _repo;
        private readonly IConfiguration _configuracao;

        public rRefreshToken(IpRefreshToken repo, IConfiguration configuracao)
        {
            _repo = repo;
            _configuracao = configuracao;
        }

        public dRefreshToken Gerar(int usuarioCid)
        {
            try
            {
                var dias = int.Parse(_configuracao["Jwt:RefreshExpiracaoDias"] ?? "7");

                var dados = new dRefreshToken
                {
                    usuario_cid = usuarioCid,
                    token = GerarTokenOpaco(),
                    expiracao = DateTime.UtcNow.AddDays(dias)
                };

                dados.cid = _repo.Incluir(dados);
                return dados;
            }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Gerar RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public dRefreshToken ConsultarValido(string token)
        {
            try { return _repo.ConsultarValido(token); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em ConsultarValido RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public void Revogar(string token)
        {
            try { _repo.Revogar(token); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em Revogar RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        public void RevogarTodosPorUsuario(int usuarioCid)
        {
            try { _repo.RevogarTodosPorUsuario(usuarioCid); }
            catch (ExcecaoNascomercio) { throw; }
            catch (Exception ex) { throw new ExcecaoNascomercio("Erro em RevogarTodosPorUsuario RefreshToken [" + ToString() + "] - " + ex.Message); }
        }

        private static string GerarTokenOpaco()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }
    }
}
