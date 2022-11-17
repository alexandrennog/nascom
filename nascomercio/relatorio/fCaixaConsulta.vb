Imports ncDados.nsProduto
Imports ncDados.nsVenda
Imports ncRegras.nsProduto
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncRegras.nsCaracteristica
Imports ncDados.nsCaracteristica
Imports ncComum.nsConstantes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog
Imports ncComum.DFW

Public Class fCaixaConsulta

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Fechar()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub fCaixa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CarregarComboCondicao()
        Me.lblMsg.Tag = False
        Me.lblLoja.Text = mdiPrincipal.gLoja.nomeFantasia

        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
            lblTitulo.Text = "CAIXA"
        Else
            lblTitulo.Text = "VENDAS"
            txtControle.ReadOnly = True
            txtControle.TabStop = False
        End If

        If System.Configuration.ConfigurationManager.AppSettings("FISCAL") <> "NAO" Then
            btnExcluirUltima.Visible = True
            btnExcluir.Visible = False
        Else
            btnExcluirUltima.Visible = False
            btnExcluir.Visible = True
        End If

    End Sub

    Private Sub CarregarComboCondicao()
        Dim regras As ncRegras.nsCondicao.rCondicao
        Dim colecao As ncDados.nsCondicao.ColecaoCondicao

        Try

            cboCondicao.DataSource = Nothing
            cboCondicao.Items.Clear()

            regras = New ncRegras.nsCondicao.rCondicao()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New ncDados.nsCondicao.dCondicao())

                cboCondicao.ValueMember = "cid"
                cboCondicao.DisplayMember = "nome"
                cboCondicao.DataSource = colecao
                cboCondicao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Condição.")

        End Try
    End Sub

    Private Sub ExcluirVenda()
        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim objVendaProduto As New ncRegras.nsVenda.rVendaProduto
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim regrasItem As rProdutoItem

        If dtgProdutos.Rows.Count <= 0 OrElse _
            MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

            If txtControle.Text.Equals("") Then
                MessageBox.Show("Digite o número da venda para excluir!", "Nascomercio")
            Else
                Dim acessoGerente As New fAcessoGerente()
                acessoGerente.ShowDialog()
                If acessoGerente.gRetorno Then

                    Try
                        ' retorna estoque
                        For Each linha As DataGridViewRow In dtgProdutos.Rows
                            regrasItem = New rProdutoItem()
                            regrasItem.AlterarEstoque(linha.Cells(0).Value, linha.Cells(4).Value)
                        Next

                        If CDec(lblTroca.Text) > 0 Then
                            ' exclui troca e seus produtos
                            dadosVenda.controle = txtControle.Text

                            objVendaProduto.ExcluirControleTroca(dadosVenda.controle)
                            objVenda.ExcluirVale(dadosVenda)
                            If dtgProdutos.Rows.Count > 0 Then
                                MessageBox.Show("Troca excluída: " & txtControle.Text)
                                GravarLog(mdiPrincipal.gUsuario.usuario, "Troca excluída: " & txtControle.Text & " - Valor:" & lblTotal.Text)
                            End If
                        Else
                            ' exclui venda e seus produtos
                            dadosVenda.controle = txtControle.Text

                            objVendaProduto.ExcluirControle(dadosVenda.controle)
                            objVenda.Excluir(dadosVenda)
                            If dtgProdutos.Rows.Count > 0 Then
                                MessageBox.Show("Venda excluída: " & txtControle.Text)
                                GravarLog(mdiPrincipal.gUsuario.usuario, "Venda excluída: " & txtControle.Text & " - Valor:" & lblTotal.Text)
                            End If
                        End If

                        limpaCampos()
                    Catch nex As ExcecaoNascomercio

                        MessageBox.Show(nex.Message)

                    Catch ex As Exception

                        MessageBox.Show("Erro ao excluir venda.")

                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub dtgProdutos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProdutos.CellValueChanged
        If e.ColumnIndex = 4 And dtgProdutos.Rows.Count > 0 Then
            CalculaTotais()
        End If
    End Sub

    Sub CalculaTotais()
        Dim itemVenda As New ncDados.nsVenda.dVendaProduto

        lblVendas.Text = 0.ToString("N")
        lblSubtotal.Text = 0.ToString("N")
        lblTotal.Text = 0.ToString("N")

        If lblMsg.Text = "TROCA" Then
            lblTroca.Text = 0.ToString("N")
        ElseIf lblMsg.Text = "DEVOLUÇÃO" Then
            lblDefeitos.Text = 0.ToString("N")
        End If

        If Me.txtControle.Text <> "F10 Nova Venda" And txtControle.Text <> "" Then
            ' Exclui histórico
            itemVenda.controle = txtControle.Text

            For Each linha As DataGridViewRow In dtgProdutos.Rows
                ' Inclui itens pre-venda
                itemVenda.codigobarras = linha.Cells(0).Value
                itemVenda.descricao = linha.Cells(1).Value
                itemVenda.itemId = linha.Cells(1).Tag
                itemVenda.referencia = linha.Cells(2).Value
                itemVenda.produtoId = linha.Cells(2).Tag
                itemVenda.valor = CDec(linha.Cells(3).Value).ToString("N")
                itemVenda.quantidade = CDec(linha.Cells(4).Value).ToString("N")
                linha.Cells(5).Value = CDec(linha.Cells(3).Value * linha.Cells(4).Value).ToString("N")
                If lblMsg.Text = "TROCA" Then
                    ' troca
                    lblTroca.Text = CDec(CDec(lblTroca.Text) + linha.Cells(5).Value).ToString("N")
                    ' Entra estoque
                ElseIf lblMsg.Text = "DEVOLUÇÃO" Then
                    ' devolucao
                    lblDefeitos.Text = CDec(CDec(lblDefeitos.Text) + linha.Cells(5).Value).ToString("N")
                    ' Sai Estoque
                Else
                    ' Calcula totais
                    lblVendas.Text = CDec(CDec(lblVendas.Text) + linha.Cells(5).Value).ToString("N")
                    lblSubtotal.Text = CDec(CDec(lblSubtotal.Text) + linha.Cells(5).Value).ToString("N")
                    ' Sai Estoque
                End If

            Next
            lblTotal.Text = CDec(CDec(lblSubtotal.Text) - CDec(txtDesconto.Text)).ToString("N")
        End If
    End Sub


    Private Sub CarregaPagamento()
        Dim janela As fPagamentoConsulta
        Dim produto As dVendaProduto
        Dim controle As Integer
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim dadosVenda As ncDados.nsVenda.dVenda
        Dim objVenda As ncRegras.nsVenda.rVenda

        janela = New fPagamentoConsulta()

        janela.lstFita.Items.Add("Produto               Qtd  Valor     Subtotal   ")
        janela.lstFita.Items.Add("------------------------------------------------")
        '                        "123456789012345678901234567890123456789012345678")

        For Each linha As DataGridViewRow In dtgProdutos.Rows
            janela.lstFita.Items.Add(linha.Cells(1).Value.ToString().PadRight(22) & _
               linha.Cells(4).Value.ToString().PadRight(5) & _
               CDec(linha.Cells(3).Value).ToString("N").PadRight(10) & _
               CDec(linha.Cells(5).Value).ToString("N").PadRight(11))
            produto = New dVendaProduto
            produto.itemId = linha.Cells(1).Tag
            produto.produtoId = linha.Cells(2).Tag
            produto.quantidade = linha.Cells(4).Value
            produto.valor = linha.Cells(3).Value
            janela.dadosVendaProdutos.Add(produto)
        Next

        janela.lblFalta.Text = Me.lblSubtotal.Text
        janela.lblTotal.Text = Me.lblTotal.Text
        janela.lblControle.Text = Me.txtControle.Text
        janela.txtCliente.Text = Me.txtCliente.Text
        janela.txtCliente.Tag = Me.txtCliente.Tag
        janela.txtCliente.ForeColor = Me.txtCliente.ForeColor
        janela.txtCliente.BackColor = Me.txtCliente.BackColor
        janela.lblEmissao.Text = Me.lblEmissao.Text
        janela.lblVendedor.Text = Me.lblVendedor.Text
        janela.lblVendedor.Tag = Me.lblVendedor.Tag
        janela.lblLoja.Text = Me.lblLoja.Text
        janela.condicao = Me.cboCondicao.Text
        janela.parcelas = Me.txtParcelas.Text
        janela.desconto = Me.txtDesconto.Text
        janela.txtTroca.Text = Me.lblTroca.Text
        janela.txtVale.Text = Me.lblVale.Text
        janela.txtDefeitos.Text = Me.lblDefeitos.Text

        If txtControle.Tag <> 0 Then
            If Integer.TryParse(Me.txtControle.Tag, controle) Then
                dadosVenda = New ncDados.nsVenda.dVenda()
                dadosVenda.controle = controle
                Try
                    dtgProdutos.Rows.Clear()
                    objVenda = New ncRegras.nsVenda.rVenda()
                    If CDec(lblTroca.Text) > 0 Then
                        vendas = objVenda.ConsultarTroca(dadosVenda)
                    Else
                        vendas = objVenda.Consultar(dadosVenda)
                    End If
                    If Not IsNothing(vendas) Then
                        For Each dadosVenda In vendas
                            janela.txtDinheiro.Text = dadosVenda.Dinheiro.ToString("N")
                            janela.txtCheque.Text = dadosVenda.Cheque.ToString("N")
                            janela.txtChequePre.Text = dadosVenda.ChequePre.ToString("N")
                            janela.txtCartaoDebito.Text = dadosVenda.CartaoDebito.ToString("N")
                            janela.txtCartaoCredito.Text = dadosVenda.CartaoCredito.ToString("N")
                            janela.crediario = dadosVenda.Crediario.ToString("N")
                        Next
                    End If
                Catch ex As Exception

                End Try
            End If
        End If

        limpaCampos()

        ' Abre janela de pagamento
        janela.StartPosition = FormStartPosition.CenterParent
        janela.ShowDialog()

    End Sub

    Private Sub limpaCampos()
        Me.dtgProdutos.Rows.Clear()
        Me.txtControle.Text = ""
        Me.txtControle.Tag = 0
        Me.lblVendas.Text = 0.ToString("N")
        Me.lblSubtotal.Text = 0.ToString("N")
        Me.lblTotal.Text = 0.ToString("N")
        Me.txtDesconto.Text = 0.ToString("N")
        Me.txtDesconto.Text = 0.ToString("N")
        Me.lblTroca.Text = 0.ToString("N")
        Me.lblDefeitos.Text = 0.ToString("N")
        Me.lblVale.Text = 0.ToString("N")
        Me.txtCliente.Text = "ao consumidor"
        Me.txtCliente.Tag = 0
        Me.txtCliente.ForeColor = Color.Black
        Me.txtCliente.BackColor = Color.White
        Me.cboCondicao.SelectedIndex = 1
    End Sub


    Private Sub FinalizaVenda()
        If lblMsg.Text = "TROCA" Or lblMsg.Text = "DEVOLUÇÃO" Then
            If Me.Tag = True Then
                Me.lblMsg.Text = "VENDA DIRETA"
            Else
                Me.lblMsg.Text = "PRÉ VENDA"
            End If
            Me.dtgProdutos.Rows.Clear()
        Else
            If dtgProdutos.Rows.Count > 0 Then
                CalculaTotais()
                CarregaPagamento()
            Else
                If Me.Tag = True Then
                    Me.lblMsg.Text = "VENDA DIRETA"
                Else
                    Me.lblMsg.Text = "PRÉ VENDA"
                End If
                ' MessageBox.Show("Nenhum produto vendido")
            End If
        End If
    End Sub

    Private Sub fCaixa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, txtParcelas.KeyDown, txtDesconto.KeyDown, cboCondicao.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Fechar()
            Case Keys.F7
                ExcluirVenda()
            Case Keys.F10
                btoSalvar.Focus()
                Application.DoEvents()
                FinalizaVenda()
        End Select
    End Sub


    Private Sub ConsultarVenda()

        Dim controle As Integer
        Dim linha As DataGridViewRow
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim trocas As ncDados.nsVenda.ColecaoVenda
        Dim vendasProdutos As ncDados.nsVenda.ColecaoVendaProduto
        ' Venda
        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim objVendaProduto As New ncRegras.nsVenda.rVendaProduto
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim dadosVendaProduto As New ncDados.nsVenda.dVendaProduto
        ' Cliente
        Dim dadosCliente As New ncDados.nsCliente.dCliente
        Dim cliente As New ncRegras.nsCliente.rCliente
        Dim dadosClienteFin As New ncDados.nsCliente.dClienteFinanceiro
        Dim dadosClienteFinCol As New ncDados.nsCliente.ColecaoClienteFinanceiro
        Dim clienteFin As New ncRegras.nsCliente.rClienteFinanceiro
        ' Vendedor
        Dim dadosVendedor As New ncDados.nsUsuario.dUsuario
        Dim vendedor As New ncRegras.nsUsuario.rUsuario
        ' Condição 
        Dim dadosCondicao As New ncDados.nsCondicao.dCondicao
        Dim condicao As New ncRegras.nsCondicao.rCondicao



        If Integer.TryParse(Me.txtControle.Text, controle) Then
            dadosVenda.controle = controle
            dadosVendaProduto.controle = controle
            vendasProdutos = objVendaProduto.Consultar(dadosVendaProduto)
            Try
                dtgProdutos.Rows.Clear()
                trocas = objVenda.ConsultarTroca(dadosVenda)
                vendas = objVenda.Consultar(dadosVenda)
                If Not IsNothing(trocas) And Not IsNothing(vendas) Then
                    If MessageBox.Show("Existe uma troca com o mesmo número de controle deseja consultar?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        vendas = trocas
                        vendasProdutos = objVendaProduto.ConsultarTroca(dadosVendaProduto)
                    End If
                End If
                If Not IsNothing(vendas) Then
                    For Each dadosVenda In vendas
                        Me.txtControle.Tag = dadosVenda.controle
                        ' Cliente
                        dadosCliente = cliente.ConsultarPorCID(dadosVenda.clienteId)
                        Me.txtCliente.Text = dadosCliente.nome
                        Me.txtCliente.Tag = dadosCliente.cid
                        dadosClienteFin.cliente_cid = dadosVenda.clienteId
                        dadosClienteFinCol = clienteFin.Consultar(dadosClienteFin)
                        If Not IsNothing(dadosClienteFinCol) Then
                            Me.txtCliente.ForeColor = IIf(dadosClienteFinCol(0).situacaoCrediario = "N", Color.Red, Color.Black)
                            Me.txtCliente.BackColor = IIf(dadosClienteFinCol(0).situacaoCrediario = "N", Color.Salmon, Color.White)
                        End If
                        lblEmissao.Text = dadosVenda.Data.ToString("dd/MM/yyyy HH:mm")
                        ' Vendedor
                        If dadosVenda.Vendedor <> "" Then
                            Me.lblVendedor.Text = dadosVenda.Vendedor
                            Me.lblVendedor.Tag = dadosVenda.usuarioId
                        End If
                        ' Outros
                        Me.lblTroca.Text = dadosVenda.Troca
                        Me.lblDefeitos.Text = dadosVenda.Defeito
                        Me.lblVale.Text = dadosVenda.Vale
                        dadosCondicao = condicao.Consultar(dadosVenda.Condicao)
                        If Not IsNothing(dadosCondicao) Then
                            Me.cboCondicao.Text = dadosCondicao.nome
                        End If
                        Me.txtParcelas.Text = dadosVenda.Parcelas
                        Me.txtDesconto.Text = dadosVenda.Desconto
                        Me.lblOS.Text = dadosVenda.ordemServicoId
                    Next

                    If Not IsNothing(vendasProdutos) Then
                        For Each dadosVendaProduto In vendasProdutos
                            linha = dtgProdutos.Rows(dtgProdutos.Rows.Add())
                            ' Inclui linha 
                            linha.Cells(0).Value = dadosVendaProduto.codigobarras
                            linha.Cells(1).Value = dadosVendaProduto.descricao
                            linha.Cells(1).Tag = dadosVendaProduto.itemId
                            linha.Cells(2).Value = dadosVendaProduto.referencia
                            linha.Cells(2).Tag = dadosVendaProduto.produtoId
                            linha.Cells(3).Value = dadosVendaProduto.valor.ToString("N")
                            linha.Cells(4).Value = dadosVendaProduto.quantidade.ToString("N")
                            linha.Cells(5).Value = CDec(dadosVendaProduto.valor * dadosVendaProduto.quantidade).ToString("N")
                        Next
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub txtControle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtControle.KeyDown
        If e.KeyCode = Keys.Enter Then
            ConsultarVenda()
        Else
            fCaixa_KeyDown(sender, e)
        End If
    End Sub

    Private Sub Fechar()
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
                mdiPrincipal.FecharTela()
            Else
                mdiPrincipal.FecharTelaLogin()
            End If
        End If
    End Sub

    Private Sub dtgProdutos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgProdutos.KeyDown
        fCaixa_KeyDown(sender, e)
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        FinalizaVenda()
    End Sub

    Private Sub txtControle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtControle.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub txtQuantidade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        fCaixa_KeyDown(sender, e)
    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        ExcluirVenda()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirUltima.Click
        If System.Configuration.ConfigurationManager.AppSettings("FISCAL") <> "NAO" Then
            Me.txtControle.Text = (mdiPrincipal.RetornaNumeroControle() - 1).ToString()
            Application.DoEvents()


            If MessageBox.Show("Deseja Excluir último cupom fiscal? " & txtControle.Text, "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                ExcluirVenda()

                If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
                    Declaracoes.iRetorno = Declaracoes.iCFCancelar_ECF_Daruma()
                    If Declaracoes.iRetorno <> 1 Then
                        MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                    End If
                ElseIf System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "SAT" Then
                    Declaracoes.iRetorno = Declaracoes.tCFeCancelar_SAT_Daruma()
                    If Declaracoes.iRetorno <> 1 Then
                        MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub txtControle_TextChanged(sender As Object, e As EventArgs) Handles txtControle.TextChanged
        ConsultarVenda()
    End Sub
End Class