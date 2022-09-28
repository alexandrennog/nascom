Namespace nsEfd

    Public Class ColecaoH005
        Inherits List(Of dRegH005)
    End Class

    Public Class dRegH005

        Private _reg As String
        Private _dt_inv As Nullable(Of DateTime)
        Private _vl_inv As Nullable(Of Decimal)
        Private _mot_inv As String

        Public Property reg() As String
            Get
                Return _reg
            End Get
            Set(ByVal value As String)
                _reg = value
            End Set
        End Property

        Public Property dt_inv() As Nullable(Of DateTime)
            Get
                Return _dt_inv
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                _dt_inv = value
            End Set
        End Property

        Public Property vl_inv() As Nullable(Of Decimal)
            Get
                Return _vl_inv
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_inv = value
            End Set
        End Property


        Public Property mot_inv() As String
            Get
                Return _mot_inv
            End Get
            Set(ByVal value As String)
                _mot_inv = value
            End Set
        End Property

    End Class

End Namespace