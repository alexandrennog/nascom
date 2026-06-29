using System;
using Modelos;

namespace Repositorios
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
