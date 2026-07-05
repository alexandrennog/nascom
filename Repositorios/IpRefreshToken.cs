using Modelos;

namespace Repositorios
{
    public interface IpRefreshToken
    {
        int Incluir(dRefreshToken dados);
        dRefreshToken ConsultarValido(string token);
        void Revogar(string token);
        void RevogarTodosPorUsuario(int usuarioCid);
    }
}
