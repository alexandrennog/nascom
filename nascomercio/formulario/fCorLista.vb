Imports ncRegras.nsCor
Imports ncDados.nsCor
Imports ncComum.nsExcecao

Public Class fCorLista

  Public filtro As dCor

  Private Sub Cadastrar()
    mdiPrincipal.CarregarCorForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarCorFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvCor.Rows.Count > 0 Then

        indice = dgvCor.CurrentRow.Index

        linha = dgvCor.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fCorForm.cid = cid

    mdiPrincipal.CarregarCorForm()
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

  Private Sub fCorLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rCor
    Dim Cors As ColecaoCor
    Dim linha As DataGridViewRow

    Try

      regras = New rCor

      Cors = regras.Consultar(filtro)

      If Not IsNothing(Cors) Then
        For Each Cor As dCor In Cors
          linha = dgvCor.Rows(dgvCor.Rows.Add())
          linha.Cells("cid").Value = Cor.cid
          linha.Cells("Nome").Value = Cor.nome
          linha.Cells("Situacao").Value = Cor.situacao
        Next
      End If
      dgvCor.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Cor [" & Me.ToString() & "]")

    End Try
  End Sub

  Private Sub fCorLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub dgvCor_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCor.CellDoubleClick
    SelecionarItem()
  End Sub

End Class