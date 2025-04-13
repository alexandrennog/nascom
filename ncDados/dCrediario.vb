Namespace nsCrediario

  Public Class ColecaoCrediario
    Inherits List(Of dCrediario)
  End Class

  Public Class dCrediario

    Private _cid As Integer
    Private _controle As Integer
    Private _usuarioId As Integer
    Private _clienteId As Integer
    Private _parcelas As Integer
    Private _valortotal As Decimal
    Private _valorpago As Decimal
    Private _valorvenda As Decimal
    Private _saldodevedor As Decimal
    Private _dataVenda As Date
    Private _lojaId As Integer
    Private _terminal As String
    Private _notafiscal As String

    Public Property cid() As Integer
      Get
        Return _cid
      End Get
      Set(ByVal value As Integer)
        _cid = value
      End Set
    End Property

    Public Property controle() As Integer
      Get
        Return _controle
      End Get
      Set(ByVal value As Integer)
        _controle = value
      End Set
    End Property

    Public Property usuarioId() As Integer
      Get
        Return _usuarioId
      End Get
      Set(ByVal value As Integer)
        _usuarioId = value
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

    Public Property Parcelas() As Integer
      Get
        Return _parcelas
      End Get
      Set(ByVal value As Integer)
        _parcelas = value
      End Set
    End Property

    Public Property ValorTotal() As Decimal
      Get
        Return _valortotal
      End Get
      Set(ByVal value As Decimal)
        _valortotal = value
      End Set
    End Property

    Public Property ValorPago() As Decimal
      Get
        Return _valorpago
      End Get
      Set(ByVal value As Decimal)
        _valorpago = value
      End Set
    End Property

    Public Property ValorVenda() As Decimal
      Get
        Return _valorvenda
      End Get
      Set(ByVal value As Decimal)
        _valorvenda = value
      End Set
    End Property

    Public Property SaldoDevedor() As Decimal
      Get
        Return _saldodevedor
      End Get
      Set(ByVal value As Decimal)
        _saldodevedor = value
      End Set
    End Property

    Public Property DataVenda() As Date
      Get
        Return _dataVenda
      End Get
      Set(ByVal value As Date)
        _dataVenda = value
      End Set
    End Property

    Public Property LojaId() As Integer
      Get
        Return _lojaId
      End Get
      Set(ByVal value As Integer)
        _lojaId = value
      End Set
    End Property

    Public Property Terminal() As String
      Get
        Return _terminal
      End Get
      Set(ByVal value As String)
        _terminal = value
      End Set
    End Property

    Public Property NotaFiscal() As String
      Get
        Return _notafiscal
      End Get
      Set(ByVal value As String)
        _notafiscal = value
      End Set
    End Property

  End Class

End Namespace
