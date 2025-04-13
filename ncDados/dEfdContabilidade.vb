Namespace nsEFD

    Public Class dEfdContabilidade

        Private _nomeContador As String
        Private _cpf As String
        Private _crc As String
        Private _cnpjEscritorio As String
        Private _logradouro As String
        Private _numero As String
        Private _complemento As String
        Private _bairro As String
        Private _estados_cid As Nullable(Of Integer)
        Private _municipio As String
        Private _municipioCodigoIbge As String
        Private _cep As String
        Private _dddTelefone As String
        Private _dddFax As String
        Private _email As String
        Private _contaAnaliticaContabil As String

        Public Property nomeContador() As String
            Get
                Return _nomeContador
            End Get
            Set(ByVal value As String)
                _nomeContador = value
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

        Public Property crc() As String
            Get
                Return _crc
            End Get
            Set(ByVal value As String)
                _crc = value
            End Set
        End Property

        Public Property cnpjEscritorio() As String
            Get
                Return _cnpjEscritorio
            End Get
            Set(ByVal value As String)
                _cnpjEscritorio = value
            End Set
        End Property

        Public Property logradouro() As String
            Get
                Return _logradouro
            End Get
            Set(ByVal value As String)
                _logradouro = value
            End Set
        End Property

        Public Property numero() As String
            Get
                Return _numero
            End Get
            Set(ByVal value As String)
                _numero = value
            End Set
        End Property

        Public Property complemento() As String
            Get
                Return _complemento
            End Get
            Set(ByVal value As String)
                _complemento = value
            End Set
        End Property

        Public Property bairro() As String
            Get
                Return _bairro
            End Get
            Set(ByVal value As String)
                _bairro = value
            End Set
        End Property

        Public Property estados_cid() As Nullable(Of Integer)
            Get
                Return _estados_cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _estados_cid = value
            End Set
        End Property

        Public Property municipio() As String
            Get
                Return _municipio
            End Get
            Set(ByVal value As String)
                _municipio = value
            End Set
        End Property

        Public Property municipioCodigoIbge() As String
            Get
                Return _municipioCodigoIbge
            End Get
            Set(ByVal value As String)
                _municipioCodigoIbge = value
            End Set
        End Property

        Public Property cep() As String
            Get
                Return _cep
            End Get
            Set(ByVal value As String)
                _cep = value
            End Set
        End Property

        Public Property dddTelefone() As String
            Get
                Return _dddTelefone
            End Get
            Set(ByVal value As String)
                _dddTelefone = value
            End Set
        End Property

        Public Property dddFax() As String
            Get
                Return _dddFax
            End Get
            Set(ByVal value As String)
                _dddFax = value
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

        Public Property contaAnaliticaContabil() As String
            Get
                Return _contaAnaliticaContabil
            End Get
            Set(ByVal value As String)
                _contaAnaliticaContabil = value
            End Set
        End Property

    End Class

End Namespace
