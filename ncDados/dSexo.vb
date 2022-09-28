Namespace nsDados

  Public Class ColecaoSexo
    Inherits List(Of dSexo)
  End Class

  Public Class dSexo

    Private _codigo As String
    Private _descricao As String

    Public Property codigo() As String
      Get
        Return _codigo
      End Get
      Set(ByVal value As String)
        _codigo = value
      End Set
    End Property

    Public Property descricao() As String
      Get
        Return _descricao
      End Get
      Set(ByVal value As String)
        _descricao = value
      End Set
    End Property

  End Class

End Namespace
