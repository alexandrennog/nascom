Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncComum.nsExcecao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fRelatorioEstoque

    Public filtro As dFabricante

    Private Sub CarregarComboFornecedor()
        Dim regras As rFornecedor
        Dim colecao As ColecaoFornecedor

        Try

            cboFornecedor.DataSource = Nothing
            cboFornecedor.Items.Clear()

            regras = New rFornecedor()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dFornecedor())

                cboFornecedor.ValueMember = "cid"
                cboFornecedor.DisplayMember = "nome"
                cboFornecedor.DataSource = colecao
                cboFornecedor.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Fornecedor.")

        End Try
    End Sub

    Private Sub CarregarComboFabricante()
        Dim regras As rFabricante
        Dim colecao As ColecaoFabricante

        Try

            cboFabricante.DataSource = Nothing
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

    Private Sub Filtrar()

        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim result As String = Nothing

        'TODO: This line of code loads data into the 'nascomercioDataSet.v_estoque' table. You can move, or remove it, as needed.
        Me.v_estoqueTableAdapter.Fill(Me.nascomercioDataSet.v_estoque)

        Dim parametros(5) As Microsoft.Reporting.WinForms.ReportParameter

        If txtProduto.Text <> "" Then
            parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(0).Name = "Produto"
            parametros(0).Values.Add(txtProduto.Text)
        Else
            parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(0).Name = "Produto"
        End If

        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(1).Name = "Loja"
        parametros(1).Values.Add(mdiPrincipal.lblLoja.Text)

        If cboFornecedor.Text <> "" Then
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fornecedor"
            parametros(2).Values.Add(cboFornecedor.Text)
        Else
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fornecedor"
        End If

        If cboFabricante.Text <> "" Then
            parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(3).Name = "Fabricante"
            parametros(3).Values.Add(cboFabricante.Text)
        Else
            parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(3).Name = "Fabricante"
        End If

        If chkEstoque.Checked Then
            parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(4).Name = "Estoque"
            parametros(4).Values.Add("0")
        Else
            parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(4).Name = "Estoque"
            parametros(4).Values.Add("-1")
        End If


        regraParametro = New rParametro()
        dadosParametro = regraParametro.Consultar(cConstantes.Parametros.IsDecimal)

        ' Consultar chave de acesso/validação
        If Not IsNothing(dadosParametro) Then
            result = dadosParametro.valor
        End If

        parametros(5) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(5).Name = "IsDecimal"
        parametros(5).Values.Add(result)

        rptRelatorio.LocalReport.SetParameters(parametros)

        Try
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
        CarregarComboFornecedor()
        CarregarComboFabricante()

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