Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fRelatorioGrupoProduto

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
        Me.nascomercioDataSet.v_vendas.Clear()

        Using conexao As New MySql.Data.MySqlClient.MySqlConnection(Global.nascomercio.My.MySettings.Default.nascomercioConnectionString)
            ' Corrigido em 28/09/2026, 2a rodada: a 1a correcao usava
            ' produtos.efdCodigoCategoria -> categoria.cid (o cadastro de
            ' Categoria usado no relatorio de SPED/EFD). Testando, a coluna
            ' continuou em branco pra praticamente todo produto - sinal de que
            ' esse campo fiscal nao e preenchido no cadastro do dia a dia (so
            ' pro EFD mesmo).
            '
            ' O nome do proprio arquivo desse relatorio (GrupoProduto.rdlc,
            ' classe fRelatorioGrupoProduto) e' a pista de qual era a intencao
            ' original: agrupar por GRUPO de produto, no' pela Categoria fiscal
            ' nem por Fabricante. Grupo e' outro cadastro proprio (produtos.
            ' grupo_cid -> grupo.cid), usado de verdade no cadastro de produto
            ' (filtro/gravacao em pProduto.vb) - mais provavel de estar
            ' preenchido do que o campo fiscal. Troquei pra usar esse.
            '
            ' Reproduz a mesma logica da view v_vendas (vendas + vales, mesmo
            ' UNION ALL), so trocando o Join de fabricantes por um Left Join em
            ' grupo - Left (nao Inner) pra um produto sem grupo cadastrado
            ' continuar aparecendo na lista, em vez de sumir. O nome do grupo
            ' continua saindo na coluna "fabricante" do dataset/relatorio (nao
            ' criei coluna nova) porque o DataSet tipado (nascomercioDataSet) e
            ' o .rdlc ja tem esse campo pronto e funcionando - so o CONTEUDO
            ' mudou, de marca pra grupo/categoria.
            Dim sql As String = "SELECT controle, data, descricao, quantidade, valorcompra, valorvenda, desconto, vendedor, nome, fabricante, referencia " &
                "FROM ( " &
                "SELECT vendas.controle AS controle, vendas.data AS data, produtos.descricao AS descricao, " &
                "vendasprodutos.quantidade AS quantidade, produtos.valorCompra AS valorcompra, vendasprodutos.valor AS valorvenda, " &
                "vendas.desconto AS desconto, vendas.vendedor AS vendedor, clientes.nome AS nome, " &
                "COALESCE(grupo.nome, 'Sem grupo') AS fabricante, produtos.referencia AS referencia " &
                "FROM vendasprodutos " &
                "INNER JOIN produtos ON vendasprodutos.produto = produtos.cid " &
                "INNER JOIN vendas ON vendasprodutos.controle = vendas.controle " &
                "INNER JOIN clientes ON vendas.clienteId = clientes.cid " &
                "LEFT JOIN grupo ON produtos.grupo_cid = grupo.cid " &
                "UNION ALL " &
                "SELECT vales.controle AS controle, vales.data AS data, produtos.descricao AS descricao, " &
                "valesprodutos.quantidade AS quantidade, produtos.valorCompra AS valorcompra, valesprodutos.valor AS valorvenda, " &
                "vales.desconto AS desconto, vales.vendedor AS vendedor, clientes.nome AS nome, " &
                "COALESCE(grupo.nome, 'Sem grupo') AS fabricante, produtos.referencia AS referencia " &
                "FROM valesprodutos " &
                "INNER JOIN produtos ON valesprodutos.produto = produtos.cid " &
                "INNER JOIN vales ON valesprodutos.controle = vales.controle " &
                "INNER JOIN clientes ON vales.clienteId = clientes.cid " &
                "LEFT JOIN grupo ON produtos.grupo_cid = grupo.cid " &
                ") v_vendas_grupo " &
                "WHERE data BETWEEN @dataInicial AND @dataFinal"

            If txtFabricante.Text.Trim() <> "" Then
                sql &= " AND fabricante LIKE @fabricante"
            End If

            Using comando As New MySql.Data.MySqlClient.MySqlCommand(sql, conexao)
                comando.Parameters.AddWithValue("@dataInicial", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataInicial.Text))
                comando.Parameters.AddWithValue("@dataFinal", ncComum.nsFuncoes.cFuncoes.FormatarDataUniversal(txtDataFinal.Text))

                If txtFabricante.Text.Trim() <> "" Then
                    comando.Parameters.AddWithValue("@fabricante", "%" & txtFabricante.Text.Trim() & "%")
                End If

                Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(comando)
                    adapter.Fill(Me.nascomercioDataSet.v_vendas)
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

        If txtFabricante.Text <> "" Then
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fabricante"
            parametros(2).Values.Add(txtFabricante.Text)
        Else
            parametros(2) = New Microsoft.Reporting.WinForms.ReportParameter
            parametros(2).Name = "Fabricante"
        End If

        parametros(3) = New Microsoft.Reporting.WinForms.ReportParameter
        parametros(3).Name = "Loja"
        parametros(3).Values.Add(mdiPrincipal.lblLoja.Text)

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

    Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Filtrar()
        End Select
    End Sub

    Private Sub fRelatorioGrupoProduto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.txtDataInicial.Text = Today.ToString("dd/MM/yyyy")
            Me.txtDataFinal.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")

            Filtrar()
        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

        End Try

    End Sub

End Class
