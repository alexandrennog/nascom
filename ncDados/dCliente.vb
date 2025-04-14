Namespace nsCliente

    Public Class ColecaoCliente
        Inherits List(Of dCliente)
    End Class

    Public Class dCliente

        Private _cid As Nullable(Of Integer)
        Private _codigo As String
        Private _nome As String
        Private _endereco As String
        Private _estadoCivil As String
        Private _sexo As String
        Private _nomePai As String
        Private _nomeMae As String
        Private _situacao As String
        Private _rg As String
        Private _rgOrgaoEmissor As String
        Private _rgUf_cid As Nullable(Of Integer)
        Private _cpf As String
        Private _carteiraProfissional As String
        Private _dataNascimento As String
        Private _naturalidade As String
        Private _nacionalidade As String
        Private _dataInclusao As String
        Private _email As String
        Private _foto As String
        Private _ddd As String
        Private _telefone As String
        Private _dddcel As String
        Private _celular As String
        Private _veiculo As String

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property codigo() As String
            Get
                Return _cid
            End Get
            Set(ByVal value As String)
                _cid = value
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

        Public Property endereco() As String
            Get
                Return _endereco
            End Get
            Set(ByVal value As String)
                _endereco = value
            End Set
        End Property

        Public Property dataNascimento() As String
            Get
                Return _dataNascimento
            End Get
            Set(ByVal value As String)
                _dataNascimento = value
            End Set
        End Property

        Public Property naturalidade() As String
            Get
                Return _naturalidade
            End Get
            Set(ByVal value As String)
                _naturalidade = value
            End Set
        End Property

        Public Property nacionalidade() As String
            Get
                Return _nacionalidade
            End Get
            Set(ByVal value As String)
                _nacionalidade = value
            End Set
        End Property

        Public Property estadoCivil() As String
            Get
                Return _estadoCivil
            End Get
            Set(ByVal value As String)
                _estadoCivil = value
            End Set
        End Property

        Public Property sexo() As String
            Get
                Return _sexo
            End Get
            Set(ByVal value As String)
                _sexo = value
            End Set
        End Property

        Public Property nomePai() As String
            Get
                Return _nomePai
            End Get
            Set(ByVal value As String)
                _nomePai = value
            End Set
        End Property
        Public Property nomeMae() As String
            Get
                Return _nomeMae
            End Get
            Set(ByVal value As String)
                _nomeMae = value
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

        Public Property dataInclusao() As String
            Get
                Return _dataInclusao
            End Get
            Set(ByVal value As String)
                _dataInclusao = value
            End Set
        End Property
        Public Property rg() As String
            Get
                Return _rg
            End Get
            Set(ByVal value As String)
                _rg = value
            End Set
        End Property
        Public Property rgOrgaoEmissor() As String
            Get
                Return _rgOrgaoEmissor
            End Get
            Set(ByVal value As String)
                _rgOrgaoEmissor = value
            End Set
        End Property
        Public Property rgUf_cid() As Nullable(Of Integer)
            Get
                Return _rgUf_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _rgUf_cid = value
            End Set
        End Property
        Public Property cpf() As String
            Get
                Return _cpf
            End Get
            Set(ByVal value As String)
                _cpf = value
            End Set
        End Property

        Public Property carteiraProfissional() As String
            Get
                Return _carteiraProfissional
            End Get
            Set(ByVal value As String)
                _carteiraProfissional = value
            End Set
        End Property
        Public Property email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property

        Public Property foto() As String
            Get
                Return _foto
            End Get
            Set(ByVal value As String)
                _foto = value
            End Set
        End Property

        Public Property ddd() As String
            Get
                Return _ddd
            End Get
            Set(ByVal value As String)
                _ddd = value
            End Set
        End Property

        Public Property telefone() As String
            Get
                Return _telefone
            End Get
            Set(ByVal value As String)
                _telefone = value
            End Set
        End Property

        Public Property dddcel() As String
            Get
                Return _dddcel
            End Get
            Set(ByVal value As String)
                _dddcel = value
            End Set
        End Property

        Public Property celular() As String
            Get
                Return _celular
            End Get
            Set(ByVal value As String)
                _celular = value
            End Set
        End Property

        Public Property veiculo() As String
            Get
                Return _veiculo
            End Get
            Set(ByVal value As String)
                _veiculo = value
            End Set
        End Property

    End Class

End Namespace