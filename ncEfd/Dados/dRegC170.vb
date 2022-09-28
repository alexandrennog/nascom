Namespace nsEfd

    Public Class ColecaoC170
        Inherits List(Of dRegC170)
    End Class

    Public Class dRegC170

        Private _reg As String

        Private _num_item As String
        Private _num_doc As String
        Private _cod_item As String
        Private _descr_compl As String
        Private _qtd As Nullable(Of Decimal)
        Private _unid As String
        Private _vl_item As Nullable(Of Decimal)
        Private _vl_desc As Nullable(Of Decimal)
        Private _ind_mov As String

        Private _cst_icms As String
        Private _cfop As String
        Private _cod_nat As String
        Private _vl_bc_icms As Nullable(Of Decimal)
        Private _aliq_icms As Nullable(Of Decimal)
        Private _vl_icms As Nullable(Of Decimal)

        Private _vl_bc_icms_st As Nullable(Of Decimal)
        Private _aliq_st As Nullable(Of Decimal)
        Private _vl_icms_st As Nullable(Of Decimal)

        Private _ind_apur As String

        Private _cst_ipi As String
        Private _cod_enq As String
        Private _vl_bc_ipi As Nullable(Of Decimal)
        Private _aliq_ipi As Nullable(Of Decimal)
        Private _vl_ipi As Nullable(Of Decimal)

        Private _cst_pis As String
        Private _vl_bc_pis As Nullable(Of Decimal)
        Private _aliq_pis As Nullable(Of Decimal)
        Private _quant_bc_pis As Nullable(Of Decimal)
        Private _aliq_pis_r As Nullable(Of Decimal)
        Private _vl_pis As Nullable(Of Decimal)

        Private _cst_cofins As String
        Private _vl_bc_cofins As Nullable(Of Decimal)
        Private _aliq_cofins As Nullable(Of Decimal)
        Private _quant_bc_cofins As Nullable(Of Decimal)
        Private _aliq_cofins_r As Nullable(Of Decimal)
        Private _vl_cofins As Nullable(Of Decimal)

        Private _cod_cta As String

        Public Property reg() As String
            Get
                Return _reg
            End Get
            Set(ByVal value As String)
                _reg = value
            End Set
        End Property

        Public Property num_item() As String
            Get
                Return _num_item
            End Get
            Set(ByVal value As String)
                _num_item = value
            End Set
        End Property
        Public Property num_doc() As String
            Get
                Return _num_doc
            End Get
            Set(ByVal value As String)
                _num_doc = value
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

        Public Property descr_compl() As String
            Get
                Return _descr_compl
            End Get
            Set(ByVal value As String)
                _descr_compl = value
            End Set
        End Property

        Public Property qtd() As Nullable(Of Decimal)
            Get
                Return _qtd
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _qtd = value
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

        Public Property vl_item() As Nullable(Of Decimal)
            Get
                Return _vl_item
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_item = value
            End Set
        End Property

        Public Property vl_desc() As Nullable(Of Decimal)
            Get
                Return _vl_desc
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_desc = value
            End Set
        End Property

        Public Property ind_mov() As String
            Get
                Return _ind_mov
            End Get
            Set(ByVal value As String)
                _ind_mov = value
            End Set
        End Property

        Public Property cst_icms() As String
            Get
                Return _cst_icms
            End Get
            Set(ByVal value As String)
                _cst_icms = value
            End Set
        End Property

        Public Property cfop() As String
            Get
                Return _cfop
            End Get
            Set(ByVal value As String)
                _cfop = value
            End Set
        End Property

        Public Property cod_nat() As String
            Get
                Return _cod_nat
            End Get
            Set(ByVal value As String)
                _cod_nat = value
            End Set
        End Property

        Public Property aliq_icms() As Nullable(Of Decimal)
            Get
                Return _aliq_icms
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_icms = value
            End Set
        End Property

        Public Property vl_bc_icms() As Nullable(Of Decimal)
            Get
                Return _vl_bc_icms
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_bc_icms = value
            End Set
        End Property

        Public Property vl_icms() As Nullable(Of Decimal)
            Get
                Return _vl_icms
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_icms = value
            End Set
        End Property

        Public Property vl_bc_icms_st() As Nullable(Of Decimal)
            Get
                Return _vl_bc_icms_st
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_bc_icms_st = value
            End Set
        End Property

        Public Property aliq_st() As Nullable(Of Decimal)
            Get
                Return _aliq_st
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_st = value
            End Set
        End Property

        Public Property vl_icms_st() As Nullable(Of Decimal)
            Get
                Return _vl_icms_st
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_icms_st = value
            End Set
        End Property

        Public Property ind_apur() As String
            Get
                Return _ind_apur
            End Get
            Set(ByVal value As String)
                _ind_apur = value
            End Set
        End Property

        Public Property cst_ipi() As String
            Get
                Return _cst_ipi
            End Get
            Set(ByVal value As String)
                _cst_ipi = value
            End Set
        End Property

        Public Property cod_enq() As String
            Get
                Return _cod_enq
            End Get
            Set(ByVal value As String)
                _cod_enq = value
            End Set
        End Property

        Public Property vl_bc_ipi() As Nullable(Of Decimal)
            Get
                Return _vl_bc_ipi
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_bc_ipi = value
            End Set
        End Property

        Public Property aliq_ipi() As Nullable(Of Decimal)
            Get
                Return _aliq_ipi
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_ipi = value
            End Set
        End Property

        Public Property vl_ipi() As Nullable(Of Decimal)
            Get
                Return _vl_ipi
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_ipi = value
            End Set
        End Property

        Public Property cst_pis() As String
            Get
                Return _cst_pis
            End Get
            Set(ByVal value As String)
                _cst_pis = value
            End Set
        End Property

        Public Property vl_bc_pis() As Nullable(Of Decimal)
            Get
                Return _vl_bc_pis
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_bc_pis = value
            End Set
        End Property

        Public Property aliq_pis() As Nullable(Of Decimal)
            Get
                Return _aliq_pis
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_pis = value
            End Set
        End Property

        Public Property quant_bc_pis() As Nullable(Of Decimal)
            Get
                Return _quant_bc_pis
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _quant_bc_pis = value
            End Set
        End Property

        Public Property aliq_pis_r() As Nullable(Of Decimal)
            Get
                Return _aliq_pis_r
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_pis_r = value
            End Set
        End Property

        Public Property vl_pis() As Nullable(Of Decimal)
            Get
                Return _vl_pis
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_pis = value
            End Set
        End Property

        Public Property cst_cofins() As String
            Get
                Return _cst_cofins
            End Get
            Set(ByVal value As String)
                _cst_cofins = value
            End Set
        End Property

        Public Property vl_bc_cofins() As Nullable(Of Decimal)
            Get
                Return _vl_bc_cofins
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_bc_cofins = value
            End Set
        End Property

        Public Property aliq_cofins() As Nullable(Of Decimal)
            Get
                Return _aliq_cofins
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_cofins = value
            End Set
        End Property

        Public Property quant_bc_cofins() As Nullable(Of Decimal)
            Get
                Return _quant_bc_cofins
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _quant_bc_cofins = value
            End Set
        End Property

        Public Property aliq_cofins_r() As Nullable(Of Decimal)
            Get
                Return _aliq_cofins_r
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _aliq_cofins_r = value
            End Set
        End Property

        Public Property vl_cofins() As Nullable(Of Decimal)
            Get
                Return _vl_cofins
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _vl_cofins = value
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

    End Class

End Namespace