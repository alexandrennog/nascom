using nsCliente;
using System;


namespace ncPersistencia.nsCliente
{
    public interface IpClienteEndereco
    {
        ColecaoClienteEndereco Listar();
        ColecaoClienteEndereco Consultar(dClienteEndereco dados);
        int Incluir(dClienteEndereco dados);
        int ExcluirPorCliente(int cliente_cid);
    }
}
