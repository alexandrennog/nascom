Imports System.Configuration
Imports System.IO
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncDados.nsVenda
Imports ncRegras.nsFabricante
Imports Unimake.Business.DFe.Xml.SNCM

Public Class fRelatorioVendasNfe

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

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Caixa"
        parametros(3).Values.Add(Me.txtCaixa.Text)
        'dadosVenda.Caixa = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtCaixa.Text)


        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaodVendasNfe
        Me.lstPix.View = View.Details

        Dim otherItems As String() = {"Cupom", "DataVenda", "Total"}
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Cupom").Width = 80
        Me.lstPix.Columns.Add("DataVenda").Width = 80
        Me.lstPix.Columns.Add("Total")

        vendas = objVenda.ListarVendasNfe(ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataInicial.Text), ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataFinal.Text))

        If vendas Is Nothing Then
            Exit Sub
        End If

        btoExport.Visible = True

        Dim li As ListViewItem

        Dim totTotal As Decimal

        For Each item As dVendasNfe In vendas
            li = New ListViewItem
            li.Text = item.Cupom.ToString
            li.SubItems.Add(item.DataVenda)
            li.SubItems.Add(item.Valor)
            Me.lstPix.Items.Add(li)
            totTotal = totTotal + item.Valor
        Next

        ' Corrigido em 28/09/2026: a lista so tem 3 colunas (Cupom, DataVenda,
        ' Total), mas essa linha adicionava 4 SubItems - o 4o (o valor da
        ' soma em si) nao tinha coluna pra entrar e o ListView simplesmente
        ' nao mostrava ele. Por isso a linha "Total:" aparecia sem o numero
        ' do total do lado.
        li = New ListViewItem
        li.Text = ""
        li.SubItems.Add("Total:")
        li.SubItems.Add(totTotal.ToString())
        Me.lstPix.Items.Add(li)

        ConfigurarRelatorio(vendas)

        'Try
        '    ConfigurarRelatorio(dadosVenda)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Private Sub Exportar()
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

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Caixa"
        parametros(3).Values.Add(Me.txtCaixa.Text)
        'dadosVenda.Caixa = ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtCaixa.Text)


        Dim objVenda As New ncRegras.nsVenda.rVenda
        Dim vendas As ncDados.nsVenda.ColecaodVendasNfe
        Me.lstPix.View = View.Details

        Dim otherItems As String() = {"Cupom", "DataVenda", "Total"}
        Me.lstPix.View = View.Details
        Me.lstPix.GridLines = True
        Me.lstPix.FullRowSelect = True
        Me.lstPix.Columns.Clear()
        Me.lstPix.Items.Clear()

        Me.lstPix.Columns.Add("Cupom").Width = 80
        Me.lstPix.Columns.Add("DataVenda").Width = 80
        Me.lstPix.Columns.Add("Total")

        vendas = objVenda.ListarVendasNfe(ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataInicial.Text), ncComum.nsFuncoes.cFuncoes.FormatarData(txtDataFinal.Text))

        Using sfd As New SaveFileDialog()

            sfd.Title = "Salvar arquivo de Vendas NFe"
            sfd.Filter = "Arquivo CSV (*.csv)|*.csv"
            sfd.FileName = "VendasNFe.csv"
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            If sfd.ShowDialog() = DialogResult.OK Then

                Using writer As New StreamWriter(sfd.FileName, False, Encoding.UTF8)

                    ' Cabeçalho
                    writer.WriteLine("Cupom;DataVenda;Valor")

                    ' Dados
                    For Each item As dVendasNfe In vendas

                        Dim linha As String = String.Format("{0};{1};{2}",
                                                            item.Cupom,
                                                            item.DataVenda,
                                                            item.Valor)

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

        Dim paragrafoTitulo As New Paragraph("Relatório de Vendas NFe", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20

        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        ' A tabela tem 3 colunas de verdade (Cupom, DataVenda, Valor) - antes estava
        ' declarada com 4 colunas (PdfPTable(4)), com 4 células no cabeçalho mas só 3
        ' células por linha de venda dentro do loop. O iTextSharp preenche a grade em
        ' sequência a cada N células (N = número de colunas), então a partir da 2ª
        ' venda cada linha ficava misturada com a venda seguinte - e a linha de Total
        ' no final acabava caindo em colunas erradas (ou sumindo visualmente),
        ' dependendo de quantas vendas tinham no período.
        Dim table As New PdfPTable(3)

        Dim cell1 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cells As New List(Of PdfPCell)

        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)

        Dim coluna1 As New Paragraph("Cupom", fonte)
        Dim coluna4 As New Paragraph("DataVenda", fonte)
        Dim coluna5 As New Paragraph("Valor", fonte)

        cell1.AddElement(coluna1)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)

        table.AddCell(cell1)
        table.AddCell(cell4)
        table.AddCell(cell5)

        Dim totTotal As Decimal

        For Each item As dVendasNfe In vendas
            table.AddCell(New PdfPCell(New Phrase(item.Cupom.ToString())))
            table.AddCell(New PdfPCell(New Phrase(item.DataVenda)))
            table.AddCell(New PdfPCell(New Phrase(item.Valor)))
            totTotal = totTotal + item.Valor
        Next

        table.AddCell(New PdfPCell(New Phrase("")))
        table.AddCell(New PdfPCell(New Phrase("Total: ")))
        table.AddCell(New PdfPCell(New Phrase(totTotal.ToString())))

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
        ' Precisa ser o MESMO nome de arquivo usado em ConfigurarRelatorio() para
        ' gerar o PDF - antes estava "RelatorioPix" (resto de copia/cola de outra
        ' tela), então o arquivo procurado aqui nunca existia e o botão Imprimir
        ' não fazia nada (nem erro, nem abria o PDF).
        Dim arquivoPDF = "RelatorioVendasNFe" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & arquivoPDF)
        End If
    End Sub

    Private Sub btoExport_Click(sender As Object, e As EventArgs) Handles btoExport.Click
        Exportar()
    End Sub
End Class