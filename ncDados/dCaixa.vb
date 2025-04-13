Namespace nsCaixa

    Public Class ColecaoCaixa
        Inherits List(Of dCaixa)
    End Class

    Public Class dCaixa

        Private _cid As Nullable(Of Integer)
        Private _nome As String
        Private _situacao As String
        Private _data As String
        Private _usuario As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property nome() As String
            Get
                Return _nome
            End Get
            Set(ByVal value As String)
                _nome = value
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
        Public Property Data() As DateTime
            Get
                Return _data
            End Get
            Set(ByVal value As DateTime)
                _data = value
            End Set
        End Property
        Public Property usuario() As String
            Get
                Return _usuario
            End Get
            Set(ByVal value As String)
                _usuario = value
            End Set
        End Property

    End Class

End Namespace

