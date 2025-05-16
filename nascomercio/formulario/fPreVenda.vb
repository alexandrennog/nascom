Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados.nsCliente
Imports ncDados.nsProduto
Imports ncRegras.nsCliente
Imports ncRegras.nsProduto

Public Class fPreVenda


    Public dadosVendaProdutos As New ncDados.nsVenda.ColecaoVendaProduto

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
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

    Private Sub PesquisarCliente()
        Dim formCliente As New fClienteLista
        formCliente.filtro = New ncDados.nsCliente.dCliente()
        formCliente.ShowDialog()
        If formCliente.filtro.nome <> "" Then
            Me.txtCliente.Text = formCliente.filtro.nome
            Me.txtCliente.Tag = formCliente.filtro.cid
            Me.txtIdCliente.Text = formCliente.filtro.cid
            If formCliente.filtro.cpf <> "" Then
                Me.txtCliente.Text += ", CPF: " & formCliente.filtro.cpf
            End If
        End If

    End Sub

    Private Sub CarregarComboCondicao()
        Dim regras As ncRegras.nsCondicao.rCondicao
        Dim colecao As ncDados.nsCondicao.ColecaoCondicao
        Dim texto As String

        Try

            texto = cboCondicao.Text

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

            cboCondicao.Text = texto

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Condição.")

        End Try


    End Sub

    Private Sub fPagamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTroco.Text = 0.ToString("N")
        lblRecebido.Text = 0.ToString("N")

        CarregarComboCondicao()
        'cboCondicao.Text = condicao
        calculaRecebido()
        formataCampos()
    End Sub

    Private Sub txtDinheiro_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDinheiro.Leave,
                                                                                               txtCartaoCredito.Leave,
                                                                                               txtCrediario.Leave,
                                                                                               txtChequePre.Leave,
                                                                                               txtCheque.Leave,
                                                                                               txtPix.Leave,
                                                                                               txtCartaoDebito.Leave, txtVale.Leave
        'Mostra informações de valores recebidos e troco
        verificaCampos()
        calculaRecebido()
        formataCampos()

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

    Private Sub formataCampos()
        txtDinheiro.Text = CDec(txtDinheiro.Text).ToString("N")
        txtPix.Text = CDec(txtPix.Text).ToString("N")
        txtCheque.Text = CDec(txtCheque.Text).ToString("N")
        txtChequePre.Text = CDec(txtChequePre.Text).ToString("N")
        txtCartaoCredito.Text = CDec(txtCartaoCredito.Text).ToString("N")
        txtCartaoDebito.Text = CDec(txtCartaoDebito.Text).ToString("N")
        txtCrediario.Text = CDec(txtCrediario.Text).ToString("N")
        txtVale.Text = CDec(txtVale.Text).ToString("N")
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Dim controle As Integer
        Dim retorno As DialogResult = Windows.Forms.DialogResult.OK

        If CDec(lblRecebido.Text) >= CDec(lblTotal.Text) Then

            If CDec(txtCrediario.Text) > 0 Then
                If txtCliente.Tag = 0 Then
                    MessageBox.Show("Selecionar um Cliente")
                    Exit Sub
                End If

            End If

            controle = IncluiPreVenda()

            Imprime()

            LimpaCampos()

            Me.Close()

            If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "ORÇAMENTO" Then
                mdiPrincipal.FecharTela()
            Else
                mdiPrincipal.FecharTelaLogin()
            End If

        Else
            MessageBox.Show("Faltam: " & lblFalta.Text)

        End If

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
                    objImpressao.Write("")
                    objImpressao.Write("Loja:" & lblLoja.Text)
                    objImpressao.Write("------------------------------------------------")
                    If System.Configuration.ConfigurationManager.AppSettings("TIPO_TERMINAL") = "ORÇAMENTO" Then
                        objImpressao.Write("ORÇAMENTO em:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle:" & lblControle.Text)
                    Else
                        objImpressao.Write("Venda em:" & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle:" & lblControle.Text)
                    End If
                    objImpressao.Write("")
                    objImpressao.Write("Vendedor:" & lblVendedor.Text)
                    objImpressao.Write("")
                    objImpressao.Write("Cliente:" & txtCliente.Text)
                    objImpressao.Write(vbCrLf)
                    For Each linha As String In lstFita.Items
                        objImpressao.Write(ncComum.nsFuncoes.cFuncoes.RemoverCaracterEspecial(linha))
                    Next
                    objImpressao.Write(vbCrLf)
                    objImpressao.Write("------------------------------------------------")
                    If CDec(txtDesconto.Text) > 0 Then
                        objImpressao.Write("DESCONTO : " & txtDesconto.Text)
                    End If
                    objImpressao.Write("TOTAL    : " & lblTotal.Text)
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("Dirija se ao caixa e apresente este cupom.")
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
            Catch ex As Exception
                MessageBox.Show("Erro ao imprimir: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Venda em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle: " & lblControle.Text)
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

    Private Function IncluiPreVenda() As Integer
        Dim novaVenda As New ncRegras.nsVenda.rPreVenda
        Dim dadosVenda As New ncDados.nsVenda.dVenda
        Dim controle As Integer

        Try
            ' Inclui pré venda
            dadosVenda.controle = Me.lblControle.Text
            dadosVenda.ordemServicoId = Me.lblControle.Tag
            dadosVenda.usuarioId = mdiPrincipal.gUsuario.cid
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
            dadosVenda.Troco = Me.lblTroco.Text
            dadosVenda.Total = Me.lblTotal.Text
            dadosVenda.Troca = Me.txtTroca.Text
            dadosVenda.Vale = Me.txtVale.Text
            dadosVenda.Defeito = Me.txtDefeitos.Text
            dadosVenda.Terminal = System.Configuration.ConfigurationManager.AppSettings("NOME_TERMINAL")
            dadosVenda.Vendedor = lblVendedor.Text

            controle = novaVenda.Alterar(dadosVenda)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return controle

    End Function


    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown, MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            PesquisarCliente()
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

    Private Sub txtDinheiro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDinheiro.KeyPress, txtVale.KeyPress, txtTroca.KeyPress, txtParcelas.KeyPress, txtDesconto.KeyPress, txtDefeitos.KeyPress, txtCrediario.KeyPress, txtChequePre.KeyPress, txtCheque.KeyPress, txtCartaoDebito.KeyPress, txtCartaoCredito.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
        PesquisarCliente()
    End Sub

    Private Sub txtPix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPix.KeyPress
        e.Handled = ncComum.nsFuncoes.cFuncoes.SoNumero(e.KeyChar)
    End Sub

    Private Sub txtPix_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPix.Leave,
                                                                                    txtDinheiro.Leave,
                                                                                    txtCartaoCredito.Leave,
                                                                                    txtCrediario.Leave,
                                                                                    txtChequePre.Leave,
                                                                                    txtCheque.Leave,
                                                                                    txtCartaoDebito.Leave, txtVale.Leave
        'Mostra informações de valores recebidos e troco
        verificaCampos()
        calculaRecebido()
        formataCampos()

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