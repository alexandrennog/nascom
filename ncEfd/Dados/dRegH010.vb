Namespace nsEfd

    Public Class ColecaoH010
        Inherits List(Of dRegH010)
    End Class

    Public Class dRegH010

        Private _reg As String
        Private _cod_item As String
        Private _unid As String
        Private _qtd As Nullable(Of Integer)
        Private _vl_unit As Nullable(Of Decimal)
        Private _vl_item As Nullable(Of Decimal)
        Private _ind_prop As String
        Private _cod_part As String
        Private _txt_compl As String
        Private _cod_cta As String
        Private _vl_item_ir As Nullable(Of Decimal)

        Public Property reg() As String
            Get
                Return _reg
            End Get
            Set(ByVal value As String)
                _reg = value
            End Set
        End Property

        Public Property cod_item() As String
            Get
                Return _cod_item
            End Get
            Set(ByVal value As String)
                _cod_item = value
            End Set
        End Property

        Public Property unid() As String
            Get
                Return _unid
            End Get
            Set(ByVal value As String)
                _unid = value
            End Set
        End Property

        Public Property qtd() As Nullable(Of Integer)
            Get
                Return _qtd
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _qtd = value
            End Set
        End Property

        Public Property vl_unit() As Nullable(Of Decimal)
            Get
                Return _vl_unit
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_unit = value
            End Set
        End Property

        Public Property vl_item() As Nullable(Of Decimal)
            Get
                Return _vl_item
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_item = value
            End Set
        End Property

        Public Property ind_prop() As String
            Get
                Return _ind_prop
            End Get
            Set(ByVal value As String)
                _ind_prop = value
            End Set
        End Property

        Public Property cod_part() As String
            Get
                Return _cod_part
            End Get
            Set(ByVal value As String)
                _cod_part = value
            End Set
        End Property

        Public Property txt_compl() As String
            Get
                Return _txt_compl
            End Get
            Set(ByVal value As String)
                _txt_compl = value
            End Set
        End Property

        Public Property cod_cta() As String
            Get
                Return _cod_cta
            End Get
            Set(ByVal value As String)
                _cod_cta = value
            End Set
        End Property

        Public Property vl_item_ir() As Nullable(Of Decimal)
            Get
                Return _vl_item_ir
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_item_ir = value
            End Set
        End Property

    End Class

End Namespace