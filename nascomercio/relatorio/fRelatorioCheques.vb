Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioCheques

  Public filtro As dFabricante


  Private Sub Filtrar()
    Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

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

    parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(2).Name = "DataInicial"
    parametros(2).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

    parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(3).Name = "DataFinal"
    parametros(3).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

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

      Me.txtDataInicial.Text = Today.AddMonths(-1).ToString("dd/MM/yyyy")
      Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy")

      Filtrar()

      Me.v_chequesTableAdapter.Fill(Me.nascomercioDataSet.v_cheques)

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

    End Try


  End Sub

  Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Filtrar()
    End Select
  End Sub

  Private Sub btoBaixar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBaixar.Click
    Dim regrasCheques As New ncRegras.nsCheques.rCheques

    regrasCheques.Baixar()

    MessageBox.Show("Cheques baixados até a data corrente!")
  End Sub
End Class