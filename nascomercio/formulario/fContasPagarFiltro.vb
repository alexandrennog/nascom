Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsContasPagar
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Public Class fContasPagarFiltro

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Pesquisar()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarContasPagarForm()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dContasPagar

    filtro = New dContasPagar

    filtro.codigo = TratarTexto(txtCodigo.Text)
    filtro.codigoBarra = TratarTexto(txtCodigoBarras.Text)
    filtro.dataEmissao = TratarTexto(FormatarData(txtDataEmissao.Text))
    filtro.dataVencimento = TratarTexto(FormatarData(txtDataVencimento.Text))
    filtro.valor = TratarDecimal(txtValor.Text)
    filtro.observacao = TratarTexto(txtObservacao.Text)
    filtro.aceite = chkAceite.Checked
    filtro.pago = chkPago.Checked
    filtro.dataPagamento = TratarTexto(FormatarData(txtDataPagamento.Text))
    filtro.valorPagamento = TratarDecimal(txtValorPago.Text)
    filtro.fornecedor_cid = TratarInteiro(cboFornecedor.SelectedValue)

    fContasPagarLista.filtro = filtro

    mdiPrincipal.CarregarContasPagarLista()
  End Sub

  Private Sub CarregarComboFornecedor()
    Dim regras As rFornecedor
    Dim colecao As ColecaoFornecedor

    Try

      cboFornecedor.DataSource = Nothing
      cboFornecedor.Items.Clear()

      regras = New rFornecedor()

      colecao = New ColecaoFornecedor()
      colecao.Add(New dFornecedor())
      colecao.AddRange(regras.Listar())

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

  Private Sub fContasPagarFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    CarregarComboFornecedor()
  End Sub

  Private Sub fContasPagarFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub

End Class