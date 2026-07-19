Namespace nsVenda

    Public Class ColecaoVendaProduto
        Inherits List(Of dVendaProduto)
    End Class

    Public Class dVendaProduto

        Private _controle As Integer
        Private _produtoId As Integer
        Private _itemId As Integer
        Private _quantidade As Decimal
        Private _valor As Decimal
        Private _codigobarras As String
        Private _descricao As String
        Private _referencia As String
        Private _aliquota As String
        Private _ncm As String
        Private _cest As String
        Public Property ncm() As String
            Get
                Return _ncm
            End Get
            Set(ByVal value As String)
                _ncm = value
            End Set
        End Property
        Public Property cest() As String
            Get
                Return _cest
            End Get
            Set(ByVal value As String)
                _cest = value
            End Set
        End Property
        Public Property controle() As Integer
            Get
                Return _controle
            End Get
            Set(ByVal value As Integer)
                _controle = value
            End Set
        End Property

        Public Property produtoId() As Integer
            Get
                Return _produtoId
            End Get
            Set(ByVal value As Integer)
                _produtoId = value
            End Set
        End Property

        Public Property itemId() As Integer
            Get
                Return _itemId
            End Get
            Set(ByVal value As Integer)
                _itemId = value
            End Set
        End Property

        Public Property quantidade() As Decimal
            Get
                Return _quantidade
            End Get
            Set(ByVal value As Decimal)
                _quantidade = value
            End Set
        End Property

        Public Property valor() As Decimal
            Get
                Return _valor
            End Get
            Set(ByVal value As Decimal)
                _valor = value
            End Set
        End Property

        Public Property codigobarras() As String
            Get
                Return _codigobarras
            End Get
            Set(ByVal value As String)
                _codigobarras = value
            End Set
        End Property

        Public Property descricao() As String
            Get
                Return _descricao
            End Get
            Set(ByVal value As String)
                _descricao = value
            End Set
        End Property

        Public Property referencia() As String
            Get
                Return _referencia
            End Get
            Set(ByVal value As String)
                _referencia = value
            End Set
        End Property

        Public Property aliquota() As String
            Get
                Return _aliquota
            End Get
            Set(ByVal value As String)
                _aliquota = value
            End Set
        End Property
    End Class

End Namespace