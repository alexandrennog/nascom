Namespace nsCheques

  Public Class ColecaoCheques
    Inherits List(Of dCheques)
  End Class

  Public Class dCheques

    Private _cid As Integer
    Private _dataEmissao As Date
    Private _dataDeposito As Date
    Private _valor As Decimal
    Private _numero As String
    Private _vendaId As Integer
    Private _clienteId As Integer
    Private _baixado As String
    Private _bancoCodigo As String
    Private _bancoNome As String
    Private _agencia As String
    Private _conta As String

    Public Property cid() As Integer
      Get
        Return _cid
      End Get
      Set(ByVal value As Integer)
        _cid = value
      End Set
    End Property

    Public Property dataEmissao() As Date
      Get
        Return _dataEmissao
      End Get
      Set(ByVal value As Date)
        _dataEmissao = value
      End Set
    End Property

    Public Property dataDeposito() As Date
      Get
        Return _dataDeposito
      End Get
      Set(ByVal value As Date)
        _dataDeposito = value
      End Set
    End Property

    Public Property valor() As Decimal
      Get
        Return _valor
      End Get
      Set(ByVal value As Decimal)
        _valor = value
      End Set
    End Property

    Public Property Numero() As String
      Get
        Return _numero
      End Get
      Set(ByVal value As String)
        _numero = value
      End Set
    End Property

    Public Property vendasId() As Integer
      Get
        Return _vendaId
      End Get
      Set(ByVal value As Integer)
        _vendaId = value
      End Set
    End Property

    Public Property clienteId() As Integer
      Get
        Return _clienteId
      End Get
      Set(ByVal value As Integer)
        _clienteId = value
      End Set
    End Property

    Public Property baixado() As String
      Get
        Return _baixado
      End Get
      Set(ByVal value As String)
        _baixado = value
      End Set
    End Property

    Public Property bancoCodigo() As String
      Get
        Return _bancoCodigo
      End Get
      Set(ByVal value As String)
        _bancoCodigo = value
      End Set
    End Property

    Public Property bancoNome() As String
      Get
        Return _bancoNome
      End Get
      Set(ByVal value As String)
        _bancoNome = value
      End Set
    End Property

    Public Property agencia() As String
      Get
        Return _agencia
      End Get
      Set(ByVal value As String)
        _agencia = value
      End Set
    End Property

    Public Property conta() As String
      Get
        Return _conta
      End Get
      Set(ByVal value As String)
        _conta = value
      End Set
    End Property

  End Class

End Namespace
