Namespace nsRegraTributaria

    Public Class ColecaoRegraTributaria
        Inherits List(Of dRegraTributaria)
    End Class

    Public Class dRegraTributaria

        Private _cid As Nullable(Of Integer)
        Private _descricao As String
        Private _crt As Nullable(Of Byte)
        Private _ufOrigem As String
        Private _ufDestino As String
        Private _tipoOperacao As String
        Private _modeloDocumento As Nullable(Of Byte)
        Private _inicioVigencia As Nullable(Of DateTime)
        Private _fimVigencia As Nullable(Of DateTime)
        Private _ativo As Nullable(Of Boolean)

        Public Property cid() As Nullable(Of Integer)
            Get
                Return _cid
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _cid = value
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

        Public Property crt() As Nullable(Of Byte)
            Get
                Return _crt
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _crt = value
            End Set
        End Property

        Public Property ufOrigem() As String
            Get
                Return _ufOrigem
            End Get
            Set(ByVal value As String)
                _ufOrigem = value
            End Set
        End Property

        Public Property ufDestino() As String
            Get
                Return _ufDestino
            End Get
            Set(ByVal value As String)
                _ufDestino = value
            End Set
        End Property

        ' E = Entrada / S = Saída
        Public Property tipoOperacao() As String
            Get
                Return _tipoOperacao
            End Get
            Set(ByVal value As String)
                _tipoOperacao = value
            End Set
        End Property

        ' 55 NF-e / 65 NFC-e
        Public Property modeloDocumento() As Nullable(Of Byte)
            Get
                Return _modeloDocumento
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _modeloDocumento = value
            End Set
        End Property

        Public Property inicioVigencia() As Nullable(Of DateTime)
            Get
                Return _inicioVigencia
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _inicioVigencia = value
            End Set
        End Property

        Public Property fimVigencia() As Nullable(Of DateTime)
            Get
                Return _fimVigencia
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _fimVigencia = value
            End Set
        End Property

        Public Property ativo() As Nullable(Of Boolean)
            Get
                Return _ativo
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ativo = value
            End Set
        End Property

    End Class

End Namespace
