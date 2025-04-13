Namespace nsNotaFiscalFornecedor

    Public Class ColecaoNotaFiscalItem
        Inherits List(Of dNotaFiscalItem)
    End Class

    Public Class dNotaFiscalItem
        Private _produtos_cid As Nullable(Of Integer)
        Private _produtos_descricao As String
        Private _produtos_estoque As String
        Private _produtos_valor As Decimal
        Private _produtos_referencia As String
        Private _item As Nullable(Of Integer)
        Private _caracteristicas_cid As Nullable(Of Integer)
        Private _caracteristicas_nome As String
        Private _caracteristicas_codigo As String

        Public Property produtos_cid() As Nullable(Of Integer)
            Get
                Return _produtos_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _produtos_cid = value
            End Set
        End Property

        Public Property produtos_descricao() As String
            Get
                Return _produtos_descricao
            End Get
            Set(ByVal value As String)
                _produtos_descricao = value
            End Set
        End Property

        Public Property produtos_estoque() As String
            Get
                Return _produtos_estoque
            End Get
            Set(ByVal value As String)
                _produtos_estoque = value
            End Set
        End Property

        Public Property item() As Nullable(Of Integer)
            Get
                Return _item
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _item = value
            End Set
        End Property

        Public Property caracteristicas_cid() As Nullable(Of Integer)
            Get
                Return _caracteristicas_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _caracteristicas_cid = value
            End Set
        End Property

        Public Property caracteristicas_nome() As String
            Get
                Return _caracteristicas_nome
            End Get
            Set(ByVal value As String)
                _caracteristicas_nome = value
            End Set
        End Property

        Public Property caracteristicas_codigo() As String
            Get
                Return _caracteristicas_codigo
            End Get
            Set(ByVal value As String)
                _caracteristicas_codigo = value
            End Set
        End Property

        Public Property Produtos_Valor() As Decimal
            Get
                Return _produtos_valor
            End Get
            Set(ByVal value As Decimal)
                _produtos_valor = value
            End Set
        End Property

        Public Property Produtos_Referencia() As String
            Get
                Return _produtos_referencia
            End Get
            Set(ByVal value As String)
                _produtos_referencia = value
            End Set
        End Property

    End Class

End Namespace