using System;

namespace Modelos
{
    public class dRefreshToken
    {
        public int? cid { get; set; }
        public int? usuario_cid { get; set; }
        public string token { get; set; }
        public DateTime expiracao { get; set; }
        public bool revogado { get; set; }
    }

    public class dRefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}
