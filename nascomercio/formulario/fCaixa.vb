Imports System.Text
Imports ncDados.nsProduto
Imports ncDados.nsVenda
Imports ncRegras.nsProduto
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncRegras.nsCaracteristica
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaixa
Imports ncDados.nsCaixa
Imports ncComum.nsConstantes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog
Imports ncComum.DFW
Imports ncComum.nsEmail
Imports ncDados
Imports ncRegras.nsUsuario
Imports ncDados.nsUsuario
Imports ncRegras.nsUsuarioPerfil
Imports ncDados.nsUsuarioPerfil
Imports System.Configuration
Imports ncRegras
Imports ncDados.nsCliente
Imports ncComum.nsFuncoes
Imports ncRegras.nsCliente
Imports System.Linq

Public Class fCaixa

    Private _excVenda As Int16
    Private _lojaGrande As Boolean
    Private dadosTroca As New ncDados.nsVenda.ColecaoVendaProduto

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        FecharTela()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub fCaixa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro

        Me.txtQuantidade.Visible = False
        Me.lblQtd.Visible = False

        Me.CarregarComboCondicao()
        Me.CarregarComboVendedor()
        Me.lblMsg.Tag = False

        Try

            ' Quantidade no caixa
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.QuantidadeCaixa)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = "Sim" Then
                    Me.txtQuantidade.Visible = True
                    Me.lblQtd.Visible = True
                End If
            End If

            ' Loja com Terminal
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.LojaGrande)
            If Not IsNothing(dadosParametro) Then
                If dadosParametro.valor = "Sim" Then
                    _lojaGrande = True
                Else
                    _lojaGrande = False
                End If
            End If

            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ExcVenda)
            If Not IsNothing(dadosParametro) Then
                _excVenda = dadosParametro.valor
                HabilitarGridParaEdicao(_excVenda)
            End If

            If System.Configuration.ConfigurationManager.AppSettings("ORDEM_SERVIÇO") = "SIM" Then
                lblOS.Visible = True
                lblOS1.Visible = True
                btnOS.Visible = True
            Else
                lblOS.Visible = False
                lblOS1.Visible = False
                btnOS.Visible = False
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos parâmetros.")

        End Try

        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
            Dim regraCaixa As New rCaixa()
            Dim dadosCaixa As New dCaixa()
            Dim consultaCaixa As New ColecaoCaixa()

            dadosCaixa.nome = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
            dadosCaixa.usuario = mdiPrincipal.gUsuario.usuario
            consultaCaixa = regraCaixa.Consultar(dadosCaixa)
            ' Caixa Aberto ?
            If Not consultaCaixa Is Nothing Then
                If consultaCaixa(0).situacao = "ABERTO" Then
                    lblAbrirFechar.Text = "Fechar Caixa [F12]"
                Else
                    lblAbrirFechar.Text = "Abrir Caixa [F12]"
                End If
            Else
                lblAbrirFechar.Text = "Abrir Caixa [F12]"
            End If

            lblTitulo.Text = "CAIXA"

            If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
                'Declaracoes.eDefinirProduto_Daruma("ECF")
                Declaracoes.iRetorno = Declaracoes.eBuscarPortaVelocidade_ECF_Daruma()
                If Declaracoes.iRetorno <> 1 Then
                    MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                End If
            ElseIf System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "SAT" Then
                Declaracoes.eDefinirProduto_Daruma("SAT")
                Declaracoes.iRetorno = Declaracoes.eBuscarPortaVelocidade_DUAL_DarumaFramework()
                If Declaracoes.iRetorno <> 1 Then
                    MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                End If
                'Declaracoes.iRetorno = Declaracoes.rVerificarComunicacao_SAT_Daruma()
                'If Declaracoes.iRetorno <> 1 Then
                'MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                'End If
            End If


        ElseIf System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "VENDAS" Then
            lblTitulo.Text = "VENDAS"
            txtControle.ReadOnly = True
            txtControle.TabStop = False
        Else
            lblTitulo.Text = "ORÇAMENTO"
        End If

        If System.Configuration.ConfigurationManager.AppSettings("FISCAL") <> "NAO" Then
            lblTitulo.ForeColor = Color.Red
            lblMsg.ForeColor = Color.Red
        End If

        NovaVenda()
    End Sub
    Private Sub HabilitarGridParaEdicao(ByVal excVenda As Int16)
        dtgProdutos.ReadOnly = (excVenda <> 1)
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

    Private Sub CarregarComboVendedor()
        Dim regras As ncRegras.nsUsuario.rUsuario
        Dim colecao As ncDados.nsUsuario.ColecaoUsuario

        Try

            cboVendedor.DataSource = Nothing
            cboVendedor.Items.Clear()

            regras = New ncRegras.nsUsuario.rUsuario()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New ncDados.nsUsuario.dUsuario())

                cboVendedor.ValueMember = "cid"
                cboVendedor.DisplayMember = "usuario"
                cboVendedor.DataSource = colecao
                cboVendedor.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados do Vendedor.")

        End Try
    End Sub


    Private Sub NovaVenda()

        If CDec(lblTroca.Text) > 0.0 Or CDec(lblDefeitos.Text) > 0.0 Then
            MessageBox.Show("Finalize o processo de troca ou devolução!")
        Else
            Me.limpaCampos()

            Me.txtQuantidade.Text = "1"
            Me.lblEmissao.Text = Today.ToString("dd/MM/yyyy")
            Me.cboVendedor.Text = mdiPrincipal.gUsuario.usuario
            Me.cboVendedor.Tag = mdiPrincipal.gUsuario.cid
            Me.lblLoja.Text = mdiPrincipal.gLoja.nomeFantasia
            Me.txtCliente.Tag = 1

            Me.txtControle.Text = mdiPrincipal.RetornaNumeroControle().ToString()

            If Me.Tag = True Then
                Me.lblTitulo.Text = "CAIXA"

                If lblAbrirFechar.Text.Equals("Abrir Caixa [F12]") Then
                    If MessageBox.Show("Caixa fechado, efetuar abertura?", "Nascomercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        AbrirCaixa()
                    Else
                        Me.txtControle.Text = "F10 Nova Venda"
                        Exit Sub
                    End If
                End If

                If Me.lblMsg.Text = "TROCA" Or Me.lblMsg.Text = "DEVOLUÇÃO" Then
                    Me.txtControle.Text = (mdiPrincipal.RetornaNumeroControle() + 10).ToString()
                    Me.txtCodigo.Focus()
                Else
                    If _lojaGrande Then
                        Me.txtControle.Text = ""
                        Me.lblMsg.Text = "VENDA DIRETA"
                        Me.txtControle.Focus()
                    Else
                        Me.ConsultarPreVenda()
                        Me.lblMsg.Text = "VENDA DIRETA"
                        Me.txtCodigo.Focus()
                    End If
                End If
            Else
                If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "VENDAS" Then
                    Me.lblMsg.Text = "PRÉ VENDA"
                    Me.lblTitulo.Text = "VENDAS"
                    If Me.lblMsg.Tag = False Then
                        GravaPreVenda()
                    End If
                Else
                    Me.lblMsg.Text = "ORÇAMENTO"
                    Me.lblTitulo.Text = "ORÇAMENTO"
                End If
                Me.txtCodigo.Focus()
            End If
        End If

    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave

        If Me.txtControle.Text <> "F10 Nova Venda" And Me.txtControle.Text <> "" Then
            If txtCodigo.Text.Trim() <> "" Then
                InserirProdutos(Me.txtCodigo.Text.Trim())
            Else
                'MessageBox.Show("Selecione um produto")
                Exit Sub
            End If
        Else
            MessageBox.Show("Tecle F10 para nova venda ou Digite o número da venda.")
            Exit Sub
        End If


    End Sub


    Private Sub dtgProdutos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProdutos.CellValueChanged
        If (e.ColumnIndex = 4 Or e.ColumnIndex = 3) And dtgProdutos.Rows.Count > 0 Then
            CalculaTotais()
        End If
    End Sub

    Sub InserirProdutos(ByVal codigo As String)
        Dim retorno As ColecaoProduto
        Dim linha As DataGridViewRow
        Dim itemID As Integer
        Dim regrasProduto As rProduto
        Dim dadosProduto As dProduto
        Dim regrasItem As rProdutoItem
        Dim dadosItem As dProdutoItem
        Dim retornoItem As ColecaoProdutoItem = Nothing
        Dim estoque As Decimal
        Dim regraC As rCaracteristica
        Dim dadosC As dCaracteristica

        regrasProduto = New rProduto
        dadosProduto = New dProduto
        regrasItem = New rProdutoItem
        dadosItem = New dProdutoItem

        regraC = New rCaracteristica()
        dadosC = regraC.ConsultarPorCodigo("codigobarras")

        dadosItem.valor = codigo
        dadosItem.caracteristicas_cid = dadosC.cid

        Try

            retornoItem = regrasItem.Consultar(dadosItem)

            If Not IsNothing(retornoItem) Then
                If lblMsg.Text = "TROCA" Or lblMsg.Text = "DEVOLUÇÃO" Then
                    estoque = 1
                Else
                    estoque = regrasItem.fConsultarEstoque(codigo)
                End If
                If estoque >= CDec(IIf(txtQuantidade.Visible, txtQuantidade.Text, 1)) Then
                    dadosProduto.cid = retornoItem.Item(0).produtos_cid
                    itemID = retornoItem.Item(0).item
                    retorno = regrasProduto.Consultar(dadosProduto)

                    If Not IsNothing(retorno) Then
                        linha = dtgProdutos.Rows(dtgProdutos.Rows.Add())

                        'If lblMsg.Text = "TROCA" Then
                        'regrasItem.AlterarEstoque(codigo, CInt(IIf(txtQuantidade.Visible, txtQuantidade.Text, 1)))
                        'ElseIf lblMsg.Text = "DEVOLUÇÃO" Then
                        '  'nada
                        'Else
                        '  regrasItem.AlterarEstoque(codigo, -(CInt(IIf(txtQuantidade.Visible, txtQuantidade.Text, 1))))
                        'End If

                        For Each dadosProduto In retorno
                            ' Inclui linha 
                            linha.Cells(0).Value = Me.txtCodigo.Text.Trim()
                            linha.Cells(1).Value = dadosProduto.descricao
                            linha.Cells(1).Tag = itemID
                            linha.Cells(2).Value = dadosProduto.referencia
                            linha.Cells(2).Tag = dadosProduto.cid
                            linha.Cells(3).Value = CDec(dadosProduto.valorVenda).ToString("N")
                            linha.Cells(3).Tag = dadosProduto.aliquota
                            linha.Cells(4).Value = CDec(IIf(txtQuantidade.Visible, txtQuantidade.Text, 1)).ToString("N")
                            linha.Cells(5).Value = CDec(dadosProduto.valorVenda).ToString("N")

                            If Not lblMsg.Text = "TROCA" And Not lblMsg.Text = "DEVOLUÇÃO" Then
                                If dadosProduto.estoqueMinimo.HasValue Then
                                    If dadosProduto.estoqueMinimo.Value > (estoque - CDec(IIf(txtQuantidade.Visible, txtQuantidade.Text, 1))) Then
                                        MessageBox.Show("Estoque mínimo: " & dadosProduto.estoqueMinimo.Value.ToString)
                                    End If
                                End If
                            End If
                        Next
                        'dtgProdutos.Rows.Add(linha)
                        Me.txtCodigo.Text = ""
                        CalculaTotais()
                        Me.txtCodigo.Focus()
                    Else
                        MessageBox.Show("Produto não econtrado")
                        txtCodigo.Text = ""
                    End If
                Else
                    MessageBox.Show("Produto sem estoque")
                    txtCodigo.Text = ""
                End If
            Else
                MessageBox.Show("Código não econtrado")
                txtCodigo.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub CalculaTotais()
        Dim itemVenda As New ncDados.nsVenda.dVendaProduto
        Dim preVenda As New ncRegras.nsVenda.rPreVendaProduto

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
            preVenda.Excluir(itemVenda)

            For Each linha As DataGridViewRow In dtgProdutos.Rows
                ' Inclui itens pre-venda
                itemVenda.codigobarras = linha.Cells(0).Value
                itemVenda.descricao = linha.Cells(1).Value
                itemVenda.itemId = linha.Cells(1).Tag
                itemVenda.referencia = linha.Cells(2).Value
                itemVenda.produtoId = linha.Cells(2).Tag
                itemVenda.valor = CDec(linha.Cells(3).Value).ToString("N")
                itemVenda.quantidade = CDec(linha.Cells(4).Value)
                preVenda.Incluir(itemVenda)
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
            If lblMsg.Text = "TROCA" Then
                lblTroca.Text = CDec(CDec(lblTroca.Text) - CDec(txtDesconto.Text)).ToString("N")
            ElseIf lblMsg.Text = "DEVOLUÇÃO" Then
                lblDefeitos.Text = CDec(CDec(lblDefeitos.Text) - CDec(txtDesconto.Text)).ToString("N")
            Else
                lblTotal.Text = CDec(CDec(lblSubtotal.Text) - CDec(txtDesconto.Text)).ToString("N")
            End If
        End If
    End Sub

    Private Sub CarregaPagamento()
        Dim janela As fPagamento
        Dim produto As dVendaProduto
        Dim controle As Integer
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim dadosVenda As ncDados.nsVenda.dVenda
        Dim preVenda As ncRegras.nsVenda.rPreVenda
        Dim tamanhoProd As Integer
        janela = New fPagamento()

        If System.Configuration.ConfigurationManager.AppSettings("CUPOM").Substring(0, 3) = "LAZ" Then
            janela.lstFita.Items.Add("Produto                                 Qtd  Valor     Subtotal   ")
            janela.lstFita.Items.Add("------------------------------------------------------------------")
            '                        "123456789012345678901234567890123456789012345678901234567801234567")
            tamanhoProd = 40
        Else
            janela.lstFita.Items.Add("Produto               Qtd  Valor     Subtotal   ")
            janela.lstFita.Items.Add("------------------------------------------------")
            '                        "123456789012345678901234567890123456789012345678")
            tamanhoProd = 22
        End If
        For Each linha As DataGridViewRow In dtgProdutos.Rows
            janela.lstFita.Items.Add(linha.Cells(1).Value.ToString().PadRight(tamanhoProd).Substring(0, tamanhoProd) &
               linha.Cells(4).Value.ToString().PadRight(5) &
               CDec(linha.Cells(3).Value).ToString("N").PadRight(10) &
               CDec(linha.Cells(5).Value).ToString("N").PadRight(11))
            produto = New dVendaProduto
            produto.itemId = linha.Cells(1).Tag
            produto.descricao = linha.Cells(1).Value
            produto.produtoId = linha.Cells(2).Tag
            produto.quantidade = linha.Cells(4).Value
            produto.valor = linha.Cells(3).Value
            produto.aliquota = linha.Cells(3).Tag
            produto.codigobarras = linha.Cells(0).Value
            janela.dadosVendaProdutos.Add(produto)
        Next
        janela.dadosTroca = dadosTroca
        janela.lblFalta.Text = Me.lblSubtotal.Text
        janela.lblTotal.Text = Me.lblTotal.Text
        janela.lblControle.Text = Me.txtControle.Text
        janela.lblControle.Tag = Me.lblOS.Text
        janela.txtCliente.Text = Me.txtCliente.Text
        janela.txtCliente.Tag = Me.txtCliente.Tag
        janela.txtCliente.ForeColor = Me.txtCliente.ForeColor
        janela.txtCliente.BackColor = Me.txtCliente.BackColor
        janela.lblEmissao.Text = Me.lblEmissao.Text
        janela.lblVendedor.Text = Me.cboVendedor.Text
        janela.lblVendedor.Tag = Me.cboVendedor.Tag
        janela.lblLoja.Text = Me.lblLoja.Text
        janela.condicao = Me.cboCondicao.Text
        janela.parcelas = Me.txtParcelas.Text
        janela.desconto = Me.txtDesconto.Text
        janela.txtTroca.Text = Me.lblTroca.Text
        janela.txtVale.Text = Me.lblVale.Text
        janela.txtDefeitos.Text = Me.lblDefeitos.Text
        janela.txtVendas.Text = Me.lblVendas.Text


        If txtControle.Tag <> 0 Then
            If Integer.TryParse(Me.txtControle.Tag, controle) Then
                dadosVenda = New ncDados.nsVenda.dVenda()
                dadosVenda.controle = controle
                Try
                    dtgProdutos.Rows.Clear()
                    preVenda = New ncRegras.nsVenda.rPreVenda()
                    vendas = preVenda.Consultar(dadosVenda)
                    If Not IsNothing(vendas) Then
                        For Each dadosVenda In vendas
                            janela.txtDinheiro.Text = dadosVenda.Dinheiro.ToString("N")
                            janela.txtPix.Text = dadosVenda.Pix.ToString("N")
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

    Private Sub CarregaPagamentoPreVenda()
        Dim janela As fPreVenda
        Dim produto As dVendaProduto
        Dim tamanhoProd As Integer

        janela = New fPreVenda()

        janela.lblFalta.Text = Me.lblSubtotal.Text
        janela.lblTotal.Text = Me.lblTotal.Text
        janela.txtDesconto.Text = Me.txtDesconto.Text
        janela.lblControle.Text = Me.txtControle.Text
        janela.lblControle.Tag = Me.lblOS.Text
        janela.txtCliente.Text = Me.txtCliente.Text
        janela.txtidCliente.Text = Me.txtCliente.Tag
        janela.txtCliente.Tag = Me.txtCliente.Tag
        janela.lblEmissao.Text = Me.lblEmissao.Text
        janela.lblVendedor.Text = Me.cboVendedor.Text
        janela.lblVendedor.Tag = Me.cboVendedor.Tag
        janela.lblLoja.Text = Me.lblLoja.Text
        janela.txtParcelas.Text = Me.txtParcelas.Text
        janela.cboCondicao.Text = Me.cboCondicao.Text
        janela.txtTroca.Text = Me.lblTroca.Text
        janela.txtVale.Text = Me.lblVale.Text
        janela.txtDefeitos.Text = Me.lblDefeitos.Text

        If System.Configuration.ConfigurationManager.AppSettings("CUPOM").Substring(0, 3) = "LAZ" Then
            janela.lstFita.Items.Add("Produto                                 Qtd  Valor     Subtotal   ")
            janela.lstFita.Items.Add("------------------------------------------------------------------")
            '                        "123456789012345678901234567890123456789012345678901234567801234567")
            tamanhoProd = 40
        Else
            janela.lstFita.Items.Add("Produto               Qtd  Valor     Subtotal   ")
            janela.lstFita.Items.Add("------------------------------------------------")
            '                        "123456789012345678901234567890123456789012345678")
            tamanhoProd = 22
        End If

        For Each linha As DataGridViewRow In dtgProdutos.Rows
            janela.lstFita.Items.Add(linha.Cells(1).Value.ToString().PadRight(tamanhoProd).Substring(0, tamanhoProd) &
               linha.Cells(4).Value.ToString().PadRight(5) &
               CDec(linha.Cells(3).Value).ToString("N").PadRight(10) &
               CDec(linha.Cells(5).Value).ToString("N").PadRight(11))
            produto = New dVendaProduto
            produto.itemId = linha.Cells(1).Tag
            produto.produtoId = linha.Cells(2).Tag
            produto.quantidade = linha.Cells(4).Value
            produto.valor = linha.Cells(3).Value
            produto.aliquota = linha.Cells(3).Tag
            produto.codigobarras = linha.Cells(0).Value
            janela.dadosVendaProdutos.Add(produto)
        Next

        limpaCampos()

        ' Abre janela de pré-venda
        janela.StartPosition = FormStartPosition.CenterParent
        janela.ShowDialog()

    End Sub

    Private Sub GravaPreVenda()
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim novaVenda As New ncRegras.nsVenda.rPreVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim dadosVenda2 As New ncDados.nsVenda.dVenda
        Dim controle As Integer

        Me.lblMsg.Tag = True

        Try

            ' Inclui venda
            dadosVenda.Vendedor = Me.cboVendedor.Text
            dadosVenda.usuarioId = Me.cboVendedor.Tag
            dadosVenda.clienteId = Me.txtCliente.Tag
            dadosVenda.Data = Now
            dadosVenda.Parcelas = Me.txtParcelas.Text
            dadosVenda.Desconto = Me.txtDesconto.Text
            dadosVenda.Condicao = Me.cboCondicao.SelectedValue
            dadosVenda.Total = Me.lblTotal.Text
            dadosVenda.Troca = Me.lblTroca.Text
            dadosVenda.Vale = Me.lblVale.Text
            dadosVenda.Defeito = Me.lblDefeitos.Text
            dadosVenda.controle = Me.txtControle.Text
            dadosVenda.ordemServicoId = Me.lblOS.Text

            If Not Me.txtControle.Tag Is Nothing Then
                vendas = novaVenda.Consultar(dadosVenda)
                If Not IsNothing(vendas) Then
                    For Each dadosVenda2 In vendas
                        dadosVenda.Dinheiro = dadosVenda2.Dinheiro
                        dadosVenda.Pix = dadosVenda2.Pix
                        dadosVenda.Cheque = dadosVenda2.Cheque
                        dadosVenda.ChequePre = dadosVenda2.ChequePre
                        dadosVenda.CartaoDebito = dadosVenda2.CartaoDebito
                        dadosVenda.CartaoCredito = dadosVenda2.CartaoCredito
                        dadosVenda.Crediario = dadosVenda2.Crediario
                    Next
                End If
            End If

            dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")

            If txtControle.Tag = 0 Then
                Me.txtControle.Text = mdiPrincipal.RetornaNumeroControle()
                dadosVenda.controle = Me.txtControle.Text
                controle = novaVenda.Incluir(dadosVenda)
                Me.txtControle.Tag = dadosVenda.controle
            Else
                controle = novaVenda.Alterar(dadosVenda)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ExcluirPreVenda()

        If dtgProdutos.Rows.Count <= 0 OrElse
            MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

            If dtgProdutos.Rows.Count > 0 And System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" Then
                Dim acessoGerente As New fAcessoGerente()
                acessoGerente.ShowDialog()
                If acessoGerente.gRetorno Then
                    EfetivaExclusaoPreVenda()
                End If
            Else
                EfetivaExclusaoPreVenda()
            End If
        End If

        NovaVenda()

    End Sub

    Private Sub EfetivaExclusaoPreVenda()
        Dim preVenda As New ncRegras.nsVenda.rPreVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        'Dim regrasItem As rProdutoItem

        '' retorna estoque
        'For Each linha As DataGridViewRow In dtgProdutos.Rows
        '  regrasItem = New rProdutoItem()
        '  regrasItem.AlterarEstoque(linha.Cells(0).Value, linha.Cells(4).Value)
        'Next

        If txtControle.Text.Equals("") Then
            MessageBox.Show("Digite o número da venda para excluir!", "Nascomercio")
        Else
            ' exclui prevenda e seus produtos
            dadosVenda.controle = txtControle.Text
            preVenda.Excluir(dadosVenda)

            'GravarLog(Me.lblVendedor.Text, "Venda excluída [" & txtControle.Text & "]")
            If dtgProdutos.Rows.Count > 0 Then
                MessageBox.Show("Venda excluída: " & txtControle.Text)
                GravarLog(mdiPrincipal.gUsuario.usuario, "Venda excluída: " & txtControle.Text)
            End If
        End If
    End Sub

    Private Sub Vale()
        Dim objImpressao As ncComum.Impressao
        Dim controle As Integer
        Dim regraVenda As New ncRegras.nsVenda.rVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim regrasItem As New rProdutoItem

        If (CDec(lblTroca.Text) > 0.0 Or CDec(lblDefeitos.Text) > 0.0) Then

            If dtgProdutos.Rows.Count <= 0 Then
                objImpressao = New ncComum.Impressao()

                GravarLog(Me.cboVendedor.Text, "Emissão de vale [" & (CDec(lblTroca.Text) + CDec(lblDefeitos.Text)).ToString("C") & "]")

                Try
                    ' Inclui vale para contabilizar no fechamento
                    Me.txtControle.Text = mdiPrincipal.RetornaNumeroControle()
                    dadosVenda.controle = Me.txtControle.Text
                    dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
                    dadosVenda.Caixa = mdiPrincipal.gUsuario.usuario
                    dadosVenda.clienteId = Me.txtCliente.Tag
                    dadosVenda.Data = Now
                    dadosVenda.Troca = Me.lblTroca.Text
                    dadosVenda.Defeito = Me.lblDefeitos.Text
                    dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
                    dadosVenda.Vendedor = Me.cboVendedor.Text
                    dadosVenda.Total = Me.lblTotal.Text
                    dadosVenda.ValeEmitido = CDec(Me.lblTroca.Text) + CDec(Me.lblDefeitos.Text)
                    GravarLog(mdiPrincipal.gUsuario.usuario, "Troca realizada. Vendedor: " & Me.cboVendedor.Text)
                    controle = regraVenda.IncluirVale(dadosVenda)

                    If CDec(Me.lblTroca.Text) > 0.0 Then
                        For Each produtoTroca As ncDados.nsVenda.dVendaProduto In dadosTroca
                            regrasItem.AlterarEstoque(produtoTroca.codigobarras, produtoTroca.quantidade)
                        Next
                    End If

                    dadosTroca.Clear()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

                If MessageBox.Show("Deseja imprimir o Vale?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    Try
                        objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

                        'objImpressao.Write("123456789012345678901234567890123456789012345678")
                        objImpressao.Write("VALE")
                        objImpressao.Write("Loja:" & mdiPrincipal.gLoja.nomeFantasia)
                        If Not String.IsNullOrEmpty(mdiPrincipal.gLoja.logradouro) Then
                            objImpressao.Write("End.:" & mdiPrincipal.gLoja.logradouro & "  " & mdiPrincipal.gLoja.numero)
                        End If
                        If Not IsNothing(mdiPrincipal.gLoja.telefone) Then
                            objImpressao.Write("Tel.:" & mdiPrincipal.gLoja.telefone)
                        End If
                        objImpressao.Write("------------------------------------------------")
                        objImpressao.Write("Emissao:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle:" & controle.ToString)
                        objImpressao.Write("Vendedor:" & mdiPrincipal.gUsuario.usuario & "  Caixa:" & System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL"))
                        objImpressao.Write("Cliente:" & ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(txtCliente.Text))
                        objImpressao.Write(vbCrLf)
                        objImpressao.Write("------------------------------------------------")
                        'objImpressao.Write("TROCA      : " & CDec(lblTroca.Text).ToString("C"))
                        'objImpressao.Write("DEFEITOS   : " & CDec(lblDefeitos.Text).ToString("C"))
                        objImpressao.Write("TOTAL VALE : " & (CDec(lblTroca.Text) + CDec(lblDefeitos.Text)).ToString("C"))
                        objImpressao.Write("------------------------------------------------")
                        objImpressao.Write("Apresente este cupom na proxima compra.")
                        objImpressao.Write("")
                        objImpressao.Write("")
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
                    'End If

                Else
                    MessageBox.Show("Vale emitido em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle: " & controle.ToString)
                End If

                limpaCampos()
                NovaVenda()
            Else
                MessageBox.Show("Pressione F10!")
            End If
        Else
            MessageBox.Show("Selecione Troca ou Defeito!")

        End If

    End Sub

    Private Sub limpaCampos()
        Me.dadosTroca = New ncDados.nsVenda.ColecaoVendaProduto
        Me.dtgProdutos.Rows.Clear()
        Me.txtControle.Text = "F10 Nova Venda"
        Me.txtControle.Tag = 0
        Me.lblVendas.Text = 0.ToString("N")
        Me.lblSubtotal.Text = 0.ToString("N")
        Me.lblTotal.Text = 0.ToString("N")
        Me.txtDesconto.Text = 0.ToString("N")
        Me.txtDesconto.Text = 0.ToString("N")
        Me.txtIdCliente.Text = ""
        Me.lblTroca.Text = 0.ToString("N")
        Me.lblDefeitos.Text = 0.ToString("N")
        Me.lblVale.Text = 0.ToString("N")
        Me.txtCliente.Text = "ao consumidor"
        Me.txtCliente.Tag = 0
        Me.txtCliente.ForeColor = Color.Black
        Me.txtCliente.BackColor = Color.White
        Me.cboCondicao.SelectedIndex = 1
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
    End Sub


    Private Sub SelecionarClientes()
        Dim formCliente As New fClienteLista
        formCliente.filtro = New ncDados.nsCliente.dCliente()
        formCliente.ShowDialog()
        If formCliente.filtro.nome <> "" Then
            Me.txtCliente.Text = formCliente.filtro.nome
            If formCliente.filtro.cpf <> "" Then
                Me.txtCliente.Text += ", CPF: " & formCliente.filtro.cpf
            End If
            Me.txtCliente.Tag = formCliente.filtro.cid
            If formCliente.filtro.situacao = "N" Then
                Me.txtCliente.ForeColor = Color.Red
                txtCliente.BackColor = Color.Salmon
            ElseIf formCliente.filtro.situacao = "O" Then
                Me.txtCliente.ForeColor = Color.Orange
                txtCliente.BackColor = Color.Yellow
            Else
                Me.txtCliente.ForeColor = Color.Black
                txtCliente.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub SelecionarProdutos()
        Dim formProduto As New fProdutoItemPesquisa()
        formProduto.ShowDialog()
        If Not IsNothing(formProduto.filtro) Then
            Me.txtCodigo.Text = formProduto.filtro.codigoBarras
            Me.txtCodigo_Leave(Nothing, Nothing)
        End If
    End Sub

    Private Sub SelecionarOrdemServico()
        Dim formOS As New fOrdemServico()
        formOS.ShowDialog()
        If Not String.IsNullOrEmpty(formOS.txtCliente.Text) Then
            Me.txtCliente.Text = formOS.txtCliente.Text
            Me.txtCliente.Tag = formOS.txtCliente.Tag
            Me.lblOS.Text = formOS.txtControle.Text
        End If
    End Sub

    Private Sub PagamentoCrediario()

        If Application.OpenForms().OfType(Of fCrediarioPagamento)().Any() Then
            Exit Sub
        End If

        Dim formCrediario As fCrediarioPagamento

        If Me.lblMsg.Text = "VENDA DIRETA" Then
            formCrediario = New fCrediarioPagamento()
            formCrediario.lblVendedor.Text = Me.cboVendedor.Text
            formCrediario.lblVendedor.Tag = Me.cboVendedor.Tag
            formCrediario.ShowDialog()
        End If
    End Sub

    Private Sub Troca()
        lblMsg.Text = "TROCA"
        NovaVenda()
    End Sub

    Private Sub Devolucao()
        lblMsg.Text = "DEVOLUÇÃO"
        NovaVenda()
    End Sub

    Private Sub FinalizaVenda()
        Dim produto As dVendaProduto
        If lblMsg.Text = "TROCA" Or lblMsg.Text = "DEVOLUÇÃO" Then
            If Me.Tag = True Then
                Me.lblMsg.Text = "VENDA DIRETA"
            Else
                Me.lblMsg.Text = "PRÉ VENDA"
            End If
            'Carregar lista de trocas
            For Each linha As DataGridViewRow In dtgProdutos.Rows
                produto = New dVendaProduto
                produto.itemId = linha.Cells(1).Tag
                produto.descricao = linha.Cells(1).Value
                produto.produtoId = linha.Cells(2).Tag
                produto.quantidade = linha.Cells(4).Value
                produto.valor = linha.Cells(3).Value
                produto.aliquota = linha.Cells(3).Tag
                produto.codigobarras = linha.Cells(0).Value
                dadosTroca.Add(produto)
            Next
            ' limpa lista tela
            Me.dtgProdutos.Rows.Clear()
        Else
            If dtgProdutos.Rows.Count > 0 Then
                GravaPreVenda()
                CalculaTotais()
                If Me.lblMsg.Text = "PRÉ VENDA" Or Me.lblMsg.Text = "ORÇAMENTO" Then
                    CarregaPagamentoPreVenda()
                Else
                    CarregaPagamento()
                End If
            Else
                If Me.Tag = True Then
                    Me.lblMsg.Text = "VENDA DIRETA"
                Else
                    Me.lblMsg.Text = "PRÉ VENDA"
                End If
                NovaVenda()
                ' MessageBox.Show("Nenhum produto vendido")
            End If
        End If
    End Sub

    Private Sub fCaixa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, txtParcelas.KeyDown, txtDesconto.KeyDown, cboCondicao.KeyDown
        Dim vendas As New ncRegras.nsVenda.rPreVenda

        Select Case e.KeyCode
            Case Keys.Escape
                FecharTela()
            Case Keys.F1 ' Selecionar cliente
                SelecionarClientes()
            Case Keys.F2 ' Selecionar produto
                SelecionarProdutos()
            Case Keys.F3 ' Pagamento de crediário
                PagamentoCrediario()
            Case Keys.F4
                Dim acessoGerente As New fAcessoGerente()
                acessoGerente.ShowDialog()
                If acessoGerente.gRetorno Then
                    Dim formRetirada As New fRetiradaCaixa()
                    formRetirada.lblVendedor.Text = acessoGerente.gGerente.usuario
                    formRetirada.lblVendedor.Tag = acessoGerente.gGerente.cid
                    formRetirada.ShowDialog()
                End If
            Case Keys.F5
                Troca()
            Case Keys.F6
                Devolucao()
            Case Keys.F7
                ExcluirPreVenda()
            Case Keys.F8
                Vale()
            Case Keys.F9
                Dim usuarioCaixa As New fUsuarioListaCaixa()
                usuarioCaixa.filtro = New ncDados.nsUsuario.dUsuario
                usuarioCaixa.ShowDialog()
                If usuarioCaixa.filtro.cid.HasValue Then
                    Me.cboVendedor.Text = usuarioCaixa.filtro.usuario
                    Me.cboVendedor.Tag = usuarioCaixa.filtro.cid
                End If
            Case Keys.F10 ' Finaliza Venda
                btoSalvar.Focus()
                Application.DoEvents()
                FinalizaVenda()
            Case Keys.F11 ' Selecionar OS
                SelecionarOrdemServico()
            Case Keys.F12
                If lblAbrirFechar.Text.Equals("Fechar Caixa [F12]") Then
                    FecharCaixa()
                Else
                    AbrirCaixa()
                End If
        End Select
    End Sub


    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        fCaixa_KeyDown(sender, e)
    End Sub


    Private Sub ConsultarPreVenda()
        Dim controle As Integer
        Dim linha As DataGridViewRow
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim vendasProdutos As ncDados.nsVenda.ColecaoVendaProduto
        ' Venda
        Dim preVenda As New ncRegras.nsVenda.rPreVenda
        Dim preVendaProduto As New ncRegras.nsVenda.rPreVendaProduto
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
            If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") <> "CAIXA" Then
                dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
            End If
            dadosVendaProduto.controle = controle
            Try
                dtgProdutos.Rows.Clear()
                vendas = preVenda.Consultar(dadosVenda)
                If Not IsNothing(vendas) Then
                    For Each dadosVenda In vendas
                        Me.txtControle.Tag = dadosVenda.controle
                        ' Cliente
                        dadosCliente = cliente.ConsultarPorCID(dadosVenda.clienteId)
                        Me.txtCliente.Text = dadosCliente.nome
                        Me.txtCliente.Tag = dadosCliente.cid
                        Me.txtIdCliente.Text = dadosCliente.cid
                        dadosClienteFin.cliente_cid = dadosVenda.clienteId
                        dadosClienteFinCol = clienteFin.Consultar(dadosClienteFin)
                        If Not IsNothing(dadosClienteFinCol) Then
                            Me.txtCliente.ForeColor = IIf(dadosClienteFinCol(0).situacaoCrediario = "N", Color.Red, Color.Black)
                            Me.txtCliente.BackColor = IIf(dadosClienteFinCol(0).situacaoCrediario = "N", Color.Salmon, Color.White)
                        End If

                        ' Vendedor
                        If dadosVenda.Vendedor <> "" Then
                            Me.cboVendedor.Text = dadosVenda.Vendedor
                            Me.cboVendedor.Tag = dadosVenda.usuarioId
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
                    vendasProdutos = preVendaProduto.Consultar(dadosVendaProduto)
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
                            linha.Cells(3).Tag = dadosVendaProduto.aliquota
                            linha.Cells(4).Value = dadosVendaProduto.quantidade
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
            ConsultarPreVenda()
        Else
            fCaixa_KeyDown(sender, e)
        End If
    End Sub

    Private Sub AbrirCaixa()

        Dim regraCaixa As New rCaixa()
        Dim dadosCaixa As New dCaixa()
        Dim consultaCaixa As New ColecaoCaixa()

        dadosCaixa.nome = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
        dadosCaixa.usuario = mdiPrincipal.gUsuario.usuario

        consultaCaixa = regraCaixa.Consultar(dadosCaixa)

        dadosCaixa.Data = DateTime.Now
        dadosCaixa.situacao = "ABERTO"

        If Not consultaCaixa Is Nothing Then
            dadosCaixa.cid = consultaCaixa(0).cid
            regraCaixa.Alterar(dadosCaixa)
        Else
            regraCaixa.Incluir(dadosCaixa)
        End If

        If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
            Declaracoes.iRetorno = Declaracoes.iLeituraX_ECF_Daruma()
            If Declaracoes.iRetorno <> 1 Then
                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
            End If
        End If

        lblAbrirFechar.Text = "Fechar Caixa [F12]"
    End Sub

    Private Sub FecharCaixa()
        Dim regraCaixa As New rCaixa()
        Dim dadosCaixa As New dCaixa()
        Dim consultaCaixa As New ColecaoCaixa()
        Dim consultaCaixaFechamento As ColecaoFechamento
        Dim regrasUsuario As rUsuario
        Dim dadosUsuario As dUsuario
        Dim retorno As ColecaoUsuario
        Dim strPerfil As String

        regrasUsuario = New rUsuario
        dadosUsuario = New dUsuario
        strPerfil = ConfigurationManager.AppSettings("perfilGestor")

        retorno = regrasUsuario.fConsultarADM(strPerfil)

        dadosCaixa.nome = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
        dadosCaixa.usuario = mdiPrincipal.gUsuario.usuario

        consultaCaixa = regraCaixa.Consultar(dadosCaixa)

        dadosCaixa.Data = DateTime.Now
        dadosCaixa.situacao = "FECHADO"

        If consultaCaixa.Count > 0 Then
            dadosCaixa.cid = consultaCaixa(0).cid
            regraCaixa.Alterar(dadosCaixa)
        Else
            regraCaixa.Incluir(dadosCaixa)
        End If

        consultaCaixaFechamento = regraCaixa.ConsultarFechamento(dadosCaixa)
        If Not consultaCaixaFechamento Is Nothing Then
            regraCaixa.EnviarEmailCaixa(consultaCaixaFechamento, retorno)
        End If

        If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
            Declaracoes.iRetorno = Declaracoes.iLeituraX_ECF_Daruma()
            If Declaracoes.iRetorno <> 1 Then
                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
            End If
        End If

        Me.lblMsg.Text = "CAIXA FECHADO"
    End Sub

    Private Sub FecharTela()
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If dtgProdutos.Rows.Count > 0 Then
                If MessageBox.Show("Deseja gravar a venda?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    GravaPreVenda()
                    CalculaTotais()
                Else
                    ExcluirPreVenda()
                End If
            Else
                If Not txtControle.Text.Equals("") Then
                    If Integer.TryParse(txtControle.Text, Nothing) Then
                        ExcluirPreVenda()
                    End If
                End If
            End If

            If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") <> "VENDA" Then
                mdiPrincipal.FecharTela()
            Else
                mdiPrincipal.FecharTelaLogin()
            End If

        End If
    End Sub

    Private Sub cboCondicao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicao.SelectedIndexChanged
        Dim regras As New ncRegras.nsCondicao.rCondicao
        Dim dados As New ncDados.nsCondicao.dCondicao

        If cboCondicao.Text = "PARCELADO" Then
            txtParcelas.Enabled = True
        Else
            txtParcelas.Enabled = False
            txtParcelas.Text = "1"
        End If

        If Not cboCondicao.SelectedValue Is Nothing Then
            dados = regras.Consultar(cboCondicao.SelectedValue)
        End If



        txtDesconto.Text = CDec(CDec(lblSubtotal.Text) * (CDec(dados.desconto) / 100)).ToString("N")

        txtDesconto_Leave(sender, e)

    End Sub

    Private Sub txtDesconto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesconto.Leave
        Dim dadosUsuario As ncDados.nsUsuario.dUsuario
        Dim regraUsuario As New ncRegras.nsUsuario.rUsuario
        Dim acessoGerente As fAcessoGerente

        Try
            If CDec(txtDesconto.Text) > 0 Then
                If CDec(lblSubtotal.Text) > 0 Or (CDec(lblTroca.Text) > 0) Or (CDec(lblDefeitos.Text) > 0) Then
                    If dtgProdutos.Rows.Count > 0 Then
                        dadosUsuario = regraUsuario.ConsultarPorCid(mdiPrincipal.gUsuario.cid)
                        If IsNothing(dadosUsuario) Then
                            MessageBox.Show("Erro ao consultar usuário")
                        Else
                            If Not dadosUsuario.descontoPedido.HasValue Then
                                dadosUsuario.descontoPedido = 0
                            End If
                            If lblMsg.Text = "DEVOLUÇÃO" Or lblMsg.Text = "TROCA" Then
                                CalculaTotais()
                                txtDesconto.Text = CDec(txtDesconto.Text).ToString("N")
                            Else
                                If (CDec(txtDesconto.Text) / CDec(lblSubtotal.Text)) * 100 <= dadosUsuario.descontoPedido Then
                                    CalculaTotais()
                                    txtDesconto.Text = CDec(txtDesconto.Text).ToString("N")
                                Else
                                    MessageBox.Show("Desconto maior que o permitido:" & dadosUsuario.descontoPedido.ToString() & "%")
                                    acessoGerente = New fAcessoGerente()
                                    acessoGerente.ShowDialog()
                                    If Not acessoGerente.gRetorno Then
                                        txtDesconto.Text = 0.ToString("N")
                                    Else
                                        txtDesconto.Text = CDec(txtDesconto.Text).ToString("N")
                                    End If
                                    acessoGerente.Close()
                                End If
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("Insira produtos antes de dar desconto")
                    txtDesconto.Text = 0.ToString("N")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        FinalizaVenda()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCodigo_Leave(sender, e)
        Else
            fCaixa_KeyDown(sender, e)
        End If
    End Sub

    Private Sub txtDesconto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesconto.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub txtParcelas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtParcelas.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub txtQuantidade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantidade.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub txtControle_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtControle.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)

    End Sub

    Private Sub txtQuantidade_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantidade.KeyDown
        fCaixa_KeyDown(sender, e)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Vale()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        ExcluirPreVenda()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SelecionarClientes()
    End Sub

    Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
        SelecionarProdutos()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        PagamentoCrediario()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Troca()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Devolucao()
    End Sub

    Private Sub dtgProdutos_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgProdutos.UserDeletingRow

        If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "CAIXA" And _lojaGrande Then
            If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                Dim acessoGerente As New fAcessoGerente()
                acessoGerente.ShowDialog()
                If Not acessoGerente.gRetorno Then
                    e.Cancel = True
                Else
                    ExcluiLinha(e.Row)
                End If
            Else
                e.Cancel = True
            End If
        Else
            ExcluiLinha(e.Row)
        End If
    End Sub

    Private Sub ExcluiLinha(ByVal linha As System.Windows.Forms.DataGridViewRow)
        'Dim regrasItem As rProdutoItem
        'regrasItem = New rProdutoItem()
        'regrasItem.AlterarEstoque(linha.Cells(0).Value, linha.Cells(4).Value)
        CalculaTotais()
    End Sub

    Private Sub btnOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOS.Click
        SelecionarOrdemServico()

    End Sub

    Private Sub dtgProdutos_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgProdutos.UserDeletedRow
        CalculaTotais()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If lblAbrirFechar.Text.Equals("Fechar Caixa [F12]") Then
            FecharCaixa()
        Else
            AbrirCaixa()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtControle_TextChanged(sender As Object, e As EventArgs) Handles txtControle.TextChanged

    End Sub

    Private Sub Panel1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Panel1.PreviewKeyDown

    End Sub

    Private Sub txtIdCliente_Enter(sender As Object, e As EventArgs) Handles txtIdCliente.Enter

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
        FiltrarCliente()
    End Sub
End Class