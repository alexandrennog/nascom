using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsPreVendaProduto
    {
        public ColecaoVendaProduto Listar();
        public ColecaoVendaProduto Consultar(dVendaProduto dados);
        public int Incluir(dVendaProduto dados);
        public int Alterar(dVendaProduto dados);
        public int Excluir(dVendaProduto dados);
    }
}