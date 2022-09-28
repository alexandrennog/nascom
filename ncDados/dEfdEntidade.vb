Namespace nsEFD

    Public Class dEfdEntidade

        Private _nomeEmpresarial As String
        Private _tipoPessoa As String
        Private _cpfCnpj As String
        Private _uf As String
        Private _estados_cid As Nullable(Of Integer)
        Private _ufSigla As String
        Private _inscricaoEstadual As String
        Private _codigoMunicipio As String
        Private _municipioCodigoIbge As String
        Private _inscricaoMunicipal As String
        Private _inscricaoSuframa As String
        Private _tipoAtividade As String
        Private _nomeFantasia As String

        Public Property nomeEmpresarial() As String
            Get
                Return _nomeEmpresarial
            End Get
            Set(ByVal value As String)
                _nomeEmpresarial = value
            End Set
        End Property

        Public Property tipoPessoa() As String
            Get
                Return _tipoPessoa
            End Get
            Set(ByVal value As String)
                _tipoPessoa = value
            End Set
        End Property

        Public Property cpfCnpj() As String
            Get
                Return _cpfCnpj
            End Get
            Set(ByVal value As String)
                _cpfCnpj = value
            End Set
        End Property

        Public Property uf() As String
            Get
                Return _uf
            End Get
            Set(ByVal value As String)
                _uf = value
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

        Public Property ufSigla() As String
            Get
                Return _ufSigla
            End Get
            Set(ByVal value As String)
                _ufSigla = value
            End Set
        End Property

        Public Property inscricaoEstadual() As String
            Get
                Return _inscricaoEstadual
            End Get
            Set(ByVal value As String)
                _inscricaoEstadual = value
            End Set
        End Property

        Public Property codigoMunicipio() As String
            Get
                Return _codigoMunicipio
            End Get
            Set(ByVal value As String)
                _codigoMunicipio = value
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

        Public Property inscricaoMunicipal() As String
            Get
                Return _inscricaoMunicipal
            End Get
            Set(ByVal value As String)
                _inscricaoMunicipal = value
            End Set
        End Property

        Public Property inscricaoSuframa() As String
            Get
                Return _inscricaoSuframa
            End Get
            Set(ByVal value As String)
                _inscricaoSuframa = value
            End Set
        End Property

        Public Property tipoAtividade() As String
            Get
                Return _tipoAtividade
            End Get
            Set(ByVal value As String)
                _tipoAtividade = value
            End Set
        End Property

        Public Property nomeFantasia() As String
            Get
                Return _nomeFantasia
            End Get
            Set(ByVal value As String)
                _nomeFantasia = value
            End Set
        End Property

    End Class

End Namespace
