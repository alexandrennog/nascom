Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioFechamento

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
    Me.nascomercioDataSet.v_fechamento.Clear()

    Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
      Dim sql As String = "SELECT `controle`, `clienteId`, `usuarioId`, `data`, `dinheiro`, `cheque`, `chequePre`, `cartaoDebito`, `cartaoCredito`, `crediario`, `parcelas`, `desconto`, `condicao`, `recebido`, `troco`, `total`, `troca`, `vale`, `defeito`, `terminal`, `retirada`, `valeEmitido`, `vendedor`, `caixa`, `crediarioPagamento`, `pix` FROM `v_fechamento` WHERE `data` BETWEEN @dataInicial AND @dataFinal"

      If Me.txtCaixa.Text.Trim() <> "" Then
        sql &= " AND `caixa` LIKE @caixa"
      End If

      Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
        comando.Parameters.AddWithValue("@dataInicial", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))
        comando.Parameters.AddWithValue("@dataFinal", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))

        If Me.txtCaixa.Text.Trim() <> "" Then
          comando.Parameters.AddWithValue("@caixa", "%" & Me.txtCaixa.Text.Trim() & "%")
        End If

        Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
          adapter.Fill(Me.nascomercioDataSet.v_fechamento)
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

    parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(2).Name = "Loja"
    parametros(2).Values.Add(mdiPrincipal.lblLoja.Text)

    parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
    parametros(3).Name = "Caixa"
    parametros(3).Values.Add(Me.txtCaixa.Text)

    Try
      CarregarDados()
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
