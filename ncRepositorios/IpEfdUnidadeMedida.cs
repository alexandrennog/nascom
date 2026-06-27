using System;
using nsEFD;

namespace ncPersistencia.nsEFD
{
    public interface IpEfdUnidadeMedida
    {
        ColecaoEfdUnidadeMedida Listar();
        dEfdUnidadeMedida Consultar(dEfdUnidadeMedida dados);
        int Excluir(dEfdUnidadeMedida dados);
        int Incluir(dEfdUnidadeMedida dados);
        int Alterar(dEfdUnidadeMedida dados);
    }
}
