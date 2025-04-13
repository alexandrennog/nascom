Imports ncRegras.nsCaracteristica
Imports ncDados.nsCaracteristica
Imports ncComum.nsExcecao

Public Class fCaracteristicaLista

  Public filtro As dCaracteristica

  Private Sub Cadastrar()
    mdiPrincipal.CarregarCaracteristicaForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarCaracteristicaFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvCaracteristica.Rows.Count > 0 Then

        indice = dgvCaracteristica.CurrentRow.Index

        linha = dgvCaracteristica.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fCaracteristicaForm.cid = cid

    mdiPrincipal.CarregarCaracteristicaForm()
  End Sub

  Private Sub fCaracteristicaLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

  Private Sub fCaracteristicaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rCaracteristica
    Dim caracteristicas As ColecaoCaracteristica
    Dim linha As DataGridViewRow

    Try

      regras = New rCaracteristica
      caracteristicas = regras.Consultar(filtro)

      If Not IsNothing(caracteristicas) Then
        For Each caracteristica As dCaracteristica In caracteristicas
          linha = dgvCaracteristica.Rows(dgvCaracteristica.Rows.Add())
          linha.Cells("cid").Value = caracteristica.cid
          linha.Cells("nome").Value = caracteristica.nome
          linha.Cells("situacao").Value = caracteristica.situacao
          linha.Cells("codigo").Value = caracteristica.codigo
        Next

      End If

      dgvCaracteristica.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Características.")

    End Try
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

  Private Sub dgvCaracteristica_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCaracteristica.CellDoubleClick
    SelecionarItem()
  End Sub

End Class