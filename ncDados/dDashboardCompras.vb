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
        ' Cor do item (o mesmo produto/referencia pode ter varias cores
        ' cadastradas, cada uma com seu proprio estoque) - pedido da cliente,
        ' pra nao precisar abrir cor por cor pra achar qual precisa repor.
        Public Property cor As String
        Public Property quantidadeVendida As Decimal
        Public Property estoqueAtual As Decimal
        Public Property classeAbc As String

    End Class

    Public Class ColecaoDashboardReposicao
        Inherits List(Of dDashboardReposicaoItem)
    End Class

    ' Compras x Vendas x Estoque (script "42 - painel_compras_x_vendas.sql"):
    ' uma linha por referencia + cor (ou por tamanho). comprado = entradas de
    ' estoque no periodo, vendido = vendas + vales no periodo, estoque = hoje.
    Public Class dDashboardCompraVendaItem

        Public Property fabricante As String
        Public Property produtoCid As Integer
        Public Property referencia As String
        Public Property descricao As String
        Public Property cor As String
        Public Property tamanho As String
        Public Property comprado As Integer
        Public Property vendido As Integer
        Public Property estoque As Integer

        ' % vendido = vendido / (vendido + estoque de hoje). Nao usa o
        ' "comprado" no denominador porque a venda do periodo pode ser de
        ' mercadoria comprada antes dele; vendido + estoque e o que havia
        ' disponivel. Estoque negativo (erro de lancamento) conta como 0.
        ' Devolve Nothing quando nao ha base para calcular.
        Public ReadOnly Property percentualVendido As Nullable(Of Decimal)
            Get
                Dim base As Integer = vendido + Math.Max(0, estoque)
                If base <= 0 Then
                    Return Nothing
                End If
                Return Math.Round(CDec(vendido) * 100D / CDec(base), 1)
            End Get
        End Property

    End Class

    Public Class ColecaoDashboardCompraVenda
        Inherits List(Of dDashboardCompraVendaItem)
    End Class

End Namespace
