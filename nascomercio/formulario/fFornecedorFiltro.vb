Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsFornecedor
Imports ncDados.nsMunicipios
Imports ncRegras.nsMunicipios
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fFornecedorFiltro

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub fFornecedorFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.F6
        CarregarProdutoFiltro()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarFornecedorForm()
  End Sub

  Private Function Validar() As Boolean
    Try
      If Not String.IsNullOrEmpty(txtCodigo.Text.Trim()) Then
        If Not cFuncoes.ValidarInteiro(txtCodigo.Text.Trim()) Then
          MessageBox.Show("O código deve ser numérico!")
          Return False
        End If
      End If
    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub Pesquisar()
    Dim filtro As dFornecedor

    If Not Validar() Then
      Exit Sub
    End If

    filtro = New dFornecedor

    filtro.nome = cFuncoes.TratarTexto(txtNome.Text)
    filtro.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
    filtro.numero = cFuncoes.TratarInteiro(txtNumero.Text)
    filtro.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
    filtro.bairro = cFuncoes.TratarTexto(txtBairro.Text)
    filtro.cidade_cid = cFuncoes.TratarInteiro(cboMunicipio.SelectedValue)
    filtro.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
    filtro.cep = cFuncoes.TratarInteiro(txtCEP.Text)
    filtro.inscricaoEstadual = cFuncoes.TratarTexto(txtInscricaoEstadual.Text)
    filtro.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
    filtro.ddd = cFuncoes.TratarInteiro(txtDDD.Text)
    filtro.telefone = cFuncoes.TratarTexto(txtTelefone.Text)
    filtro.ramal = cFuncoes.TratarInteiro(txtRamal.Text)
    filtro.nomeContato = cFuncoes.TratarTexto(txtContato.Text)
    filtro.cid = cFuncoes.TratarInteiro(txtCodigo.Text.Trim())
    filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

    fFornecedorLista.filtro = filtro

    mdiPrincipal.CarregarFornecedorLista()
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

  Private Sub CarregarComboMunicipio()
    Dim regras As rMunicipios
    Dim colecao As ColecaoMunicipios
    Dim codigo As Integer

    Try

      cboMunicipio.DataSource = Nothing
      cboMunicipio.Items.Clear()

      If cboEstado.Items.Count > 0 Then
        If cboEstado.SelectedValue IsNot Nothing Then
          If Not String.IsNullOrEmpty(cboEstado.SelectedValue.ToString()) Then

            codigo = Convert.ToInt32(cboEstado.SelectedValue)

            regras = New rMunicipios()
            colecao = regras.ListarPorEstados(codigo)

            If Not colecao Is Nothing Then
              colecao.Insert(0, New dMunicipios())

              cboMunicipio.ValueMember = "cid"
              cboMunicipio.DisplayMember = "nome"
              cboMunicipio.DataSource = colecao
              cboMunicipio.Refresh()
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
        cboEstado.DisplayMember = "nome"
        cboEstado.DataSource = colecao
        cboEstado.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Estados.")

    End Try
  End Sub

  Private Sub fFornecedorFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarComboSituacao()
    CarregarComboEstado()
  End Sub

  Private Sub btoProdutos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProdutos.Click
    CarregarProdutoFiltro()
  End Sub

  Private Sub CarregarProdutoFiltro()
    mdiPrincipal.CarregarProdutoFiltro()
  End Sub

  Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
    CarregarComboMunicipio()
  End Sub

End Class