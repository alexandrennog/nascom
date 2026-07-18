Namespace nsEmpresa

    Public Class ColecaoEmpresa
        Inherits List(Of dEmpresa)
    End Class

    Public Class dEmpresa

        Private _cid As Nullable(Of Integer)
        Private _cnpj As String
        Private _razaoSocial As String
        Private _crt As Nullable(Of Byte)
        Private _uf As String
        Private _municipio As Nullable(Of Integer)
        Private _createdAt As Nullable(Of DateTime)

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
            End Set
        End Property

        Public Property cnpj() As String
            Get
                Return _cnpj
            End Get
            Set(ByVal value As String)
                _cnpj = value
            End Set
        End Property

        Public Property razaoSocial() As String
            Get
                Return _razaoSocial
            End Get
            Set(ByVal value As String)
                _razaoSocial = value
            End Set
        End Property

        ' 1 Simples Nacional / 2 Simples Nacional excesso sublimite / 3 Regime Normal
        Public Property crt() As Nullable(Of Byte)
            Get
                Return _crt
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _crt = value
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

        Public Property municipio() As Nullable(Of Integer)
            Get
                Return _municipio
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _municipio = value
            End Set
        End Property

        Public Property createdAt() As Nullable(Of DateTime)
            Get
                Return _createdAt
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _createdAt = value
            End Set
        End Property

    End Class

End Namespace
