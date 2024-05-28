Namespace nsLoja

  Public Class ColecaoLoja
    Inherits List(Of dLoja)
  End Class

  Public Class dLoja

    Private _cid As Nullable(Of Integer)
    Private _codigo As String
    Private _nomeFantasia As String
    Private _logradouro As String
    Private _numero As Nullable(Of Integer)
    Private _complemento As String
    Private _bairro As String
    Private _cidade As String
    Private _estado_cid As Nullable(Of Integer)
    Private _cep As Nullable(Of Integer)
    Private _cnpj As String
    Private _ddd As Nullable(Of Integer)
    Private _telefone As Nullable(Of Integer)
    Private _ramal As Nullable(Of Integer)
    Private _nomeContato As String
    Private _razaoSocial As String
    Private _situacao As String
    Private _spc_codigo_associado As String
    Private _spc_nome_informante As String
        Private _spc_controle_informante As String
        Private _inscestadual As String



        Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property nomeFantasia() As String
      Get
        Return _nomeFantasia
      End Get
      Set(ByVal value As String)
        _nomeFantasia = value
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

    Public Property telefone() As Nullable(Of Integer)
      Get
        Return _telefone
      End Get
      Set(ByVal value As Nullable(Of Integer))
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

    Public Property razaoSocial() As String
      Get
        Return _razaoSocial
      End Get
      Set(ByVal value As String)
        _razaoSocial = value
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

    Public Property spc_codigo_associado() As String
      Get
        Return _spc_codigo_associado
      End Get
      Set(ByVal value As String)
        _spc_codigo_associado = value
      End Set
    End Property

    Public Property spc_nome_informante() As String
      Get
        Return _spc_nome_informante
      End Get
      Set(ByVal value As String)
        _spc_nome_informante = value
      End Set
    End Property

        Public Property spc_controle_informante() As String
            Get
                Return _spc_controle_informante
            End Get
            Set(ByVal value As String)
                _spc_controle_informante = value
            End Set
        End Property
        Public Property Inscestadual() As String
            Get
                Return _inscestadual
            End Get
            Set(ByVal value As String)
                _inscestadual = value
            End Set
        End Property






    End Class

End Namespace
