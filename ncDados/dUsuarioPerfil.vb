Namespace nsUsuarioPerfil

  Public Class ColecaoUsuarioPerfil
    Inherits List(Of dUsuarioPerfil)
  End Class

  Public Class dUsuarioPerfil

    Private _cid As Nullable(Of Integer)
    Private _codigo As String
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

    Public Property nome() As String
      Get
        Return _nome
      End Get
      Set(ByVal value As String)
        _nome = value
      End Set
    End Property

    Public Property codigo() As String
      Get
        Return _codigo
      End Get
      Set(ByVal value As String)
        _codigo = value
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
