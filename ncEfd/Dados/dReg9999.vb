Namespace nsEfd

  Public Class Colecao9999
    Inherits List(Of dReg9999)
  End Class

  Public Class dReg9999

    Private _reg As String
    Private _qtd_lin As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property qtd_lin() As Nullable(Of Integer)
      Get
        Return _qtd_lin
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_lin = value
      End Set
    End Property

  End Class

End Namespace