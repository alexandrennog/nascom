Namespace nsFornecedor

  Public Class ColecaoFornecedor
    Inherits List(Of dFornecedor)
  End Class

  Public Class dFornecedor

    Private _cid As Nullable(Of Integer)
    Private _codigo As String
    Private _nome As String
    Private _logradouro As String
    Private _numero As Nullable(Of Integer)
    Private _complemento As String
    Private _bairro As String
    Private _cidade_cid As Nullable(Of Integer)
    Private _municipioCodigoIbge As String
    Private _estado_cid As Nullable(Of Integer)
    Private _cep As Nullable(Of Integer)
    Private _inscricaoEstadual As String
    Private _cnpj As String
    Private _ddd As Nullable(Of Integer)
    Private _telefone As String
    Private _ramal As Nullable(Of Integer)
    Private _nomeContato As String
    Private _situacao As String

    Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property codigo() As String
      Get
        Return _codigo
      End Get
      Set(ByVal value As String)
        _codigo = value
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

    Public Property bairro() As String
      Get
        Return _bairro
      End Get
      Set(ByVal value As String)
        _bairro = value
      End Set
    End Property

    Public Property cidade_cid() As Nullable(Of Integer)
      Get
        Return _cidade_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cidade_cid = value
      End Set
    End Property

    Public Property municipioCodigoIbge() As String
      Get
        Return _municipioCodigoIbge
      End Get
      Set(ByVal value As String)
        _municipioCodigoIbge = value
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

    Public Property inscricaoEstadual() As String
      Get
        Return _inscricaoEstadual
      End Get
      Set(ByVal value As String)
        _inscricaoEstadual = value
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

    Public Property ddd() As Nullable(Of Integer)
      Get
        Return _ddd
      End Get
      Set(ByVal value As Nullable(Of Integer))
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

    Public Property ramal() As Nullable(Of Integer)
      Get
        Return _ramal
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _ramal = value
      End Set
    End Property

    Public Property nomeContato() As String
      Get
        Return _nomeContato
      End Get
      Set(ByVal value As String)
        _nomeContato = value
      End Set
    End Property

    Public Property situacao() As String
      Get
        Return _situacao
      End Get
      Set(ByVal value As String)
        _situacao = value
      End Set
    End Property

  End Class

End Namespace