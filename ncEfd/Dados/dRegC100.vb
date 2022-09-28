Namespace nsEfd

  Public Class ColecaoC100
    Inherits List(Of dRegC100)
  End Class

  Public Class dRegC100

    Private _reg As String
    Private _ind_oper As String
    Private _ind_emit As String
    Private _cod_part As String
    Private _cod_mod As String
    Private _cod_sit As String
    Private _ser As String
    Private _num_doc As String
    Private _chv_nfe As String
    Private _dt_doc As Nullable(Of DateTime)
    Private _dt_e_s As Nullable(Of DateTime)
    Private _vl_doc As Nullable(Of Decimal)
    Private _ind_pagto As String
    Private _vl_desc As Nullable(Of Decimal)
    Private _vl_abat_nt As Nullable(Of Decimal)
    Private _vl_merc As Nullable(Of Decimal)
    Private _ind_frt As String
    Private _vl_frt As Nullable(Of Decimal)
    Private _vl_seg As Nullable(Of Decimal)
    Private _vl_out_da As Nullable(Of Decimal)
    Private _vl_bc_icms As Nullable(Of Decimal)
    Private _vl_icms As Nullable(Of Decimal)
    Private _vl_bc_icms_st As Nullable(Of Decimal)
    Private _vl_icms_st As Nullable(Of Decimal)
    Private _vl_ipi As Nullable(Of Decimal)
    Private _vl_pis As Nullable(Of Decimal)
    Private _vl_cofins As Nullable(Of Decimal)
    Private _vl_pis_st As Nullable(Of Decimal)
    Private _vl_cofins_st As Nullable(Of Decimal)

    Private _tipoEmissao As Nullable(Of Integer)
    Private _tipoFluxo As Nullable(Of Integer)
    Private _tipoFrete As Nullable(Of Integer)
    Private _tipoNF As Nullable(Of Integer)
    Private _tipoPagto As Nullable(Of Integer)
    Private _situacaoNF As Nullable(Of Integer)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property ind_oper() As String
      Get
        Return _ind_oper
      End Get
      Set(ByVal value As String)
        _ind_oper = value
      End Set
    End Property

    Public Property ind_emit() As String
      Get
        Return _ind_emit
      End Get
      Set(ByVal value As String)
        _ind_emit = value
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

    Public Property cod_mod() As String
      Get
        Return _cod_mod
      End Get
      Set(ByVal value As String)
        _cod_mod = value
      End Set
    End Property

    Public Property cod_sit() As String
      Get
        Return _cod_sit
      End Get
      Set(ByVal value As String)
        _cod_sit = value
      End Set
    End Property

    Public Property ser() As String
      Get
        Return _ser
      End Get
      Set(ByVal value As String)
        _ser = value
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

    Public Property chv_nfe() As String
      Get
        Return _chv_nfe
      End Get
      Set(ByVal value As String)
        _chv_nfe = value
      End Set
    End Property

    Public Property dt_doc() As Nullable(Of DateTime)
      Get
        Return _dt_doc
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_doc = value
      End Set
    End Property

    Public Property dt_e_s() As Nullable(Of DateTime)
      Get
        Return _dt_e_s
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_e_s = value
      End Set
    End Property

    Public Property vl_doc() As Nullable(Of Decimal)
      Get
        Return _vl_doc
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_doc = value
      End Set
    End Property

    Public Property ind_pagto() As String
      Get
        Return _ind_pagto
      End Get
      Set(ByVal value As String)
        _ind_pagto = value
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

    Public Property vl_abat_nt() As Nullable(Of Decimal)
      Get
        Return _vl_abat_nt
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_abat_nt = value
      End Set
    End Property

    Public Property vl_merc() As Nullable(Of Decimal)
      Get
        Return _vl_merc
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_merc = value
      End Set
    End Property

    Public Property ind_frt() As String
      Get
        Return _ind_frt
      End Get
      Set(ByVal value As String)
        _ind_frt = value
      End Set
    End Property

    Public Property vl_frt() As Nullable(Of Decimal)
      Get
        Return _vl_frt
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_frt = value
      End Set
    End Property

    Public Property vl_seg() As Nullable(Of Decimal)
      Get
        Return _vl_seg
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_seg = value
      End Set
    End Property

    Public Property vl_out_da() As Nullable(Of Decimal)
      Get
        Return _vl_out_da
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_out_da = value
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

    Public Property vl_icms_st() As Nullable(Of Decimal)
      Get
        Return _vl_icms_st
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_icms_st = value
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

    Public Property vl_pis() As Nullable(Of Decimal)
      Get
        Return _vl_pis
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_pis = value
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

    Public Property vl_pis_st() As Nullable(Of Decimal)
      Get
        Return _vl_pis_st
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_pis_st = value
      End Set
    End Property

    Public Property vl_cofins_st() As Nullable(Of Decimal)
      Get
        Return _vl_cofins_st
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_cofins_st = value
      End Set
    End Property

    Public Property tipoEmissao() As Nullable(Of Integer)
      Get
        Return _tipoEmissao
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _tipoEmissao = value
      End Set
    End Property

    Public Property tipoFluxo() As Nullable(Of Integer)
      Get
        Return _tipoFluxo
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _tipoFluxo = value
      End Set
    End Property

    Public Property tipoFrete() As Nullable(Of Integer)
      Get
        Return _tipoFrete
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _tipoFrete = value
      End Set
    End Property

    Public Property tipoNF() As Nullable(Of Integer)
      Get
        Return _tipoNF
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _tipoNF = value
      End Set
    End Property

    Public Property tipoPagto() As Nullable(Of Integer)
      Get
        Return _tipoPagto
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _tipoPagto = value
      End Set
    End Property

    Public Property situacaoNF() As Nullable(Of Integer)
      Get
        Return _situacaoNF
      End Get
      Set(ByVal value As Nullable(Of Integer))
        _situacaoNF = value
      End Set
    End Property

  End Class

End Namespace