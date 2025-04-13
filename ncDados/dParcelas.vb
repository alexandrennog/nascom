Namespace nsCrediario

  Public Class ColecaoParcelas
    Inherits List(Of dParcelas)
  End Class

  Public Class dParcelas

    Private _cid As Integer
    Private _crediarioId As Integer
    Private _dataEmissao As Date
    Private _dataVencimento As Date
    Private _valor As Decimal
    Private _valorpago As Decimal
    Private _valorreceber As Decimal
    Private _situacao As String
    Private _codigoBarras As String
    Private _dataPagamento As Nullable(Of DateTime)
    Private _observacao As String
    Private _diasAtraso As Integer

    Public Property cid() As Integer
      Get
        Return _cid
      End Get
      Set(ByVal value As Integer)
        _cid = value
      End Set
    End Property

    Public Property crediarioId() As Integer
      Get
        Return _crediarioId
      End Get
      Set(ByVal value As Integer)
        _crediarioId = value
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

    Public Property dataVecimento() As Date
      Get
        Return _dataVencimento
      End Get
      Set(ByVal value As Date)
        _dataVencimento = value
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

    Public Property valorPago() As Decimal
      Get
        Return _valorpago
      End Get
      Set(ByVal value As Decimal)
        _valorpago = value
      End Set
    End Property

    Public Property valorReceber() As Decimal
      Get
        Return _valorreceber
      End Get
      Set(ByVal value As Decimal)
        _valorreceber = value
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

    Public Property codigoBarras() As String
      Get
        Return _codigoBarras
      End Get
      Set(ByVal value As String)
        _codigoBarras = value
      End Set
    End Property

    Public Property dataPagamento() As Nullable(Of DateTime)
      Get
        Return _dataPagamento
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dataPagamento = value
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

    Public Property diasAtraso() As Integer
      Get
        Return _diasAtraso
      End Get
      Set(ByVal value As Integer)
        _diasAtraso = value
      End Set
    End Property

  End Class

End Namespace
