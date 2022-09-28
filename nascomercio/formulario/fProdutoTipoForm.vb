Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Public Class fProdutoTipoForm

  Public cid As Nullable(Of Integer)

  Private Sub Salvar()
    Dim dados As dProdutoTipo
    Dim regras As rProdutoTipo
    Dim tipoMsg As String = String.Empty
    Dim tipoAcao As String = String.Empty
    Dim novoCID As Integer

    Try

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
        dados = New dProdutoTipo
        regras = New rProdutoTipo

        dados.cid = Me.cid
        dados.nome = TratarTexto(txtNome.Text)
        dados.situacao = TratarTexto(cboSituacao.SelectedValue)

        If tipoAcao.Equals("i") Then
          novoCID = regras.Incluir(dados)

          Me.cid = novoCID
          ExibirInformacoesTela()
        ElseIf tipoAcao.Equals("a") Then
          regras.Alterar(dados)

          ExibirInformacoesTela()
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Tipo de Produto.")

    End Try
  End Sub

  Private Sub Excluir()
    Dim dados As dProdutoTipo
    Dim regras As rProdutoTipo

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dProdutoTipo
              regras = New rProdutoTipo

              dados.cid = TratarInteiro(Me.cid)

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

      MessageBox.Show("Erro na exclusão dos dados de Tipo de Produto.")

    End Try
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

  Private Sub ExibirInformacoesTela()
    Dim regras As rProdutoTipo
    Dim dados As dProdutoTipo

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rProdutoTipo()

          dados = regras.Consultar(Me.cid)

          If Not dados Is Nothing Then
            txtNome.Text = RetornarTexto(dados.nome)
            If cboSituacao.Items.Count > 0 Then
              cboSituacao.SelectedIndex = 0
            End If
            If ValidarValor(dados.situacao) Then
              cboSituacao.SelectedValue = RetornarTexto(dados.situacao)
            End If
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de Produto.")

    End Try
  End Sub

  Private Sub LimparCampos()
    txtNome.Text = String.Empty
    If cboSituacao.Items.Count > 0 Then
      cboSituacao.SelectedIndex = 0
    End If
  End Sub

  Private Sub fProdutoTipoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LimparCampos()
    CarregarComboSituacao()
    ExibirInformacoesTela()
  End Sub


  Private Sub fProdutoTipoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
          mdiPrincipal.FecharTela()
        End If
      Case Keys.F5
        Filtrar()
      Case Keys.F6
        CarregarProdutoTipoCaracteristica()
      Case Keys.Enter
        Salvar()
      Case Keys.F12
        Excluir()
    End Select
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarProdutoTipoFiltro()
  End Sub

  Private Sub CarregarProdutoTipoCaracteristica()
    If Not Me.cid.Equals(Nothing) Then
      If Not Me.cid.Equals(0) Then
        fProdutoTipoCaracteristicaForm.produtoTipo_cid = Me.cid
        mdiPrincipal.CarregarProdutoTipoCaracteristicaForm()
      End If
    End If
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
    Excluir()
  End Sub

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCaracteristica.Click
    CarregarProdutoTipoCaracteristica()
  End Sub

  Private Sub btoProdutos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CarregarProdutoFiltro()
  End Sub

  Private Sub CarregarProdutoFiltro()
    mdiPrincipal.CarregarProdutoFiltro()
  End Sub

End Class