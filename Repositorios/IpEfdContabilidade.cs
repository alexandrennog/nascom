using System;
using Modelos;

namespace Repositorios
{
    public interface IpEfdContabilidade
    {
        dEfdContabilidade Consultar();
        int Excluir();
        int Incluir(dEfdContabilidade dados);
        int Alterar(dEfdContabilidade dados);
    }
}
