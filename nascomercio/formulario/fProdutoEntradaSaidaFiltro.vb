Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fProdutoEntradaSaidaFiltro

    Private Sub fProdutoEntradaSaidaFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimparCampos()
        CarregarComboProdutoTipo()
        CarregarComboFornecedor()
        CarregarComboFabricante()
        ExibirInformacoesTela()
    End Sub
    Private Sub ExibirInformacoesTela()
        If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
            btoBalanco.Visible = False
        End If
    End Sub
    Private Sub LimparCampos()
        txtCodigo.Text = String.Empty
        txtReferencia.Text = String.Empty
        txtDescricao.Text = String.Empty
        cboFornecedor.Items.Clear()
        cboFabricante.Items.Clear()
        cboTipo.Items.Clear()
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

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim filtro As dProduto

        filtro = New dProduto

        filtro.codigo = cFuncoes.TratarTexto(txtCodigo.Text)
        filtro.referencia = cFuncoes.TratarTexto(txtReferencia.Text)
        filtro.descricao = cFuncoes.TratarTexto(txtDescricao.Text)
        filtro.produtoTipo_cid = cFuncoes.TratarInteiro(cboTipo.SelectedValue)
        filtro.fornecedor_cid = cFuncoes.TratarInteiro(cboFornecedor.SelectedValue)
        filtro.fabricante_cid = cFuncoes.TratarInteiro(cboFabricante.SelectedValue)
        filtro.codigoBarras = cFuncoes.TratarTexto(txtCodigoBarras.Text)

        fProdutoEntradaSaidaLista.filtro = filtro

        mdiPrincipal.CarregarProdutoEntradaSaidaLista()
    End Sub

    Private Sub fProdutoEntradaSaidaFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.Enter
                Pesquisar()
            Case Keys.F8
                CarregarProdutoBalancoFiltro()
        End Select
    End Sub

    Private Sub btoBalanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBalanco.Click
        CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub CarregarProdutoBalancoFiltro()
        mdiPrincipal.CarregarProdutoBalancoFiltro()
    End Sub

End Class