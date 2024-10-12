Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports ncDados.nsCobranca
Imports System.Configuration
Imports System.IO

Public Class fRelatorioCobrancaAutomatica
    Private Sub fRelatorioCobrancaAutomatica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btoFiltro_Click(sender As Object, e As EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub


    Private Sub btoSair_Click(sender As Object, e As EventArgs) Handles btoSair.Click

    End Sub
    Private Sub Filtrar()
        Dim dadosVenda As New dCobrancaAutomatica

        Dim parametros(1) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))
        dadosVenda.DataCobranca = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text)

        Dim objCrediario As New ncRegras.nsCobranca.rCobranca
        Dim cobrancas As ncDados.nsCobranca.ColecaoCobranca

        Me.lstCobrancaPix.View = View.Details

        'Dim otherItems As String() = {"Data", "Terminal", "Dinheiro", "PIX"}
        Me.lstCobrancaPix.View = View.Details

        Me.lstCobrancaPix.GridLines = True
        Me.lstCobrancaPix.FullRowSelect = True
        Me.lstCobrancaPix.Columns.Clear()
        Me.lstCobrancaPix.Items.Clear()

        Me.lstCobrancaPix.Columns.Add("CodigoCliente").Width = 0
        Me.lstCobrancaPix.Columns.Add("CrediarioId").Width = 0
        Me.lstCobrancaPix.Columns.Add("ParcelaIdId").Width = 0
        Me.lstCobrancaPix.Columns.Add("Nome").Width = 220
        Me.lstCobrancaPix.Columns.Add("DDDCel").Width = 0
        Me.lstCobrancaPix.Columns.Add("Celular").Width = 90
        Me.lstCobrancaPix.Columns.Add("Sucesso").Width = 0
        Me.lstCobrancaPix.Columns.Add("PixCode").Width = 0
        Me.lstCobrancaPix.Columns.Add("Cobranca").Width = 90
        Me.lstCobrancaPix.Columns.Add("Vencimento").Width = 90
        Me.lstCobrancaPix.Columns.Add("Valor").Width = 70

        cobrancas = objCrediario.ConsultarCobrancas(dadosVenda)

        If cobrancas Is Nothing Then
            Exit Sub
        End If
        Dim li As ListViewItem

        Dim totTotal As Decimal


        For Each item As dCobrancaAutomatica In cobrancas
            li = New ListViewItem
            li.Text = item.CodigoCliente
            li.SubItems.Add(item.CrediarioId)
            li.SubItems.Add(item.ParcelaIdId)
            li.SubItems.Add((item.Nome))
            li.SubItems.Add(item.DDDCel)
            li.SubItems.Add(item.Celular + item.DDDCel)
            li.SubItems.Add(item.Sucesso)
            li.SubItems.Add(item.PixCode)
            li.SubItems.Add(item.DataCobranca.ToString("dd/MM/yyyy"))
            li.SubItems.Add(item.DataVencimento.ToString("dd/MM/yyyy"))
            li.SubItems.Add(item.Valor.ToString())
            Me.lstCobrancaPix.Items.Add(li)
            totTotal = totTotal + item.Valor
        Next

        lblTotal.Text = "Total: " + totTotal.ToString()
        ConfigurarRelatorio(cobrancas)
    End Sub

    Private Sub ConfigurarRelatorio(ByVal cobrancas As ncDados.nsCobranca.ColecaoCobranca)

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioCobrancaPix" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If

        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(3, 2, 3, 2)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF, FileMode.Create))

        doc.Open()

        Dim fonteTitulo As Font
        fonteTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 8)

        Dim paragrafoTitulo As New Paragraph("Crediário Cobrança PIX", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20

        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        Dim table As New PdfPTable(5)

        Dim cell1 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cell7 As New PdfPCell
        Dim cells As New List(Of PdfPCell)

        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 8)


        Dim coluna1 As New Paragraph("Nome", fonte)
        Dim coluna4 As New Paragraph("Celular", fonte)
        Dim coluna5 As New Paragraph("Data Cobrança", fonte)
        Dim coluna6 As New Paragraph("Data Vencimento", fonte)
        Dim coluna7 As New Paragraph("Valor", fonte)


        cell1.AddElement(coluna1)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)
        cell7.AddElement(coluna7)

        table.AddCell(cell1)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)
        table.AddCell(cell7)

        Dim totTotal As Decimal

        For Each item As dCobrancaAutomatica In cobrancas
            table.AddCell(New PdfPCell(New Phrase(item.Nome)))
            table.AddCell(New PdfPCell(New Phrase(item.Celular)))
            table.AddCell(New PdfPCell(New Phrase(item.DataCobranca.ToString("dd/MM/yyyy"))))
            table.AddCell(New PdfPCell(New Phrase(item.DataVencimento.ToString("dd/MM/yyyy"))))
            table.AddCell(New PdfPCell(New Phrase(item.Valor.ToString(""))))
            totTotal = totTotal + item.Valor
        Next

        table.AddCell(New PdfPCell(New Phrase("")))
        table.AddCell(New PdfPCell(New Phrase("")))
        table.AddCell(New PdfPCell(New Phrase("")))
        table.AddCell(New PdfPCell(New Phrase("")))
        table.AddCell(New PdfPCell(New Phrase("Total: " + totTotal.ToString())))

        If Not cobrancas Is Nothing Then
            doc.Add(table)
        End If
        doc.Close()




    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim arquivoPDF = "RelatorioCobrancaPix" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblTotal.Click

    End Sub
End Class