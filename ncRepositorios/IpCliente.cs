using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpCliente
    {
        ColecaoCliente Listar();
        ColecaoCliente Consultar(dCliente dados);
        int Incluir(dCliente dados);
        int IncluirCid(dCliente dados);
        int Alterar(dCliente dados);
        int Excluir(dCliente dados);
    }
}
