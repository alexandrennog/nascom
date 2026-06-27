using System;
using nsServico;

namespace ncPersistencia.nsServico
{
    public interface IpServico
    {
        ColecaoServico Listar();
        ColecaoServico Consultar(dServico dados);
        int Incluir(dServico dados);
        int Alterar(dServico dados);
        int Excluir(dServico dados);
    }
}
