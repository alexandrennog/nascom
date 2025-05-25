Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncComum.nsConstantes
Imports ncDados.nsCrediario
Imports ncComum.nsLog.cLog
Imports ncRegras.nsCliente
Imports ncDados.nsCliente
Imports ncRegras.nsParametro
Imports ncDados.nsParametro

Public Class fCrediarioPagamento
    Public formularioModal As New Form
    Private tela As Boolean = True
    Private _excVenda As Int16

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        SendKeys.Flush()
        Me.Close()
    End Sub

    Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ConsultarCliente()
            Case Keys.F7
                Me.btoEtiqueta_Click(sender, e)
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If dgvCrediario.Rows.Count > 0 Then

                    If CDec(lblTotal.Text) <= 0D Then
                        MessageBox.Show("Selecione uma Parcela não baixada!")
                        Exit Sub
                    End If

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
        Dim selecionado As Boolean = False
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
                If MessageBox.Show("Confirma gravação das informações?", "Financeiro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                    If existe = True Then
                        For Each linha As DataGridViewRow In dgvCrediario.Rows
                            parcelas = New ncDados.nsCrediario.ColecaoParcelas
                            parcelasPagamento = New ncDados.nsCrediario.ColecaoParcelas
                            dadosCrediario = New ncDados.nsCrediario.dCrediario

                            ' Consulta crediario
                            dadosCrediario.cid = linha.Cells(0).Tag
                            crediarios = consulta.Consultar(dadosCrediario)
                            dadosCrediario = crediarios(0)

                            If linha.Cells("selecao").Value = True Then
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
                                    crediario.GravarPagamentoParcelas(parcelasPagamento)

                                    ' Dados do crediário
                                    dadosCrediario.usuarioId = lblVendedor.Tag
                                    dadosCrediario.clienteId = txtCliente.Tag
                                    dadosCrediario.ValorPago = dadosCrediario.ValorPago + parcela.valorPago
                                    If (dadosCrediario.SaldoDevedor - parcela.valorPago) > 0.009 Then
                                        dadosCrediario.SaldoDevedor = dadosCrediario.SaldoDevedor - parcela.valorPago
                                    Else
                                        dadosCrediario.SaldoDevedor = 0
                                    End If

                                    crediario.Alterar(dadosCrediario, parcelas)

                                End If
                                selecionado = True
                            End If
                        Next
                    End If

                    If selecionado Then

                        ' Inclui venda para contabilizar no fechamento
                        dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
                        dadosVenda.Caixa = mdiPrincipal.gUsuario.usuario
                        dadosVenda.clienteId = Me.txtCliente.Tag
                        dadosVenda.Data = Now
                        dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
                        dadosVenda.Vendedor = Me.lblVendedor.Text
                        dadosVenda.CrediarioPagamento = (recebido - CDec(lblTroco.Text)).ToString("N")
                        dadosVenda.Total = recebido.ToString("N")
                        dadosVenda.Pix = txtPix.Text
                        GravarLog(mdiPrincipal.gUsuario.usuario, "Pagamento de Crediário. Vendedor: " & Me.lblVendedor.Text)
                        regraVenda.IncluirCrediarioPagamento(dadosVenda)

                        lblRecebido.Text = recebido.ToString("N")

                        ExibirInformacoes()

                        Imprime()

                        Me.Close()
                    Else
                        MessageBox.Show("Selecione ao menos uma parcela.", "Financeiro")
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na gravação dos dados de Cliente.")

        End Try

    End Sub

    Private Sub LimparCampos()
        txtLimite.Text = String.Empty
        txtDisponivel.Text = String.Empty
        Me.txtIdCliente.Text = ""
        lblRecebido.Text = 0.ToString("N")
        lblFalta.Text = 0.ToString("N")
        lblTroco.Text = 0.ToString("N")
        lblTotal.Text = 0.ToString("N")
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
        Dim qtdImpressao As Integer = 1

        objImpressao = New ncComum.Impressao()

        If MessageBox.Show("Deseja imprimir comprovante?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                ' Imprime segunda via
                If System.Configuration.ConfigurationManager.AppSettings("SEGUNDA_VIA") = "SIM" Then
                    qtdImpressao = 2
                End If

                For i As Integer = 1 To qtdImpressao
                    objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

                    'objImpressao.Write("123456789012345678901234567890123456789012345678")
                    For Each linha As DataGridViewRow In dgvCrediario.Rows
                        If linha.Cells("selecao").Value = True Then
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
                        End If
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

                Next

            Catch ex As Exception
                MessageBox.Show("Erro ao imprimir: " & ex.Message)
            End Try

        Else
            MessageBox.Show("Pagamento em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle: " & txtControle.Text)
        End If
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        If dgvCrediario.Rows.Count > 0 Then
            If CDec(lblTotal.Text) <= 0D Then
                MessageBox.Show("Parcela já foi paga!")
            Else
                If CDec(lblRecebido.Text) > 0 Then
                    Salvar()
                Else
                    MessageBox.Show("Informe o valor pago!")
                End If
            End If
        End If
    End Sub

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs)



    End Sub
    Private Sub HabilitarGridParaEdicao(ByVal excVenda As Int16)
        dgvCrediario.ReadOnly = False
        For Each column As DataGridViewColumn In dgvCrediario.Columns
            column.[ReadOnly] = (excVenda <> 1)
        Next

        dgvCrediario.Columns(0).ReadOnly = False

    End Sub
    Private Sub FiltrarCliente()
        Dim filtro As dCliente
        Dim clientes As ColecaoCliente
        Dim regras As rCliente
        filtro = New dCliente
        clientes = New ColecaoCliente

        If txtIdCliente.Text = "" Then
            MessageBox.Show("Informe um código")
            Exit Sub
        End If

        'fClienteLista.filtro = filtro

        filtro.cid = cFuncoes.TratarInteiro(txtIdCliente.Text)
        regras = New rCliente

        clientes = regras.Consultar(filtro)

        If clientes Is Nothing Then

            MessageBox.Show("Não existe cliente com esse código!")
            txtIdCliente.Focus()
            txtIdCliente.Select()
            txtIdCliente.Text = ""

            txtCliente.Focus()
            txtCliente.Select()
            txtCliente.Text = ""

            Exit Sub
        End If

        filtro = clientes.Item(0)

        If filtro.nome <> "" Then
            Me.txtCliente.Text = filtro.nome
            If filtro.cpf <> "" Then
                Me.txtCliente.Text += ", CPF: " & filtro.cpf
            End If
            Me.txtCliente.Tag = filtro.cid
            If filtro.situacao = "N" Then
                Me.txtCliente.ForeColor = Color.Red
                txtCliente.BackColor = Color.Salmon
            ElseIf filtro.situacao = "O" Then
                Me.txtCliente.ForeColor = Color.Orange
                txtCliente.BackColor = Color.Yellow
            Else
                Me.txtCliente.ForeColor = Color.Black
                txtCliente.BackColor = Color.White
            End If
        End If

        If filtro.nome <> "" Then
            Me.txtCliente.Text = filtro.nome
            Me.txtCliente.Tag = filtro.cid
            txtCliente_Leave(Nothing, Nothing)
        End If

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
        Dim consultacliente As New ncRegras.nsCliente.rCliente
        Dim cliente As New ncDados.nsCliente.dCliente

        If txtCodigo.Text <> "" And CDec(txtDinheiro.Text) <= 0.0 Then

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
                    txtIdCliente.Text = crediarios(0).clienteId
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

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub


    Private Sub txtDinheiro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDinheiro.Leave
        If txtDinheiro.Text <> "" Then
            Dim valorRecebidoTotal As Decimal
            valorRecebidoTotal = CDec(txtDinheiro.Text) + CDec(txtPix.Text)

            lblRecebido.Text = CDec(valorRecebidoTotal).ToString("N")
            If (CDec(lblTotal.Text) - CDec(lblRecebido.Text)) < 0 Then
                lblTroco.Text = Math.Abs(CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
                lblFalta.Text = 0.ToString("N")
            Else
                lblTroco.Text = 0.ToString("N")
                lblFalta.Text = (CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
            End If
        End If

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown

        Select Case e.KeyCode
            Case Keys.F7
                Me.btoEtiqueta_Click(sender, e)
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                txtCodigo_Leave(sender, e)
        End Select
    End Sub

    Private Sub txtDinheiro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDinheiro.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub btoEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiqueta.Click
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
        Dim cliente As String

        If Me.txtControle.Text.Equals("") Then
            MessageBox.Show("Selecione as parcelas para impressão!")
        Else
            impressao = New ncComum.Impressao
            etiqueta = New EtiquetaCrediario()
            colecaoEtiqueta = New ColecaoEtiqueta()
            colecaoLinha = New ColecaoLinha()
            colecaoParcelas = New ColecaoParcelas()
            crediario = New dCrediario()

            crediario.controle = Me.txtControle.Text
            crediario.DataVenda = Today.Date
            crediario.SaldoDevedor = Me.lblFalta.Text
            crediario.ValorTotal = Me.lblTotal.Text
            crediario.clienteId = Me.txtCliente.Tag
            regras = New rCliente()
            cliente = regras.ConsultarPorCID(crediario.clienteId).nome

            For Each linhaGrid As DataGridViewRow In dgvCrediario.Rows
                '-- parcelas
                parcela = New dParcelas()
                parcela.codigoBarras = linhaGrid.Cells(1).Value
                parcela.dataEmissao = linhaGrid.Cells(2).Value
                parcela.dataVecimento = linhaGrid.Cells(3).Value
                parcela.valor = linhaGrid.Cells(4).Value
                parcela.valorReceber = linhaGrid.Cells(5).Value
                parcela.valorPago = linhaGrid.Cells(6).Value
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
        End If

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
    Private Sub valorParcelasSelecioadas()
        'lblTotal.Text = 0.ToString("N")

        'For Each linha As DataGridViewRow In dgvCrediario.Rows

        '    If linha.DataGridView.  = True Then
        '        chk.Value = chk.FalseValue
        '    Else
        '        chk.Value = chk.TrueValue
        '    End If

        '    If linha.Cells("selecao").Value = True Then
        '        lblTotal.Text = (CDec(lblTotal.Text) + CDec(linha.Cells(5).Value)).ToString("N")
        '    End If
        'Next

        'txtDinheiro_Leave(Nothing, Nothing)
    End Sub

    Private Sub valorParcelas()
        lblTotal.Text = 0.ToString("N")

        For Each linha As DataGridViewRow In dgvCrediario.Rows
            If linha.Cells("selecao").Value = True Then
                lblTotal.Text = (CDec(lblTotal.Text) + CDec(linha.Cells(5).Value)).ToString("N")
            End If
        Next

        txtDinheiro_Leave(Nothing, Nothing)
    End Sub

    Private Sub ConsultarCliente()
        Dim formCliente As New fClienteLista

        formCliente.filtro = New ncDados.nsCliente.dCliente()
        formCliente.ShowDialog()
        If formCliente.filtro.nome <> "" Then
            Me.txtCliente.Text = formCliente.filtro.nome
            Me.txtCliente.Tag = formCliente.filtro.cid
            txtIdCliente.Text = formCliente.filtro.cid
            txtCliente_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvCrediario_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCrediario.CellValueChanged, dgvCrediario.CellClick
        If dgvCrediario.Columns(e.ColumnIndex).Name = "selecao" Then
            valorParcelas()
        End If
    End Sub

    Private Sub btoIncluirCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirCliente.Click
        ConsultarCliente()
    End Sub

    Private Sub dgvCrediario_Click(sender As Object, e As EventArgs) Handles dgvCrediario.Click
        'valorParcelasSelecioadas()
    End Sub

    'Private Sub btnPix_Click(sender As Object, e As EventArgs)




    'End Sub

    Private Sub AbrirTelaModal()
        tela = False

        formularioModal.MdiParent = Me
        formularioModal.Show()
        formularioModal.BringToFront()
    End Sub

    Private Sub FecharTelaModal()
        If Not formularioModal Is Nothing Then
            formularioModal.Close()
            formularioModal = Nothing
        End If

        tela = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnPix_Click(sender As Object, e As EventArgs) Handles btnPix.Click
        If Me.lblTotal.Text = "0,00" Or Me.lblTotal.Text = "0.00" Then
            MessageBox.Show("É preciso informar um valor a pagar.", "Pagar com PIX!")
            Exit Sub
        End If

        Dim formPix As fPix
        formPix = New fPix()
        formPix.txtValorPIX.Text = Me.lblTotal.Text
        formPix.ShowDialog()
    End Sub

    Private Sub txtPix_Leave(sender As Object, e As EventArgs) Handles txtPix.Leave
        If txtDinheiro.Text <> "" Then
            Dim valorRecebidoTotal As Decimal
            valorRecebidoTotal = CDec(txtDinheiro.Text) + CDec(txtPix.Text)

            lblRecebido.Text = CDec(valorRecebidoTotal).ToString("N")
            If (CDec(lblTotal.Text) - CDec(lblRecebido.Text)) < 0 Then
                lblTroco.Text = Math.Abs(CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
                lblFalta.Text = 0.ToString("N")
            Else
                lblTroco.Text = 0.ToString("N")
                lblFalta.Text = (CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
            End If
        End If
    End Sub

    Private Sub dgvCrediario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCrediario.CellDoubleClick

    End Sub

    Private Sub dgvCrediario_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvCrediario.CellBeginEdit

    End Sub

    Private Sub txtIdCliente_MouseDown(sender As Object, e As MouseEventArgs) Handles txtIdCliente.MouseDown


    End Sub

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            FiltrarCliente()
        End If
    End Sub

    Private Sub txtIdCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyUp
        If txtIdCliente.Text = "" Then
            txtCliente.Focus()
            txtCliente.Select()
            txtCliente.Text = ""
        End If
    End Sub

    Private Sub txtIdCliente_Leave(sender As Object, e As EventArgs) Handles txtIdCliente.Leave
        'FiltrarCliente()
    End Sub

    Private Sub txtIdCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIdCliente.TextChanged

    End Sub

    Private Sub fCrediarioPagamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro

        LimparCampos()
        ExibirInformacoes()

        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ExcVenda)
        If Not IsNothing(dadosParametro) Then
            _excVenda = dadosParametro.valor
            HabilitarGridParaEdicao(_excVenda)
        End If
    End Sub
End Class