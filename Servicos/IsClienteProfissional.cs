using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsClienteProfissional
    {
        public ColecaoClienteProfissional Listar();
        public ColecaoClienteProfissional Consultar(dClienteProfissional dados);
        public int Incluir(dClienteProfissional dados);
        public int Alterar(dClienteProfissional dados);
        public int ExcluirPorCliente(int cliente_cid);
    }
}