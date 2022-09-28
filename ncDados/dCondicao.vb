Namespace nsCondicao

  Public Class ColecaoCondicao
    Inherits List(Of dCondicao)
  End Class

  Public Class dCondicao

    Private _cid As Nullable(Of Integer)
    Private _nome As String
    Private _situacao As String
    Private _desconto As Decimal

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

    Public Property desconto() As Decimal
      Get
        Return _desconto
      End Get
      Set(ByVal value As Decimal)
        _desconto = value
      End Set
    End Property

  End Class

End Namespace

