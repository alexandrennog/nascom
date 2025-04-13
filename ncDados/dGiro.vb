Namespace nsGiro

  Public Class ColecaoGiro
    Inherits List(Of dGiro)
  End Class

  Public Class dGiro

    Private _produto_cid As Nullable(Of Integer)
    Private _codigoBarras As String
    Private _dataInicio As String
    Private _dataFim As String
    Private _dias As Nullable(Of Integer)
        Private _quantidade As Nullable(Of Decimal)
        Private _dataAtual As String
    Private _usuario_cid As Nullable(Of Integer)
    Private _usuario_nomeCompleto As String
    Private _situacao As String

    Public Property produto_cid() As Nullable(Of Integer)
      Get
        Return _produto_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
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

    Public Property dataInicio() As String
      Get
        Return _dataInicio
      End Get
      Set(ByVal value As String)
        _dataInicio = value
      End Set
    End Property

    Public Property dataFim() As String
      Get
        Return _dataFim
      End Get
      Set(ByVal value As String)
        _dataFim = value
      End Set
    End Property

    Public Property dias() As Nullable(Of Integer)
      Get
        Return _dias
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _dias = value
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

        Public Property dataAtual() As String
      Get
        Return _dataAtual
      End Get
      Set(ByVal value As String)
        _dataAtual = value
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
