using System;
using nsFabricante;

namespace ncPersistencia.nsFabricante
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
