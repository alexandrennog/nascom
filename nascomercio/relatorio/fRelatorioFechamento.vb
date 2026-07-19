Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports Unimake.Business.DFe.Xml.ESocial

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

        Dim acesso As New ncComum.nsAcessoBD.cAcessoBD

        Dim dataInicial As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(Convert.ToDateTime(Me.txtDataInicial.Text).AddDays(-1).ToString("dd/MM/yyyy"))
        Dim dataFinal As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(Convert.ToDateTime(Me.txtDataFinal.Text).ToString("dd/MM/yyyy"))

        If dataInicial Is Nothing OrElse dataFinal Is Nothing Then
            MessageBox.Show("Data inválida.")
            Exit Sub
        End If

        Dim sql As String =
            "SELECT controle, clienteId, usuarioId, data, dinheiro, cheque, chequePre, " &
            "cartaoDebito, cartaoCredito, crediario, parcelas, desconto, condicao, recebido, " &
            "troco, total, troca, vale, defeito, terminal, retirada, valeEmitido, vendedor, caixa, " &
            "crediarioPagamento, pix " &
            "FROM v_fechamento " &
            "WHERE data BETWEEN '" + dataInicial + " 00:00' AND  '" + dataFinal + " 23:59'"


        Dim ds As DataSet = acesso.ExecutarDS(sql)

        Me.nascomercioDataSet.v_fechamento.Rows.Clear()
        For Each origem As DataRow In ds.Tables(0).Rows
            Dim novaLinha As DataRow = Me.nascomercioDataSet.v_fechamento.NewRow()
            For Each coluna As DataColumn In ds.Tables(0).Columns
                If coluna.ColumnName = "data" Then
                    novaLinha("data") = Convert.ToDateTime(origem("data").ToString())
                Else
                    novaLinha(coluna.ColumnName) = origem(coluna.ColumnName)
                End If
            Next
            Me.nascomercioDataSet.v_fechamento.Rows.Add(novaLinha)
        Next

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
    'Private Sub Filtrar()
    '    Dim acesso As New ncComum.nsAcessoBD.cAcessoBD
    '    Dim sql As String =
    '    "SELECT controle, clienteId, usuarioId, data, dinheiro, cheque, chequePre, " &
    '    "cartaoDebito, cartaoCredito, crediario, parcelas, desconto, condicao, recebido, " &
    '    "troco, total, troca, vale, defeito, terminal, retirada, valeEmitido, vendedor, caixa, " &
    '    "crediarioPagamento, pix " &
    '    "FROM v_fechamento " &
    '    $"WHERE data BETWEEN ' DATE_FORMAT(" + txtDataInicial.Text + ", '%Y-%m-%d')" & "' " &
    '    "AND ' DATE_FORMAT(" + txtDataInicial.Text + ", '%Y-%m-%d')" & "' " &
    '    "AND (caixa = '" & Me.txtCaixa.Text & "' OR '" & Me.txtCaixa.Text & "' = '')"

    '    Dim ds As DataSet = acesso.ExecutarDS(sql)
    '    Me.nascomercioDataSet.v_fechamento.Rows.Clear()
    '    Me.nascomercioDataSet.v_fechamento.Merge(ds.Tables(0))

    '    ' ... resto do SetParameters/RefreshReport
    'End Sub
    'Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    '    Try

    '        Me.v_fechamentoTableAdapter.Fill(Me.nascomercioDataSet.v_fechamento)

    '    Catch nex As ExcecaoNascomercio

    '        MessageBox.Show(nex.Message)

    '    Catch ex As Exception

    '        MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

    '    End Try

    '    Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
    '    Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")
    '    Select Case mdiPrincipal.gUsuario.usuarioPerfil_codigo
    '        Case "a", "g"
    '            Me.txtCaixa.Text = ""
    '            Me.txtCaixa.ReadOnly = False
    '        Case "c"
    '            Me.txtCaixa.Text = mdiPrincipal.gUsuario.usuario
    '            Me.txtCaixa.ReadOnly = True
    '    End Select

    '    Filtrar()

    'End Sub
    Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try


            'Me.v_fechamentoTableAdapter.Connection.ConnectionString = ConfigurationManager.ConnectionStrings("nascomercio").ConnectionString

            'Me.v_fechamentoTableAdapter.ClearBeforeFill = True
            'Me.v_fechamentoTableAdapter.Fill(Me.nascomercioDataSet.v_fechamento)


            Dim acesso As New ncComum.nsAcessoBD.cAcessoBD

            'Dim ds As DataSet = acesso.ExecutarDS(sql)


            'Dim dataInicial As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"))
            'Dim dataFinal As String = ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(DateTime.Now.ToString("dd/MM/yyyy"))

            'If dataInicial Is Nothing OrElse dataFinal Is Nothing Then
            '    MessageBox.Show("Data inválida.")
            '    Exit Sub
            'End If

            'Dim sql As String =
            '"SELECT controle, clienteId, usuarioId, data, dinheiro, cheque, chequePre, " &
            '"cartaoDebito, cartaoCredito, crediario, parcelas, desconto, condicao, recebido, " &
            '"troco, total, troca, vale, defeito, terminal, retirada, valeEmitido, vendedor, caixa, " &
            '"crediarioPagamento, pix " &
            '"FROM v_fechamento " &
            '"WHERE data BETWEEN '" + dataInicial + " 00:00' AND  '" + dataFinal + " 23:59'"


            'Dim ds As DataSet = acesso.ExecutarDS(sql)

            'Me.nascomercioDataSet.v_fechamento.Rows.Clear()
            'For Each origem As DataRow In ds.Tables(0).Rows
            '    Dim novaLinha As DataRow = Me.nascomercioDataSet.v_fechamento.NewRow()
            '    For Each coluna As DataColumn In ds.Tables(0).Columns
            '        If coluna.ColumnName = "data" Then
            '            novaLinha("data") = Convert.ToDateTime(origem("data").ToString())
            '        Else
            '            novaLinha(coluna.ColumnName) = origem(coluna.ColumnName)
            '        End If
            '    Next
            '    Me.nascomercioDataSet.v_fechamento.Rows.Add(novaLinha)
            'Next


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