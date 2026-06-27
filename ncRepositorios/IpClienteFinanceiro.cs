using nsCliente;
using System;


namespace ncPersistencia.nsCliente
{
    public interface IpClienteFinanceiro
    {
        ColecaoClienteFinanceiro Listar();
        ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados);
        int Incluir(dClienteFinanceiro dados);
        int Alterar(dClienteFinanceiro dados);
        int ExcluirPorCliente(int cliente_cid);
    }
}
