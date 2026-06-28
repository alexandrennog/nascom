using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpEfdEnderecoContato
    {
        dEfdEnderecoContato Consultar();
        int Excluir();
        int Incluir(dEfdEnderecoContato dados);
        int Alterar(dEfdEnderecoContato dados);
    }
}
