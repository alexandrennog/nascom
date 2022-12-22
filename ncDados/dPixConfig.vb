Public Class dPixConfig

    Private _cliente As Integer
    Private _cpf As String
    Private _cnpj As String
    Private _nome As String
    Private _chave As String


    Public Property Cliente() As Integer
        Get
            Return _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property

    Public Property Cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    Public Property Cnpj() As String
        Get
            Return _cnpj
        End Get
        Set(ByVal value As String)
            _cnpj = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property Chave() As String
        Get
            Return _chave
        End Get
        Set(ByVal value As String)
            _chave = value
        End Set
    End Property

End Class
