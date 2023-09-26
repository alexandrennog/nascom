Public Class dPix

    Private _iD As String
    Private _txId As String
    Private _cliente As Integer
    Private _cpf As String
    Private _cnpj As String
    Private _nome As String
    Private _pagador As String
    Private _original As Decimal
    Private _observacao As String
    Private _status As String
    Private _dataHora As DateTime
    Private _controle As Integer
    Private _urlPix As String


    Public Property ID() As String
        Get
            Return _iD
        End Get
        Set(ByVal value As String)
            _iD = value
        End Set
    End Property

    Public Property TxId() As String
        Get
            Return _txId
        End Get
        Set(ByVal value As String)
            _txId = value
        End Set
    End Property

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

    Public Property Pagador() As String
        Get
            Return _pagador
        End Get
        Set(ByVal value As String)
            _pagador = value
        End Set
    End Property

    Public Property Original() As Decimal
        Get
            Return _original
        End Get
        Set(ByVal value As Decimal)
            _original = value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return _observacao
        End Get
        Set(ByVal value As String)
            _observacao = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
    Public Property DataHora() As String
        Get
            Return _dataHora
        End Get
        Set(ByVal value As String)
            _dataHora = value
        End Set
    End Property
    Public Property UrlPix() As String
        Get
            Return _urlPix
        End Get
        Set(ByVal value As String)
            _urlPix = value
        End Set
    End Property
    Public Property Controle() As Integer
        Get
            Return _controle
        End Get
        Set(ByVal value As Integer)
            _controle = value
        End Set
    End Property
End Class
