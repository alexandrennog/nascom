Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsLog.cLog
Imports ncComum.nsExcecao
Imports ncDados.nsNotaFiscalFornecedor
Imports ncRegras.nsNotaFiscalFornecedor

Public Class fProdutoEntradaSaidaEstoque

    Public produto_cid As Integer
    Public produto As dProduto
    Private colecaoProdutoTipoCaracteristica As ColecaoProdutoTipoCaracteristica
    Public nffNumero As String = String.Empty
    Public nffSerie As String = String.Empty
    Public nffTipoAcao As String = String.Empty

    Private Sub fProdutoEntradaSaidaEstoque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F1
                ClonarItem()
            Case Keys.F5
                CarregarProdutoEntradaSaidaFiltro()
            Case Keys.Enter
                AtualizarEstoque()
            Case Keys.F6
                CarregarProdutoEntradaSaidaTransferencia()
            Case Keys.F8
                CarregarProdutoBalancoFiltro()
            Case Keys.F2
                If e.Alt = False Then
                    CarregarTelaNotaFiscal()
                End If
        End Select
    End Sub

    Private Sub fProdutoEntradaSaidaEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarProduto()
        CarregarProdutoTipoCaracteristica()
        MontarGradeCaracteristicas()
        CarregarItens()
        ExibirInformacoesTela()
    End Sub
    Private Sub ExibirInformacoesTela()
        If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
            btoBalanco.Visible = False
        End If
    End Sub
    Private Sub CarregarProdutoEntradaSaidaFiltro()
        mdiPrincipal.CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub CarregarProdutoEntradaSaidaTransferencia()
        fProdutoEntradaSaidaTransferencia.produto_cid = Me.produto_cid
        mdiPrincipal.CarregarProdutoEntradaSaidaTransferencia()
    End Sub

    Private Sub btoFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFechar.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub btoAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAtualizar.Click
        AtualizarEstoque()
    End Sub

    Private Sub btoTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoTransferencia.Click
        CarregarProdutoEntradaSaidaTransferencia()
    End Sub

    Private Sub Salvar()
        Dim colecao As ColecaoProdutoItem
        Dim linha As DataGridViewRow
        Dim coluna As DataGridViewCell
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty
        Dim dadosCaracteristica As dCaracteristica
        Dim regraCaracteristica As rCaracteristica
        Dim regraProdutoItem As rProdutoItem

        Try

            dadosCaracteristica = New dCaracteristica()
            regraCaracteristica = New rCaracteristica()
            regraProdutoItem = New rProdutoItem()

            If dgvProduto.Rows.Count > 0 Then
                colecao = New ColecaoProdutoItem()

                For Each linha In dgvProduto.Rows
                    For Each coluna In linha.Cells
                        If Not coluna.OwningColumn.Name.ToLower().Equals("quantidade") Then
                            Dim dadosItem As dProdutoItem

                            dadosCaracteristica = regraCaracteristica.fConsultarPorNome(coluna.OwningColumn.Name)

                            dadosItem = New dProdutoItem()

                            If dadosCaracteristica Is Nothing Then
                                MessageBox.Show("Erro na inclusão de novo item")
                                Exit Sub
                            End If

                            dadosItem.produtos_cid = Me.produto_cid
                            dadosItem.item = linha.Index
                            dadosItem.caracteristicas_nome = coluna.OwningColumn.Name
                            dadosItem.caracteristicas_cid = dadosCaracteristica.cid
                            dadosItem.valor = RetornarTexto(coluna.Value)

                            colecao.Add(dadosItem)
                        End If
                    Next
                Next

                If Not colecao Is Nothing Then
                    regraProdutoItem.ExcluirPorProduto(Me.produto_cid)
                    regraProdutoItem.IncluirListaItem(colecao)
                End If

            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na inclusão dos itens de produto.")

        End Try
    End Sub

    Private Sub AtualizarEstoque()
        Dim codigoBarras As String
        Dim quantidade As Decimal
        Dim regra As rCaracteristica
        Dim dados As dCaracteristica
        Dim regraPI As rProdutoItem
        Dim nfDados As dNotaFiscalFornecedor
        Dim nfRegras As rNotaFiscalFornecedor
        Dim nfColecao As ColecaoNotaFiscalFornecedor
        Dim notaFiscalNumero As String = Nothing
        Dim notaFiscalSerie As String = Nothing


        If MessageBox.Show("Confirma atualização de estoque?", "Estoque", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

            txtNotaFiscalNumero.Text = txtNotaFiscalNumero.Text.Trim()
            txtNotaFiscalSerie.Text = txtNotaFiscalSerie.Text.Trim()

            If (String.IsNullOrEmpty(txtNotaFiscalNumero.Text)) <> (String.IsNullOrEmpty(txtNotaFiscalSerie.Text)) Then
                MessageBox.Show("Nota Fiscal inválida.", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If (Not String.IsNullOrEmpty(txtNotaFiscalNumero.Text)) And (Not String.IsNullOrEmpty(txtNotaFiscalSerie.Text)) Then
                notaFiscalNumero = TratarTexto(txtNotaFiscalNumero.Text)
                notaFiscalSerie = TratarTexto(txtNotaFiscalSerie.Text)
                nfDados = New dNotaFiscalFornecedor()
                nfRegras = New rNotaFiscalFornecedor()

                nfDados.numero = notaFiscalNumero
                nfDados.serie = notaFiscalSerie
                nfColecao = nfRegras.Consultar(nfDados)

                If nfColecao IsNot Nothing Then
                    If nfColecao.Count <= 0 Then
                        MessageBox.Show("Nota Fiscal inválida.", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                Else
                    MessageBox.Show("Nota Fiscal inválida.", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If

            regra = New rCaracteristica()
            regraPI = New rProdutoItem()

            dados = regra.ConsultarPorCodigo("codigoBarras")

            Salvar()

            If dgvProduto.Rows.Count > 0 Then
                For Each linha As DataGridViewRow In dgvProduto.Rows
                    codigoBarras = ""
                    quantidade = 0

                    For Each celula As DataGridViewCell In linha.Cells

                        If celula.OwningColumn.Name.Equals(dados.nome) Then
                            codigoBarras = celula.Value.ToString()
                        End If

                        If Not celula.Value Is Nothing Then
                            If celula.OwningColumn.Name.ToLower().Equals("quantidade") Then
                                quantidade = celula.Value.ToString()
                            End If
                        End If

                    Next

                    If Not codigoBarras.Trim().Equals(String.Empty) Then
                        If quantidade > 0 Then
                            '-- Atualizar LogEstoque
                            GravarLogEstoque(mdiPrincipal.gUsuario.cid, mdiPrincipal.gUsuario.nomeCompleto, Me.produto_cid, codigoBarras, quantidade, notaFiscalNumero, notaFiscalSerie)

                            '-- Atualizar Estoque
                            regraPI.AlterarEstoque(codigoBarras, quantidade)
                        End If
                    End If
                Next

                MontarGradeCaracteristicas()
                CarregarItens()

            End If
        End If

    End Sub

    Private Sub CarregarProduto()
        Dim regras As rProduto

        Try

            If Not Me.produto_cid.Equals(Nothing) Then
                If Not Me.produto_cid.Equals(0) Then

                    regras = New rProduto()

                    Me.produto = regras.Consultar(Me.produto_cid)

                    If Not Me.produto Is Nothing Then
                        txtCodigo.Text = Me.produto.codigo
                        txtDescricao.Text = Me.produto.descricao
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Produto.")

        End Try
    End Sub

    Private Sub CarregarItens()
        Dim regras As rProdutoItem
        Dim colecao As ColecaoProdutoItem
        Dim colecaoQtde As ColecaoProdutoItem
        Dim novaLinha As DataGridViewRow
        Dim novaCelula As DataGridViewTextBoxCell
        Dim item As dProdutoItem
        Dim itemQtde As dProdutoItem
        Dim coluna As DataGridViewTextBoxColumn
        Dim existe As Boolean = False

        Try

            If Not produto Is Nothing Then
                If Not produto.produtoTipo_cid.Equals(Nothing) Then
                    If dgvProduto.Columns.Count > 0 Then
                        regras = New rProdutoItem()
                        colecao = regras.ConsultarPorProduto(produto.cid)
                        colecaoQtde = regras.ConsultarQuantidadeItem(produto.cid)

                        If Not colecaoQtde Is Nothing Then
                            If colecaoQtde.Count > 0 Then
                                If colecao.Count > 0 Then
                                    '-- Para cada item do produto
                                    For Each itemQtde In colecaoQtde
                                        novaLinha = New DataGridViewRow()

                                        '-- Para cada coluna da grade
                                        For Each coluna In dgvProduto.Columns

                                            '-- Verifica se tem o campo cadastrado pro item
                                            For Each item In colecao

                                                existe = False

                                                If Not coluna.Tag Is Nothing Then
                                                    If (coluna.Tag.ToString().Equals(item.caracteristicas_cid.ToString())) And _
                                                        (item.item.Equals(itemQtde.item)) Then
                                                        novaCelula = New DataGridViewTextBoxCell()
                                                        novaCelula.Value = item.valor
                                                        novaLinha.Cells.Add(novaCelula)
                                                        existe = True
                                                        Exit For
                                                    End If
                                                End If

                                            Next

                                            If existe = False Then
                                                novaCelula = New DataGridViewTextBoxCell()
                                                novaLinha.Cells.Add(novaCelula)
                                            End If

                                        Next

                                        dgvProduto.Rows.Add(novaLinha)
                                        novaLinha = Nothing
                                    Next
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Itens de Produtos.")

        End Try
    End Sub

    Private Sub CarregarProdutoTipoCaracteristica()
        Dim regras As rProdutoTipoCaracteristica

        Try

            colecaoProdutoTipoCaracteristica = Nothing

            If Not Me.produto Is Nothing Then
                regras = New rProdutoTipoCaracteristica()

                colecaoProdutoTipoCaracteristica = regras.ConsultarPorProdutoTipo(Me.produto.produtoTipo_cid)
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Características de Tipo de Produto.")

        End Try
    End Sub

    Private Sub MontarGradeCaracteristicas()
        Dim item As dProdutoTipoCaracteristica
        Dim qtde As Integer
        Dim coluna As DataGridViewTextBoxColumn
        Dim somenteLeitura As Boolean = False
        Dim rCarac As rCaracteristica
        Dim dCarac As dCaracteristica
        Dim caracLeitura As String

        dgvProduto.Rows.Clear()
        dgvProduto.Columns.Clear()
        dgvProduto.Refresh()

        rCarac = New rCaracteristica()
        dCarac = New dCaracteristica()

        dCarac = rCarac.ConsultarPorCodigo("codigoBarras")
        caracLeitura = "|" & dCarac.cid.ToString() & "|"

        dCarac = rCarac.ConsultarPorCodigo("estoque")
        caracLeitura = caracLeitura & "|" & dCarac.cid.ToString() & "|"

        'dCarac = rCarac.ConsultarPorCodigo("estoqueMinimo")
        'caracLeitura = caracLeitura & "|" & dCarac.cid.ToString() & "|"

        If Not colecaoProdutoTipoCaracteristica Is Nothing Then

            For Each item In colecaoProdutoTipoCaracteristica
                somenteLeitura = False

                If caracLeitura.Contains("|" & item.caracteristica_cid.ToString() & "|") Then
                    somenteLeitura = True
                Else
                    If item.quantidade.Equals(Nothing) Then
                        qtde = 0
                    Else
                        qtde = item.quantidade
                    End If

                    If qtde > 0 Then
                        somenteLeitura = True
                    End If
                End If

                coluna = New DataGridViewTextBoxColumn()
                coluna.Name = item.caracteristica_nome
                coluna.Tag = item.caracteristica_cid.ToString()
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable

                If somenteLeitura = True Then
                    coluna.ReadOnly = True
                End If

                dgvProduto.Columns.Add(coluna)
            Next

            coluna = New DataGridViewTextBoxColumn()
            coluna.Name = "Quantidade"
            coluna.Tag = Nothing
            dgvProduto.Columns.Add(coluna)

            dgvProduto.Refresh()
        End If
    End Sub

    Private Sub btoClonarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoClonarItem.Click
        ClonarItem()
    End Sub

    Private Sub ClonarItem()
        Dim linha As DataGridViewRow
        Dim item As Integer
        Dim dadosCaracteristica As dCaracteristica
        Dim regraCaracteristica As rCaracteristica
        Dim regraProdutoItem As rProdutoItem
        Dim dadosItem As dProdutoItem
        Dim novoCB As String

        If dgvProduto.Rows.Count > 0 Then
            If dgvProduto.CurrentRow.Index >= 0 Then

                linha = dgvProduto.Rows(dgvProduto.CurrentRow.Index)
                item = dgvProduto.Rows.Count
                dadosCaracteristica = New dCaracteristica()
                regraCaracteristica = New rCaracteristica()
                regraProdutoItem = New rProdutoItem()

                For Each coluna As DataGridViewCell In linha.Cells

                    If Not coluna.OwningColumn.Name.ToLower().Equals("quantidade") Then

                        dadosCaracteristica = regraCaracteristica.fConsultarPorNome(coluna.OwningColumn.Name)

                        If dadosCaracteristica Is Nothing Then
                            MessageBox.Show("Erro na inclusão de novo item")
                            Exit Sub
                        End If

                        dadosItem = New dProdutoItem()

                        dadosItem.produtos_cid = Me.produto_cid
                        dadosItem.item = item
                        dadosItem.caracteristicas_nome = coluna.OwningColumn.Name
                        dadosItem.caracteristicas_cid = dadosCaracteristica.cid

                        If dadosCaracteristica.codigo.ToLower().Equals("codigobarras") Then
                            novoCB = regraProdutoItem.fConsultarUltimoCodigoBarras()

                            novoCB = ObterCodigoBarrasProduto(novoCB)

                            dadosItem.valor = novoCB
                        Else
                            If Not coluna.OwningColumn.Name.ToLower().Equals("estoque") Then
                                dadosItem.valor = RetornarTexto(coluna.Value)
                            End If
                        End If

                        regraProdutoItem.fIncluir(dadosItem)

                    End If
                Next

                MontarGradeCaracteristicas()
                CarregarItens()

            End If
        End If

    End Sub

    Private Sub btoBalanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBalanco.Click
        CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub CarregarProdutoBalancoFiltro()
        mdiPrincipal.CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub btoNotaFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNotaFiscal.Click
        CarregarTelaNotaFiscal()
    End Sub

    Private Sub CarregarTelaNotaFiscal()
        If (Not txtNotaFiscalNumero.Text.Trim().Equals(String.Empty)) Or (Not txtNotaFiscalSerie.Text.Trim().Equals(String.Empty)) Then
            Me.nffTipoAcao = "l"
            Me.nffNumero = txtNotaFiscalNumero.Text.Trim()
            Me.nffSerie = txtNotaFiscalSerie.Text.Trim()
            CarregarNotaFiscalFornecedorLista()
        Else
            Me.nffTipoAcao = "i"
            CarregarNotaFiscalFornecedorForm()
        End If
    End Sub

    Private Sub CarregarNotaFiscalFornecedorForm()
        mdiPrincipal.CarregarNotaFiscalFornecedorForm()
    End Sub

    Private Sub CarregarNotaFiscalFornecedorLista()
        mdiPrincipal.CarregarNotaFiscalFornecedorLista(Nothing)
    End Sub

End Class