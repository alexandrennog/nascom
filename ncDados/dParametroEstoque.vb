Namespace nsdParametroEstoque

    Public Class ColecaoParametroEstoque
        Inherits List(Of dEstoque)
    End Class

    Public Class dParametroEstoque

        Private _cidFornecedor As Nullable(Of Integer)
        Private _cidFabricante As Nullable(Of Integer)
        Private _cidGrupo As Nullable(Of Integer)
        Private _descricao As String
        Private _valor As String
        Private _dataCadastroInicio As String
        Private _dataCadastroFim As String

        Public Property cidFornecedor() As Nullable(Of Integer)
            Get
                Return _cidFornecedor
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cidFornecedor = value
            End Set
        End Property

        Public Property cidFabricante() As Nullable(Of Integer)
            Get
                Return _cidFabricante
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cidFabricante = value
            End Set
        End Property

        Public Property cidGrupo() As Nullable(Of Integer)
            Get
                Return _cidGrupo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cidGrupo = value
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

        Public Property valor() As String
            Get
                Return _valor
            End Get
            Set(ByVal value As String)
                _valor = value
            End Set
        End Property

        ' Filtro por periodo de cadastro do produto (dataInclusao), formato AAAA-MM-DD ou Nothing/vazio = sem filtro
        Public Property dataCadastroInicio() As String
            Get
                Return _dataCadastroInicio
            End Get
            Set(ByVal value As String)
                _dataCadastroInicio = value
            End Set
        End Property

        Public Property dataCadastroFim() As String
            Get
                Return _dataCadastroFim
            End Get
            Set(ByVal value As String)
                _dataCadastroFim = value
            End Set
        End Property

    End Class

End Namespace

