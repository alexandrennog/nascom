Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioFechamento


  Private Sub Filtrar()
    Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

    parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(0).Name = "DataInicial"
    parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

    parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(1).Name = "DataFinal"
    parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

    parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(2).Name = "Loja"
    parametros(2).Values.Add(mdiPrincipal.lblLoja.Text)

    parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(3).Name = "Caixa"
    parametros(3).Values.Add(Me.txtCaixa.Text)

    Try
      rptFechamento.LocalReport.SetParameters(parametros)
      rptFechamento.RefreshReport()
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

      Me.v_fechamentoTableAdapter.Fill(Me.nascomercioDataSet.v_fechamento)

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

End Class