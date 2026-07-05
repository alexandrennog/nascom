using System;

namespace Modelos
{
    public class dTokenResposta
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiracao { get; set; }
        public string NomeCompleto { get; set; }
        public string Perfil { get; set; }
    }
}
