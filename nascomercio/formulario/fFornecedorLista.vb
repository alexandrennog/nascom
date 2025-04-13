Imports ncRegras.nsFornecedor
Imports ncDados.nsFornecedor
Imports ncComum.nsExcecao

Public Class fFornecedorLista

  Public filtro As dFornecedor

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fFornecedorLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rFornecedor
    Dim fornecedores As ColecaoFornecedor
    Dim linha As DataGridViewRow

    Try

      regras = New rFornecedor

      fornecedores = regras.Consultar(filtro)
      If Not IsNothing(fornecedores) Then
        For Each fornecedor As dFornecedor In fornecedores
          linha = dgvFornecedor.Rows(dgvFornecedor.Rows.Add())
          linha.Cells("cid").Value = fornecedor.cid
          linha.Cells("codigo").Value = fornecedor.codigo
          linha.Cells("nome").Value = fornecedor.nome
          linha.Cells("ddd").Value = fornecedor.ddd
          linha.Cells("telefone").Value = fornecedor.telefone
          linha.Cells("ramal").Value = fornecedor.ramal
          linha.Cells("contato").Value = fornecedor.nomeContato
          linha.Cells("situacao").Value = fornecedor.situacao
        Next
      End If

      dgvFornecedor.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Fornecedores.")

    End Try

  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarFornecedorForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarFornecedorFiltro()
  End Sub

  Private Sub fFornecedorLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvFornecedor.Rows.Count > 0 Then

        indice = dgvFornecedor.CurrentRow.Index

        linha = dgvFornecedor.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fFornecedorForm.cid = cid

    mdiPrincipal.CarregarFornecedorForm()
  End Sub

  Private Sub dgvFornecedor_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFornecedor.CellDoubleClick
    SelecionarItem()
  End Sub

End Class