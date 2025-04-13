Namespace nsEfd

  Public Class Colecao9900
    Inherits List(Of dReg9900)
  End Class

  Public Class dReg9900

    Private _reg As String
    Private _reg_blc As String
    Private _qtd_reg_blc As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property reg_blc() As String
      Get
        Return _reg_blc
      End Get
      Set(ByVal value As String)
        _reg_blc = value
      End Set
    End Property

    Public Property qtd_reg_blc() As Nullable(Of Integer)
      Get
        Return _qtd_reg_blc
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _qtd_reg_blc = value
      End Set
    End Property

    Public Function MontarReg9900(ByVal tipoRegistro As String, ByVal quantidadeRegistro As Integer) As dReg9900

      Dim registro As dReg9900 = New dReg9900()

      registro.reg = "9900"
      registro.reg_blc = tipoRegistro
      registro.qtd_reg_blc = quantidadeRegistro

      MontarReg9900 = registro

    End Function

  End Class

End Namespace