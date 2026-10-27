Imports System.Globalization
Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsDashboardCompras
Imports ncRegras.nsDashboardCompras

' Relatorio "Compras x Vendas x Estoque" (pedido do cliente, 27/10/2026):
' cruza o que entrou de compra no estoque com o que foi vendido e com o
' estoque de hoje, por marca, para decidir a recompra ("comprei 100, vendi 30,
' tem 70 - compro mais ou nao?").
'
'   Comprou  = entradas de estoque no periodo (logestoque)
'   Vendeu   = vendas + vales no periodo
'   Estoque  = estoque de hoje
'   % vendido = vendeu / (vendeu + estoque de hoje)
'
' Procedure sp_dashboard_compras_x_vendas (script "scripts\new script\42 -
' painel_compras_x_vendas.sql"), lida por rDashboardCompras.ListarComprasVendas.
Public Class fRelatorioComprasVendas

    ' Regra da coluna Situacao
    Private Const PERCENTUAL_REPOR As Decimal = 70D
    Private Const PERCENTUAL_VENDEU_POUCO As Decimal = 30D

    ' Opcoes do "Ver por" (codigo passado ao relatorio no parametro VerPor)
    Private Const VER_MARCA As String = "M"
    Private Const VER_REFERENCIA As String = "R"
    Private Const VER_TAMANHO As String = "T"

    Private dtDados As New System.Data.DataTable()
    Private carregando As Boolean = False

    Private Sub CarregarComboFabricante()
        Dim colecao As ColecaoFabricante

        Try
            colecao = New rFabricante().Listar()

            If colecao Is Nothing Then
                colecao = New ColecaoFabricante
            End If

            ' Primeira opcao em branco = todas as marcas
            colecao.Insert(0, New dFabricante())

            cboFabricante.DataSource = Nothing
            cboFabricante.ValueMember = "cid"
            cboFabricante.DisplayMember = "nome"
            cboFabricante.DataSource = colecao

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Fabricante.")
        End Try
    End Sub

    Private Sub CarregarComboVerPor()
        cboVerPor.Items.Clear()
        cboVerPor.Items.Add(New ItemVerPor(VER_MARCA, "Marca"))
        cboVerPor.Items.Add(New ItemVerPor(VER_REFERENCIA, "Referência"))
        cboVerPor.Items.Add(New ItemVerPor(VER_TAMANHO, "Tamanho"))
        cboVerPor.SelectedIndex = 1
    End Sub

    Private Function FabricanteSelecionado() As Nullable(Of Integer)
        Dim item As dFabricante = TryCast(cboFabricante.SelectedItem, dFabricante)
        If item Is Nothing OrElse Not item.cid.HasValue OrElse item.cid.Value <= 0 Then
            Return Nothing
        End If
        Return item.cid
    End Function

    Private Function VerPorSelecionado() As String
        Dim item As ItemVerPor = TryCast(cboVerPor.SelectedItem, ItemVerPor)
        If item Is Nothing Then
            Return VER_REFERENCIA
        End If
        Return item.codigo
    End Function

    Private Sub MontarTabela()
        dtDados.Clear()
        dtDados.Columns.Clear()
        dtDados.Columns.Add("fabricante", GetType(String))
        dtDados.Columns.Add("referencia", GetType(String))
        dtDados.Columns.Add("descricao", GetType(String))
        dtDados.Columns.Add("cor", GetType(String))
        dtDados.Columns.Add("tamanho", GetType(String))
        dtDados.Columns.Add("comprado", GetType(Integer))
        dtDados.Columns.Add("vendido", GetType(Integer))
        dtDados.Columns.Add("estoque", GetType(Integer))
        ' Estoque usado na conta do % (negativo = erro de lancamento, conta 0)
        dtDados.Columns.Add("estoqueCalculo", GetType(Integer))
        dtDados.Columns.Add("percVendido", GetType(Decimal))
        dtDados.Columns.Add("situacao", GetType(String))
    End Sub

    Private Sub CarregarDados(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime,
                              ByVal fabricante As Nullable(Of Integer), ByVal verPor As String)

        Dim lista As ColecaoDashboardCompraVenda

        MontarTabela()

        lista = New rDashboardCompras().ListarComprasVendas(dataInicial.ToString("ddMMyyyy", CultureInfo.InvariantCulture),
                                                            dataFinal.ToString("ddMMyyyy", CultureInfo.InvariantCulture),
                                                            fabricante,
                                                            verPor = VER_TAMANHO)

        If verPor = VER_MARCA Then
            lista = AgruparPorMarca(lista)
        End If

        For Each item As dDashboardCompraVendaItem In lista
            Dim linha As System.Data.DataRow = dtDados.NewRow()
            Dim perc As Nullable(Of Decimal) = item.percentualVendido

            linha("fabricante") = If(String.IsNullOrEmpty(item.fabricante), "(sem marca)", item.fabricante)
            linha("referencia") = item.referencia
            linha("descricao") = item.descricao
            linha("cor") = item.cor
            linha("tamanho") = item.tamanho
            linha("comprado") = item.comprado
            linha("vendido") = item.vendido
            linha("estoque") = item.estoque
            linha("estoqueCalculo") = Math.Max(0, item.estoque)
            If perc.HasValue Then
                linha("percVendido") = perc.Value
            Else
                linha("percVendido") = DBNull.Value
            End If
            linha("situacao") = DescreverSituacao(item)

            dtDados.Rows.Add(linha)
        Next
    End Sub

    ' Soma as linhas (referencia + cor) de cada marca
    Private Function AgruparPorMarca(ByVal lista As ColecaoDashboardCompraVenda) As ColecaoDashboardCompraVenda
        Dim marcas As New Dictionary(Of String, dDashboardCompraVendaItem)
        Dim retorno As New ColecaoDashboardCompraVenda

        For Each item As dDashboardCompraVendaItem In lista
            Dim chave As String = If(item.fabricante, "")
            Dim marca As dDashboardCompraVendaItem = Nothing

            If Not marcas.TryGetValue(chave, marca) Then
                marca = New dDashboardCompraVendaItem
                marca.fabricante = chave
                marca.referencia = ""
                marca.descricao = ""
                marca.cor = ""
                marca.tamanho = ""
                marcas.Add(chave, marca)
                retorno.Add(marca)
            End If

            marca.comprado += item.comprado
            marca.vendido += item.vendido
            marca.estoque += Math.Max(0, item.estoque)
        Next

        Return retorno
    End Function

    ' Repor        = vendeu PERCENTUAL_REPOR% ou mais do que tinha
    ' Vendeu pouco = vendeu PERCENTUAL_VENDEU_POUCO% ou menos e ainda tem estoque
    Private Function DescreverSituacao(ByVal item As dDashboardCompraVendaItem) As String
        Dim perc As Nullable(Of Decimal) = item.percentualVendido

        If item.vendido > 0 AndAlso item.estoque <= 0 Then
            Return "Esgotado - repor"
        End If
        If Not perc.HasValue Then
            Return ""
        End If
        If perc.Value >= PERCENTUAL_REPOR Then
            Return "Repor"
        End If
        If perc.Value <= PERCENTUAL_VENDEU_POUCO Then
            Return "Vendeu pouco"
        End If
        Return "Normal"
    End Function

    Private Sub Filtrar()
        Dim dataInicial As DateTime
        Dim dataFinal As DateTime

        If carregando Then
            Exit Sub
        End If

        If Not DateTime.TryParseExact(txtDataInicial.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataInicial) Then
            MessageBox.Show("Data inicial inválida.", "Compras x Vendas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataInicial.Focus()
            Exit Sub
        End If

        If Not DateTime.TryParseExact(txtDataFinal.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataFinal) Then
            MessageBox.Show("Data final inválida.", "Compras x Vendas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        If dataFinal < dataInicial Then
            MessageBox.Show("A data final é anterior à data inicial.", "Compras x Vendas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        Dim fabricante As Nullable(Of Integer) = FabricanteSelecionado()
        Dim verPor As String = VerPorSelecionado()

        Dim parametros(6) As Microsoft.Reporting.WinForms.ReportParameter
        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataInicial", dataInicial.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter("DataFinal", dataFinal.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter("Fabricante", If(fabricante.HasValue, cboFabricante.Text, ""))
        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter("Loja", mdiPrincipal.lblLoja.Text)
        parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter("VerPor", verPor)
        parametros(5) = New Microsoft.Reporting.WinForms.ReportParameter("PercRepor", PERCENTUAL_REPOR.ToString(CultureInfo.InvariantCulture))
        parametros(6) = New Microsoft.Reporting.WinForms.ReportParameter("PercPouco", PERCENTUAL_VENDEU_POUCO.ToString(CultureInfo.InvariantCulture))

        Try
            Cursor.Current = Cursors.WaitCursor

            CarregarDados(dataInicial, dataFinal, fabricante, verPor)

            rptRelatorio.LocalReport.DataSources.Clear()
            rptRelatorio.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsComprasVendas", dtDados))

            rptRelatorio.LocalReport.SetParameters(parametros)
            rptRelatorio.RefreshReport()
        Catch ex As Exception
            MessageBox.Show("Erro ao gerar o relatório: " & ex.Message & vbCrLf & vbCrLf &
                            "Se a mensagem fala de procedure inexistente, rode o script ""42 - painel_compras_x_vendas.sql"" no banco desta loja.",
                            "Compras x Vendas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    ' Trocar a marca ou o "Ver por" ja refaz o relatorio
    Private Sub cboFiltro_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFabricante.SelectionChangeCommitted, cboVerPor.SelectionChangeCommitted
        Filtrar()
    End Sub

    Private Sub fRelatorioComprasVendas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub fRelatorioComprasVendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            carregando = True

            ' Relatorio em paisagem: ajusta a largura da pagina a tela (senao as
            ' ultimas colunas ficam cortadas e precisa rolar para o lado)
            rptRelatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

            ' Padrao: do inicio do mes ate hoje (igual ao Painel de Compras)
            Me.txtDataInicial.Text = New DateTime(Today.Year, Today.Month, 1).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)

            CarregarComboFabricante()
            CarregarComboVerPor()

            carregando = False
            Filtrar()

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir o relatório Compras x Vendas x Estoque [" & Me.ToString() & "]")
        Finally
            carregando = False
        End Try
    End Sub

    ' Item do combo "Ver por" (codigo + texto)
    Private Class ItemVerPor
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
