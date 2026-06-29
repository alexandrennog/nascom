using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsPreVenda
    {
        ColecaoVenda Listar();
        ColecaoVenda Consultar(dVenda dados);
        int ConsultarMax();
        int Incluir(dVenda dados);
        int Alterar(dVenda dados);
        int Excluir(dVenda dados);
    }
}
