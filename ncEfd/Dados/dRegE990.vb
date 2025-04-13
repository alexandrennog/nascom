Namespace nsEfd

  Public Class ColecaoE990
    Inherits List(Of dRegE990)
  End Class

  Public Class dRegE990

    Private _reg As String
    Private _qtd_lin_e As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin_e() As Nullable(Of Integer)
      Get
        Return _qtd_lin_e
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin_e = value
      End Set
    End Property

  End Class

End Namespace