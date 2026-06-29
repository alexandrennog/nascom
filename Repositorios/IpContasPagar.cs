using System;
using Modelos;

namespace Repositorios
{
    public interface IpContasPagar
    {
        ColecaoContasPagar Listar();
        ColecaoContasPagar Consultar(dContasPagar dados);
        int Incluir(dContasPagar dados);
        int Importar(dContasPagar dados);
        int Alterar(dContasPagar dados);
        int Excluir(dContasPagar dados);
    }
}
