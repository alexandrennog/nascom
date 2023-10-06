Imports System.Configuration
Imports ncComum.nsExcecao
Imports ncDados
Imports ncPersistencia
Imports ncRegras

Public Class fPix
    Private Sub btnPix_Click(sender As Object, e As EventArgs) Handles btnPix.Click
        If btnPix.Text = "Cobrar" Then

            If fPagamento.txtPix.Text = "0,00" Or fPagamento.txtPix.Text = "0" Then
                MessageBox.Show("É preciso informar um valor para a cobrança")
                fPagamento.Select()
            Else
                Cadastrar()
                btnPix.Text = "Consultar"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
            End If


        ElseIf btnPix.Text = "Nova Cobrança" Then
            Cadastrar()
            btnPix.Text = "Cobrar"
            btnPix.Image = nascomercio.My.Resources.Resources.cobrar

            txtValorPIX.Text = ""
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

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Clipboard.SetText(txtUrlPix.Text)
    End Sub

    Private Sub btoSair_Click(sender As Object, e As EventArgs) Handles btoSair.Click
        fCrediarioPagamento.Visible = True
        Me.Close()

    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click



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

    Private Sub LimparControles()
        txtValorPIX.Text = ""
        txtStatus.Text = ""
        txtTxId.Text = ""
        txtObs.Text = ""
        txtUrlPix.Text = ""
    End Sub
    Private Sub Consultar(tx As String)
        Dim regras As New rPix
        Dim pix As dPix


        pix = regras.Consultar(tx)

        If IsNothing(pix) Then
            Exit Sub
        End If


        txtValorPIX.Text = pix.Original
        fPagamento.txtPix.Text = pix.Original

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
        Select Case pix.Status
            Case "NOVA"
                txtStatus.Text = ""
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = "Consultar"
            Case "ATIVA"
                txtStatus.Text = "Criada"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = "Consultar"
                picQRCode.Image = ResizeImage(Image.FromFile(filename))
            Case "CONCLUIDA"
                txtStatus.Text = "Pago"
                btnPix.Image = nascomercio.My.Resources.Resources.consultar
                btnPix.Text = ""
                picQRCode.Image = ResizeImage(Image.FromFile(folder + "\pago.png"))
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

        txtObs.Text = String.Format($"{pix.Observacao} Controle:  {fPagamento.lblControle.Text} {pix.DataHora}")

        txtUrlPix.Text = pix.UrlPix



    End Sub

    Public Shared Function ResizeImage(ByVal InputImage As Image) As Image
        Return New Bitmap(InputImage, New Size(200, 200))
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
    Private Sub Cadastrar()
        Dim regras As rPix

        regras = New rPix
        Dim pagamentos = New ColecaoPix
        Dim dados As New dPix


        Try
            dados.Original = txtValorPIX.Text
            dados.Observacao = txtObs.Text
            dados.Controle = fPagamento.lblControle.Text
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
            dados.Controle = fPagamento.lblControle.Text
            Dim arPix = regras.Consultar(dados)

            If Not arPix Is Nothing Then
                arPix = arPix.ToArray()
                dados = arPix(0)
                fPagamento.txtPix.Text = dados.Original
                txtValorPIX.Text = dados.Original
                txtObs.Text = dados.Observacao
                txtTxId.Text = "PIX Cadastrado!"
                txtStatus.Text = "A Cobrar"
            End If

        Catch ex As Exception

            Throw New ExcecaoNascomercio("Erro em recuperar dados do pix [" & Me.ToString() & "] - " & ex.Message)

        End Try
    End Sub
End Class