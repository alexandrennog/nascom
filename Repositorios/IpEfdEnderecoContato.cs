using System;
using Modelos;

namespace Repositorios
{
    public interface IpEfdEnderecoContato
    {
        dEfdEnderecoContato Consultar();
        int Excluir();
        int Incluir(dEfdEnderecoContato dados);
        int Alterar(dEfdEnderecoContato dados);
    }
}
