Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes.cFuncoes

Public Class fProdutoLista

  Public filtro As dProduto

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    If Me.Modal Then
      Me.filtro.codigo = ""
      Me.Close()
    Else
      mdiPrincipal.FecharTela()
    End If
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        If Me.Modal Then
          Me.filtro.codigo = ""
          Me.Close()
        Else
          mdiPrincipal.FecharTela()
        End If
      Case Keys.F5
        Cadastrar()
      Case Keys.F6
        Filtrar()
      Case Keys.Enter
        SelecionarItem()
    End Select
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarProdutoForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarProdutoFiltro()
  End Sub

  Private Sub fProdutoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rProduto
    Dim produtos As ColecaoProduto
    Dim linha As DataGridViewRow

    Try

      regras = New rProduto

      produtos = regras.Consultar(filtro)
      If Not IsNothing(produtos) Then
        For Each produto As dProduto In produtos
          linha = dgvProduto.Rows(dgvProduto.Rows.Add())
          linha.Cells("cid").Value = produto.cid
          linha.Cells("codigo").Value = produto.codigo
          linha.Cells("descricao").Value = produto.descricao
          linha.Cells("referencia").Value = produto.referencia
          linha.Cells("valorCompra").Value = RetornarTexto(produto.valorCompra)
          linha.Cells("valorVenda").Value = RetornarTexto(produto.valorVenda)
          linha.Cells("cor").Value = RetornarTexto(produto.cor)
          linha.Cells("situacao").Value = produto.situacao
        Next
      End If
      dgvProduto.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Produtos.")

    End Try
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)
    Dim codigo As String = ""

    Try
      If dgvProduto.Rows.Count > 0 Then

        indice = dgvProduto.CurrentRow.Index

        linha = dgvProduto.Rows(indice)

        cid = linha.Cells("cid").Value
        codigo = linha.Cells("codigo").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    If Me.Modal Then
      Me.filtro.cid = cid
      Me.filtro.codigoBarras = codigo
      Me.Close()
    Else
      fProdutoForm.cid = cid
      mdiPrincipal.CarregarProdutoForm()
    End If
  End Sub

  Private Sub dgvProduto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProduto.CellDoubleClick
    SelecionarItem()
  End Sub
End Class