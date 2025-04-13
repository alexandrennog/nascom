Namespace nsEFD

  Public Class ColecaoEfdItem
    Inherits List(Of dEfdItem)
  End Class

  Public Class dEfdItem

    Private _produtoCodigo As String
    Private _produtoItem As String
    Private _codigoEfd As String
    Private _descricao As String
    Private _codigoBarras As String
    Private _aliquotaIcms As String
    Private _quantidade As String
    Private _unidadeMedidaCodigo As String
    Private _valorUnitario As String

    Public Property codigo() As String
      Get
        Return _produtoCodigo
      End Get
      Set(ByVal value As String)
        _produtoCodigo = value
      End Set
    End Property

    Public Property item() As String
      Get
        Return _produtoItem
      End Get
      Set(ByVal value As String)
        _produtoItem = value
      End Set
    End Property

    Public Property codigoEfd() As String
      Get
        Return _codigoEfd
      End Get
      Set(ByVal value As String)
        _codigoEfd = value
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

    Public Property codigoBarras() As String
      Get
        Return _codigoBarras
      End Get
      Set(ByVal value As String)
        _codigoBarras = value
      End Set
    End Property

    Public Property aliquotaIcms() As String
      Get
        Return _aliquotaIcms
      End Get
      Set(ByVal value As String)
        _aliquotaIcms = value
      End Set
    End Property

    Public Property quantidade() As String
      Get
        Return _quantidade
      End Get
      Set(ByVal value As String)
        _quantidade = value
      End Set
    End Property

    Public Property unidadeMedidaCodigo() As String
      Get
        Return _unidadeMedidaCodigo
      End Get
      Set(ByVal value As String)
        _unidadeMedidaCodigo = value
      End Set
    End Property

    Public Property valorUnitario() As String
      Get
        Return _valorUnitario
      End Get
      Set(ByVal value As String)
        _valorUnitario = value
      End Set
    End Property

  End Class

End Namespace