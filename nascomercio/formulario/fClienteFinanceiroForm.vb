Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncDados.nsCrediario

Public Class fClienteFinanceiroForm

  Public cliente_cid As Nullable(Of Integer)
  Public cliente_nome As String

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    CarregarCadastro()
  End Sub

  Private Sub btoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEndereco.Click
    CarregarEndereco()
  End Sub

  Private Sub btoProfissional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProfissional.Click
    CarregarProfissional()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        CarregarProfissional()
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

  Private Sub CarregarProfissional()
    fClienteProfissionalForm.cliente_cid = Me.cliente_cid
    fClienteProfissionalForm.cliente_nome = Me.txtNome.Text
    mdiPrincipal.CarregarClienteProfissionalForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarClienteFiltro()
  End Sub

  Private Sub Salvar()
    Dim dados As dClienteFinanceiro
    Dim dadosConsulta As dClienteFinanceiro
    Dim colecao As ColecaoClienteFinanceiro
    Dim regras As rClienteFinanceiro
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
        If MessageBox.Show("Confirma gravação das informações?", "Financeiro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
          dados = New dClienteFinanceiro
          dadosConsulta = New dClienteFinanceiro
          regras = New rClienteFinanceiro

          dados.limite = cFuncoes.TratarDecimal(txtLimite.Text)
          dados.situacaoCrediario = cFuncoes.TratarTexto(cboCrediario.SelectedValue)
          dados.cliente_cid = Me.cliente_cid
          dados.banco1 = Me.txtBanco1.Text
          dados.banco2 = Me.txtBanco2.Text
          dados.agencia1 = Me.txtAgencia1.Text
          dados.agencia2 = Me.txtAgencia2.Text
          dados.conta1 = Me.txtConta1.Text
          dados.conta2 = Me.txtConta2.Text
          dados.gerente1 = Me.txtGerente1.Text
          dados.gerente2 = Me.txtGerente2.Text
          dados.referencia1 = Me.txtReferencia1.Text
          dados.referencia2 = Me.txtReferencia2.Text
          dados.ddd1 = Me.txtDDD.Text
          dados.ddd2 = Me.txtDDD2.Text
          dados.telefone1 = Me.txtTelefone.Text
          dados.telefone2 = Me.txtTelefone2.Text
          dados.observacoes = Me.txtObservacao.Text

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

  Private Sub LimparCampos()
    txtLimite.Text = String.Empty
    If cboCrediario.Items.Count > 0 Then
      cboCrediario.SelectedIndex = 0
    End If
  End Sub

  Private Sub ExibirInformacoes()
    Dim regras As rClienteFinanceiro
    Dim dados As dClienteFinanceiro
    Dim colecao As ColecaoClienteFinanceiro

    Try

      If Not Me.cliente_cid.Equals(Nothing) Then
        If Not Me.cliente_cid.Equals(0) Then

          txtNome.Text = Me.cliente_nome

          regras = New rClienteFinanceiro()
          dados = New dClienteFinanceiro()

          dados.cliente_cid = Me.cliente_cid
          colecao = regras.Consultar(dados)

          If Not colecao Is Nothing Then
            If colecao.Count > 0 Then
              dados = colecao(0)

              txtLimite.Text = cFuncoes.RetornarDecimal(dados.limite).Value.ToString("N")
              txtBanco1.Text = cFuncoes.RetornarTexto(dados.banco1)
              txtBanco2.Text = cFuncoes.RetornarTexto(dados.banco2)
              txtAgencia1.Text = cFuncoes.RetornarTexto(dados.agencia1)
              txtAgencia2.Text = cFuncoes.RetornarTexto(dados.agencia2)
              txtConta1.Text = cFuncoes.RetornarTexto(dados.conta1)
              txtConta2.Text = cFuncoes.RetornarTexto(dados.conta2)
              txtGerente1.Text = cFuncoes.RetornarTexto(dados.gerente1)
              txtGerente2.Text = cFuncoes.RetornarTexto(dados.gerente2)
              txtReferencia1.Text = cFuncoes.RetornarTexto(dados.referencia1)
              txtReferencia2.Text = cFuncoes.RetornarTexto(dados.referencia2)
              txtDDD.Text = cFuncoes.RetornarTexto(dados.ddd1)
              txtDDD2.Text = cFuncoes.RetornarTexto(dados.ddd2)
              txtTelefone.Text = cFuncoes.RetornarTexto(dados.telefone1)
              txtTelefone2.Text = cFuncoes.RetornarTexto(dados.telefone2)
              txtObservacao.Text = cFuncoes.RetornarTexto(dados.observacoes)

              If cboCrediario.Items.Count > 0 Then
                cboCrediario.SelectedIndex = 0
              End If
              If cFuncoes.ValidarValor(dados.situacaoCrediario) Then
                cboCrediario.SelectedValue = cFuncoes.RetornarTexto(dados.situacaoCrediario)
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

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LimparCampos()
    CarregarComboSituacao()
    ExibirInformacoes()
  End Sub

  Private Sub CarregarComboSituacao()
    Dim regras As rSituacao
    Dim colecao As ColecaoSituacao

    Try

      cboCrediario.Items.Clear()

      regras = New rSituacao()
      colecao = regras.ListarFinan()

      If Not colecao Is Nothing Then


        cboCrediario.ValueMember = "codigo"
        cboCrediario.DisplayMember = "descricao"
        cboCrediario.DataSource = colecao
        cboCrediario.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Situação.")

    End Try
  End Sub

  Private Sub btoCrediario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCrediario.Click
    CarregarCrediario()
  End Sub

  Private Sub txtLimite_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLimite.Leave
    If txtLimite.Text.Trim() <> "" Then
      txtLimite.Text = CDec(txtLimite.Text).ToString("N")
    End If
  End Sub

  Private Sub btoCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCheques.Click
    mdiPrincipal.CarregarCheques(txtNome.Text)
  End Sub

  Private Sub btoVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVendas.Click
    mdiPrincipal.CarregarVendas(txtNome.Text)
  End Sub
End Class