Namespace nsCliente

  Public Class ColecaoClienteEndereco
    Inherits List(Of dClienteEndereco)
  End Class

  Public Class dClienteEndereco

    Private _logradouro As String
    Private _numero As Nullable(Of Integer)
    Private _complemento As String
    Private _cidade As String
    Private _estado_cid As Nullable(Of Integer)
    Private _cep As Nullable(Of Integer)
    Private _dataInclusao As String
    Private _tipoResidencia As String
    Private _bairro As String
    Private _tipoEndereco As String
    Private _cliente_cid As Nullable(Of Integer)
    Private _valor As Nullable(Of Decimal)
        Private _tempo As String
        Private _siglaEstado As String

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

    Public Property dataInclusao() As String
      Get
        Return _dataInclusao
      End Get
      Set(ByVal value As String)
        _dataInclusao = value
      End Set
    End Property

    Public Property tipoResidencia() As String
      Get
        Return _tipoResidencia
      End Get
      Set(ByVal value As String)
        _tipoResidencia = value
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

    Public Property tipoEndereco() As String
      Get
        Return _tipoEndereco
      End Get
      Set(ByVal value As String)
        _tipoEndereco = value
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

    Public Property valor() As Nullable(Of Decimal)
      Get
        Return _valor
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _valor = value
      End Set
    End Property

    Public Property tempo() As String
      Get
        Return _tempo
      End Get
      Set(ByVal value As String)
        _tempo = value
      End Set
        End Property
        Public Property siglaEstado() As String
            Get
                Return _siglaEstado
            End Get
            Set(ByVal value As String)
                _siglaEstado = value
            End Set
        End Property

  End Class

End Namespace