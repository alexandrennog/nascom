Namespace nsEfd

  Public Class ColecaoG990
    Inherits List(Of dRegG990)
  End Class

  Public Class dRegG990

    Private _reg As String
    Private _qtd_lin_g As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin_g() As Nullable(Of Integer)
      Get
        Return _qtd_lin_g
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin_g = value
      End Set
    End Property

  End Class

End Namespace