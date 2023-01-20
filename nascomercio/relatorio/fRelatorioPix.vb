Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports ncDados.nsVenda
Imports System.Configuration

Public Class fRelatorioPix

    Private Sub Filtrar()
        Dim dadosVenda As New dVenda

        Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))
        dadosVenda.Data = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text)

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "DataFinal"
        parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))
        dadosVenda.DataFim = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text)

        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(2).Name = "Loja"
        parametros(2).Values.Add(mdiPrincipal.lblLoja.Text)

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Caixa"
        parametros(3).Values.Add(Me.txtCaixa.Text)
        dadosVenda.Caixa = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtCaixa.Text)

        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaoVenda
        Me.lstPix.View = View.Details

        Dim otherItems As String() = {"Data", "Terminal", "Total", "PIX"}
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Controle")
        Me.lstPix.Columns.Add("Data").Width = 80
        Me.lstPix.Columns.Add("Terminal").Width = 80
        Me.lstPix.Columns.Add("Total")
        Me.lstPix.Columns.Add("PIX")

        vendas = objVenda.Consultar(dadosVenda)

        If vendas Is Nothing Then
            Exit Sub
        End If

        Dim li As ListViewItem

        Dim totTotal As Decimal
        Dim totPIX As Decimal

        For Each item As dVenda In vendas
            li = New ListViewItem
            li.Text = item.controle.ToString
            li.SubItems.Add(item.Data.ToString("dd/MM/yyyy"))
            li.SubItems.Add(item.Terminal)
            li.SubItems.Add(item.Total.ToString())
            li.SubItems.Add(item.Pix.ToString())
            Me.lstPix.Items.Add(li)
            totTotal = totTotal + item.Total
            totPIX = totPIX + item.Pix
        Next

        li = New ListViewItem
        li.Text = ""
        li.SubItems.Add("")
        li.SubItems.Add("Total:")
        li.SubItems.Add(totTotal.ToString())
        li.SubItems.Add(totPIX.ToString())
        Me.lstPix.Items.Add(li)

        ConfigurarRelatorio(vendas)

        'Try
        '    ConfigurarRelatorio(dadosVenda)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Private Sub ConfigurarRelatorio(ByVal vendas As ncDados.nsVenda.ColecaoVenda)

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioPix" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If

        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(3, 2, 3, 2)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF, FileMode.Create))

        doc.Open()

        Dim fonteTitulo As Font
        fonteTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22)

        Dim paragrafoTitulo As New Paragraph("Relatório de Fechamento em PIX", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20

        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        Dim table As New PdfPTable(5)

        Dim cell1 As New PdfPCell
        'Dim cell2 As New PdfPCell
        'Dim cell3 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cell7 As New PdfPCell
        Dim cells As New List(Of PdfPCell)

        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)

        Dim coluna1 As New Paragraph("Controle", fonte)
        'Dim coluna2 As New Paragraph("usuarioId", fonte)
        'Dim coluna3 As New Paragraph("clienteId", fonte)
        Dim coluna4 As New Paragraph("data", fonte)
        Dim coluna5 As New Paragraph("terminal", fonte)
        Dim coluna6 As New Paragraph("total", fonte)
        Dim coluna7 As New Paragraph("PIX", fonte)

        cell1.AddElement(coluna1)
        'cell2.AddElement(coluna2)
        'cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)
        cell7.AddElement(coluna7)

        table.AddCell(cell1)
        'table.AddCell(cell2)
        'table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)
        table.AddCell(cell7)

        Dim totTotal As Decimal
        Dim totPIX As Decimal


        For Each item As dVenda In vendas

            'cells.Add(New PdfPCell(New Phrase(item.controle)))
            table.AddCell(New PdfPCell(New Phrase(item.controle.ToString())))
            'cells.Add(New PdfPCell(New Phrase(item.Data)))
            table.AddCell(New PdfPCell(New Phrase(item.Data)))
            'cells.Add(New PdfPCell(New Phrase(item.Terminal)))
            table.AddCell(New PdfPCell(New Phrase(item.Terminal)))
            'cells.Add(New PdfPCell(New Phrase(item.Total)))
            table.AddCell(New PdfPCell(New Phrase(item.Total.ToString())))
            'cells.Add(New PdfPCell(New Phrase(item.Pix)))
            table.AddCell(New PdfPCell(New Phrase(item.Pix.ToString())))
            totTotal = totTotal + item.Total
            totPIX = totPIX + item.Pix
        Next

        table.AddCell(New PdfPCell(New Phrase("")))
        'cells.Add(New PdfPCell(New Phrase(item.Data)))
        table.AddCell(New PdfPCell(New Phrase("")))
        'cells.Add(New PdfPCell(New Phrase(item.Terminal)))
        table.AddCell(New PdfPCell(New Phrase("Total: ")))
        'cells.Add(New PdfPCell(New Phrase(item.Total)))
        table.AddCell(New PdfPCell(New Phrase(totTotal.ToString())))
        'cells.Add(New PdfPCell(New Phrase(item.Pix)))
        table.AddCell(New PdfPCell(New Phrase(totPIX.ToString())))


        If Not vendas Is Nothing Then
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

            'Me.v_fechamentoTableAdapter.Fill(Me.nascomercioDataSet.v_fechamento)

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

        End Try

        Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
        Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")
        Select Case mdiPrincipal.gUsuario.usuarioPerfil_codigo
            Case "a", "g"
                Me.txtCaixa.Text = ""
                Me.txtCaixa.ReadOnly = False
            Case "c"
                Me.txtCaixa.Text = mdiPrincipal.gUsuario.usuario
                Me.txtCaixa.ReadOnly = True
        End Select


    End Sub

    Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
            Case Keys.F8
                Imprimir()
        End Select
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Imprimir()

    End Sub

    Private Sub Imprimir()
        Dim arquivoPDF = "RelatorioPix" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub
End Class