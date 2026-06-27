using System;
using nsVeiculos;

namespace ncPersistencia.nsVeiculos
{
    public interface IpVeiculos
    {
        ColecaoVeiculos Listar();
        ColecaoVeiculos Consultar(dVeiculos dados);
        int Incluir(dVeiculos dados);
        int Alterar(dVeiculos dados);
        int Excluir(dVeiculos dados);
        int ExcluirVeiculosCliente(dVeiculos dados);
    }
}
