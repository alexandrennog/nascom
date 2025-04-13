Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncComum.nsExcecao

Public Class fRelatorioTransferencia

    Public filtro As dFabricante

    Private Sub Filtrar()

        Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "DataFinal"
        parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

        If txtProduto.Text <> "" Then
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Produto"
            parametros(2).Values.Add(txtProduto.Text)
        Else
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Produto"
        End If

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Loja"
        parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

        rptRelatorio.LocalReport.SetParameters(parametros)

        Try
            rptRelatorio.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDataInicial.Text = Today.AddMonths(-1).ToString("dd/MM/yyyy")
        Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy")

        'TODO: This line of code loads data into the 'nascomercioDataSet.v_transferencia' table. You can move, or remove it, as needed.
        Me.v_transferenciaTableAdapter.Fill(Me.nascomercioDataSet.v_transferencia)
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