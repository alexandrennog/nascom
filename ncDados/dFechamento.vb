Public Class ColecaoFechamento
    Inherits List(Of dFechamento)
End Class
Public Class dFechamento

    Private _data As Date
    Private _dinheiro As Decimal
    Private _cheque As Decimal
    Private _chequePre As Decimal
    Private _cartaoDebito As Decimal
    Private _cartaoCredito As Decimal
    Private _crediario As Decimal
    Private _desconto As Decimal
    Private _recebido As Decimal
    Private _troco As Decimal
    Private _total As Decimal
    Private _troca As Decimal
    Private _vale As Decimal
    Private _defeito As Decimal
    Private _retirada As Decimal
    Private _valeEmitido As Decimal
    Private _caixa As String
    Private _crediarioPagamento As Decimal



    Public Property data() As DateTime
        Get
            Return _data
        End Get
        Set(ByVal value As DateTime)
            _data = value
        End Set
    End Property

    Public Property dinheiro() As Decimal
        Get
            Return _dinheiro
        End Get
        Set(ByVal value As Decimal)
            _dinheiro = value
        End Set
    End Property

    Public Property cheque() As Decimal
        Get
            Return _cheque
        End Get
        Set(ByVal value As Decimal)
            _cheque = value
        End Set
    End Property

    Public Property chequePre() As Decimal
        Get
            Return _chequePre
        End Get
        Set(ByVal value As Decimal)
            _chequePre = value
        End Set
    End Property

    Public Property cartaoDebito() As Decimal
        Get
            Return _cartaoDebito
        End Get
        Set(ByVal value As Decimal)
            _cartaoDebito = value
        End Set
    End Property

    Public Property cartaoCredito() As Decimal
        Get
            Return _cartaoCredito
        End Get
        Set(ByVal value As Decimal)
            _cartaoCredito = value
        End Set
    End Property

    Public Property crediario() As Decimal
        Get
            Return _crediario
        End Get
        Set(ByVal value As Decimal)
            _crediario = value
        End Set
    End Property

    Public Property desconto() As Decimal
        Get
            Return _desconto
        End Get
        Set(ByVal value As Decimal)
            _desconto = value
        End Set
    End Property

    Public Property recebido() As Decimal
        Get
            Return _recebido
        End Get
        Set(ByVal value As Decimal)
            _recebido = value
        End Set
    End Property

    Public Property troco() As Decimal
        Get
            Return _troco
        End Get
        Set(ByVal value As Decimal)
            _troco = value
        End Set
    End Property

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property


    Public Property troca() As Decimal
        Get
            Return _troca
        End Get
        Set(ByVal value As Decimal)
            _troca = value
        End Set
    End Property

    Public Property vale() As Decimal
        Get
            Return _vale
        End Get
        Set(ByVal value As Decimal)
            _vale = value
        End Set
    End Property

    Public Property defeito() As Decimal
        Get
            Return _defeito
        End Get
        Set(ByVal value As Decimal)
            _defeito = value
        End Set
    End Property

    Public Property retirada() As Decimal
        Get
            Return _retirada
        End Get
        Set(ByVal value As Decimal)
            _retirada = value
        End Set
    End Property

    Public Property valeEmitido() As Decimal
        Get
            Return _valeEmitido
        End Get
        Set(ByVal value As Decimal)
            _valeEmitido = value
        End Set
    End Property

    Public Property crediarioPagamento() As Decimal
        Get
            Return _crediarioPagamento
        End Get
        Set(ByVal value As Decimal)
            _crediarioPagamento = value
        End Set
    End Property


    Public Property caixa() As String
        Get
            Return _caixa
        End Get
        Set(ByVal value As String)
            _caixa = value
        End Set
    End Property

End Class
