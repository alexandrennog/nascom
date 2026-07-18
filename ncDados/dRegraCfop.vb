Namespace nsRegraCfop

    Public Class ColecaoRegraCfop
        Inherits List(Of dRegraCfop)
    End Class

    Public Class dRegraCfop

        Private _cid As Nullable(Of Integer)
        Private _regra_cid As Nullable(Of Integer)
        Private _cfop As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
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

        Public Property cfop() As String
            Get
                Return _cfop
            End Get
            Set(ByVal value As String)
                _cfop = value
            End Set
        End Property

    End Class

End Namespace
