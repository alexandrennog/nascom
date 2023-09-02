Public Class dPixConfig

    Private _cliente As Integer
    Private _cpf As String
    Private _cnpj As String
    Private _nome As String
    Private _chave As String
    Private _appKey As String
    Private _ClientID As String
    Private _ClientSecret As String
    Private _certPath As String
    Private _certPass As String


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
    Public Property AppKey() As String
        Get
            Return _appKey
        End Get
        Set(ByVal value As String)
            _appKey = value
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

    Public Property ClientID() As String
        Get
            Return _ClientID
        End Get
        Set(ByVal value As String)
            _ClientID = value
        End Set
    End Property
    Public Property ClientSecret() As String
        Get
            Return _ClientSecret
        End Get
        Set(ByVal value As String)
            _ClientSecret = value
        End Set
    End Property

    Public Property CertPath() As String
        Get
            Return _certPath
        End Get
        Set(ByVal value As String)
            _certPath = value
        End Set
    End Property

    Public Property CertPass() As String
        Get
            Return _certPass
        End Get
        Set(ByVal value As String)
            _certPass = value
        End Set
    End Property

End Class
