Namespace nsGradeEntrada

  Public Class ColecaoGradeEntrada
    Inherits List(Of dGradeEntrada)
  End Class

  Public Class dGradeEntrada

    Private _produto_cid As Nullable(Of Integer)
    Private _item As Nullable(Of Integer)
    Private _codigoBarras As String
    Private _tamanho As String
    Private _entrada_data As String
    Private _entrada_qtde As Nullable(Of Integer)

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

    Public Property codigoBarras() As String
      Get
        Return _codigoBarras
      End Get
      Set(ByVal value As String)
        _codigoBarras = value
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

    Public Property entrada_data() As String
      Get
        Return _entrada_data
      End Get
      Set(ByVal value As String)
        _entrada_data = value
      End Set
    End Property

    Public Property entrada_qtde() As Nullable(Of Integer)
      Get
        Return _entrada_qtde
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _entrada_qtde = value
      End Set
    End Property

  End Class

End Namespace
