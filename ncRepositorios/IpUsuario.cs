using System;
using ncModelos;


namespace ncRepositorios
{
    public interface IpUsuario
    {
        ColecaoUsuario Listar();
        ColecaoUsuario Consultar(dUsuario dados);
        ColecaoUsuario ConsultarADM(string perfil);
        int Incluir(dUsuario dados);
        int Alterar(dUsuario dados);
        int Excluir(dUsuario dados);
    }
}
