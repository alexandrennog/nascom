Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncDados.nsNotaFiscalFornecedor
Imports ncRegras.nsNotaFiscalFornecedor
Imports ncDados.nsCor
Imports ncRegras.nsCor
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncDados.nsEFD
Imports ncRegras.nsEFD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsLog.cLog
Imports ncComum.nsExcecao
Imports ncDados.nsUsuario
Imports ncDados.nsLoja
Imports ncDados.nsCategoria
Imports ncRegras.nsCategoria
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes
Imports System.Globalization

Public Class fProdutoForm

    Public cid As Nullable(Of Integer)
    Public produto As dProduto
    Private colecaoProdutoTipoCaracteristica As ColecaoProdutoTipoCaracteristica
    Private estoqueTotal As Integer
    Private estoqueTotaldec As Integer
    Private gUsuario As New dUsuario
    Private gLoja As New dLoja
    Public abrirTela As Boolean = False
    Public nffNumero As String = String.Empty
    Public nffSerie As String = String.Empty
    Public nffTipoAcao As String = String.Empty

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            mdiPrincipal.FecharTela()
        End If
    End Sub

    Private Function VerificarProduto() As String
        Dim retorno As String = "I"

        Try
            Dim regraP As rProduto = New rProduto()
            Dim dadosP As dProduto = New dProduto()
            Dim colecaoP As ColecaoProduto = New ColecaoProduto()

            dadosP.fornecedor_cid = cboFornecedor.SelectedValue
            dadosP.fabricante_cid = cboFabricante.SelectedValue
            dadosP.cor_cid = cboCor.SelectedValue
            dadosP.referencia = txtReferencia.Text

            colecaoP = regraP.Consultar(dadosP)

            If colecaoP IsNot Nothing Then
                If colecaoP.Count > 0 Then
                    If Not colecaoP.Item(0).cid.Equals(Me.cid) Then
                        If MessageBox.Show("Ja existe um produto com os dados (Fornecedor, Fabricante, Cor e Referencia) informados. " & vbCrLf &
                            "Deseja consultar o produto existente?", "Cadastro de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                            retorno = "A"
                            Me.cid = colecaoP.Item(0).cid
                        Else
                            retorno = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            retorno = ""
        End Try

        VerificarProduto = retorno
    End Function

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Executar()
    End Sub

    Private Sub Executar()
        Dim acao As String

        If ValidarDados() Then
            acao = VerificarProduto()

            Select Case acao
                Case "I"
                    Salvar()
                Case "A"
                    ExibirInformacoesTela()
            End Select
        End If
    End Sub

    Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
        Excluir()
    End Sub

    Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
        IncluirItem()
    End Sub

    Private Sub fProdutoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = False Then
            Select Case e.KeyCode
                Case Keys.Escape
                    If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        mdiPrincipal.FecharTela()
                    End If
                Case Keys.F5
                    Filtrar()
                Case Keys.F6
                    ImprimirEtiqueta()
                Case Keys.F7
                    ImprimirEtiquetaES()
                Case Keys.F8
                    IncluirGrade()
                Case Keys.F9
                    CarregarFornecedorFiltro()
                Case Keys.F10
                    CarregarFabricanteFiltro()
                Case Keys.F11
                    CarregarCorFiltro()
                Case Keys.F1
                    Limpar()
                Case Keys.F2
                    CarregarNotaFiscalFornecedorLista(Me.txtCodigo.Text)
                Case Keys.Enter
                    Executar()
                Case Keys.F12
                    Excluir()
                Case Keys.F3
                    IncluirItem()
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.F2
                    CarregarTelaNotaFiscal()
                Case Keys.F3
                    CarregarGrupoFiltro()
            End Select
        End If
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarProdutoFiltro()
    End Sub

    Private Function ValidarNovoCodigoBarras() As Boolean
        Dim retorno As Boolean = True
        Dim atual As String = String.Empty
        Dim codigoBarras As String = String.Empty
        Dim regraC As rCaracteristica
        Dim dadosC As dCaracteristica

        Try

            regraC = New rCaracteristica()

            For Each linha As DataGridViewRow In dgvProduto.Rows

                dadosC = regraC.ConsultarPorCodigo("codigoBarras")

                If Not linha.Cells("codigobarrasatual").Value = Nothing Then
                    atual = linha.Cells("codigobarrasatual").Value.ToString()
                Else
                    atual = ""
                End If

                If Not linha.Cells(dadosC.codigo).Value = Nothing Then
                    codigoBarras = linha.Cells(dadosC.codigo).Value.ToString()
                Else
                    codigoBarras = ""
                End If

                If Not atual.ToLower().Equals(codigoBarras) Then

                    '-- verifica se codigo é válido
                    If codigoBarras.Length > 13 Then
                        MessageBox.Show("Código de Barras deve possuir no máximo 13 caracteres")
                        retorno = False
                        Exit For
                    End If

                End If
            Next

        Catch ex As Exception
            retorno = False
        End Try

        ValidarNovoCodigoBarras = retorno
    End Function

    Private Function ValidarDados() As Boolean
        Dim retorno As Boolean = True
        Dim valorCompra As Decimal = 0
        Dim valorVenda As Decimal = 0
        Dim listaAliquota As String = String.Empty

        Try

            If txtReferencia.Text.Trim().Equals(String.Empty) Then
                MessageBox.Show("Informe a Referência do produto", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtReferencia.Focus()
                retorno = False
                Exit Try
            End If

            If txtDescricao.Text.Trim().Equals(String.Empty) Then
                MessageBox.Show("Informe a Descrição do produto", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescricao.Focus()
                retorno = False
                Exit Try
            End If

            If cboFornecedor.Items.Count > 0 Then
                If (cboFornecedor.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboFornecedor.SelectedValue.ToString())) Then
                    MessageBox.Show("Selecione um Fornecedor", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboFornecedor.Focus()
                    retorno = False
                    Exit Try
                End If
            Else
                MessageBox.Show("Selecione um Fornecedor", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboFornecedor.Focus()
                retorno = False
            End If

            If cboFabricante.Items.Count > 0 Then
                If (cboFabricante.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboFabricante.SelectedValue.ToString())) Then
                    MessageBox.Show("Selecione um Fabricante", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboFabricante.Focus()
                    retorno = False
                    Exit Try
                End If
            Else
                MessageBox.Show("Selecione um Fabricante", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboFabricante.Focus()
                retorno = False
            End If

            If cboCor.Items.Count > 0 Then
                If (cboCor.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboCor.SelectedValue.ToString())) Then
                    MessageBox.Show("Selecione uma Cor", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboCor.Focus()
                    retorno = False
                    Exit Try
                End If
            Else
                MessageBox.Show("Selecione uma Cor", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboCor.Focus()
                retorno = False
            End If

            If txtValorCompra.Text.Trim().Equals(String.Empty) Then
                MessageBox.Show("Informe o Valor de Custo", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtValorCompra.Focus()
                retorno = False
                Exit Try
            End If

            If Decimal.TryParse(txtValorCompra.Text, valorCompra) = False Then
                MessageBox.Show("Valor de Custo inválido", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtValorCompra.Focus()
                retorno = False
                Exit Try
            End If

            If txtValorVenda.Text.Trim().Equals(String.Empty) Then
                MessageBox.Show("Informe o Valor de Venda", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtValorVenda.Focus()
                retorno = False
                Exit Try
            End If

            If Decimal.TryParse(txtValorVenda.Text, valorVenda) = False Then
                MessageBox.Show("Valor de Venda inválido", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtValorVenda.Focus()
                retorno = False
                Exit Try
            End If

            txtAliquota.Text = txtAliquota.Text.Trim().ToUpper()
            listaAliquota = "|FF|II|NN|SS|"
            Dim aux As Double = 0
            If Not txtAliquota.Text.Trim().Equals(String.Empty) Then
                If Not listaAliquota.Contains("|" & txtAliquota.Text.ToUpper() & "|") Then
                    If Not Double.TryParse(txtAliquota.Text, aux) Then
                        MessageBox.Show("Alíquota inválida", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtAliquota.Focus()
                        retorno = False
                    Else
                        txtAliquota.Text = aux.ToString("00.00")
                        If (Convert.ToDouble(txtAliquota.Text) <= 0) Or (Convert.ToDouble(txtAliquota.Text) >= 100) Then
                            MessageBox.Show("Alíquota inválida", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtAliquota.Focus()
                            retorno = False
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Informe a Alíquota", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAliquota.Focus()
                retorno = False
            End If

        Catch ex As Exception
            retorno = False
        End Try

        ValidarDados = retorno
    End Function

    Private Sub Salvar()
        Dim dados As dProduto
        Dim colecao As ColecaoProdutoItem
        Dim colecaoProdutoItem As ColecaoProdutoItem = Nothing
        Dim colecaoItensProdutos As ColecaoItensProdutos = Nothing
        Dim regras As rProduto
        Dim linha As DataGridViewRow
        Dim celula As DataGridViewCell
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty
        Dim novoCID As Integer
        Dim nfDados As dNotaFiscalFornecedor
        Dim nfRegras As rNotaFiscalFornecedor
        Dim nfColecao As ColecaoNotaFiscalFornecedor

        Try
            If ValidarNovoCodigoBarras() Then

                tipoMsg = "INCLUSÃO"
                tipoAcao = "i"

                If Not cid.Equals(Nothing) Then
                    If Not cid.ToString().Equals(String.Empty) Then
                        If Not cid.Equals(0) Then
                            tipoMsg = "ALTERAÇÃO"
                            tipoAcao = "a"
                        End If
                    End If
                End If

                If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    dados = New dProduto()
                    regras = New rProduto()

                    txtNotaFiscalNumero.Text = txtNotaFiscalNumero.Text.Trim()
                    txtNotaFiscalSerie.Text = txtNotaFiscalSerie.Text.Trim()

                    If (String.IsNullOrEmpty(txtNotaFiscalNumero.Text)) <> (String.IsNullOrEmpty(txtNotaFiscalSerie.Text)) Then
                        MessageBox.Show("Nota Fiscal inválida.", "Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    If (Not String.IsNullOrEmpty(txtNotaFiscalNumero.Text)) And (Not String.IsNullOrEmpty(txtNotaFiscalSerie.Text)) Then
                        dados.notaFiscalNumero = TratarTexto(txtNotaFiscalNumero.Text)
                        dados.notaFiscalSerie = TratarTexto(txtNotaFiscalSerie.Text)
                        nfDados = New dNotaFiscalFornecedor()
                        nfRegras = New rNotaFiscalFornecedor()

                        nfDados.numero = dados.notaFiscalNumero
                        nfDados.serie = dados.notaFiscalSerie
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

                    dados.cid = Me.cid
                    dados.codigo = TratarTexto(txtCodigo.Text)
                    dados.descricao = TratarTexto(txtDescricao.Text)
                    dados.produtoTipo_cid = TratarInteiro(cboTipo.SelectedValue)
                    dados.fornecedor_cid = TratarInteiro(cboFornecedor.SelectedValue)
                    dados.valorCompra = TratarDecimal(txtValorCompra.Text)
                    dados.valorVenda = TratarDecimal(txtValorVenda.Text)
                    dados.fabricante_cid = TratarInteiro(cboFabricante.SelectedValue)
                    dados.situacao = TratarTexto(cboSituacao.SelectedValue)
                    dados.referencia = TratarTexto(txtReferencia.Text)
                    dados.cor_cid = TratarInteiro(cboCor.SelectedValue)
                    dados.grupo_cid = TratarInteiro(cboGrupo.SelectedValue)
                    dados.estoqueMinimo = TratarInteiro(txtEstoqueMinimo.Text)
                    dados.aliquota = TratarTexto(txtAliquota.Text)
                    dados.efdUnidadeMedidaCodigo = TratarTexto(cboEfdUnidadeMedida.SelectedValue)
                    dados.efdCodigoCategoria = TratarTexto(cboCategoria.SelectedValue)
                    dados.ncm = TratarTexto(txtNCM.Text)
                    dados.cest = TratarTexto(txtCEST.Text)

                    If Not String.IsNullOrEmpty(cboCategoria.Text.Trim()) Then
                        dados.efdIntegracao = True
                    Else
                        dados.efdIntegracao = False
                    End If
                    dados.dataInclusao = Now().Year.ToString().PadLeft(4, "0"c) + "-" +
                      Now().Month.ToString().PadLeft(2, "0"c) + "-" +
                      Now().Day.ToString().PadLeft(2, "0"c) + " " +
                      Now().Hour.ToString().PadLeft(2, "0"c) + ":" +
                      Now().Minute.ToString().PadLeft(2, "0"c) + ":" +
                      Now().Second.ToString().PadLeft(2, "0"c)

                    If dgvProduto.Rows.Count > 0 Then
                        colecao = New ColecaoProdutoItem()
                        colecaoItensProdutos = New ColecaoItensProdutos()

                        For Each linha In dgvProduto.Rows
                            colecaoProdutoItem = New ColecaoProdutoItem()

                            For Each celula In linha.Cells
                                If Not celula.OwningColumn.Name.ToLower().Equals("codigobarrasatual") Then
                                    'If Not celula.OwningColumn.Name.ToLower().Equals("estoquenovo") Then
                                    Dim dadosItem As dProdutoItem
                                    Dim estoqueNovo As Integer = 0
                                    Dim estoqueAtual As Integer = 0
                                    Dim estoqueAux As String = "0"
                                    Dim codBarraAtual As String

                                    dadosItem = New dProdutoItem()

                                    If celula.OwningColumn.Name.ToLower().Equals("estoque") Then
                                        If linha.Cells.Item("estoquenovo").Value IsNot Nothing Then
                                            If linha.Cells.Item("estoquenovo").Value IsNot Nothing Then
                                                estoqueAux = linha.Cells.Item("estoquenovo").Value.ToString()
                                            Else
                                                estoqueAux = "0"
                                            End If
                                            Integer.TryParse(estoqueAux, estoqueNovo)
                                            If linha.Cells.Item("estoque").Value IsNot Nothing Then
                                                estoqueAux = linha.Cells.Item("estoque").Value.ToString()
                                            Else
                                                estoqueAux = "0"
                                            End If
                                            Decimal.TryParse(estoqueAux, estoqueAtual)
                                            If estoqueNovo > 0 Then
                                                estoqueAtual = estoqueAtual + estoqueNovo
                                            End If

                                            dadosItem.valor = RetornarTexto(estoqueAtual)

                                            If linha.Cells.Item("codigobarras").Value IsNot Nothing Then
                                                codBarraAtual = linha.Cells.Item("codigobarras").Value.ToString()
                                            Else
                                                codBarraAtual = String.Empty
                                            End If

                                            If (estoqueNovo > 0) And (Not codBarraAtual.Trim().Equals(String.Empty)) And
                                                (Not Me.cid.Equals(Nothing)) Then
                                                '-- Gravar Log Estoque
                                                GravarLogEstoque(mdiPrincipal.gUsuario.cid, mdiPrincipal.gUsuario.nomeCompleto, Me.cid, codBarraAtual, estoqueNovo, dados.notaFiscalNumero, dados.notaFiscalSerie)
                                            End If
                                        Else
                                            dadosItem.valor = RetornarTexto(celula.Value)
                                        End If
                                    Else
                                        dadosItem.valor = RetornarTexto(celula.Value)
                                    End If

                                    dadosItem.produtos_cid = Me.cid
                                    dadosItem.item = linha.Index
                                    dadosItem.caracteristicas_codigo = celula.OwningColumn.Name

                                    colecao.Add(dadosItem)
                                    colecaoProdutoItem.Add(dadosItem)
                                    'End If
                                End If
                            Next

                            colecaoItensProdutos.Add(colecaoProdutoItem)
                        Next
                    Else
                        colecao = Nothing
                    End If

                    regras._usuario = mdiPrincipal.gUsuario

                    If tipoAcao.Equals("i") Then
                        novoCID = regras.Incluir(dados, colecaoItensProdutos, mdiPrincipal.gUsuario)

                        Me.cid = novoCID

                        MessageBox.Show("Informacoes incluidas com sucesso", "Inclusao de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'ExibirInformacoesTela()
                        Limpar()
                    ElseIf tipoAcao.Equals("a") Then
                        regras.Alterar(dados, colecaoItensProdutos, mdiPrincipal.gUsuario)

                        MessageBox.Show("Informacoes alteradas com sucesso", "Inclusao de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'ExibirInformacoesTela()
                        Limpar()
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Produto.")

        End Try
    End Sub

    Private Sub Excluir()
        Dim dados As dProduto
        Dim regras As rProduto

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.ToString().Equals(String.Empty) Then
                    If Not Me.cid.Equals(0) Then
                        If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                            dados = New dProduto
                            regras = New rProduto

                            dados.cid = TratarInteiro(Me.cid)

                            regras.Excluir(dados, mdiPrincipal.gUsuario)

                            Me.cid = Nothing
                            LimparCampos()
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na exclusão dos dados de Produto.")

        End Try
    End Sub

    Private Sub IncluirItem()
        Dim linhaSelecionada As DataGridViewRow
        Dim linhaNova As DataGridViewRow
        Dim indiceNovo As Integer
        Dim dadosCaracteristica As dCaracteristica
        Dim regraCaracteristica As rCaracteristica
        Dim novoCB As String = String.Empty

        If Not produto Is Nothing Then
            If cboTipo.Items.Count > 0 Then
                If cboTipo.SelectedIndex > 0 Then
                    If dgvProduto.Rows.Count <= 0 Then
                        dgvProduto.Rows.Add()
                    Else
                        If dgvProduto.CurrentRow.Index >= 0 Then

                            linhaSelecionada = dgvProduto.Rows(dgvProduto.CurrentRow.Index)

                            indiceNovo = dgvProduto.Rows.AddCopy(dgvProduto.CurrentRow.Index)

                            linhaNova = dgvProduto.Rows(indiceNovo)

                            dadosCaracteristica = New dCaracteristica()
                            regraCaracteristica = New rCaracteristica()

                            For Each celulaSelecionada As DataGridViewCell In linhaSelecionada.Cells

                                For Each celulaNova As DataGridViewCell In linhaNova.Cells
                                    If (celulaNova.OwningColumn.Name.ToLower().Equals("codigobarrasatual")) Or
                                        (celulaNova.OwningColumn.Name.ToLower().Equals("estoquenovo")) Then
                                        celulaNova.Value = String.Empty
                                    Else
                                        If celulaNova.OwningColumn.Name.Equals(celulaSelecionada.OwningColumn.Name) Then

                                            dadosCaracteristica = regraCaracteristica.fConsultarPorCodigo(celulaNova.OwningColumn.Name)

                                            If dadosCaracteristica Is Nothing Then
                                                MessageBox.Show("Erro na inclusão de novo item")
                                                Exit Sub
                                            End If

                                            If (dadosCaracteristica.codigo.ToLower().Equals("codigobarras")) Or
                                               (dadosCaracteristica.codigo.ToLower().Equals("estoque")) Then
                                                celulaNova.Value = String.Empty
                                            Else
                                                celulaNova.Value = RetornarTexto(celulaSelecionada.Value)
                                            End If

                                        End If

                                    End If
                                Next

                            Next

                        End If
                    End If
                Else
                    MessageBox.Show("É necessário selecionar um Tipo de Produto!", "ITEM DE PRODUTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cboTipo.Focus()
                End If
            Else
                MessageBox.Show("É necessário selecionar um Tipo de Produto!", "ITEM DE PRODUTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboTipo.Focus()
            End If
        Else
            MessageBox.Show("É necessário Incluir um produto ou Selecionar um existente!", "ITEM DE PRODUTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub fProdutoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimparCampos()
        CarregarComboProdutoTipo()
        CarregarComboFornecedor()
        CarregarComboGrupo()
        CarregarComboCor()
        CarregarComboFabricante()
        CarregarComboSituacao()
        CarregarComboEfdUnidadeMedida()
        CarregarComboCategoria()
        ExibirInformacoesTela()
        ConsultarProximoCID()
    End Sub

    Private Sub ConsultarProximoCID()
        If (Me.cid.Equals(Nothing)) OrElse (String.IsNullOrEmpty(Me.cid.ToString())) Then
            Dim regra As rProduto = New rProduto()
            Dim proximoCID As Integer

            proximoCID = regra.ConsultarProximoCID()

            txtCodigo.Text = (proximoCID + 1).ToString()
        End If
    End Sub

    Private Sub ExibirInformacoesTela()
        CarregarProduto()
        CarregarProdutoTipoCaracteristica()
        MontarGradeCaracteristicas()
        ListarItens()

        If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
            btoExcluir.Visible = False
            lblExcluirItem.Visible = False
            btoExcluirItem.Visible = False
        End If
    End Sub

    Private Sub LimparCampos()
        cboTipo.DataSource = Nothing
        cboTipo.Items.Clear()
        cboFornecedor.DataSource = Nothing
        cboFornecedor.Items.Clear()
        cboFabricante.DataSource = Nothing
        cboFabricante.Items.Clear()
        cboCor.DataSource = Nothing
        cboCor.Items.Clear()
        cboGrupo.DataSource = Nothing
        cboGrupo.Items.Clear()
        cboSituacao.DataSource = Nothing
        cboSituacao.Items.Clear()
        dgvProduto.Rows.Clear()
        dgvProduto.Columns.Clear()
        dgvProduto.Refresh()
        txtCodigo.Text = ""
        txtDescricao.Text = ""
        txtEstoqueTotal.Text = ""
        txtReferencia.Text = ""
        txtEstoqueMinimo.Text = ""
        txtAliquota.Text = ""
        txtValorCompra.Text = ""
        txtValorVenda.Text = ""
    End Sub

    Private Sub ListarItens()
        Dim regras As rProdutoItem
        Dim colecao As ColecaoProdutoItem
        Dim colecaoQtde As ColecaoProdutoItem
        Dim novaLinha As DataGridViewRow
        Dim item As dProdutoItem
        Dim itemQtde As dProdutoItem
        Dim celula As DataGridViewCell
        Dim existe As Boolean = False
        Dim regraC As rCaracteristica
        Dim dadosC As dCaracteristica
        Dim dadosEstoque As String
        Dim estoque As Integer
        Dim estoqueDec As Decimal
        Dim dadosParametro As dParametro
        Dim regraParametro As rParametro
        Dim ehDecimal As String = Nothing

        Try

            regraParametro = New rParametro()
            dadosParametro = regraParametro.Consultar(cConstantes.Parametros.IsDecimal)
            If Not IsNothing(dadosParametro) Then
                ehDecimal = dadosParametro.valor
            End If

            estoqueTotal = 0

            If Not produto Is Nothing Then
                If Not produto.produtoTipo_cid.Equals(Nothing) Then
                    If dgvProduto.Columns.Count > 0 Then
                        regras = New rProdutoItem()
                        colecao = regras.ConsultarPorProduto(produto.cid)
                        colecaoQtde = regras.ConsultarQuantidadeItem(produto.cid)
                        regraC = New rCaracteristica()

                        If Not colecaoQtde Is Nothing Then
                            If colecaoQtde.Count > 0 Then
                                If colecao.Count > 0 Then

                                    '-- Para cada item do produto
                                    For Each itemQtde In colecaoQtde
                                        novaLinha = dgvProduto.Rows(dgvProduto.Rows.Add())

                                        '-- Para cada coluna da grade
                                        For Each celula In novaLinha.Cells

                                            '-- Verifica se tem o campo cadastrado pro item
                                            For Each item In colecao

                                                If (celula.OwningColumn.Tag.ToString().Equals(item.caracteristicas_cid.ToString())) And
                                                    (item.item.Equals(itemQtde.item)) Then
                                                    dadosC = regraC.ConsultarPorCID(item.caracteristicas_cid)

                                                    If dadosC.codigo.ToLower().Equals("codigobarras") Then
                                                        novaLinha.Cells("codigobarrasatual").Value = item.valor
                                                    End If

                                                    celula.Value = item.valor

                                                    If dadosC.codigo.ToLower().Equals("estoque") Then

                                                        If ehDecimal = "0" Then
                                                            If item.valor IsNot Nothing Then
                                                                dadosEstoque = Convert.ToInt32(Decimal.Parse(item.valor.Replace(",", "."), CultureInfo.InvariantCulture))
                                                            Else
                                                                dadosEstoque = 0
                                                            End If

                                                            If Not dadosEstoque = Nothing Then
                                                                If Not dadosEstoque.Trim().Equals(String.Empty) Then
                                                                    If Integer.TryParse(dadosEstoque.Trim(), estoque) Then
                                                                        estoqueTotal = estoqueTotal + estoque
                                                                    End If
                                                                End If
                                                            End If
                                                        Else
                                                            dadosEstoque = String.Format("{0:0.00}", Convert.ToDecimal(item.valor))
                                                            If Not dadosEstoque = Nothing Then
                                                                If Not dadosEstoque.Trim().Equals(String.Empty) Then
                                                                    If Decimal.TryParse(dadosEstoque.Trim(), estoqueDec) Then
                                                                        estoqueTotaldec = estoqueTotaldec + estoqueDec
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                        celula.Value = dadosEstoque

                                                    End If

                                                    If dadosC.codigo.ToLower().Equals("tamanho") Then

                                                        If item.valor Is Nothing Then
                                                            celula.Value = ""
                                                        Else
                                                            celula.Value = item.valor
                                                        End If

                                                    End If

                                                    Exit For
                                                End If
                                            Next
                                        Next
                                    Next
                                End If

                            End If
                        End If
                    End If
                End If
            End If

            If ehDecimal = "0" Then
                txtEstoqueTotal.Text = estoqueTotal.ToString()
            Else
                txtEstoqueTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(estoqueTotaldec))
            End If


        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Itens de Produtos.")

        End Try
    End Sub

    Private Sub CarregarProduto()
        Dim regras As rProduto

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.Equals(0) Then

                    regras = New rProduto()

                    produto = regras.Consultar(Me.cid)

                    If Not produto Is Nothing Then
                        CarregarInformacoesProduto()
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Produto.")

        End Try
    End Sub

    Private Sub CarregarInformacoesProduto()
        txtCodigo.Text = RetornarTexto(Me.produto.codigo)
        txtDescricao.Text = RetornarTexto(Me.produto.descricao)
        txtReferencia.Text = RetornarTexto(Me.produto.referencia)
        txtEstoqueMinimo.Text = RetornarTexto(Me.produto.estoqueMinimo)
        txtAliquota.Text = RetornarTexto(Me.produto.aliquota)
        txtValorCompra.Text = RetornarTexto(Me.produto.valorCompra)
        txtValorVenda.Text = RetornarTexto(Me.produto.valorVenda)
        txtNCM.Text = RetornarTexto(Me.produto.ncm)
        txtCEST.Text = RetornarTexto(Me.produto.cest)
        If cboFabricante.Items.Count > 0 Then
            cboFabricante.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.fabricante_cid) Then
            cboFabricante.SelectedValue = RetornarInteiro(Me.produto.fabricante_cid)
        End If
        If cboCor.Items.Count > 0 Then
            cboCor.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.cor_cid) Then
            cboCor.SelectedValue = RetornarInteiro(Me.produto.cor_cid)
        End If
        If cboGrupo.Items.Count > 0 Then
            cboGrupo.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.grupo_cid) Then
            cboGrupo.SelectedValue = RetornarInteiro(Me.produto.grupo_cid)
        End If
        If cboFornecedor.Items.Count > 0 Then
            cboFornecedor.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.fornecedor_cid) Then
            cboFornecedor.SelectedValue = RetornarInteiro(Me.produto.fornecedor_cid)
        End If
        If cboSituacao.Items.Count > 0 Then
            cboSituacao.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.situacao) Then
            cboSituacao.SelectedValue = RetornarTexto(Me.produto.situacao)
        End If
        If cboTipo.Items.Count > 0 Then
            cboTipo.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.produtoTipo_cid) Then
            cboTipo.SelectedValue = RetornarInteiro(Me.produto.produtoTipo_cid)
        End If
        If cboEfdUnidadeMedida.Items.Count > 0 Then
            cboEfdUnidadeMedida.SelectedIndex = 0
        End If
        If ValidarValor(Me.produto.efdUnidadeMedidaCodigo) Then
            cboEfdUnidadeMedida.SelectedValue = RetornarTexto(Me.produto.efdUnidadeMedidaCodigo)
        End If
        If ValidarValor(Me.produto.efdCodigoCategoria) Then
            cboCategoria.SelectedValue = RetornarInteiro(Me.produto.efdCodigoCategoria)
        End If
    End Sub

    Private Sub CarregarComboProdutoTipo()
        Dim regras As rProdutoTipo
        Dim colecao As ColecaoProdutoTipo

        Try

            cboTipo.DataSource = Nothing
            cboTipo.Items.Clear()

            regras = New rProdutoTipo()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dProdutoTipo())

                cboTipo.ValueMember = "cid"
                cboTipo.DisplayMember = "nome"
                cboTipo.DataSource = colecao
                cboTipo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Tipo de Produto.")

        End Try
    End Sub

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

    Private Sub CarregarComboCor()
        Dim regras As rCor
        Dim colecao As ColecaoCor

        Try

            cboCor.DataSource = Nothing
            cboCor.Items.Clear()

            regras = New rCor()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dCor())

                cboCor.ValueMember = "cid"
                cboCor.DisplayMember = "nome"
                cboCor.DataSource = colecao
                cboCor.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cor.")

        End Try
    End Sub

    Private Sub CarregarComboGrupo()
        Dim regras As rGrupo
        Dim colecao As ColecaoGrupo

        Try

            cboGrupo.DataSource = Nothing
            cboGrupo.Items.Clear()

            regras = New rGrupo()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dGrupo())

                cboGrupo.ValueMember = "cid"
                cboGrupo.DisplayMember = "nome"
                cboGrupo.DataSource = colecao
                cboGrupo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Grupo.")

        End Try
    End Sub

    Private Sub CarregarComboEfdUnidadeMedida()
        Dim regras As rEfdUnidadeMedida
        Dim colecao As ColecaoEfdUnidadeMedida

        Try

            cboEfdUnidadeMedida.DataSource = Nothing
            cboEfdUnidadeMedida.Items.Clear()

            regras = New rEfdUnidadeMedida()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                cboEfdUnidadeMedida.ValueMember = "codigo"
                cboEfdUnidadeMedida.DisplayMember = "descricao"
                cboEfdUnidadeMedida.DataSource = colecao
                cboEfdUnidadeMedida.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Situação.")

        End Try
    End Sub

    Private Sub CarregarComboSituacao()
        Dim regras As rSituacao
        Dim colecao As ColecaoSituacao

        Try

            cboSituacao.DataSource = Nothing
            cboSituacao.Items.Clear()

            regras = New rSituacao()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then


                cboSituacao.ValueMember = "codigo"
                cboSituacao.DisplayMember = "descricao"
                cboSituacao.DataSource = colecao
                cboSituacao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Situação.")

        End Try
    End Sub

    Private Sub CarregarComboCategoria()
        Dim regras As rCategoria
        Dim colecao As ColecaoCategoria

        Try

            cboCategoria.DataSource = Nothing
            cboCategoria.Items.Clear()

            regras = New rCategoria()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dCategoria())

                cboCategoria.ValueMember = "cid"
                cboCategoria.DisplayMember = "nome"
                cboCategoria.DataSource = colecao
                cboCategoria.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Categorias.")

        End Try

    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub CarregarProdutoTipoCaracteristica()
        Dim regras As rProdutoTipoCaracteristica

        Try

            colecaoProdutoTipoCaracteristica = Nothing

            If cboTipo.Items.Count > 0 Then
                If Not cboTipo.SelectedIndex.Equals(0) And Not cboTipo.SelectedIndex = -1 Then
                    If Not cboTipo.SelectedValue.ToString().Trim().Equals(String.Empty) Then
                        regras = New rProdutoTipoCaracteristica()

                        colecaoProdutoTipoCaracteristica = regras.ConsultarPorProdutoTipo(cboTipo.SelectedValue)
                    End If
                End If
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
        Dim texto As DataGridViewTextBoxColumn
        Dim combo As DataGridViewComboBoxColumn
        Dim colecaoCaracteristicaItem As ColecaoCaracteristicaItem
        Dim regraCaracteristicaItem As rCaracteristicaItem
        Dim leitura As Boolean = False

        dgvProduto.Rows.Clear()
        dgvProduto.Columns.Clear()
        dgvProduto.Refresh()

        If Not colecaoProdutoTipoCaracteristica Is Nothing Then
            regraCaracteristicaItem = New rCaracteristicaItem()

            For Each item In colecaoProdutoTipoCaracteristica
                If item.quantidade.Equals(Nothing) Then
                    qtde = 0
                Else
                    qtde = item.quantidade
                End If

                leitura = False
                If item.caracteristica_codigo.Equals("estoque") Then
                    leitura = True
                End If

                If qtde > 0 Then
                    combo = New DataGridViewComboBoxColumn()
                    combo.Name = item.caracteristica_codigo
                    combo.HeaderText = item.caracteristica_nome
                    combo.Tag = item.caracteristica_cid.ToString()
                    combo.SortMode = DataGridViewColumnSortMode.NotSortable
                    'combo.ReadOnly = True

                    colecaoCaracteristicaItem = regraCaracteristicaItem.ConsultarPorCaracteristica(item.caracteristica_cid)
                    If Not colecaoCaracteristicaItem Is Nothing Then
                        combo.DisplayMember = "valor"
                        combo.DataSource = colecaoCaracteristicaItem
                    End If

                    dgvProduto.Columns.Add(combo)
                Else
                    texto = New DataGridViewTextBoxColumn()
                    texto.Name = item.caracteristica_codigo
                    texto.HeaderText = item.caracteristica_nome
                    texto.Tag = item.caracteristica_cid.ToString()
                    texto.SortMode = DataGridViewColumnSortMode.NotSortable
                    texto.ReadOnly = leitura
                    dgvProduto.Columns.Add(texto)
                End If

            Next

            texto = New DataGridViewTextBoxColumn()
            texto.Name = "codigobarrasatual"
            texto.Tag = ""
            texto.SortMode = DataGridViewColumnSortMode.NotSortable
            texto.Visible = False
            dgvProduto.Columns.Add(texto)

            texto = New DataGridViewTextBoxColumn()
            texto.Name = "estoquenovo"
            texto.HeaderText = "Entrada de Produtos"
            texto.Tag = ""
            texto.SortMode = DataGridViewColumnSortMode.NotSortable
            texto.Visible = True
            dgvProduto.Columns.Add(texto)

            dgvProduto.Refresh()
        End If
    End Sub

    Private Sub dgvProduto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProduto.KeyDown
        Select Case e.KeyCode
            Case Keys.F4
                ExcluirItem()
        End Select
    End Sub

    Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
        ExcluirItem()
    End Sub

    Private Sub ExcluirItem()
        If MessageBox.Show("Confirma EXCLUSÃO do item?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            If dgvProduto.Rows.Count > 0 Then
                dgvProduto.Rows.RemoveAt(dgvProduto.CurrentRow.Index)
            End If
        End If
    End Sub

    Private Sub cboTipo_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectionChangeCommitted
        CarregarProdutoTipoCaracteristica()
        MontarGradeCaracteristicas()

        If cboTipo.Items.Count > 0 Then
            If Not cboTipo.SelectedIndex.Equals(0) Then
                If Not cboTipo.SelectedValue.ToString().Trim().Equals(String.Empty) Then
                    If Not produto Is Nothing Then
                        If Not produto.produtoTipo_cid.Equals(Nothing) Then
                            If produto.produtoTipo_cid.Equals(cboTipo.SelectedValue) Then
                                ListarItens()
                            End If
                        End If
                    End If

                    If dgvProduto.Rows.Count <= 0 Then
                        dgvProduto.Rows.Add()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btoEtiqueta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiqueta.Click
        ImprimirEtiqueta()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Limpar()
        ConsultarProximoCID()
    End Sub


    Private Sub ImprimirEtiqueta()
        If Me.cid Is Nothing OrElse Me.cid = 0 Then
            MessageBox.Show("Selecione um produto antes de imprimir a etiqueta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvProduto.Rows.Count = 0 OrElse dgvProduto.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um item na grade do produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        fProdutoEtiqueta.produto_cid = Me.cid
        fProdutoEtiqueta.item = dgvProduto.CurrentRow.Index
        fProdutoEtiqueta.ShowDialog()
    End Sub

    Private Sub ImprimirEtiquetaES()
        fProdutoEtiquetaES.ShowDialog(mdiPrincipal)
    End Sub

    Private Sub btoTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarProdutoTipoFiltro()
    End Sub

    Private Sub CarregarProdutoTipoFiltro()
        mdiPrincipal.CarregarProdutoTipoFiltro()
    End Sub

    Private Sub btoCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CarregarCaracteristicaFiltro()
    End Sub

    Private Sub CarregarCaracteristicaFiltro()
        mdiPrincipal.CarregarCaracteristicaFiltro()
    End Sub

    Private Sub CarregarFabricanteFiltro()
        fFabricanteForm.cid = Nothing
        fFabricanteForm.ShowDialog()
    End Sub

    Private Sub CarregarCorFiltro()
        fCorForm.cid = Nothing
        fCorForm.ShowDialog()
    End Sub

    Private Sub CarregarGrupoFiltro()
        fGrupoForm.cid = Nothing
        fGrupoForm.ShowDialog()
    End Sub

    Private Sub CarregarFornecedorFiltro()
        fFornecedorForm.cid = Nothing
        fFornecedorForm.ShowDialog()
    End Sub

    Private Sub CarregarCategoriaFiltro()
        fCategoriaForm.cid = Nothing
        fCategoriaForm.ShowDialog()
    End Sub


    Private Sub btoEtiquetaES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiquetaES.Click
        ImprimirEtiquetaES()
    End Sub

    Private Sub Limpar()
        Me.cid = Nothing
        Me.produto = Nothing
        LimparCampos()
        CarregarComboProdutoTipo()
        CarregarComboFornecedor()
        CarregarComboGrupo()
        CarregarComboCor()
        CarregarComboFabricante()
        CarregarComboSituacao()
        CarregarComboCategoria()
        ExibirInformacoesTela()
    End Sub

    Private Sub btoFornecedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFornecedores.Click
        CarregarFornecedorFiltro()
    End Sub

    Private Sub btoFabricantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFabricantes.Click
        CarregarFabricanteFiltro()
    End Sub

    Public Sub SelecionarNovoFabricante(ByVal codigo As Integer)
        Try
            CarregarComboFabricante()

            If cboFabricante.Items.Count > 0 Then
                cboFabricante.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SelecionarNovoFornecedor(ByVal codigo As Integer)
        Try
            CarregarComboFornecedor()

            If cboFornecedor.Items.Count > 0 Then
                cboFornecedor.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SelecionarNovaCor(ByVal codigo As Integer)
        Try
            CarregarComboCor()

            If cboCor.Items.Count > 0 Then
                cboCor.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SelecionarNovoGrupo(ByVal codigo As Integer)
        Try
            CarregarComboGrupo()

            If cboGrupo.Items.Count > 0 Then
                cboGrupo.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SelecionarNovaCategoria(ByVal codigo As Integer)
        Try
            CarregarComboCategoria()

            If cboCategoria.Items.Count > 0 Then
                cboCategoria.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btoGrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoGrade.Click
        IncluirGrade()
    End Sub

    Private Sub IncluirGrade()
        Dim valido As Boolean = False

        If cboTipo.Items.Count > 0 Then
            If cboTipo.SelectedIndex > 0 Then
                valido = True
            End If
        End If

        If valido = True Then
            fGradeForm.ShowDialog()
            Me.dgvProduto.Focus()
        Else
            MessageBox.Show("É necessário selecionar um tipo de produto", "Grade", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub IncluirLinhasUnico(ByVal tamanho As String)
        Dim linha As DataGridViewRow

        Try
            linha = dgvProduto.Rows(dgvProduto.Rows.Add())
            linha.Cells.Item("tamanho").Value = tamanho

            ExcluirLinhaVazia()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub IncluirLinhasNumero(ByVal lista() As Integer)
        Dim numeros As String = String.Empty

        Try

            If Not lista Is Nothing Then
                If lista.Length > 0 Then

                    For Each linha As DataGridViewRow In dgvProduto.Rows
                        If linha.Cells("tamanho").Value IsNot Nothing Then
                            numeros &= "|" & linha.Cells("tamanho").Value & "|"
                        End If
                    Next

                    For Each tamanho As Integer In lista
                        If Not numeros.Contains("|" & tamanho.ToString() & "|") Then
                            Dim linha As DataGridViewRow

                            linha = dgvProduto.Rows(dgvProduto.Rows.Add())
                            linha.Cells.Item("tamanho").Value = tamanho
                        End If
                    Next

                    ExcluirLinhaVazia()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub IncluirLinhasTexto(ByVal lista() As String)
        Try

            If Not lista Is Nothing Then
                If lista.Length > 0 Then
                    For Each tamanho As String In lista
                        Dim linha As DataGridViewRow

                        linha = dgvProduto.Rows(dgvProduto.Rows.Add())
                        linha.Cells.Item("tamanho").Value = tamanho
                    Next

                    ExcluirLinhaVazia()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ExcluirLinhaVazia()
        Dim preenchido As Boolean = False

        For Each linha As DataGridViewRow In dgvProduto.Rows
            preenchido = False

            For Each celula As DataGridViewCell In linha.Cells
                If celula.Value IsNot Nothing Then
                    If Not celula.Value.ToString().Equals(String.Empty) Then
                        preenchido = True
                    End If
                End If
            Next

            If preenchido = False Then
                dgvProduto.Rows.Remove(linha)
            End If
        Next

    End Sub

    Private Sub txtValorCompra_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorCompra.Leave
        Dim aux As Decimal

        If Not String.IsNullOrEmpty(txtValorCompra.Text) Then
            If Decimal.TryParse(txtValorCompra.Text, aux) Then
                txtValorCompra.Text = String.Format("{0:F2}", aux)
            End If
        End If
    End Sub

    Private Sub txtValorVenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorVenda.Leave
        Dim aux As Decimal

        If Not String.IsNullOrEmpty(txtValorVenda.Text) Then
            If Decimal.TryParse(txtValorVenda.Text, aux) Then
                txtValorVenda.Text = String.Format("{0:F2}", aux)
            End If
        End If
    End Sub

    Private Sub btoGiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CadastrarGiro()
    End Sub

    Private Sub CadastrarGiro()
        Dim valido As Boolean = False
        Dim regrasPI As rProdutoItem = New rProdutoItem()
        Dim dadosPI As rProdutoItem = New rProdutoItem()

        If Not Me.cid.Equals(Nothing) Then
            If Not Me.cid.ToString().Equals(String.Empty) Then
                If Not Me.cid.Equals(0) Then
                    If dgvProduto.Rows.Count > 0 Then
                        If dgvProduto.CurrentRow.Index >= 0 Then
                            valido = True
                        End If
                    End If
                End If
            End If
        End If

        If valido = True Then
            fGiroForm.produto_cid = Me.cid
            fGiroForm.item = dgvProduto.CurrentRow.Index
            fGiroForm.ShowDialog()
        Else

        End If
    End Sub

    Private Sub CarregarNotaFiscalFornecedorForm()
        mdiPrincipal.CarregarNotaFiscalFornecedorForm()
    End Sub

    Private Sub CarregarNotaFiscalFornecedorLista(ByVal codigoProduto As String)
        mdiPrincipal.CarregarNotaFiscalFornecedorLista(codigoProduto)
    End Sub

    Private Sub btoNotaFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNotaFiscal.Click
        CarregarTelaNotaFiscal()
    End Sub

    Private Sub CarregarTelaNotaFiscal()
        If (Not txtNotaFiscalNumero.Text.Trim().Equals(String.Empty)) Or (Not txtNotaFiscalSerie.Text.Trim().Equals(String.Empty)) Then
            Me.nffTipoAcao = "l"
            Me.nffNumero = txtNotaFiscalNumero.Text.Trim()
            Me.nffSerie = txtNotaFiscalSerie.Text.Trim()
            Me.CarregarNotaFiscalFornecedorLista(txtCodigo.Text)
        Else
            Me.nffTipoAcao = "i"
            CarregarNotaFiscalFornecedorForm()
        End If
    End Sub

    Private Sub btoCor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCor.Click
        CarregarCorFiltro()
    End Sub

    Private Sub btoGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoGrupo.Click
        CarregarGrupoFiltro()
    End Sub

    Private Sub btoNF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNF.Click
        CarregarNotaFiscalFornecedorLista(Me.txtCodigo.Text)
    End Sub

    Private Sub btoCategoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCategoria.Click
        CarregarCategoriaFiltro()
    End Sub

    Private Sub btoImpostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImpostos.Click
        CarregarImpostos()
    End Sub

    Private Sub CarregarImpostos()
        Dim valido As Boolean = False

        If Not Me.cid.Equals(Nothing) Then
            If Not Me.cid.ToString().Equals(String.Empty) Then
                If Not Me.cid.Equals(0) Then
                    valido = True
                End If
            End If
        End If

        If valido = True Then
            fImpostoLista.produto_cid = Me.cid
            mdiPrincipal.CarregarImpostoLista()
        Else
            MessageBox.Show("Salve o produto antes de configurar os Impostos.")
        End If
    End Sub
End Class