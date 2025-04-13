Public Class ColecaoCaixaFechamento
    Inherits List(Of dCaixaFechamento)
End Class

Public Class dCaixaFechamento

    Private _cid As Nullable(Of Integer)
    Private _nome As String
    Private _situacao As String
    Private _data As String
    Private _usuario As String
    Private _valor As Decimal
    Private _quantidade As Integer


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
    Public Property valor() As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
        End Set
    End Property
    Public Property quantidade() As Integer
        Get
            Return _quantidade
        End Get
        Set(ByVal value As Integer)
            _quantidade = value
        End Set
    End Property

End Class
