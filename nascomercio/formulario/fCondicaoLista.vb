Imports ncRegras.nsCondicao
Imports ncDados.nsCondicao
Imports ncComum.nsExcecao

Public Class fCondicaoLista

  Public filtro As dCondicao

  Private Sub Cadastrar()
    mdiPrincipal.CarregarCondicaoForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarCondicaoFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvCondicao.Rows.Count > 0 Then

        indice = dgvCondicao.CurrentRow.Index

        linha = dgvCondicao.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fCondicaoForm.cid = cid

    mdiPrincipal.CarregarCondicaoForm()
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

  Private Sub fCondicaoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rCondicao
    Dim Condicaos As ColecaoCondicao
    Dim linha As DataGridViewRow

    Try

      regras = New rCondicao

      Condicaos = regras.Consultar(filtro)

      If Not IsNothing(Condicaos) Then
        For Each Condicao As dCondicao In Condicaos
          linha = dgvCondicao.Rows(dgvCondicao.Rows.Add())
          linha.Cells("cid").Value = Condicao.cid
          linha.Cells("Nome").Value = Condicao.nome
          linha.Cells("desconto").Value = Condicao.desconto
          linha.Cells("Situacao").Value = Condicao.situacao
        Next
      End If
      dgvCondicao.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Condicao [" & Me.ToString() & "]")

    End Try
  End Sub

  Private Sub fCondicaoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub dgvCondicao_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCondicao.CellDoubleClick
    SelecionarItem()
  End Sub

End Class