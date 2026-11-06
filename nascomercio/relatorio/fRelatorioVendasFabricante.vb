Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante

Public Class fRelatorioVendasFabricante

    ' DataTable simples (não faz parte do nascomercioDataSet tipado) preenchida direto
    ' pela view v_vendasfabricante (ver scripts\new script\40 - v_vendasfabricante.sql).
    Private dtVendasFabricante As New System.Data.DataTable()

    Private Sub CarregarComboFabricante()
        Dim regras As rFabricante
        Dim colecao As ColecaoFabricante

        Try

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
        dtVendasFabricante.Clear()
        dtVendasFabricante.Columns.Clear()

        Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
            Dim sql As String = "SELECT `codigo`, `produto`, `referencia`, `cor`, `fabricante`, `cd_fabricante`, `controle`, `quantidade`, `valor`, `total_valor`, `data` FROM `v_vendasfabricante` WHERE `data` BETWEEN @dataInicial AND @dataFinal"

            If cboFabricante.Text.Trim() <> "" Then
                sql &= " AND `fabricante` LIKE @fabricante"
            End If

            Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
                comando.Parameters.AddWithValue("@dataInicial", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))
                comando.Parameters.AddWithValue("@dataFinal", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))

                If cboFabricante.Text.Trim() <> "" Then
                    comando.Parameters.AddWithValue("@fabricante", "%" & cboFabricante.Text.Trim() & "%")
                End If

                Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
                    adapter.Fill(dtVendasFabricante)
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

        If cboFabricante.Text <> "" Then
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fabricante"
            parametros(2).Values.Add(cboFabricante.Text)
        Else
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fabricante"
        End If

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Loja"
        parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

        Try
            CarregarDados()

            rptRelatorio.LocalReport.DataSources.Clear()
            rptRelatorio.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("nascomercioDataSet_v_vendasfabricante", dtVendasFabricante))

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

    Private Sub fRelatorioVendasFabricante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub fRelatorioVendasFabricante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
            Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")

            CarregarComboFabricante()

            Filtrar()
        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

        End Try

    End Sub

End Class
