using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos
{
    public interface IsVenda
    {
        public ColecaoVenda Listar();
        public ColecaodVendasNfe ListarVendasNfe(string dataIni, string dataFim);
        public ColecaodVendasABC ListarVendasABC(string dataIni, string dataFim, string tipo);
        public ColecaoVenda Consultar(dVenda dados);
        public ColecaoVenda ConsultarPix(dVenda dados);
        public ColecaoVendasPorVendedor ConsultarVendasPorVendedor(dVendasPorVendedor dados);
        public ColecaoVendasPorVendedor ConsultarVendasDaLoja(dVendasPorVendedor dados);
        public ColecaoVenda ConsultarCrediarioPix(dVenda dados);
        public ColecaoVenda ConsultarTroca(dVenda dados);
        public dVenda ConsultarUltimaVenda(int produto_cid);
        public int ConsultarMax();
        public int Incluir(dVenda dados, ColecaoVendaProduto dadosProdutos);
        public int IncluirnNF(dBasennf dados);
        public int IncluirTroca(dVenda dados, ColecaoVendaProduto dadosProdutos);
        public int IncluirVale(dVenda dados);
        public int IncluirCrediarioPagamento(dVenda dados);
        public int Alterar(dVenda dados);
        public int Alterar(string controle, string chave);
        public int AlterarBaseNnf(dBasennf dados);
        public int Excluir(dVenda dados);
        public int ExcluirVale(dVenda dados);
        public ColecaoVenda ConsultarFechamento(dVenda dados);
    }
}