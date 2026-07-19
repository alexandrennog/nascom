Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEmpresa
Imports ncRegras.nsEmpresa
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsMunicipios
Imports ncRegras.nsMunicipios
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fEmpresaForm

  Public cid As Nullable(Of Integer)

  Private colecaoEstados As ColecaoEstado

  Private Function Validar() As Boolean
    Try

      If String.IsNullOrEmpty(txtRazaoSocial.Text.Trim()) Then
        MessageBox.Show("É necessário informar a Razão Social!")
        Return False
      End If

      If String.IsNullOrEmpty(txtCnpj.Text.Trim()) Then
        MessageBox.Show("É necessário informar o CNPJ!")
        Return False
      End If

      If Not cFuncoes.ValidarValor(cboCrt.SelectedValue) Then
        MessageBox.Show("É necessário informar o CRT!")
        Return False
      End If

    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub Salvar()
    Dim dados As dEmpresa
    Dim filtro As dEmpresa
    Dim regras As rEmpresa
    Dim tipoMsg As String = String.Empty
    Dim tipoAcao As String = String.Empty
    Dim novoCID As Integer

    Try

      If Not Validar() Then
        Exit Sub
      End If

      tipoMsg = "INCLUSÃO"
      tipoAcao = "i"

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            tipoMsg = "ALTERAÇÃO"
            tipoAcao = "a"
          End If
        End If
      End If

      If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
        dados = New dEmpresa
        regras = New rEmpresa

        dados.cid = Me.cid
        dados.razaoSocial = cFuncoes.TratarTexto(txtRazaoSocial.Text)
        dados.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
        dados.crt = CType(cFuncoes.TratarInteiro(cboCrt.SelectedValue), Nullable(Of Byte))
        dados.uf = cFuncoes.TratarTexto(cboUf.SelectedValue)
        dados.municipio = cFuncoes.TratarInteiro(cboMunicipio.SelectedValue)

        If tipoAcao.Equals("i") Then
          filtro = New dEmpresa
          filtro.cnpj = dados.cnpj

          If IsNothing(regras.Consultar(filtro)) Then
            novoCID = regras.Incluir(dados)

            Me.cid = novoCID
            ExibirInformacoesTela()
          Else
            MessageBox.Show("Já existe uma Empresa cadastrada com este CNPJ.")
          End If
        ElseIf tipoAcao.Equals("a") Then
          regras.Alterar(dados)

          ExibirInformacoesTela()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados da Empresa.")

    End Try
  End Sub

  Private Sub Excluir()
    Dim dados As dEmpresa
    Dim regras As rEmpresa

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dEmpresa
              regras = New rEmpresa

              dados.cid = cFuncoes.TratarInteiro(Me.cid)

              regras.Excluir(dados)

              Me.cid = Nothing
              LimparCampos()
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na exclusão dos dados da Empresa.")

    End Try
  End Sub

  Private Sub CarregarComboCrt()
    Dim regras As rCrt
    Dim colecao As ColecaoCrt

    Try

      cboCrt.DataSource = Nothing
      cboCrt.Items.Clear()

      regras = New rCrt()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then

        cboCrt.ValueMember = "codigo"
        cboCrt.DisplayMember = "descricao"
        cboCrt.DataSource = colecao
        cboCrt.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de CRT.")

    End Try
  End Sub

  Private Sub CarregarComboUf()
    Dim regras As rEstado

    Try

      cboUf.DataSource = Nothing
      cboUf.Items.Clear()

      regras = New rEstado()
      colecaoEstados = regras.Listar()

      If Not colecaoEstados Is Nothing Then
        colecaoEstados.Insert(0, New dEstado())

        cboUf.ValueMember = "sigla"
        cboUf.DisplayMember = "nome"
        cboUf.DataSource = colecaoEstados
        cboUf.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

  Private Sub CarregarComboMunicipio()
    Dim regras As rMunicipios
    Dim colecao As ColecaoMunicipios
    Dim estadoSelecionado As dEstado
    Dim sigla As String

    Try

      cboMunicipio.DataSource = Nothing
      cboMunicipio.Items.Clear()

      If cboUf.Items.Count > 0 Then
        If cboUf.SelectedValue IsNot Nothing Then
          sigla = cboUf.SelectedValue.ToString()

          If Not String.IsNullOrEmpty(sigla) Then
            If Not colecaoEstados Is Nothing Then
              For Each item As dEstado In colecaoEstados
                If Not item.sigla Is Nothing Then
                  If item.sigla.Equals(sigla) Then
                    estadoSelecionado = item
                    Exit For
                  End If
                End If
              Next
            End If

            If Not estadoSelecionado Is Nothing Then
              regras = New rMunicipios()
              colecao = regras.ListarPorEstados(Convert.ToInt32(estadoSelecionado.cid))

              If Not colecao Is Nothing Then
                colecao.Insert(0, New dMunicipios())

                cboMunicipio.ValueMember = "codigo_ibge"
                cboMunicipio.DisplayMember = "nome"
                cboMunicipio.DataSource = colecao
                cboMunicipio.Refresh()
              End If
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Municípios.")

    End Try
  End Sub

  Private Sub ExibirInformacoesTela()
    Dim regras As rEmpresa
    Dim dados As dEmpresa

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rEmpresa()

          dados = regras.Consultar(Me.cid)

          If Not dados Is Nothing Then
            txtRazaoSocial.Text = cFuncoes.RetornarTexto(dados.razaoSocial)
            txtCnpj.Text = cFuncoes.RetornarTexto(dados.cnpj)

            If cboCrt.Items.Count > 0 Then
              cboCrt.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.crt) Then
              cboCrt.SelectedValue = cFuncoes.RetornarInteiro(dados.crt)
            End If

            If cboUf.Items.Count > 0 Then
              cboUf.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.uf) Then
              cboUf.SelectedValue = cFuncoes.RetornarTexto(dados.uf)
            End If

            CarregarComboMunicipio()

            If cboMunicipio.Items.Count > 0 Then
              cboMunicipio.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.municipio) Then
              cboMunicipio.SelectedValue = cFuncoes.RetornarTexto(dados.municipio)
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados da Empresa.")

    End Try

  End Sub

  Private Sub LimparCampos()
    txtRazaoSocial.Text = String.Empty
    txtCnpj.Text = String.Empty
    If cboCrt.Items.Count > 0 Then
      cboCrt.SelectedIndex = 0
    End If
    If cboUf.Items.Count > 0 Then
      cboUf.SelectedIndex = 0
    End If
    If cboMunicipio.Items.Count > 0 Then
      cboMunicipio.SelectedIndex = 0
    End If
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarEmpresaFiltro()
  End Sub

  Private Sub cboUf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUf.SelectedIndexChanged
    CarregarComboMunicipio()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Sair()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fEmpresaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Me.Modal = True Then
      btoFiltro.Visible = False
      btoExcluir.Visible = False
    End If

    LimparCampos()
    CarregarComboCrt()
    CarregarComboUf()
    ExibirInformacoesTela()
  End Sub

  Private Sub fEmpresaForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Sair()
      Case Keys.F5
        Filtrar()
      Case Keys.Enter
        Salvar()
      Case Keys.F12
        Excluir()
    End Select
  End Sub

  Private Sub Sair()
    If Me.Modal = True Then
      Me.Close()
    Else
      If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        mdiPrincipal.FecharTela()
      End If
    End If
  End Sub

End Class
