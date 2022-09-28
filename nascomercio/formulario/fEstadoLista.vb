Imports ncRegras.nsEstado
Imports ncDados.nsEstado
Imports ncComum.nsExcecao

Public Class fEstadoLista

  Public filtro As dEstado

  Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
    Cadastrar()
  End Sub

  Private Sub Cadastrar()
    mdiPrincipal.CarregarEstadoForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarEstadoFiltro()
  End Sub

  Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
    Filtrar()
  End Sub

  Private Sub fEstadoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
    mdiPrincipal.FecharTela()
  End Sub

  Private Sub fEstadoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rEstado
    Dim estados As ColecaoEstado
    Dim linha As DataGridViewRow

    Try

      regras = New rEstado
      estados = regras.Consultar(filtro)

      If Not IsNothing(estados) Then
        For Each estado As dEstado In estados
          linha = dgvEstado.Rows(dgvEstado.Rows.Add())
          linha.Cells("cid").Value = estado.cid
          linha.Cells("sigla").Value = estado.sigla
          linha.Cells("nome").Value = estado.nome
          linha.Cells("situacao").Value = estado.situacao
        Next
      End If

      dgvEstado.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Estados.")

    End Try
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvEstado.Rows.Count > 0 Then

        indice = dgvEstado.CurrentRow.Index

        linha = dgvEstado.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fEstadoForm.cid = cid

    mdiPrincipal.CarregarEstadoForm()
  End Sub

  Private Sub dgvEstado_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstado.CellDoubleClick
    SelecionarItem()
  End Sub

End Class