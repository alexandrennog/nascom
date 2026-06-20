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

    Private ReadOnly _pathRelatorio As String = ConfigurationManager.AppSettings("pathRelatorio")

    Private Function ObterTipoRelatorio() As String
        Return If(rdValor.Checked, "V", "Q")
    End Function

    Private Function ObterDataFormatada(dataTexto As String, formatarComBarras As Boolean) As String
        If formatarComBarras Then
            Return cFuncoes.FormatarDataBarras(dataTexto)
        Else
            Return cFuncoes.FormatarData(dataTexto)
        End If
    End Function

    Private Sub ConfigurarListView()
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Fabricante").Width = 100
        Me.lstPix.Columns.Add("Valor").Width = 80
        Me.lstPix.Columns.Add("Percentual").Width = 80
        Me.lstPix.Columns.Add("Perc Acumulado").Width = 129
        Me.lstPix.Columns.Add("Classe Abc").Width = 140
        Me.lstPix.Columns.Add("Estrategia").Width = 180
    End Sub

    Private Sub PreencherListView(vendas As ColecaodVendasABC)
        If vendas Is Nothing OrElse vendas.Count = 0 Then
            Exit Sub
        End If

        For Each item As dCurvaAbc In vendas
            Dim li As New ListViewItem(item.Fabricante)
            li.SubItems.Add(item.valor)
            li.SubItems.Add(item.PercReceita)
            li.SubItems.Add(item.PercAcumulado)
            li.SubItems.Add(item.ClasseAbc)
            li.SubItems.Add(item.Estrategia)
            Me.lstPix.Items.Add(li)
        Next
    End Sub

    Private Sub Filtrar()
        Try
            ConfigurarListView()

            Dim tipo As String = ObterTipoRelatorio()
            Dim dataInicial As String = ObterDataFormatada(txtDataInicial.Text, False)
            Dim dataFinal As String = ObterDataFormatada(txtDataFinal.Text, False)

            Dim objVenda As New ncRegras.nsVenda.rVenda
            Dim vendas As ColecaodVendasABC = objVenda.ListarVendasABC(dataInicial, dataFinal, tipo)

            If vendas Is Nothing OrElse vendas.Count = 0 Then
                MessageBox.Show("Nenhum dado encontrado para o período selecionado.",
                                "Informação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If

            PreencherListView(vendas)
            btoExport.Visible = True
            ConfigurarRelatorioCurvaABC(vendas)

        Catch nex As ExcecaoNascomercio
            MessageBox.Show("Erro ao filtrar vendas: " & nex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Erro inesperado em Filtrar: " & ex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Exportar()
        Try
            Dim tipo As String = ObterTipoRelatorio()
            Dim dataInicial As String = ObterDataFormatada(txtDataInicial.Text, False)
            Dim dataFinal As String = ObterDataFormatada(txtDataFinal.Text, False)

            Dim objVenda As New ncRegras.nsVenda.rVenda
            Dim vendas As ColecaodVendasABC = objVenda.ListarVendasABC(dataInicial, dataFinal, tipo)

            If vendas Is Nothing OrElse vendas.Count = 0 Then
                MessageBox.Show("Nenhum dado para exportar.",
                                "Informação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If

            Using sfd As New SaveFileDialog()
                sfd.Title = "Salvar arquivo de Vendas ABC"
                sfd.Filter = "Arquivo CSV (*.csv)|*.csv"
                sfd.FileName = "VendasABC.csv"
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                If sfd.ShowDialog() = DialogResult.OK Then
                    ExportarParaCsvInterno(vendas, sfd.FileName)
                    MessageBox.Show("Arquivo exportado com sucesso!",
                                    "Sucesso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                End If
            End Using

        Catch nex As ExcecaoNascomercio
            MessageBox.Show("Erro ao exportar: " & nex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Erro inesperado em Exportar: " & ex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarParaCsvInterno(vendas As ColecaodVendasABC, caminhoArquivo As String)
        Using writer As New StreamWriter(caminhoArquivo, False, Encoding.UTF8)
            writer.WriteLine("Fabricante;Valor;PercReceita;PercAcumulado;ClasseAbc;Estrategia")

            For Each item As dCurvaAbc In vendas
                Dim linha As String = String.Format("{0};{1};{2};{3};{4};{5}",
                    item.Fabricante,
                    item.valor,
                    item.PercReceita,
                    item.PercAcumulado,
                    item.ClasseAbc,
                    item.Estrategia)
                writer.WriteLine(linha)
            Next
        End Using
    End Sub

    Private Sub ConfigurarRelatorioCurvaABC(ByVal vendas As ColecaodVendasABC)
        Try
            Dim arquivoPDF As String = "RelatorioVendasABC" & DateTime.Now.ToString("ddMMyyyy") & ".pdf"
            Dim caminhoCompleto As String = Path.Combine(_pathRelatorio, arquivoPDF)

            If File.Exists(caminhoCompleto) Then
                File.Delete(caminhoCompleto)
            End If

            Dim doc As New Document(PageSize.A4.Rotate())
            doc.SetMargins(10, 10, 15, 10)

            Using fileStream As New FileStream(caminhoCompleto, FileMode.Create)
                PdfWriter.GetInstance(doc, fileStream)
                doc.Open()

                ' ── Fontes ─────────────────────────────────────────────────────────────────
                Dim fonteTitulo As Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 16, BaseColor.BLACK)
                Dim fonteHeader As Font = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 8, BaseColor.WHITE)
                Dim fonteDados As Font = FontFactory.GetFont(BaseFont.HELVETICA, 7, BaseColor.BLACK)

                ' ── Cores ──────────────────────────────────────────────────────────────────
                Dim corHeader As BaseColor = New BaseColor(31, 73, 125)
                Dim corLinhaA As BaseColor = New BaseColor(198, 224, 180)
                Dim corLinhaB As BaseColor = New BaseColor(255, 235, 156)
                Dim corLinhaC As BaseColor = New BaseColor(255, 199, 206)
                Dim corAlt As BaseColor = New BaseColor(242, 242, 242)

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

                ' ── Tabela ─────────────────────────────────────────────────────────────────
                Dim tabela As New PdfPTable(6)
                tabela.WidthPercentage = 100
                tabela.SetWidths(New Single() {22, 10, 10, 10, 20, 28})
                tabela.HeaderRows = 1

                ' Cabeçalhos
                tabela.AddCell(CriarCelulaHeader("Fabricante", fonteHeader, corHeader))
                tabela.AddCell(CriarCelulaHeader("Valor", fonteHeader, corHeader))
                tabela.AddCell(CriarCelulaHeader("Percentual", fonteHeader, corHeader))
                tabela.AddCell(CriarCelulaHeader("Acumulado", fonteHeader, corHeader))
                tabela.AddCell(CriarCelulaHeader("Classe ABC", fonteHeader, corHeader))
                tabela.AddCell(CriarCelulaHeader("Estratégia", fonteHeader, corHeader))

                ' Dados
                Dim totalFaturamento As Decimal = 0
                Dim linha As Integer = 0

                For Each item As dCurvaAbc In vendas
                    Dim corFundo As BaseColor = ObtenerCorPorClasse(item.ClasseAbc, linha, corLinhaA, corLinhaB, corLinhaC, corAlt)

                    tabela.AddCell(CriarCelulaDado(item.Fabricante, Element.ALIGN_LEFT, fonteDados, corFundo))
                    tabela.AddCell(CriarCelulaDado(item.valor, Element.ALIGN_RIGHT, fonteDados, corFundo))
                    tabela.AddCell(CriarCelulaDado(item.PercReceita & "%", Element.ALIGN_RIGHT, fonteDados, corFundo))
                    tabela.AddCell(CriarCelulaDado(item.PercAcumulado & "%", Element.ALIGN_CENTER, fonteDados, corFundo))
                    tabela.AddCell(CriarCelulaDado(item.ClasseAbc, Element.ALIGN_LEFT, fonteDados, corFundo))
                    tabela.AddCell(CriarCelulaDado(item.Estrategia, Element.ALIGN_LEFT, fonteDados, corFundo))

                    totalFaturamento += item.valor
                    linha += 1
                Next

                ' Linha de totais
                Dim corTotais As BaseColor = New BaseColor(31, 73, 125)
                tabela.AddCell(CriarCelulaTotal("TOTAL", Element.ALIGN_LEFT, corTotais))
                tabela.AddCell(CriarCelulaTotal(linha & " produtos", Element.ALIGN_LEFT, corTotais))
                tabela.AddCell(CriarCelulaTotal(totalFaturamento.ToString("N2"), Element.ALIGN_RIGHT, corTotais))
                tabela.AddCell(CriarCelulaTotal("100%", Element.ALIGN_CENTER, corTotais))
                tabela.AddCell(CriarCelulaTotal("-", Element.ALIGN_CENTER, corTotais))
                tabela.AddCell(CriarCelulaTotal("-", Element.ALIGN_CENTER, corTotais))

                doc.Add(tabela)

                ' Legenda
                doc.Add(New Chunk(vbLf))
                Dim legenda As New Paragraph(
                    "Legenda: ■ Classe A = até 80% do faturamento   ■ Classe B = até 95% do faturamento   ■ Classe C = acima de 95% do faturamento",
                    FontFactory.GetFont(BaseFont.HELVETICA, 7, BaseColor.GRAY))
                legenda.Alignment = Element.ALIGN_LEFT
                doc.Add(legenda)

                doc.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao gerar relatório: " & ex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CriarCelulaHeader(texto As String, fonte As Font, corFundo As BaseColor) As PdfPCell
        Dim c As New PdfPCell(New Phrase(texto, fonte))
        c.BackgroundColor = corFundo
        c.HorizontalAlignment = Element.ALIGN_CENTER
        c.VerticalAlignment = Element.ALIGN_MIDDLE
        c.Padding = 5
        c.BorderColor = BaseColor.WHITE
        Return c
    End Function

    Private Function CriarCelulaDado(texto As String, alinhamento As Integer, fonte As Font, corFundo As BaseColor) As PdfPCell
        Dim c As New PdfPCell(New Phrase(texto, fonte))
        c.BackgroundColor = corFundo
        c.HorizontalAlignment = alinhamento
        c.VerticalAlignment = Element.ALIGN_MIDDLE
        c.Padding = 4
        c.BorderColor = New BaseColor(210, 210, 210)
        Return c
    End Function

    Private Function CriarCelulaTotal(texto As String, alinhamento As Integer, corFundo As BaseColor) As PdfPCell
        Dim c As New PdfPCell(New Phrase(texto, FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 8, BaseColor.WHITE)))
        c.BackgroundColor = corFundo
        c.HorizontalAlignment = alinhamento
        c.VerticalAlignment = Element.ALIGN_MIDDLE
        c.Padding = 5
        Return c
    End Function

    Private Function ObtenerCorPorClasse(classe As String, linha As Integer,
                                         corA As BaseColor, corB As BaseColor,
                                         corC As BaseColor, corAlt As BaseColor) As BaseColor
        Select Case classe
            Case "A - Prioridade Alta"
                Return corA
            Case "B - Prioridade Média"
                Return corB
            Case "C - Prioridade Baixa"
                Return corC
            Case Else
                Return If(linha Mod 2 = 0, BaseColor.WHITE, corAlt)
        End Select
    End Function

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Filtrar()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDataInicial.Text = New DateTime(Today.Year, Today.Month, 1).ToString("dd/MM/yyyy")
        Me.txtDataFinal.Text = New DateTime(Today.Year, Today.Month, DateTime.DaysInMonth(Today.Year, Today.Month)).ToString("dd/MM/yyyy")
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
        Dim arquivoPDF = "RelatorioVendasABC" & DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim caminhoCompleto As String = Path.Combine(_pathRelatorio, arquivoPDF)

        If File.Exists(caminhoCompleto) Then
            Try
                Process.Start(caminhoCompleto)
            Catch ex As Exception
                MessageBox.Show("Erro ao abrir relatório: " & ex.Message,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Arquivo não encontrado: " & caminhoCompleto,
                        "Informação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btoExport_Click(sender As Object, e As EventArgs) Handles btoExport.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Exportar()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtDataInicial_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtDataInicial.MaskInputRejected
    End Sub

    Private Sub rdQtde_CheckedChanged(sender As Object, e As EventArgs) Handles rdQtde.CheckedChanged
        Me.lstPix.Items.Clear()
    End Sub

    Private Sub rdValor_CheckedChanged(sender As Object, e As EventArgs) Handles rdValor.CheckedChanged
        Me.lstPix.Items.Clear()
    End Sub
End Class