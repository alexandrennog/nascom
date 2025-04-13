Namespace nsEstado

  Public Class ColecaoEstado
    Inherits List(Of dEstado)
  End Class

  Public Class dEstado

    Private _cid As Nullable(Of Integer)
    Private _sigla As String
    Private _nome As String
    Private _situacao As String

    Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property sigla() As String
      Get
        Return _sigla
      End Get
      Set(ByVal value As String)
        _sigla = value
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

  End Class

End Namespace

