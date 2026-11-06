Imports System.Globalization
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsPedidoCompra
Imports ncRegras.nsPedidoCompra
Imports ncComum.nsExcecao

' Cadastro de um Pedido de Compra (cabecalho + itens por referencia/cor/tamanho).
'
' Como usar:
'   1. Escolha o fabricante.
'   2. Escolha o produto (referencia + cor) e clique em "Adicionar grade <F3>":
'      entram todos os tamanhos daquele produto com 0 pares.
'   3. Digite os pares de cada tamanho (e ajuste o valor do par, se precisar).
'      Tamanho que ficar com 0 nao e gravado.
'   4. Desconto do pedido todo em % ou em R$ (um calcula o outro).
'   5. Salvar <F2>.
'
' A baixa (pares entregues) e feita sozinha pela tela de Entrada de Estoque.
Public Class fPedidoCompraForm

    ' Pedido a abrir (Nothing = pedido novo). Definido pela lista antes de abrir a tela.
    Public pedidoCid As Nullable(Of Integer)
    ' Fabricante ja selecionado na lista, para sugerir num pedido novo
    Public fabricanteSugerido As Nullable(Of Integer)

    Private Shared ReadOnly culturaBR As CultureInfo = New CultureInfo("pt-BR")

    Private situacaoAtual As String = ""
    Private cidsExcluidos As New List(Of Integer)
    Private carregando As Boolean = False
    Private alterado As Boolean = False
    Private fabricanteAtual As Nullable(Of Integer)
    ' True quando o desconto foi digitado em %: ai, se as quantidades mudarem,
    ' o valor em R$ e recalculado mantendo o mesmo percentual. Quando digitado
    ' em R$ (ou ao abrir um pedido gravado), o R$ fica fixo e o % e que se ajusta.
    Private descontoEmPercentual As Boolean = False

