using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpEfdContabilidade
    {
        dEfdContabilidade Consultar();
        int Excluir();
        int Incluir(dEfdContabilidade dados);
        int Alterar(dEfdContabilidade dados);
    }
}
