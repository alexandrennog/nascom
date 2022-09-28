Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsLoja
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fLojaFiltro

  Private Sub Cadastrar()
    mdiPrincipal.CarregarLojaForm()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dLoja

    filtro = New dLoja

    filtro.nomeFantasia = cFuncoes.TratarTexto(txtNomeFantasia.Text)
    filtro.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
    filtro.numero = cFuncoes.TratarInteiro(txtNumero.Text)
    filtro.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
    filtro.bairro = cFuncoes.TratarTexto(txtBairro.Text)
    filtro.cidade = cFuncoes.TratarTexto(txtCidade.Text)
    filtro.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
    filtro.cep = cFuncoes.TratarInteiro(txtCEP.Text)
    filtro.razaoSocial = cFuncoes.TratarTexto(txtRazaoSocial.Text)
    filtro.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
    filtro.ddd = cFuncoes.TratarInteiro(txtDDD.Text)
    filtro.telefone = cFuncoes.TratarInteiro(txtTelefone.Text)
    filtro.ramal = cFuncoes.TratarInteiro(txtRamal.Text)
    filtro.nomeContato = cFuncoes.TratarTexto(txtContato.Text)
    filtro.codigo = cFuncoes.TratarTexto(txtCodigo.Text)
    filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

    fFechamento.filtro = filtro

    mdiPrincipal.CarregarLojaLista()
  End Sub

  Private Sub CarregarComboSituacao()
    Dim regras As rSituacao
    Dim colecao As ColecaoSituacao

    Try

      cboSituacao.Items.Clear()

      regras = New rSituacao()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then


        cboSituacao.ValueMember = "codigo"
        cboSituacao.DisplayMember = "descricao"
        cboSituacao.DataSource = colecao
        cboSituacao.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Situação.")

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

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub fLojaFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub

  Private Sub fLojaFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarComboSituacao()
    CarregarComboEstado()
  End Sub

End Class