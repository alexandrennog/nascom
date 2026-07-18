Namespace nsImpostoPis

    Public Class ColecaoImpostoPis
        Inherits List(Of dImpostoPis)
    End Class

    Public Class dImpostoPis

        Private _regra_cid As Nullable(Of Integer)
        Private _cst As String
        Private _aliquota As Nullable(Of Decimal)

        Public Property regra_cid() As Nullable(Of Integer)
            Get
                Return _regra_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _regra_cid = value
            End Set
        End Property

        Public Property cst() As String
            Get
                Return _cst
            End Get
            Set(ByVal value As String)
                _cst = value
            End Set
        End Property

        Public Property aliquota() As Nullable(Of Decimal)
            Get
                Return _aliquota
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliquota = value
            End Set
        End Property

    End Class

End Namespace
