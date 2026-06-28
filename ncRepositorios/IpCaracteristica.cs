using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpCaracteristica
    {
        ColecaoCaracteristica Listar();
        ColecaoCaracteristica Consultar(dCaracteristica dados);
        int Incluir(dCaracteristica dados);
        int Alterar(dCaracteristica dados);
        int Excluir(dCaracteristica dados);
    }
}
