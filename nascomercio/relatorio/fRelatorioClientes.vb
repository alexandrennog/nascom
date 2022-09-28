Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioClientes

  Public filtro As dFabricante


  Private Sub Filtrar()
    Dim parametros(1) As Microsoft.Reporting.WinForms.ReportParameter

    If txtCliente.Text.Trim <> "" Then
      parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
      parametros(0).Name = "Cliente"
      parametros(0).Values.Add(txtCliente.Text)
    Else
      parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
      parametros(0).Name = "Cliente"
    End If

    parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(1).Name = "Loja"
    parametros(1).Values.Add(mdiPrincipal.lblLoja.Text)

    Try
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

  Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try

      Me.clientesTableAdapter.Fill(Me.nascomercioDataSet.clientes)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta de clietes " & Me.ToString() & "]")

    End Try

    Me.rptRelatorio.RefreshReport()

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