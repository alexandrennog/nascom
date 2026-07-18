Namespace nsImpostoIcms

    Public Class ColecaoImpostoIcms
        Inherits List(Of dImpostoIcms)
    End Class

    Public Class dImpostoIcms

        Private _regra_cid As Nullable(Of Integer)
        Private _origem As Nullable(Of Byte)
        Private _cst As String
        Private _csosn As String
        Private _aliquota As Nullable(Of Decimal)
        Private _reducaoBase As Nullable(Of Decimal)
        Private _modalidadeBc As Nullable(Of Byte)
        Private _aliquotaSt As Nullable(Of Decimal)
        Private _margemValorAgregado As Nullable(Of Decimal)

        Public Property regra_cid() As Nullable(Of Integer)
            Get
                Return _regra_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _regra_cid = value
            End Set
        End Property

        ' 0 Nacional / 1 Estrangeira
        Public Property origem() As Nullable(Of Byte)
            Get
                Return _origem
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _origem = value
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

        Public Property csosn() As String
            Get
                Return _csosn
            End Get
            Set(ByVal value As String)
                _csosn = value
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

        Public Property reducaoBase() As Nullable(Of Decimal)
            Get
                Return _reducaoBase
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _reducaoBase = value
            End Set
        End Property

        Public Property modalidadeBc() As Nullable(Of Byte)
            Get
                Return _modalidadeBc
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _modalidadeBc = value
            End Set
        End Property

        Public Property aliquotaSt() As Nullable(Of Decimal)
            Get
                Return _aliquotaSt
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliquotaSt = value
            End Set
        End Property

        Public Property margemValorAgregado() As Nullable(Of Decimal)
            Get
                Return _margemValorAgregado
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _margemValorAgregado = value
            End Set
        End Property

    End Class

End Namespace
