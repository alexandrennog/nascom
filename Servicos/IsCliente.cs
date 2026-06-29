using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsCliente
    {
        public ColecaoCliente Listar();
        public ColecaoCliente Consultar(dCliente dados);
        public dCliente ConsultarPorCID(int cid);
        public int Incluir(dCliente dados);
        public int IncluirImportacao(dCliente dados);
        public int Alterar(dCliente dados);
        public int Excluir(dCliente dados);
    }
}