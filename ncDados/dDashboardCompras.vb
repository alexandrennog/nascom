Namespace nsDashboardCompras

    ' Resumo do painel de compras: ticket medio e marca campea do periodo
    ' (em valor e em quantidade - podem ser marcas diferentes).
    Public Class dDashboardResumo

        Public Property periodoInicio As String
        Public Property periodoFim As String
        Public Property qtdVendas As Integer
        Public Property faturamentoTotal As Decimal
        Public Property ticketMedio As Decimal
        Public Property marcaCampeaValor As String
        Public Property marcaCampeaValorTotal As Decimal
        Public Property marcaCampeaQuantidade As String
        Public Property marcaCampeaQuantidadeTotal As Decimal

    End Class

    ' Um item candidato a reposicao: vendeu bem (classe A/B na Curva ABC por
    ' quantidade) e esta com pouco estoque em relacao ao que foi vendido.
    Public Class dDashboardReposicaoItem

        Public Property referencia As String
        Public Property descricao As String
        Public Property fabricante As String
        Public Property quantidadeVendida As Decimal
        Public Property estoqueAtual As Decimal
        Public Property classeAbc As String

    End Class

    Public Class ColecaoDashboardReposicao
        Inherits List(Of dDashboardReposicaoItem)
    End Class

End Namespace
