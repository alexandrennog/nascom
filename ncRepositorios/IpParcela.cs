using System;
using ncModelos;

namespace ncRepositorios
{
    public interface IpParcela
    {
        ColecaoParcelas Listar();
        ColecaoParcelas Consultar(dParcelas dados);
        ColecaoParcelas ConsultarParcelasCliente(int codCliente);
        ColecaoParcelas ConsultarParcelasVencidas(int codCliente);
        int Incluir(dParcelas dados);
        ColecaoParcelas ConsultarPagamentos(dParcelas dados);
        int IncluirPagamento(dParcelas dados);
        int Corrigir();
        int Alterar(dParcelas dados);
        int Excluir(dParcelas dados);
    }
}
