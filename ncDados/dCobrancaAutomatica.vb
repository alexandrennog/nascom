Namespace nsCobranca


    Public Class ColecaoCobranca
        Inherits List(Of dCobrancaAutomatica)
    End Class
    Public Class dCobrancaAutomatica


        Private _codigocliente As Integer
        Private _crediarioid As Integer
        Private _parcelaidid As Integer
        Private _valor As Decimal
        Private _nome As String
        Private _dddcel As String
        Private _celular As String
        Private _sucesso As String
        Private _pix_code As String
        Private _data_cobranca As DateTime
        Private _datavencimento As DateTime



        Public Property CodigoCliente As Integer
            Get
                Return _codigocliente
            End Get
            Set(ByVal value As Integer)
                _codigocliente = value
            End Set
        End Property

        Public Property CrediarioId As Integer
            Get
                Return _crediarioid
            End Get
            Set(ByVal value As Integer)
                _crediarioid = value
            End Set
        End Property

        Public Property ParcelaIdId As Integer
            Get
                Return _parcelaidid
            End Get
            Set(ByVal value As Integer)
                _parcelaidid = value
            End Set
        End Property

        Public Property Valor As Decimal
            Get
                Return _valor
            End Get
            Set(ByVal value As Decimal)
                _valor = value
            End Set
        End Property

        Public Property Nome As String
            Get
                Return _nome
            End Get
            Set(ByVal value As String)
                _nome = value
            End Set
        End Property

        Public Property DDDCel As String
            Get
                Return _dddcel
            End Get
            Set(ByVal value As String)
                _dddcel = value
            End Set
        End Property

        Public Property Celular As String
            Get
                Return _celular
            End Get
            Set(ByVal value As String)
                _celular = value
            End Set
        End Property

        Public Property Sucesso As String
            Get
                Return _sucesso
            End Get
            Set(ByVal value As String)
                _sucesso = value
            End Set
        End Property

        Public Property PixCode As String
            Get
                Return _pix_code
            End Get
            Set(ByVal value As String)
                _pix_code = value
            End Set
        End Property

        Public Property DataCobranca As DateTime
            Get
                Return _data_cobranca
            End Get
            Set(ByVal value As DateTime)
                _data_cobranca = value
            End Set
        End Property

        Public Property DataVencimento As DateTime
            Get
                Return _datavencimento
            End Get
            Set(ByVal value As DateTime)
                _datavencimento = value
            End Set
        End Property


    End Class

End Namespace
