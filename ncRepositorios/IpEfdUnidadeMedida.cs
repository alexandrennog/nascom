using System;
using ncModelos;

namespace ncRepositorios
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
