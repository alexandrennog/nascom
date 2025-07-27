Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados.nsFabricante
Imports ncDados.nsUsuario
Imports ncDados.nsVenda
Imports ncRegras.nsFabricante
Imports ncRegras.nsUsuario
Imports ncDados.nsLoja
Imports ncRegras.nsLoja

Public Class fRelatorioPorVendedor

    Private Sub Filtrar()
        Dim dadosVenda As New dVendasPorVendedor

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
        parametros(2).Name = "Nome"
        parametros(2).Values.Add(cboVendedor.Text)
        dadosVenda.Nome = ncComum.nsFuncoes.cFuncoes.RetornarTexto(cboVendedor.Text)

        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaoVendasPorVendedor
        Me.lstPix.View = View.Details

        Dim otherItems As String() = {"Nome", "TotalVendas", "QuantidadeProdutos", "ValorTotalVendas", "TicketMedio", "PercentualAtingimento"}
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Nome")
        Me.lstPix.Columns.Add("Tot. Vendas").Width = 80
        Me.lstPix.Columns.Add("Tot. Ítens").Width = 80
        Me.lstPix.Columns.Add("Valor Vendas").Width = 120
        Me.lstPix.Columns.Add("Ticket Médio").Width = 120
        Me.lstPix.Columns.Add("PA").Width = 120

        ' Ativa o cursor de espera (ampulheta)
        Cursor.Current = Cursors.WaitCursor


        vendas = objVenda.ConsultarVendasPorVendedor(dadosVenda)



        If vendas Is Nothing Then
            Exit Sub
        End If

        Dim li As ListViewItem

        For Each item As dVendasPorVendedor In vendas
            li = New ListViewItem
            li.Text = item.Nome.ToString
            li.SubItems.Add(item.TotalVendas)
            li.SubItems.Add(item.QuantidadeProdutos)
            li.SubItems.Add(item.ValorTotalVendas.ToString("C2"))
            li.SubItems.Add(item.TicketMedio.ToString("C2"))
            li.SubItems.Add(item.PercentualAtingimento.ToString("N"))
            Me.lstPix.Items.Add(li)
        Next

        Try

            ConfigurarRelatorio(vendas)
            ' Restaura o cursor padrão
            Cursor.Current = Cursors.Default
        Catch ex As Exception

            ' Restaura o cursor padrão
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConfigurarRelatorio(ByVal vendas As ncDados.nsVenda.ColecaoVendasPorVendedor)
        Dim gLoja As New dLoja
        Dim regrasLoja As rLoja
        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioVendasPorVendedor" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If

        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(3, 2, 3, 2)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF, FileMode.Create))

        doc.Open()

        Dim fonteTitulo As Font
        fonteTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22)

        Dim paragrafoTitulo As New Paragraph("Relatório de Vendas por Vendedor", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20

        regrasLoja = New rLoja()

        gLoja = regrasLoja.Consultar(1)

        Dim fonteLoja As Font
        fonteLoja = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16)

        Dim NomeDaLoja As New Paragraph("                      Loja: " + gLoja.nomeFantasia & vbCrLf & "                      Período: " + txtDataInicial.AccessibilityObject.Value + " a " + txtDataFinal.AccessibilityObject.Value, fonteLoja)
        NomeDaLoja.Alignment = Element.ALIGN_LEFT
        NomeDaLoja.SpacingBefore = 20
        NomeDaLoja.SpacingAfter = 20


        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(NomeDaLoja)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        Dim table As New PdfPTable(6)

        Dim cell1 As New PdfPCell
        Dim cell2 As New PdfPCell
        Dim cell3 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cells As New List(Of PdfPCell)

        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)

        Dim coluna1 As New Paragraph("Nome", fonte)
        Dim coluna2 As New Paragraph("Tot. Vendas", fonte)
        Dim coluna3 As New Paragraph("Tot. Ítens", fonte)
        Dim coluna4 As New Paragraph("Valor Vendas", fonte)
        Dim coluna5 As New Paragraph("Ticket Médio", fonte)
        Dim coluna6 As New Paragraph("PA", fonte)


        cell1.AddElement(coluna1)
        cell2.AddElement(coluna2)
        cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)

        table.AddCell(cell1)
        table.AddCell(cell2)
        table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)

        For Each item As dVendasPorVendedor In vendas
            table.AddCell(New PdfPCell(New Phrase(item.Nome.ToString())))
            table.AddCell(New PdfPCell(New Phrase(item.TotalVendas.ToString())))
            table.AddCell(New PdfPCell(New Phrase(item.QuantidadeProdutos.ToString())))
            table.AddCell(New PdfPCell(New Phrase(item.ValorTotalVendas.ToString("C2"))))
            table.AddCell(New PdfPCell(New Phrase(item.TicketMedio.ToString("C2"))))
            table.AddCell(New PdfPCell(New Phrase(item.PercentualAtingimento.ToString("N"))))
        Next

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
        fVendendorLista()

    End Sub
    Private Sub fVendendorLista()
        Dim regras As rUsuario
        Dim usuarios As ColecaoUsuario
        Dim usuario As New dUsuario
        Dim linha As DataGridViewRow
        Try
            regras = New rUsuario
            Dim filtro As New dUsuario

            filtro.situacao = "A"

            usuarios = regras.Consultar(filtro)
            usuario = usuarios.FirstOrDefault()
            usuario.usuario = "Todos"
            'usuarios.Insert(0, usuario)
            If Not IsNothing(usuarios) Then
                ' 2. Configurar o ComboBox
                cboVendedor.DataSource = usuarios
                cboVendedor.DisplayMember = "usuario"  ' O que será exibido no ComboBox
                cboVendedor.ValueMember = "cid"    ' Valor associado a cada item (poderia ser um ID)
                'cboVendedor.SelectedIndex = -1      ' Inicia sem nenhum item selecionado

                ' Opcional: Adicionar um item padrão no início
                cboVendedor.SelectedIndex = 0
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Usuários.")

        End Try
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
        Dim arquivoPDF = "RelatorioVendasPorVendedor" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub
End Class