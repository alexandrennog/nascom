Imports MySql.Data.MySqlClient
Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante

Public Class fRelatorioVendasSintetico

  Public filtro As dFabricante


    'Private Sub Filtrar()
    '  Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

    '  parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
    '  parametros(0).Name = "DataInicial"
    '  parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

    '  parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
    '  parametros(1).Name = "DataFinal"
    '  parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

    '  If txtCliente.Text <> "" Then
    '    parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
    '    parametros(2).Name = "Cliente"
    '    parametros(2).Values.Add(txtCliente.Text)
    '  Else
    '    parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
    '    parametros(2).Name = "Cliente"
    '  End If

    '  parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    '  parametros(3).Name = "Loja"
    '  parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

    '  Try
    '    Me.v_vendassinteticoTableAdapter.Fill(Me.nascomercioDataSet.v_vendassintetico)
    '    rptRelatorio.LocalReport.SetParameters(parametros)
    '    rptRelatorio.RefreshReport()
    '  Catch ex As Exception
    '    MessageBox.Show(ex.Message)
    '  End Try
    'End Sub
    Private Sub Filtrar()
        Dim parametros(3) As Microsoft.Reporting.WinForms.ReportParameter

        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(0).Name = "DataInicial"
        parametros(0).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataInicial.Text))

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "DataFinal"
        parametros(1).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataBarras(txtDataFinal.Text))

        If txtCliente.Text <> "" Then
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Cliente"
            parametros(2).Values.Add(txtCliente.Text)
        Else
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Cliente"
        End If

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Loja"
        parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

        Try
            Dim acesso As New ncComum.nsAcessoBD.cAcessoBD

            Dim dataInicial As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text)
            Dim dataFinal As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text)

            If dataInicial Is Nothing OrElse dataFinal Is Nothing Then
                MessageBox.Show("Data inválida.")
                Exit Sub
            End If

            Dim clienteEscapado As String = MySqlHelper.EscapeString(txtCliente.Text)

            Dim sql As String =
            "SELECT controle, data, valorvenda, desconto, vendedor, nome, troca, defeito, vale, valeEmitido " &
            "FROM v_vendassintetico " &
            "WHERE data BETWEEN '" & dataInicial & " 00:00:00' AND '" & dataFinal & " 23:59:59' " &
            "AND ('" & clienteEscapado & "' = '' OR nome LIKE CONCAT('%', '" & clienteEscapado & "', '%'))"

            Dim ds As DataSet = acesso.ExecutarDS(sql)

            Me.nascomercioDataSet.v_vendassintetico.Rows.Clear()
            For Each origem As DataRow In ds.Tables(0).Rows
                Dim novaLinha As DataRow = Me.nascomercioDataSet.v_vendassintetico.NewRow()
                For Each coluna As DataColumn In ds.Tables(0).Columns
                    If coluna.ColumnName = "data" Then
                        novaLinha("data") = Convert.ToDateTime(origem("data").ToString())
                    Else
                        novaLinha(coluna.ColumnName) = origem(coluna.ColumnName)
                    End If
                Next
                Me.nascomercioDataSet.v_vendassintetico.Rows.Add(novaLinha)
            Next

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

  Private Sub fRelatorioVendasSintetico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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