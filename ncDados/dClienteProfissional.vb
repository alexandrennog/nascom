Namespace nsCliente

  Public Class ColecaoClienteProfissional
    Inherits List(Of dClienteProfissional)
  End Class

  Public Class dClienteProfissional

    Private _empresa As String
    Private _logradouro As String
    Private _numero As Nullable(Of Integer)
    Private _complemento As String
    Private _bairro As String
    Private _cidade As String
    Private _estado_cid As Nullable(Of Integer)
    Private _cep As Nullable(Of Integer)
    Private _ddd As String
    Private _telefone As String
    Private _ramal As String
    Private _dataAdmissao As String
    Private _cargo As String
    Private _salario As Nullable(Of Decimal)
    Private _cliente_cid As Nullable(Of Integer)

    Public Property empresa() As String
      Get
        Return _empresa
      End Get
      Set(ByVal value As String)
        _empresa = value
      End Set
    End Property

    Public Property logradouro() As String
      Get
        Return _logradouro
      End Get
      Set(ByVal value As String)
        _logradouro = value
      End Set
    End Property

    Public Property numero() As Nullable(Of Integer)
      Get
        Return _numero
      End Get
      Set(ByVal value As Nullable(Of Integer))
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

    Public Property cidade() As String
      Get
        Return _cidade
      End Get
      Set(ByVal value As String)
        _cidade = value
      End Set
    End Property

    Public Property estado_cid() As Nullable(Of Integer)
      Get
        Return _estado_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _estado_cid = value
      End Set
    End Property

    Public Property cep() As Nullable(Of Integer)
      Get
        Return _cep
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cep = value
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

    Public Property cliente_cid() As Nullable(Of Integer)
      Get
        Return _cliente_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cliente_cid = value
      End Set
    End Property

    Public Property ddd() As String
      Get
        Return _ddd
      End Get
      Set(ByVal value As String)
        _ddd = value
      End Set
    End Property

    Public Property telefone() As String
      Get
        Return _telefone
      End Get
      Set(ByVal value As String)
        _telefone = value
      End Set
    End Property

    Public Property ramal() As String
      Get
        Return _ramal
      End Get
      Set(ByVal value As String)
        _ramal = value
      End Set
    End Property

    Public Property dataAdmissao() As String
      Get
        Return _dataAdmissao
      End Get
      Set(ByVal value As String)
        _dataAdmissao = value
      End Set
    End Property

    Public Property cargo() As String
      Get
        Return _cargo
      End Get
      Set(ByVal value As String)
        _cargo = value
      End Set
    End Property

    Public Property salario() As Nullable(Of Decimal)
      Get
        Return _salario
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _salario = value
      End Set
    End Property

  End Class

End Namespace