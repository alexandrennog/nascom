Namespace nsPedidoCompra

    ' Pedido de Compra feito a um fabricante (marca). Tabelas criadas pelo
    ' script "scripts\new script\41 - pedido_compra.sql".
    '
    ' Situacao: A = Aberto, P = Parcial, E = Entregue, C = Cancelado.
    Public Class dPedidoCompra

        Public Property cid As Nullable(Of Integer)
        Public Property numero As String
        Public Property fabricante_cid As Nullable(Of Integer)
        Public Property fabricanteNome As String
        Public Property data As Nullable(Of DateTime)
        Public Property previsaoEntrega As Nullable(Of DateTime)
        ' Desconto do pedido todo, em R$ (rateado nos itens pelo valor bruto)
        Public Property descontoValor As Decimal
        Public Property situacao As String
        Public Property observacao As String
        Public Property usuario_cid As Nullable(Of Integer)

        Public Property itens As New ColecaoPedidoCompraItem

        ' Totais usados na lista de pedidos (vem prontos da consulta; na tela de
        ' cadastro sao recalculados a partir dos itens)
        Public Property totalPares As Integer
        Public Property totalBruto As Decimal
        Public Property totalEntregue As Integer

        Public ReadOnly Property totalLiquido As Decimal
            Get
                Return totalBruto - descontoValor
            End Get
        End Property

        Public ReadOnly Property situacaoDescricao As String
            Get
                Return DescreverSituacao(situacao)
            End Get
        End Property

        Public Shared Function DescreverSituacao(ByVal codigo As String) As String
            Select Case If(codigo, "").ToUpper()
                Case "A"
                    Return "Aberto"
                Case "P"
                    Return "Parcial"
                Case "E"
                    Return "Entregue"
                Case "C"
                    Return "Cancelado"
                Case Else
                    Return ""
            End Select
        End Function

    End Class

    Public Class ColecaoPedidoCompra
        Inherits List(Of dPedidoCompra)
    End Class

    ' Um item do pedido: uma referencia + cor (produto) em um tamanho
    ' (identificado pelo codigo de barras daquele tamanho na grade).
    Public Class dPedidoCompraItem

        Public Property cid As Nullable(Of Integer)
        Public Property pedidocompra_cid As Nullable(Of Integer)
        Public Property produtos_cid As Nullable(Of Integer)
        Public Property referencia As String
        Public Property descricao As String
        Public Property cor As String
        Public Property codigoBarras As String
        Public Property tamanho As String
        Public Property quantidade As Integer
        Public Property valorUnitario As Decimal
        Public Property quantidadeEntregue As Integer

        Public ReadOnly Property valorBruto As Decimal
            Get
                Return quantidade * valorUnitario
            End Get
        End Property

    End Class

    Public Class ColecaoPedidoCompraItem
        Inherits List(Of dPedidoCompraItem)
    End Class

    ' Produto (referencia + cor) de um fabricante, para escolher na tela do pedido.
    Public Class dPedidoCompraProduto

        Public Property cid As Integer
        Public Property referencia As String
        Public Property descricao As String
        Public Property cor As String
        Public Property valorCompra As Decimal

        ' Texto mostrado no combo da tela
        Public ReadOnly Property texto As String
            Get
                Return referencia & " - " & descricao & If(String.IsNullOrEmpty(cor), "", " - " & cor)
            End Get
        End Property

    End Class

    Public Class ColecaoPedidoCompraProduto
        Inherits List(Of dPedidoCompraProduto)
    End Class

    ' Um tamanho da grade de um produto
    Public Class dPedidoCompraGrade

        Public Property tamanho As String
        Public Property codigoBarras As String

    End Class

    Public Class ColecaoPedidoCompraGrade
        Inherits List(Of dPedidoCompraGrade)
    End Class

    ' Resultado da baixa automatica de uma entrada de estoque nos pedidos
    Public Class dPedidoCompraBaixa

        Public Property quantidadeBaixada As Integer
        Public Property quantidadeSemPedido As Integer
        ' Pedidos que receberam baixa, ex.: "P-01, #12"
        Public Property pedidos As String

    End Class

End Namespace
