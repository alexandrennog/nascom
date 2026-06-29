using System;
using Modelos;

namespace Repositorios
{
    public interface IpEfdEntidade
    {
        dEfdEntidade Consultar();
        int Excluir();
        int Incluir(dEfdEntidade dados);
        int Alterar(dEfdEntidade dados);
    }
}
