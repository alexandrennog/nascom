Namespace nsEfd

  Public Class ColecaoE110
    Inherits List(Of dRegE110)
  End Class

  Public Class dRegE110

    Private _reg As String
    Private _vl_tot_debitos As Nullable(Of Decimal)
    Private _vl_aj_debitos As Nullable(Of Decimal)
    Private _vl_tot_aj_debitos As Nullable(Of Decimal)
    Private _vl_estornos_cred As Nullable(Of Decimal)
    Private _vl_tot_creditos As Nullable(Of Decimal)
    Private _vl_aj_creditos As Nullable(Of Decimal)
    Private _vl_tot_aj_creditos As Nullable(Of Decimal)
    Private _vl_estornos_deb As Nullable(Of Decimal)
    Private _vl_sld_credor_ant As Nullable(Of Decimal)
    Private _vl_sld_apurado As Nullable(Of Decimal)
    Private _vl_tot_ded As Nullable(Of Decimal)
    Private _vl_icms_recolher As Nullable(Of Decimal)
    Private _vl_sld_credor_transportar As Nullable(Of Decimal)
    Private _deb_esp As Nullable(Of Decimal)

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property vl_tot_debitos() As Nullable(Of Decimal)
      Get
        Return _vl_tot_debitos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_tot_debitos = value
      End Set
    End Property

    Public Property vl_aj_debitos() As Nullable(Of Decimal)
      Get
        Return _vl_aj_debitos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_aj_debitos = value
      End Set
    End Property

    Public Property vl_tot_aj_debitos() As Nullable(Of Decimal)
      Get
        Return _vl_tot_aj_debitos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_tot_aj_debitos = value
      End Set
    End Property

    Public Property vl_estornos_cred() As Nullable(Of Decimal)
      Get
        Return _vl_estornos_cred
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_estornos_cred = value
      End Set
    End Property

    Public Property vl_tot_creditos() As Nullable(Of Decimal)
      Get
        Return _vl_tot_creditos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_tot_creditos = value
      End Set
    End Property

    Public Property vl_aj_creditos() As Nullable(Of Decimal)
      Get
        Return _vl_aj_creditos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_aj_creditos = value
      End Set
    End Property

    Public Property vl_tot_aj_creditos() As Nullable(Of Decimal)
      Get
        Return _vl_tot_aj_creditos
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_tot_aj_creditos = value
      End Set
    End Property

    Public Property vl_estornos_deb() As Nullable(Of Decimal)
      Get
        Return _vl_estornos_deb
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_estornos_deb = value
      End Set
    End Property

    Public Property vl_sld_credor_ant() As Nullable(Of Decimal)
      Get
        Return _vl_sld_credor_ant
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_sld_credor_ant = value
      End Set
    End Property

    Public Property vl_sld_apurado() As Nullable(Of Decimal)
      Get
        Return _vl_sld_apurado
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_sld_apurado = value
      End Set
    End Property

    Public Property vl_tot_ded() As Nullable(Of Decimal)
      Get
        Return _vl_tot_ded
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_tot_ded = value
      End Set
    End Property

    Public Property vl_icms_recolher() As Nullable(Of Decimal)
      Get
        Return _vl_icms_recolher
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_icms_recolher = value
      End Set
    End Property

    Public Property vl_sld_credor_transportar() As Nullable(Of Decimal)
      Get
        Return _vl_sld_credor_transportar
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _vl_sld_credor_transportar = value
      End Set
    End Property

    Public Property deb_esp() As Nullable(Of Decimal)
      Get
        Return _deb_esp
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        _deb_esp = value
      End Set
    End Property

  End Class

End Namespace