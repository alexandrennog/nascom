Namespace nsEfd

  Public Class Colecao0200
    Inherits List(Of dReg0200)
  End Class

  Public Class dReg0200

    Private _reg As String
    Private _cod_item As String
    Private _descr_item As String
    Private _cod_barra As String
    Private _cod_ant_item As String
    Private _unid_inv As String
    Private _tipo_item As String
    Private _cod_ncm As String
    Private _ex_ipi As String
    Private _cod_gen As String
    Private _cod_lst As String
    Private _aliq_icms As String

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

    Public Property descr_item() As String
      Get
        Return _descr_item
      End Get
      Set(ByVal value As String)
        _descr_item = value
      End Set
    End Property

    Public Property cod_barra() As String
      Get
        Return _cod_barra
      End Get
      Set(ByVal value As String)
        _cod_barra = value
      End Set
    End Property

    Public Property cod_ant_item() As String
      Get
        Return _cod_ant_item
      End Get
      Set(ByVal value As String)
        _cod_ant_item = value
      End Set
    End Property

    Public Property unid_inv() As String
      Get
        Return _unid_inv
      End Get
      Set(ByVal value As String)
        _unid_inv = value
      End Set
    End Property

    Public Property tipo_item() As String
      Get
        Return _tipo_item
      End Get
      Set(ByVal value As String)
        _tipo_item = value
      End Set
    End Property

    Public Property cod_ncm() As String
      Get
        Return _cod_ncm
      End Get
      Set(ByVal value As String)
        _cod_ncm = value
      End Set
    End Property

    Public Property ex_ipi() As String
      Get
        Return _ex_ipi
      End Get
      Set(ByVal value As String)
        _ex_ipi = value
      End Set
    End Property

    Public Property cod_gen() As String
      Get
        Return _cod_gen
      End Get
      Set(ByVal value As String)
        _cod_gen = value
      End Set
    End Property

    Public Property cod_lst() As String
      Get
        Return _cod_lst
      End Get
      Set(ByVal value As String)
        _cod_lst = value
      End Set
    End Property

    Public Property aliq_icms() As String
      Get
        Return _aliq_icms
      End Get
      Set(ByVal value As String)
        _aliq_icms = value
      End Set
    End Property

  End Class

End Namespace
