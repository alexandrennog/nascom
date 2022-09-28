Namespace nsVenda

    Public Class ColecaoVenda
        Inherits List(Of dVenda)
    End Class

    Public Class dVenda

        Private _controle As Integer
        Private _usuarioId As Integer
        Private _clienteId As Integer
        Private _ordemServicoId As String
        Private _data As DateTime
        Private _dataFim As DateTime
        Private _dinheiro As Decimal
        Private _cheque As Decimal
        Private _chequePre As Decimal
        Private _cartaoDebito As Decimal
        Private _cartaoCredito As Decimal
        Private _crediario As Decimal
        Private _crediarioPagamento As Decimal
        Private _parcelas As Integer
        Private _desconto As Decimal
        Private _condicao As Integer
        Private _recebido As Decimal
        Private _troco As Decimal
        Private _total As Decimal
        Private _troca As Decimal
        Private _vale As Decimal
        Private _defeito As Decimal
        Private _retirada As Decimal
        Private _terminal As String
        Private _valeEmitido As Decimal
        Private _vendedor As String
        Private _caixa As String
        Private _valorProduto As Nullable(Of Decimal)
        Private _valorCusto As Nullable(Of Decimal)

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

        Public Property ordemServicoId() As String
            Get
                Return _ordemServicoId
            End Get
            Set(ByVal value As String)
                _ordemServicoId = value
            End Set
        End Property

        Public Property Data() As DateTime
            Get
                Return _data
            End Get
            Set(ByVal value As DateTime)
                _data = value
            End Set
        End Property

        Public Property DataFim() As DateTime
            Get
                Return _dataFim
            End Get
            Set(ByVal value As DateTime)
                _dataFim = value
            End Set
        End Property

        Public Property Dinheiro() As Decimal
            Get
                Return _dinheiro
            End Get
            Set(ByVal value As Decimal)
                _dinheiro = value
            End Set
        End Property

        Public Property Cheque() As Decimal
            Get
                Return _cheque
            End Get
            Set(ByVal value As Decimal)
                _cheque = value
            End Set
        End Property

        Public Property ChequePre() As Decimal
            Get
                Return _chequePre
            End Get
            Set(ByVal value As Decimal)
                _chequePre = value
            End Set
        End Property

        Public Property CartaoDebito() As Decimal
            Get
                Return _cartaoDebito
            End Get
            Set(ByVal value As Decimal)
                _cartaoDebito = value
            End Set
        End Property

        Public Property CartaoCredito() As Decimal
            Get
                Return _cartaoCredito
            End Get
            Set(ByVal value As Decimal)
                _cartaoCredito = value
            End Set
        End Property

        Public Property Crediario() As Decimal
            Get
                Return _crediario
            End Get
            Set(ByVal value As Decimal)
                _crediario = value
            End Set
        End Property

        Public Property CrediarioPagamento() As Decimal
            Get
                Return _crediarioPagamento
            End Get
            Set(ByVal value As Decimal)
                _crediarioPagamento = value
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

        Public Property Desconto() As Decimal
            Get
                Return _desconto
            End Get
            Set(ByVal value As Decimal)
                _desconto = value
            End Set
        End Property

        Public Property Condicao() As Integer
            Get
                Return _condicao
            End Get
            Set(ByVal value As Integer)
                _condicao = value
            End Set
        End Property

        Public Property Recebido() As Decimal
            Get
                Return _recebido
            End Get
            Set(ByVal value As Decimal)
                _recebido = value
            End Set
        End Property

        Public Property Troco() As Decimal
            Get
                Return _troco
            End Get
            Set(ByVal value As Decimal)
                _troco = value
            End Set
        End Property

        Public Property Total() As Decimal
            Get
                Return _total
            End Get
            Set(ByVal value As Decimal)
                _total = value
            End Set
        End Property

        Public Property Troca() As Decimal
            Get
                Return _troca
            End Get
            Set(ByVal value As Decimal)
                _troca = value
            End Set
        End Property

        Public Property Vale() As Decimal
            Get
                Return _vale
            End Get
            Set(ByVal value As Decimal)
                _vale = value
            End Set
        End Property

        Public Property ValeEmitido() As Decimal
            Get
                Return _valeEmitido
            End Get
            Set(ByVal value As Decimal)
                _valeEmitido = value
            End Set
        End Property

        Public Property Defeito() As Decimal
            Get
                Return _defeito
            End Get
            Set(ByVal value As Decimal)
                _defeito = value
            End Set
        End Property

        Public Property Retirada() As Decimal
            Get
                Return _retirada
            End Get
            Set(ByVal value As Decimal)
                _retirada = value
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

        Public Property Vendedor() As String
            Get
                Return _vendedor
            End Get
            Set(ByVal value As String)
                _vendedor = value
            End Set
        End Property

        Public Property Caixa() As String
            Get
                Return _caixa
            End Get
            Set(ByVal value As String)
                _caixa = value
            End Set
        End Property

        Public Property valorProduto() As Nullable(Of Decimal)
            Get
                Return _valorProduto
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorProduto = value
            End Set
        End Property

        Public Property valorCusto() As Nullable(Of Decimal)
            Get
                Return _valorCusto
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorCusto = value
            End Set
        End Property

    End Class

End Namespace
