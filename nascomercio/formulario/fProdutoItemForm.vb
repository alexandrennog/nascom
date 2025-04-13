Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsCaracteristica
Imports ncRegras.nsCaracteristica
Imports ncComum.nsExcecao

Public Class fProdutoItemForm

  Public produto As dProduto
  Public produtoTipo_cid As Integer
  Private colecaoProdutoTipoCaracteristica As ColecaoProdutoTipoCaracteristica

  Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
    Salvar()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
    IncluirItem()
  End Sub

  Private Sub fProdutoItemForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
      Case Keys.Enter
        Salvar()
      Case Keys.F1
        IncluirItem()
      Case Keys.F2
        ExcluirItem()
    End Select
  End Sub

  Private Sub Salvar()
    Dim linha As DataGridViewRow
    Dim celula As DataGridViewCell
    Dim novaLinha As DataGridViewRow
    Dim novaCelula As DataGridViewTextBoxCell

    Try

      If dgvItem.Rows.Count > 0 Then
        For Each linha In Me.dgvItem.Rows
          novaLinha = New DataGridViewRow()

          For Each celula In linha.Cells
            novaCelula = New DataGridViewTextBoxCell()
            novaCelula.Value = celula.Value
            novaLinha.Cells.Add(novaCelula)
          Next

          fProdutoForm.dgvProduto.Rows.Add(novaLinha)
          fProdutoForm.dgvProduto.Refresh()
        Next
      End If

      Me.Close()

    Catch ex As Exception

      MessageBox.Show("Erro na inclusão dos itens de Produto.")

    End Try
  End Sub

  Private Sub IncluirItem()
    If dgvItem.Columns.Count > 0 Then
      dgvItem.Rows.Add()

      dgvItem.Refresh()
    End If
  End Sub

  Private Sub fProdutoItemForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LimparCampos()
    CarregarProduto()
    CarregarProdutoItem()
    CarregarProdutoTipoCaracteristica()
    MontarGradeCaracteristicas()
  End Sub

  Private Sub LimparCampos()
    dgvItem.Rows.Clear()
    dgvItem.Columns.Clear()
    dgvItem.Refresh()
  End Sub

  Private Sub CarregarProduto()
    If Not produto Is Nothing Then
      txtCID.Text = produto.cid.ToString()
      txtDescricao.Text = produto.descricao
    End If
  End Sub

  Private Sub CarregarProdutoItem()
    Dim regras As rProdutoTipo
    Dim dados As dProdutoTipo

    Try

      If Not produto Is Nothing Then
        regras = New rProdutoTipo()
        dados = New dProdutoTipo()

        dados = regras.Consultar(Me.produtoTipo_cid)

        txtTipo.Text = dados.nome
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Tipo de Produto.")

    End Try
  End Sub

  Private Sub CarregarProdutoTipoCaracteristica()
    Dim regras As rProdutoTipoCaracteristica

    Try

      If Not produto Is Nothing Then
        If Not Me.produtoTipo_cid.Equals(Nothing) Then
          regras = New rProdutoTipoCaracteristica()

          colecaoProdutoTipoCaracteristica = regras.ConsultarPorProdutoTipo(Me.produtoTipo_cid)
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
            coluna.Tag = item.caracteristica_codigo

            colecaoCaracteristicaItem = regraCaracteristicaItem.ConsultarPorCaracteristica(item.caracteristica_cid)
            If Not colecaoCaracteristicaItem Is Nothing Then
              coluna.DisplayMember = "valor"
              coluna.DataSource = colecaoCaracteristicaItem
            End If

            dgvItem.Columns.Add(coluna)
          Else
            Dim coluna As DataGridViewTextBoxColumn

            coluna = New DataGridViewTextBoxColumn()

            coluna.Name = item.caracteristica_nome
            coluna.Tag = item.caracteristica_codigo

            dgvItem.Columns.Add(coluna)
          End If
        Next

        dgvItem.Refresh()
      End If

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta dos dados de Itens de Características.")

    End Try
  End Sub

  Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
    ExcluirItem()
  End Sub

  Private Sub ExcluirItem()
    If dgvItem.Rows.Count > 0 Then
      dgvItem.Rows.RemoveAt(dgvItem.CurrentRow.Index)
    End If
  End Sub

End Class
