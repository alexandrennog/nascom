Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncDados.nsCrediario
Imports ncRegras.nsCrediario
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fClienteCrediarioParcelasForm

    Public pago As Boolean

    Private Sub Salvar()
        Dim crediario As New ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As New ncDados.nsCrediario.dCrediario
        Dim parcelas As New ncDados.nsCrediario.ColecaoParcelas
        Dim parcela As ncDados.nsCrediario.dParcelas

        Try

            If MessageBox.Show("Confirma gravação das informações?", "Crediário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                For Each linha As DataGridViewRow In dgvCrediario.Rows
                    If linha.Cells(3).Value <> "" Then
                        parcela = New ncDados.nsCrediario.dParcelas()
                        parcela.cid = linha.Cells(0).Tag
                        parcela.crediarioId = txtControle.Tag
                        parcela.codigoBarras = linha.Cells(0).Value
                        parcela.dataEmissao = linha.Cells(1).Value
                        parcela.dataVecimento = linha.Cells(2).Value
                        parcela.valor = linha.Cells(3).Value
                        parcela.valorPago = linha.Cells(4).Value
                        parcela.valorReceber = parcela.valor - parcela.valorPago
                        If (linha.Cells(6).Value = "00") Then
                            If (parcela.valor - parcela.valorPago) > 0.009 Then
                                parcela.situacao = "00" ' n pagou
                            Else
                                parcela.situacao = "01" ' pagou
                            End If
                        Else
                            parcela.situacao = "01" ' pagou
                        End If

                        parcela.dataPagamento = CDate(linha.Cells(5).Value)
                        parcela.observacao = linha.Cells(6).Value

                        dadosCrediario.SaldoDevedor += (parcela.valor - parcela.valorPago)
                        dadosCrediario.ValorPago += parcela.valorPago
                        dadosCrediario.ValorTotal += parcela.valor

                        parcelas.Add(parcela)
                    End If
                Next

                dadosCrediario.usuarioId = lblVendedor.Tag
                dadosCrediario.clienteId = txtCliente.Tag
                dadosCrediario.controle = txtControle.Text
                dadosCrediario.Parcelas = dgvCrediario.Rows.Count
                dadosCrediario.DataVenda = Today
                dadosCrediario.cid = txtControle.Tag
                crediario.Renegociar(dadosCrediario, parcelas)

                If dgvCrediario.Rows.Count <= 0 Then
                    If MessageBox.Show("Deseja excluir crediário?", "Crediário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        crediario.Excluir(dadosCrediario)
                    End If
                Else
                    ImprimirCrediario()
                End If

                pago = True
                Me.Close()
            End If

            ExibirInformacoes()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na gravação dos dados de Crediário.")

        End Try
    End Sub

    Private Sub ImprimirCrediario()

        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim tamanhoEtiqueta As String

        Dim impressao As ncComum.Impressao
        Dim etiqueta As EtiquetaCrediario
        Dim colecaoEtiqueta As ColecaoEtiqueta
        Dim colecaoLinha As ColecaoLinha
        Dim colecaoParcelas As ColecaoParcelas
        Dim crediario As dCrediario
        Dim linha As String
        Dim parcela As dParcelas

        impressao = New ncComum.Impressao
        etiqueta = New EtiquetaCrediario()
        colecaoEtiqueta = New ColecaoEtiqueta()
        colecaoLinha = New ColecaoLinha()
        colecaoParcelas = New ColecaoParcelas()
        crediario = New dCrediario()

        crediario.controle = Me.txtControle.Text
        crediario.DataVenda = Today
        crediario.SaldoDevedor = Me.lblFalta.Text
        crediario.clienteId = Me.txtCliente.Tag

        For Each linhaGrid As DataGridViewRow In dgvCrediario.Rows
            '-- parcelas
            parcela = New dParcelas()
            parcela.codigoBarras = linhaGrid.Cells(0).Value
            parcela.dataEmissao = linhaGrid.Cells(1).Value
            parcela.dataVecimento = linhaGrid.Cells(2).Value
            parcela.valor = linhaGrid.Cells(3).Value
            parcela.valorReceber = linhaGrid.Cells(3).Value
            parcela.valorPago = 0

            crediario.ValorPago += parcela.valorPago
            crediario.ValorTotal += parcela.valor

            colecaoParcelas.Add(parcela)
        Next

        ' Tamanho Etiqueta
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TamanhoEtiqueta)
        If Not IsNothing(dadosParametro) Then
            tamanhoEtiqueta = dadosParametro.valor
        Else
            tamanhoEtiqueta = ""
        End If


        colecaoEtiqueta = etiqueta.MontarEtiqueta(colecaoParcelas, crediario, txtCliente.Text, mdiPrincipal.gLoja.nomeFantasia, tamanhoEtiqueta)

        If MessageBox.Show("Imprimir etiquetas?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            '-- Imprimir etiqueta
            impressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("ETIQUETA"))
            For Each colecaoLinha In colecaoEtiqueta
                For Each linha In colecaoLinha
                    impressao.Write(linha)
                Next
            Next
            impressao.EndWrite()
        End If

    End Sub

    Private Sub LimparCampos()
        txtLimite.Text = String.Empty
        txtDisponivel.Text = String.Empty
    End Sub

    Private Sub ExibirInformacoes()
        Dim dadosCliente As ncDados.nsCliente.dClienteFinanceiro
        Dim consultaCliente As ncRegras.nsCliente.rClienteFinanceiro
        Dim dadosFinanceiro As ncDados.nsCliente.ColecaoClienteFinanceiro

        Dim regrasCrediario As ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As ncDados.nsCrediario.dCrediario
        Dim dadosListaCrediario As ncDados.nsCrediario.ColecaoCrediario

        Try
            dadosCliente = New ncDados.nsCliente.dClienteFinanceiro()
            consultaCliente = New ncRegras.nsCliente.rClienteFinanceiro()

            dadosCliente.cliente_cid = txtCliente.Tag
            dadosFinanceiro = consultaCliente.fConsultar(dadosCliente)

            If Not IsNothing(dadosFinanceiro) Then
                If dadosFinanceiro.Count > 0 Then
                    txtLimite.Text = CDec(dadosFinanceiro(0).limite).ToString("N")
                    txtDisponivel.Text = txtLimite.Text
                    'txtDisponivel.Text = CDec(dadosFinanceiro(0).limite - CDec(lblTotal.Text)).ToString("N")
                End If
            Else
                MessageBox.Show("Selecionar um Cliente!")
            End If

            ' Consulta dados de crediário
            regrasCrediario = New ncRegras.nsCrediario.rCrediario
            dadosCrediario = New ncDados.nsCrediario.dCrediario
            dadosCrediario.clienteId = Me.txtCliente.Tag
            dadosListaCrediario = regrasCrediario.Consultar(dadosCrediario)

            If Not IsNothing(dadosListaCrediario) Then
                For Each dadosCrediario In dadosListaCrediario
                    txtDisponivel.Text = CDec(CDec(txtDisponivel.Text) - dadosCrediario.SaldoDevedor).ToString("N")
                Next
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                IncluirItem()
            Case Keys.F2
                ExcluirItem()
            Case Keys.F3
                ExibirPagamentos()
            Case Keys.F7
                btoEtiqueta_Click(sender, e)
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Salvar()
        End Select
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LimparCampos()
        ExibirInformacoes()
    End Sub


    Private Sub dgvCrediario_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCrediario.CellValueChanged
        Dim total As Decimal

        For Each linha As DataGridViewRow In dgvCrediario.Rows
            total = CDec(total + linha.Cells(3).Value)
        Next

        If lblTotal.Text <> "" Then
            lblFalta.Text = CDec(CDec(lblTotal.Text) - total).ToString("N")
            If CDec(lblFalta.Text) < 0.0 Then
                lblFalta.Text = 0.ToString("N")
            End If
        End If

    End Sub

    Private Sub IncluirItem()
        If dgvCrediario.Columns.Count > 0 Then
            dgvCrediario.Rows.Add()

            'Insere no grid nova parcela
            If dgvCrediario.Rows.Count > 1 Then
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(0).Value = CStr(dgvCrediario.Rows(dgvCrediario.Rows.Count - 2).Cells(0).Value + 1).PadLeft(12, "0"c)
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(2).Value = CDate(dgvCrediario.Rows(dgvCrediario.Rows.Count - 2).Cells(2).Value).AddMonths(1).ToString("dd/MM/yyyy")
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(3).Value = lblFalta.Text
            Else
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(0).Value = CStr(txtCliente.Tag).PadLeft(6, "0"c) & (txtControle.Text.ToString() & CStr(1)).PadLeft(6, "0"c)
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(2).Value = Today.AddMonths(1).ToString("dd/MM/yyyy")
                dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(3).Value = lblFalta.Text
            End If
            dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(1).Value = Today.ToString("dd/MM/yyyy")

            dgvCrediario.Refresh()
        End If


    End Sub

    Private Sub ExcluirItem()
        If dgvCrediario.Rows.Count > 0 Then
            dgvCrediario.Rows.RemoveAt(dgvCrediario.CurrentRow.Index)
        End If
    End Sub

    Private Sub ExibirPagamentos()

        Dim janela As fClientePagamentos
        Dim parcelas As ColecaoParcelas

        Dim dadosParcela As New dParcelas
        Dim regraparcela As New rCrediario

        If dgvCrediario.Rows.Count > 0 Then
            dadosParcela.codigoBarras = dgvCrediario.CurrentRow.Cells(0).Tag
        Else
            MessageBox.Show("Nenhum crediário selecionado.")
            Exit Sub
        End If

        janela = New fClientePagamentos()

        Try
            parcelas = regraparcela.ConsultarParcelas(dadosParcela)
            If Not IsNothing(parcelas) Then
                janela.txtControle.Tag = dadosParcela.crediarioId
            Else
                janela.txtControle.Tag = dgvCrediario.CurrentRow.Cells(0).Tag
            End If
            janela.lblTotal.Text = dgvCrediario.CurrentRow.Cells(3).Value
            janela.lblFalta.Text = dgvCrediario.CurrentRow.Cells(4).Value
            janela.txtCodigo.Text = dgvCrediario.CurrentRow.Cells(0).Value
            janela.txtControle.Text = txtControle.Text
            janela.txtCliente.Text = Me.txtCliente.Text
            janela.txtCliente.Tag = Me.txtCliente.Tag

            janela.StartPosition = FormStartPosition.CenterParent
            janela.lblVendedor.Text = mdiPrincipal.gUsuario.usuario
            janela.lblVendedor.Tag = mdiPrincipal.gUsuario.cid
        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados do Cliente.")

        End Try

        janela.ShowDialog()

    End Sub

    Private Sub btoEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiqueta.Click
        ImprimirCrediario()
    End Sub

    Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
        IncluirItem()
    End Sub

    Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
        ExcluirItem()
    End Sub

    Private Sub btnPagamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagamentos.Click
        ExibirPagamentos()
    End Sub
End Class