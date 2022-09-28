Namespace nsProduto

  Public Class ColecaoItensProdutos
    Inherits List(Of ColecaoProdutoItem)
  End Class

  Public Class ColecaoProdutoItem
    Inherits List(Of dProdutoItem)
  End Class

  Public Class dProdutoItem

    Private _produtos_cid As Nullable(Of Integer)
    Private _produtos_descricao As String
    Private _produtos_estoque As String
    Private _produtos_tamanho As String
    Private _produtos_valorVenda As Decimal
    Private _produtos_referencia As String
    Private _produtos_cor As String
    Private _item As Nullable(Of Integer)
    Private _caracteristicas_cid As Nullable(Of Integer)
    Private _caracteristicas_nome As String
    Private _caracteristicas_codigo As String
    Private _valor As String

    Public Property produtos_cid() As Nullable(Of Integer)
      Get
        Return _produtos_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _produtos_cid = value
      End Set
    End Property

    Public Property produtos_descricao() As String
      Get
        Return _produtos_descricao
      End Get
      Set(ByVal value As String)
        _produtos_descricao = value
      End Set
    End Property

    Public Property produtos_estoque() As String
      Get
        Return _produtos_estoque
      End Get
      Set(ByVal value As String)
        _produtos_estoque = value
      End Set
    End Property

    Public Property item() As Nullable(Of Integer)
      Get
        Return _item
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _item = value
      End Set
    End Property

    Public Property caracteristicas_cid() As Nullable(Of Integer)
      Get
        Return _caracteristicas_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _caracteristicas_cid = value
      End Set
    End Property

    Public Property caracteristicas_nome() As String
      Get
        Return _caracteristicas_nome
      End Get
      Set(ByVal value As String)
        _caracteristicas_nome = value
      End Set
    End Property

    Public Property caracteristicas_codigo() As String
      Get
        Return _caracteristicas_codigo
      End Get
      Set(ByVal value As String)
        _caracteristicas_codigo = value
      End Set
    End Property

    Public Property valor() As String
      Get
        Return _valor
      End Get
      Set(ByVal value As String)
        _valor = value
      End Set
    End Property

    Public Property Produtos_ValorVenda() As Decimal
      Get
        Return _produtos_valorVenda
      End Get
      Set(ByVal value As Decimal)
        _produtos_valorVenda = value
      End Set
    End Property

    Public Property Produtos_Tamanho() As String
      Get
        Return _produtos_tamanho
      End Get
      Set(ByVal value As String)
        _produtos_tamanho = value
      End Set
    End Property

    Public Property Produtos_Referencia() As String
      Get
        Return _produtos_referencia
      End Get
      Set(ByVal value As String)
        _produtos_referencia = value
      End Set
    End Property

    Public Property Produtos_Cor() As String
      Get
        Return _produtos_cor
      End Get
      Set(ByVal value As String)
        _produtos_cor = value
      End Set
    End Property

  End Class

End Namespace
