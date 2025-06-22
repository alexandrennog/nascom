
Namespace nsVenda

    Public Class ColecaoVendasPorVendedor
        Inherits List(Of dVendasPorVendedor)
    End Class

    Public Class dVendasPorVendedor
        Public Property _nome As String
        Public Property _totalVendas As Integer
        Public Property _quantidadeProdutos As Integer
        Public Property _valorTotalVendas As Decimal
        Public Property _ticketMedio As Decimal
        Public Property _percentualAtingimento As Decimal
        Public Property _data As DateTime
        Private Property _dataFim As DateTime

        Public Property Nome() As String
            Get
                Return _nome
            End Get
            Set(ByVal value As String)
                _nome = value
            End Set
        End Property

        Public Property TotalVendas() As Integer
            Get
                Return _totalVendas
            End Get
            Set(ByVal value As Integer)
                _totalVendas = value
            End Set
        End Property

        Public Property QuantidadeProdutos() As Integer
            Get
                Return _quantidadeProdutos
            End Get
            Set(ByVal value As Integer)
                _quantidadeProdutos = value
            End Set
        End Property

        Public Property ValorTotalVendas() As Decimal
            Get
                Return _valorTotalVendas
            End Get
            Set(ByVal value As Decimal)
                _valorTotalVendas = value
            End Set
        End Property

        Public Property TicketMedio() As Decimal
            Get
                Return _ticketMedio
            End Get
            Set(ByVal value As Decimal)
                _ticketMedio = value
            End Set
        End Property

        Public Property PercentualAtingimento() As Decimal
            Get
                Return _percentualAtingimento
            End Get
            Set(ByVal value As Decimal)
                _percentualAtingimento = value
            End Set
        End Property


        Public Property Data() As DateTime
            Get
                Return _data
            End Get
            Set(ByVal value As DateTime)
                _data = value
            End Set
        End Property

        Public Property DataFim() As DateTime
            Get
                Return _dataFim
            End Get
            Set(ByVal value As DateTime)
                _dataFim = value
            End Set
        End Property
    End Class

End Namespace
