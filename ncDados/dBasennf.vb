Namespace nsVenda

    Public Class ColecaoBasennf
        Inherits List(Of dBasennf)
    End Class

    Public Class dBasennf
        Private _seqNFe As Integer
        Private _chnfe As String

        Public Property SeqNFe() As Integer
            Get
                Return _seqNFe
            End Get
            Set(ByVal value As Integer)
                _seqNFe = value
            End Set
        End Property
        Public Property chnfe() As String
            Get
                Return _chnfe
            End Get
            Set(ByVal value As String)
                _chnfe = value
            End Set
        End Property

    End Class
End Namespace
