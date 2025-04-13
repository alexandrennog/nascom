Namespace nsGradeItem

  Public Class ColecaoGradeItem
    Inherits List(Of dGradeItem)
  End Class

  Public Class dGradeItem

    Private _produto_cid As Nullable(Of Integer)
    Private _item As Nullable(Of Integer)
    Private _descricao As String
    Private _referencia As String
    Private _dataUltimaVenda As Nullable(Of DateTime)
    Private _corMaterial As String
    Private _tamanho As String
    Private _estoque As String
    Private _codigoBarras As String
    Private _dataEntrada As Nullable(Of DateTime)
        Private _quantidade As Nullable(Of Decimal)
        Private _fornecedor_cid As Nullable(Of Integer)
    Private _fabricante_cid As Nullable(Of Integer)
    Private _grupo_cid As Nullable(Of Integer)
    Private _ordem As Boolean

    Public Property produto_cid() As Nullable(Of Integer)
      Get
        Return _produto_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _produto_cid = value
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

    Public Property descricao() As String
      Get
        Return _descricao
      End Get
      Set(ByVal value As String)
        _descricao = value
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

    Public Property dataUltimaVenda() As Nullable(Of DateTime)
      Get
        Return _dataUltimaVenda
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dataUltimaVenda = value
      End Set
    End Property

    Public Property corMaterial() As String
      Get
        Return _corMaterial
      End Get
      Set(ByVal value As String)
        _corMaterial = value
      End Set
    End Property

    Public Property tamanho() As String
      Get
        Return _tamanho
      End Get
      Set(ByVal value As String)
        _tamanho = value
      End Set
    End Property

    Public Property estoque() As String
      Get
        Return _estoque
      End Get
      Set(ByVal value As String)
        _estoque = value
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

    Public Property dataEntrada() As Nullable(Of DateTime)
      Get
        Return _dataEntrada
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dataEntrada = value
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

    Public Property grupo_cid() As Nullable(Of Integer)
      Get
        Return _grupo_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _grupo_cid = value
      End Set
    End Property

    Public Property ordem() As Boolean
      Get
        Return _ordem
      End Get
      Set(ByVal value As Boolean)
        _ordem = value
      End Set
    End Property

  End Class

End Namespace
