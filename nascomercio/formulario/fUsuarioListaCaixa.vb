Imports ncRegras.nsUsuario
Imports ncDados.nsUsuario
Imports ncComum.nsExcecao

Public Class fUsuarioListaCaixa

  Public filtro As dUsuario

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    SelecionarItem()
  End Sub

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Cadastrar()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarUsuarioFiltro()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarUsuarioForm()
  End Sub

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    Me.Close()
  End Sub

  Private Sub fUsuarioLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyCode
      Case Keys.Escape
        Me.Close()
      Case Keys.F5
        Cadastrar()
      Case Keys.F6
        Filtrar()
      Case Keys.Enter
        SelecionarItem()
    End Select
  End Sub

  Private Sub fUsuarioLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rUsuario
    Dim usuarios As ColecaoUsuario
    Dim linha As DataGridViewRow

    Try

      regras = New rUsuario

      usuarios = regras.Consultar(filtro)
      If Not IsNothing(usuarios) Then
        For Each usuario As dUsuario In usuarios
          linha = dgvUsuario.Rows(dgvUsuario.Rows.Add())
          linha.Cells("cid").Value = usuario.cid
          linha.Cells("usuario").Value = usuario.usuario
          linha.Cells("nome").Value = usuario.nomeCompleto
          linha.Cells("situacao").Value = usuario.situacao
        Next
      End If
      dgvUsuario.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Usuários.")

    End Try
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow

    Try
      If dgvUsuario.Rows.Count > 0 Then

        indice = dgvUsuario.CurrentRow.Index

        linha = dgvUsuario.Rows(indice)

        Me.filtro.cid = linha.Cells("cid").Value
        Me.filtro.usuario = linha.Cells("usuario").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    Me.Close()

  End Sub

  Private Sub dgvUsuario_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuario.CellDoubleClick
    SelecionarItem()
  End Sub

End Class