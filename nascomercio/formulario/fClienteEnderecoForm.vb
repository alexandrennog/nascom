Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsConstantes

Public Class fClienteEnderecoForm

  Public cliente_cid As Nullable(Of Integer)
  Public cliente_nome As String

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    CarregarCadastro()
  End Sub

  Private Sub btoProfissional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProfissional.Click
    CarregarProfissional()
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

  Private Sub fClienteEnderecoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        CarregarProfissional()
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
    Dim dados As dClienteEndereco
    Dim dadosAnterior As dClienteEndereco
    Dim regras As rClienteEndereco
    Dim tipoMsg As String = String.Empty
    Dim tipoAcao As String = String.Empty
    Dim valido As Boolean = False

    Try

      If Not Me.cliente_cid.Equals(Nothing) Then
        If Not Me.cliente_cid.ToString().Equals(String.Empty) Then
          If Not Me.cliente_cid.Equals(0) Then
            valido = True
          End If
        End If
      End If

      If valido = True Then
        If MessageBox.Show("Confirma gravação das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
          dados = New dClienteEndereco
          dadosAnterior = New dClienteEndereco
          regras = New rClienteEndereco

          dados.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
          dados.numero = cFuncoes.TratarInteiro(txtNumero.Text)
          dados.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
          dados.bairro = cFuncoes.TratarTexto(txtBairro.Text)
          dados.cidade = cFuncoes.TratarTexto(txtCidade.Text)
          dados.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
          dados.cep = cFuncoes.TratarInteiro(txtCEP.Text)
          dados.tipoResidencia = cFuncoes.TratarTexto(cboTipo.SelectedValue)
          dados.tipoEndereco = cConstantes.EnderecoAtual
          dados.cliente_cid = Me.cliente_cid

          dadosAnterior.logradouro = cFuncoes.TratarTexto(txtLogradouroAnterior.Text)
          dadosAnterior.numero = cFuncoes.TratarInteiro(txtNumeroAnterior.Text)
          dadosAnterior.complemento = cFuncoes.TratarTexto(txtComplementoAnterior.Text)
          dadosAnterior.bairro = cFuncoes.TratarTexto(txtBairroAnterior.Text)
          dadosAnterior.cidade = cFuncoes.TratarTexto(txtCidadeAnterior.Text)
          dadosAnterior.estado_cid = cFuncoes.TratarInteiro(cboEstadoAnterior.SelectedValue)
          dadosAnterior.cep = cFuncoes.TratarInteiro(txtCEPAnterior.Text)
          dadosAnterior.tipoResidencia = cFuncoes.TratarTexto(cboTipoAnterior.SelectedValue)
          dadosAnterior.tipoEndereco = cConstantes.EnderecoAnterior
          dadosAnterior.cliente_cid = Me.cliente_cid

          regras.ExcluirPorCliente(Me.cliente_cid)
          regras.Incluir(dados)
          regras.Incluir(dadosAnterior)

          ExibirInformacoesTela()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Cliente.")

    End Try
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub ExibirInformacoesTela()
    Dim regras As rClienteEndereco
    Dim dados As dClienteEndereco
    Dim colecao As ColecaoClienteEndereco

    Try

      If Not Me.cliente_cid.Equals(Nothing) Then
        If Not Me.cliente_cid.Equals(0) Then

          txtNome.Text = Me.cliente_nome

          regras = New rClienteEndereco()
          dados = New dClienteEndereco()

          dados.cliente_cid = Me.cliente_cid
          colecao = regras.Consultar(dados)

          If Not colecao Is Nothing Then
            If colecao.Count > 0 Then

              For Each dados In colecao
                If dados.tipoEndereco = cConstantes.EnderecoAtual Then '-- Atual
                  txtLogradouro.Text = cFuncoes.RetornarTexto(dados.logradouro)
                  txtNumero.Text = cFuncoes.RetornarTexto(dados.numero)
                  txtComplemento.Text = cFuncoes.RetornarTexto(dados.complemento)
                  txtBairro.Text = cFuncoes.RetornarTexto(dados.bairro)
                  txtCidade.Text = cFuncoes.RetornarTexto(dados.cidade)
                  If cFuncoes.ValidarValor(dados.cep) Then
                    txtCEP.Text = cFuncoes.RetornarTexto(dados.cep).PadLeft(8, "0")
                  End If
                  If cboEstado.Items.Count > 0 Then
                    cboEstado.SelectedIndex = 0
                  End If
                  If cFuncoes.ValidarValor(dados.estado_cid) Then
                    cboEstado.SelectedValue = cFuncoes.RetornarInteiro(dados.estado_cid)
                  End If
                  If cboTipo.Items.Count > 0 Then
                    cboTipo.SelectedIndex = 0
                  End If
                  If cFuncoes.ValidarValor(dados.tipoResidencia) Then
                    cboTipo.SelectedValue = cFuncoes.RetornarTexto(dados.tipoResidencia)
                  End If
                End If

                If dados.tipoEndereco = cConstantes.EnderecoAnterior Then '-- Anterior
                  txtLogradouroAnterior.Text = cFuncoes.RetornarTexto(dados.logradouro)
                  txtNumeroAnterior.Text = cFuncoes.RetornarTexto(dados.numero)
                  txtComplementoAnterior.Text = cFuncoes.RetornarTexto(dados.complemento)
                  txtBairroAnterior.Text = cFuncoes.RetornarTexto(dados.bairro)
                  txtCidadeAnterior.Text = cFuncoes.RetornarTexto(dados.cidade)
                  If cFuncoes.ValidarValor(dados.cep) Then
                    txtCEPAnterior.Text = cFuncoes.RetornarTexto(dados.cep).PadLeft(8, "0")
                  End If
                  If cboEstadoAnterior.Items.Count > 0 Then
                    cboEstadoAnterior.SelectedIndex = 0
                  End If
                  If cFuncoes.ValidarValor(dados.estado_cid) Then
                    cboEstadoAnterior.SelectedValue = cFuncoes.RetornarInteiro(dados.estado_cid)
                  End If
                  If cboTipoAnterior.Items.Count > 0 Then
                    cboTipoAnterior.SelectedIndex = 0
                  End If
                  If cFuncoes.ValidarValor(dados.tipoResidencia) Then
                    cboTipoAnterior.SelectedValue = cFuncoes.RetornarTexto(dados.tipoResidencia)
                  End If
                End If
              Next

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

  Private Sub LimparCampos()
    txtLogradouro.Text = String.Empty
    txtNumero.Text = String.Empty
    txtComplemento.Text = String.Empty
    txtBairro.Text = String.Empty
    txtCidade.Text = String.Empty
    txtCEP.Text = String.Empty
    If cboEstado.Items.Count > 0 Then
      cboEstado.SelectedIndex = 0
    End If
    If cboTipo.Items.Count > 0 Then
      cboTipo.SelectedIndex = 0
    End If
    txtLogradouroAnterior.Text = String.Empty
    txtNumeroAnterior.Text = String.Empty
    txtComplementoAnterior.Text = String.Empty
    txtBairroAnterior.Text = String.Empty
    txtCidadeAnterior.Text = String.Empty
    txtCEPAnterior.Text = String.Empty
    If cboEstadoAnterior.Items.Count > 0 Then
      cboEstadoAnterior.SelectedIndex = 0
    End If
    If cboTipoAnterior.Items.Count > 0 Then
      cboTipoAnterior.SelectedIndex = 0
    End If
  End Sub

  Private Sub CarregarComboTipoResidencia()
    Dim regras As rTipoResidencia
    Dim colecao As ColecaoTipoResidencia

    Try

      cboTipo.Items.Clear()

      regras = New rTipoResidencia()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dTipoResidencia())

        cboTipo.ValueMember = "codigo"
        cboTipo.DisplayMember = "descricao"
        cboTipo.DataSource = colecao
        cboTipo.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de residência.")

    End Try
  End Sub

  Private Sub CarregarComboTipoResidenciaAnterior()
    Dim regras As rTipoResidencia
    Dim colecao As ColecaoTipoResidencia

    Try

      cboTipoAnterior.Items.Clear()

      regras = New rTipoResidencia()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dTipoResidencia())

        cboTipoAnterior.ValueMember = "codigo"
        cboTipoAnterior.DisplayMember = "descricao"
        cboTipoAnterior.DataSource = colecao
        cboTipoAnterior.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de residência.")

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

  Private Sub CarregarComboEstadoAnterior()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboEstadoAnterior.Items.Clear()

      regras = New rEstado()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dEstado())

        cboEstadoAnterior.ValueMember = "cid"
        cboEstadoAnterior.DisplayMember = "sigla"
        cboEstadoAnterior.DataSource = colecao
        cboEstadoAnterior.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

  Private Sub fClienteEnderecoForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LimparCampos()
    CarregarComboEstado()
    CarregarComboEstadoAnterior()
    CarregarComboTipoResidencia()
    CarregarComboTipoResidenciaAnterior()
    ExibirInformacoesTela()
  End Sub

  Private Sub btoCrediario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCrediario.Click
    CarregarCrediario()
  End Sub
End Class