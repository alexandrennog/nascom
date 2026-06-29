using System;
using Modelos;


namespace Repositorios
{
    public interface IpPreVendaProduto
    {
        ColecaoVendaProduto Listar();
        ColecaoVendaProduto Consultar(dVendaProduto dados);
        int Incluir(dVendaProduto dados);
        int Alterar(dVendaProduto dados);
        int Excluir(dVendaProduto dados);
    }
}
