using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpEfdArquivo
    {
        dEfdArquivo Consultar();
        int Excluir();
        int Incluir(dEfdArquivo dados);
        int Alterar(dEfdArquivo dados);
    }
}
