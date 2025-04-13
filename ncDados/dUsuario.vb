Namespace nsUsuario

  Public Class ColecaoUsuario
    Inherits List(Of dUsuario)
  End Class

  Public Class dUsuario

    Private _cid As Nullable(Of Integer)
    Private _usuario As String
    Private _senha As String
    Private _nomeCompleto As String
    Private _situacao As String
    Private _usuarioPerfil_cid As Nullable(Of Integer)
        Private _usuarioPerfil_codigo As String
        Private _descontoProduto As Nullable(Of Decimal)
    Private _descontoPedido As Nullable(Of Decimal)
        Private _comissao As Nullable(Of Decimal)
        Private _email As String

        Public Property cid() As Nullable(Of Integer)
      Get
        Return _cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _cid = value
      End Set
    End Property

    Public Property usuario() As String
      Get
        Return _usuario
      End Get
      Set(ByVal value As String)
        _usuario = value
      End Set
    End Property

    Public Property senha() As String
      Get
        Return _senha
      End Get
      Set(ByVal value As String)
        _senha = value
      End Set
    End Property

    Public Property nomeCompleto() As String
      Get
        Return _nomeCompleto
      End Get
      Set(ByVal value As String)
        _nomeCompleto = value
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

    Public Property usuarioPerfil_cid() As Nullable(Of Integer)
      Get
        Return _usuarioPerfil_cid
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _usuarioPerfil_cid = value
      End Set
    End Property

        Public Property usuarioPerfil_codigo() As String
            Get
                Return _usuarioPerfil_codigo
            End Get
            Set(ByVal value As String)
                _usuarioPerfil_codigo = value
            End Set
        End Property

        Public Property descontoProduto() As Nullable(Of Decimal)
      Get
        Return _descontoProduto
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _descontoProduto = value
      End Set
    End Property

    Public Property descontoPedido() As Nullable(Of Decimal)
      Get
        Return _descontoPedido
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _descontoPedido = value
      End Set
    End Property

        Public Property comissao() As Nullable(Of Decimal)
            Get
                Return _comissao
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _comissao = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property

    End Class

End Namespace
