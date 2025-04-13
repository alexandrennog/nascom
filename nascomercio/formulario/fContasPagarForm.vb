Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsContasPagar
Imports ncRegras.nsContasPagar
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Public Class fContasPagarForm

  Public cid As Nullable(Of Integer)

  Private Sub fContasPagarForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Me.Modal = True Then
      btoFiltro.Visible = False
      btoExcluir.Visible = False
    End If

    LimparCampos()
    CarregarComboFornecedor()
    ExibirInformacoesTela()
  End Sub

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

  Private Function Validar() As Boolean
    Try

      If String.IsNullOrEmpty(txtCodigo.Text.Trim()) Then
        MessageBox.Show("É necessário informar o Código!")
        Return False
      End If

      If Not String.IsNullOrEmpty(txtDataEmissao.Text.Trim()) Then
        If Not ValidarData(txtDataEmissao.Text) Then
          MessageBox.Show("Data de Emissão inválida!")
          Return False
        End If
      End If

      If String.IsNullOrEmpty(txtDataVencimento.Text.Trim()) Then
        MessageBox.Show("É necessário informar a Data de Vencimento!")
        Return False
      End If

      If Not ValidarData(txtDataVencimento.Text) Then
        MessageBox.Show("Data de Vencimento inválida!")
        Return False
      End If

      If String.IsNullOrEmpty(txtValor.Text.Trim()) Then
        MessageBox.Show("É necessário informar o Valor!")
        Return False
      End If

      If Not ValidarDecimal(txtValor.Text) Then
        MessageBox.Show("Valor inválido!")
        Return False
      End If

      '-- Baixa / Pagamento
      If chkPago.Checked = True Then
        If String.IsNullOrEmpty(txtDataPagamento.Text.Trim()) Then
          MessageBox.Show("É necessário informar a Data de Pagamento!")
          Return False
        End If

        If Not ValidarData(txtDataPagamento.Text) Then
          MessageBox.Show("Data de Pagamento inválida!")
          Return False
        End If

        If String.IsNullOrEmpty(txtValorPago.Text.Trim()) Then
          MessageBox.Show("É necessário informar o Valor Pago!")
          Return False
        End If

        If Not ValidarDecimal(txtValorPago.Text) Then
          MessageBox.Show("Valor Pago inválido!")
          Return False
        End If
      Else
        If Not String.IsNullOrEmpty(txtDataPagamento.Text.Trim()) Then
          If Not ValidarData(txtDataPagamento.Text) Then
            MessageBox.Show("Data de Pagamento inválida!")
            Return False
          End If
        End If

        If Not String.IsNullOrEmpty(txtValorPago.Text.Trim()) Then
          If Not ValidarDecimal(txtValorPago.Text) Then
            MessageBox.Show("Valor Pago inválido!")
            Return False
          End If
        End If
      End If

    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Private Sub CarregarComboFornecedor()
    Dim regras As rFornecedor
    Dim colecao As ColecaoFornecedor

    Try

      cboFornecedor.DataSource = Nothing
      cboFornecedor.Items.Clear()

      regras = New rFornecedor()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        cboFornecedor.ValueMember = "cid"
        cboFornecedor.DisplayMember = "nome"
        cboFornecedor.DataSource = colecao
        cboFornecedor.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Fornecedor.")

    End Try
  End Sub

  Private Sub ExibirInformacoesTela()
    Dim regras As rContasPagar
    Dim dados As dContasPagar

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.Equals(0) Then

          regras = New rContasPagar()

          dados = regras.Consultar(Me.cid)

          If Not dados Is Nothing Then
            txtCodigo.Text = RetornarTexto(dados.codigo)
            txtCodigoBarras.Text = RetornarTexto(dados.codigoBarra)
            If cboFornecedor.Items.Count > 0 Then
              cboFornecedor.SelectedIndex = 0
            End If
            If ValidarValor(dados.fornecedor_cid) Then
              cboFornecedor.SelectedValue = dados.fornecedor_cid
            End If
            txtDataEmissao.Text = RetornarTexto(FormatarData(dados.dataEmissao))
            txtDataVencimento.Text = RetornarTexto(FormatarData(dados.dataVencimento))
            txtValor.Text = RetornarTexto(dados.valor)
            txtObservacao.Text = RetornarTexto(dados.observacao)
            chkAceite.Checked = dados.aceite
            chkPago.Checked = dados.pago
            txtDataPagamento.Text = RetornarTexto(FormatarData(dados.dataPagamento))
            txtValorPago.Text = RetornarTexto(dados.valorPagamento)

            VerificarPagamento()
          End If
        End If
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados da ContasPagar.")

    End Try

  End Sub

  Private Sub LimparCampos()
    txtCodigo.Text = String.Empty
    txtCodigoBarras.Text = String.Empty
    txtDataEmissao.Text = String.Empty
    txtDataVencimento.Text = String.Empty
    txtValor.Text = String.Empty
    txtObservacao.Text = String.Empty
    chkAceite.Checked = False
    chkPago.Checked = False
    txtDataPagamento.Text = String.Empty
    txtValorPago.Text = String.Empty
    If cboFornecedor.Items.Count > 0 Then
      cboFornecedor.SelectedIndex = 0
    End If
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

  Private Sub Filtrar()
    mdiPrincipal.CarregarContasPagarFiltro()
  End Sub

  Private Sub Salvar()
    Dim dados As dContasPagar
    Dim regras As rContasPagar
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
        dados = New dContasPagar
        regras = New rContasPagar

        dados.cid = Me.cid
        dados.codigo = TratarTexto(txtCodigo.Text)
        dados.codigoBarra = TratarTexto(txtCodigoBarras.Text)
        dados.dataEmissao = TratarTexto(FormatarData(txtDataEmissao.Text))
        dados.dataVencimento = TratarTexto(FormatarData(txtDataVencimento.Text))
        dados.valor = TratarDecimal(txtValor.Text)
        dados.observacao = TratarTexto(txtObservacao.Text)
        dados.aceite = chkAceite.Checked
        dados.pago = chkPago.Checked
        dados.dataPagamento = TratarTexto(FormatarData(txtDataPagamento.Text))
        dados.valorPagamento = TratarDecimal(txtValorPago.Text)
        dados.fornecedor_cid = TratarInteiro(cboFornecedor.SelectedValue)

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

      MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Contas a Pagar.")

    End Try
  End Sub

  Private Sub Excluir()

    Dim dados As dContasPagar
    Dim regras As rContasPagar

    Try

      If Not Me.cid.Equals(Nothing) Then
        If Not Me.cid.ToString().Equals(String.Empty) Then
          If Not Me.cid.Equals(0) Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
              dados = New dContasPagar
              regras = New rContasPagar

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

      MessageBox.Show("Erro na exclusão dos dados de Contas a Pagar.")

    End Try
  End Sub

  Private Sub fContasPagarForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub chkPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPago.CheckedChanged
    VerificarPagamento()
  End Sub

  Private Sub VerificarPagamento()
    If chkPago.Checked = True Then
      txtDataPagamento.Enabled = True
      txtValorPago.Enabled = True
    Else
      txtDataPagamento.Text = ""
      txtDataPagamento.Enabled = False
      txtValorPago.Text = ""
      txtValorPago.Enabled = False
    End If
  End Sub

End Class