Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncComum.nsExcecao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes
Imports ncDados.nsdParametroEstoque
Imports ncDados.nsVenda
Imports ncDados
Imports System.Configuration
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports LibPix.Impl
Imports QRCoder.PayloadGenerator.SwissQrCode
Imports System.Security.Cryptography
Imports Newtonsoft.Json.Linq

Public Class fRelatorioEstoque

    Public filtro As dFabricante

    Private Sub CarregarComboGrupo()
        Dim regras As rGrupo
        Dim colecao As ColecaoGrupo

        Try

            cboGrupo.DataSource = Nothing
            cboGrupo.Items.Clear()

            regras = New rGrupo()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dGrupo())

                cboGrupo.ValueMember = "cid"
                cboGrupo.DisplayMember = "nome"
                cboGrupo.DataSource = colecao
                cboGrupo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Grupo.")

        End Try
    End Sub

    Private Sub CarregarComboFornecedor()
        Dim regras As rFornecedor
        Dim colecao As ColecaoFornecedor

        Try

            cboFornecedor.DataSource = Nothing
            cboFornecedor.Items.Clear()

            regras = New rFornecedor()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dFornecedor())

                cboFornecedor.ValueMember = "cid"
                cboFornecedor.DisplayMember = "nome"
                cboFornecedor.DataSource = colecao
                cboFornecedor.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Fornecedor.")

        End Try
    End Sub

    Private Sub CarregarComboFabricante()
        Dim regras As rFabricante
        Dim colecao As ColecaoFabricante

        Try

            cboFabricante.DataSource = Nothing
            cboFabricante.Items.Clear()

            regras = New rFabricante()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dFabricante())

                cboFabricante.ValueMember = "cid"
                cboFabricante.DisplayMember = "nome"
                cboFabricante.DataSource = colecao
                cboFabricante.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Fabricante.")

        End Try
    End Sub

    Private Sub Filtrar()

        Dim dadosParametro As ColecaoParametroEstoque
        Dim dados As New dParametroEstoque
        Dim regraParametro As rParametro
        Dim result As String = Nothing

        'TODO: This line of code loads data into the 'nascomercioDataSet.v_estoque' table. You can move, or remove it, as needed.

        Dim parametros(5) As Microsoft.Reporting.WinForms.ReportParameter

        If Not String.IsNullOrEmpty(txtProduto.Text) Then
            dados.descricao = txtProduto.Text
        End If

        If Not String.IsNullOrEmpty(cboFornecedor.Text) Then
            dados.cidFornecedor = cboFornecedor.SelectedValue
        Else
            dados.cidFornecedor = 0
        End If

        If Not String.IsNullOrEmpty(cboFabricante.Text) Then
            dados.cidFabricante = cboFabricante.SelectedValue
        Else
            dados.cidFabricante = 0
        End If

        If Not String.IsNullOrEmpty(cboGrupo.Text) Then
            dados.cidGrupo = cboGrupo.SelectedValue
        Else
            dados.cidGrupo = 0
        End If

        If chkEstoque.Checked Then
            dados.valor = 1
        Else
            dados.valor = 0
        End If


        regraParametro = New rParametro()
        dadosParametro = regraParametro.fConsultarEstoque(dados)

        ' Consultar chave de acesso/validação
        If IsNothing(dadosParametro) Then
            Exit Sub
        End If

        Me.lstEstoque.Clear()

        Me.lstEstoque.View = View.Details
        Me.lstEstoque.GridLines = True
        Me.lstEstoque.FullRowSelect = True
        Me.lstEstoque.Columns.Clear()
        Me.lstEstoque.Items.Clear()

        Me.lstEstoque.Columns.Add("Fabricante").Width = 160
        Me.lstEstoque.Columns.Add("CID").Width = 80
        Me.lstEstoque.Columns.Add("Descrição").Width = 200
        Me.lstEstoque.Columns.Add("Referência").Width = 80
        Me.lstEstoque.Columns.Add("Item").Width = 80
        Me.lstEstoque.Columns.Add("ValorCompra").Width = 80
        Me.lstEstoque.Columns.Add("ValorVenda").Width = 80
        Me.lstEstoque.Columns.Add("Valor").Width = 80

        If dadosParametro Is Nothing Then
            Exit Sub
        End If
        Dim li As ListViewItem

        For Each item As dEstoque In dadosParametro
            li = New ListViewItem
            li.Text = item.Fabricante.ToString
            li.SubItems.Add(item.CID)
            li.SubItems.Add(item.Descricao)
            li.SubItems.Add(item.Referencia.ToString())
            li.SubItems.Add(item.Item.ToString())
            li.SubItems.Add(String.Format("{0:0,0.00}", item.ValorCompra))
            li.SubItems.Add(String.Format("{0:0,0.00}", item.ValorVenda))
            li.SubItems.Add(item.Valor.ToString())
            Me.lstEstoque.Items.Add(li)
        Next

        Try
            ConfigurarRelatorio(dadosParametro)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ConfigurarRelatorio(ByVal dadosParametro As ColecaoParametroEstoque)

        Dim hoje As DateTime = DateTime.Now

        Dim arquivoPDF = "RelatorioEstoque" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"

        If Not System.IO.Directory.Exists(ConfigurationManager.AppSettings("pathRelatorio")) Then
            System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings("pathRelatorio"))
        End If

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & "\" & arquivoPDF) Then
            System.IO.File.Delete(ConfigurationManager.AppSettings("pathRelatorio") & "\" & arquivoPDF)
        End If

        Dim doc As New Document(PageSize.A4.Rotate())
        doc.SetMargins(3, 2, 3, 2)
        PdfWriter.GetInstance(doc, New FileStream(ConfigurationManager.AppSettings("pathRelatorio") & "\" & arquivoPDF, FileMode.Create))

        doc.Open()

        Dim fonteTitulo As Font
        fonteTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22)

        Dim paragrafoTitulo As New Paragraph("Relatório de Estoque", fonteTitulo)
        paragrafoTitulo.Alignment = Element.ALIGN_CENTER
        paragrafoTitulo.SpacingBefore = 20
        paragrafoTitulo.SpacingAfter = 20


        Dim valorCompraSoma As Double = 0
        Dim valorVendaSoma As Double = 0
        Dim estoqueSoma As Integer = 0

        Dim tableHeader As New PdfPTable(6)
        tableHeader.DefaultCell.Border = Rectangle.NO_BORDER



        doc.Add(paragrafoTitulo)
        doc.Add(Chunk.NEWLINE)
        doc.Add(Chunk.NEWLINE)

        Dim table As New PdfPTable(8)

        Dim cell1 As New PdfPCell
        Dim cell2 As New PdfPCell
        Dim cell3 As New PdfPCell
        Dim cell4 As New PdfPCell
        Dim cell5 As New PdfPCell
        Dim cell6 As New PdfPCell
        Dim cell7 As New PdfPCell
        Dim cell8 As New PdfPCell

        Dim cells As New List(Of PdfPCell)
        Dim fonte As Font
        fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)

        Dim coluna1 As New Paragraph("Fabricante", fonte)
        Dim coluna2 As New Paragraph("Cid", fonte)
        Dim coluna3 As New Paragraph("Descricao", fonte)
        Dim coluna4 As New Paragraph("Referencia", fonte)
        Dim coluna5 As New Paragraph("Item", fonte)
        Dim coluna6 As New Paragraph("ValorCompra", fonte)
        Dim coluna7 As New Paragraph("ValorVenda", fonte)
        Dim coluna8 As New Paragraph("Valor", fonte)

        cell1.AddElement(coluna1)
        cell2.AddElement(coluna2)
        cell3.AddElement(coluna3)
        cell4.AddElement(coluna4)
        cell5.AddElement(coluna5)
        cell6.AddElement(coluna6)
        cell7.AddElement(coluna7)
        cell8.AddElement(coluna8)

        table.AddCell(cell1)
        table.AddCell(cell2)
        table.AddCell(cell3)
        table.AddCell(cell4)
        table.AddCell(cell5)
        table.AddCell(cell6)
        table.AddCell(cell7)
        table.AddCell(cell8)

        'new Chunk(expStringBuilder1.ToString(), infoFont2)
        Dim infoFont2 = FontFactory.GetFont("Kalinga", 8, New iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000")))

        For Each item As dEstoque In dadosParametro
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.Fabricante.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.CID.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.Descricao.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.Referencia.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.Item.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.ValorCompra.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.ValorVenda.ToString(), infoFont2))))
            table.AddCell(New PdfPCell(New Phrase(New Chunk(item.Valor.ToString(), infoFont2))))

            valorCompraSoma += item.ValorCompra
            valorVendaSoma += item.ValorVenda
            estoqueSoma += item.Valor

        Next

        tableHeader.AddCell("")
        tableHeader.AddCell("")
        tableHeader.AddCell("")
        tableHeader.AddCell("Valor Compra")
        tableHeader.AddCell("Valor Venda")
        tableHeader.AddCell("Estoque")

        tableHeader.AddCell("")
        tableHeader.AddCell("")
        tableHeader.AddCell("Total em Estoque:")
        tableHeader.AddCell(String.Format("{0:n}", valorCompraSoma))
        tableHeader.AddCell(String.Format("{0:n}", valorVendaSoma))
        tableHeader.AddCell(estoqueSoma.ToString())


        doc.Add(tableHeader)
        doc.Add(Chunk.NEWLINE)

        If Not dadosParametro Is Nothing Then
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
        CarregarComboGrupo()
        CarregarComboFornecedor()
        CarregarComboFabricante()

    End Sub

    Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Imprimir()
    End Sub
    Private Sub Imprimir()
        Dim arquivoPDF = "RelatorioEstoque" & System.DateTime.Now.ToString("ddMMyyyy") & ".pdf"
        Dim ProcessApplication As String = "AcroRd32"

        If System.IO.File.Exists(ConfigurationManager.AppSettings("pathRelatorio") & "\" & arquivoPDF) Then
            Process.Start(ConfigurationManager.AppSettings("pathRelatorio") & "\" & arquivoPDF)
        End If
    End Sub
End Class