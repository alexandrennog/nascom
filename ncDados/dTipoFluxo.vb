Namespace nsDados

  Public Class ColecaoTipoFluxo
    Inherits List(Of dTipoFluxo)
  End Class

  Public Class dTipoFluxo

    Private _cid As Integer
    Private _codigo As String
    Private _descricao As String

    Public Property cid() As Integer
      Get
        Return _cid
      End Get
      Set(ByVal value As Integer)
        _cid = value
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
