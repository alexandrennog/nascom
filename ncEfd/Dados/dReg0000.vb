Namespace nsEfd

  Public Class Colecao0000
    Inherits List(Of dReg0000)
  End Class

  Public Class dReg0000

    Private _reg As String
    Private _cod_ver As String
    Private _cod_fin As String
    Private _dt_ini As DateTime
    Private _dt_fin As DateTime
    Private _nome As String
    Private _cnpj As String
    Private _cpf As String
    Private _uf As String
    Private _ie As String
    Private _cod_mun As String
    Private _im As String
    Private _suframa As String
    Private _ind_perfil As String
    Private _ind_ativ As String

    Private _cpfCnpj As String
    Private _tipoPessoa As String

    Public Property reg() As String
      Get
        Return _reg
      End Get
      Set(ByVal value As String)
        _reg = value
      End Set
    End Property

    Public Property cod_ver() As String
      Get
        Return _cod_ver
      End Get
      Set(ByVal value As String)
        _cod_ver = value
      End Set
    End Property

    Public Property cod_fin() As String
      Get
        Return _cod_fin
      End Get
      Set(ByVal value As String)
        _cod_fin = value
      End Set
    End Property

    Public Property dt_ini() As Nullable(Of DateTime)
      Get
        Return _dt_ini
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_ini = value
      End Set
    End Property

    Public Property dt_fin() As Nullable(Of DateTime)
      Get
        Return _dt_fin
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        _dt_fin = value
      End Set
    End Property

    Public Property nome() As String
      Get
        Return _nome
      End Get
      Set(ByVal value As String)
        _nome = value
      End Set
    End Property

    Public Property cnpj() As String
      Get
        Return _cnpj
      End Get
      Set(ByVal value As String)
        _cnpj = value
      End Set
    End Property

    Public Property cpf() As String
      Get
        Return _cpf
      End Get
      Set(ByVal value As String)
        _cpf = value
      End Set
    End Property

    Public Property uf() As String
      Get
        Return _uf
      End Get
      Set(ByVal value As String)
        _uf = value
      End Set
    End Property

    Public Property ie() As String
      Get
        Return _ie
      End Get
      Set(ByVal value As String)
        _ie = value
      End Set
    End Property

    Public Property cod_mun() As String
      Get
        Return _cod_mun
      End Get
      Set(ByVal value As String)
        _cod_mun = value
      End Set
    End Property

    Public Property im() As String
      Get
        Return _im
      End Get
      Set(ByVal value As String)
        _im = value
      End Set
    End Property

    Public Property suframa() As String
      Get
        Return _suframa
      End Get
      Set(ByVal value As String)
        _suframa = value
      End Set
    End Property

    Public Property ind_perfil() As String
      Get
        Return _ind_perfil
      End Get
      Set(ByVal value As String)
        _ind_perfil = value
      End Set
    End Property

    Public Property ind_ativ() As String
      Get
        Return _ind_ativ
      End Get
      Set(ByVal value As String)
        _ind_ativ = value
      End Set
    End Property

    Public Property tipoPessoa() As String
      Get
        Return _tipoPessoa
      End Get
      Set(ByVal value As String)
        _tipoPessoa = value
      End Set
    End Property

    Public Property cpfCnpj() As String
      Get
        Return _cpfCnpj
      End Get
      Set(ByVal value As String)
        _cpfCnpj = value
      End Set
    End Property

  End Class

End Namespace