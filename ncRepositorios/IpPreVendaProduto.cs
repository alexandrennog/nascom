using nsVenda;
using System;


namespace ncPersistencia.nsVenda
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
