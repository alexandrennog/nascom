using Modelos;

namespace Servicos
{
    public interface IsRefreshToken
    {
        dRefreshToken Gerar(int usuarioCid);
        dRefreshToken ConsultarValido(string token);
        void Revogar(string token);
        void RevogarTodosPorUsuario(int usuarioCid);
    }
}
