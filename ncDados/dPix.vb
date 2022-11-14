Public Class dPix

    Private _txId As String
    Private _cliente As Integer
    Private _cpf As String
    Private _cnpj As String
    Private _nome As String
    Private _pagador As String
    Private _original As Decimal

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

End Class
