Namespace nsProduto

  Public Class ColecaoProdutoTipoCaracteristica
    Inherits List(Of dProdutoTipoCaracteristica)
  End Class

  Public Class dProdutoTipoCaracteristica

    Private _cid As Nullable(Of Integer)
    Private _produtoTipo_cid As Nullable(Of Integer)
    Private _caracteristica_cid As Nullable(Of Integer)
    Private _caracteristica_nome As String
    Private _caracteristica_codigo As String
        Private _quantidade As Nullable(Of Decimal)

        Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
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

    Public Property caracteristica_cid() As Nullable(Of Integer)
      Get
        Return _caracteristica_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _caracteristica_cid = value
      End Set
    End Property

    Public Property caracteristica_nome() As String
      Get
        Return _caracteristica_nome
      End Get
      Set(ByVal value As String)
        _caracteristica_nome = value
      End Set
    End Property

    Public Property caracteristica_codigo() As String
      Get
        Return _caracteristica_codigo
      End Get
      Set(ByVal value As String)
        _caracteristica_codigo = value
      End Set
    End Property

        Public Property quantidade() As Nullable(Of Decimal)
            Get
                Return _quantidade
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _quantidade = value
            End Set
        End Property

    End Class

End Namespace
