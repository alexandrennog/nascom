Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncComum.nsExcecao

Public Class fRelatorioTransferencia

    Public filtro As dFabricante

    Private Function PeriodoMuitoLargo() As Boolean
        Dim dataInicial As DateTime
        Dim dataFinal As DateTime

        If Not DateTime.TryParse(txtDataInicial.Text, dataInicial) OrElse Not DateTime.TryParse(txtDataFinal.Text, dataFinal) Then
            Return False
        End If

        Dim dias As Double = (dataFinal - dataInicial).TotalDays

        If dias > 60 Then
            Dim resposta = MessageBox.Show(
                "O período selecionado (" & Math.Round(dias).ToString() & " dias) é bem largo e a consulta pode demorar bastante." & vbCrLf & vbCrLf &
                "Deseja continuar mesmo assim?",
                "Período largo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Return resposta <> Windows.Forms.DialogResult.Yes
        End If

        Return False
    End Function

    Private Sub CarregarDados()
        Me.nascomercioDataSet.v_transferencia.Clear()

        Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
            Dim sql As String = "SELECT v_transferencia.* FROM v_transferencia WHERE data BETWEEN @dataInicial AND @dataFinal"

            If txtProduto.Text.Trim() <> "" Then
                sql &= " AND descricao LIKE @produto"
            End If

            Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
                comando.Parameters.AddWithValue("@dataInicial", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))
                comando.Parameters.AddWithValue("@dataFinal", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))

                If txtProduto.Text.Trim() <> "" Then
                    comando.Parameters.AddWithValue("@produto", "%" & txtProduto.Text.Trim() & "%")
                End If

                Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
                    adapter.Fill(Me.nascomercioDataSet.v_transferencia)
                End Using
            End Using
        End Using
    End Sub

    Private Sub Filtrar()
        If PeriodoMuitoLargo() Then
            Exit Sub
        End If

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
            CarregarDados()
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

        CarregarDados()
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
