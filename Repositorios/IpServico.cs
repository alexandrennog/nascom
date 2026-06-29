using System;
using Modelos;

namespace Repositorios
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
