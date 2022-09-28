Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncDados.nsCrediario
Imports ncRegras.nsCliente
Imports ncDados.nsCliente
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fCrediarioForm

    Public pago As Boolean

    Private Sub Salvar()
        Dim valido As Boolean = True
        Dim existe As Boolean = False
        Dim crediario As New ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As New ncDados.nsCrediario.dCrediario
        Dim parcelas As New ncDados.nsCrediario.ColecaoParcelas
        Dim parcela As ncDados.nsCrediario.dParcelas

        Try

            If valido = True Then
                If MessageBox.Show("Confirma gravação das informações?", "Crediário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                    dadosCrediario.usuarioId = lblVendedor.Tag
                    dadosCrediario.clienteId = txtCliente.Tag
                    dadosCrediario.controle = txtControle.Text
                    dadosCrediario.Parcelas = dgvCrediario.Rows.Count
                    dadosCrediario.SaldoDevedor = lblTotal.Text
                    dadosCrediario.ValorPago = 0
                    dadosCrediario.ValorTotal = lblTotal.Text
                    dadosCrediario.DataVenda = Today
                    dadosCrediario.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")

                    If Not existe = True Then
                        For Each linha As DataGridViewRow In dgvCrediario.Rows
                            If linha.Cells(3).Value <> "" Then
                                parcela = New ncDados.nsCrediario.dParcelas()
                                parcela.codigoBarras = linha.Cells(0).Value
                                parcela.dataEmissao = linha.Cells(1).Value
                                parcela.dataVecimento = linha.Cells(2).Value
                                parcela.valor = linha.Cells(3).Value
                                parcela.valorReceber = linha.Cells(3).Value
                                parcela.situacao = "00" ' n pagou

                                If parcela.dataVecimento.CompareTo(Today) < 0 Then
                                    valido = False
                                    MessageBox.Show("Data anterior a data atual", "", MessageBoxButtons.OK)
                                End If
                                parcelas.Add(parcela)
                            End If
                        Next
                        If valido Then
                            crediario.Incluir(dadosCrediario, parcelas)
                            ImprimirCrediario()

                            pago = True
                            Me.Close()
                        End If
                    End If

                    'ExibirInformacoes()
                End If
            End If

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
        Dim regras As rCliente
        Dim filtro As dCliente
        Dim cliente As String

        impressao = New ncComum.Impressao
        etiqueta = New EtiquetaCrediario()
        colecaoEtiqueta = New ColecaoEtiqueta()
        colecaoLinha = New ColecaoLinha()
        colecaoParcelas = New ColecaoParcelas()
        crediario = New dCrediario()

        crediario.controle = Me.txtControle.Text
        crediario.DataVenda = Today
        crediario.SaldoDevedor = Me.lblFalta.Text
        crediario.ValorTotal = Me.lblTotal.Text
        crediario.clienteId = Me.txtCliente.Tag
        regras = New rCliente()
        cliente = regras.ConsultarPorCID(crediario.clienteId).nome

        For Each linhaGrid As DataGridViewRow In dgvCrediario.Rows
            '-- parcelas
            parcela = New dParcelas()
            parcela.codigoBarras = linhaGrid.Cells(0).Value
            parcela.dataEmissao = linhaGrid.Cells(1).Value
            parcela.dataVecimento = linhaGrid.Cells(2).Value
            parcela.valor = linhaGrid.Cells(3).Value
            parcela.valorReceber = linhaGrid.Cells(3).Value
            parcela.valorPago = 0
            colecaoParcelas.Add(parcela)
        Next

        ' Tamanho Etiqueta
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TamanhoEtiqueta)
        If Not IsNothing(dadosParametro) Then
            tamanhoEtiqueta = dadosParametro.valor
        Else
            tamanhoEtiqueta = ""
        End If

        colecaoEtiqueta = etiqueta.MontarEtiqueta(colecaoParcelas, crediario, cliente, mdiPrincipal.gLoja.nomeFantasia, tamanhoEtiqueta)

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

        Dim acessoGerente As fAcessoGerente

        Try
            dadosCliente = New ncDados.nsCliente.dClienteFinanceiro()
            consultaCliente = New ncRegras.nsCliente.rClienteFinanceiro()

            dadosCliente.cliente_cid = txtCliente.Tag
            dadosFinanceiro = consultaCliente.fConsultar(dadosCliente)

            If Not IsNothing(dadosFinanceiro) Then
                If dadosFinanceiro.Count > 0 Then
                    txtLimite.Text = CDec(dadosFinanceiro(0).limite).ToString("N")
                    txtDisponivel.Text = CDec(dadosFinanceiro(0).limite - CDec(lblTotal.Text)).ToString("N")
                End If
            Else
                MessageBox.Show("Cliente sem limite cadastrado.")
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

            If CDec(txtDisponivel.Text) < 0 Then
                If MessageBox.Show("Limite do Cliente Insuficiente, deseja inserir limite?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    acessoGerente = New fAcessoGerente()
                    acessoGerente.ShowDialog()
                    If acessoGerente.gRetorno Then
                        txtLimite.Text = InputBox("O limite atual é: " & CDec(dadosFinanceiro(0).limite).ToString("N") & " Digite o novo limite:")
                        txtDisponivel.Text = (CDec(txtLimite.Text) - CDec(lblTotal.Text)).ToString("N")
                        If CDec(txtDisponivel.Text) < 0 Then
                            MessageBox.Show("Limite Insuficiente!")
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

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub fCrediarioForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If CDec(txtDisponivel.Text) < 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                IncluirItem()
            Case Keys.F2
                ExcluirItem()
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If CDec(lblFalta.Text) <> 0D Then
                    MessageBox.Show("Faltam: " & lblFalta.Text)
                Else
                    Salvar()
                End If
        End Select
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        If CDec(lblFalta.Text) <> 0D Then
            MessageBox.Show("Faltam: " & lblFalta.Text)
        Else
            Salvar()
        End If
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
            dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(0).Value = CStr(dgvCrediario.Rows(dgvCrediario.Rows.Count - 2).Cells(0).Value + 1).PadLeft(12, "0"c)
            dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(1).Value = Today.ToString("dd/MM/yyyy")
            dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(2).Value = CDate(dgvCrediario.Rows(dgvCrediario.Rows.Count - 2).Cells(2).Value).AddMonths(1).ToString("dd/MM/yyyy")
            dgvCrediario.Rows(dgvCrediario.Rows.Count - 1).Cells(3).Value = lblFalta.Text

            dgvCrediario.Refresh()
        End If


    End Sub

    Private Sub ExcluirItem()
        If dgvCrediario.Rows.Count > 0 Then
            dgvCrediario.Rows.RemoveAt(dgvCrediario.CurrentRow.Index)
        End If
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
End Class