Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioVendasVendedor

  Public filtro As dFabricante


  Private Sub Filtrar()
    Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

    parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(0).Name = "DataInicial"
    parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

    parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(1).Name = "DataFinal"
    parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

    If txtVendedor.Text <> "" Then
      parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
      parametros(2).Name = "Vendedor"
      parametros(2).Values.Add(txtVendedor.Text)
    Else
      parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
      parametros(2).Name = "Vendedor"
    End If

    parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(3).Name = "Loja"
    parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

    Try
      Me.v_vendassinteticoTableAdapter.Fill(Me.nascomercioDataSet.v_vendassintetico)
      rptRelatorio.LocalReport.SetParameters(parametros)
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

  Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Filtrar()
    End Select
  End Sub

  Private Sub fRelatorioVendasVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try

      Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
      Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")

      Filtrar()
    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

    End Try

  End Sub
End Class