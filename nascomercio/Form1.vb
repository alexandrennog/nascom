Public Class fRelatorioCrediarioPix
    Private Sub btoFiltro_Click(sender As Object, e As EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub
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

        vendas = objVenda.ConsultarPix(dadosVenda)

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
End Class