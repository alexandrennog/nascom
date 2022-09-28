Namespace nsEfd

  Public Class ColecaoD990
    Inherits List(Of dRegD990)
  End Class

  Public Class dRegD990

    Private _reg As String
    Private _qtd_lin_d As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin_d() As Nullable(Of Integer)
      Get
        Return _qtd_lin_d
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin_d = value
      End Set
    End Property

  End Class

End Namespace