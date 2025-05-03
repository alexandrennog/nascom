Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncRegras.nsVenda
Imports ncDados.nsVenda
Imports System.Configuration
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports ncPersistencia.nsVenda

Partial Public Class fRelatorioFechamentoSAT

    Private contadorRelatorio As Integer
    Private linhasRelatorio As String()
    Private paginaAtual As Integer

    Private Sub Filtrar()
        Dim regras As rVenda
        Dim filtro As dVenda
        Dim colVenda As ColecaoVenda
        Dim somaTotal As Decimal
        Dim objFuncoes As ncComum.nsFuncoes.cFuncoes()


        'rtbGrade.Clear()

        regras = New rVenda()
        filtro = New dVenda()

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioVendasSAT" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If

        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(3, 2, 3, 2)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF, FileMode.Create))

        doc.Open()

        Dim fonteTitulo As Font
        fonteTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22)

        Dim paragrafoTitulo As New Paragraph("Relatório de Vendas SAT", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20

        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        Dim table As New PdfPTable(9)

        Dim cell1 As New PdfPCell
        Dim cell2 As New PdfPCell
        Dim cell3 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cell7 As New PdfPCell
        Dim cell8 As New PdfPCell
        Dim cell9 As New PdfPCell
        Dim cells As New List(Of PdfPCell)

        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 11)

        Dim coluna1 As New Paragraph("Data", fonte)
        Dim coluna2 As New Paragraph("Dinheiro", fonte)
        Dim coluna3 As New Paragraph("Cheque", fonte)
        Dim coluna4 As New Paragraph("Pix", fonte)
        Dim coluna5 As New Paragraph("CartaoDebito", fonte)
        Dim coluna6 As New Paragraph("CartaoCredito", fonte)
        Dim coluna7 As New Paragraph("Crediario", fonte)
        Dim coluna8 As New Paragraph("Desconto", fonte)
        Dim coluna9 As New Paragraph("Total", fonte)

        cell1.AddElement(coluna1)
        cell2.AddElement(coluna2)
        cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)
        cell7.AddElement(coluna7)
        cell8.AddElement(coluna8)
        cell9.AddElement(coluna9)

        table.AddCell(cell1)
        table.AddCell(cell2)
        table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)
        table.AddCell(cell7)
        table.AddCell(cell8)
        table.AddCell(cell9)

        Dim totTotal As Decimal

        If txtDataInicial.Text = "" Then
            Exit Sub
        End If


        txtDataInicial.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        txtDataFinal.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

        filtro.Data = txtDataInicial.Text
        filtro.DataFim = txtDataFinal.Text
        filtro.Terminal = Me.txtCaixa.Text

        colVenda = regras.ConsultarFechamento(filtro)


        Me.lstVendasSAT.View = View.Details

        Me.lstVendasSAT.View = View.Details
        Me.lstVendasSAT.GridLines = True
        Me.lstVendasSAT.FullRowSelect = True
        Me.lstVendasSAT.Columns.Clear()
        Me.lstVendasSAT.Items.Clear()

        Me.lstVendasSAT.Columns.Add("Data").Width = 120
        Me.lstVendasSAT.Columns.Add("Dinheiro").Width = 80
        Me.lstVendasSAT.Columns.Add("Cheque").Width = 80
        Me.lstVendasSAT.Columns.Add("Pix").Width = 80
        Me.lstVendasSAT.Columns.Add("CartaoDebito").Width = 80
        Me.lstVendasSAT.Columns.Add("CartaoCredito").Width = 80
        Me.lstVendasSAT.Columns.Add("Crediario").Width = 80
        Me.lstVendasSAT.Columns.Add("Desconto").Width = 80
        Me.lstVendasSAT.Columns.Add("Total").Width = 80


        If colVenda Is Nothing Then
            Exit Sub
        End If

        Dim li As ListViewItem


        Dim totalDinheiro As Decimal
        Dim totalCheque As Decimal
        Dim totalvalorOriginal As Decimal
        Dim totalCartaoDebito As Decimal
        Dim totalCartaoCredito As Decimal
        Dim totalCrediario As Decimal
        Dim totalDesconto As Decimal
        Dim totTotalVendas As Decimal


        For Each item As dVenda In colVenda
            li = New ListViewItem
            li.Text = item.Data.ToString()
            li.SubItems.Add(item.Dinheiro.ToString("N"))
            totalDinheiro = totalDinheiro + item.Dinheiro
            li.SubItems.Add(item.Cheque)
            totalCheque = totalCheque + item.Cheque
            li.SubItems.Add(item.valorOriginal.ToString())
            totalvalorOriginal = totalvalorOriginal + item.valorOriginal
            li.SubItems.Add(item.CartaoDebito.ToString())
            totalCartaoDebito = totalCartaoDebito + item.CartaoDebito
            li.SubItems.Add(item.CartaoCredito.ToString())
            totalCartaoCredito = totalCartaoCredito + item.CartaoCredito
            li.SubItems.Add(item.Crediario.ToString())
            totalCrediario = totalCrediario + item.Crediario
            li.SubItems.Add(item.Desconto.ToString())
            totalDesconto = totalDesconto + item.Desconto
            li.SubItems.Add(item.Total.ToString())
            Me.lstVendasSAT.Items.Add(li)
            totTotalVendas = totTotalVendas + item.Total
        Next


        li = New ListViewItem
        li.Text = "Totais: "
        li.SubItems.Add(totalDinheiro.ToString())
        li.SubItems.Add(totalCheque.ToString())
        li.SubItems.Add(totalvalorOriginal.ToString())
        li.SubItems.Add(totalCartaoDebito.ToString())
        li.SubItems.Add(totalCartaoCredito.ToString())
        li.SubItems.Add(totalCrediario.ToString())
        li.SubItems.Add(totalDesconto.ToString())
        li.SubItems.Add(totTotalVendas.ToString())
        Me.lstVendasSAT.Items.Add(li)

        For Each itemRef As dVenda In colVenda
            table.AddCell(New PdfPCell(New Phrase(itemRef.Data.ToString())))

            table.AddCell(New PdfPCell(New Phrase(itemRef.Dinheiro.ToString("N"))))
            totalDinheiro = totalDinheiro + itemRef.Dinheiro
            table.AddCell(New PdfPCell(New Phrase(itemRef.Cheque.ToString("N"))))
            totalCheque = totalCheque + itemRef.Cheque
            table.AddCell(New PdfPCell(New Phrase(itemRef.valorOriginal.ToString("N"))))
            totalvalorOriginal = totalvalorOriginal + itemRef.valorOriginal
            table.AddCell(New PdfPCell(New Phrase(itemRef.CartaoDebito.ToString("N"))))
            totalCartaoDebito = totalCartaoDebito + itemRef.CartaoDebito
            table.AddCell(New PdfPCell(New Phrase(itemRef.CartaoCredito.ToString("N"))))
            totalCartaoCredito = totalCartaoCredito + itemRef.CartaoCredito
            table.AddCell(New PdfPCell(New Phrase(itemRef.Crediario.ToString("N"))))
            totalCrediario = totalCrediario + itemRef.Crediario
            table.AddCell(New PdfPCell(New Phrase(itemRef.Desconto.ToString("N"))))
            totalDesconto = totalDesconto + itemRef.Desconto
            table.AddCell(New PdfPCell(New Phrase(itemRef.Total.ToString("N"))))
            totTotal = totTotal + itemRef.Total
        Next


        table.AddCell(New PdfPCell(New Phrase("Total:")))
        table.AddCell(New PdfPCell(New Phrase(totalDinheiro.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalCheque.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalvalorOriginal.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalCartaoDebito.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalCartaoCredito.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalCrediario.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totalDesconto.ToString())))
        table.AddCell(New PdfPCell(New Phrase(totTotal.ToString())))

        If Not colVenda Is Nothing Then
            doc.Add(table)
        End If
        doc.Close()

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

            'Filtrar()

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

        Dim arquivoPDF = "RelatorioVendasSAT" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fonteNormal As New Font("Courier New", 8)
        Dim margemEsq As Single = 20
        Dim margemSup As Single = 100
        Dim alturaLinha As Integer = 12
        Dim qtdeLinhasRelatorio As Integer = 80

        'Do While contadorRelatorio < linhasRelatorio.Length
        '    Dim altura As Integer

        '    altura = ((((qtdeLinhasRelatorio + contadorRelatorio) Mod qtdeLinhasRelatorio) + 1) * alturaLinha) + margemSup

        '    If contadorRelatorio = 1 Then
        '        e.Graphics.DrawString("Relatório de Fechamento Fiscal", New Font("Arial", 14, FontStyle.Bold), Brushes.Red, margemEsq, 8)
        '    End If

        '    e.Graphics.DrawString(linhasRelatorio(contadorRelatorio), fonteNormal, Brushes.Black, margemEsq, altura)

        '    contadorRelatorio = contadorRelatorio + 1

        '    If contadorRelatorio Mod qtdeLinhasRelatorio = 0 Then
        '        Exit Do
        '    End If
        'Loop

        'e.Graphics.DrawString("Página " + paginaAtual.ToString(), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 720, 1050)
        'paginaAtual = paginaAtual + 1

        'If contadorRelatorio >= linhasRelatorio.Length Then
        '    e.HasMorePages = False
        'Else
        '    e.HasMorePages = True
        'End If



    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        PrintDocument1.DefaultPageSettings.Landscape = True
    End Sub
End Class