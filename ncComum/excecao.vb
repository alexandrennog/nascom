Namespace nsExcecao

  Public Class ExcecaoNascomercio
    Inherits System.Exception

    Public Sub New()
      MyBase.New()
    End Sub

    Public Sub New(ByVal mensasgem As String)
      MyBase.New(mensasgem)
    End Sub

    Public Sub New(ByVal mensasgem As String, ByVal innerException As System.Exception)
      MyBase.New(mensasgem, innerException)
    End Sub

  End Class

End Namespace
