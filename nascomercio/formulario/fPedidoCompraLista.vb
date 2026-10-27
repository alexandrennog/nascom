Imports System.Globalization
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsPedidoCompra
Imports ncRegras.nsPedidoCompra
Imports ncComum.nsExcecao

' Lista de Pedidos de Compra (por fabricante/marca).
' Acesso: Inventario de Produtos [F11] > "Pedidos de Compra <F7>".
Public Class fPedidoCompraLista

    ' Mantem o filtro entre uma abertura e outra da tela (ex.: ao voltar do
    ' cadastro de um pedido a lista continua filtrada do mesmo jeito)
    Private Shared filtroFabricante As Nullable(Of Integer)
    Private Shared filtroDataInicial As Nullable(Of DateTime)
    Private Shared filtroDataFinal As Nullable(Of DateTime)
    Private Shared filtroSituacao As String = "ABERTOS"
    Private Shared filtroInicializado As Boolean = False

    Private carregando As Boolean = False

    Private Sub fPedidoCompraLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carregando = True

        Try
            If Not filtroInicializado Then
                ' Padrao: pedidos dos ultimos 6 meses ainda nao entregues.
                ' Data final em branco = sem limite (assim pedidos lancados
                ' depois, ou com data futura, continuam aparecendo).
                filtroDataInicial = Today.AddMonths(-6)
                filtroDataFinal = Nothing
                filtroInicializado = True
            End If

            CarregarComboFabricante()
            CarregarComboSituacao()

            txtDataInicial.Text = FormatarData(filtroDataInicial)
            txtDataFinal.Text = FormatarData(filtroDataFinal)

        Finally
            carregando = False
        End Try

        Pesquisar()
    End Sub

    Private Sub CarregarComboFabricante()
        Dim regras As New rFabricante
        Dim colecao As ColecaoFabricante

        Try
            colecao = regras.Listar()

            If colecao Is Nothing Then
                colecao = New ColecaoFabricante
            End If

            ' Primeira opcao vazia = todos os fabricantes
            colecao.Insert(0, New dFabricante() With {.nome = "(todos)"})

            cboFabricante.DataSource = Nothing
            cboFabricante.ValueMember = "cid"
            cboFabricante.DisplayMember = "nome"
            cboFabricante.DataSource = colecao

            If filtroFabricante.HasValue Then
                cboFabricante.SelectedValue = filtroFabricante.Value
            End If

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos dados de Fabricante.")
        End Try
    End Sub

    Private Sub CarregarComboSituacao()
        cboSituacao.Items.Clear()
        cboSituacao.Items.Add(New ItemSituacao("ABERTOS", "Em aberto"))
        cboSituacao.Items.Add(New ItemSituacao("", "Todos"))
        cboSituacao.Items.Add(New ItemSituacao("A", "Aberto"))
        cboSituacao.Items.Add(New ItemSituacao("P", "Parcial"))
        cboSituacao.Items.Add(New ItemSituacao("E", "Entregue"))
        cboSituacao.Items.Add(New ItemSituacao("C", "Cancelado"))

        cboSituacao.SelectedIndex = 0
        For i As Integer = 0 To cboSituacao.Items.Count - 1
            If CType(cboSituacao.Items(i), ItemSituacao).codigo = filtroSituacao Then
                cboSituacao.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub Pesquisar()
        Dim regras As New rPedidoCompra
        Dim pedidos As ColecaoPedidoCompra
        Dim situacao As String
        Dim totalPares As Integer = 0
        Dim totalFaltam As Integer = 0
        Dim totalLiquido As Decimal = 0
        Dim totalReceber As Decimal = 0
        Dim quantidade As Integer = 0

        If carregando Then
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Guarda o filtro para a proxima vez que a tela abrir
            filtroFabricante = FabricanteSelecionado()
            filtroDataInicial = LerData(txtDataInicial.Text)
            filtroDataFinal = LerData(txtDataFinal.Text)
            filtroSituacao = CType(cboSituacao.SelectedItem, ItemSituacao).codigo

            ' "Em aberto" = Aberto + Parcial (filtrado aqui na tela)
            situacao = If(filtroSituacao = "ABERTOS", "", filtroSituacao)

            pedidos = regras.Listar(filtroFabricante, filtroDataInicial, filtroDataFinal, situacao)

            dgvPedido.Rows.Clear()

            For Each pedido As dPedidoCompra In pedidos
                If filtroSituacao = "ABERTOS" AndAlso pedido.situacao <> "A" AndAlso pedido.situacao <> "P" Then
                    Continue For
                End If

                Dim faltam As Integer = Math.Max(0, pedido.totalPares - pedido.totalEntregue)
                Dim linha As DataGridViewRow = dgvPedido.Rows(dgvPedido.Rows.Add())

                linha.Cells("cid").Value = pedido.cid
                linha.Cells("Numero").Value = If(String.IsNullOrEmpty(pedido.numero), "#" & pedido.cid.ToString(), pedido.numero)
                linha.Cells("Data").Value = FormatarData(pedido.data)
                linha.Cells("Fabricante").Value = pedido.fabricanteNome
                linha.Cells("Pares").Value = pedido.totalPares
                linha.Cells("Entregues").Value = pedido.totalEntregue
                linha.Cells("Faltam").Value = faltam
                linha.Cells("ValorLiquido").Value = pedido.totalLiquido
                linha.Cells("Situacao").Value = pedido.situacaoDescricao

                If pedido.situacao = "C" Then
                    linha.DefaultCellStyle.ForeColor = Color.Gray
                ElseIf pedido.situacao = "E" Then
                    linha.DefaultCellStyle.ForeColor = Color.DarkGreen
                End If

                quantidade += 1
                If pedido.situacao <> "C" Then
                    totalPares += pedido.totalPares
                    totalFaltam += faltam
                    totalLiquido += pedido.totalLiquido
                    If pedido.totalPares > 0 Then
                        totalReceber += pedido.totalLiquido * faltam / pedido.totalPares
                    End If
                End If
            Next

            lblResumo.Text = quantidade.ToString() & If(quantidade = 1, " pedido", " pedidos") &
                             "   |   " & totalPares.ToString("N0") & " pares (faltam " & totalFaltam.ToString("N0") & ")" &
                             "   |   Líquido R$ " & totalLiquido.ToString("N2") &
                             "   |   A receber R$ " & totalReceber.ToString("N2")

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos Pedidos de Compra: " & ex.Message, "Pedidos de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function FabricanteSelecionado() As Nullable(Of Integer)
        Dim item As dFabricante = TryCast(cboFabricante.SelectedItem, dFabricante)
        If item Is Nothing OrElse Not item.cid.HasValue OrElse item.cid.Value <= 0 Then
            Return Nothing
        End If
        Return item.cid
    End Function

    Private Sub Cadastrar()
        fPedidoCompraForm.pedidoCid = Nothing
        fPedidoCompraForm.fabricanteSugerido = FabricanteSelecionado()
        mdiPrincipal.CarregarPedidoCompraForm()
    End Sub

    Private Sub SelecionarItem()
        If dgvPedido.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Dim cidPedido As Nullable(Of Integer) = Nothing
        Try
            cidPedido = CInt(dgvPedido.CurrentRow.Cells("cid").Value)
        Catch
            cidPedido = Nothing
        End Try

        If cidPedido.HasValue Then
            fPedidoCompraForm.pedidoCid = cidPedido
            fPedidoCompraForm.fabricanteSugerido = Nothing
            mdiPrincipal.CarregarPedidoCompraForm()
        End If
    End Sub

    Private Sub AbrirRelatorio()
        fRelatorioPedidosCompra.fabricanteSugerido = FabricanteSelecionado()
        fRelatorioPedidosCompra.dataInicialSugerida = LerData(txtDataInicial.Text)
        fRelatorioPedidosCompra.dataFinalSugerida = LerData(txtDataFinal.Text)
        mdiPrincipal.CarregarRelatorioPedidosCompra()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Pesquisar()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub btoAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAbrir.Click
        SelecionarItem()
    End Sub

    Private Sub btoRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRelatorio.Click
        AbrirRelatorio()
    End Sub

    Private Sub dgvPedido_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPedido.CellDoubleClick
        If e.RowIndex >= 0 Then
            SelecionarItem()
        End If
    End Sub

    Private Sub cboFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFabricante.SelectionChangeCommitted, cboSituacao.SelectionChangeCommitted
        Pesquisar()
    End Sub

    Private Sub fPedidoCompraLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Cadastrar()
            Case Keys.F6
                Pesquisar()
            Case Keys.F8
                AbrirRelatorio()
            Case Keys.Enter
                If dgvPedido.Focused Then
                    e.Handled = True
                    SelecionarItem()
                Else
                    Pesquisar()
                End If
        End Select
    End Sub

    Private Shared Function LerData(ByVal texto As String) As Nullable(Of DateTime)
        Dim data As DateTime
        If DateTime.TryParseExact(If(texto, "").Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, data) Then
            Return data
        End If
        Return Nothing
    End Function

    Private Shared Function FormatarData(ByVal data As Nullable(Of DateTime)) As String
        If data.HasValue Then
            Return data.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
        End If
        Return ""
    End Function

    ' Item do combo de situacao (codigo + texto)
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
