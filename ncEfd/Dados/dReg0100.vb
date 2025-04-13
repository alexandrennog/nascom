Namespace nsEfd

  Public Class Colecao0100
    Inherits List(Of dReg0100)
  End Class

  Public Class dReg0100

    Private _reg As String
    Private _nome As String
    Private _cpf As String
    Private _crc As String
    Private _cnpj As String
    Private _cep As String
    Private _ende As String
    Private _num As String
    Private _compl As String
    Private _bairro As String
    Private _fone As String
    Private _fax As String
    Private _email As String
    Private _cod_mun As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
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

    Public Property cpf() As String
      Get
        Return _cpf
      End Get
      Set(ByVal value As String)
        _cpf = value
      End Set
    End Property

    Public Property crc() As String
      Get
        Return _crc
      End Get
      Set(ByVal value As String)
        _crc = value
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

    Public Property cep() As String
      Get
        Return _cep
      End Get
      Set(ByVal value As String)
        _cep = value
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

    Public Property fone() As String
      Get
        Return _fone
      End Get
      Set(ByVal value As String)
        _fone = value
      End Set
    End Property

    Public Property fax() As String
      Get
        Return _fax
      End Get
      Set(ByVal value As String)
        _fax = value
      End Set
    End Property

    Public Property email() As String
      Get
        Return _email
      End Get
      Set(ByVal value As String)
        _email = value
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

  End Class

End Namespace
