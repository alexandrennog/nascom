using System;
using System.Transactions;
using Comum;
using Repositorios;
using Modelos;

namespace Servicos.nsCrediario
{
    public interface IsCrediario
    {
        public ColecaoCrediario Listar();
        public int ConsultarMax();
        public ColecaoCrediario Consultar(dCrediario dados);
        public ColecaoParcelas ConsultarParcelas(dParcelas dados);
        public ColecaoParcelas ConsultarParcelasPagamentos(dParcelas dados);
        public dParcelas ConsultarParcela(int cid);
        public ColecaoParcelas ConsultarParcelasCliente(int codCliente);
        public ColecaoParcelas ConsultarParcelasVencidas(int codCliente);
        public int Incluir(dCrediario dados, ColecaoParcelas dadosParcelas);
        public int IncluirCrediario(dCrediario dados);
        public int IncluirParcela(dParcelas dadosParcela);
        public int Alterar(dCrediario dados, ColecaoParcelas dadosParcelas);
        public int GravarPagamentoParcelas(ColecaoParcelas dadosParcelas);
        public int Renegociar(dCrediario dados, ColecaoParcelas dadosParcelas);
        public int AlterarCrediario(dCrediario dados);
        public int AlterarControle(dCrediario dados);
        public int Excluir(dCrediario dados);
        public int CorrigirParcelas();
    }
}