#Region "Abertura"

    Private Sub fPedidoCompraForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' O icone de cancelar do projeto e 128x128 (os outros botoes usam 48x48);
        ' reduz para 48x48 senao ele cobre o texto e os botoes vizinhos.
        AjustarIconeBotao(btoCancelarPedido, 48)

        dgvItens.Columns("Quantidade").ValueType = GetType(Integer)
        dgvItens.Columns("ValorUnitario").ValueType = GetType(Decimal)

        carregando = True
        Try
            CarregarComboFabricante()

            If pedidoCid.HasValue AndAlso pedidoCid.Value > 0 Then
                ExibirPedido(pedidoCid.Value)
            Else
                NovoPedido()
            End If
        Finally
            carregando = False
        End Try

        alterado = False
        AtualizarTotais()
    End Sub

    Private Sub CarregarComboFabricante()
        Dim regras As New rFabricante
        Dim colecao As ColecaoFabricante

        Try
            colecao = regras.Listar()

            If colecao Is Nothing Then
                colecao = New ColecaoFabricante
            End If

            colecao.Insert(0, New dFabricante() With {.nome = "(selecione)"})

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

    Private Sub NovoPedido()
        pedidoCid = Nothing
        situacaoAtual = ""
        cidsExcluidos.Clear()
        dgvItens.Rows.Clear()

        txtNumero.Text = ""
        txtData.Text = Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
        txtPrevisao.Text = ""
        txtDescontoPerc.Text = ""
        txtDescontoValor.Text = ""
        descontoEmPercentual = False
        txtObservacao.Text = ""

        If cboFabricante.Items.Count > 0 Then
            cboFabricante.SelectedIndex = 0
        End If
        If fabricanteSugerido.HasValue Then
            cboFabricante.SelectedValue = fabricanteSugerido.Value
        End If
        fabricanteAtual = FabricanteSelecionado()
        CarregarProdutos()

        ExibirSituacao()
    End Sub

    Private Sub ExibirPedido(ByVal cidPedido As Integer)
        Dim regras As New rPedidoCompra
        Dim pedido As dPedidoCompra

        Try
            pedido = regras.Consultar(cidPedido)

            If pedido Is Nothing Then
                MessageBox.Show("Pedido não encontrado. Ele pode ter sido excluído em outro terminal.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NovoPedido()
                Exit Sub
            End If

            pedidoCid = pedido.cid
            situacaoAtual = pedido.situacao
            cidsExcluidos.Clear()

            txtNumero.Text = pedido.numero
            txtData.Text = FormatarData(pedido.data)
            txtPrevisao.Text = FormatarData(pedido.previsaoEntrega)
            txtObservacao.Text = pedido.observacao
            txtDescontoValor.Text = If(pedido.descontoValor > 0, pedido.descontoValor.ToString("N2", culturaBR), "")
            descontoEmPercentual = False

            cboFabricante.SelectedValue = pedido.fabricante_cid.GetValueOrDefault()
            fabricanteAtual = FabricanteSelecionado()
            CarregarProdutos()

            dgvItens.Rows.Clear()
            For Each item As dPedidoCompraItem In pedido.itens
                AdicionarLinha(item)
            Next

            AtualizarTotais()
            AtualizarPercentualDesconto()
            ExibirSituacao()

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro ao abrir o pedido: " & ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Situacao na tela + o que pode ou nao ser mexido
    Private Sub ExibirSituacao()
        Dim cancelado As Boolean = (situacaoAtual = "C")
        Dim novo As Boolean = Not (pedidoCid.HasValue AndAlso pedidoCid.Value > 0)

        lblSituacaoValor.Text = If(novo, "Novo (ainda não gravado)", dPedidoCompra.DescreverSituacao(situacaoAtual))

        Select Case situacaoAtual
            Case "C"
                lblSituacaoValor.ForeColor = Color.Gray
            Case "E"
                lblSituacaoValor.ForeColor = Color.DarkGreen
            Case Else
                lblSituacaoValor.ForeColor = Color.FromArgb(192, 64, 0)
        End Select

        txtNumero.ReadOnly = cancelado
        cboFabricante.Enabled = Not cancelado
        txtData.ReadOnly = cancelado
        txtPrevisao.ReadOnly = cancelado
        txtDescontoPerc.ReadOnly = cancelado
        txtDescontoValor.ReadOnly = cancelado
        txtObservacao.ReadOnly = cancelado
        cboProduto.Enabled = Not cancelado
        txtValorUnitario.ReadOnly = cancelado
        btoAdicionar.Enabled = Not cancelado
        btoRemoverItem.Enabled = Not cancelado
        dgvItens.ReadOnly = cancelado
        If Not cancelado Then
            ' ReadOnly do grid volta a liberar tudo; trava de novo as colunas so de leitura
            For Each coluna As DataGridViewColumn In dgvItens.Columns
                coluna.ReadOnly = Not (coluna.Name = "Quantidade" OrElse coluna.Name = "ValorUnitario")
            Next
        End If

        btoSalvar.Enabled = Not cancelado
        btoExcluir.Enabled = Not novo
        btoCancelarPedido.Enabled = Not novo
        btoCancelarPedido.Text = If(cancelado, "Reabrir <F8>", "Cancelar <F8>")
    End Sub

#End Region

#Region "Produtos e grade"

    Private Function FabricanteSelecionado() As Nullable(Of Integer)
        Dim item As dFabricante = TryCast(cboFabricante.SelectedItem, dFabricante)
        If item Is Nothing OrElse Not item.cid.HasValue OrElse item.cid.Value <= 0 Then
            Return Nothing
        End If
        Return item.cid
    End Function

    Private Sub CarregarProdutos()
        Dim regras As New rPedidoCompra
        Dim fabricante As Nullable(Of Integer) = FabricanteSelecionado()

        cboProduto.DataSource = Nothing
        cboProduto.Items.Clear()
        txtValorUnitario.Text = ""

        If Not fabricante.HasValue Then
            Exit Sub
        End If

        Try
            Dim produtos As ColecaoPedidoCompraProduto = regras.ListarProdutosFabricante(fabricante.Value)

            cboProduto.DisplayMember = "texto"
            cboProduto.ValueMember = "cid"
            cboProduto.DataSource = produtos

            If produtos.Count > 0 Then
                cboProduto.SelectedIndex = 0
                ExibirValorProduto()
            End If

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro na consulta dos produtos do fabricante: " & ex.Message)
        End Try
    End Sub

    Private Sub ExibirValorProduto()
        Dim produto As dPedidoCompraProduto = TryCast(cboProduto.SelectedItem, dPedidoCompraProduto)
        If produto Is Nothing Then
            txtValorUnitario.Text = ""
        Else
            txtValorUnitario.Text = produto.valorCompra.ToString("N2", culturaBR)
        End If
    End Sub

    ' SelectedIndexChanged (e nao SelectionChangeCommitted) para pegar tambem a
    ' escolha feita digitando a referencia (autocompletar do combo)
    Private Sub cboProduto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduto.SelectedIndexChanged
        ExibirValorProduto()
    End Sub

    ' Trocar o fabricante com itens na tela: os itens sao de outra marca, entao saem.
    Private Sub cboFabricante_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFabricante.SelectionChangeCommitted
        If carregando Then
            Exit Sub
        End If

        Dim novoFabricante As Nullable(Of Integer) = FabricanteSelecionado()

        If novoFabricante.GetValueOrDefault() = fabricanteAtual.GetValueOrDefault() Then
            Exit Sub
        End If

        If dgvItens.Rows.Count > 0 Then
            For Each linha As DataGridViewRow In dgvItens.Rows
                If LerInteiro(linha.Cells("Entregue").Value) > 0 Then
                    MessageBox.Show("Este pedido já teve entregas; o fabricante não pode ser trocado.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    VoltarFabricante()
                    Exit Sub
                End If
            Next

            If MessageBox.Show("Os itens deste pedido são do fabricante anterior e serão removidos. Continuar?", "Trocar fabricante",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                VoltarFabricante()
                Exit Sub
            End If

            For Each linha As DataGridViewRow In dgvItens.Rows
                Dim cidItem As Integer = LerInteiro(linha.Cells("cid").Value)
                If cidItem > 0 AndAlso Not cidsExcluidos.Contains(cidItem) Then
                    cidsExcluidos.Add(cidItem)
                End If
            Next
            dgvItens.Rows.Clear()
        End If

        fabricanteAtual = novoFabricante
        alterado = True
        CarregarProdutos()
        AtualizarTotais()
    End Sub

    Private Sub VoltarFabricante()
        carregando = True
        Try
            If fabricanteAtual.HasValue Then
                cboFabricante.SelectedValue = fabricanteAtual.Value
            Else
                cboFabricante.SelectedIndex = 0
            End If
        Finally
            carregando = False
        End Try
    End Sub

    ' Inclui todos os tamanhos do produto escolhido (os que ainda nao estao na tela)
    Private Sub AdicionarGrade()
        Dim produto As dPedidoCompraProduto = TryCast(cboProduto.SelectedItem, dPedidoCompraProduto)
        Dim regras As New rPedidoCompra
        Dim valor As Decimal
        Dim primeiraNova As Integer = -1

        If situacaoAtual = "C" Then
            Exit Sub
        End If

        If Not FabricanteSelecionado().HasValue Then
            MessageBox.Show("Escolha o fabricante primeiro.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboFabricante.Focus()
            Exit Sub
        End If

        If produto Is Nothing OrElse cboProduto.Text <> produto.texto Then
            MessageBox.Show("Escolha o produto (referência + cor) na lista. Pode digitar o começo da referência para filtrar.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboProduto.Focus()
            Exit Sub
        End If

        If Not LerDecimal(txtValorUnitario.Text, valor) OrElse valor < 0 Then
            MessageBox.Show("Valor do par inválido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValorUnitario.Focus()
            Exit Sub
        End If

        Try
            Dim grade As ColecaoPedidoCompraGrade = regras.ListarGradeProduto(produto.cid)

            If grade.Count = 0 Then
                MessageBox.Show("Este produto não tem tamanhos (código de barras) cadastrados na grade." & vbCrLf &
                                "Cadastre a grade do produto antes de incluí-lo no pedido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For Each tamanho As dPedidoCompraGrade In grade
                If LinhaDoItem(produto.cid, tamanho.codigoBarras) >= 0 Then
                    Continue For
                End If

                Dim item As New dPedidoCompraItem
                item.produtos_cid = produto.cid
                item.referencia = produto.referencia
                item.descricao = produto.descricao
                item.cor = produto.cor
                item.codigoBarras = tamanho.codigoBarras
                item.tamanho = tamanho.tamanho
                item.quantidade = 0
                item.valorUnitario = valor
                item.quantidadeEntregue = 0

                Dim indice As Integer = AdicionarLinha(item)
                If primeiraNova < 0 Then
                    primeiraNova = indice
                End If
            Next

            If primeiraNova < 0 Then
                MessageBox.Show("Todos os tamanhos deste produto já estão no pedido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            alterado = True
            AtualizarTotais()

            ' Ja deixa o cursor no primeiro tamanho novo, pronto para digitar os pares
            dgvItens.Focus()
            dgvItens.CurrentCell = dgvItens.Rows(primeiraNova).Cells("Quantidade")

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message)
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar a grade do produto: " & ex.Message)
        End Try
    End Sub

    Private Function AdicionarLinha(ByVal item As dPedidoCompraItem) As Integer
        Dim indice As Integer = dgvItens.Rows.Add()
        Dim linha As DataGridViewRow = dgvItens.Rows(indice)

        linha.Cells("cid").Value = item.cid
        linha.Cells("produtos_cid").Value = item.produtos_cid
        linha.Cells("codigoBarras").Value = item.codigoBarras
        linha.Cells("Referencia").Value = item.referencia
        linha.Cells("Descricao").Value = item.descricao
        linha.Cells("Cor").Value = item.cor
        linha.Cells("Tamanho").Value = item.tamanho
        linha.Cells("Quantidade").Value = item.quantidade
        linha.Cells("ValorUnitario").Value = item.valorUnitario
        linha.Cells("Entregue").Value = item.quantidadeEntregue
        AtualizarLinha(linha)

        Return indice
    End Function

    Private Function LinhaDoItem(ByVal produtos_cid As Integer, ByVal codigoBarras As String) As Integer
        For Each linha As DataGridViewRow In dgvItens.Rows
            If LerInteiro(linha.Cells("produtos_cid").Value) = produtos_cid AndAlso
               Convert.ToString(linha.Cells("codigoBarras").Value) = codigoBarras Then
                Return linha.Index
            End If
        Next
        Return -1
    End Function

    Private Sub RemoverItem()
        If situacaoAtual = "C" OrElse dgvItens.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Dim linha As DataGridViewRow = dgvItens.CurrentRow

        If LerInteiro(linha.Cells("Entregue").Value) > 0 Then
            MessageBox.Show("Este item já teve entrega e não pode ser removido." & vbCrLf &
                            "Se quiser, diminua a quantidade até o que já foi entregue.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim cidItem As Integer = LerInteiro(linha.Cells("cid").Value)
        If cidItem > 0 AndAlso Not cidsExcluidos.Contains(cidItem) Then
            cidsExcluidos.Add(cidItem)
        End If

        dgvItens.Rows.Remove(linha)
        alterado = True
        AtualizarTotais()
    End Sub

#End Region

#Region "Edicao na grade e totais"

    Private Sub dgvItens_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItens.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim linha As DataGridViewRow = dgvItens.Rows(e.RowIndex)

        ' Celula apagada vira 0
        If linha.Cells(e.ColumnIndex).Value Is Nothing OrElse IsDBNull(linha.Cells(e.ColumnIndex).Value) Then
            linha.Cells(e.ColumnIndex).Value = 0
        End If

        AtualizarLinha(linha)
        alterado = True
        AtualizarTotais()
    End Sub

    Private Sub dgvItens_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvItens.CellValidating
        Dim nome As String = dgvItens.Columns(e.ColumnIndex).Name
        Dim texto As String = Convert.ToString(e.FormattedValue).Trim()

        If Not dgvItens.IsCurrentCellInEditMode OrElse texto.Length = 0 Then
            Exit Sub
        End If

        If nome = "Quantidade" Then
            Dim pares As Integer
            If Not Integer.TryParse(texto.Replace(".", ""), NumberStyles.Integer, culturaBR, pares) OrElse pares < 0 Then
                MessageBox.Show("Digite a quantidade de pares (número inteiro, 0 ou mais).", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            ElseIf pares < LerInteiro(dgvItens.Rows(e.RowIndex).Cells("Entregue").Value) Then
                MessageBox.Show("Já foram entregues " & LerInteiro(dgvItens.Rows(e.RowIndex).Cells("Entregue").Value) &
                                " pares deste item; a quantidade não pode ser menor que isso.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If
        ElseIf nome = "ValorUnitario" Then
            Dim valor As Decimal
            If Not LerDecimal(texto, valor) OrElse valor < 0 Then
                MessageBox.Show("Valor do par inválido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If
        End If
    End Sub

    ' Converte o que foi digitado na grade com as mesmas regras da validacao.
    ' Sem isso a grade converteria sozinha pela cultura do Windows (pt-BR), e um
    ' valor digitado com ponto ("120.50") viraria 12050.
    Private Sub dgvItens_CellParsing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles dgvItens.CellParsing
        Dim nome As String = dgvItens.Columns(e.ColumnIndex).Name
        Dim texto As String = Convert.ToString(e.Value).Trim()

        If nome = "Quantidade" Then
            e.Value = LerInteiro(texto)
            e.ParsingApplied = True
        ElseIf nome = "ValorUnitario" Then
            Dim valor As Decimal
            If Not LerDecimal(texto, valor) Then
                valor = 0D
            End If
            e.Value = valor
            e.ParsingApplied = True
        End If
    End Sub

    ' Conversao automatica da grade falhou (texto invalido): avisa sem derrubar a tela
    Private Sub dgvItens_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItens.DataError
        e.ThrowException = False
        e.Cancel = True
    End Sub

    Private Sub AtualizarLinha(ByVal linha As DataGridViewRow)
        Dim pares As Integer = LerInteiro(linha.Cells("Quantidade").Value)
        Dim valor As Decimal = LerDecimalCelula(linha.Cells("ValorUnitario").Value)
        Dim entregue As Integer = LerInteiro(linha.Cells("Entregue").Value)

        linha.Cells("Total").Value = pares * valor
        linha.Cells("Falta").Value = Math.Max(0, pares - entregue)
    End Sub

    Private Sub AtualizarTotais()
        Dim pares As Integer = 0
        Dim bruto As Decimal = 0
        Dim entregue As Integer = 0
        Dim brutoFalta As Decimal = 0
        Dim desconto As Decimal

        ' Mantem o desconto coerente com o bruto atual (ver descontoEmPercentual)
        Dim perc As Decimal
        If descontoEmPercentual AndAlso txtDescontoPerc.Text.Trim().Length > 0 AndAlso LerDecimal(txtDescontoPerc.Text, perc) Then
            txtDescontoValor.Text = Math.Round(TotalBruto() * perc / 100D, 2).ToString("N2", culturaBR)
        ElseIf Not descontoEmPercentual Then
            AtualizarPercentualDesconto()
        End If
        desconto = LerDescontoValor()

        For Each linha As DataGridViewRow In dgvItens.Rows
            Dim qtd As Integer = LerInteiro(linha.Cells("Quantidade").Value)
            Dim valor As Decimal = LerDecimalCelula(linha.Cells("ValorUnitario").Value)
            Dim ent As Integer = LerInteiro(linha.Cells("Entregue").Value)

            pares += qtd
            bruto += qtd * valor
            entregue += ent
            brutoFalta += Math.Max(0, qtd - ent) * valor
        Next

        Dim liquido As Decimal = bruto - desconto
        Dim fator As Decimal = If(bruto > 0, liquido / bruto, 0D)
        Dim receber As Decimal = brutoFalta * fator

        lblTotais.Text = "Pares: " & pares.ToString("N0", culturaBR) &
                         "     Bruto: R$ " & bruto.ToString("N2", culturaBR) &
                         "     Desconto: R$ " & desconto.ToString("N2", culturaBR) &
                         "     Líquido: R$ " & liquido.ToString("N2", culturaBR) & vbCrLf &
                         "Entregues: " & entregue.ToString("N0", culturaBR) &
                         "     Faltam: " & Math.Max(0, pares - entregue).ToString("N0", culturaBR) &
                         "     A receber: R$ " & receber.ToString("N2", culturaBR)
    End Sub

    Private Function TotalBruto() As Decimal
        Dim bruto As Decimal = 0
        For Each linha As DataGridViewRow In dgvItens.Rows
            bruto += LerInteiro(linha.Cells("Quantidade").Value) * LerDecimalCelula(linha.Cells("ValorUnitario").Value)
        Next
        Return bruto
    End Function

    Private Function LerDescontoValor() As Decimal
        Dim valor As Decimal
        If LerDecimal(txtDescontoValor.Text, valor) Then
            Return valor
        End If
        Return 0D
    End Function

    ' Digitou o % -> calcula o R$
    Private Sub txtDescontoPerc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescontoPerc.Leave
        Dim perc As Decimal
        If txtDescontoPerc.ReadOnly OrElse Not txtDescontoPerc.Modified Then
            ' So saiu do campo sem digitar nada: nao muda o modo do desconto
            Exit Sub
        End If
        txtDescontoPerc.Modified = False
        If txtDescontoPerc.Text.Trim().Length = 0 Then
            ' Apagou o % que tinha digitado: zera o desconto
            If descontoEmPercentual Then
                txtDescontoValor.Text = ""
                alterado = True
                AtualizarTotais()
            End If
            Exit Sub
        End If
        If LerDecimal(txtDescontoPerc.Text, perc) AndAlso perc >= 0 AndAlso perc <= 100 Then
            descontoEmPercentual = True
            txtDescontoValor.Text = Math.Round(TotalBruto() * perc / 100D, 2).ToString("N2", culturaBR)
            alterado = True
            AtualizarTotais()
        Else
            MessageBox.Show("Percentual de desconto inválido (use de 0 a 100).", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescontoPerc.Focus()
        End If
    End Sub

    ' Digitou o R$ -> mostra o %
    Private Sub txtDescontoValor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescontoValor.Leave
        Dim valor As Decimal
        If txtDescontoValor.ReadOnly OrElse Not txtDescontoValor.Modified Then
            ' So saiu do campo sem digitar nada: nao muda o modo do desconto
            Exit Sub
        End If
        txtDescontoValor.Modified = False
        descontoEmPercentual = False
        If txtDescontoValor.Text.Trim().Length = 0 Then
            txtDescontoPerc.Text = ""
            alterado = True
            AtualizarTotais()
            Exit Sub
        End If
        If LerDecimal(txtDescontoValor.Text, valor) AndAlso valor >= 0 Then
            txtDescontoValor.Text = valor.ToString("N2", culturaBR)
            AtualizarPercentualDesconto()
            alterado = True
            AtualizarTotais()
        Else
            MessageBox.Show("Valor de desconto inválido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescontoValor.Focus()
        End If
    End Sub

    Private Sub AtualizarPercentualDesconto()
        Dim bruto As Decimal = TotalBruto()
        Dim valor As Decimal = LerDescontoValor()
        If bruto > 0 AndAlso valor > 0 Then
            txtDescontoPerc.Text = Math.Round(valor / bruto * 100D, 2).ToString("0.##", culturaBR)
        Else
            txtDescontoPerc.Text = ""
        End If
    End Sub

    Private Sub CampoAlterado(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged, txtData.TextChanged, txtPrevisao.TextChanged, txtObservacao.TextChanged
        If Not carregando Then
            alterado = True
        End If
    End Sub

#End Region

#Region "Gravar, excluir, cancelar"

    Private Function MontarPedido() As dPedidoCompra
        Dim pedido As New dPedidoCompra

        pedido.cid = pedidoCid
        pedido.numero = txtNumero.Text.Trim()
        pedido.fabricante_cid = FabricanteSelecionado()
        pedido.data = LerData(txtData.Text)
        pedido.previsaoEntrega = LerData(txtPrevisao.Text)
        pedido.descontoValor = LerDescontoValor()
        pedido.observacao = txtObservacao.Text.Trim()
        Try
            pedido.usuario_cid = mdiPrincipal.gUsuario.cid
        Catch
            pedido.usuario_cid = Nothing
        End Try

        For Each linha As DataGridViewRow In dgvItens.Rows
            Dim item As New dPedidoCompraItem
            Dim cidItem As Integer = LerInteiro(linha.Cells("cid").Value)

            item.cid = If(cidItem > 0, cidItem, CType(Nothing, Nullable(Of Integer)))
            item.pedidocompra_cid = pedidoCid
            item.produtos_cid = LerInteiro(linha.Cells("produtos_cid").Value)
            item.codigoBarras = Convert.ToString(linha.Cells("codigoBarras").Value)
            item.referencia = Convert.ToString(linha.Cells("Referencia").Value)
            item.descricao = Convert.ToString(linha.Cells("Descricao").Value)
            item.cor = Convert.ToString(linha.Cells("Cor").Value)
            item.tamanho = Convert.ToString(linha.Cells("Tamanho").Value)
            item.quantidade = LerInteiro(linha.Cells("Quantidade").Value)
            item.valorUnitario = LerDecimalCelula(linha.Cells("ValorUnitario").Value)
            item.quantidadeEntregue = LerInteiro(linha.Cells("Entregue").Value)

            pedido.itens.Add(item)
        Next

        Return pedido
    End Function

    Private Function Salvar() As Boolean
        If situacaoAtual = "C" Then
            Return False
        End If

        ' Termina a edicao de uma celula que ainda esteja aberta
        If dgvItens.IsCurrentCellInEditMode Then
            If Not dgvItens.EndEdit() Then
                Return False
            End If
        End If

        If txtData.Text.Replace("/", "").Trim().Length > 0 AndAlso Not LerData(txtData.Text).HasValue Then
            MessageBox.Show("Data do pedido inválida.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtData.Focus()
            Return False
        End If

        If txtPrevisao.Text.Replace("/", "").Trim().Length > 0 AndAlso Not LerData(txtPrevisao.Text).HasValue Then
            MessageBox.Show("Previsão de entrega inválida.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrevisao.Focus()
            Return False
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim regras As New rPedidoCompra
            Dim novoCid As Integer = regras.Salvar(MontarPedido(), cidsExcluidos)

            carregando = True
            Try
                ExibirPedido(novoCid)
            Finally
                carregando = False
            End Try

            alterado = False
            Cursor.Current = Cursors.Default
            MessageBox.Show("Pedido gravado.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True

        Catch nex As ExcecaoNascomercio
            Cursor.Current = Cursors.Default
            MessageBox.Show(nex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show("Erro ao gravar o pedido: " & ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False
    End Function

    Private Sub Excluir()
        If Not pedidoCid.HasValue Then
            Exit Sub
        End If

        If MessageBox.Show("Confirma a EXCLUSÃO deste pedido?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Dim regras As New rPedidoCompra
            If regras.Excluir(pedidoCid.Value) Then
                alterado = False
                MessageBox.Show("Pedido excluído.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                VoltarParaLista()
            Else
                MessageBox.Show("Este pedido já teve entregas e não pode ser excluído." & vbCrLf &
                                "Use ""Cancelar <F8>"" para encerrá-lo.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro ao excluir o pedido: " & ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancela (pedido nao recebe mais baixa e sai do relatorio) ou reabre
    Private Sub CancelarOuReabrir()
        If Not pedidoCid.HasValue Then
            Exit Sub
        End If

        Try
            Dim regras As New rPedidoCompra

            If situacaoAtual = "C" Then
                If MessageBox.Show("Reabrir este pedido? Ele volta a receber baixa das entradas de estoque.", "Reabrir pedido",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If
                regras.Reabrir(pedidoCid.Value)
            Else
                If alterado Then
                    MessageBox.Show("Salve ou desfaça as alterações antes de cancelar o pedido.", "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If MessageBox.Show("Cancelar este pedido? O que falta entregar deixa de ser esperado e ele não recebe mais baixa.", "Cancelar pedido",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If
                regras.Cancelar(pedidoCid.Value)
            End If

            carregando = True
            Try
                ExibirPedido(pedidoCid.Value)
            Finally
                carregando = False
            End Try
            alterado = False

        Catch nex As ExcecaoNascomercio
            MessageBox.Show(nex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro ao alterar a situação do pedido: " & ex.Message, "Pedido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Sair()
        If alterado AndAlso situacaoAtual <> "C" Then
            Dim resposta As DialogResult = MessageBox.Show("Há alterações não gravadas. Deseja gravar antes de sair?", "Pedido de Compra",
                                                           MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If resposta = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            ElseIf resposta = Windows.Forms.DialogResult.Yes Then
                If Not Salvar() Then
                    Exit Sub
                End If
            End If
        End If

        VoltarParaLista()
    End Sub

    Private Sub VoltarParaLista()
        alterado = False
        mdiPrincipal.CarregarPedidoCompraLista()
    End Sub

#End Region

#Region "Botoes e teclas"

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
        Excluir()
    End Sub

    Private Sub btoCancelarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCancelarPedido.Click
        CancelarOuReabrir()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Sair()
    End Sub

    Private Sub btoAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAdicionar.Click
        AdicionarGrade()
    End Sub

    Private Sub btoRemoverItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoRemoverItem.Click
        RemoverItem()
    End Sub

    Private Sub fPedidoCompraForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If dgvItens.IsCurrentCellInEditMode Then
                    Exit Sub ' Esc dentro da celula so desfaz a digitacao
                End If
                e.Handled = True
                Sair()
            Case Keys.F2
                If dgvItens.Focused AndAlso Not dgvItens.IsCurrentCellInEditMode Then
                    ' F2 na grade e o atalho padrao do Windows para editar a celula;
                    ' aqui ele grava o pedido, igual ao resto da tela
                    e.Handled = True
                End If
                Salvar()
            Case Keys.F3
                e.Handled = True
                AdicionarGrade()
            Case Keys.F8
                e.Handled = True
                CancelarOuReabrir()
            Case Keys.F12
                e.Handled = True
                Excluir()
            Case Keys.Delete
                If dgvItens.Focused AndAlso Not dgvItens.IsCurrentCellInEditMode Then
                    e.Handled = True
                    RemoverItem()
                End If
        End Select
    End Sub

#End Region

#Region "Conversoes"

    Private Shared Sub AjustarIconeBotao(ByVal botao As Button, ByVal tamanho As Integer)
        If botao.Image Is Nothing OrElse (botao.Image.Width = tamanho AndAlso botao.Image.Height = tamanho) Then
            Exit Sub
        End If
        Dim reduzida As New Bitmap(tamanho, tamanho)
        Using g As Graphics = Graphics.FromImage(reduzida)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.DrawImage(botao.Image, 0, 0, tamanho, tamanho)
        End Using
        botao.Image = reduzida
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

    ' Aceita "120,50", "1.234,50", "1.234" (milhar) e tambem "120.50"
    Private Shared Function LerDecimal(ByVal texto As String, ByRef valor As Decimal) As Boolean
        texto = If(texto, "").Trim().Replace("R$", "").Trim()
        If texto.Length = 0 Then
            valor = 0D
            Return True
        End If
        If texto.Contains(",") OrElse System.Text.RegularExpressions.Regex.IsMatch(texto, "^\d{1,3}(\.\d{3})+$") Then
            Return Decimal.TryParse(texto, NumberStyles.Number, culturaBR, valor)
        End If
        Return Decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, valor)
    End Function

    Private Shared Function LerInteiro(ByVal valor As Object) As Integer
        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0
        End If
        Dim numero As Integer
        If TypeOf valor Is Integer Then
            Return CInt(valor)
        End If
        If Integer.TryParse(Convert.ToString(valor).Replace(".", ""), NumberStyles.Integer, culturaBR, numero) Then
            Return numero
        End If
        Return 0
    End Function

    Private Shared Function LerDecimalCelula(ByVal valor As Object) As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0D
        End If
        If TypeOf valor Is Decimal Then
            Return CDec(valor)
        End If
        Dim numero As Decimal
        If LerDecimal(Convert.ToString(valor), numero) Then
            Return numero
        End If
        Return 0D
    End Function

#End Region

End Class
