Namespace nsEFD

  Public Class dEfdArquivo

    Private _versaoLeiaute As String
    Private _finalidadeArquivo As String
    Private _perfilArquivoFiscal As String

    Public Property versaoLeiaute() As String
      Get
        Return _versaoLeiaute
      End Get
      Set(ByVal value As String)
        _versaoLeiaute = value
      End Set
    End Property

    Public Property finalidadeArquivo() As String
      Get
        Return _finalidadeArquivo
      End Get
      Set(ByVal value As String)
        _finalidadeArquivo = value
      End Set
    End Property

    Public Property perfilArquivoFiscal() As String
      Get
        Return _perfilArquivoFiscal
      End Get
      Set(ByVal value As String)
        _perfilArquivoFiscal = value
      End Set
    End Property

  End Class

End Namespace
