using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsVeiculos
    {
        public ColecaoVeiculos Listar();
        public ColecaoVeiculos Consultar(dVeiculos dados);
        public dVeiculos ConsultarPorCID(int cid);
        public int Incluir(ColecaoVeiculos dadosVeiculos);
        public int Incluir(dVeiculos dados);
        public int Alterar(ColecaoVeiculos dadosVeiculos);
        public int Excluir(dVeiculos dados);
        public int ExcluirVeiculosCliente(dVeiculos dados);
    }
}