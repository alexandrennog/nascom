Namespace nsParametro

  Public Class ColecaoParametro
    Inherits List(Of dParametro)
  End Class

  Public Class dParametro

    Private _cid As Nullable(Of Integer)
    Private _descricao As String
    Private _valor As String

    Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
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

    Public Property valor() As String
      Get
        Return _valor
      End Get
      Set(ByVal value As String)
        _valor = value
      End Set
    End Property

  End Class

End Namespace

