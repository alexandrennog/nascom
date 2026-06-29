using System;
using Modelos;

namespace Repositorios
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
