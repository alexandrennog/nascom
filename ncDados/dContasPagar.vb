Namespace nsContasPagar

  Public Class ColecaoContasPagar
    Inherits List(Of dContasPagar)
  End Class

  Public Class dContasPagar

    Private _cid As Nullable(Of Integer)
    Private _codigo As String
    Private _codigoBarra As String
    Private _valor As Nullable(Of Decimal)
    Private _aceite As Nullable(Of Boolean)
    Private _observacao As String
    Private _dataEmissao As String
    Private _dataVencimento As String
    Private _dataPagamento As String
    Private _valorPagamento As Nullable(Of Decimal)
    Private _fornecedor_cid As Nullable(Of Integer)
    Private _pago As Nullable(Of Boolean)

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

    Public Property codigoBarra() As String
      Get
        Return _codigoBarra
      End Get
      Set(ByVal value As String)
        _codigoBarra = value
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

    Public Property aceite() As Nullable(Of Boolean)
      Get
        Return _aceite
      End Get
      Set(ByVal value As Nullable(Of Boolean))
        _aceite = value
      End Set
    End Property

    Public Property observacao() As String
      Get
        Return _observacao
      End Get
      Set(ByVal value As String)
        _observacao = value
      End Set
    End Property

    Public Property dataEmissao() As String
      Get
        Return _dataEmissao
      End Get
      Set(ByVal value As String)
        _dataEmissao = value
      End Set
    End Property

    Public Property dataVencimento() As String
      Get
        Return _dataVencimento
      End Get
      Set(ByVal value As String)
        _dataVencimento = value
      End Set
    End Property

    Public Property dataPagamento() As String
      Get
        Return _dataPagamento
      End Get
      Set(ByVal value As String)
        _dataPagamento = value
      End Set
    End Property

    Public Property valorPagamento() As Nullable(Of Decimal)
      Get
        Return _valorPagamento
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _valorPagamento = value
      End Set
    End Property

    Public Property fornecedor_cid() As Nullable(Of Integer)
      Get
        Return _fornecedor_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _fornecedor_cid = value
      End Set
    End Property

    Public Property pago() As Nullable(Of Boolean)
      Get
        Return _pago
      End Get
      Set(ByVal value As Nullable(Of Boolean))
        _pago = value
      End Set
    End Property

  End Class

End Namespace
