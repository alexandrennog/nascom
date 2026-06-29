using System;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsVenda
{
    public interface IsVendaProduto
    {
        public ColecaoVendaProduto Listar();
        public ColecaoVendaProduto Consultar(dVendaProduto dados);
        public ColecaoVendaProduto ConsultarTroca(dVendaProduto dados);
        public int Incluir(dVendaProduto dados);
        public int Alterar(dVendaProduto dados);
        public int Excluir(dVendaProduto dados);
        public int ExcluirTroca(dVendaProduto dados);
        public int ExcluirControle(int controle);
        public int ExcluirControleTroca(int controle);
    }
}