Namespace nsServico

  Public Class ColecaoServico
    Inherits List(Of dServico)
  End Class

  Public Class dServico

    Private _cid As Nullable(Of Integer)
    Private _nome As String
    Private _situacao As String
    Private _valor As Decimal

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

    Public Property valor() As Decimal
      Get
        Return _valor
      End Get
      Set(ByVal value As Decimal)
        _valor = value
      End Set
    End Property

  End Class

End Namespace

