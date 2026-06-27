using System;
using nsOrdemServico;

namespace ncPersistencia.nsOrdemServico
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
