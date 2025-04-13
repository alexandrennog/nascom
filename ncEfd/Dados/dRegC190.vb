Namespace nsEfd

  Public Class ColecaoC190
    Inherits List(Of dRegC190)
  End Class

  Public Class dRegC190

    Private _reg As String
    Private _cst_icms As String
    Private _cfop As String
    Private _aliq_icms As Nullable(Of Decimal)
    Private _vl_opr As Nullable(Of Decimal)
    Private _vl_bc_icms As Nullable(Of Decimal)
    Private _vl_icms As Nullable(Of Decimal)
    Private _vl_bc_icms_st As Nullable(Of Decimal)
    Private _vl_icms_st As Nullable(Of Decimal)
    Private _vl_red_bc As Nullable(Of Decimal)
    Private _vl_ipi As Nullable(Of Decimal)
    Private _cod_obs As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
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

    Public Property aliq_icms() As Nullable(Of Decimal)
      Get
        Return _aliq_icms
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _aliq_icms = value
      End Set
    End Property

    Public Property vl_opr() As Nullable(Of Decimal)
      Get
        Return _vl_opr
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_opr = value
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

    Public Property vl_red_bc() As Nullable(Of Decimal)
      Get
        Return _vl_red_bc
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_red_bc = value
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

    Public Property cod_obs() As String
      Get
        Return _cod_obs
      End Get
      Set(ByVal value As String)
        _cod_obs = value
      End Set
    End Property

  End Class

End Namespace