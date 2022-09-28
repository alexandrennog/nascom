Namespace nsEfd

  Public Class Colecao0150
    Inherits List(Of dReg0150)
  End Class

  Public Class dReg0150

    Private _reg As String
    Private _cod_part As String
    Private _nome As String
    Private _cod_pais As String
    Private _cnpj As String
    Private _cpf As String
    Private _ie As String
    Private _cod_mun As String
    Private _suframa As String
    Private _ende As String
    Private _num As String
    Private _compl As String
    Private _bairro As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property cod_part() As String
      Get
        Return _cod_part
      End Get
      Set(ByVal value As String)
        _cod_part = value
      End Set
    End Property

    Public Property nome() As String
      Get
        Return _nome
      End Get
      Set(ByVal value As String)
        _nome = value
      End Set
    End Property

    Public Property cod_pais() As String
      Get
        Return _cod_pais
      End Get
      Set(ByVal value As String)
        _cod_pais = value
      End Set
    End Property

    Public Property cnpj() As String
      Get
        Return _cnpj
      End Get
      Set(ByVal value As String)
        _cnpj = value
      End Set
    End Property

    Public Property cpf() As String
      Get
        Return _cpf
      End Get
      Set(ByVal value As String)
        _cpf = value
      End Set
    End Property

    Public Property ie() As String
      Get
        Return _ie
      End Get
      Set(ByVal value As String)
        _ie = value
      End Set
    End Property

    Public Property cod_mun() As String
      Get
        Return _cod_mun
      End Get
      Set(ByVal value As String)
        _cod_mun = value
      End Set
    End Property

    Public Property suframa() As String
      Get
        Return _suframa
      End Get
      Set(ByVal value As String)
        _suframa = value
      End Set
    End Property

    Public Property ende() As String
      Get
        Return _ende
      End Get
      Set(ByVal value As String)
        _ende = value
      End Set
    End Property

    Public Property num() As String
      Get
        Return _num
      End Get
      Set(ByVal value As String)
        _num = value
      End Set
    End Property

    Public Property compl() As String
      Get
        Return _compl
      End Get
      Set(ByVal value As String)
        _compl = value
      End Set
    End Property

    Public Property bairro() As String
      Get
        Return _bairro
      End Get
      Set(ByVal value As String)
        _bairro = value
      End Set
    End Property

  End Class

End Namespace
