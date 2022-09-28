Namespace nsOrdemServico

    Public Class ColecaoOrdemServico
        Inherits List(Of dOrdemServico)
    End Class

    Public Class dOrdemServico

        Private _cid As Nullable(Of Integer)
        Private _clienteid As Nullable(Of Integer)
        Private _veiculoid As Nullable(Of Integer)
        Private _observacoes As String
        Private _emissao As String
        Private _vendedor As String
        Private _loja As String
        Private _situacao As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property clienteid() As Nullable(Of Integer)
            Get
                Return _clienteid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _clienteid = value
            End Set
        End Property

        Public Property veiculoid() As Nullable(Of Integer)
            Get
                Return _veiculoid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _veiculoid = value
            End Set
        End Property

        Public Property observacoes() As String
            Get
                Return _observacoes
            End Get
            Set(ByVal value As String)
                _observacoes = value
            End Set
        End Property

        Public Property emissao() As String
            Get
                Return _emissao
            End Get
            Set(ByVal value As String)
                _emissao = value
            End Set
        End Property

        Public Property vendedor() As String
            Get
                Return _vendedor
            End Get
            Set(ByVal value As String)
                _vendedor = value
            End Set
        End Property

        Public Property loja() As String
            Get
                Return _loja
            End Get
            Set(ByVal value As String)
                _loja = value
            End Set
        End Property

        Public Property situacao() As String
            Get
                Return _situacao
            End Get
            Set(ByVal value As String)
                _situacao = value
            End Set
        End Property

    End Class

End Namespace

