Namespace nsDados

  Public Class ColecaoOrigemMercadoria
    Inherits List(Of dOrigemMercadoria)
  End Class

  Public Class dOrigemMercadoria

    Private _codigo As Nullable(Of Integer)
    Private _descricao As String

    Public Property codigo() As Nullable(Of Integer)
      Get
        Return _codigo
      End Get
      Set(ByVal value As Nullable(Of Integer))
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
