using System;
using Modelos;

namespace Repositorios
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
