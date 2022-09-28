Namespace nsCliente

  Public Class ColecaoClienteFinanceiro
    Inherits List(Of dClienteFinanceiro)
  End Class

  Public Class dClienteFinanceiro

    Private _limite As Nullable(Of Decimal)
    Private _situacaoCrediario As String
    Private _cliente_cid As Nullable(Of Integer)
    Private _banco1 As String
    Private _banco2 As String
    Private _agencia1 As String
    Private _agencia2 As String
    Private _conta1 As String
    Private _conta2 As String
    Private _gerente1 As String
    Private _gerente2 As String
    Private _referencia1 As String
    Private _referencia2 As String
    Private _ddd1 As String
    Private _ddd2 As String
    Private _telefone1 As String
    Private _telefone2 As String
    Private _observacoes As String
    Private _dataNegativa As String
    Private _motivo As String

    Public Property limite() As Nullable(Of Decimal)
      Get
        Return _limite
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _limite = value
      End Set
    End Property

    Public Property situacaoCrediario() As String
      Get
        Return _situacaoCrediario
      End Get
      Set(ByVal value As String)
        _situacaoCrediario = value
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

    Public Property banco1() As String
      Get
        Return _banco1
      End Get
      Set(ByVal value As String)
        _banco1 = value
      End Set
    End Property

    Public Property banco2() As String
      Get
        Return _banco2
      End Get
      Set(ByVal value As String)
        _banco2 = value
      End Set
    End Property

    Public Property agencia1() As String
      Get
        Return _agencia1
      End Get
      Set(ByVal value As String)
        _agencia1 = value
      End Set
    End Property

    Public Property agencia2() As String
      Get
        Return _agencia2
      End Get
      Set(ByVal value As String)
        _agencia2 = value
      End Set
    End Property

    Public Property conta1() As String
      Get
        Return _conta1
      End Get
      Set(ByVal value As String)
        _conta1 = value
      End Set
    End Property

    Public Property conta2() As String
      Get
        Return _conta2
      End Get
      Set(ByVal value As String)
        _conta2 = value
      End Set
    End Property

    Public Property gerente1() As String
      Get
        Return _gerente1
      End Get
      Set(ByVal value As String)
        _gerente1 = value
      End Set
    End Property

    Public Property gerente2() As String
      Get
        Return _gerente2
      End Get
      Set(ByVal value As String)
        _gerente2 = value
      End Set
    End Property

    Public Property referencia1() As String
      Get
        Return _referencia1
      End Get
      Set(ByVal value As String)
        _referencia1 = value
      End Set
    End Property

    Public Property referencia2() As String
      Get
        Return _referencia2
      End Get
      Set(ByVal value As String)
        _referencia2 = value
      End Set
    End Property

    Public Property ddd1() As String
      Get
        Return _ddd1
      End Get
      Set(ByVal value As String)
        _ddd1 = value
      End Set
    End Property

    Public Property ddd2() As String
      Get
        Return _ddd2
      End Get
      Set(ByVal value As String)
        _ddd2 = value
      End Set
    End Property

    Public Property telefone1() As String
      Get
        Return _telefone1
      End Get
      Set(ByVal value As String)
        _telefone1 = value
      End Set
    End Property

    Public Property telefone2() As String
      Get
        Return _telefone2
      End Get
      Set(ByVal value As String)
        _telefone2 = value
      End Set
    End Property

    Public Property observacoes() As String
      Get
        Return _observacoes
      End Get
      Set(ByVal value As String)
        _observacoes = value
      End Set
    End Property

    Public Property dataNegativacao() As String
      Get
        Return _dataNegativa
      End Get
      Set(ByVal value As String)
        _dataNegativa = value
      End Set
    End Property

    Public Property motivo() As String
      Get
        Return _motivo
      End Get
      Set(ByVal value As String)
        _motivo = value
      End Set
    End Property

  End Class

End Namespace