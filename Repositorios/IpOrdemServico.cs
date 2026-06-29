using System;
using Modelos;

namespace Repositorios
{
    public interface IpOrdemServico
    {
        ColecaoOrdemServico Listar();
        ColecaoOrdemServico Consultar(dOrdemServico dados);
        int ConsultarMax();
        int Incluir(dOrdemServico dados);
        int Alterar(dOrdemServico dados);
        int Excluir(dOrdemServico dados);
    }
}
