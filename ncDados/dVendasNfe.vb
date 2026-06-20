Namespace nsVenda

    Public Class ColecaodVendasNfe
        Inherits List(Of dVendasNfe)
    End Class

    Public Class dVendasNfe
        Private _cupom As String
        Private _dataVenda As String
        Private _valor As String
        Public Property Cupom() As String
            Get
                Return _cupom
            End Get
            Set(ByVal value As String)
                _cupom = value
            End Set
        End Property
        Public Property DataVenda() As String
            Get
                Return _dataVenda
            End Get
            Set(ByVal value As String)
                _dataVenda = value
            End Set
        End Property
        Public Property Valor() As String
            Get
                Return _valor
            End Get
            Set(ByVal value As String)
                _valor = value
            End Set
        End Property

    End Class
End Namespace
