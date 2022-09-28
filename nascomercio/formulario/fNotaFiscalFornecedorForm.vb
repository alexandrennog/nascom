Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsNotaFiscalFornecedor
Imports ncRegras.nsNotaFiscalFornecedor
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fNotaFiscalFornecedorForm

    Private numero As String = ""
    Private serie As String = ""
    Private tipoAcao As String = "i"

    Private Sub fNotaFiscalFornecedorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarComboFornecedor()
        CarregarComboTipoFluxo()
        CarregarComboTipoNotaFiscal()
        CarregarComboTipoPagamento()
        CarregarComboTipoFrete()
        CarregarComboTipoEmissao()
        CarregarComboSituacaoNotaFiscal()

        Me.tipoAcao = fProdutoForm.nffTipoAcao
        Me.numero = fProdutoForm.nffNumero
        Me.serie = fProdutoForm.nffSerie

        If Me.tipoAcao.ToLower.Equals("a") Then
            If Not String.IsNullOrEmpty(Me.numero) Then
                If Not String.IsNullOrEmpty(Me.serie) Then
                    ConfigurarTela("a")
                    ExibirInformacoesTela()
                End If
            End If
        End If
    End Sub

    Private Sub fNotaFiscalFornecedorForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                End If
            Case Keys.F5
                Pesquisar()
            Case Keys.F1
                Novo()
            Case Keys.Enter
                Salvar()
            Case Keys.F12
                Excluir()
            Case Keys.F4
                Selecionar()
        End Select
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
        Excluir()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Pesquisar()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub btoNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNovo.Click
        Novo()
    End Sub

    Private Sub btoSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSelecionar.Click
        Selecionar()
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

    Private Sub CarregarComboTipoFluxo()
        Dim regras As rTipoFluxo
        Dim colecao As ColecaoTipoFluxo

        Try

            cboTipoFluxo.DataSource = Nothing
            cboTipoFluxo.Items.Clear()

            regras = New rTipoFluxo()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dTipoFluxo())

                cboTipoFluxo.ValueMember = "cid"
                cboTipoFluxo.DisplayMember = "descricao"
                cboTipoFluxo.DataSource = colecao
                cboTipoFluxo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoFluxo.")

        End Try
    End Sub

    Private Sub CarregarComboTipoEmissao()
        Dim regras As rTipoEmissao
        Dim colecao As ColecaoTipoEmissao

        Try

            cboTipoEmissao.DataSource = Nothing
            cboTipoEmissao.Items.Clear()

            regras = New rTipoEmissao()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dTipoEmissao())

                cboTipoEmissao.ValueMember = "cid"
                cboTipoEmissao.DisplayMember = "descricao"
                cboTipoEmissao.DataSource = colecao
                cboTipoEmissao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoEmissao.")

        End Try
    End Sub

    Private Sub CarregarComboTipoNotaFiscal()
        Dim regras As rTipoNotaFiscal
        Dim colecao As ColecaoTipoNotaFiscal

        Try

            cboTipo.DataSource = Nothing
            cboTipo.Items.Clear()

            regras = New rTipoNotaFiscal()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dTipoNotaFiscal())

                cboTipo.ValueMember = "cid"
                cboTipo.DisplayMember = "descricao"
                cboTipo.DataSource = colecao
                cboTipo.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoNotaFiscal.")

        End Try
    End Sub

    Private Sub CarregarComboSituacaoNotaFiscal()
        Dim regras As rSituacaoNotaFiscal
        Dim colecao As ColecaoSituacaoNotaFiscal

        Try

            cboSituacao.DataSource = Nothing
            cboSituacao.Items.Clear()

            regras = New rSituacaoNotaFiscal()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dSituacaoNotaFiscal())

                cboSituacao.ValueMember = "cid"
                cboSituacao.DisplayMember = "descricao"
                cboSituacao.DataSource = colecao
                cboSituacao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de SituacaoNotaFiscal.")

        End Try
    End Sub

    Private Sub CarregarComboTipoPagamento()
        Dim regras As rTipoPagamento
        Dim colecao As ColecaoTipoPagamento

        Try

            cboTipoPagamento.DataSource = Nothing
            cboTipoPagamento.Items.Clear()

            regras = New rTipoPagamento()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dTipoPagamento())

                cboTipoPagamento.ValueMember = "cid"
                cboTipoPagamento.DisplayMember = "descricao"
                cboTipoPagamento.DataSource = colecao
                cboTipoPagamento.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoPagamento.")

        End Try
    End Sub

    Private Sub CarregarComboTipoFrete()
        Dim regras As rTipoFrete
        Dim colecao As ColecaoTipoFrete

        Try

            cboTipoFrete.DataSource = Nothing
            cboTipoFrete.Items.Clear()

            regras = New rTipoFrete()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then
                colecao.Insert(0, New dTipoFrete())

                cboTipoFrete.ValueMember = "cid"
                cboTipoFrete.DisplayMember = "descricao"
                cboTipoFrete.DataSource = colecao
                cboTipoFrete.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de TipoFrete.")

        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            If Not cFuncoes.ValidarLong(txtNumero.Text) Then
                MessageBox.Show("Número da nota fiscal inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                Return False
            End If

            If Not cFuncoes.ValidarInteiro(txtSerie.Text) Then
                MessageBox.Show("Série da nota fiscal inválida.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSerie.Focus()
                Return False
            End If

            If cboFornecedor.Items.Count <= 0 Then
                MessageBox.Show("Fornecedor inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboFornecedor.Focus()
                Return False
            Else
                If (cboFornecedor.SelectedValue Is Nothing) OrElse (String.IsNullOrEmpty(cboFornecedor.SelectedValue.ToString())) Then
                    MessageBox.Show("Fornecedor inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboFornecedor.Focus()
                    Return False
                End If
            End If

            If Not cFuncoes.ValidarData(txtDataEmissao.Text) Then
                MessageBox.Show("Data de Emissão inválida.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDataEmissao.Focus()
                Return False
            End If

            If Not String.IsNullOrEmpty(txtValorBaseIcms.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorBaseIcms.Text) Then
                    MessageBox.Show("Base de Cálculo do ICMS inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorBaseIcms.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorIcms.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorIcms.Text) Then
                    MessageBox.Show("Valor do ICMS inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorIcms.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorBaseIcmsSubstituicao.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorBaseIcmsSubstituicao.Text) Then
                    MessageBox.Show("Base de Cálculo do ICMS Substituição inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorBaseIcmsSubstituicao.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorIcmsSubstituicao.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorIcmsSubstituicao.Text) Then
                    MessageBox.Show("Valor do ICMS Substituição inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorIcmsSubstituicao.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorTotalIpi.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorTotalIpi.Text) Then
                    MessageBox.Show("Valor Total do IPI inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorTotalIpi.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorTotalProdutos.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorTotalProdutos.Text) Then
                    MessageBox.Show("Valor Total dos Produtos inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorTotalProdutos.Focus()
                    Return False
                End If
            End If

            If Not String.IsNullOrEmpty(txtValorTotalNota.Text) Then
                If Not cFuncoes.ValidarDecimal(txtValorTotalNota.Text) Then
                    MessageBox.Show("Valor Total da Nota inválido.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtValorTotalNota.Focus()
                    Return False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erro na validação dos dados.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try

        Return True
    End Function

    Private Sub Salvar()
        Dim dados As dNotaFiscalFornecedor
        Dim regras As rNotaFiscalFornecedor
        Dim tipoMsg As String = String.Empty
        Dim novoCID As Integer

        Try
            If Not Validar() Then
                Return
            End If

            tipoMsg = "INCLUSÃO"

            If Me.tipoAcao.ToLower.Equals("a") Then
                tipoMsg = "ALTERAÇÃO"
            End If

            If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                dados = New dNotaFiscalFornecedor
                regras = New rNotaFiscalFornecedor

                dados.numero = cFuncoes.TratarTexto(txtNumero.Text)
                dados.serie = cFuncoes.TratarTexto(txtSerie.Text)
                dados.fornecedor_cid = cFuncoes.TratarInteiro(cboFornecedor.SelectedValue)
                dados.dataEmissao = cFuncoes.TratarTexto(cFuncoes.FormatarData(txtDataEmissao.Text))
                dados.valorBaseIcms = cFuncoes.TratarDecimal(txtValorBaseIcms.Text)
                dados.valorIcms = cFuncoes.TratarDecimal(txtValorIcms.Text)
                dados.valorBaseIcmsSubstituicao = cFuncoes.TratarDecimal(txtValorBaseIcmsSubstituicao.Text)
                dados.valorIcmsSubstituicao = cFuncoes.TratarDecimal(txtValorIcmsSubstituicao.Text)
                dados.valorTotalIpi = cFuncoes.TratarDecimal(txtValorTotalIpi.Text)
                dados.valorTotalProdutos = cFuncoes.TratarDecimal(txtValorTotalProdutos.Text)
                dados.valorTotalNota = cFuncoes.TratarDecimal(txtValorTotalNota.Text)
                dados.dataInclusao = Today.Date

                dados.tipoFluxo_cid = cFuncoes.TratarInteiro(cboTipoFluxo.SelectedValue)
                dados.tipoEmissao_cid = cFuncoes.TratarInteiro(cboTipoEmissao.SelectedValue)
                dados.tipoNotaFiscal_cid = cFuncoes.TratarInteiro(cboTipo.SelectedValue)
                dados.situacaoNotaFiscal_cid = cFuncoes.TratarInteiro(cboSituacao.SelectedValue)
                dados.tipoPagamento_cid = cFuncoes.TratarInteiro(cboTipoPagamento.SelectedValue)
                dados.tipoFrete_cid = cFuncoes.TratarInteiro(cboTipoFrete.SelectedValue)
                dados.dataEntrada = cFuncoes.TratarTexto(cFuncoes.FormatarData(txtDataEntrada.Text))
                dados.chaveNotaFiscalEletronica = cFuncoes.TratarTexto(txtChaveEletronica.Text)

                dados.valorFrete = cFuncoes.TratarDecimal(txtValorFrete.Text)
                dados.valorSeguro = cFuncoes.TratarDecimal(txtValorSeguro.Text)
                dados.valorDesconto = cFuncoes.TratarDecimal(txtValorDesconto.Text)
                dados.valorOutrasDespesas = cFuncoes.TratarDecimal(txtValorOutrasDespesas.Text)
                dados.valorAbatimento = cFuncoes.TratarDecimal(txtValorAbatimento.Text)
                dados.valorTotalPis = cFuncoes.TratarDecimal(txtValorTotalPis.Text)
                dados.valorPisRetidoSubstituicao = cFuncoes.TratarDecimal(txtValorPisRetidoSubstituicao.Text)
                dados.valorTotalCofins = cFuncoes.TratarDecimal(txtValorTotalCofins.Text)
                dados.valorCofinsRetidoSubstituicao = cFuncoes.TratarDecimal(txtValorCofinsRetidoSubstituicao.Text)

                If tipoAcao.Equals("i") Or tipoAcao.Equals("") Then
                    novoCID = regras.Incluir(dados)

                    Me.numero = txtNumero.Text
                    Me.serie = txtSerie.Text
                    Limpar()
                    ConfigurarTela("a")
                    ExibirInformacoesTela()
                    MessageBox.Show("Informações incluídas com sucesso.")
                ElseIf tipoAcao.Equals("a") Then
                    regras.Alterar(dados)

                    Limpar()
                    ExibirInformacoesTela()
                    MessageBox.Show("Informações alteradas com sucesso.")
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados de Nota Fiscal.")

        End Try

    End Sub

    Private Sub ConfigurarTela(ByVal tipo As String)
        Select Case tipo
            Case "i"
                Me.tipoAcao = "i"
                Me.numero = String.Empty
                txtNumero.Text = String.Empty
                txtNumero.Enabled = True
                Me.serie = String.Empty
                txtSerie.Text = String.Empty
                txtSerie.Enabled = True
            Case "a"
                Me.tipoAcao = "a"
                txtNumero.Text = Me.numero
                txtNumero.Enabled = False
                txtSerie.Text = Me.serie
                txtSerie.Enabled = False
        End Select
    End Sub

    Private Sub Pesquisar()
        mdiPrincipal.CarregarNotaFiscalFornecedorLista(Nothing)
    End Sub

    Private Sub Excluir()
        Dim dados As dNotaFiscalFornecedor
        Dim regras As rNotaFiscalFornecedor

        Try

            If tipoAcao.ToLower.Equals("a") Then
                If Not String.IsNullOrEmpty(Me.numero) Then
                    If Not String.IsNullOrEmpty(Me.serie) Then
                        If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                            dados = New dNotaFiscalFornecedor
                            regras = New rNotaFiscalFornecedor

                            dados.numero = cFuncoes.TratarTexto(Me.numero)
                            dados.serie = cFuncoes.TratarTexto(Me.serie)

                            regras.Excluir(dados)

                            Novo()
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na exclusão dos dados de Nota Fiscal.")

        End Try
    End Sub

    Private Sub ExibirInformacoesTela()
        Dim regras As rNotaFiscalFornecedor
        Dim dados As dNotaFiscalFornecedor

        Try

            If Me.tipoAcao.ToLower.Equals("a") Then
                regras = New rNotaFiscalFornecedor()

                dados = regras.Selecionar(Me.numero, Me.serie)

                If Not dados Is Nothing Then
                    txtNumero.Text = cFuncoes.RetornarTexto(dados.numero)
                    txtSerie.Text = cFuncoes.RetornarTexto(dados.serie)
                    txtDataEmissao.Text = cFuncoes.RetornarTexto(cFuncoes.FormatarData(dados.dataEmissao))
                    txtValorBaseIcms.Text = cFuncoes.RetornarTexto(dados.valorBaseIcms)
                    txtValorIcms.Text = cFuncoes.RetornarTexto(dados.valorIcms)
                    txtValorBaseIcmsSubstituicao.Text = cFuncoes.RetornarTexto(dados.valorBaseIcmsSubstituicao)
                    txtValorIcmsSubstituicao.Text = cFuncoes.RetornarTexto(dados.valorIcmsSubstituicao)
                    txtValorTotalIpi.Text = cFuncoes.RetornarTexto(dados.valorTotalIpi)
                    txtValorTotalProdutos.Text = cFuncoes.RetornarTexto(dados.valorTotalProdutos)
                    txtValorTotalNota.Text = cFuncoes.RetornarTexto(dados.valorTotalNota)
                    If cboFornecedor.Items.Count > 0 Then
                        If (Not dados.fornecedor_cid.Equals(Nothing)) Then
                            cboFornecedor.SelectedValue = cFuncoes.RetornarInteiro(dados.fornecedor_cid)
                        End If
                    End If

                    If cboTipo.Items.Count > 0 Then
                        If (Not dados.tipoNotaFiscal_cid.Equals(Nothing)) Then
                            cboTipo.SelectedValue = cFuncoes.RetornarInteiro(dados.tipoNotaFiscal_cid)
                        End If
                    End If
                    If cboTipoEmissao.Items.Count > 0 Then
                        If (Not dados.tipoEmissao_cid.Equals(Nothing)) Then
                            cboTipoEmissao.SelectedValue = cFuncoes.RetornarInteiro(dados.tipoEmissao_cid)
                        End If
                    End If
                    If cboTipoFluxo.Items.Count > 0 Then
                        If (Not dados.tipoFluxo_cid.Equals(Nothing)) Then
                            cboTipoFluxo.SelectedValue = cFuncoes.RetornarInteiro(dados.tipoFluxo_cid)
                        End If
                    End If
                    If cboTipoFrete.Items.Count > 0 Then
                        If (Not dados.tipoFrete_cid.Equals(Nothing)) Then
                            cboTipoFrete.SelectedValue = cFuncoes.RetornarInteiro(dados.tipoFrete_cid)
                        End If
                    End If
                    If cboTipoPagamento.Items.Count > 0 Then
                        If (Not dados.tipoPagamento_cid.Equals(Nothing)) Then
                            cboTipoPagamento.SelectedValue = cFuncoes.RetornarInteiro(dados.tipoPagamento_cid)
                        End If
                    End If
                    If cboSituacao.Items.Count > 0 Then
                        If (Not dados.situacaoNotaFiscal_cid.Equals(Nothing)) Then
                            cboSituacao.SelectedValue = cFuncoes.RetornarInteiro(dados.situacaoNotaFiscal_cid)
                        End If
                    End If

                    txtChaveEletronica.Text = cFuncoes.RetornarTexto(dados.chaveNotaFiscalEletronica)
                    txtDataEntrada.Text = cFuncoes.RetornarTexto(cFuncoes.FormatarData(dados.dataEntrada.ToString()))
                    txtValorAbatimento.Text = cFuncoes.RetornarTexto(dados.valorAbatimento)
                    txtValorDesconto.Text = cFuncoes.RetornarTexto(dados.valorDesconto)
                    txtValorFrete.Text = cFuncoes.RetornarTexto(dados.valorFrete)
                    txtValorSeguro.Text = cFuncoes.RetornarTexto(dados.valorSeguro)
                    txtValorOutrasDespesas.Text = cFuncoes.RetornarTexto(dados.valorOutrasDespesas)
                    txtValorPisRetidoSubstituicao.Text = cFuncoes.RetornarTexto(dados.valorPisRetidoSubstituicao)
                    txtValorTotalPis.Text = cFuncoes.RetornarTexto(dados.valorTotalPis)
                    txtValorCofinsRetidoSubstituicao.Text = cFuncoes.RetornarTexto(dados.valorCofinsRetidoSubstituicao)
                    txtValorTotalCofins.Text = cFuncoes.RetornarTexto(dados.valorTotalCofins)

                    PesquisarItens()
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Nota Fiscal.")

        End Try
    End Sub

    Private Sub PesquisarItens()
        Dim regras As rNotaFiscalFornecedor
        Dim itens As ColecaoNotaFiscalItem
        Dim linha As DataGridViewRow

        Try

            dgvProdutoItem.DataSource = Nothing
            dgvProdutoItem.Rows.Clear()
            dgvProdutoItem.Refresh()

            regras = New rNotaFiscalFornecedor

            If txtNumero.Text.Trim().Length > 1 Or txtSerie.Text.Trim().Length > 1 Then
                itens = regras.fConsultarItemNota(txtNumero.Text, txtSerie.Text)
                If Not IsNothing(itens) Then
                    For Each produto As dNotaFiscalItem In itens
                        linha = dgvProdutoItem.Rows(dgvProdutoItem.Rows.Add())
                        linha.Cells("produtos_cid").Value = produto.produtos_cid
                        linha.Cells("valor").Value = produto.caracteristicas_codigo
                        linha.Cells("descricao").Value = produto.produtos_descricao
                        linha.Cells("estoque").Value = produto.produtos_estoque
                        linha.Cells("referencia").Value = produto.Produtos_Referencia
                        linha.Cells("valorCompra").Value = produto.Produtos_Valor
                    Next
                End If
            Else
                MessageBox.Show("Digitar pelo menos dois caracteres!")
            End If

            dgvProdutoItem.Refresh()

            If dgvProdutoItem.RowCount > 0 Then
                dgvProdutoItem.Focus()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Produtos.")

        End Try
    End Sub

    Private Sub Limpar()
        txtNumero.Text = String.Empty
        txtSerie.Text = String.Empty
        txtDataEmissao.Clear()
        txtValorBaseIcms.Text = String.Empty
        txtValorBaseIcmsSubstituicao.Text = String.Empty
        txtValorIcms.Text = String.Empty
        txtValorIcmsSubstituicao.Text = String.Empty
        txtValorTotalIpi.Text = String.Empty
        txtValorTotalNota.Text = String.Empty
        txtValorTotalProdutos.Text = String.Empty

        txtChaveEletronica.Text = String.Empty
        txtDataEntrada.Text = String.Empty
        txtValorFrete.Text = String.Empty
        txtValorSeguro.Text = String.Empty
        txtValorDesconto.Text = String.Empty
        txtValorOutrasDespesas.Text = String.Empty
        txtValorAbatimento.Text = String.Empty
        txtValorTotalPis.Text = String.Empty
        txtValorPisRetidoSubstituicao.Text = String.Empty
        txtValorTotalCofins.Text = String.Empty
        txtValorCofinsRetidoSubstituicao.Text = String.Empty

        If cboFornecedor.Items.Count > 0 Then
            cboFornecedor.SelectedIndex = 0
        End If

        If cboTipoFluxo.Items.Count > 0 Then
            cboTipoFluxo.SelectedIndex = 0
        End If
        If cboTipoEmissao.Items.Count > 0 Then
            cboTipoEmissao.SelectedIndex = 0
        End If
        If cboTipo.Items.Count > 0 Then
            cboTipo.SelectedIndex = 0
        End If
        If cboSituacao.Items.Count > 0 Then
            cboSituacao.SelectedIndex = 0
        End If
        If cboTipoPagamento.Items.Count > 0 Then
            cboTipoPagamento.SelectedIndex = 0
        End If
    End Sub

    Private Sub Novo()
        Limpar()
        ConfigurarTela("i")
        fProdutoForm.nffTipoAcao = "i"
        fProdutoForm.nffNumero = String.Empty
        fProdutoForm.nffSerie = String.Empty
    End Sub

    Private Sub Selecionar()
        Dim verifica As Boolean = False

        If tipoAcao.ToLower().Equals("a") Then
            If Not String.IsNullOrEmpty(Me.numero) Then
                If Not String.IsNullOrEmpty(Me.serie) Then
                    fProdutoForm.nffNumero = numero
                    fProdutoForm.nffSerie = serie
                    fProdutoForm.nffTipoAcao = "i"
                    If mdiPrincipal.formulario IsNot Nothing Then
                        Select Case mdiPrincipal.formulario.Name
                            Case "fProdutoForm"
                                fProdutoForm.txtNotaFiscalNumero.Text = numero
                                fProdutoForm.txtNotaFiscalSerie.Text = serie
                            Case "fProdutoEntradaSaidaEstoque"
                                fProdutoEntradaSaidaEstoque.txtNotaFiscalNumero.Text = numero
                                fProdutoEntradaSaidaEstoque.txtNotaFiscalSerie.Text = serie
                        End Select
                    End If
                    verifica = True
                End If
            End If
        End If

        If verifica Then
            Me.Close()
        Else
            MessageBox.Show("É Necessário selecionar uma Nota Fiscal.", "Nota Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class