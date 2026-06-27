using nsCliente;
using System;


namespace ncPersistencia.nsCliente
{
    public interface IpClienteProfissional
    {
        ColecaoClienteProfissional Listar();
        ColecaoClienteProfissional Consultar(dClienteProfissional dados);
        int Incluir(dClienteProfissional dados);
        int Alterar(dClienteProfissional dados);
        int ExcluirPorCliente(int cliente_cid);
    }
}
