Imports ncRegras.nsFabricante
Imports ncDados.nsFabricante
Imports ncComum.nsExcecao

Public Class fFabricanteLista

  Public filtro As dFabricante

  Private Sub Cadastrar()
    mdiPrincipal.CarregarFabricanteForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarFabricanteFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvFabricante.Rows.Count > 0 Then

        indice = dgvFabricante.CurrentRow.Index

        linha = dgvFabricante.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fFabricanteForm.cid = cid

    mdiPrincipal.CarregarFabricanteForm()
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

  Private Sub fFabricanteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rFabricante
    Dim fabricantes As ColecaoFabricante
    Dim linha As DataGridViewRow

    Try

      regras = New rFabricante

      fabricantes = regras.Consultar(filtro)

      If Not IsNothing(fabricantes) Then
        For Each fabricante As dFabricante In fabricantes
          linha = dgvFabricante.Rows(dgvFabricante.Rows.Add())
          linha.Cells("cid").Value = fabricante.cid
          linha.Cells("Nome").Value = fabricante.nome
          linha.Cells("Situacao").Value = fabricante.situacao
        Next
      End If
      dgvFabricante.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta do Fabricante [" & Me.ToString() & "]")

    End Try
  End Sub

  Private Sub fFabricanteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub dgvFabricante_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFabricante.CellDoubleClick
    SelecionarItem()
  End Sub

End Class