using System;
using Modelos;

namespace Repositorios
{
    public interface IpFabricante
    {
        ColecaoFabricante Listar();
        ColecaoFabricante Consultar(dFabricante dados);
        int Incluir(dFabricante dados);
        int Alterar(dFabricante dados);
        int Excluir(dFabricante dados);
    }
}
