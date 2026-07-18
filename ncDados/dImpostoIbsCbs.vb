Namespace nsImpostoIbsCbs

    Public Class ColecaoImpostoIbsCbs
        Inherits List(Of dImpostoIbsCbs)
    End Class

    Public Class dImpostoIbsCbs

        Private _regra_cid As Nullable(Of Integer)
        Private _cstIbsCbs As String
        Private _cClassTrib As String
        Private _aliquotaIbsUf As Nullable(Of Decimal)
        Private _aliquotaIbsMunicipio As Nullable(Of Decimal)
        Private _aliquotaCbs As Nullable(Of Decimal)

        Public Property regra_cid() As Nullable(Of Integer)
            Get
                Return _regra_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _regra_cid = value
            End Set
        End Property

        Public Property cstIbsCbs() As String
            Get
                Return _cstIbsCbs
            End Get
            Set(ByVal value As String)
                _cstIbsCbs = value
            End Set
        End Property

        Public Property cClassTrib() As String
            Get
                Return _cClassTrib
            End Get
            Set(ByVal value As String)
                _cClassTrib = value
            End Set
        End Property

        Public Property aliquotaIbsUf() As Nullable(Of Decimal)
            Get
                Return _aliquotaIbsUf
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliquotaIbsUf = value
            End Set
        End Property

        Public Property aliquotaIbsMunicipio() As Nullable(Of Decimal)
            Get
                Return _aliquotaIbsMunicipio
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliquotaIbsMunicipio = value
            End Set
        End Property

        Public Property aliquotaCbs() As Nullable(Of Decimal)
            Get
                Return _aliquotaCbs
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliquotaCbs = value
            End Set
        End Property

    End Class

End Namespace
