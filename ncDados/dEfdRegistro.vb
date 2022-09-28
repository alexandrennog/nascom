Namespace nsEFD

  Public Class ColecaoRegistro
    Inherits List(Of dEfdRegistro)

    Public Sub Incluir(ByVal pCodigo As String, ByVal pQuantidade As String)
      Dim registro As dEfdRegistro = New dEfdRegistro()

      registro.codigo = pCodigo
      registro.quantidade = pQuantidade

      Me.Add(registro)
    End Sub
  End Class

  Public Class dEfdRegistro

    Private _codigo As String
        Private _quantidade As Decimal

        Public Property codigo() As String
      Get
        Return _codigo
      End Get
      Set(ByVal value As String)
        _codigo = value
      End Set
    End Property

        Public Property quantidade() As Decimal
            Get
                Return _quantidade
            End Get
            Set(ByVal value As Decimal)
                _quantidade = value
            End Set
        End Property

    End Class

End Namespace
