Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioCrediario

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

  ' Reproduz em SQL a mesma lógica que o Crediario.rdlc já aplicava (client-side) sobre o
  ' dataset completo, com base nas caixinhas "Recebidas" (chkRecebidas) e "A Receber" (chkReceber):
  '   - Recebidas marcada:  filtra por dataPagamento dentro do período E valorpago >= valorreceber
  '   - A Receber marcada:  filtra por datavencimento dentro do período E valorpago <= valorreceber
  '   - Nenhuma marcada:    datavencimento >= DataInicial E dataPagamento <= DataFinal (sem filtro de valor)
  '   - As duas marcadas:   dataPagamento >= DataInicial E datavencimento <= DataFinal E valorpago = valorreceber
  Private Sub CarregarDados()
    Me.nascomercioDataSet.v_crediario.Clear()

    Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
      Dim sql As String =
        "SELECT `codigobarras`, `nome`, `dataemissao`, `dataPagamento`, `valor`, `valorpago`, `valorreceber`, `valortotal`, `datavencimento`, `situacaoCrediario` " &
        "FROM `v_crediario` " &
        "WHERE IF(@recebidos, `dataPagamento`, `datavencimento`) >= @dataInicial " &
        "AND IF(@receber, `datavencimento`, `dataPagamento`) <= @dataFinal " &
        "AND IF(@recebidos, `valorpago`, `valorreceber`) >= `valorreceber` " &
        "AND IF(@receber, `valorpago`, `valorreceber`) <= `valorreceber`"

      If txtCliente.Text.Trim() <> "" Then
        sql &= " AND `nome` LIKE @cliente"
      End If

      Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
        comando.Parameters.AddWithValue("@dataInicial", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))
        comando.Parameters.AddWithValue("@dataFinal", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))
        comando.Parameters.AddWithValue("@recebidos", chkRecebidas.Checked)
        comando.Parameters.AddWithValue("@receber", chkReceber.Checked)

        If txtCliente.Text.Trim() <> "" Then
          comando.Parameters.AddWithValue("@cliente", "%" & txtCliente.Text.Trim() & "%")
        End If

        Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
          adapter.Fill(Me.nascomercioDataSet.v_crediario)
        End Using
      End Using
    End Using
  End Sub

  Private Sub Filtrar()
    If PeriodoMuitoLargo() Then
      Exit Sub
    End If

    Dim parametros(5) As Microsoft.Reporting.WinForms.ReportParameter

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
        parametros(2).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))

    parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(3).Name = "DataFinal"
        parametros(3).Values.Add(ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))

    parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(4).Name = "Recebidos"
    parametros(4).Values.Add(chkRecebidas.Checked)

    parametros(5) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(5).Name = "Receber"
    parametros(5).Values.Add(chkReceber.Checked)

    Try
      CarregarDados()
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

    Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
    Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy")

    Try
      Filtrar()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Credi�rio [" & Me.ToString() & "]")

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

End Class
