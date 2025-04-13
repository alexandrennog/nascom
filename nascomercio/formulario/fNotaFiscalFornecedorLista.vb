Imports ncRegras.nsNotaFiscalFornecedor
Imports ncDados.nsNotaFiscalFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFornecedor
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes.cFuncoes

Public Class fNotaFiscalFornecedorLista

    Public filtro As dNotaFiscalFornecedor

    Private Sub fNotaFiscalFornecedorLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    mdiPrincipal.FecharTela()
                End If
            Case Keys.F5
                Cadastrar()
            Case Keys.Enter
                Pesquisar()
            Case Keys.F4
                Selecionar()
            Case Keys.F8
                Alterar()
        End Select
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub btoSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSelecionar.Click
        Selecionar()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub Selecionar()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim numero As String = Nothing
        Dim serie As String = Nothing

        Try
            If dgvNF.Rows.Count > 0 Then

                indice = dgvNF.CurrentRow.Index

                linha = dgvNF.Rows(indice)

                numero = linha.Cells("numero").Value
                serie = linha.Cells("serie").Value

                fProdutoForm.nffNumero = numero
                fProdutoForm.nffSerie = serie
                fProdutoForm.nffTipoAcao = "i"
                Select Case mdiPrincipal.formulario.Name
                    Case "fProdutoForm"
                        fProdutoForm.txtNotaFiscalNumero.Text = numero
                        fProdutoForm.txtNotaFiscalSerie.Text = serie
                    Case "fProdutoEntradaSaidaEstoque"
                        fProdutoEntradaSaidaEstoque.txtNotaFiscalNumero.Text = numero
                        fProdutoEntradaSaidaEstoque.txtNotaFiscalSerie.Text = serie
                End Select

                Me.Close()
            End If
        Catch ex As Exception
            numero = Nothing
            serie = Nothing
        End Try
    End Sub

    Private Sub Pesquisar()
        Dim regras As rNotaFiscalFornecedor
        Dim dados As dNotaFiscalFornecedor
        Dim notas As ColecaoNotaFiscalFornecedor
        Dim linha As DataGridViewRow

        Try

            dgvNF.Rows.Clear()
            dgvNF.Refresh()

            regras = New rNotaFiscalFornecedor()
            dados = New dNotaFiscalFornecedor()

            dados.numero = TratarTexto(txtNumero.Text)
            dados.serie = TratarTexto(txtSerie.Text)
            dados.fornecedor_cid = TratarInteiro(cboFornecedor.SelectedValue)
            dados.dataEmissao = TratarTexto(FormatarDataUniversal(txtDataEmissao.Text))
            dados.produtoCodigo = TratarTexto(txtCodigo.Text)

            notas = regras.Consultar(dados)

            If Not IsNothing(notas) Then
                For Each nota As dNotaFiscalFornecedor In notas
                    linha = dgvNF.Rows(dgvNF.Rows.Add())
                    linha.Cells("numero").Value = nota.numero
                    linha.Cells("serie").Value = nota.serie
                    linha.Cells("fornecedor").Value = nota.fornecedorNome
                    linha.Cells("dataEmissao").Value = nota.dataEmissao
                    linha.Cells("valorTotalNota").Value = nota.valorTotalNota
                Next
            End If

            dgvNF.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Nota Fiscal.")

        End Try

    End Sub

    Private Sub Cadastrar()
        mdiPrincipal.CarregarNotaFiscalFornecedorForm()
    End Sub

    Private Sub CarregarComboFornecedor()
        Dim regras As rFornecedor
        Dim colecao As ColecaoFornecedor

        Try

            cboFornecedor.DataSource = Nothing
            cboFornecedor.Items.Clear()

            regras = New rFornecedor()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dFornecedor())

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

    Private Sub fNotaFiscalFornecedorLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarComboFornecedor()

        txtNumero.Text = fProdutoForm.nffNumero
        txtSerie.Text = fProdutoForm.nffSerie

        If fProdutoForm.nffTipoAcao = "l" Then
            Pesquisar()
        End If
    End Sub

    Private Sub btoAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAlterar.Click
        Alterar()
    End Sub

    Private Sub Alterar()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim numero As String = Nothing
        Dim serie As String = Nothing

        Try
            If dgvNF.Rows.Count > 0 Then

                indice = dgvNF.CurrentRow.Index

                linha = dgvNF.Rows(indice)

                numero = linha.Cells("numero").Value
                serie = linha.Cells("serie").Value

                fProdutoForm.nffNumero = numero
                fProdutoForm.nffSerie = serie
                fProdutoForm.nffTipoAcao = "a"

                mdiPrincipal.CarregarNotaFiscalFornecedorForm()
            End If
        Catch ex As Exception
            numero = Nothing
            serie = Nothing
        End Try
    End Sub

End Class