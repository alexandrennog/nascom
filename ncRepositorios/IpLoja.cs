using System;
using ncModelos;

namespace ncRepositorios
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
