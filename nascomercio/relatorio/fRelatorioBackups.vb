Imports System.Globalization
Imports System.IO
Imports ncComum.nsExcecao
Imports ncDados.nsBackupNuvem
Imports ncRegras.nsBackupNuvem

' Relatorio de Backups (local + nuvem): historico de cada execucao do backup
' (tabela backupnuvem - script "43 - backup_nuvem.sql"), com o resumo no topo
' (ultimo backup na nuvem, quantos deram certo/errado) e graficos por dia.
' Acesso: Relatorios > "Backups" e botao "Relatorio de Backups" na tela de Backup.
Public Class fRelatorioBackups

    ' Nuvem "em dia" = ultimo backup com sucesso ha no maximo 1 dia
    Private Const DIAS_ALERTA As Integer = 1

    Private dtDados As New System.Data.DataTable()
    Private carregando As Boolean = False

    Private Sub CarregarComboSituacao()
        cboSituacao.Items.Clear()
        cboSituacao.Items.Add(New ItemSituacao("", "Todas"))
        cboSituacao.Items.Add(New ItemSituacao("S", "Sucesso"))
        cboSituacao.Items.Add(New ItemSituacao("P", "Só local"))
        cboSituacao.Items.Add(New ItemSituacao("F", "Falha"))
        cboSituacao.Items.Add(New ItemSituacao("E", "Em andamento"))
        cboSituacao.SelectedIndex = 0
    End Sub

    Private Function SituacaoSelecionada() As String
        Dim item As ItemSituacao = TryCast(cboSituacao.SelectedItem, ItemSituacao)
        Return If(item Is Nothing, "", item.codigo)
    End Function

    Private Sub MontarTabela()
        dtDados.Clear()
        dtDados.Columns.Clear()
        dtDados.Columns.Add("dataInicio", GetType(DateTime))
        dtDados.Columns.Add("diaChave", GetType(String))   ' yyyy-MM-dd (agrupa/ordena o grafico)
        dtDados.Columns.Add("dia", GetType(String))        ' dd/MM
        dtDados.Columns.Add("data", GetType(String))       ' dd/MM/yyyy
        dtDados.Columns.Add("hora", GetType(String))
        dtDados.Columns.Add("duracao", GetType(String))
        dtDados.Columns.Add("tipo", GetType(String))
        dtDados.Columns.Add("terminal", GetType(String))
        dtDados.Columns.Add("usuario", GetType(String))
        dtDados.Columns.Add("situacao", GetType(String))
        dtDados.Columns.Add("situacaoDescricao", GetType(String))
        dtDados.Columns.Add("bancoMB", GetType(Decimal))
        dtDados.Columns.Add("zipMB", GetType(Decimal))
        dtDados.Columns.Add("nuvem", GetType(String))
        dtDados.Columns.Add("email", GetType(String))
        dtDados.Columns.Add("detalhe", GetType(String))
    End Sub

    Private Sub CarregarDados(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime, ByVal situacao As String)
        Dim lista As ColecaoBackupNuvem = New rBackupNuvem().Listar(dataInicial, dataFinal, situacao)

        MontarTabela()

        For Each item As dBackupNuvem In lista
            Dim linha As System.Data.DataRow = dtDados.NewRow()
            Dim inicio As DateTime = item.dataInicio.GetValueOrDefault()

            linha("dataInicio") = inicio
            linha("diaChave") = inicio.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            linha("dia") = inicio.ToString("dd/MM", CultureInfo.InvariantCulture)
            linha("data") = inicio.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            linha("hora") = inicio.ToString("HH:mm", CultureInfo.InvariantCulture)
            linha("duracao") = FormatarDuracao(item)
            linha("tipo") = item.tipoDescricao
            linha("terminal") = item.terminal
            linha("usuario") = item.usuarioNome
            linha("situacao") = item.situacao
            linha("situacaoDescricao") = item.situacaoDescricao
            linha("bancoMB") = Math.Round(CDec(item.bytesBanco) / 1048576D, 1)
            linha("zipMB") = Math.Round(CDec(item.bytesZip) / 1048576D, 1)
            linha("nuvem") = If(item.enviadoNuvem, "Sim", "Não")
            linha("email") = If(item.emailEnviado, "Enviado", "")
            ' Sucesso: nome do arquivo; senao, o motivo
            If item.situacao = "S" Then
                linha("detalhe") = If(String.IsNullOrEmpty(item.arquivo), item.chaveNuvem, Path.GetFileName(item.arquivo))
            ElseIf item.situacao = "P" Then
                linha("detalhe") = "Cópia local: " & Path.GetFileName(item.arquivo) & " - " & item.mensagem
            Else
                linha("detalhe") = item.mensagem
            End If

            dtDados.Rows.Add(linha)
        Next
    End Sub

    Private Shared Function FormatarDuracao(ByVal item As dBackupNuvem) As String
        If item.situacao = "E" Then
            Return "-"
        End If
        Dim t As TimeSpan = TimeSpan.FromSeconds(item.duracaoSegundos)
        If t.TotalHours >= 1 Then
            Return CInt(Math.Floor(t.TotalHours)).ToString() & "h" & t.Minutes.ToString("00")
        End If
        Return t.Minutes.ToString() & "m" & t.Seconds.ToString("00") & "s"
    End Function

    ' Resumo que nao depende do filtro: ultimo backup que chegou na nuvem
    Private Sub MontarResumoNuvem(ByRef ultimoTexto As String, ByRef statusTexto As String, ByRef statusCor As String)
        Dim ultimoOk As dBackupNuvem = New rBackupNuvem().Ultimo(True)

        If ultimoOk Is Nothing OrElse Not ultimoOk.dataInicio.HasValue Then
            ultimoTexto = "Nenhum"
            statusTexto = "SEM BACKUP NA NUVEM"
            statusCor = "#C62828"
            Exit Sub
        End If

        Dim dias As Integer = CInt(Math.Floor((Today - ultimoOk.dataInicio.Value.Date).TotalDays))
        ultimoTexto = ultimoOk.dataInicio.Value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)

        If dias <= DIAS_ALERTA Then
            statusTexto = If(dias <= 0, "EM DIA (hoje)", "EM DIA (ontem)")
            statusCor = "#2E7D32"
        Else
            statusTexto = "ATENÇÃO: " & dias.ToString() & " dias sem backup na nuvem"
            statusCor = "#C62828"
        End If
    End Sub

    Private Sub Filtrar()
        Dim dataInicial As DateTime
        Dim dataFinal As DateTime

        If carregando Then
            Exit Sub
        End If

        If Not DateTime.TryParseExact(txtDataInicial.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataInicial) Then
            MessageBox.Show("Data inicial inválida.", "Relatório de Backups", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataInicial.Focus()
            Exit Sub
        End If

        If Not DateTime.TryParseExact(txtDataFinal.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataFinal) Then
            MessageBox.Show("Data final inválida.", "Relatório de Backups", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        If dataFinal < dataInicial Then
            MessageBox.Show("A data final é anterior à data inicial.", "Relatório de Backups", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            If Not New rBackupNuvem().TabelaExiste() Then
                MessageBox.Show("O histórico de backups ainda não existe neste banco." & vbCrLf &
                                "Rode o script ""scripts\new script\43 - backup_nuvem.sql"" no MySQL desta loja.",
                                "Relatório de Backups", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            CarregarDados(dataInicial, dataFinal, SituacaoSelecionada())

            Dim ultimoTexto As String = ""
            Dim statusTexto As String = ""
            Dim statusCor As String = ""
            MontarResumoNuvem(ultimoTexto, statusTexto, statusCor)

            Dim parametros(8) As Microsoft.Reporting.WinForms.ReportParameter
            parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataInicial", dataInicial.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
            parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter("DataFinal", dataFinal.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter("Situacao", If(SituacaoSelecionada() = "", "", cboSituacao.Text))
            parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter("Loja", mdiPrincipal.lblLoja.Text)
            parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter("UltimoNuvem", ultimoTexto)
            parametros(5) = New Microsoft.Reporting.WinForms.ReportParameter("StatusNuvem", statusTexto)
            parametros(6) = New Microsoft.Reporting.WinForms.ReportParameter("StatusCor", statusCor)
            parametros(7) = New Microsoft.Reporting.WinForms.ReportParameter("Bucket", Configuracao("bucketName"))
            parametros(8) = New Microsoft.Reporting.WinForms.ReportParameter("PastaLocal", Configuracao("directoryBackupPath").Replace("\\", "\"))

            rptRelatorio.LocalReport.DataSources.Clear()
            rptRelatorio.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsBackups", dtDados))
            rptRelatorio.LocalReport.SetParameters(parametros)
            rptRelatorio.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Erro ao gerar o relatório: " & ex.Message, "Relatório de Backups", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Shared Function Configuracao(ByVal chave As String) As String
        Dim valor As String = System.Configuration.ConfigurationManager.AppSettings(chave)
        Return If(valor, "")
    End Function

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub cboSituacao_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSituacao.SelectionChangeCommitted
        Filtrar()
    End Sub

    Private Sub fRelatorioBackups_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub fRelatorioBackups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            carregando = True

            ' Relatorio em paisagem: ajusta a largura da pagina a tela
            rptRelatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

            ' Padrao: ultimos 30 dias
            Me.txtDataInicial.Text = Today.AddDays(-29).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)

            CarregarComboSituacao()

            carregando = False
            Filtrar()

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir o Relatório de Backups [" & Me.ToString() & "]")
        Finally
            carregando = False
        End Try
    End Sub

    Private Class ItemSituacao
        Public ReadOnly codigo As String
        Public ReadOnly texto As String

        Public Sub New(ByVal codigo As String, ByVal texto As String)
            Me.codigo = codigo
            Me.texto = texto
        End Sub

        Public Overrides Function ToString() As String
            Return texto
        End Function
    End Class

End Class
