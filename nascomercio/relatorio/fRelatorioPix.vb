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

        Try
            ConfigurarRelatorio(dadosVenda)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConfigurarRelatorio(ByVal dadosVenda As dVenda)

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioPix001" & ".pdf"

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

        Dim table As New PdfPTable(7)

        Dim cell1 As New PdfPCell
        Dim cell2 As New PdfPCell
        Dim cell3 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cell7 As New PdfPCell


        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)

        Dim coluna1 As New Paragraph("Controle", fonte)
        Dim coluna2 As New Paragraph("usuarioId", fonte)
        Dim coluna3 As New Paragraph("clienteId", fonte)
        Dim coluna4 As New Paragraph("data", fonte)
        Dim coluna5 As New Paragraph("terminal", fonte)
        Dim coluna6 As New Paragraph("total", fonte)
        Dim coluna7 As New Paragraph("Original", fonte)

        cell1.AddElement(coluna1)
        cell2.AddElement(coluna2)
        cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)
        cell7.AddElement(coluna7)

        table.AddCell(cell1)
        table.AddCell(cell2)
        table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)
        table.AddCell(cell7)


        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaoVenda

        vendas = objVenda.Consultar(dadosVenda)

        For Each item As dVenda In vendas

            Dim controle As New Phrase(item.controle.ToString())
            Dim cell As New PdfPCell(controle)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim usuarioid As New Phrase(item.usuarioId.ToString())
            cell = New PdfPCell(usuarioid)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim clienteid As New Phrase(item.clienteId.ToString())
            cell = New PdfPCell(clienteid)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim data As New Phrase(item.Data.ToString("dd/MM/yyyy"))
            cell = New PdfPCell(data)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim terminal As New Phrase(item.Terminal)
            cell = New PdfPCell(terminal)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim total As New Phrase(item.Total.ToString())
            cell = New PdfPCell(total)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)

            Dim original As New Phrase(item.Pix.ToString())
            cell = New PdfPCell(original)
            cell.Border = PdfPCell.NO_BORDER
            table.AddCell(cell)
        Next

        If Not vendas Is Nothing Then
            doc.Add(table)
        End If
        doc.Close()

        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Dim MyPDF As New ProcessStartInfo(ProcessApplication)
            MyPDF.Arguments = ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF

            Process.Start(MyPDF)
        End If








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

        Filtrar()

    End Sub

    Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

End Class