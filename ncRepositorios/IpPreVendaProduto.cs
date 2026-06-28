using System;
using ncModelos;


namespace ncRepositorios
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
