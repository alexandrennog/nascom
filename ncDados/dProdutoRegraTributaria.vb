Namespace nsProdutoRegraTributaria

    Public Class ColecaoProdutoRegraTributaria
        Inherits List(Of dProdutoRegraTributaria)
    End Class

    Public Class dProdutoRegraTributaria

        Private _cid As Nullable(Of Integer)
        Private _produto_cid As Nullable(Of Integer)
        Private _regra_cid As Nullable(Of Integer)

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property produto_cid() As Nullable(Of Integer)
            Get
                Return _produto_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _produto_cid = value
            End Set
        End Property

        Public Property regra_cid() As Nullable(Of Integer)
            Get
                Return _regra_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _regra_cid = value
            End Set
        End Property

    End Class

End Namespace
