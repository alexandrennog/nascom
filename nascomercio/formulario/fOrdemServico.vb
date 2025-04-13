Imports ncComum.nsExcecao
Imports ncDados.nsProduto
Imports ncRegras.nsProduto

Public Class fOrdemServico


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub NovaOS()
        Me.lblEmissao.Text = Today.ToString("dd/MM/yyyy")
        Me.lblVendedor.Text = mdiPrincipal.gUsuario.usuario
        Me.lblVendedor.Tag = mdiPrincipal.gUsuario.cid
        Me.lblLoja.Text = mdiPrincipal.gLoja.nomeFantasia
        Me.txtCliente.Tag = 1
        Me.txtControle.Text = RetornaNumeroControle().ToString()
        Me.cboSituacao.Text = "Aberta"
        Me.txtCliente.Focus()

    End Sub

    Public Function RetornaNumeroControle() As Integer
        Dim ordemServico As New ncRegras.nsOrdemServico.rOrdemServico
        Dim controle As Integer

        controle = ordemServico.ConsultarMax()

        Return (controle + 1)

    End Function

    Private Sub fOrdemServico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NovaOS()
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Dim controle As Integer
        Dim retorno As DialogResult = Windows.Forms.DialogResult.OK

        If txtCliente.Tag = 0 Then
            MessageBox.Show("Selecionar um Cliente")
            Exit Sub
        End If

        If Me.Modal Then
            Me.cboSituacao.Text = "Fechada"
            controle = IncluiOrdemServico()
            Me.Close()
        Else
            controle = IncluiOrdemServico()
            txtControle.Text = controle.ToString()
            txtControle.Tag = controle.ToString()

            Imprime()

            LimpaCampos()
            Me.Close()
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
                    objImpressao.Write("ORDEM DE SERVIÇO " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle:" & txtControle.Text)
                    objImpressao.Write("")
                    objImpressao.Write("Vendedor:" & lblVendedor.Text)
                    objImpressao.Write("")
                    objImpressao.Write("Cliente:" & txtCliente.Text)
                    objImpressao.Write("")
                    objImpressao.Write("Veículo:" & txtVeiculo.Text)
                    objImpressao.Write(vbCrLf)
                    objImpressao.Write(vbCrLf)
                    objImpressao.Write("Observacoes")
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write(txtObservacao.Text)
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("")
                    objImpressao.Write("------------------------------------------------")
                    objImpressao.Write("Assinatura")
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
            MessageBox.Show("Ordem de Serviço em: " & Now.ToString("dd/MM/yyyy") & " " & Now.ToString("HH:mm:ss") & " Controle: " & txtControle.Text)
        End If

    End Sub

    Private Sub LimpaCampos()
        txtCliente.Text = ""
        txtControle.Text = ""
        lblEmissao.Text = ""
        lblVendedor.Text = ""
        lblLoja.Text = ""
    End Sub

    Private Function IncluiOrdemServico() As Integer
        Dim novaOS As New ncRegras.nsOrdemServico.rOrdemServico
        Dim dadosOS As New ncDados.nsOrdemServico.dOrdemServico
        Dim controle As Integer
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty

        Try
            tipoMsg = "INCLUSÃO"
            tipoAcao = "i"

            If Not IsNothing(Me.txtControle.Tag) Then
                If Not Me.txtControle.Tag.ToString().Equals(String.Empty) Then
                    If Not Me.txtControle.Tag.Equals(0) Then
                        tipoMsg = "ALTERAÇÃO"
                        tipoAcao = "a"
                    End If
                End If
            End If

            If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                'usuario
                dadosOS.clienteid = Me.txtCliente.Tag
                dadosOS.veiculoid = Me.txtVeiculo.Tag
                dadosOS.emissao = Now
                dadosOS.vendedor = lblVendedor.Text
                dadosOS.loja = lblLoja.Text
                dadosOS.observacoes = txtObservacao.Text
                dadosOS.situacao = cboSituacao.Text
                dadosOS.cid = Me.txtControle.Text

                If tipoAcao.Equals("i") Then
                    ' Inclui OS
                    controle = novaOS.Incluir(dadosOS)
                ElseIf tipoAcao.Equals("a") Then
                    novaOS.Alterar(dadosOS)
                    controle = dadosOS.cid
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return controle

    End Function


    Private Sub txtCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown, MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            PesquisaCliente()
        End If
    End Sub

    Private Sub btoClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoClientes.Click
        PesquisaCliente()
    End Sub

    Private Sub PesquisaCliente()
        Dim formCliente As New fClienteLista
        formCliente.filtro = New ncDados.nsCliente.dCliente()
        formCliente.ShowDialog()
        If formCliente.filtro.nome <> "" Then
            Me.txtCliente.Text = formCliente.filtro.nome
            If formCliente.filtro.celular <> "" Then
                Me.txtCliente.Text += ", Cel." & formCliente.filtro.dddcel & "-" & formCliente.filtro.celular
            End If
            If formCliente.filtro.telefone <> "" Then
                Me.txtCliente.Text += ", Tel." & formCliente.filtro.ddd & "-" & formCliente.filtro.telefone
            End If
            If formCliente.filtro.cpf <> "" Then
                Me.txtCliente.Text += ", CPF: " & formCliente.filtro.cpf
            End If
            Me.txtCliente.Tag = formCliente.filtro.cid
        End If
    End Sub

    Private Sub btoEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiqueta.Click
        Imprime()
    End Sub

    Private Sub btoVeiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVeiculos.Click
        PesquisaVeiculos()
    End Sub

    Private Sub PesquisaVeiculos()
        Dim formVeiculo As New fVeiculoLista
        formVeiculo.filtro = New ncDados.nsVeiculos.dVeiculos()
        formVeiculo.filtro.clienteId = Me.txtCliente.Tag
        formVeiculo.ShowDialog()

        If formVeiculo.filtro.Placa <> "" Then
            Me.txtVeiculo.Tag = formVeiculo.filtro.cid
            Me.txtVeiculo.Text = formVeiculo.filtro.Placa & " " & formVeiculo.filtro.Marca & " - " & formVeiculo.filtro.Modelo & " : " & formVeiculo.filtro.Ano
        End If
    End Sub

    Private Sub txtVeiculo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVeiculo.KeyDown
        If e.KeyCode = Keys.F2 Then
            PesquisaVeiculos()
        End If
    End Sub

    Private Sub txtControle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtControle.KeyDown
        If e.KeyCode = Keys.Enter Then
            ConsultarOrdemServico()
        End If

    End Sub

    Private Sub ConsultarOrdemServico()
        Dim novaOS As New ncRegras.nsOrdemServico.rOrdemServico
        Dim dadosOS As New ncDados.nsOrdemServico.dOrdemServico
        Dim listaOS As New ncDados.nsOrdemServico.ColecaoOrdemServico

        Dim cliente As New ncRegras.nsCliente.rCliente
        Dim dadosCliente As New ncDados.nsCliente.dCliente

        Dim veiculo As New ncRegras.nsVeiculos.rVeiculos
        Dim dadosVeiculos As New ncDados.nsVeiculos.dVeiculos

        Try
            ' Consulta OS
            dadosOS.cid = Me.txtControle.Text

            listaOS = novaOS.Consultar(dadosOS)

            If Not IsNothing(listaOS) Then

                For Each dadosOS In listaOS
                    'cliente
                    dadosCliente = cliente.ConsultarPorCID(dadosOS.clienteid)
                    Me.txtCliente.Tag = dadosOS.clienteid
                    Me.txtCliente.Text = dadosCliente.nome & ", Cel." & dadosCliente.dddcel & "-" & dadosCliente.celular & ", Tel." & dadosCliente.ddd & "-" & dadosCliente.telefone
                    'veiculo
                    dadosVeiculos = veiculo.ConsultarPorCID(dadosOS.veiculoid)
                    Me.txtVeiculo.Tag = dadosOS.veiculoid
                    Me.txtVeiculo.Text = dadosVeiculos.Placa & " " & dadosVeiculos.Marca & " - " & dadosVeiculos.Modelo & " : " & dadosVeiculos.Ano

                    Me.txtControle.Tag = dadosOS.cid
                    Me.lblEmissao.Text = dadosOS.emissao
                    Me.lblVendedor.Text = dadosOS.vendedor
                    Me.lblLoja.Text = dadosOS.loja
                    Me.txtObservacao.Text = dadosOS.observacoes
                    Me.cboSituacao.Text = dadosOS.situacao
                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class