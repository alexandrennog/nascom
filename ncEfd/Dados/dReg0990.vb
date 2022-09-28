Namespace nsEfd

  Public Class Colecao0990
    Inherits List(Of dReg0990)
  End Class

  Public Class dReg0990

    Private _reg As String
    Private _qtd_lin_0 As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin_0() As Nullable(Of Integer)
      Get
        Return _qtd_lin_0
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin_0 = value
      End Set
    End Property

  End Class

End Namespace