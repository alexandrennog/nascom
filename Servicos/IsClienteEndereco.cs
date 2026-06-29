using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCliente
{
    public interface IsClienteEndereco
    {
        public ColecaoClienteEndereco Listar();
        public ColecaoClienteEndereco Consultar(dClienteEndereco dados);
        public dClienteEndereco ConsultarPorCID(int cid);
        public int Incluir(dClienteEndereco dados);
        public int ExcluirPorCliente(int cliente_cid);
    }
}