using Modelos;

namespace Servicos
{
    public interface IsJwt
    {
        dTokenResposta GerarToken(dUsuario usuario);
    }
}
