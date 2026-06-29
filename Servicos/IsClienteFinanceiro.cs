using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsClienteFinanceiro
    {
        public ColecaoClienteFinanceiro Listar();
        public ColecaoClienteFinanceiro Consultar(dClienteFinanceiro dados);
        public int Incluir(dClienteFinanceiro dados);
        public int Alterar(dClienteFinanceiro dados);
        public int ExcluirPorCliente(int cliente_cid);
    }
}