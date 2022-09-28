Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncDados.nsLoja
Imports ncRegras.nsLoja
Imports ncComum.nsFuncoes
Imports ncComum.nsLog.cLog
Imports ncComum.nsExcecao

Public Class fProdutoEntradaSaidaTransferencia

  Public produto_cid As Integer
  Public produto As dProduto
  Private colecaoProdutoTipoCaracteristica As ColecaoProdutoTipoCaracteristica

  Private Sub fProdutoEntradaSaidaTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        CarregarProdutoEntradaSaidaFiltro()
      Case Keys.Enter
        ValidarTransferencia()
      Case Keys.F6
        CarregarProdutoEntradaSaidaEstoque()
      Case Keys.F8
        CarregarProdutoBalancoFiltro()
    End Select
  End Sub

  Private Sub fProdutoEntradaSaidaTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CarregarProduto()
    CarregarProdutoTipoCaracteristica()
    MontarGradeCaracteristicas()
    CarregarItens()
    CarregarComboLojaOrigem()
    CarregarComboLojaDestino()
    ExibirInformacoesTela()
  End Sub

  Private Sub btoFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFechar.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
    CarregarProdutoEntradaSaidaFiltro()
  End Sub

  Private Sub btoEstoque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEstoque.Click
    CarregarProdutoEntradaSaidaEstoque()
  End Sub

  Private Sub btoTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoTransferir.Click
    ValidarTransferencia()
  End Sub

  Private Sub ValidarTransferencia()
    Try
      If cboOrigem.SelectedValue Is Nothing Then
        MessageBox.Show("Selecione a loja origem", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If cboOrigem.SelectedValue.ToString().Trim().Equals(String.Empty) Then
        MessageBox.Show("Selecione a loja origem", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If cboDestino.SelectedValue Is Nothing Then
        MessageBox.Show("Selecione a loja destino", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If cboDestino.SelectedValue.ToString().Trim().Equals(String.Empty) Then
        MessageBox.Show("Selecione a loja destino", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If cboOrigem.SelectedValue = cboDestino.SelectedValue Then
        MessageBox.Show("A loja origem deve ser diferente da loja destino", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If MessageBox.Show("Confirma transferência de produto?", "Transferência", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
        Transferir()
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub CarregarProdutoEntradaSaidaFiltro()
    mdiPrincipal.CarregarProdutoEntradaSaidaFiltro()
  End Sub

  Private Sub CarregarProdutoEntradaSaidaEstoque()
    fProdutoEntradaSaidaEstoque.produto_cid = Me.produto_cid
    mdiPrincipal.CarregarProdutoEntradaSaidaEstoque()
  End Sub

  Private Sub Transferir()
    Dim linha As DataGridViewRow
    Dim regraC As rCaracteristica
    Dim dadosC As dCaracteristica
    Dim regraPI As rProdutoItem
    Dim origemCID As Integer
    Dim origemRazao As String
    Dim destinoCID As Integer
    Dim destinoRazao As String
    Dim usuarioCID As Integer
    Dim usuarioNome As String
    Dim produtoCID As Integer
    Dim codigoBarras As String = ""
    Dim quantidade As Decimal

        Try

      If dgvProduto.Rows.Count > 0 Then
        If dgvProduto.CurrentRow.Index >= 0 Then

          linha = dgvProduto.CurrentRow

          origemCID = Convert.ToInt32(cboOrigem.SelectedValue)
          origemRazao = cboOrigem.Text
          destinoCID = Convert.ToInt32(cboDestino.SelectedValue)
          destinoRazao = cboDestino.Text
          usuarioCID = mdiPrincipal.gUsuario.cid
          usuarioNome = mdiPrincipal.gUsuario.nomeCompleto

          produtoCID = Me.produto_cid
          quantidade = Convert.ToInt32(txtQuantidade.Text)

          regraC = New rCaracteristica()
          regraPI = New rProdutoItem()

          dadosC = regraC.ConsultarPorCodigo("codigoBarras")

          If Not dadosC Is Nothing Then
            For Each celula As DataGridViewCell In linha.Cells
              If celula.OwningColumn.Tag.ToString().Equals(dadosC.cid.ToString()) Then
                codigoBarras = celula.Value.ToString()
                Exit For
              End If
            Next

            If Not String.IsNullOrEmpty(codigoBarras) Then

              regraPI.AlterarEstoque(codigoBarras, (quantidade * -1))

              GravarLogTransferencia(origemCID, origemRazao, destinoCID, destinoRazao, usuarioCID, usuarioNome, _
                  produtoCID, codigoBarras, quantidade)

              MontarGradeCaracteristicas()
              CarregarItens()

              MessageBox.Show("Tranferência realizada com sucesso!")

            End If
          End If
        End If
      End If

      Limpar()

    Catch ex As Exception

      MessageBox.Show("Não foi possível realizar a transferência", "Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Try

  End Sub
  Private Sub ExibirInformacoesTela()
    If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
      btoBalanco.Visible = False
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

                        If (coluna.Tag.ToString().Equals(item.caracteristicas_cid.ToString())) And _
                            (item.item.Equals(itemQtde.item)) Then
                          novaCelula = New DataGridViewTextBoxCell()
                          novaCelula.Value = item.valor
                          novaLinha.Cells.Add(novaCelula)
                          existe = True
                          Exit For
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

    dgvProduto.Rows.Clear()
    dgvProduto.Columns.Clear()
    dgvProduto.Refresh()

    If Not colecaoProdutoTipoCaracteristica Is Nothing Then

      For Each item In colecaoProdutoTipoCaracteristica
        If item.quantidade.Equals(Nothing) Then
          qtde = 0
        Else
          qtde = item.quantidade
        End If

        coluna = New DataGridViewTextBoxColumn()
        coluna.Name = item.caracteristica_nome
        coluna.Tag = item.caracteristica_cid.ToString()

        If qtde > 0 Then
          coluna.ReadOnly = True
        End If

        dgvProduto.Columns.Add(coluna)
      Next

      dgvProduto.Refresh()
    End If
  End Sub

  Private Sub CarregarComboLojaOrigem()
    Dim regras As rLoja
    Dim colecao As ColecaoLoja

    Try

      cboOrigem.Items.Clear()

      regras = New rLoja()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dLoja())

        cboOrigem.ValueMember = "cid"
        cboOrigem.DisplayMember = "razaoSocial"
        cboOrigem.DataSource = colecao
        cboOrigem.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Loja.")

    End Try
  End Sub

  Private Sub CarregarComboLojaDestino()
    Dim regras As rLoja
    Dim colecao As ColecaoLoja

    Try

      cboDestino.Items.Clear()

      regras = New rLoja()
      colecao = regras.Listar()

      If Not colecao Is Nothing Then
        colecao.Insert(0, New dLoja())

        cboDestino.ValueMember = "cid"
        cboDestino.DisplayMember = "razaoSocial"
        cboDestino.DataSource = colecao
        cboDestino.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Loja.")

    End Try
  End Sub

  Private Sub Limpar()

    If cboOrigem.Items.Count > 0 Then
      cboOrigem.SelectedIndex = 0
    End If
    If cboDestino.Items.Count > 0 Then
      cboDestino.SelectedIndex = 0
    End If
    txtQuantidade.Text = ""

  End Sub

  Private Sub btoBalanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBalanco.Click
    CarregarProdutoBalancoFiltro()
  End Sub

  Private Sub CarregarProdutoBalancoFiltro()
    mdiPrincipal.CarregarProdutoBalancoFiltro()
  End Sub

End Class