Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fClienteProfissionalForm

  Public cliente_cid As Nullable(Of Integer)
  Public cliente_nome As String

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    CarregarCadastro()
  End Sub

  Private Sub btoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEndereco.Click
    CarregarEndereco()
  End Sub

  Private Sub btoFinanceiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFinanceiro.Click
    CarregarFinanceiro()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub fClienteProfissionalForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
          mdiPrincipal.FecharTela()
        End If
      Case Keys.F5
        Filtrar()
      Case Keys.F6
        CarregarCadastro()
      Case Keys.F7
        CarregarEndereco()
      Case Keys.F8
        CarregarFinanceiro()
      Case Keys.F9
        CarregarCrediario()
      Case Keys.Enter
        Salvar()
    End Select
  End Sub

  Private Sub CarregarCadastro()
    fClienteForm.cid = Me.cliente_cid
    mdiPrincipal.CarregarClienteForm()
  End Sub

  Private Sub CarregarFinanceiro()
    fClienteFinanceiroForm.cliente_cid = Me.cliente_cid
    fClienteFinanceiroForm.cliente_nome = Me.txtNome.Text
    mdiPrincipal.CarregarClienteFinanceiroForm()
  End Sub

  Private Sub CarregarEndereco()
    fClienteEnderecoForm.cliente_cid = Me.cliente_cid
    fClienteEnderecoForm.cliente_nome = Me.txtNome.Text
    mdiPrincipal.CarregarClienteEnderecoForm()
  End Sub

  Private Sub CarregarCrediario()
    fClienteCrediarioForm.cliente_cid = Me.cliente_cid
    fClienteCrediarioForm.cliente_nome = Me.txtNome.Text
    mdiPrincipal.CarregarClienteCrediarioForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarClienteFiltro()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub Salvar()
    Dim dados As dClienteProfissional
    Dim dadosConsulta As dClienteProfissional
    Dim colecao As ColecaoClienteProfissional
    Dim regras As rClienteProfissional
    Dim valido As Boolean = False
    Dim existe As Boolean = False

    Try

      If Not Me.cliente_cid.Equals(Nothing) Then
        If Not Me.cliente_cid.ToString().Equals(String.Empty) Then
          If Not Me.cliente_cid.Equals(0) Then
            valido = True
          End If
        End If
      End If

      If valido = True Then
        If MessageBox.Show("Confirma gravação das informações?", "Profissional", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
          dados = New dClienteProfissional
          dadosConsulta = New dClienteProfissional
          regras = New rClienteProfissional

          dados.empresa = cFuncoes.TratarTexto(txtEmpresa.Text)
          dados.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
          dados.numero = cFuncoes.TratarInteiro(txtNumero.Text)
          dados.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
          dados.bairro = cFuncoes.TratarTexto(txtBairro.Text)
          dados.cidade = cFuncoes.TratarTexto(txtCidade.Text)
          dados.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
          dados.cep = cFuncoes.TratarInteiro(txtCEP.Text)
          dados.ddd = cFuncoes.TratarTexto(txtDDD.Text)
          dados.telefone = cFuncoes.TratarTexto(txtTelefone.Text)
          dados.ramal = cFuncoes.TratarTexto(txtRamal.Text)
          dados.dataAdmissao = cFuncoes.TratarTexto(txtDataAdmissao.Text)
          dados.cargo = cFuncoes.TratarTexto(txtCargo.Text)
          dados.salario = cFuncoes.TratarTexto(txtSalario.Text)
          dados.cliente_cid = Me.cliente_cid

          dadosConsulta.cliente_cid = Me.cliente_cid

          colecao = regras.Consultar(dadosConsulta)

          If Not colecao Is Nothing Then
            If colecao.Count > 0 Then
              existe = True
            End If
          End If

          If existe = True Then
            regras.Alterar(dados)
          Else
            regras.Incluir(dados)
          End If

          ExibirInformacoes()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na gravação dos dados de Cliente.")

    End Try
  End Sub

  Private Sub fClienteProfissionalForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LimparCampos()
    CarregarComboEstado()
    ExibirInformacoes()
  End Sub

  Private Sub LimparCampos()
    txtEmpresa.Text = String.Empty
    txtLogradouro.Text = String.Empty
    txtNumero.Text = String.Empty
    txtComplemento.Text = String.Empty
    txtBairro.Text = String.Empty
    txtCidade.Text = String.Empty
    txtCEP.Text = String.Empty
    txtDDD.Text = String.Empty
    txtTelefone.Text = String.Empty
    txtRamal.Text = String.Empty
    txtDataAdmissao.Text = String.Empty
    txtCargo.Text = String.Empty
    txtSalario.Text = String.Empty
    If cboEstado.Items.Count > 0 Then
      cboEstado.SelectedIndex = 0
    End If
  End Sub

  Private Sub ExibirInformacoes()
    Dim regras As rClienteProfissional
    Dim dados As dClienteProfissional
    Dim colecao As ColecaoClienteProfissional

    Try

      If Not Me.cliente_cid.Equals(Nothing) Then
        If Not Me.cliente_cid.Equals(0) Then

          txtNome.Text = Me.cliente_nome

          regras = New rClienteProfissional()
          dados = New dClienteProfissional()

          dados.cliente_cid = Me.cliente_cid
          colecao = regras.Consultar(dados)

          If Not colecao Is Nothing Then
            If colecao.Count > 0 Then
              dados = colecao(0)

              txtEmpresa.Text = cFuncoes.RetornarTexto(dados.empresa)
              txtLogradouro.Text = cFuncoes.RetornarTexto(dados.logradouro)
              txtNumero.Text = cFuncoes.RetornarTexto(dados.numero)
              txtComplemento.Text = cFuncoes.RetornarTexto(dados.complemento)
              txtBairro.Text = cFuncoes.RetornarTexto(dados.bairro)
              txtCidade.Text = cFuncoes.RetornarTexto(dados.cidade)
              If cFuncoes.ValidarValor(dados.cep) Then
                txtCEP.Text = cFuncoes.RetornarTexto(dados.cep).PadLeft(8, "0")
              End If
              txtDDD.Text = cFuncoes.RetornarTexto(dados.ddd)
              txtTelefone.Text = cFuncoes.RetornarTexto(dados.telefone)
              txtRamal.Text = cFuncoes.RetornarTexto(dados.ramal)
              txtDataAdmissao.Text = cFuncoes.RetornarTexto(dados.dataAdmissao)
              txtCargo.Text = cFuncoes.RetornarTexto(dados.cargo)
              txtSalario.Text = cFuncoes.RetornarTexto(dados.salario)
              If cboEstado.Items.Count > 0 Then
                cboEstado.SelectedIndex = 0
              End If
              If cFuncoes.ValidarValor(dados.estado_cid) Then
                cboEstado.SelectedValue = cFuncoes.RetornarTexto(dados.estado_cid)
              End If
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Cliente.")

    End Try
  End Sub

  Private Sub CarregarComboEstado()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboEstado.Items.Clear()
      
      regras = New rEstado()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dEstado())

        cboEstado.ValueMember = "cid"
        cboEstado.DisplayMember = "sigla"
        cboEstado.DataSource = colecao
        cboEstado.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

 
  Private Sub btoCrediario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCrediario.Click
    CarregarCrediario()
  End Sub

End Class