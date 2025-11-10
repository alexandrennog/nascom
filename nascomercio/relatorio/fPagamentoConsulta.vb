Imports System.Configuration
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports System.Web.UI.WebControls
Imports LibNF65
Imports ncComum.nsConstantes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog
Imports ncDados
Imports ncDados.nsParametro
Imports ncDados.nsProduto
Imports ncRegras
Imports ncRegras.nsParametro
Imports ncRegras.nsProduto
Imports Unimake.Business.DFe.Xml.SNCM
Imports Unimake.Business.Security

Public Class fPagamentoConsulta
    Private certificadoCarregado As New X509Certificate2
    Public dadosVendaProdutos As New ncDados.nsVenda.ColecaoVendaProduto
    Public condicao As String
    Public parcelas As String
    Public desconto As String
    Public crediario As String
    Private dadosParametro As dParametro
    Private regraParametro As rParametro

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ''' <summary>
    ''' Mostra informações de valores recebidos e troco
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub calculaRecebido()
        ' Soma recebidos
        lblRecebido.Text = CDec(CDec(txtDinheiro.Text) + CDec(txtCheque.Text) + CDec(txtChequePre.Text) _
        + CDec(txtCartaoDebito.Text) + CDec(txtCartaoCredito.Text) + CDec(txtCrediario.Text) _
        + CDec(txtTroca.Text) + CDec(txtVale.Text) + CDec(txtPix.Text) + CDec(txtDefeitos.Text)).ToString("N")

        If CDec(lblRecebido.Text) <= CDec(lblTotal.Text) Then
            lblFalta.Text = CDec(CDec(lblTotal.Text) - CDec(lblRecebido.Text)).ToString("N")
            lblTroco.Text = 0.ToString("N")
        Else
            lblTroco.Text = CDec(CDec(lblRecebido.Text) - CDec(lblTotal.Text)).ToString("N")
            lblFalta.Text = 0.ToString("N")
        End If
    End Sub

    Private Sub fPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTroco.Text = 0.ToString("N")
        lblRecebido.Text = 0.ToString("N")
        lblVale.Text = 0.ToString("N")

        CarregarComboCondicao()
        cboCondicao.Text = condicao

        Me.lblLoja.Text = mdiPrincipal.gLoja.nomeFantasia

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
    End Sub

    Private Sub txtDinheiro_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDinheiro.Leave,
                                                                                               txtCartaoCredito.Leave,
                                                                                               txtCrediario.Leave,
                                                                                               txtChequePre.Leave,
                                                                                               txtCheque.Leave,
                                                                                               txtCartaoDebito.Leave,
                                                                                               txtVale.Leave
        'Mostra informações de valores recebidos e troco
        verificaCampos()
        calculaRecebido()
        formataCampos()
    End Sub

    Private Sub formataCampos()
        txtDinheiro.Text = CDec(txtDinheiro.Text).ToString("N")
        txtCheque.Text = CDec(txtCheque.Text).ToString("N")
        txtChequePre.Text = CDec(txtChequePre.Text).ToString("N")
        txtCartaoCredito.Text = CDec(txtCartaoCredito.Text).ToString("N")
        txtCartaoDebito.Text = CDec(txtCartaoDebito.Text).ToString("N")
        txtCrediario.Text = CDec(txtCrediario.Text).ToString("N")
        txtVale.Text = CDec(txtVale.Text).ToString("N")
        txtPix.Text = CDec(txtPix.Text).ToString("N")
    End Sub

    Private Sub verificaCampos()
        If txtDinheiro.Text.Trim().Equals("") Then
            txtDinheiro.Text = 0.ToString("N")
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
        If txtPix.Text.Trim().Equals("") Then
            txtPix.Text = 0.ToString("N")
        End If
    End Sub
    Private Async Function CarregarComboCondicaoAsync() As Task

        Dim certificado As New CertificadoDigital()

        Dim caminhoCertificado As String = ConfigurationManager.AppSettings("CertificadoArquivo")
        Dim senhaCertificado As String = ConfigurationManager.AppSettings("CertificadoSenha")

        certificadoCarregado = Await CarregarCertificadoAsync(caminhoCertificado, senhaCertificado, certificado)
    End Function
    Private Shared Async Function CarregarCertificadoAsync(caminhoCertificado As String,
                                                       senhaCertificado As String,
                                                       certificado As CertificadoDigital) As Task(Of X509Certificate2)
        ' Executa o carregamento do certificado em uma thread separada (sem travar a UI)
        Return Await Task.Run(Function()
                                  Return certificado.CarregarCertificadoDigitalA1(caminhoCertificado, senhaCertificado)
                              End Function)
    End Function
    Private Sub btoImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Dim controle As Integer
        Dim retornoCrediario As Boolean = True
        Dim retornoCheque As Boolean = True
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro

        If CDec(lblRecebido.Text) >= CDec(lblTotal.Text) Then

            Try
                controle = lblControle.Text
                Imprime(controle)
                ImprimeNFe(controle)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Erro ao incluir venda!")
            End Try

            LimpaCampos()
            Me.Close()

            Try
                ' Fechar tela caixa
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

    End Sub

    Private Sub LimpaCampos()
        txtCliente.Text = ""
        lblControle.Text = ""
        lblEmissao.Text = ""
        lblVendedor.Text = ""
        lblLoja.Text = ""
        lblRecebido.Text = "0"
    End Sub

    Private Sub Imprime(ByVal controle As Integer)

        Dim objImpressao As ncComum.Impressao
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro

        objImpressao = New ncComum.Impressao()

        If MessageBox.Show("Deseja imprimir comprovante de venda?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                ' Mensagem final fita
                Dim msg As String = "Agradecemos a preferencia - Volte sempre"
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Mensagem)
                If Not IsNothing(dadosParametro) Then
                    msg = dadosParametro.valor
                End If

                objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

                'objImpressao.Write("123456789012345678901234567890123456789012345678")
                objImpressao.Write("Loja:" & mdiPrincipal.gLoja.nomeFantasia)
                If Not String.IsNullOrEmpty(mdiPrincipal.gLoja.logradouro) Then
                    objImpressao.Write("End.:" & mdiPrincipal.gLoja.logradouro & "  " & mdiPrincipal.gLoja.numero)
                End If
                If Not IsNothing(mdiPrincipal.gLoja.telefone) Then
                    objImpressao.Write("Tel.:" & mdiPrincipal.gLoja.telefone)
                End If
                objImpressao.Write("------------------------------------------------")
                objImpressao.Write("Emissao:" & lblEmissao.Text & "    Controle:" & controle.ToString())
                objImpressao.Write("Vendedor:" & lblVendedor.Text & "  Caixa:" & System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL"))
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

            Catch ex As Exception
                MessageBox.Show("Erro ao imprimir: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Venda concluída em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle: " & controle.ToString())
        End If
    End Sub
    Private Sub ImprimeNFe(ByVal controle As Integer)

        Dim objImpressao As ncComum.Impressao
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim objNFCe As New NasNFCe
        Dim regraVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Dim dadosVenda As ncDados.nsVenda.dVenda
        Dim objVenda As ncRegras.nsVenda.rVenda

        objImpressao = New ncComum.Impressao()

        'NFCe65.GerarNF(Lista, certificadoCarregado)

        'objNFCe.ImprimirDANFe(chaveAcesso)

        'objNFCe.ConsultarCupom(configuracao, chaveAcesso)

        objVenda = New ncRegras.nsVenda.rVenda()
        dadosVenda = New ncDados.nsVenda.dVenda()
        dadosVenda.controle = controle
        vendas = objVenda.Consultar(dadosVenda)
        Dim chaveRetorno As String = ""

        If Not IsNothing(vendas) Then
            For Each dadosVenda In vendas
                chaveRetorno = dadosVenda.Chave.ToString()
                objNFCe.ImprimirDANFe(chaveRetorno)
            Next
        End If

        'If MessageBox.Show("Deseja imprimir comprovante de venda?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

        '    Try
        '        ' Mensagem final fita
        '        Dim msg As String = "Agradecemos a preferencia - Volte sempre"
        '        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.Mensagem)
        '        If Not IsNothing(dadosParametro) Then
        '            msg = dadosParametro.valor
        '        End If

        '        objImpressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("CUPOM"))

        '        'objImpressao.Write("123456789012345678901234567890123456789012345678")
        '        objImpressao.Write("Loja:" & mdiPrincipal.gLoja.nomeFantasia)
        '        If Not String.IsNullOrEmpty(mdiPrincipal.gLoja.logradouro) Then
        '            objImpressao.Write("End.:" & mdiPrincipal.gLoja.logradouro & "  " & mdiPrincipal.gLoja.numero)
        '        End If
        '        If Not IsNothing(mdiPrincipal.gLoja.telefone) Then
        '            objImpressao.Write("Tel.:" & mdiPrincipal.gLoja.telefone)
        '        End If
        '        objImpressao.Write("------------------------------------------------")
        '        objImpressao.Write("Emissao:" & lblEmissao.Text & "    Controle:" & controle.ToString())
        '        objImpressao.Write("Vendedor:" & lblVendedor.Text & "  Caixa:" & System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL"))
        '        objImpressao.Write("Cliente:" & ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(txtCliente.Text))
        '        objImpressao.Write(vbCrLf)
        '        For Each linha As String In lstFita.Items
        '            objImpressao.Write(ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(linha))
        '        Next
        '        objImpressao.Write(vbCrLf)
        '        objImpressao.Write("------------------------------------------------")
        '        objImpressao.Write("DESCONTO : " & CDec(txtDesconto.Text).ToString("C"))
        '        objImpressao.Write("TOTAL    : " & CDec(lblTotal.Text).ToString("C"))
        '        objImpressao.Write("RECEBIDO : " & CDec(lblRecebido.Text).ToString("C"))
        '        objImpressao.Write("TROCO    : " & CDec(lblTroco.Text).ToString("C"))
        '        objImpressao.Write("------------------------------------------------")
        '        If CDec(txtDinheiro.Text) > 0.001 Then
        '            objImpressao.Write("DINHEIRO  : " & CDec(txtDinheiro.Text).ToString("C"))
        '        End If
        '        If CDec(txtPix.Text) > 0.001 Then
        '            objImpressao.Write("PIX       : " & CDec(txtPix.Text).ToString("C"))
        '        End If
        '        If CDec(txtCheque.Text) > 0.001 Then
        '            objImpressao.Write("CHEQUE    : " & CDec(txtCheque.Text).ToString("C"))
        '        End If
        '        If CDec(txtChequePre.Text) > 0.001 Then
        '            objImpressao.Write("CHEQUE PRE: " & CDec(txtChequePre.Text).ToString("C"))
        '        End If
        '        If CDec(txtCartaoDebito.Text) > 0.001 Then
        '            objImpressao.Write("CARTAO DEB: " & CDec(txtCartaoDebito.Text).ToString("C"))
        '        End If
        '        If CDec(txtCartaoCredito.Text) > 0.001 Then
        '            objImpressao.Write("CARTAO CRE: " & CDec(txtCartaoCredito.Text).ToString("C"))
        '        End If
        '        If CDec(txtCrediario.Text) > 0.001 Then
        '            objImpressao.Write("CREDIARIO : " & CDec(txtCrediario.Text).ToString("C"))
        '        End If
        '        If CDec(txtTroca.Text) > 0.001 Then
        '            objImpressao.Write("TROCA     : " & CDec(txtTroca.Text).ToString("C"))
        '        End If
        '        If CDec(txtVale.Text) > 0.001 Then
        '            objImpressao.Write("VALE      : " & CDec(txtVale.Text).ToString("C"))
        '        End If
        '        If CDec(txtDefeitos.Text) > 0.001 Then
        '            objImpressao.Write("DEFEITOS  : " & CDec(txtDefeitos.Text).ToString("C"))
        '        End If
        '        objImpressao.Write("------------------------------------------------")
        '        objImpressao.Write(msg)
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.Write("")
        '        objImpressao.EndWrite()

        '    Catch ex As Exception
        '        MessageBox.Show("Erro ao imprimir: " & ex.Message)
        '    End Try
        'Else
        '    MessageBox.Show("Venda concluída em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & "    Controle: " & controle.ToString())
        'End If
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

End Class