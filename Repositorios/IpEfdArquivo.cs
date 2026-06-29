using System;
using Modelos;

namespace Repositorios
{
    public interface IpEfdArquivo
    {
        dEfdArquivo Consultar();
        int Excluir();
        int Incluir(dEfdArquivo dados);
        int Alterar(dEfdArquivo dados);
    }
}
