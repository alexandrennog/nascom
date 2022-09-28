Namespace nsDados

  Public Class ColecaoTipoNotaFiscal
    Inherits List(Of dTipoNotaFiscal)
  End Class

  Public Class dTipoNotaFiscal

    Private _cid As Integer
    Private _codigo As String
    Private _descricao As String
    Private _modelo As String
    Private _modeloDescricao As String

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

    Public Property modelo() As String
      Get
        Return _modelo
      End Get
      Set(ByVal value As String)
        _modelo = value
      End Set
    End Property

    Public Property modeloDescricao() As String
      Get
        Return _modeloDescricao
      End Get
      Set(ByVal value As String)
        _modeloDescricao = value
      End Set
    End Property

  End Class

End Namespace
