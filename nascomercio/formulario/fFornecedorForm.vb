Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsMunicipios
Imports ncRegras.nsMunicipios
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fFornecedorForm

  Public cid As Nullable(Of Integer)

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Sair()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
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

  Private Sub fFornecedorForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Sair()
      Case Keys.F5
        Filtrar()
      Case Keys.F6
        CarregarProdutoFiltro()
      Case Keys.Enter
        Salvar()
      Case Keys.F12
        Excluir()
    End Select
  End Sub

  Private Sub Excluir()
    Dim dados As dFornecedor
    Dim regras As rFornecedor

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dFornecedor
              regras = New rFornecedor

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

      MessageBox.Show("Erro na exclusão dos dados de Fornecedor.")

    End Try
  End Sub

  Private Function Validar() As Boolean
    Try

      If String.IsNullOrEmpty(txtNome.Text.Trim()) Then
        MessageBox.Show("É necessário informar o Nome!")
        Return False
      End If

    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub Salvar()
    Dim dados As dFornecedor
    Dim regras As rFornecedor
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
        dados = New dFornecedor
        regras = New rFornecedor

        dados.cid = Me.cid
        dados.nome = cFuncoes.TratarTexto(txtNome.Text)
        dados.logradouro = cFuncoes.TratarTexto(txtLogradouro.Text)
        dados.numero = cFuncoes.TratarInteiro(txtNumero.Text)
        dados.complemento = cFuncoes.TratarTexto(txtComplemento.Text)
        dados.bairro = cFuncoes.TratarTexto(txtBairro.Text)
        dados.cidade_cid = cFuncoes.TratarInteiro(cboMunicipio.SelectedValue)
        dados.estado_cid = cFuncoes.TratarInteiro(cboEstado.SelectedValue)
        dados.cep = cFuncoes.TratarInteiro(txtCEP.Text)
        dados.inscricaoEstadual = cFuncoes.TratarTexto(txtInscricaoEstadual.Text)
        dados.cnpj = cFuncoes.TratarTexto(txtCnpj.Text)
        dados.ddd = cFuncoes.TratarInteiro(txtDDD.Text)
        dados.telefone = cFuncoes.TratarTexto(txtTelefone.Text)
        dados.ramal = cFuncoes.TratarInteiro(txtRamal.Text)
        dados.nomeContato = cFuncoes.TratarTexto(txtContato.Text)
        'dados.codigo = cFuncoes.TratarTexto(txtCodigo.Text)
        dados.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

        If tipoAcao.Equals("i") Then
          novoCID = regras.Incluir(dados)

          Me.cid = novoCID
          ExibirInformacoesTela()
        ElseIf tipoAcao.Equals("a") Then
          regras.Alterar(dados)

          ExibirInformacoesTela()
        End If

        SelecionarNovoFornecedor()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Fornecedor.")

    End Try
  End Sub

  Private Sub SelecionarNovoFornecedor()
    If Me.Modal = True Then
      If Not Me.cid.Equals(Nothing) Then
        fProdutoForm.SelecionarNovoFornecedor(Me.cid)
      End If

      Sair()
    End If
  End Sub

  Public Sub Filtrar()
    mdiPrincipal.CarregarFornecedorFiltro()
  End Sub

  Private Sub LimparCampos()
    txtCodigo.Text = String.Empty
    txtNome.Text = String.Empty
    txtCnpj.Text = String.Empty
    txtInscricaoEstadual.Text = String.Empty
    txtLogradouro.Text = String.Empty
    txtNumero.Text = String.Empty
    txtComplemento.Text = String.Empty
    txtBairro.Text = String.Empty
    txtCep.Text = String.Empty
    txtDDD.Text = String.Empty
    txtTelefone.Text = String.Empty
    txtRamal.Text = String.Empty
    txtContato.Text = String.Empty
    If cboMunicipio.Items.Count > 0 Then
      cboMunicipio.SelectedIndex = 0
    End If
    If cboEstado.Items.Count > 0 Then
      cboEstado.SelectedIndex = 0
    End If
    If cboSituacao.Items.Count > 0 Then
      cboSituacao.SelectedIndex = 0
    End If
  End Sub

  Private Sub ExibirInformacoesTela()
    Dim regras As rFornecedor
    Dim dados As dFornecedor

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rFornecedor()

          dados = regras.Consultar(Me.cid)

          If Not dados Is Nothing Then
            txtCodigo.Text = cFuncoes.RetornarTexto(dados.cid)
            txtNome.Text = cFuncoes.RetornarTexto(dados.nome)
            txtCnpj.Text = cFuncoes.RetornarTexto(dados.cnpj)
            txtInscricaoEstadual.Text = cFuncoes.RetornarTexto(dados.inscricaoEstadual)
            txtLogradouro.Text = cFuncoes.RetornarTexto(dados.logradouro)
            txtNumero.Text = cFuncoes.RetornarTexto(dados.numero)
            txtComplemento.Text = cFuncoes.RetornarTexto(dados.complemento)
            txtBairro.Text = cFuncoes.RetornarTexto(dados.bairro)
            txtCep.Text = cFuncoes.RetornarTexto(dados.cep)
            txtDDD.Text = cFuncoes.RetornarTexto(dados.ddd)
            txtTelefone.Text = cFuncoes.RetornarTexto(dados.telefone)
            txtRamal.Text = cFuncoes.RetornarTexto(dados.ramal)
            txtContato.Text = cFuncoes.RetornarTexto(dados.nomeContato)

            If cboEstado.Items.Count > 0 Then
              cboEstado.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.estado_cid) Then
              cboEstado.SelectedValue = cFuncoes.RetornarInteiro(dados.estado_cid)
            End If

            CarregarComboMunicipio()

            If cboMunicipio.Items.Count > 0 Then
              cboMunicipio.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.cidade_cid) Then
              cboMunicipio.SelectedValue = cFuncoes.RetornarInteiro(dados.cidade_cid)
            End If
            If cboSituacao.Items.Count > 0 Then
              cboSituacao.SelectedIndex = 0
            End If
            If cFuncoes.ValidarValor(dados.situacao) Then
              cboSituacao.SelectedValue = cFuncoes.RetornarTexto(dados.situacao)
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Fornecedor.")

    End Try
  End Sub

  Private Sub fFornecedorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Me.Modal = True Then
      btoFiltro.Visible = False
      btoProdutos.Visible = False
      btoExcluir.Visible = False
    End If

    LimparCampos()
    CarregarComboSituacao()
    CarregarComboEstado()
    ExibirInformacoesTela()
  End Sub

  Private Sub CarregarComboEstado()
    Dim regras As rEstado
    Dim colecao As ColecaoEstado

    Try

      cboEstado.DataSource = Nothing
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

  Private Sub CarregarComboSituacao()
    Dim regras As rSituacao
    Dim colecao As ColecaoSituacao

    Try

      cboSituacao.DataSource = Nothing
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