Imports ncComum.nsExcecao
Imports ncRegras.nsVenda
Imports ncDados.nsVenda

Partial Public Class fRelatorioFechamentoSAT

    Private contadorRelatorio As Integer
    Private linhasRelatorio As String()
    Private paginaAtual As Integer

    Private Sub Filtrar()
        Dim regras As rVenda
        Dim filtro As dVenda
        Dim colVenda As ColecaoVenda
        Dim somaTotal As Decimal

        rtbGrade.Clear()

        regras = New rVenda()
        filtro = New dVenda()

        Try

            filtro.Data = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text)
            filtro.DataFim = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text)
            filtro.Terminal = Me.txtCaixa.Text

            colVenda = regras.ConsultarFechamento(filtro)

            If IsNothing(colVenda) Then
                rtbGrade.AppendText(vbCrLf)
                rtbGrade.AppendText(" Nenhuma venda no período!")
                rtbGrade.AppendText(vbCrLf)
            Else
                rtbGrade.AppendText(vbCrLf)
                For Each itemRef As dVenda In colVenda
                    rtbGrade.AppendText(itemRef.Data & " Dinheiro: R$" & itemRef.Dinheiro.ToString("N") & " Cheque: R$" & itemRef.Cheque.ToString("N") & " PIX: R$" & itemRef.valorOriginal.ToString("N") & " Débito: R$" & itemRef.CartaoDebito.ToString("N") & " Crédito: R$" & itemRef.CartaoCredito.ToString("N") & " Crediário: R$" & itemRef.Crediario.ToString("N") & " Valor: R$" & itemRef.Total.ToString("N"))
                    rtbGrade.AppendText(vbCrLf)
                    somaTotal += itemRef.Total
                Next
                rtbGrade.AppendText(vbCrLf)

                rtbGrade.AppendText(" Total no período: R$" & somaTotal.ToString("N"))
                rtbGrade.AppendText(vbCrLf)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try

            Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
            Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")
            Me.txtCaixa.Text = mdiPrincipal.lblTerminal.Text

            Filtrar()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta [" & Me.ToString() & "]")

        End Try


    End Sub

    Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub btoImprimir_Click(sender As Object, e As EventArgs) Handles btoImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()

        If Not String.IsNullOrEmpty(rtbGrade.Text) Then
            contadorRelatorio = 0
            paginaAtual = 1
            linhasRelatorio = rtbGrade.Text.Split(vbLf)
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fonteNormal As New Font("Courier New", 8)
        Dim margemEsq As Single = 20
        Dim margemSup As Single = 100
        Dim alturaLinha As Integer = 12
        Dim qtdeLinhasRelatorio As Integer = 80

        Do While contadorRelatorio < linhasRelatorio.Length
            Dim altura As Integer

            altura = ((((qtdeLinhasRelatorio + contadorRelatorio) Mod qtdeLinhasRelatorio) + 1) * alturaLinha) + margemSup

            If contadorRelatorio = 1 Then
                e.Graphics.DrawString("Relatório de Fechamento Fiscal", New Font("Arial", 14, FontStyle.Bold), Brushes.Red, margemEsq, 8)
            End If

            e.Graphics.DrawString(linhasRelatorio(contadorRelatorio), fonteNormal, Brushes.Black, margemEsq, altura)

            contadorRelatorio = contadorRelatorio + 1

            If contadorRelatorio Mod qtdeLinhasRelatorio = 0 Then
                Exit Do
            End If
        Loop

        e.Graphics.DrawString("Página " + paginaAtual.ToString(), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 720, 1050)
        paginaAtual = paginaAtual + 1

        If contadorRelatorio >= linhasRelatorio.Length Then
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If



    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        PrintDocument1.DefaultPageSettings.Landscape = True
    End Sub
End Class