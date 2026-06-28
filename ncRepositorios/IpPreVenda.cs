using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpPreVenda
    {
        ColecaoVenda Listar();
        ColecaoVenda Consultar(dVenda dados);
        int ConsultarMax();
        int Incluir(dVenda dados);
        int Alterar(dVenda dados);
        int Excluir(dVenda dados);
    }
}
