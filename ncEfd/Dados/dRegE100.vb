Namespace nsEfd

  Public Class ColecaoE100
    Inherits List(Of dRegE100)
  End Class

  Public Class dRegE100

    Private _reg As String
    Private _dt_ini As Nullable(Of DateTime)
    Private _dt_fin As Nullable(Of DateTime)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property dt_ini() As Nullable(Of DateTime)
      Get
        Return _dt_ini
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_ini = value
      End Set
    End Property

    Public Property dt_fin() As Nullable(Of DateTime)
      Get
        Return _dt_fin
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_fin = value
      End Set
    End Property

  End Class

End Namespace