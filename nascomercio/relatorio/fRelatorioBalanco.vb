Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncComum.nsExcecao

Public Class fRelatorioBalanco

    Public filtro As dFabricante

    ' Carrega os nomes dos produtos uma vez (ao abrir a tela) para o
    ' autocompletar do campo "Produto" - pedido do usuario: "ir aparecendo os
    ' nomes compativeis quando a pessoa estiver digitando". Usa o recurso
    ' nativo do TextBox (AutoCompleteMode/AutoCompleteSource) em vez de montar
    ' um dropdown customizado - mais simples e consistente com o resto do
    ' sistema, que nao tem nenhum padrao proprio de autocomplete ainda.
    Private Sub CarregarAutocompleteProduto()

        Try
            Dim regras As New rProduto
            Dim produtos As ColecaoProduto = regras.Listar()
            Dim fonte As New AutoCompleteStringCollection

            If Not produtos Is Nothing Then
                For Each item As dProduto In produtos
                    If Not String.IsNullOrWhiteSpace(item.descricao) Then
                        fonte.Add(item.descricao)
                    End If
                Next
            End If

            txtProduto.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtProduto.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtProduto.AutoCompleteCustomSource = fonte

        Catch ex As Exception
            ' Autocompletar e um extra - se a lista de produtos nao carregar por
            ' qualquer motivo, a tela continua funcionando normal (campo livre,
            ' sem sugestao), sem travar a abertura do relatorio por causa disso.
        End Try

    End Sub

    Private Sub Filtrar()

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

        CarregarAutocompleteProduto()

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