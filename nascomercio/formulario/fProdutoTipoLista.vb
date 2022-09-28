Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao

Public Class fProdutoTipoLista

  Public filtro As dProdutoTipo

  Private Sub Cadastrar()
    mdiPrincipal.CarregarProdutoTipoForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarProdutoTipoFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvProdutoTipo.Rows.Count > 0 Then

        indice = dgvProdutoTipo.CurrentRow.Index

        linha = dgvProdutoTipo.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fProdutoTipoForm.cid = cid

    mdiPrincipal.CarregarProdutoTipoForm()
  End Sub

  Private Sub fProdutoTipoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        mdiPrincipal.FecharTela()
      Case Keys.F5
        Cadastrar()
      Case Keys.F6
        Filtrar()
      Case Keys.Enter
        SelecionarItem()
    End Select
  End Sub

  Private Sub dgvProdutoTipo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProdutoTipo.CellDoubleClick
    SelecionarItem()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fProdutoTipoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rProdutoTipo
    Dim tipoProdutos As ColecaoProdutoTipo
    Dim linha As DataGridViewRow

    Try

      regras = New rProdutoTipo

      tipoProdutos = regras.Consultar(filtro)
      For Each tipoProduto As dProdutoTipo In tipoProdutos
        linha = dgvProdutoTipo.Rows(dgvProdutoTipo.Rows.Add())
        linha.Cells("cid").Value = tipoProduto.cid
        linha.Cells("nome").Value = tipoProduto.nome
        linha.Cells("situacao").Value = tipoProduto.situacao
      Next
      dgvProdutoTipo.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Tipos de Produto.")

    End Try
  End Sub

End Class