Namespace nsCaracteristica

  Public Class ColecaoCaracteristicaItem
    Inherits List(Of dCaracteristicaItem)
  End Class

  Public Class dCaracteristicaItem

    Private _cid As Nullable(Of Integer)
    Private _caracteristicas_cid As Nullable(Of Integer)
    Private _valor As String

    Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property caracteristicas_cid() As Nullable(Of Integer)
      Get
        Return _caracteristicas_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _caracteristicas_cid = value
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

