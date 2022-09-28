Imports ncRegras.nsGrupo
Imports ncDados.nsGrupo
Imports ncComum.nsExcecao

Public Class fGrupoLista

  Public filtro As dGrupo

  Private Sub Cadastrar()
    mdiPrincipal.CarregarGrupoForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarGrupoFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvGrupo.Rows.Count > 0 Then

        indice = dgvGrupo.CurrentRow.Index

        linha = dgvGrupo.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fGrupoForm.cid = cid

    mdiPrincipal.CarregarGrupoForm()
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

  Private Sub fGrupoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rGrupo
    Dim Grupos As ColecaoGrupo
    Dim linha As DataGridViewRow

    Try

      regras = New rGrupo

      Grupos = regras.Consultar(filtro)

      If Not IsNothing(Grupos) Then
        For Each Grupo As dGrupo In Grupos
          linha = dgvGrupo.Rows(dgvGrupo.Rows.Add())
          linha.Cells("cid").Value = Grupo.cid
          linha.Cells("Nome").Value = Grupo.nome
          linha.Cells("Situacao").Value = Grupo.situacao
        Next
      End If
      dgvGrupo.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Grupo [" & Me.ToString() & "]")

    End Try
  End Sub

  Private Sub fGrupoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub dgvGrupo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrupo.CellDoubleClick
    SelecionarItem()
  End Sub

End Class