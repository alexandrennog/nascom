Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsCor
Imports ncRegras.nsCor
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fProdutoFiltro

  Private colecaoProdutoTipoCaracteristica As ColecaoProdutoTipoCaracteristica

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    Pesquisar()
  End Sub

  Private Sub fProdutoFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.F6
        ImprimirEtiquetaES()
      Case Keys.F7
        CarregarFornecedorFiltro()
      Case Keys.F8
        CarregarFabricanteFiltro()
      Case Keys.Enter
        Pesquisar()
    End Select
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarProdutoForm()
  End Sub

  Private Sub Pesquisar()
    Dim filtro As dProduto

    filtro = New dProduto

    filtro.codigo = cFuncoes.TratarTexto(txtCodigo.Text)
    filtro.referencia = cFuncoes.TratarTexto(txtReferencia.Text)
    filtro.descricao = cFuncoes.TratarTexto(txtDescricao.Text)
    filtro.valorCompra = cFuncoes.TratarDecimal(txtValorCompra.Text)
    filtro.valorVenda = cFuncoes.TratarDecimal(txtValorVenda.Text)
    filtro.produtoTipo_cid = cFuncoes.TratarInteiro(cboTipo.SelectedValue)
    filtro.fornecedor_cid = cFuncoes.TratarInteiro(cboFornecedor.SelectedValue)
    filtro.fabricante_cid = cFuncoes.TratarInteiro(cboFabricante.SelectedValue)
    filtro.cor_cid = cFuncoes.TratarInteiro(cboCor.SelectedValue)
    filtro.grupo_cid = cFuncoes.TratarInteiro(cboGrupo.SelectedValue)
    filtro.estoqueMinimo = cFuncoes.TratarInteiro(txtEstoqueMinimo.Text)
    filtro.aliquota = cFuncoes.TratarTexto(txtAliquota.Text)

    fProdutoLista.filtro = filtro

    mdiPrincipal.CarregarProdutoLista()
  End Sub

  Private Sub cboTipo_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectionChangeCommitted
    CarregarProdutoTipoCaracteristica()
    MontarGradeCaracteristicas()
  End Sub

  Private Sub CarregarProdutoTipoCaracteristica()
    Dim regras As rProdutoTipoCaracteristica

    Try

      colecaoProdutoTipoCaracteristica = Nothing

      If cboTipo.Items.Count > 0 Then
        If Not cboTipo.SelectedIndex.Equals(0) Then
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
        Dim colecaoCaracteristicaItem As ColecaoCaracteristicaItem
        Dim regraCaracteristicaItem As rCaracteristicaItem
        Dim qtde As Integer

        Try

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

                    If qtde > 0 Then
                        Dim coluna As DataGridViewComboBoxColumn

                        coluna = New DataGridViewComboBoxColumn()
                        coluna.Name = item.caracteristica_nome

                        colecaoCaracteristicaItem = regraCaracteristicaItem.ConsultarPorCaracteristica(item.caracteristica_cid)
                        If Not colecaoCaracteristicaItem Is Nothing Then
                            coluna.DisplayMember = "valor"
                            coluna.DataSource = colecaoCaracteristicaItem
                        End If

                        colecaoCaracteristicaItem.Insert(0, New dCaracteristicaItem())

                        dgvProduto.Columns.Add(coluna)
                    Else
                        Dim coluna As DataGridViewTextBoxColumn

                        coluna = New DataGridViewTextBoxColumn()

                        coluna.Name = item.caracteristica_nome

                        dgvProduto.Columns.Add(coluna)
                    End If
                Next

                dgvProduto.Refresh()
            End If

            If dgvProduto.Columns.Count > 0 Then
                dgvProduto.Rows.Add()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Características de Tipo de Produto.")

        End Try
    End Sub

    Private Sub fProdutoFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LimparCampos()
        CarregarComboSituacao()
        CarregarComboProdutoTipo()
        CarregarComboFornecedor()
        CarregarComboFabricante()
        CarregarComboCor()
        CarregarComboGrupo()
        CarregarProdutoTipoCaracteristica()
        MontarGradeCaracteristicas()
    End Sub

    Private Sub LimparCampos()
        txtCodigo.Text = String.Empty
        txtReferencia.Text = String.Empty
        txtEstoqueMinimo.Text = String.Empty
        txtAliquota.Text = String.Empty
        txtDescricao.Text = String.Empty
        txtValorCompra.Text = String.Empty
        txtValorVenda.Text = String.Empty
        cboFornecedor.Items.Clear()
        cboFabricante.Items.Clear()
        cboGrupo.Items.Clear()
        cboCor.Items.Clear()
        cboTipo.Items.Clear()
        cboSituacao.Items.Clear()
        colecaoProdutoTipoCaracteristica = Nothing
    End Sub

    Private Sub CarregarComboProdutoTipo()
        Dim regras As rProdutoTipo
        Dim colecao As ColecaoProdutoTipo

        Try

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

    Private Sub CarregarComboGrupo()
        Dim regras As rGrupo
        Dim colecao As ColecaoGrupo

        Try

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

    Private Sub CarregarComboCor()
        Dim regras As rCor
        Dim colecao As ColecaoCor

        Try

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

    Private Sub CarregarComboSituacao()
        Dim regras As rSituacao
        Dim colecao As ColecaoSituacao

        Try

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

    Private Sub CarregarFabricanteFiltro()
        mdiPrincipal.CarregarFabricanteFiltro()
    End Sub

    Private Sub CarregarFornecedorFiltro()
        mdiPrincipal.CarregarFornecedorFiltro()
    End Sub

    Private Sub btoFornecedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFornecedores.Click
        CarregarFornecedorFiltro()
    End Sub

    Private Sub btoFabricantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFabricantes.Click
        CarregarFabricanteFiltro()
    End Sub

    Private Sub ImprimirEtiquetaES()
        fProdutoEtiquetaES.ShowDialog(mdiPrincipal)
    End Sub

  Private Sub btoEtiquetaES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEtiquetaES.Click
    ImprimirEtiquetaES()
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

    Private Sub btoNF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoNF.Click
        mdiPrincipal.CarregarNotaFiscalFornecedorLista(Nothing)
    End Sub

    Private Sub dgvProduto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProduto.CellContentClick

    End Sub
End Class