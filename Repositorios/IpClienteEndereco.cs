using System;
using Modelos;


namespace Repositorios
{
    public interface IpClienteEndereco
    {
        ColecaoClienteEndereco Listar();
        ColecaoClienteEndereco Consultar(dClienteEndereco dados);
        int Incluir(dClienteEndereco dados);
        int ExcluirPorCliente(int cliente_cid);
    }
}
