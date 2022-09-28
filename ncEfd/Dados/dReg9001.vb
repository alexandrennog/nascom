Namespace nsEfd

  Public Class Colecao9001
    Inherits List(Of dReg9001)
  End Class

  Public Class dReg9001

    Private _reg As String
    Private _ind_mov As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property ind_mov() As String
      Get
        Return _ind_mov
      End Get
      Set(ByVal value As String)
        _ind_mov = value
      End Set
    End Property

  End Class

End Namespace