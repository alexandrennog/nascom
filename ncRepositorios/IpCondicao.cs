using System;
using nsCondicao;

namespace ncPersistencia.nsCondicao
{
    public interface IpCondicao
    {
        ColecaoCondicao Listar();
        ColecaoCondicao Consultar(dCondicao dados);
        int Incluir(dCondicao dados);
        int Alterar(dCondicao dados);
        int Excluir(dCondicao dados);
    }
}
