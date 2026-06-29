using System;
using Modelos;


namespace Repositorios
{
    public interface IpVendaProduto
    {
        ColecaoVendaProduto Listar();
        ColecaoVendaProduto Consultar(dVendaProduto dados);
        ColecaoVendaProduto ConsultarTroca(dVendaProduto dados);
        int Incluir(dVendaProduto dados);
        int IncluirTroca(dVendaProduto dados);
        int Alterar(dVendaProduto dados);
        int Excluir(dVendaProduto dados);
        int ExcluirControle(int controle);
        int ExcluirControleTroca(int controle);
    }
}
