Namespace nsProdutoEtiqueta

  Public Class ColecaoProdutoEtiqueta
    Inherits List(Of dProdutoEtiqueta)
  End Class

  Public Class dProdutoEtiqueta

    Private _data As Nullable(Of DateTime)
    Private _usuario_cid As Nullable(Of Integer)
    Private _usuario_nomeCompleto As String
    Private _produto_cid As Nullable(Of Integer)
    Private _produtoItem_codigoBarras As String
        Private _quantidade As Nullable(Of Decimal)
        Private _impressao As String
    Private _referencia As String
    Private _cor As String

    Public Property data() As Nullable(Of DateTime)
      Get
        Return _data
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _data = value
      End Set
    End Property

    Public Property usuario_cid() As Nullable(Of Integer)
      Get
        Return _usuario_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _usuario_cid = value
      End Set
    End Property

    Public Property usuario_nomeCompleto() As String
      Get
        Return _usuario_nomeCompleto
      End Get
      Set(ByVal value As String)
        _usuario_nomeCompleto = value
      End Set
    End Property

    Public Property produto_cid() As Nullable(Of Integer)
      Get
        Return _produto_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _produto_cid = value
      End Set
    End Property

    Public Property produtoItem_codigoBarras() As String
      Get
        Return _produtoItem_codigoBarras
      End Get
      Set(ByVal value As String)
        _produtoItem_codigoBarras = value
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

        Public Property impressao() As String
      Get
        Return _impressao
      End Get
      Set(ByVal value As String)
        _impressao = value
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
    Public Property cor() As String
      Get
        Return _cor
      End Get
      Set(ByVal value As String)
        _cor = value
      End Set
    End Property

  End Class

End Namespace
