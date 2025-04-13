Namespace nsNotaFiscalFornecedor

    Public Class ColecaoNotaFiscalFornecedor
        Inherits List(Of dNotaFiscalFornecedor)
    End Class

    Public Class dNotaFiscalFornecedor

        Private _cid As Nullable(Of Integer)
        Private _numero As String
        Private _serie As String
        Private _fornecedor_cid As Nullable(Of Integer)
        Private _fornecedor_nome As String
        Private _dataEmissao As String
        Private _dataInclusao As Nullable(Of DateTime)
        Private _valorBaseIcms As Nullable(Of Decimal)
        Private _valorIcms As Nullable(Of Decimal)
        Private _valorBaseIcmsSubstituicao As Nullable(Of Decimal)
        Private _valorIcmsSubstituicao As Nullable(Of Decimal)
        Private _valorTotalIpi As Nullable(Of Decimal)
        Private _valorTotalProdutos As Nullable(Of Decimal)
        Private _valorTotalNota As Nullable(Of Decimal)

        Private _tipoFluxo_cid As Nullable(Of Integer)
        Private _tipoEmissao_cid As Nullable(Of Integer)
        Private _tipoNotaFiscal_cid As Nullable(Of Integer)
        Private _tipoPagamento_cid As Nullable(Of Integer)
        Private _tipoFrete_cid As Nullable(Of Integer)
        Private _situacaoNotaFiscal_cid As Nullable(Of Integer)

        Private _chaveNotaFiscalEletronica As String
        Private _dataEntrada As Nullable(Of DateTime)
        Private _valorFrete As Nullable(Of Decimal)
        Private _valorSeguro As Nullable(Of Decimal)
        Private _valorDesconto As Nullable(Of Decimal)
        Private _valorOutrasDespesas As Nullable(Of Decimal)
        Private _valorAbatimento As Nullable(Of Decimal)
        Private _valorTotalPis As Nullable(Of Decimal)
        Private _valorPisRetidoSubstituicao As Nullable(Of Decimal)
        Private _valorTotalCofins As Nullable(Of Decimal)
        Private _valorCofinsRetidoSubstituicao As Nullable(Of Decimal)

        Private _produtoCodigo As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property numero() As String
            Get
                Return _numero
            End Get
            Set(ByVal value As String)
                _numero = value
            End Set
        End Property

        Public Property serie() As String
            Get
                Return _serie
            End Get
            Set(ByVal value As String)
                _serie = value
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

        Public Property dataEmissao() As String
            Get
                Return _dataEmissao
            End Get
            Set(ByVal value As String)
                _dataEmissao = value
            End Set
        End Property

        Public Property dataInclusao() As Nullable(Of DateTime)
            Get
                Return _dataInclusao
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _dataInclusao = value
            End Set
        End Property

        Public Property valorBaseIcms() As Nullable(Of Decimal)
            Get
                Return _valorBaseIcms
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorBaseIcms = value
            End Set
        End Property

        Public Property valorIcms() As Nullable(Of Decimal)
            Get
                Return _valorIcms
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorIcms = value
            End Set
        End Property

        Public Property valorBaseIcmsSubstituicao() As Nullable(Of Decimal)
            Get
                Return _valorBaseIcmsSubstituicao
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorBaseIcmsSubstituicao = value
            End Set
        End Property

        Public Property valorIcmsSubstituicao() As Nullable(Of Decimal)
            Get
                Return _valorIcmsSubstituicao
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorIcmsSubstituicao = value
            End Set
        End Property

        Public Property valorTotalIpi() As Nullable(Of Decimal)
            Get
                Return _valorTotalIpi
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorTotalIpi = value
            End Set
        End Property

        Public Property valorTotalProdutos() As Nullable(Of Decimal)
            Get
                Return _valorTotalProdutos
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorTotalProdutos = value
            End Set
        End Property

        Public Property valorTotalNota() As Nullable(Of Decimal)
            Get
                Return _valorTotalNota
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorTotalNota = value
            End Set
        End Property

        Public Property fornecedorNome() As String
            Get
                Return _fornecedor_nome
            End Get
            Set(ByVal value As String)
                _fornecedor_nome = value
            End Set
        End Property

        Public Property tipoFluxo_cid() As Nullable(Of Integer)
            Get
                Return _tipoFluxo_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _tipoFluxo_cid = value
            End Set
        End Property

        Public Property tipoEmissao_cid() As Nullable(Of Integer)
            Get
                Return _tipoEmissao_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _tipoEmissao_cid = value
            End Set
        End Property

        Public Property tipoNotaFiscal_cid() As Nullable(Of Integer)
            Get
                Return _tipoNotaFiscal_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _tipoNotaFiscal_cid = value
            End Set
        End Property

        Public Property tipoPagamento_cid() As Nullable(Of Integer)
            Get
                Return _tipoPagamento_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _tipoPagamento_cid = value
            End Set
        End Property

        Public Property tipoFrete_cid() As Nullable(Of Integer)
            Get
                Return _tipoFrete_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _tipoFrete_cid = value
            End Set
        End Property

        Public Property situacaoNotaFiscal_cid() As Nullable(Of Integer)
            Get
                Return _situacaoNotaFiscal_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _situacaoNotaFiscal_cid = value
            End Set
        End Property

        Public Property chaveNotaFiscalEletronica() As String
            Get
                Return _chaveNotaFiscalEletronica
            End Get
            Set(ByVal value As String)
                _chaveNotaFiscalEletronica = value
            End Set
        End Property

        Public Property dataEntrada() As Nullable(Of DateTime)
            Get
                Return _dataEntrada
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _dataEntrada = value
            End Set
        End Property

        Public Property valorFrete() As Nullable(Of Decimal)
            Get
                Return _valorFrete
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorFrete = value
            End Set
        End Property

        Public Property valorSeguro() As Nullable(Of Decimal)
            Get
                Return _valorSeguro
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorSeguro = value
            End Set
        End Property

        Public Property valorDesconto() As Nullable(Of Decimal)
            Get
                Return _valorDesconto
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorDesconto = value
            End Set
        End Property

        Public Property valorOutrasDespesas() As Nullable(Of Decimal)
            Get
                Return _valorOutrasDespesas
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorOutrasDespesas = value
            End Set
        End Property

        Public Property valorAbatimento() As Nullable(Of Decimal)
            Get
                Return _valorAbatimento
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorAbatimento = value
            End Set
        End Property

        Public Property valorTotalPis() As Nullable(Of Decimal)
            Get
                Return _valorTotalPis
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorTotalPis = value
            End Set
        End Property

        Public Property valorPisRetidoSubstituicao() As Nullable(Of Decimal)
            Get
                Return _valorPisRetidoSubstituicao
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorPisRetidoSubstituicao = value
            End Set
        End Property

        Public Property valorTotalCofins() As Nullable(Of Decimal)
            Get
                Return _valorTotalCofins
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorTotalCofins = value
            End Set
        End Property

        Public Property valorCofinsRetidoSubstituicao() As Nullable(Of Decimal)
            Get
                Return _valorCofinsRetidoSubstituicao
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorCofinsRetidoSubstituicao = value
            End Set
        End Property

        Public Property produtoCodigo() As String
            Get
                Return _produtoCodigo
            End Get
            Set(ByVal value As String)
                _produtoCodigo = value
            End Set
        End Property


    End Class

End Namespace