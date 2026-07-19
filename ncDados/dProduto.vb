Namespace nsProduto

    Public Class ColecaoProduto
        Inherits List(Of dProduto)
    End Class

    Public Class dProduto

        Private _cid As Nullable(Of Integer)
        Private _codigo As String
        Private _descricao As String
        Private _situacao As String
        Private _dataInclusao As String
        Private _valorCompra As Nullable(Of Decimal)
        Private _valorVenda As Nullable(Of Decimal)
        Private _produtoTipo_cid As Nullable(Of Integer)
        Private _fornecedor_cid As Nullable(Of Integer)
        Private _fabricante_cid As Nullable(Of Integer)
        Private _imagem As String
        Private _referencia As String
        Private _codigoBarras As String
        Private _estoqueMinimo As Nullable(Of Integer)
        Private _cor_cid As Nullable(Of Integer)
        Private _cor As String
        Private _grupo_cid As Nullable(Of Integer)
        Private _grupo As String
        Private _notaFiscalNumero As String
        Private _notaFiscalSerie As String
        Private _aliquota As String
        Private _dataInicio As String
        Private _dataFim As String
        Private _efdUnidadeMedidaCodigo As String
        Private _efdCodigoCategoria As String
        Private _efdCategoria As String
        Private _efdIntegracao As Nullable(Of Boolean)
        Private _ncm As String
        Private _cest As String
        Public Property ncm() As String
            Get
                Return _ncm
            End Get
            Set(ByVal value As String)
                _ncm = value
            End Set
        End Property
        Public Property cest() As String
            Get
                Return _cest
            End Get
            Set(ByVal value As String)
                _cest = value
            End Set
        End Property
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

        Public Property descricao() As String
            Get
                Return _descricao
            End Get
            Set(ByVal value As String)
                _descricao = value
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

        Public Property dataInclusao() As String
            Get
                Return _dataInclusao
            End Get
            Set(ByVal value As String)
                _dataInclusao = value
            End Set
        End Property

        Public Property valorCompra() As Nullable(Of Decimal)
            Get
                Return _valorCompra
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorCompra = value
            End Set
        End Property

        Public Property valorVenda() As Nullable(Of Decimal)
            Get
                Return _valorVenda
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _valorVenda = value
            End Set
        End Property

        Public Property produtoTipo_cid() As Nullable(Of Integer)
            Get
                Return _produtoTipo_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _produtoTipo_cid = value
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

        Public Property fabricante_cid() As Nullable(Of Integer)
            Get
                Return _fabricante_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _fabricante_cid = value
            End Set
        End Property

        Public Property imagem() As String
            Get
                Return _imagem
            End Get
            Set(ByVal value As String)
                _imagem = value
            End Set
        End Property

        Public Property referencia() As String
            Get
                Return _referencia
            End Get
            Set(ByVal value As String)
                _referencia = value
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

        Public Property cor_cid() As Nullable(Of Integer)
            Get
                Return _cor_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cor_cid = value
            End Set
        End Property

        Public Property cor() As String
            Get
                Return _cor
            End Get
            Set(ByVal value As String)
                _cor = value
            End Set
        End Property

        Public Property grupo_cid() As Nullable(Of Integer)
            Get
                Return _grupo_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _grupo_cid = value
            End Set
        End Property

        Public Property grupo() As String
            Get
                Return _grupo
            End Get
            Set(ByVal value As String)
                _grupo = value
            End Set
        End Property

        Public Property estoqueMinimo() As Nullable(Of Integer)
            Get
                Return _estoqueMinimo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _estoqueMinimo = value
            End Set
        End Property

        Public Property aliquota() As String
            Get
                Return _aliquota
            End Get
            Set(ByVal value As String)
                _aliquota = value
            End Set
        End Property

        Public Property notaFiscalNumero() As String
            Get
                Return _notaFiscalNumero
            End Get
            Set(ByVal value As String)
                _notaFiscalNumero = value
            End Set
        End Property

        Public Property notaFiscalSerie() As String
            Get
                Return _notaFiscalSerie
            End Get
            Set(ByVal value As String)
                _notaFiscalSerie = value
            End Set
        End Property

        Public Property dataInicio() As String
            Get
                Return _dataInicio
            End Get
            Set(ByVal value As String)
                _dataInicio = value
            End Set
        End Property

        Public Property dataFinal() As String
            Get
                Return _dataFim
            End Get
            Set(ByVal value As String)
                _dataFim = value
            End Set
        End Property

        Public Property efdUnidadeMedidaCodigo() As String
            Get
                Return _efdUnidadeMedidaCodigo
            End Get
            Set(ByVal value As String)
                _efdUnidadeMedidaCodigo = value
            End Set
        End Property

        Public Property efdCodigoCategoria() As String
            Get
                Return _efdCodigoCategoria
            End Get
            Set(ByVal value As String)
                _efdCodigoCategoria = value
            End Set
        End Property

        Public Property efdCategoria() As String
            Get
                Return _efdCategoria
            End Get
            Set(ByVal value As String)
                _efdCategoria = value
            End Set
        End Property

        Public Property efdIntegracao() As Nullable(Of Boolean)
            Get
                Return _efdIntegracao
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _efdIntegracao = value
            End Set
        End Property

    End Class

End Namespace
