using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpUsuarioPerfil
    {
        ColecaoUsuarioPerfil Listar();
        ColecaoUsuarioPerfil Consultar(dUsuarioPerfil dados);
        int Incluir(dUsuarioPerfil dados);
        int Alterar(dUsuarioPerfil dados);
        int Excluir(dUsuarioPerfil dados);
    }
}
