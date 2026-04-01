Imports System.Configuration
Imports System.IO
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes
Imports ncDados.nsCurvaABC
Imports ncDados.nsFabricante
Imports ncDados.nsVenda
Imports ncRegras.nsFabricante
Imports Unimake.Business.DFe.Xml.GNRE
Imports Unimake.Business.DFe.Xml.SNCM

Public Class fRelatorioVendasABC

    Private Sub Filtrar()
        Dim dadosVenda As New dVendasNfe

        Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))
        ' dadosVenda.Data = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text)

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "DataFinal"
        parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))
        'dadosVenda.DataFim = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text)

        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(2).Name = "Loja"
        parametros(2).Values.Add(mdiPrincipal.lblLoja.Text)

        Dim tipo As String
        If rdValor.Checked Then
            tipo = "V"
        Else
            tipo = "Q"
        End If




        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsCurvaABC.ColecaodVendasABC
        Me.lstPix.View = View.Details

        Dim otherItems As String() = {"Referencia", "Descricao", "Faturamento", "PercIndividual", "PercAcumulado", "ClasseAbc", "Fabricante", "Fornecedor", "EstoqueAtual"}
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Referencia").Width = 80
        Me.lstPix.Columns.Add("Descricao").Width = 80
        Me.lstPix.Columns.Add("Faturamento")
        Me.lstPix.Columns.Add("PercIndividual").Width = 80
        Me.lstPix.Columns.Add("PercAcumulado").Width = 80
        Me.lstPix.Columns.Add("ClasseAbc")
        Me.lstPix.Columns.Add("Fabricante").Width = 80
        Me.lstPix.Columns.Add("Fornecedor").Width = 80
        Me.lstPix.Columns.Add("EstoqueAtual")

        vendas = objVenda.ListarVendasABC(ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataInicial.Text), ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataFinal.Text), tipo)

        If vendas Is Nothing Then
            Exit Sub
        End If

        btoExport.Visible = True

        Dim li As ListViewItem

        Dim totTotal As Decimal

        For Each item As dCurvaAbc In vendas
            li = New ListViewItem
            li.Text = item.Referencia
            li.SubItems.Add(item.Descricao)
            li.SubItems.Add(item.Faturamento)
            li.SubItems.Add(item.PercIndividual)
            li.SubItems.Add(item.PercAcumulado)
            li.SubItems.Add(item.ClasseAbc)
            li.SubItems.Add(item.Fabricante)
            li.SubItems.Add(item.Fornecedor)
            li.SubItems.Add(item.EstoqueAtual)
            Me.lstPix.Items.Add(li)

        Next

        li = New ListViewItem
        li.Text = ""
        li.SubItems.Add("")
        li.SubItems.Add("Total:")
        li.SubItems.Add(totTotal.ToString())
        Me.lstPix.Items.Add(li)

        ConfigurarRelatorioCurvaABC(vendas)

        'Try
        '    ConfigurarRelatorio(dadosVenda)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Private Sub Exportar()
        Dim dadosVenda As New dVenda

        Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))
        ' dadosVenda.Data = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text)

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "DataFinal"
        parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))
        'dadosVenda.DataFim = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text)

        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(2).Name = "Loja"
        parametros(2).Values.Add(mdiPrincipal.lblLoja.Text)

        Dim tipo As String
        If rdValor.Checked Then
            tipo = "V"
        Else
            tipo = "Q"
        End If


        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ColecaodVendasABC
        'Me.lstPix.View = View.Details

        'Dim otherItems As String() = {"Referencia", "Descricao", "Faturamento", "PercIndividual", "PercAcumulado", "ClasseAbc", "Fabricante", "Fornecedor", "EstoqueAtual"}
        'Me.lstPix.View = View.Details
        'Me.lstPix.GridLines = True
        'Me.lstPix.FullRowSelect = True
        'Me.lstPix.Columns.Clear()
        'Me.lstPix.Items.Clear()

        'Me.lstPix.Columns.Add("Referencia").Width = 80
        'Me.lstPix.Columns.Add("Descricao").Width = 80
        'Me.lstPix.Columns.Add("Faturamento")
        'Me.lstPix.Columns.Add("PercIndividual").Width = 80
        'Me.lstPix.Columns.Add("PercAcumulado").Width = 80
        'Me.lstPix.Columns.Add("ClasseAbc")
        'Me.lstPix.Columns.Add("Fabricante").Width = 80
        'Me.lstPix.Columns.Add("Fornecedor").Width = 80
        'Me.lstPix.Columns.Add("EstoqueAtual")

        vendas = objVenda.ListarVendasABC(ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataInicial.Text), ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataFinal.Text), tipo)

        Using sfd As New SaveFileDialog()

            sfd.Title = "Salvar arquivo de Vendas NFe"
            sfd.Filter = "Arquivo CSV (*.csv)|*.csv"
            sfd.FileName = "VendasABC.csv"
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            If sfd.ShowDialog() = DialogResult.OK Then

                Using writer As New StreamWriter(sfd.FileName, False, Encoding.UTF8)

                    ' Cabeçalho
                    writer.WriteLine("Referencia;Descricao;Faturamento;PercIndividual;PercAcumulado;ClasseAbc;Fabricante;Fornecedor;EstoqueAtual")

                    ' Dados
                    For Each item As dCurvaAbc In vendas

                        Dim linha As String = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                                                            item.Referencia,
                                                            item.Descricao,
                                                            item.Faturamento,
                                                            item.PercIndividual,
                                                            item.PercAcumulado,
                                                            item.ClasseAbc,
                                                            item.Fabricante,
                                                            item.Fornecedor,
                                                            item.EstoqueAtual)

                        writer.WriteLine(linha)

                    Next

                End Using

                MessageBox.Show("Arquivo exportado com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

            End If

        End Using

        'If vendas Is Nothing Then
        '    Exit Sub
        'End If

        'Dim li As ListViewItem

        'Dim totTotal As Decimal

        'For Each item As dVendasNfe In vendas
        '    li = New ListViewItem
        '    li.Text = item.Cupom.ToString
        '    li.SubItems.Add(item.DataVenda)
        '    li.SubItems.Add(item.Valor)
        '    Me.lstPix.Items.Add(li)
        '    totTotal = totTotal + item.Valor
        'Next

        'li = New ListViewItem
        'li.Text = ""
        'li.SubItems.Add("")
        'li.SubItems.Add("Total:")
        'li.SubItems.Add(totTotal.ToString())
        'Me.lstPix.Items.Add(li)

        'ConfigurarRelatorio(vendas)

        ''Try
        ''    ConfigurarRelatorio(dadosVenda)
        ''Catch ex As Exception
        ''    MessageBox.Show(ex.Message)
        ''End Try
    End Sub
    Public Shared Sub ExportarParaCsv(lista As ColecaodVendasNfe, caminhoArquivo As String)

        Using writer As New StreamWriter(caminhoArquivo, False, Encoding.UTF8)

            ' Cabeçalho
            writer.WriteLine("Cupom;DataVenda;Valor")

            ' Linhas
            For Each item As dVendasNfe In lista

                Dim linha As String = String.Format("{0};{1};{2}",
                                                    item.Cupom,
                                                    item.DataVenda,
                                                    item.Valor)

                writer.WriteLine(linha)

            Next

        End Using

    End Sub
    Private Sub ConfigurarRelatorio(ByVal vendas As ncDados.nsVenda.ColecaodVendasNfe)

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioVendasNFe" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

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

        Dim table As New PdfPTable(4)

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

        Dim coluna1 As New Paragraph("Cupom", fonte)
        'Dim coluna2 As New Paragraph("usuarioId", fonte)
        'Dim coluna3 As New Paragraph("clienteId", fonte)
        Dim coluna4 As New Paragraph("DataVenda", fonte)
        Dim coluna5 As New Paragraph("Valor", fonte)
        Dim coluna6 As New Paragraph("total", fonte)

        cell1.AddElement(coluna1)
        'cell2.AddElement(coluna2)
        'cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)

        table.AddCell(cell1)
        'table.AddCell(cell2)
        'table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)

        Dim totTotal As Decimal


        For Each item As dVendasNfe In vendas

            'cells.Add(New PdfPCell(New Phrase(item.controle)))
            table.AddCell(New PdfPCell(New Phrase(item.Cupom.ToString())))
            'cells.Add(New PdfPCell(New Phrase(item.Data)))
            table.AddCell(New PdfPCell(New Phrase(item.DataVenda)))
            'cells.Add(New PdfPCell(New Phrase(item.Terminal)))
            table.AddCell(New PdfPCell(New Phrase(item.Valor)))
            'cells.Add(New PdfPCell(New Phrase(item.Total)))
            totTotal = totTotal + item.Valor
        Next

        table.AddCell(New PdfPCell(New Phrase("")))
        'cells.Add(New PdfPCell(New Phrase(item.Data)))
        table.AddCell(New PdfPCell(New Phrase("")))
        'cells.Add(New PdfPCell(New Phrase(item.Terminal)))
        table.AddCell(New PdfPCell(New Phrase("Total: ")))
        'cells.Add(New PdfPCell(New Phrase(item.Total)))
        table.AddCell(New PdfPCell(New Phrase(totTotal.ToString())))

        If Not vendas Is Nothing Then
            doc.Add(table)
        End If
        doc.Close()




    End Sub
    Private Sub ConfigurarRelatorioCurvaABC(ByVal vendas As ColecaodVendasABC)

        ' ── Arquivo ────────────────────────────────────────────────────────────────
        Dim pathRelatorio As String = ConfigurationManager.AppSettings("pathRelatorio")
        Dim arquivoPDF As String = "RelatorioVendasABC" & DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim caminhoCompleto As String = pathRelatorio & arquivoPDF

        If File.Exists(caminhoCompleto) Then File.Delete(caminhoCompleto)

        ' ── Documento ──────────────────────────────────────────────────────────────
        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(10, 10, 15, 10)
        PdfWriter.GetInstance(doc, New FileStream(caminhoCompleto, FileMode.Create))
        doc.Open()

        ' ── Fontes ─────────────────────────────────────────────────────────────────
        Dim fonteTitulo As Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 16, BaseColor.BLACK)
        Dim fonteHeader As Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 8, BaseColor.WHITE)
        Dim fonteDados As Font = FontFactory.GetFont(BaseFont.HELVETICA, 7, BaseColor.BLACK)
        Dim fonteTotal As Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 8, BaseColor.BLACK)

        ' ── Cores ──────────────────────────────────────────────────────────────────
        Dim corHeader As BaseColor = New BaseColor(31, 73, 125)   ' Azul escuro
        Dim corLinhaA As BaseColor = New BaseColor(198, 224, 180) ' Verde claro
        Dim corLinhaB As BaseColor = New BaseColor(255, 235, 156) ' Amarelo claro
        Dim corLinhaC As BaseColor = New BaseColor(255, 199, 206) ' Vermelho claro
        Dim corAlt As BaseColor = New BaseColor(242, 242, 242) ' Cinza claro (linhas pares)

        ' ── Título ─────────────────────────────────────────────────────────────────
        Dim titulo As New Paragraph("Relatório de Vendas - Curva ABC", fonteTitulo)
        titulo.Alignment = Element.ALIGN_CENTER
        titulo.SpacingBefore = 10
        titulo.SpacingAfter = 5
        doc.Add(titulo)

        Dim subTitulo As New Paragraph("Gerado em: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                                   FontFactory.GetFont(BaseFont.HELVETICA, 8, BaseColor.GRAY))
        subTitulo.Alignment = Element.ALIGN_CENTER
        subTitulo.SpacingAfter = 15
        doc.Add(subTitulo)

        ' ── Tabela: 9 colunas ──────────────────────────────────────────────────────
        '   Larguras relativas (total = 100%)
        Dim tabela As New PdfPTable(9)
        tabela.WidthPercentage = 100
        tabela.SetWidths(New Single() {8, 22, 10, 8, 8, 6, 14, 14, 10})
        tabela.HeaderRows = 1   ' Repete cabeçalho em cada página

        ' ── Função auxiliar: célula de cabeçalho ───────────────────────────────────
        Dim CriarHeader As Func(Of String, PdfPCell) =
        Function(texto As String)
            Dim c As New PdfPCell(New Phrase(texto, fonteHeader))
            c.BackgroundColor = corHeader
            c.HorizontalAlignment = Element.ALIGN_CENTER
            c.VerticalAlignment = Element.ALIGN_MIDDLE
            c.Padding = 5
            c.BorderColor = BaseColor.WHITE
            Return c
        End Function

        ' ── Cabeçalhos ─────────────────────────────────────────────────────────────
        tabela.AddCell(CriarHeader("Referência"))
        tabela.AddCell(CriarHeader("Descrição"))
        tabela.AddCell(CriarHeader("Faturamento"))
        tabela.AddCell(CriarHeader("% Individual"))
        tabela.AddCell(CriarHeader("% Acumulado"))
        tabela.AddCell(CriarHeader("Classe"))
        tabela.AddCell(CriarHeader("Fabricante"))
        tabela.AddCell(CriarHeader("Fornecedor"))
        tabela.AddCell(CriarHeader("Estoque Atual"))

        ' ── Função auxiliar: célula de dado ────────────────────────────────────────
        Dim CriarCelula As Func(Of String, Integer, BaseColor, PdfPCell) =
        Function(texto As String, alinhamento As Integer, corFundo As BaseColor)
            Dim c As New PdfPCell(New Phrase(texto, fonteDados))
            c.BackgroundColor = corFundo
            c.HorizontalAlignment = alinhamento
            c.VerticalAlignment = Element.ALIGN_MIDDLE
            c.Padding = 4
            c.BorderColor = New BaseColor(210, 210, 210)
            Return c
        End Function

        ' ── Linhas de dados ────────────────────────────────────────────────────────
        Dim totalFaturamento As Decimal = 0
        Dim totalEstoque As Decimal = 0
        Dim linha As Integer = 0

        For Each item As dCurvaAbc In vendas

            ' Cor de fundo por classe ABC
            Dim corFundo As BaseColor
            Select Case item.ClasseAbc
                Case "A" : corFundo = corLinhaA
                Case "B" : corFundo = corLinhaB
                Case "C" : corFundo = corLinhaC
                Case Else
                    corFundo = If(linha Mod 2 = 0, BaseColor.WHITE, corAlt)
            End Select

            tabela.AddCell(CriarCelula(item.Referencia, Element.ALIGN_LEFT, corFundo))
            tabela.AddCell(CriarCelula(item.Descricao, Element.ALIGN_LEFT, corFundo))
            tabela.AddCell(CriarCelula(item.Faturamento.ToString("N2"), Element.ALIGN_RIGHT, corFundo))
            tabela.AddCell(CriarCelula(item.PercIndividual.ToString("N2") & "%", Element.ALIGN_RIGHT, corFundo))
            tabela.AddCell(CriarCelula(item.PercAcumulado.ToString("N2") & "%", Element.ALIGN_RIGHT, corFundo))
            tabela.AddCell(CriarCelula(item.ClasseAbc, Element.ALIGN_CENTER, corFundo))
            tabela.AddCell(CriarCelula(item.Fabricante, Element.ALIGN_LEFT, corFundo))
            tabela.AddCell(CriarCelula(item.Fornecedor, Element.ALIGN_LEFT, corFundo))
            tabela.AddCell(CriarCelula(item.EstoqueAtual.ToString("N0"), Element.ALIGN_RIGHT, corFundo))

            totalFaturamento += item.Faturamento
            totalEstoque += item.EstoqueAtual
            linha += 1
        Next

        ' ── Linha de totais ────────────────────────────────────────────────────────
        Dim corTotais As BaseColor = New BaseColor(31, 73, 125)

        Dim CriarTotal As Func(Of String, Integer, PdfPCell) =
        Function(texto As String, alinhamento As Integer)
            Dim c As New PdfPCell(New Phrase(texto, FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 8, BaseColor.WHITE)))
            c.BackgroundColor = corTotais
            c.HorizontalAlignment = alinhamento
            c.VerticalAlignment = Element.ALIGN_MIDDLE
            c.Padding = 5
            Return c
        End Function

        tabela.AddCell(CriarTotal("TOTAL", Element.ALIGN_LEFT))
        tabela.AddCell(CriarTotal(linha & " produtos", Element.ALIGN_LEFT))
        tabela.AddCell(CriarTotal(totalFaturamento.ToString("N2"), Element.ALIGN_RIGHT))
        tabela.AddCell(CriarTotal("100%", Element.ALIGN_RIGHT))
        tabela.AddCell(CriarTotal("100%", Element.ALIGN_RIGHT))
        tabela.AddCell(CriarTotal("-", Element.ALIGN_CENTER))
        tabela.AddCell(CriarTotal("-", Element.ALIGN_CENTER))
        tabela.AddCell(CriarTotal("-", Element.ALIGN_CENTER))
        tabela.AddCell(CriarTotal(totalEstoque.ToString("N0"), Element.ALIGN_RIGHT))

        doc.Add(tabela)

        ' ── Legenda ────────────────────────────────────────────────────────────────
        doc.Add(New Chunk(vbLf))
        Dim legenda As New Paragraph(
        "Legenda:   " &
        "■ Classe A = até 80% do faturamento   " &
        "■ Classe B = até 95% do faturamento   " &
        "■ Classe C = acima de 95% do faturamento",
        FontFactory.GetFont(BaseFont.HELVETICA, 7, BaseColor.GRAY))
        legenda.Alignment = Element.ALIGN_LEFT
        doc.Add(legenda)

        doc.Close()
    End Sub
    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        ' Ativar ampulheta (antes de uma operação demorada)
        Cursor.Current = Cursors.WaitCursor

        Filtrar()

        ' Voltar ao cursor normal (após a operação)
        Cursor.Current = Cursors.Default
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
        Me.txtDataFinal.Text = DateAdd(DateInterval.Year, 1, Today).ToString("dd/MM/yyyy")


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
        Dim arquivoPDF = "RelatorioVendasABC" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub

    Private Sub btoExport_Click(sender As Object, e As EventArgs) Handles btoExport.Click
        ' Ativar ampulheta (antes de uma operação demorada)
        Cursor.Current = Cursors.WaitCursor

        Exportar()

        ' Voltar ao cursor normal (após a operação)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtDataInicial_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtDataInicial.MaskInputRejected

    End Sub
End Class