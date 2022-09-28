Imports ncRegras.nsUsuarioPerfil
Imports ncDados.nsUsuarioPerfil
Imports ncComum.nsExcecao

Public Class fUsuarioPerfilLista

  Public filtro As dUsuarioPerfil

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarUsuarioPerfilForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarUsuarioPerfilFiltro()
  End Sub

  Private Sub fUsuarioPerfilLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub fUsuarioPerfilLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rUsuarioPerfil
    Dim perfis As ColecaoUsuarioPerfil
    Dim linha As DataGridViewRow

    Try

      regras = New rUsuarioPerfil

      perfis = regras.Consultar(filtro)
      If Not IsNothing(perfis) Then
        For Each perfil As dUsuarioPerfil In perfis
          linha = dgvUsuarioPerfil.Rows(dgvUsuarioPerfil.Rows.Add())
          linha.Cells("cid").Value = perfil.cid
          linha.Cells("codigo").Value = perfil.codigo
          linha.Cells("nome").Value = perfil.nome
          linha.Cells("situacao").Value = perfil.situacao
        Next
      End If

      dgvUsuarioPerfil.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Fabricantes.")

    End Try
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvUsuarioPerfil.Rows.Count > 0 Then

        indice = dgvUsuarioPerfil.CurrentRow.Index

        linha = dgvUsuarioPerfil.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fUsuarioPerfilForm.cid = cid

    mdiPrincipal.CarregarUsuarioPerfilForm()
  End Sub

  Private Sub dgvUsuarioPerfil_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarioPerfil.CellDoubleClick
    SelecionarItem()
  End Sub

End Class
