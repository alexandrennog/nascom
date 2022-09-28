Imports ncDados.nsProduto

Namespace nsEtiquetaProdutoImpressao

  Public Class ColecaoEtiquetaProdutoImpressao
    Inherits List(Of dEtiquetaProdutoImpressao)
  End Class

  Public Class dEtiquetaProdutoImpressao

    Private _loja As String
    Private _fabricante As String
    Private _produto As dProduto
    Private _colecaoProdutoItem As ColecaoProdutoItem
    Private _corNome As String
    Private _data As String
    Private _produto_cid As String
    Private _codigoBarras As String

    Public Property loja() As String
      Get
        Return _loja
      End Get
      Set(ByVal value As String)
        _loja = value
      End Set
    End Property

    Public Property fabricante() As String
      Get
        Return _fabricante
      End Get
      Set(ByVal value As String)
        _fabricante = value
      End Set
    End Property

    Public Property produto() As dProduto
      Get
        Return _produto
      End Get
      Set(ByVal value As dProduto)
        _produto = value
      End Set
    End Property

    Public Property colecaoProdutoItem() As ColecaoProdutoItem
      Get
        Return _colecaoProdutoItem
      End Get
      Set(ByVal value As ColecaoProdutoItem)
        _colecaoProdutoItem = value
      End Set
    End Property

    Public Property corNome() As String
      Get
        Return _corNome
      End Get
      Set(ByVal value As String)
        _corNome = value
      End Set
    End Property

    Public Property data() As String
      Get
        Return _data
      End Get
      Set(ByVal value As String)
        _data = value
      End Set
    End Property

    Public Property produto_cid() As String
      Get
        Return _produto_cid
      End Get
      Set(ByVal value As String)
        _produto_cid = value
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

  End Class

End Namespace

