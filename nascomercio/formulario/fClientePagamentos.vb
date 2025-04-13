Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncComum.nsConstantes
Imports ncDados.nsCrediario
Imports ncComum.nsLog.cLog

Public Class fClientePagamentos

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim formCliente As New fClienteLista

        Select Case e.KeyCode
            Case Keys.F1
                formCliente.filtro = New ncDados.nsCliente.dCliente()
                formCliente.ShowDialog()
                If formCliente.filtro.nome <> "" Then
                    Me.txtCliente.Text = formCliente.filtro.nome
                    Me.txtCliente.Tag = formCliente.filtro.cid
                    txtCliente_Leave(sender, e)
                End If
            Case Keys.F7
                Me.btoEtiqueta_Click(sender, e)
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If dgvCrediario.Rows.Count > 0 Then
                    If CDec(lblRecebido.Text) > 0 Then
                        Salvar()
                    End If
                End If
        End Select
    End Sub

    Private Sub Salvar()

        Dim recebido As Decimal
        Dim valido As Boolean = True
        Dim existe As Boolean = True
        Dim crediario As New ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As ncDados.nsCrediario.dCrediario
        Dim parcelas As ncDados.nsCrediario.ColecaoParcelas
        Dim parcelasPagamento As ncDados.nsCrediario.ColecaoParcelas
        Dim parcela As ncDados.nsCrediario.dParcelas
        Dim parcelaPagamento As ncDados.nsCrediario.dParcelas
        Dim consulta As New ncRegras.nsCrediario.rCrediario
        Dim crediarios As New ncDados.nsCrediario.ColecaoCrediario
        Dim regraVenda As New ncRegras.nsVenda.rVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda

        Try
            recebido = CDec(lblRecebido.Text)

            If valido = True Then

                If existe = True Then
                    For Each linha As DataGridViewRow In dgvCrediario.Rows
                        parcelas = New ncDados.nsCrediario.ColecaoParcelas
                        parcelasPagamento = New ncDados.nsCrediario.ColecaoParcelas
                        dadosCrediario = New ncDados.nsCrediario.dCrediario

                        ' Consulta crediario
                        dadosCrediario.cid = linha.Cells(0).Tag
                        crediarios = consulta.Consultar(dadosCrediario)
                        dadosCrediario = crediarios(0)

                        If linha.Cells(3).Value <> "" Then
                            parcela = New ncDados.nsCrediario.dParcelas()
                            parcelaPagamento = New ncDados.nsCrediario.dParcelas()
                            parcela.crediarioId = linha.Cells(0).Tag
                            parcela.cid = linha.Cells(1).Tag
                            parcelaPagamento.cid = parcela.cid
                            parcela.codigoBarras = linha.Cells(1).Value
                            parcela.dataEmissao = linha.Cells(2).Value
                            parcela.dataVecimento = linha.Cells(3).Value
                            parcela.valor = linha.Cells(4).Value
                            ' valor pago maior que parcela
                            If (CDec(lblRecebido.Text) + 0.009) > CDec(linha.Cells(5).Value) Then
                                parcela.valorPago = CDec(linha.Cells(5).Value)
                                parcelaPagamento.valorPago = parcela.valorPago
                                lblRecebido.Text = CDec(lblRecebido.Text) - parcela.valorPago
                                parcela.valorReceber = 0
                                parcela.situacao = "01" ' pagou
                            Else
                                parcela.valorPago = CDec(lblRecebido.Text)
                                parcelaPagamento.valorPago = parcela.valorPago
                                ' se ainda tem valor a receber
                                If (CDec(linha.Cells(5).Value) - parcela.valorPago) > 0.009 Then
                                    If parcela.dataVecimento.CompareTo(Today.Date) < 0 Then
                                        parcela.dataVecimento = Today.Date
                                    End If
                                    parcela.valorReceber = CDec(linha.Cells(5).Value) - CDec(lblRecebido.Text)
                                    parcela.situacao = "00" ' n pagou
                                Else
                                    parcela.valorReceber = 0
                                    parcela.situacao = "01" ' pagou
                                End If
                            End If
                            parcela.dataPagamento = Today.Date
                            parcelaPagamento.dataPagamento = parcela.dataPagamento
                            parcelas.Add(parcela)

                            ' Grava histórico de pagamento da parcela
                            parcelaPagamento.diasAtraso = linha.Cells(7).Value
                            parcelasPagamento.Add(parcelaPagamento)

                            ' Dados do crediário
                            dadosCrediario.usuarioId = lblVendedor.Tag
                            dadosCrediario.clienteId = txtCliente.Tag
                            dadosCrediario.ValorPago = dadosCrediario.ValorPago + parcela.valorPago
                            If (dadosCrediario.SaldoDevedor - parcela.valorPago) > 0.009 Then
                                dadosCrediario.SaldoDevedor = dadosCrediario.SaldoDevedor - parcela.valorPago
                            Else
                                dadosCrediario.SaldoDevedor = 0
                            End If

                        End If
                    Next
                End If

                ' Inclui venda para contabilizar no fechamento
                dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
                dadosVenda.Caixa = mdiPrincipal.gUsuario.usuario
                dadosVenda.clienteId = Me.txtCliente.Tag
                dadosVenda.Data = Now
                dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
                dadosVenda.Vendedor = Me.lblVendedor.Text
                dadosVenda.CrediarioPagamento = (recebido - CDec(lblTroco.Text)).ToString("N")
                dadosVenda.Total = recebido.ToString("N")

                lblRecebido.Text = recebido.ToString("N")

                ExibirInformacoes()

                Imprime()

                Me.Close()
            Else
                MessageBox.Show("Selecione ao menos uma parcela.", "Financeiro")
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na gravação dos dados de Cliente.")

        End Try

    End Sub

    Private Sub ExibirInformacoes()
        Dim dadosCliente As ncDados.nsCliente.dClienteFinanceiro
        Dim consultaCliente As ncRegras.nsCliente.rClienteFinanceiro
        Dim dadosFinanceiro As ncDados.nsCliente.ColecaoClienteFinanceiro

        Try
            dadosCliente = New ncDados.nsCliente.dClienteFinanceiro()
            consultaCliente = New ncRegras.nsCliente.rClienteFinanceiro()

            dadosCliente.cliente_cid = txtCliente.Tag
            dadosFinanceiro = consultaCliente.fConsultar(dadosCliente)

            If Not IsNothing(dadosFinanceiro) Then
                If dadosFinanceiro.Count > 0 Then
                    txtLimite.Text = CDec(dadosFinanceiro(0).limite).ToString("N")
                    txtDisponivel.Text = CDec(dadosFinanceiro(0).limite).ToString("N")
                End If
            Else
                MessageBox.Show("Cliente sem limite cadastrado.")
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try
    End Sub

    Private Sub Imprime()

        Dim objImpressao As ncComum.Impressao

        objImpressao = New ncComum.Impressao()

        If MessageBox.Show("Deseja imprimir comprovante?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

                'objImpressao.Write("123456789012345678901234567890123456789012345678")
                For Each linha As DataGridViewRow In dgvCrediario.Rows
                    objImpressao.Write("COMPROVANTE DE PAGAMENTO")
                    objImpressao.Write("Loja:" & mdiPrincipal.gLoja.nomeFantasia)
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("Pagamento em:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle:" & txtControle.Text)
                    objImpressao.Write("Cliente:" & txtCliente.Text)
                    objImpressao.Write(vbCrLf)
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("Codigo      Data Emissao   Vencimento   Valor   ")
                    objImpressao.Write(ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(linha.Cells(1).Value.ToString() & "      " & linha.Cells(2).Value.ToString() & "     " & linha.Cells(3).Value.ToString() & "   " & linha.Cells(4).Value.ToString()))
                    objImpressao.Write(vbCrLf)
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("VALOR PARCELA : " & linha.Cells(4).Value.ToString())
                    If CDec(linha.Cells(5).Value) > CDec(linha.Cells(4).Value) Then
                        objImpressao.Write("VALOR JUROS : " & (CDec(linha.Cells(5).Value) - CDec(linha.Cells(4).Value)).ToString("N"))
                    End If
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                Next
                objImpressao.Write("------------------------------------------------")
                objImpressao.Write("TOTAL    : " & lblTotal.Text)
                objImpressao.Write("RECEBIDO : " & lblRecebido.Text)
                objImpressao.Write("TROCO    : " & lblTroco.Text)
                objImpressao.Write("FALTA    : " & lblFalta.Text)
                objImpressao.Write("------------------------------------------------")
                objImpressao.Write("Agradecemos a preferencia - Volte sempre")
                objImpressao.Write("")
                objImpressao.Write("")
                objImpressao.Write("")
                objImpressao.Write("")
                objImpressao.Write("")
                objImpressao.Write("")
                objImpressao.EndWrite()

            Catch ex As Exception
                MessageBox.Show("Erro ao imprimir: " & ex.Message)
            End Try

        Else
            MessageBox.Show("Pagamento em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle: " & txtControle.Text)
        End If
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvCrediario.Rows.Count > 0 Then
            If CDec(lblTotal.Text) <= 0D Then
                MessageBox.Show("Selecione uma Parcela!")
            Else
                If CDec(lblRecebido.Text) > 0 Then
                    Salvar()
                Else
                    MessageBox.Show("Informe o valor pago!")
                End If
            End If
        End If
    End Sub

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ExibirInformacoes()

    End Sub


    Private Sub txtCodigo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave

        Dim juros As Decimal
        Dim dias As Integer
        Dim diasTolerancia As Integer
        Dim cobrarTolerancia As String = ""
        Dim linha As DataGridViewRow
        Dim regrasCrediario As ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As ncDados.nsCrediario.dCrediario
        Dim dadosListaCrediario As ncDados.nsCrediario.ColecaoCrediario
        Dim dadosParametro As ncDados.nsParametro.dParametro

        Dim regraParametro As New ncRegras.nsParametro.rParametro
        Dim consulta As New ncRegras.nsCrediario.rCrediario
        Dim crediario As New ncDados.nsCrediario.dCrediario
        Dim crediarios As New ncDados.nsCrediario.ColecaoCrediario
        Dim parcela As New ncDados.nsCrediario.dParcelas
        Dim parcelas As New ncDados.nsCrediario.ColecaoParcelas
        Dim parcelasPagamentos As New ncDados.nsCrediario.ColecaoParcelas
        Dim consultacliente As New ncRegras.nsCliente.rCliente
        Dim cliente As New ncDados.nsCliente.dCliente

        If txtCodigo.Text <> "" Then

            parcela.codigoBarras = txtCodigo.Text

            Try
                parcelas = consulta.ConsultarParcelas(parcela)

                If IsNothing(parcelas) Then
                    MessageBox.Show("Código não encontrado!")
                Else
                    crediario.cid = parcelas(0).crediarioId
                    crediarios = consulta.Consultar(crediario)

                    txtControle.Text = crediarios(0).controle
                    txtControle.Tag = crediarios(0).cid

                    cliente = consultacliente.ConsultarPorCID(crediarios(0).clienteId)

                    txtCliente.Text = cliente.nome
                    txtCliente.Tag = cliente.cid

                    ExibirInformacoes()

                    dgvCrediario.Rows.Clear()

                    ' Juros
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.JurosDiario)
                    If Not IsNothing(dadosParametro) Then
                        juros = CDec(dadosParametro.valor)
                    End If

                    ' Dias Tolerancia
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DiasTolerancia)
                    If Not IsNothing(dadosParametro) Then
                        diasTolerancia = CInt(dadosParametro.valor)
                    End If

                    ' Cobrar Tolerancia
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CobrarJurosTolerancia)
                    If Not IsNothing(dadosParametro) Then
                        If Not String.IsNullOrEmpty(dadosParametro.valor) Then
                            cobrarTolerancia = dadosParametro.valor.Trim()
                        End If
                    End If

                    For Each parcela In parcelas
                        linha = dgvCrediario.Rows(dgvCrediario.Rows.Add())
                        linha.Cells(0).Tag = parcela.crediarioId
                        linha.Cells(1).Tag = parcela.cid
                        linha.Cells(1).Value = parcela.codigoBarras
                        linha.Cells(2).Value = parcela.dataEmissao.ToString("dd/MM/yyyy")
                        linha.Cells(3).Value = parcela.dataVecimento.ToString("dd/MM/yyyy")
                        linha.Cells(4).Value = parcela.valor.ToString("N")
                        ' Verifica vencimento e cobra juros
                        If parcela.dataVecimento.AddDays(diasTolerancia).CompareTo(Today.Date) < 0 Then
                            linha.Cells(3).Style.ForeColor = Color.Red
                            linha.Cells(5).Style.ForeColor = Color.Red
                            If cobrarTolerancia.Equals("") Or cobrarTolerancia.Equals("Não") Then
                                dias = DateDiff(DateInterval.Day, parcela.dataVecimento, Today.Date) - diasTolerancia
                            Else
                                dias = DateDiff(DateInterval.Day, parcela.dataVecimento, Today.Date)
                            End If
                            linha.Cells(7).Value = dias
                            linha.Cells(5).Value = (parcela.valorReceber * ((juros * dias) + 1)).ToString("N")
                        Else
                            linha.Cells(3).Style.ForeColor = Color.Black
                            linha.Cells(5).Style.ForeColor = Color.Black
                            linha.Cells(5).Value = parcela.valorReceber.ToString("N")
                        End If
                        linha.Cells(6).Value = parcela.valorPago.ToString("N")
                        'lblTotal.Text = linha.Cells(5).Value
                        lblFalta.Text = linha.Cells(5).Value
                    Next

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

                    ' Consulta pagamentos
                    parcelasPagamentos = consulta.ConsultarParcelasPagamentos(parcela)
                    If Not IsNothing(parcelasPagamentos) Then
                        For Each parcela In parcelasPagamentos
                            linha = dgvPagamentos.Rows(dgvPagamentos.Rows.Add())
                            linha.Cells(1).Value = parcela.cid
                            linha.Cells(2).Value = parcela.dataPagamento.Value.ToString("dd/MM/yyyy")
                            linha.Cells(3).Value = parcela.valorPago.ToString("N")
                            linha.Cells(4).Value = parcela.diasAtraso
                        Next
                        txtDinheiro.Text = parcela.valorPago.ToString("N")
                        txtDinheiro_Leave(Nothing, Nothing)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        Dim formCliente As New fClienteLista

        Select Case e.KeyCode
            Case Keys.F7
                Me.btoEtiqueta_Click(sender, e)
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                txtCodigo_Leave(sender, e)
        End Select
    End Sub

    Private Sub txtDinheiro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub btoEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiqueta.Click
        Salvar()
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.Leave

        Dim juros As Decimal
        Dim dias As Integer
        Dim diasTolerancia As Integer
        Dim cobrarTolerancia As String = ""
        Dim linha As DataGridViewRow
        Dim regrasCrediario As ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As ncDados.nsCrediario.dCrediario
        Dim dadosListaCrediario As ncDados.nsCrediario.ColecaoCrediario
        Dim dadosParametro As ncDados.nsParametro.dParametro

        Dim regraParametro As New ncRegras.nsParametro.rParametro
        Dim consulta As New ncRegras.nsCrediario.rCrediario
        Dim crediario As New ncDados.nsCrediario.dCrediario
        Dim crediarios As New ncDados.nsCrediario.ColecaoCrediario
        Dim parcela As New ncDados.nsCrediario.dParcelas
        Dim parcelas As New ncDados.nsCrediario.ColecaoParcelas
        Dim consultacliente As New ncRegras.nsCliente.rCliente
        Dim cliente As New ncDados.nsCliente.dCliente

        If txtCliente.Text <> "" And txtCliente.Text <> "Consumidor" Then

            dgvCrediario.Rows.Clear()

            ' Consulta dados de crediário
            regrasCrediario = New ncRegras.nsCrediario.rCrediario()
            dadosCrediario = New ncDados.nsCrediario.dCrediario()

            dadosCrediario.clienteId = Me.txtCliente.Tag
            'dadosCrediario.SaldoDevedor = 1
            If dadosCrediario.clienteId <> 0 Then
                dadosListaCrediario = regrasCrediario.Consultar(dadosCrediario)
            End If

            Try

                If Not IsNothing(dadosListaCrediario) Then

                    ' Juros
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.JurosDiario)
                    If Not IsNothing(dadosParametro) Then
                        juros = CDec(dadosParametro.valor)
                    End If

                    ' Dias Tolerancia
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.DiasTolerancia)
                    If Not IsNothing(dadosParametro) Then
                        diasTolerancia = CInt(dadosParametro.valor)
                    End If

                    ' Cobrar Tolerancia
                    dadosParametro = regraParametro.Consultar(cConstantes.Parametros.CobrarJurosTolerancia)
                    If Not IsNothing(dadosParametro) Then
                        If Not String.IsNullOrEmpty(dadosParametro.valor) Then
                            cobrarTolerancia = dadosParametro.valor.Trim()
                        End If
                    End If

                    For Each dadosCrediario In dadosListaCrediario
                        parcela = New ncDados.nsCrediario.dParcelas()

                        txtDisponivel.Text = CDec(CDec(txtDisponivel.Text) - dadosCrediario.SaldoDevedor).ToString("N")

                        parcela.crediarioId = dadosCrediario.cid

                        parcelas = consulta.ConsultarParcelas(parcela)

                        If Not IsNothing(parcelas) Then
                            crediario.cid = parcelas(0).crediarioId
                            crediarios = consulta.Consultar(crediario)

                            txtControle.Text = crediarios(0).controle
                            txtControle.Tag = crediarios(0).cid

                            cliente = consultacliente.ConsultarPorCID(crediarios(0).clienteId)

                            txtCliente.Text = cliente.nome
                            txtCliente.Tag = cliente.cid

                            ExibirInformacoes()

                            For Each parcela In parcelas
                                If parcela.valorReceber > 0 Then
                                    linha = dgvCrediario.Rows(dgvCrediario.Rows.Add())
                                    linha.Cells(0).Tag = parcela.crediarioId
                                    linha.Cells(1).Tag = parcela.cid
                                    linha.Cells(1).Value = parcela.codigoBarras
                                    linha.Cells(2).Value = parcela.dataEmissao.ToString("dd/MM/yyyy")
                                    linha.Cells(3).Value = parcela.dataVecimento.ToString("dd/MM/yyyy")
                                    linha.Cells(4).Value = parcela.valor.ToString("N")
                                    ' Verifica vencimento e cobra juros
                                    If parcela.dataVecimento.AddDays(diasTolerancia).CompareTo(Today.Date) < 0 Then
                                        If parcela.valorReceber > 0 Then
                                            linha.Cells(1).Style.ForeColor = Color.Red
                                            linha.Cells(2).Style.ForeColor = Color.Red
                                            linha.Cells(3).Style.ForeColor = Color.Red
                                            linha.Cells(4).Style.ForeColor = Color.Red
                                            linha.Cells(5).Style.ForeColor = Color.Red
                                            linha.Cells(6).Style.ForeColor = Color.Red
                                            If cobrarTolerancia.Equals("") Or cobrarTolerancia.Equals("Não") Then
                                                dias = DateDiff(DateInterval.Day, parcela.dataVecimento, Today.Date) - diasTolerancia
                                            Else
                                                dias = DateDiff(DateInterval.Day, parcela.dataVecimento, Today.Date)
                                            End If
                                            linha.Cells(7).Value = dias
                                            linha.Cells(5).Value = (parcela.valorReceber * ((juros * dias) + 1)).ToString("N")
                                        Else
                                            linha.Cells(1).Style.ForeColor = Color.Green
                                            linha.Cells(2).Style.ForeColor = Color.Green
                                            linha.Cells(3).Style.ForeColor = Color.Green
                                            linha.Cells(4).Style.ForeColor = Color.Green
                                            linha.Cells(5).Style.ForeColor = Color.Green
                                            linha.Cells(6).Style.ForeColor = Color.Green
                                        End If
                                    Else
                                        linha.Cells(1).Style.ForeColor = Color.Black
                                        linha.Cells(2).Style.ForeColor = Color.Black
                                        linha.Cells(3).Style.ForeColor = Color.Black
                                        linha.Cells(4).Style.ForeColor = Color.Black
                                        linha.Cells(5).Style.ForeColor = Color.Black
                                        linha.Cells(6).Style.ForeColor = Color.Black
                                        linha.Cells(5).Value = parcela.valorReceber.ToString("N")
                                    End If
                                    linha.Cells(6).Value = parcela.valorPago.ToString("N")
                                    'lblTotal.Text = linha.Cells(5).Value
                                End If
                            Next
                        End If
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

        If lblTotal.Text.Trim() = "" Then
            lblTotal.Text = 0.ToString("N")
        End If

    End Sub

    Private Sub txtDinheiro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDinheiro.Leave
        If txtDinheiro.Text <> "" Then
            lblRecebido.Text = CDec(txtDinheiro.Text).ToString("N")
            lblTroco.Text = 0.ToString("N")
            If (CDec(lblTotal.Text) - CDec(lblRecebido.Text)) < 0 Then
                lblFalta.Text = 0.ToString("N")
            Else
                lblFalta.Text = (CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
            End If
        End If
    End Sub

    Private Sub valorParcelas()
        lblTotal.Text = 0.ToString("N")
        For Each linha As DataGridViewRow In dgvCrediario.Rows
            lblTotal.Text = (CDec(lblTotal.Text) + CDec(linha.Cells(5).Value)).ToString("N")
        Next
        txtDinheiro_Leave(Nothing, Nothing)
    End Sub


    Private Sub fClientePagamentos_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtCodigo_Leave(Nothing, Nothing)
        valorParcelas()
    End Sub

End Class