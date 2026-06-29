using System;
using Modelos;

namespace Repositorios
{
    public interface IpLoja
    {
        ColecaoLoja Listar();
        ColecaoLoja Consultar(dLoja dados);
        int Incluir(dLoja dados);
        int Alterar(dLoja dados);
        int Excluir(dLoja dados);
    }
}
