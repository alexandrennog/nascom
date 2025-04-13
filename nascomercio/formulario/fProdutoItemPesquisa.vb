Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao

Public Class fProdutoItemPesquisa

    Public filtro As dProduto

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        If Validar() = True Then
            Pesquisar()
        Else
            MessageBox.Show("É necessário preencher pelo menos um campo.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim retorno As Boolean = False

        If Not txtDescricao.Text.Trim().Equals(String.Empty) Then
            retorno = True
        End If

        If Not txtCodigoBarras.Text.Trim().Equals(String.Empty) Then
            retorno = True
        End If

        If Not txtReferencia.Text.Trim().Equals(String.Empty) Then
            retorno = True
        End If

        Validar = retorno
    End Function

    Private Sub Pesquisar()
        Dim regras As rProdutoItem
        Dim produtos As ColecaoProdutoItem
        Dim linha As DataGridViewRow

        Try

            dgvProdutoItem.DataSource = Nothing
            dgvProdutoItem.Rows.Clear()
            dgvProdutoItem.Refresh()

            regras = New rProdutoItem

            If txtDescricao.Text.Trim().Length > 1 Or txtCodigoBarras.Text.Trim().Length > 1 Or txtReferencia.Text.Trim().Length > 1 Then
                produtos = regras.ConsultarProdutoItem(txtDescricao.Text, txtCodigoBarras.Text, txtReferencia.Text, chkEstoque.Checked)
                If Not IsNothing(produtos) Then
                    For Each produto As dProdutoItem In produtos
                        linha = dgvProdutoItem.Rows(dgvProdutoItem.Rows.Add())
                        linha.Cells("produtos_cid").Value = produto.produtos_cid
                        linha.Cells("valor").Value = produto.valor
                        linha.Cells("descricao").Value = produto.produtos_descricao
                        linha.Cells("estoque").Value = produto.produtos_estoque
                        linha.Cells("referencia").Value = produto.Produtos_Referencia
                        linha.Cells("cor").Value = produto.Produtos_Cor
                        linha.Cells("tamanho").Value = produto.Produtos_Tamanho
                        linha.Cells("valorvenda").Value = produto.Produtos_ValorVenda
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

    Private Sub fProdutoItemPesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                If dgvProdutoItem.Rows.Count > 0 Then
                    SelecionarItem()
                Else
                    Pesquisar()
                End If
        End Select
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub


    Private Sub dgvProdutoItem_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProdutoItem.CellDoubleClick
        SelecionarItem()
    End Sub


    Private Sub SelecionarItem()
        Dim cid As Nullable(Of Integer)
        Dim codigo As String = ""

        Try
            If dgvProdutoItem.Rows.Count > 0 Then

                cid = dgvProdutoItem.CurrentRow.Cells("produtos_cid").Value
                codigo = dgvProdutoItem.CurrentRow.Cells("valor").Value

            End If
        Catch ex As Exception
            cid = Nothing
            codigo = ""
        End Try

        Me.filtro = New dProduto
        Me.filtro.cid = cid
        Me.filtro.codigoBarras = codigo
        Me.Close()

    End Sub

    Private Sub dgvProdutoItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProdutoItem.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                SelecionarItem()
        End Select

    End Sub

    Private Sub fProdutoItemPesquisa_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        txtCodigoBarras.Focus()
    End Sub
End Class