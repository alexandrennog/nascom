Namespace nsEfd

  Public Class Colecao0190
    Inherits List(Of dReg0190)
  End Class

  Public Class dReg0190

    Private _reg As String
    Private _unid As String
    Private _descr As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property unid() As String
      Get
        Return _unid
      End Get
      Set(ByVal value As String)
        _unid = value
      End Set
    End Property

    Public Property descr() As String
      Get
        Return _descr
      End Get
      Set(ByVal value As String)
        _descr = value
      End Set
    End Property

  End Class

End Namespace
