Imports System.Globalization
Imports ncComum.nsExcecao
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante

' Relatorio "Pedidos de Compra x Entregas": mesma visao da planilha de compras
' por marca (COMPRAS / PEDIDO - ENTREGA - A RECEBER), agora tirada direto dos
' pedidos lancados no sistema e das baixas feitas pela Entrada de Estoque.
'
' Filtro de data = data do pedido. O que foi entregue/falta e sempre a posicao
' de hoje desses pedidos. Pedidos cancelados nao entram.
'
' Mesmo padrao do "Vendas por Fabricante": DataTable simples preenchida por SQL
' parametrizado (tabelas do script "scripts\new script\41 - pedido_compra.sql").
Public Class fRelatorioPedidosCompra

    ' Filtro que veio da lista de pedidos (opcional)
    Public fabricanteSugerido As Nullable(Of Integer)
    Public dataInicialSugerida As Nullable(Of DateTime)
    Public dataFinalSugerida As Nullable(Of DateTime)

    Private dtPedidos As New System.Data.DataTable()

    Private Sub CarregarComboFabricante()
        Dim regras As rFabricante
        Dim colecao As ColecaoFabricante

        Try
            regras = New rFabricante()
            colecao = regras.Listar()

            If colecao Is Nothing Then
                colecao = New ColecaoFabricante
            End If

            colecao.Insert(0, New dFabricante())

            cboFabricante.DataSource = Nothing
            cboFabricante.ValueMember = "cid"
            cboFabricante.DisplayMember = "nome"
            cboFabricante.DataSource = colecao

            If fabricanteSugerido.HasValue Then
                cboFabricante.SelectedValue = fabricanteSugerido.Value
            End If

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Fabricante.")
        End Try
    End Sub

    Private Function FabricanteSelecionado() As Nullable(Of Integer)
        Dim item As dFabricante = TryCast(cboFabricante.SelectedItem, dFabricante)
        If item Is Nothing OrElse Not item.cid.HasValue OrElse item.cid.Value <= 0 Then
            Return Nothing
        End If
        Return item.cid
    End Function

    Private Sub CarregarDados(ByVal dataInicial As DateTime, ByVal dataFinal As DateTime, ByVal fabricante As Nullable(Of Integer))
        dtPedidos.Clear()
        dtPedidos.Columns.Clear()

        ' Uma linha por item do pedido. O desconto do pedido e rateado pelo
        ' valor bruto de cada item; o valor entregue/a receber usa o preco
        ' liquido do item (decisao combinada: valor da entrega = pares
        ' entregues x preco do pedido). Numeros com 4 casas para as somas por
        ' marca fecharem certinho; o relatorio mostra com 2.
        Dim sql As String =
            " SELECT f.nome AS fabricante, " &
            "        p.cid AS pedido_cid, " &
            "        COALESCE(NULLIF(TRIM(p.numero), ''), CONCAT('#', p.cid)) AS pedido, " &
            "        p.data AS data, " &
            "        pr.referencia AS referencia, " &
            "        pr.descricao AS descricao, " &
            "        co.nome AS cor, " &
            "        i.tamanho AS tamanho, " &
            "        CAST(i.quantidade AS SIGNED) AS qtdPedida, " &
            "        CAST(i.quantidade * i.valorUnitario AS DECIMAL(14,4)) AS valorBruto, " &
            "        CAST(CASE WHEN t.bruto > 0 THEN i.quantidade * i.valorUnitario * p.descontoValor / t.bruto ELSE 0 END AS DECIMAL(14,4)) AS desconto, " &
            "        CAST(i.quantidade * i.valorUnitario - CASE WHEN t.bruto > 0 THEN i.quantidade * i.valorUnitario * p.descontoValor / t.bruto ELSE 0 END AS DECIMAL(14,4)) AS valorLiquido, " &
            "        CAST(i.quantidadeEntregue AS SIGNED) AS qtdEntregue, " &
            "        CAST(CASE WHEN i.quantidade > 0 THEN (i.quantidade * i.valorUnitario - CASE WHEN t.bruto > 0 THEN i.quantidade * i.valorUnitario * p.descontoValor / t.bruto ELSE 0 END) * i.quantidadeEntregue / i.quantidade ELSE 0 END AS DECIMAL(14,4)) AS valorEntregue, " &
            "        CAST(i.quantidade - i.quantidadeEntregue AS SIGNED) AS qtdReceber, " &
            "        CAST(CASE WHEN i.quantidade > 0 THEN (i.quantidade * i.valorUnitario - CASE WHEN t.bruto > 0 THEN i.quantidade * i.valorUnitario * p.descontoValor / t.bruto ELSE 0 END) * (i.quantidade - i.quantidadeEntregue) / i.quantidade ELSE 0 END AS DECIMAL(14,4)) AS valorReceber " &
            "   FROM pedidocompraitem i " &
            "  INNER JOIN pedidocompra p ON p.cid = i.pedidocompra_cid " &
            "  INNER JOIN (SELECT pedidocompra_cid, SUM(quantidade * valorUnitario) AS bruto " &
            "                FROM pedidocompraitem " &
            "               GROUP BY pedidocompra_cid) t ON t.pedidocompra_cid = p.cid " &
            "  INNER JOIN fabricantes f ON f.cid = p.fabricante_cid " &
            "  INNER JOIN produtos pr ON pr.cid = i.produtos_cid " &
            "   LEFT JOIN cor co ON co.cid = pr.cor_cid " &
            "  WHERE p.situacao <> 'C' " &
            "    AND p.data BETWEEN @dataInicial AND @dataFinal "

        If fabricante.HasValue Then
            sql &= " AND p.fabricante_cid = @fabricante "
        End If

        sql &= " ORDER BY f.nome, p.data, p.cid, pr.referencia, co.nome, i.tamanho "

        Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
            Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
                comando.Parameters.AddWithValue("@dataInicial", dataInicial.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                comando.Parameters.AddWithValue("@dataFinal", dataFinal.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))

                If fabricante.HasValue Then
                    comando.Parameters.AddWithValue("@fabricante", fabricante.Value)
                End If

                Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
                    adapter.Fill(dtPedidos)
                End Using
            End Using
        End Using
    End Sub

    Private Sub Filtrar()
        Dim dataInicial As DateTime
        Dim dataFinal As DateTime

        If Not DateTime.TryParseExact(txtDataInicial.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataInicial) Then
            MessageBox.Show("Data inicial inválida.", "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataInicial.Focus()
            Exit Sub
        End If

        If Not DateTime.TryParseExact(txtDataFinal.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dataFinal) Then
            MessageBox.Show("Data final inválida.", "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        If dataFinal < dataInicial Then
            MessageBox.Show("A data final é anterior à data inicial.", "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDataFinal.Focus()
            Exit Sub
        End If

        Dim fabricante As Nullable(Of Integer) = FabricanteSelecionado()

        Dim parametros(4) As Microsoft.Reporting.WinForms.ReportParameter
        parametros(0) = New Microsoft.Reporting.WinForms.ReportParameter("DataInicial", dataInicial.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(1) = New Microsoft.Reporting.WinForms.ReportParameter("DataFinal", dataFinal.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
        parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter("Fabricante", If(fabricante.HasValue, cboFabricante.Text, ""))
        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter("Loja", mdiPrincipal.lblLoja.Text)
        parametros(4) = New Microsoft.Reporting.WinForms.ReportParameter("Detalhado", If(chkDetalhado.Checked, "S", "N"))

        Try
            Cursor.Current = Cursors.WaitCursor

            CarregarDados(dataInicial, dataFinal, fabricante)

            rptRelatorio.LocalReport.DataSources.Clear()
            rptRelatorio.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsPedidosCompra", dtPedidos))

            rptRelatorio.LocalReport.SetParameters(parametros)
            rptRelatorio.RefreshReport()
        Catch ex As Exception
            MessageBox.Show("Erro ao gerar o relatório: " & ex.Message & vbCrLf & vbCrLf &
                            "Se a mensagem fala de tabela inexistente, rode o script ""41 - pedido_compra.sql"" no banco desta loja.",
                            "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub chkDetalhado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetalhado.CheckedChanged
        If Me.Visible Then
            Filtrar()
        End If
    End Sub

    Private Sub fRelatorioPedidosCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub fRelatorioPedidosCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Relatorio em paisagem: ajusta a largura da pagina a tela (senao as
            ' ultimas colunas ficam cortadas e precisa rolar para o lado)
            rptRelatorio.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

            ' Padrao: pedidos dos ultimos 6 meses
            Dim inicio As DateTime = If(dataInicialSugerida.HasValue, dataInicialSugerida.Value, Today.AddMonths(-6))
            Dim fim As DateTime = If(dataFinalSugerida.HasValue, dataFinalSugerida.Value, Today)

            Me.txtDataInicial.Text = inicio.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
            Me.txtDataFinal.Text = fim.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)

            CarregarComboFabricante()

            ' A sugestao vale so para esta abertura
            fabricanteSugerido = Nothing
            dataInicialSugerida = Nothing
            dataFinalSugerida = Nothing

            Filtrar()

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir o relatório de Pedidos de Compra [" & Me.ToString() & "]")
        End Try
    End Sub

End Class
