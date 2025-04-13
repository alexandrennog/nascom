Imports ncRegras.nsLoja
Imports ncDados.nsLoja
Imports ncComum.nsExcecao

Public Class fFechamento

  Public filtro As dLoja

  Private Sub Cadastrar()
    mdiPrincipal.CarregarLojaForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarLojaFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvLoja.Rows.Count > 0 Then

        indice = dgvLoja.CurrentRow.Index

        linha = dgvLoja.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fLojaForm.cid = cid

    mdiPrincipal.CarregarLojaForm()
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

  Private Sub fLojaLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

  Private Sub fLojaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rLoja
    Dim lojas As ColecaoLoja
    Dim linha As DataGridViewRow

    Try

      regras = New rLoja

      lojas = regras.Consultar(filtro)

      If Not IsNothing(lojas) Then
        For Each loja As dLoja In lojas
          linha = dgvLoja.Rows(dgvLoja.Rows.Add())
          linha.Cells("cid").Value = loja.cid
          linha.Cells("codigo").Value = loja.codigo
          linha.Cells("nome").Value = loja.nomeFantasia
          linha.Cells("ddd").Value = loja.ddd
          linha.Cells("telefone").Value = loja.telefone
          linha.Cells("ramal").Value = loja.ramal
          linha.Cells("contato").Value = loja.nomeContato
          linha.Cells("situacao").Value = loja.situacao
        Next
      End If

      dgvLoja.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da lista de Lojas.")

    End Try
  End Sub

  Private Sub dgvLoja_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoja.CellDoubleClick
    SelecionarItem()
  End Sub

End Class