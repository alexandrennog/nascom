Namespace nsEfd

  Public Class ColecaoC990
    Inherits List(Of dRegC990)
  End Class

  Public Class dRegC990

    Private _reg As String
    Private _qtd_lin_c As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin_c() As Nullable(Of Integer)
      Get
        Return _qtd_lin_c
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin_c = value
      End Set
    End Property

  End Class

End Namespace