Namespace nsEFD

  Public Class dEfdEnderecoContato

    Private _logradouro As String
    Private _numero As String
    Private _complemento As String
    Private _bairro As String
    Private _cep As String
    Private _dddTelefone As String
    Private _dddFax As String
    Private _email As String

    Public Property logradouro() As String
      Get
        Return _logradouro
      End Get
      Set(ByVal value As String)
        _logradouro = value
      End Set
    End Property

    Public Property numero() As String
      Get
        Return _numero
      End Get
      Set(ByVal value As String)
        _numero = value
      End Set
    End Property

    Public Property complemento() As String
      Get
        Return _complemento
      End Get
      Set(ByVal value As String)
        _complemento = value
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

    Public Property cep() As String
      Get
        Return _cep
      End Get
      Set(ByVal value As String)
        _cep = value
      End Set
    End Property

    Public Property dddTelefone() As String
      Get
        Return _dddTelefone
      End Get
      Set(ByVal value As String)
        _dddTelefone = value
      End Set
    End Property

    Public Property dddFax() As String
      Get
        Return _dddFax
      End Get
      Set(ByVal value As String)
        _dddFax = value
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

  End Class

End Namespace
