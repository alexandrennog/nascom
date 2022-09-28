Namespace nsVeiculos

    Public Class ColecaoVeiculos
        Inherits List(Of dVeiculos)
    End Class

    Public Class dVeiculos

        Private _cid As Nullable(Of Integer)
        Private _clienteId As Integer
        Private _placa As String
        Private _marca As String
        Private _modelo As String
        Private _cor As String
        Private _ano As String
        Private _combustivel As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property clienteId() As Integer
            Get
                Return _clienteId
            End Get
            Set(ByVal value As Integer)
                _clienteId = value
            End Set
        End Property

        Public Property Placa() As String
            Get
                Return _placa
            End Get
            Set(ByVal value As String)
                _placa = value
            End Set
        End Property

        Public Property Marca() As String
            Get
                Return _marca
            End Get
            Set(ByVal value As String)
                _marca = value
            End Set
        End Property

        Public Property Modelo() As String
            Get
                Return _modelo
            End Get
            Set(ByVal value As String)
                _modelo = value
            End Set
        End Property

        Public Property Cor() As String
            Get
                Return _cor
            End Get
            Set(ByVal value As String)
                _cor = value
            End Set
        End Property

        Public Property Ano() As String
            Get
                Return _ano
            End Get
            Set(ByVal value As String)
                _ano = value
            End Set
        End Property

        Public Property Combustivel() As String
            Get
                Return _combustivel
            End Get
            Set(ByVal value As String)
                _combustivel = value
            End Set
        End Property

    End Class

End Namespace
