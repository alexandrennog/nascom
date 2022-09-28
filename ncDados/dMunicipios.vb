Namespace nsMunicipios

  Public Class ColecaoMunicipios
    Inherits List(Of dMunicipios)
  End Class

  Public Class dMunicipios

    Private _cid As Nullable(Of Integer)
    Private _codigo_ibge As String
    Private _nome As String
    Private _estados_cid As Integer
    Private _situacao As String

    Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property codigo_ibge() As String
      Get
        Return _codigo_ibge
      End Get
      Set(ByVal value As String)
        _codigo_ibge = value
      End Set
    End Property

    Public Property nome() As String
      Get
        Return _nome
      End Get
      Set(ByVal value As String)
        _nome = value
      End Set
    End Property

    Public Property estados_cid() As Integer
      Get
        Return _estados_cid
      End Get
      Set(ByVal value As Integer)
        _estados_cid = value
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

  End Class

End Namespace

