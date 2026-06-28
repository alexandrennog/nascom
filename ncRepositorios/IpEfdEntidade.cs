using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpEfdEntidade
    {
        dEfdEntidade Consultar();
        int Excluir();
        int Incluir(dEfdEntidade dados);
        int Alterar(dEfdEntidade dados);
    }
}
