using System;
using nsUsuarioPerfil;

namespace ncPersistencia.nsUsuarioPerfil
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
