using System;
using Modelos;

namespace Repositorios
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
