Imports System
Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Net.Sockets
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports CLPix.Services
Imports iTextSharp.text
Imports LibNF65
Imports LibNF65.NFCeModel
Imports ncComum.DFW
Imports ncComum.nsConstantes
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsLog.cLog
Imports ncDados
Imports ncDados.nsCliente
Imports ncDados.nsParametro
Imports ncDados.nsProduto
Imports ncPersistencia
Imports ncRegras
Imports ncRegras.nsCliente
Imports ncRegras.nsParametro
Imports ncRegras.nsProduto
Imports Unimake.Business.DFe.Servicos
Imports Unimake.Business.Security
Imports LibNF65.Modelo


Public Class fPagamento

    Public dadosVendaProdutos As New ncDados.nsVenda.ColecaoVendaProduto
    Public dadosTroca As New ncDados.nsVenda.ColecaoVendaProduto
    Public condicao As String
    Public parcelas As String
    Public desconto As String
    Public crediario As String
    Private dadosParametro As dParametro
    Private regraParametro As rParametro
    Private certificadoCarregado As New X509Certificate2

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        btnPix.Text = "Cobrar"
        txtTxId.Tag = 0
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ''' <summary>
    ''' Mostra informações de valores recebidos e troco
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub calculaRecebido()
        ' Soma recebidos
        lblRecebido.Text = CDec(CDec(txtDinheiro.Text) + CDec(txtPix.Text) + CDec(txtCheque.Text) + CDec(txtChequePre.Text) _
        + CDec(txtCartaoDebito.Text) + CDec(txtCartaoCredito.Text) + CDec(txtCrediario.Text) _
        + CDec(txtTroca.Text) + CDec(txtVale.Text) + CDec(txtDefeitos.Text)).ToString("N")

        If CDec(lblRecebido.Text) <= CDec(lblTotal.Text) Then
            lblFalta.Text = CDec(CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
            lblTroco.Text = 0.ToString("N")
        Else
            lblTroco.Text = CDec(CDec(lblRecebido.Text) - CDec(lblTotal.Text)).ToString("N")
            lblFalta.Text = 0.ToString("N")
        End If
        lblRecebido.Text = CDec(CDec(txtVendas.Text) - CDec(lblFalta.Text)).ToString("N")
    End Sub
    Private Sub recalculaRecebido()
        ' Soma recebidos
        lblRecebido.Text = CDec(CDec(txtDinheiro.Text) + CDec(txtPix.Text) + CDec(txtCheque.Text) + CDec(txtChequePre.Text) _
        + CDec(txtCartaoDebito.Text) + CDec(txtCartaoCredito.Text) + CDec(txtCrediario.Text) _
        + CDec(txtTroca.Text) + CDec(txtVale.Text) + CDec(txtDesconto.Text) + CDec(txtDefeitos.Text)).ToString("N")

        If CDec(lblRecebido.Text) <= CDec(txtVendas.Text) Then
            lblFalta.Text = CDec(CDec(txtVendas.Text) - CDec(lblRecebido.Text)).ToString("N")
            lblTroco.Text = 0.ToString("N")
        Else
            lblTroco.Text = CDec(CDec(lblRecebido.Text) - CDec(txtVendas.Text)).ToString("N")
            lblFalta.Text = 0.ToString("N")
        End If
        lblTotal.Text = txtVendas.Text
    End Sub

    Private Sub fPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTroco.Text = 0.ToString("N")
        lblRecebido.Text = 0.ToString("N")
        lblVale.Text = 0.ToString("N")

        CarregarComboCondicao()
        cboCondicao.Text = condicao

        If parcelas <> "" Then
            txtParcelas.Text = parcelas
        End If

        If crediario <> "" Then
            txtCrediario.Text = crediario
        End If

        If desconto <> "" Then
            txtDesconto.Text = desconto
        End If

        calculaRecebido()
        formataCampos()
        If HabilitarPix() Then
            'RecuperarDadosPix()
            chkPIX.Enabled = True
        Else
            chkPIX.Enabled = False
        End If

        txtValorPIX.Text = "0,00"
        txtObs.Text = ""
        txtTxId.Text = ""
        txtStatus.Text = ""
        txtUrlPix.Text = ""
        'txtPix.Text = "0,00"
        'txtDesconto.Text = "0,00"
        lblTotal.Text = txtVendas.Text

        CarregarComboCondicaoAsync()

    End Sub
    Private Async Function CarregarComboCondicaoAsync() As Task

        Dim certificado As New CertificadoDigital()

        Dim caminhoCertificado As String = ConfigurationManager.AppSettings("CertificadoArquivo")
        Dim senhaCertificado As String = ConfigurationManager.AppSettings("CertificadoSenha")

        certificadoCarregado = Await CarregarCertificadoAsync(caminhoCertificado, senhaCertificado, certificado)
    End Function
    Private Function HabilitarPix() As Boolean
        ' Habilitar uso do PIX?

        Dim retorno As Boolean

        regraParametro = New rParametro()
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.UsarPIX)
        If Not IsNothing(dadosParametro) Then
            If dadosParametro.valor = "1" Then
                retorno = True
            Else
                retorno = False
            End If
        End If

        HabilitarPix = retorno
    End Function
    Private Sub txtDinheiro_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDinheiro.Leave,
                                                                                               txtCartaoCredito.Leave,
                                                                                               txtCrediario.Leave,
                                                                                               txtChequePre.Leave,
                                                                                               txtCheque.Leave,
                                                                                               txtCartaoDebito.Leave,
                                                                                               txtVale.Leave,
                                                                                               txtDesconto.Leave,
                                                                                               txtPix.Leave
        'Mostra informações de valores recebidos e troco
        verificaCampos()
        recalculaRecebido()
        VerificarAlcada()
        formataCampos()
    End Sub
    Private Sub VerificarAlcada()
        Dim dadosUsuario As ncDados.nsUsuario.dUsuario
        Dim regraUsuario As New ncRegras.nsUsuario.rUsuario
        Dim acessoGerente As fAcessoGerente

        Try
            If CDec(txtDesconto.Text) = 0 Then
                Exit Sub
            End If

            dadosUsuario = regraUsuario.ConsultarPorCid(mdiPrincipal.gUsuario.cid)
            If IsNothing(dadosUsuario) Then
                MessageBox.Show("Erro ao consultar usuário")
            Else
                If Not dadosUsuario.descontoPedido.HasValue Then
                    dadosUsuario.descontoPedido = 0
                End If
                If (CDec(txtDesconto.Text) / CDec(lblTotal.Text)) * 100 <= dadosUsuario.descontoPedido Then
                    recalculaRecebido()
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub formataCampos()

        txtDinheiro.Text = CDec(txtDinheiro.Text).ToString("N")
        txtPix.Text = CDec(txtPix.Text).ToString("N")
        txtCheque.Text = CDec(txtCheque.Text).ToString("N")
        txtChequePre.Text = CDec(txtChequePre.Text).ToString("N")
        txtCartaoCredito.Text = CDec(txtCartaoCredito.Text).ToString("N")
        txtCartaoDebito.Text = CDec(txtCartaoDebito.Text).ToString("N")
        txtCrediario.Text = CDec(txtCrediario.Text).ToString("N")
        txtVale.Text = CDec(txtVale.Text).ToString("N")
        txtDesconto.Text = CDec(txtDesconto.Text).ToString("N")
        txtIdCliente.Text = Me.txtCliente.Tag
    End Sub

    Private Sub verificaCampos()


        If txtDinheiro.Text.Trim().Equals("") Then
            txtDinheiro.Text = 0.ToString("N")
        End If
        If txtPix.Text.Trim().Equals("") Then
            txtPix.Text = 0.ToString("N")
        End If
        If txtCheque.Text.Trim().Equals("") Then
            txtCheque.Text = 0.ToString("N")
        End If
        If txtChequePre.Text.Trim().Equals("") Then
            txtChequePre.Text = 0.ToString("N")
        End If
        If txtCartaoCredito.Text.Trim().Equals("") Then
            txtCartaoCredito.Text = 0.ToString("N")
        End If
        If txtCartaoDebito.Text.Trim().Equals("") Then
            txtCartaoDebito.Text = 0.ToString("N")
        End If
        If txtCrediario.Text.Trim().Equals("") Then
            txtCrediario.Text = 0.ToString("N")
        End If
        If txtVale.Text.Trim().Equals("") Then
            txtVale.Text = 0.ToString("N")
        End If
        If txtDesconto.Text.Trim().Equals("") Then
            txtDesconto.Text = 0.ToString("N")
        End If
        If txtIdCliente.Text.Trim().Equals("") Then
            txtIdCliente.Text = ""
        End If
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Dim controle As Integer
        Dim retornoCrediario As Boolean = True
        Dim retornoCheque As Boolean = True
        Dim acessoGerente As fAcessoGerente

        If CDec(lblRecebido.Text) >= CDec(lblTotal.Text) Then
            If CDec(lblTroco.Text) > 0 And CDec(txtDinheiro.Text) <= 0 And CDec(txtPix.Text) <= 0 And CDec(txtTroca.Text) <= 0 And CDec(txtVale.Text) <= 0 And CDec(txtDefeitos.Text) <= 0 Then
                MessageBox.Show("Para pagamentos sem dinheiro informe o valor exato!")
                Exit Sub
            End If
            If MessageBox.Show("Deseja finalizar a venda?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If txtCliente.Tag <> 1 Then

                    If Me.txtCliente.ForeColor = Color.Red And Not EhAdmin() Then
                        MessageBox.Show("Cliente com pendências!")
                        acessoGerente = New fAcessoGerente()
                        acessoGerente.ShowDialog()
                        If Not acessoGerente.gRetorno Then
                            Exit Sub
                        End If
                    End If

                    If CDec(txtCrediario.Text) > 0 Then
                        retornoCrediario = CarregaCrediario()
                    End If
                    If CDec(txtCheque.Text) > 0 Or CDec(txtChequePre.Text) > 0 Then
                        retornoCheque = CarregaCheque()
                    End If
                Else
                    If CDec(txtCheque.Text) > 0 Or CDec(txtChequePre.Text) > 0 Or CDec(txtCrediario.Text) > 0 Then
                        MessageBox.Show("Selecionar um Cliente")
                        Exit Sub
                    End If
                End If

                If retornoCrediario And retornoCheque Then

                    Try
                        controle = IncluiVenda()
                        ExcluirPreVenda()
                        Imprime(controle)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Erro ao incluir venda!")
                    End Try

                    If retornoCrediario Then
                        ControleCrediario(controle)
                    End If

                    LimpaCampos()
                    Me.Close()

                    Try
                        ' Fechar tela caixa
                        regraParametro = New rParametro()
                        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.FecharTelaCaixa)
                        If Not IsNothing(dadosParametro) Then
                            If dadosParametro.valor = "Sim" Then
                                mdiPrincipal.FecharTelaLogin()
                            End If
                        End If
                    Catch nex As ExcecaoNascomercio

                        MessageBox.Show(nex.Message)

                    Catch ex As Exception

                        MessageBox.Show("Erro na consulta dos parâmetros.")

                    End Try

                End If

                If Not retornoCheque Then
                    MessageBox.Show("Inserir Cheques!")
                End If

                If Not retornoCrediario Then
                    MessageBox.Show("Incluir Crediário!")
                End If

            End If

        Else
            MessageBox.Show("Faltam: " & lblFalta.Text)

        End If

    End Sub
    Private Function EhAdmin() As Boolean
        Return mdiPrincipal.lblUsuario.Text.Contains("ADMINISTRADOR")
    End Function

    Private Function CarregaCheque() As Boolean
        Dim janela As fChequesForm
        Dim linha As DataGridViewRow
        Dim cheques As Integer

        cheques = CInt(txtParcelas.Text)

        janela = New fChequesForm()

        If txtCliente.Tag > 1 Then
            ' cheques
            For i As Integer = 0 To cheques - 1
                linha = janela.dgvCheques.Rows(janela.dgvCheques.Rows.Add())
                janela.dgvCheques.Rows(i).Cells(0).Value = lblControle.Text + i.ToString()
                janela.dgvCheques.Rows(i).Cells(1).Value = Today.ToString("dd/MM/yyyy")
                janela.dgvCheques.Rows(i).Cells(2).Value = Today.AddMonths(i).ToString("dd/MM/yyyy")
                janela.dgvCheques.Rows(i).Cells(3).Value = CDec((CDec(txtCheque.Text) + CDec(txtChequePre.Text)) / cheques).ToString("N")
            Next

            janela.lblTotal.Text = (CDec(txtCheque.Text) + CDec(txtChequePre.Text)).ToString("N")
            janela.lblFalta.Text = 0.ToString("N")
            janela.txtControle.Text = lblControle.Text
            janela.StartPosition = FormStartPosition.CenterParent
            janela.txtCliente.Text = txtCliente.Text
            janela.txtCliente.Tag = txtCliente.Tag
            janela.lblVendedor.Text = lblVendedor.Text
            janela.lblVendedor.Tag = lblVendedor.Tag
            janela.lblLoja.Text = lblLoja.Text
            janela.lblLoja.Tag = lblLoja.Tag


            'Application.DoEvents()

            janela.ShowDialog(Me)

            Return janela.pago
        Else
            MessageBox.Show("Selecionar um cliente!")
            Return False
        End If

    End Function

    Private Sub ControleCrediario(ByVal controle As Integer)
        Dim regraCrediario As New ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As New ncDados.nsCrediario.dCrediario

        dadosCrediario.cid = lblControle.Text
        dadosCrediario.controle = controle

        regraCrediario.AlterarControle(dadosCrediario)

    End Sub

    Private Function CarregaCrediario() As Boolean
        Dim janela As fCrediarioForm
        Dim linha As DataGridViewRow
        Dim parcelas As Integer
        Dim controle As Integer
        Dim tempoParcela As Integer
        Dim regraCrediario As ncRegras.nsCrediario.rCrediario
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim dataAtual As Date = Today

        Try

            ' Consulta ultima venda
            regraCrediario = New ncRegras.nsCrediario.rCrediario()
            'controle = regraCrediario.ConsultarMax() + 1
            controle = CInt(Me.lblControle.Text)

            parcelas = CInt(txtParcelas.Text)

            ' Tempo primeira parcela
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TempoPrimeiraParcela)
            If Not IsNothing(dadosParametro) Then
                tempoParcela = CInt(dadosParametro.valor)
                dataAtual = dataAtual.AddDays(tempoParcela)
            End If

            janela = New fCrediarioForm()

            If txtCliente.Tag > 1 Then
                ' crediario
                For i As Integer = 0 To parcelas - 1
                    linha = janela.dgvCrediario.Rows(janela.dgvCrediario.Rows.Add())
                    janela.dgvCrediario.Rows(i).Cells(0).Value = CStr(txtCliente.Tag).PadLeft(6, "0"c) & (controle.ToString() & CStr(i)).PadLeft(6, "0"c)
                    janela.dgvCrediario.Rows(i).Cells(1).Value = Today.ToString("dd/MM/yyyy")
                    janela.dgvCrediario.Rows(i).Cells(2).Value = dataAtual.AddMonths(i).ToString("dd/MM/yyyy")
                    janela.dgvCrediario.Rows(i).Cells(3).Value = CDec(CDec(txtCrediario.Text) / parcelas).ToString("N")
                Next

                janela.lblTotal.Text = CDec(txtCrediario.Text).ToString("N")
                janela.lblFalta.Text = 0.ToString("N")
                janela.txtControle.Text = controle.ToString()
                janela.StartPosition = FormStartPosition.CenterParent
                janela.txtCliente.Text = txtCliente.Text
                janela.txtCliente.Tag = txtCliente.Tag
                janela.lblVendedor.Text = lblVendedor.Text
                janela.lblVendedor.Tag = lblVendedor.Tag
                janela.lblLoja.Text = lblLoja.Text
                janela.lblLoja.Tag = lblLoja.Tag


                janela.ShowDialog()

                Return janela.pago
            Else
                MessageBox.Show("Selecionar um cliente!")
                Return False
            End If
        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)

        Catch ex As Exception
            MessageBox.Show("Erro na consulta do crediário.")

        End Try


    End Function

    Private Sub ExcluirPreVenda()
        Dim preVenda As New ncRegras.nsVenda.rPreVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda

        dadosVenda.controle = lblControle.Text
        preVenda.Excluir(dadosVenda)
    End Sub

    Private Sub LimpaCampos()
        txtCliente.Text = ""
        txtIdCliente.Text = ""
        lblControle.Text = ""
        lblEmissao.Text = ""
        lblVendedor.Text = ""
        lblLoja.Text = ""
        lblRecebido.Text = "0"
    End Sub

    Private Function IncluiVenda() As Integer
        Dim novaVenda As New ncRegras.nsVenda.rVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim regrasItem As New rProdutoItem

        Dim controle As Integer

        ' Inclui venda
        dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
        dadosVenda.Caixa = mdiPrincipal.gUsuario.usuario
        dadosVenda.clienteId = Me.txtCliente.Tag
        dadosVenda.Data = Now
        dadosVenda.Dinheiro = Me.txtDinheiro.Text
        dadosVenda.Pix = Me.txtPix.Text
        dadosVenda.Cheque = Me.txtCheque.Text
        dadosVenda.ChequePre = Me.txtChequePre.Text
        dadosVenda.CartaoDebito = Me.txtCartaoDebito.Text
        dadosVenda.CartaoCredito = Me.txtCartaoCredito.Text
        dadosVenda.Crediario = Me.txtCrediario.Text
        dadosVenda.Parcelas = Me.txtParcelas.Text
        dadosVenda.Desconto = Me.txtDesconto.Text
        dadosVenda.Condicao = Me.cboCondicao.SelectedIndex
        dadosVenda.Recebido = Me.lblRecebido.Text
        dadosVenda.Troca = Me.txtTroca.Text
        dadosVenda.Troco = Me.lblTroco.Text
        dadosVenda.Vale = Me.txtVale.Text
        dadosVenda.Defeito = Me.txtDefeitos.Text
        dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
        dadosVenda.Vendedor = Me.lblVendedor.Text
        dadosVenda.Total = Me.lblTotal.Text
        dadosVenda.controle = Me.lblControle.Text
        dadosVenda.ordemServicoId = Me.lblControle.Tag
        dadosVenda.TXID = Me.txtTxId.Text
        ' Verifica se emite Vale
        If (dadosVenda.Troca > 0.0 Or dadosVenda.Defeito > 0.0 Or dadosVenda.Vale > 0.0) And dadosVenda.Troco > 0.0 Then
            ' Verifica se troco provem de troca
            If dadosVenda.Troca > dadosVenda.Total Or dadosVenda.Defeito > dadosVenda.Total Or dadosVenda.Vale > dadosVenda.Total Then
                If MessageBox.Show("Deseja emitir Vale?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Vale()
                    dadosVenda.ValeEmitido = Me.lblVale.Text
                    dadosVenda.Troco = Me.lblTroco.Text
                End If
            End If
        End If

        If dadosVenda.Troca > 0.0 Then
            For Each produtoTroca As ncDados.nsVenda.dVendaProduto In dadosTroca
                regrasItem.AlterarEstoque(produtoTroca.codigobarras, produtoTroca.quantidade)
            Next
        End If
        dadosTroca.Clear()

        For Each produto As ncDados.nsVenda.dVendaProduto In dadosVendaProdutos
            regrasItem.AlterarEstoque(produto.codigobarras, -produto.quantidade)
        Next

        ' Verifica grava troca ou venda
        If (dadosVenda.Troca > 0.0 Or dadosVenda.Defeito > 0.0) Then
            GravarLog(mdiPrincipal.gUsuario.usuario, "Troca realizada. Vendedor: " & Me.lblVendedor.Text)
            controle = novaVenda.IncluirTroca(dadosVenda, dadosVendaProdutos)
        Else
            GravarLog(mdiPrincipal.gUsuario.usuario, "Venda realizada. Vendedor: " & Me.lblVendedor.Text)
            controle = novaVenda.Incluir(dadosVenda, dadosVendaProdutos)
        End If

        Return controle

    End Function
    Private Function IncluirNFe() As Integer
        Dim novaVenda As New ncRegras.nsVenda.rVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim regrasItem As New rProdutoItem

        Dim controle As Integer

        ' Inclui venda
        dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
        dadosVenda.Caixa = mdiPrincipal.gUsuario.usuario
        dadosVenda.clienteId = Me.txtCliente.Tag
        dadosVenda.Data = Now
        dadosVenda.Dinheiro = Me.txtDinheiro.Text
        dadosVenda.Pix = Me.txtPix.Text
        dadosVenda.Cheque = Me.txtCheque.Text
        dadosVenda.ChequePre = Me.txtChequePre.Text
        dadosVenda.CartaoDebito = Me.txtCartaoDebito.Text
        dadosVenda.CartaoCredito = Me.txtCartaoCredito.Text
        dadosVenda.Crediario = Me.txtCrediario.Text
        dadosVenda.Parcelas = Me.txtParcelas.Text
        dadosVenda.Desconto = Me.txtDesconto.Text
        dadosVenda.Condicao = Me.cboCondicao.SelectedIndex
        dadosVenda.Recebido = Me.lblRecebido.Text
        dadosVenda.Troca = Me.txtTroca.Text
        dadosVenda.Troco = Me.lblTroco.Text
        dadosVenda.Vale = Me.txtVale.Text
        dadosVenda.Defeito = Me.txtDefeitos.Text
        dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
        dadosVenda.Vendedor = Me.lblVendedor.Text
        dadosVenda.Total = Me.lblTotal.Text
        dadosVenda.controle = Me.lblControle.Text
        dadosVenda.ordemServicoId = Me.lblControle.Tag
        dadosVenda.TXID = Me.txtTxId.Text
        ' Verifica se emite Vale
        If (dadosVenda.Troca > 0.0 Or dadosVenda.Defeito > 0.0 Or dadosVenda.Vale > 0.0) And dadosVenda.Troco > 0.0 Then
            ' Verifica se troco provem de troca
            If dadosVenda.Troca > dadosVenda.Total Or dadosVenda.Defeito > dadosVenda.Total Or dadosVenda.Vale > dadosVenda.Total Then
                If MessageBox.Show("Deseja emitir Vale?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Vale()
                    dadosVenda.ValeEmitido = Me.lblVale.Text
                    dadosVenda.Troco = Me.lblTroco.Text
                End If
            End If
        End If

        If dadosVenda.Troca > 0.0 Then
            For Each produtoTroca As ncDados.nsVenda.dVendaProduto In dadosTroca
                regrasItem.AlterarEstoque(produtoTroca.codigobarras, produtoTroca.quantidade)
            Next
        End If
        dadosTroca.Clear()

        For Each produto As ncDados.nsVenda.dVendaProduto In dadosVendaProdutos
            regrasItem.AlterarEstoque(produto.codigobarras, -produto.quantidade)
        Next

        ' Verifica grava troca ou venda
        If (dadosVenda.Troca > 0.0 Or dadosVenda.Defeito > 0.0) Then
            GravarLog(mdiPrincipal.gUsuario.usuario, "Troca realizada. Vendedor: " & Me.lblVendedor.Text)
            controle = novaVenda.IncluirTroca(dadosVenda, dadosVendaProdutos)
        Else
            GravarLog(mdiPrincipal.gUsuario.usuario, "Venda realizada. Vendedor: " & Me.lblVendedor.Text)
            controle = novaVenda.Incluir(dadosVenda, dadosVendaProdutos)
        End If

        Return controle

    End Function
    Private Sub Vale()
        Dim objImpressao As ncComum.Impressao

        objImpressao = New ncComum.Impressao()

        GravarLog(mdiPrincipal.gUsuario.usuario, "Emissão de vale [" & (CDec(lblTroco.Text)).ToString("C") & "]")

        lblVale.Text = lblTroco.Text
        lblTroco.Text = 0.ToString("N")

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
                objImpressao.Write("Emissao:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle:" & lblControle.Text)
                objImpressao.Write("Vendedor:" & mdiPrincipal.gUsuario.usuario & "  Caixa:" & System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL"))
                objImpressao.Write("Cliente:" & ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(txtCliente.Text))
                objImpressao.Write(vbCrLf)
                objImpressao.Write("------------------------------------------------")
                'objImpressao.Write("TROCA    : " & CDec(txtTroca.Text).ToString("C"))
                'objImpressao.Write("DEFEITOS : " & CDec(txtDefeitos.Text).ToString("C"))
                objImpressao.Write("TOTAL VALE: " & CDec(lblVale.Text).ToString("C"))
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
            MessageBox.Show("Vale emitido em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle: " & lblControle.Text)
        End If

    End Sub

    Private Sub Imprime(ByVal controle As Integer)

        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim regraVenda As New ncRegras.nsVenda.rVenda

        Dim objImpressao As ncComum.Impressao
        Dim qtdImpressao As Integer = 1

        ' Fiscal
        Dim Str_CPF As String = "", Str_Nome As String = ""
        Dim Str_Aliquota As String, Str_ValorUnit As String, Str_Codigo_Item As String, Str_Descricao As String

        objImpressao = New ncComum.Impressao()

        If MessageBox.Show("Deseja emitir comprovante de venda?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                ' Mensagem final fita
                Dim msg As String = "Agradecemos a preferencia - Volte sempre"
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Mensagem)
                If Not IsNothing(dadosParametro) Then
                    msg = dadosParametro.valor
                End If


                ' Imprime segunda via
                If System.Configuration.ConfigurationManager.AppSettings("SEGUNDA_VIA") = "SIM" Then
                    qtdImpressao = 2
                End If


                If txtCliente.Text.Split(",").Length > 1 Then
                    'pega dados do cliente
                    Str_Nome = txtCliente.Text.Split(",")(0)
                    Str_CPF = txtCliente.Text.Split(",")(1).Replace("CPF:", "").Trim()
                End If


                If ConfigurationManager.AppSettings("FISCAL") = "ECF" Then

                    ' ECF - Impressora Fiscal

                    'se não informou cpf pergunta
                    If String.IsNullOrEmpty(Str_CPF) And Len(Str_CPF) = 11 Then
                        Str_CPF = InputBox("Deseja informar o CPF ?").Trim()
                        Do While Not ValidaCpf(Str_CPF)
                            Str_CPF = InputBox("CPF Incorreto, informe novamente ?").Trim()
                        Loop
                    ElseIf String.IsNullOrEmpty(Str_CPF) And Len(Str_CPF) = 14 Then
                        Str_CPF = InputBox("Deseja informar o CNPJ ?").Trim()
                        Do While Not ValidaCnpj(Str_CPF)
                            Str_CPF = InputBox("CNPJ Incorreto, informe novamente ?").Trim()
                        Loop

                    End If

                    If Not String.IsNullOrEmpty(Str_CPF) Then
                        Declaracoes.iRetorno = Declaracoes.iCFAbrir_ECF_Daruma(Str_CPF, Str_Nome, "")
                    Else
                        Declaracoes.iRetorno = Declaracoes.iCFAbrirPadrao_ECF_Daruma()
                    End If

                    If Declaracoes.iRetorno <> 1 Then
                        MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                    End If

                    For Each produto As ncDados.nsVenda.dVendaProduto In dadosVendaProdutos
                        Str_Aliquota = "T" & produto.aliquota
                        Str_ValorUnit = produto.valor.ToString("N")
                        Str_Codigo_Item = produto.codigobarras.Trim()
                        Str_Descricao = produto.descricao.Trim()

                        Declaracoes.iRetorno = Declaracoes.iCFVender_ECF_Daruma(Str_Aliquota, produto.quantidade, Str_ValorUnit, "D$", "", Str_Codigo_Item, "UN", Str_Descricao)
                        If Declaracoes.iRetorno <> 1 Then
                            MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                        End If
                    Next

                    'Desconto
                    Declaracoes.iRetorno = Declaracoes.iCFTotalizarCupom_ECF_Daruma("D$", txtDesconto.Text)
                    Declaracoes.TrataRetorno(Declaracoes.iRetorno)

                    'Pagamento
                    If CDec(txtDinheiro.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Dinheiro", txtDinheiro.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtPix.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Pix", txtPix.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtCheque.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Cheque", txtCheque.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtChequePre.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Cheque", txtChequePre.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtCartaoDebito.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma(ConfigurationManager.AppSettings("LABEL_DEBITO"), txtCartaoDebito.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtCartaoCredito.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma(ConfigurationManager.AppSettings("LABEL_CREDITO"), txtCartaoCredito.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtCrediario.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Crediário", txtCrediario.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtTroca.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Troca", txtTroca.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtVale.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Vale", txtVale.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If
                    If CDec(txtDefeitos.Text) > 0.001 Then
                        Declaracoes.iRetorno = Declaracoes.iCFEfetuarPagamentoFormatado_ECF_Daruma("Troca", txtDefeitos.Text)
                        Declaracoes.TrataRetorno(Declaracoes.iRetorno)
                    End If

                    Declaracoes.iRetorno = Declaracoes.iCFEncerrarConfigMsg_ECF_Daruma("Controle:" & controle.ToString())
                    If Declaracoes.iRetorno <> 1 Then
                        MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                    End If

                    Declaracoes.iRetorno = Declaracoes.iCFEncerrar_ECF_Daruma("0", msg)
                    If Declaracoes.iRetorno <> 1 Then
                        MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                    End If

                ElseIf ConfigurationManager.AppSettings("FISCAL") = "SAT" Then

                    ' SAT - Cupom Eletrônico
                    Try

                        'se não informou cpf pergunta
                        If String.IsNullOrEmpty(Str_CPF) Then
                            Str_CPF = InputBox("Deseja informar o CPF/CNPJ ?").Trim()
                            If Str_CPF.Length > 11 Then
                                Do While Not ValidaCnpj(Str_CPF)
                                    Str_CPF = InputBox("CNPJ Incorreto, informe novamente ?").Trim()
                                Loop
                            Else
                                Do While Not ValidaCpf(Str_CPF)
                                    Str_CPF = InputBox("CPF Incorreto, informe novamente ?").Trim()
                                Loop
                            End If
                        End If

                        ' Abertura Cupom
                        If Not String.IsNullOrEmpty(Str_CPF) Then
                            Declaracoes.iRetorno = Declaracoes.aCFAbrir_SAT_Daruma(Str_CPF, Str_Nome, "")
                        Else
                            Declaracoes.iRetorno = Declaracoes.aCFAbrir_SAT_Daruma("", "", "")
                        End If

                        If Declaracoes.iRetorno <> 1 Then
                            MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                        End If

                        ' Itens Cupom
                        For Each produto As ncDados.nsVenda.dVendaProduto In dadosVendaProdutos
                            Str_Aliquota = produto.aliquota
                            Str_ValorUnit = produto.valor.ToString("N").Replace(".", "")
                            Str_Codigo_Item = produto.codigobarras.Trim()
                            Str_Descricao = produto.descricao.Trim()

                            Declaracoes.iRetorno = Declaracoes.aCFVender_SAT_Daruma(Str_Aliquota, produto.quantidade.ToString("N"), Str_ValorUnit, "D$", "0,00", Str_Codigo_Item, "UND", Str_Descricao)

                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        Next

                        'Desconto
                        Declaracoes.iRetorno = Declaracoes.aCFTotalizar_SAT_Daruma("D$", txtDesconto.Text)
                        If Declaracoes.iRetorno <> 1 Then
                            MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                        End If

                        ' Meios de pagamento
                        If CDec(txtDinheiro.Text) > 0.001 Then
                            '01 - Dinheiro
                            Dim dinheiro As String = txtDinheiro.Text.Replace(".", "")
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Dinheiro", dinheiro, "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtCheque.Text) > 0.001 Then
                            '02 - Cheque
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Cheque", txtCheque.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtChequePre.Text) > 0.001 Then
                            '02 - Cheque
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Cheque", txtChequePre.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtCartaoDebito.Text) > 0.001 Then
                            '04 - Cartão de Débito
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Cartão de Débito", txtCartaoDebito.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtCartaoCredito.Text) > 0.001 Then
                            '03 - Cartão de Crédito
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Cartão de Crédito", txtCartaoCredito.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtCrediario.Text) > 0.001 Then
                            '05 - Crédito Loja
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Crédito Loja", txtCrediario.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtPix.Text) > 0.001 Then
                            '06 - Pix
                            Dim pix As String = txtPix.Text.Replace(".", "")
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("pix", pix, "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtTroca.Text) > 0.001 Then
                            '99 - Outros (Troca)
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Outros", txtTroca.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtVale.Text) > 0.001 Then
                            '99 - Outros (Vale)
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Outros", txtVale.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If
                        If CDec(txtDefeitos.Text) > 0.001 Then
                            '99 - Outros (Defeitos)
                            Declaracoes.iRetorno = Declaracoes.aCFEfetuarPagamento_SAT_Daruma("Outros", txtDefeitos.Text.Replace(".", ""), "")
                            If Declaracoes.iRetorno <> 1 Then
                                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                            End If
                        End If

                        Declaracoes.iRetorno = Declaracoes.tCFEncerrar_SAT_Daruma("", "Controle:" & controle.ToString())
                        If Declaracoes.iRetorno <> 1 Then
                            MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                ElseIf ConfigurationManager.AppSettings("FISCAL") = "ONLINE" Then

                    ' SAT - Cupom Eletrônico
                    Try

                        'se não informou cpf pergunta
                        If String.IsNullOrEmpty(Str_CPF) Then
                            Dim resposta As String = InputBox("Deseja informar o CPF/CNPJ? (deixe em branco para ignorar)").Trim()

                            ' Se o usuário não quiser informar, simplesmente seguimos.
                            If String.IsNullOrEmpty(resposta) Then
                                Str_CPF = ""
                            Else
                                Str_CPF = resposta

                                ' Decide se valida como CNPJ ou CPF apenas se for informado.
                                If Str_CPF.Length > 11 Then
                                    ' Validação de CNPJ
                                    While Not ValidaCnpj(Str_CPF)
                                        Str_CPF = InputBox("CNPJ incorreto. Informe novamente ou deixe em branco para cancelar.").Trim()
                                        If String.IsNullOrEmpty(Str_CPF) Then Exit While
                                    End While
                                Else
                                    ' Validação de CPF
                                    While Not ValidaCpf(Str_CPF)
                                        Str_CPF = InputBox("CPF incorreto. Informe novamente ou deixe em branco para cancelar.").Trim()
                                        If String.IsNullOrEmpty(Str_CPF) Then Exit While
                                    End While
                                End If
                            End If
                        End If

                        Dim meiosPagamentos As New List(Of MeioPagamentoNascom)

                        ' Meios de pagamento
                        If CDec(txtDinheiro.Text) > 0.001 Then
                            '01 - Dinheiro
                            Dim dinheiro As String = txtDinheiro.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "01"
                            pagamentoMeio.DescricaoPagamento = "Dinheiro"
                            pagamentoMeio.Valor = dinheiro
                            meiosPagamentos.Add(pagamentoMeio)

                        End If
                        If CDec(txtCheque.Text) > 0.001 Then
                            '02 - Cheque
                            Dim cheque As String = txtCheque.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "02"
                            pagamentoMeio.DescricaoPagamento = "Cheque"
                            pagamentoMeio.Valor = cheque
                            meiosPagamentos.Add(pagamentoMeio)
                        End If
                        If CDec(txtChequePre.Text) > 0.001 Then
                            '02 - Cheque

                            Dim chequePre As String = txtChequePre.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "02"
                            pagamentoMeio.DescricaoPagamento = "Cheque"
                            pagamentoMeio.Valor = chequePre
                            meiosPagamentos.Add(pagamentoMeio)
                        End If
                        If CDec(txtCartaoDebito.Text) > 0.001 Then
                            '04 - Cartão de Débito

                            Dim cartaoDebito As String = txtCartaoDebito.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "04"
                            pagamentoMeio.DescricaoPagamento = "Cartão de Débito"
                            pagamentoMeio.Valor = cartaoDebito
                            meiosPagamentos.Add(pagamentoMeio)

                        End If
                        If CDec(txtCartaoCredito.Text) > 0.001 Then
                            '03 - Cartão de Crédito

                            Dim cartaoCredito As String = txtCartaoCredito.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "03"
                            pagamentoMeio.DescricaoPagamento = "Cartão de Crédito"
                            pagamentoMeio.Valor = cartaoCredito
                            meiosPagamentos.Add(pagamentoMeio)

                        End If
                        If CDec(txtCrediario.Text) > 0.001 Then
                            '05 - Crédito Loja

                            Dim crediarioPagamento As String = txtCrediario.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "05"
                            pagamentoMeio.DescricaoPagamento = "Crédito Loja"
                            pagamentoMeio.Valor = crediarioPagamento
                            meiosPagamentos.Add(pagamentoMeio)

                        End If
                        If CDec(txtPix.Text) > 0.001 Then
                            '06 - Pix

                            Dim pixPagamento As String = txtPix.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "06"
                            pagamentoMeio.DescricaoPagamento = "PIX"
                            pagamentoMeio.Valor = pixPagamento
                            meiosPagamentos.Add(pagamentoMeio)
                        End If
                        If CDec(txtTroca.Text) > 0.001 Then
                            '99 - Outros (Troca)

                            Dim troca As String = txtTroca.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "99"
                            pagamentoMeio.DescricaoPagamento = "Troca"
                            pagamentoMeio.Valor = troca
                            meiosPagamentos.Add(pagamentoMeio)

                        End If
                        If CDec(txtVale.Text) > 0.001 Then
                            '99 - Outros (Vale)

                            Dim vale As String = txtVale.Text.Replace(".", "")
                            Dim pagamentoMeio As New MeioPagamentoNascom()
                            pagamentoMeio.CodigoPagamento = "99"
                            pagamentoMeio.DescricaoPagamento = "Vale"
                            pagamentoMeio.Valor = vale
                            meiosPagamentos.Add(pagamentoMeio)
                        End If
                        If CDec(txtDefeitos.Text) > 0.001 Then
                            '99 - Outros (Defeitos)

                            Dim defeito As String = txtDefeitos.Text.Replace(".", "")
                            Dim pagamento As New MeioPagamentoNascom()
                            pagamento.CodigoPagamento = "99"
                            pagamento.DescricaoPagamento = "Defeitos"
                            pagamento.Valor = defeito
                            meiosPagamentos.Add(pagamento)

                        End If

                        Dim lista = ConverterLista(dadosVendaProdutos.ToList)
                        Dim chave = NFCe65.GerarNF(lista, certificadoCarregado, meiosPagamentos, Str_CPF, controle.ToString())
                        regraVenda.Alterar(controle.ToString(), chave)

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else

                    For i As Integer = 1 To qtdImpressao
                        objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

                        'objImpressao.Write("123456789012345678901234567890123456789012345678")
                        objImpressao.Write("")
                        objImpressao.Write("Loja:" & mdiPrincipal.gLoja.nomeFantasia)
                        If Not String.IsNullOrEmpty(mdiPrincipal.gLoja.logradouro) Then
                            objImpressao.Write("End.:" & mdiPrincipal.gLoja.logradouro & "  " & mdiPrincipal.gLoja.numero)
                        End If
                        If Not IsNothing(mdiPrincipal.gLoja.telefone) Then
                            objImpressao.Write("Tel.:" & mdiPrincipal.gLoja.telefone)
                        End If
                        objImpressao.Write("------------------------------------------------")
                        objImpressao.Write("Emissao:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle:" & controle.ToString())
                        objImpressao.Write("")
                        objImpressao.Write("Vendedor:" & lblVendedor.Text & "  Caixa:" & System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL"))
                        objImpressao.Write("")
                        objImpressao.Write("Cliente:" & ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(txtCliente.Text))
                        objImpressao.Write(vbCrLf)
                        For Each linha As String In lstFita.Items
                            objImpressao.Write(ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(linha))
                        Next
                        objImpressao.Write(vbCrLf)
                        objImpressao.Write("------------------------------------------------")
                        objImpressao.Write("DESCONTO : " & CDec(txtDesconto.Text).ToString("C"))
                        objImpressao.Write("TOTAL    : " & CDec(lblTotal.Text).ToString("C"))
                        objImpressao.Write("RECEBIDO : " & CDec(lblRecebido.Text).ToString("C"))
                        objImpressao.Write("TROCO    : " & CDec(lblTroco.Text).ToString("C"))
                        objImpressao.Write("------------------------------------------------")
                        If CDec(txtDinheiro.Text) > 0.001 Then
                            objImpressao.Write("DINHEIRO  : " & CDec(txtDinheiro.Text).ToString("C"))
                        End If
                        If CDec(txtPix.Text) > 0.001 Then
                            objImpressao.Write("PIX       : " & CDec(txtPix.Text).ToString("C"))
                        End If
                        If CDec(txtCheque.Text) > 0.001 Then
                            objImpressao.Write("CHEQUE    : " & CDec(txtCheque.Text).ToString("C"))
                        End If
                        If CDec(txtChequePre.Text) > 0.001 Then
                            objImpressao.Write("CHEQUE PRE: " & CDec(txtChequePre.Text).ToString("C"))
                        End If
                        If CDec(txtCartaoDebito.Text) > 0.001 Then
                            objImpressao.Write("CARTAO DEB: " & CDec(txtCartaoDebito.Text).ToString("C"))
                        End If
                        If CDec(txtCartaoCredito.Text) > 0.001 Then
                            objImpressao.Write("CARTAO CRE: " & CDec(txtCartaoCredito.Text).ToString("C"))
                        End If
                        If CDec(txtCrediario.Text) > 0.001 Then
                            objImpressao.Write("CREDIARIO : " & CDec(txtCrediario.Text).ToString("C"))
                        End If
                        If CDec(txtTroca.Text) > 0.001 Then
                            objImpressao.Write("TROCA     : " & CDec(txtTroca.Text).ToString("C"))
                        End If
                        If CDec(txtVale.Text) > 0.001 Then
                            objImpressao.Write("VALE      : " & CDec(txtVale.Text).ToString("C"))
                        End If
                        If CDec(txtDefeitos.Text) > 0.001 Then
                            objImpressao.Write("DEFEITOS  : " & CDec(txtDefeitos.Text).ToString("C"))
                        End If
                        objImpressao.Write("------------------------------------------------")
                        objImpressao.Write(msg)
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.Write("")
                        objImpressao.EndWrite()

                    Next
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao imprimir: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Venda concluída em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle: " & controle.ToString())
        End If
    End Sub
    Private Shared Async Function CarregarCertificadoAsync(caminhoCertificado As String,
                                                       senhaCertificado As String,
                                                       certificado As CertificadoDigital) As Task(Of X509Certificate2)
        ' Executa o carregamento do certificado em uma thread separada (sem travar a UI)
        Return Await Task.Run(Function()
                                  Return certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado)
                              End Function)
    End Function
    Public Shared Function ConverterLista(listaOrigem As List(Of ncDados.nsVenda.dVendaProduto)) As List(Of LibNF65.Modelo.ProdutoVendido)
        Dim listaDestino As New List(Of LibNF65.Modelo.ProdutoVendido)
        Dim contador As Integer = 0

        If listaOrigem Is Nothing Then
            Return listaDestino
        End If

        For Each item As ncDados.nsVenda.dVendaProduto In listaOrigem

            contador = contador + 1

            Dim novoItem As New LibNF65.Modelo.ProdutoVendido

            novoItem.controle = item.controle
            novoItem.produtoId = item.produtoId
            novoItem.itemId = contador
            novoItem.quantidade = item.quantidade
            novoItem.valor = item.valor
            novoItem.codigobarras = item.codigobarras
            novoItem.descricao = item.descricao
            novoItem.referencia = item.referencia
            novoItem.aliquota = item.aliquota
            novoItem.valorTributacao = Double.Parse(item.valor.ToString()) * (Double.Parse(item.aliquota) / 100)
            listaDestino.Add(novoItem)
        Next

        Return listaDestino
    End Function
    Private Sub Cliente()
        Dim formCliente As New fClienteLista
        formCliente.filtro = New ncDados.nsCliente.dCliente()
        formCliente.ShowDialog()
        If formCliente.filtro.nome <> "" Then
            Me.txtIdCliente.Text = formCliente.filtro.cid
            Me.txtCliente.Text = formCliente.filtro.nome
            Me.txtCliente.Tag = formCliente.filtro.cid
            Me.txtCliente.ForeColor = IIf(formCliente.filtro.situacao = "N", Color.Red, Color.Black)
            If formCliente.filtro.cpf <> "" Then
                Me.txtCliente.Text += ", CPF: " & formCliente.filtro.cpf
            End If
        End If

    End Sub
    Private Sub Configuracao_Pix()
        Dim formPixConfig As New fConfigPix
        formPixConfig.ShowDialog()
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F1 Then
            Cliente()
        End If
    End Sub

    Private Sub cboCondicao_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicao.SelectedIndexChanged
        If cboCondicao.Text = "PARCELADO" Then
            txtParcelas.Enabled = True
            txtCrediario.Enabled = True
        Else
            txtParcelas.Enabled = False
            txtCrediario.Enabled = False
            txtParcelas.Text = "1"
            txtCrediario.Text = 0.ToString("N")
        End If

    End Sub

    Private Sub txtDinheiro_KeyPress(ByVal tecla As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDinheiro.KeyPress, txtVale.KeyPress, txtTroca.KeyPress, txtParcelas.KeyPress, txtDesconto.KeyPress, txtDefeitos.KeyPress, txtCrediario.KeyPress, txtChequePre.KeyPress, txtCheque.KeyPress, txtCartaoDebito.KeyPress, txtCartaoCredito.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub btoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCliente.Click
        Cliente()
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

                cboCondicao.ValueMember = "desconto"
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

    Private Sub btoGerarEFD_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Consultar(tx As String)
        Dim regras As New rPix
        Dim pix As dPix


        pix = regras.Consultar(tx)

        If IsNothing(pix) Then
            Exit Sub
        End If


        txtValorPIX.Text = pix.Original
        txtPix.Text = pix.Original



        If pix.Status = Nothing Then
            txtStatus.Text = "Cobrar"
            pix.Status = "NOVA"
        Else
            txtStatus.Text = pix.Status
        End If

        txtTxId.Text = pix.TxId
        picQRCode.Image = Nothing
        btnPix.Image = Nothing
        btnPix.Text = ""

        Dim folder As String = ConfigurationManager.AppSettings("pathPIX")
        Dim filename As String = BuscarImagem(folder, pix)
        If String.IsNullOrEmpty(filename) And folder = "" Then
            Exit Sub
        End If



        btnPix.Image = nascomercio.My.Resources.Resources.cobrar
        Select Case pix.Status.ToUpper()

            Case "NOVA"
                txtStatus.Text = ""
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = "Consultar"
            Case "ATIVA"
                txtStatus.Text = "Criada"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = "Consultar"
                picQRCode.Image = ResizeImage(System.Drawing.Image.FromFile(filename))
            Case "PENDING"
                txtStatus.Text = "Criada"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = "Consultar"
                picQRCode.Image = ResizeImage(System.Drawing.Image.FromFile(filename))
            Case "CONCLUIDA"
                txtStatus.Text = "Pago"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = ""
                picQRCode.Image = ResizeImage(System.Drawing.Image.FromFile(folder + "\pago.png"))
            Case "APPROVED"
                txtStatus.Text = "Pago"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = ""
                picQRCode.Image = ResizeImage(System.Drawing.Image.FromFile(folder + "\pago.png"))
            Case "REMOVIDA_PELO_USUARIO_RECEBEDOR"
                txtStatus.Text = "Removida User"
                btnPix.Text = ""
            Case "REMOVIDA_PELO_PSP"
                txtStatus.Text = "Removida PSP"
                btnPix.Text = ""
            Case "EXPIRADA"
                txtStatus.Text = "Expirada"
                btnPix.Text = ""

        End Select

        txtObs.Text = String.Format($"{pix.Observacao} Controle:  {Me.lblControle.Text} {pix.DataHora}")

        txtUrlPix.Text = pix.UrlPix

    End Sub
    Private Sub Cadastrar()
        Dim regras As rPix

        regras = New rPix
        Dim pagamentos = New ColecaoPix
        Dim dados As New dPix


        Try
            dados.Original = txtValorPIX.Text
            dados.Observacao = txtObs.Text
            dados.Controle = lblControle.Text
            pagamentos = regras.fIncluir(dados)
            txtTxId.Text = "PIX Cadastrado!"
            txtStatus.Text = "A Cobrar"
            picQRCode.Tag = pagamentos


        Catch ex As Exception

            Throw New ExcecaoNascomercio("Erro em fIncluir pix [" & Me.ToString() & "] - " & ex.Message)

        End Try
    End Sub
    Private Sub RecuperarDadosPix()
        Dim regras As rPix
        regras = New rPix
        Dim dados As New dPix
        Dim _dados As New dPix
        Dim colecaoPIX As List(Of dPix) = New List(Of dPix)

        Try
            dados.Original = txtValorPIX.Text
            dados.Observacao = txtObs.Text
            dados.Controle = lblControle.Text
            Dim arPix = regras.Consultar(dados)

            If Not arPix Is Nothing Then
                arPix = arPix.ToArray()
                dados = arPix(0)
                txtPix.Text = dados.Original
                txtValorPIX.Text = dados.Original
                txtObs.Text = dados.Observacao
                txtTxId.Text = "PIX Cadastrado!"
                txtStatus.Text = "A Cobrar"
            End If

        Catch ex As Exception

            Throw New ExcecaoNascomercio("Erro em recuperar dados do pix [" & Me.ToString() & "] - " & ex.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub chkPIX_CheckedChanged(sender As Object, e As EventArgs) Handles chkPIX.CheckedChanged


        If Me.chkPIX.Checked = True Then
            panelPIX.Visible = True
            panelLista.Visible = False
        Else
            panelLista.Visible = True
            panelPIX.Visible = False
        End If

        txtStatus.Text = ""
        txtTxId.Text = ""
        txtObs.Text = ""
        txtUrlPix.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'Dim id As String = "22137471"

    End Sub
    Public Shared Function ResizeImage(ByVal InputImage As System.Drawing.Image) As System.Drawing.Image
        Return New System.Drawing.Bitmap(InputImage, New System.Drawing.Size(200, 200))
    End Function
    Private Function BuscarImagem(folder As String, pix As dPix) As String

        Dim filter As String

        If String.IsNullOrEmpty(pix.TxId) Then
            Exit Function
        End If

        If Not String.IsNullOrEmpty(pix.TxId) Then
            filter = $"{pix.TxId}.png"
        Else
            filter = "*.png"
        End If

        Dim files() As String = IO.Directory.GetFiles(folder, filter)
        Dim nomeFile As String = String.Empty

        For Each sFile As String In files
            If sFile.Contains(pix.TxId) Then
                nomeFile = sFile
                Exit For
            End If
        Next

        BuscarImagem = nomeFile

    End Function

    Private Sub txtPix_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPix.KeyUp
        txtValorPIX.Text = txtPix.Text
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        'Declare um variável do tipo Timer: 
        Dim tempo As New System.Timers.Timer(50000) '5000 = 5 segundos

        'Adicione um handler para capturar o evento tick do timer: 
        AddHandler tempo.Elapsed, AddressOf DispararTimer

        'Adicione a sub que representa o evento tick do timer:


        'Por último, no load do formulário, habilite o timer:
        tempo.Enabled = True
    End Sub

    Public Sub DispararTimer()

    End Sub

    Private Sub txtPix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPix.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub txtPix_Leave(sender As Object, e As EventArgs) Handles txtPix.Leave,
                                                                txtDinheiro.Leave,
                                                                txtCartaoCredito.Leave,
                                                                txtCrediario.Leave,
                                                                txtChequePre.Leave,
                                                                txtCheque.Leave,
                                                                txtCartaoDebito.Leave,
                                                                txtVale.Leave,
                                                                txtDesconto.Leave


        'Mostra informações de valores recebidos e troco
        verificaCampos()
        recalculaRecebido()
        formataCampos()
    End Sub

    Private Sub btnPix_Click(sender As Object, e As EventArgs) Handles btnPix.Click

        If btnPix.Text = "Cobrar" Then

            If txtPix.Text = "0,00" Or txtPix.Text = "0" Then
                MessageBox.Show("É preciso informar um valor para a cobrança")
                txtPix.Select()
            Else
                Cadastrar()
                btnPix.Text = "Consultar"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
            End If


        ElseIf btnPix.Text = "Nova Cobrança" Then
            Cadastrar()
            btnPix.Text = "Cobrar"
            btnPix.Image = nascomercio.My.Resources.Resources.cobrar

            txtPix.Text = "0,00"
            txtValorPIX.Text = "0,00"
            txtObs.Text = ""
            txtTxId.Text = ""
            txtStatus.Text = ""
            txtUrlPix.Text = ""
            picQRCode.Image = Nothing

        Else
            If txtTxId.Text.Length <> 36 Then
                txtTxId.Text = "Consulte Novamente..."
            End If
            Consultar("")
        End If
    End Sub

    Private Sub fPagamento_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub btnConfigPix_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        If txtUrlPix.Text.Trim() <> "" Then
            Clipboard.SetText(txtUrlPix.Text)
        End If
    End Sub

    Private Sub picQRCode_Click(sender As Object, e As EventArgs) Handles picQRCode.Click

    End Sub

    Private Sub panelPIX_Paint(sender As Object, e As PaintEventArgs) Handles panelPIX.Paint

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub LimparControles()
        txtValorPIX.Text = ""
        txtStatus.Text = ""
        txtTxId.Text = ""
        txtObs.Text = ""
        txtUrlPix.Text = ""
    End Sub
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click

        PanelListPix.Visible = True
        panelPIX.Visible = False
        panelLista.Visible = False

        Dim regras As rPix
        regras = New rPix
        Dim dados As New dPix
        Dim _dados As New dPix
        Dim colecaoPIX As List(Of dPix) = New List(Of dPix)
        Dim li As ListViewItem

        Try

            LimparControles()
            Me.lstPix.View = View.Details
            Me.lstPix.GridLines = True
            Me.lstPix.FullRowSelect = True
            Me.lstPix.Columns.Clear()
            Me.lstPix.Items.Clear()

            Me.lstPix.Columns.Add("TX").Width = 220
            Me.lstPix.Columns.Add("Valor").Width = 60
            Me.lstPix.Columns.Add("Data").Width = 100
            Me.lstPix.Columns.Add("Status").Width = 100

            colecaoPIX = regras.Consultar(dados)

            If colecaoPIX Is Nothing Then
                MessageBox.Show("Não há ítens na lista.")
                Exit Sub
            End If

            For Each item As dPix In colecaoPIX
                li = New ListViewItem
                li.Text = item.TxId
                li.SubItems.Add(item.Original)
                li.SubItems.Add(item.DataHora.ToString("dd/MM/yy HH:mm"))
                If item.Status = "CONCLUIDA" Then
                    item.Status = "PAGO"
                End If

                li.SubItems.Add(item.Status)
                Me.lstPix.Items.Add(li)
            Next

        Catch ex As Exception

            Throw New ExcecaoNascomercio("Erro em recuperar dados do pix [" & Me.ToString() & "] - " & ex.Message)

        End Try







    End Sub

    Private Sub lstPix_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPix.SelectedIndexChanged


    End Sub

    Private Sub lstPix_DoubleClick(sender As Object, e As EventArgs) Handles lstPix.DoubleClick
        PanelListPix.Visible = False
        panelPIX.Visible = True
        Dim haSelecionado As Boolean = False

        haSelecionado = Me.lstPix.SelectedItems.Count > 0

        Dim tx As String

        If haSelecionado = True Then
            tx = Me.lstPix.SelectedItems.Item(0).Text
            Consultar(tx)
        Else
            Consultar("")
        End If




    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnOut_Click(sender As Object, e As EventArgs)
        PanelListPix.Visible = False
        panelPIX.Visible = True
        panelLista.Visible = False
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        PanelListPix.Visible = False
        panelPIX.Visible = True
        panelLista.Visible = False
    End Sub

    Private Sub txtPix_TextChanged(sender As Object, e As EventArgs) Handles txtPix.TextChanged

    End Sub

    Private Sub txtDesconto_Leave(sender As Object, e As EventArgs) Handles txtPix.Leave,
                                                                txtDinheiro.Leave,
                                                                txtCartaoCredito.Leave,
                                                                txtCrediario.Leave,
                                                                txtChequePre.Leave,
                                                                txtCheque.Leave,
                                                                txtCartaoDebito.Leave,
                                                                txtVale.Leave,
                                                                txtDesconto.Leave


        'Mostra informações de valores recebidos e troco
        verificaCampos()
        recalculaRecebido()
        formataCampos()

    End Sub

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            FiltrarCliente()
        End If
    End Sub

    Private Sub txtIdCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            FiltrarCliente()
        End If
    End Sub

    Private Sub txtIdCliente_Leave(sender As Object, e As EventArgs) Handles txtIdCliente.Leave
        FiltrarCliente()
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
End Class