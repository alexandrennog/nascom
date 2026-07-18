Imports ncRegras.nsEmpresa
Imports ncDados.nsEmpresa
Imports ncComum.nsExcecao

Public Class fEmpresaLista

  Public filtro As dEmpresa

  Private Sub Cadastrar()
    mdiPrincipal.CarregarEmpresaForm()
  End Sub

  Private Sub Filtrar()
    mdiPrincipal.CarregarEmpresaFiltro()
  End Sub

  Private Sub SelecionarItem()
    Dim indice As Integer
    Dim linha As DataGridViewRow
    Dim cid As Nullable(Of Integer)

    Try
      If dgvEmpresa.Rows.Count > 0 Then

        indice = dgvEmpresa.CurrentRow.Index

        linha = dgvEmpresa.Rows(indice)

        cid = linha.Cells("cid").Value

      End If
    Catch ex As Exception

      cid = Nothing

    End Try

    fEmpresaForm.cid = cid

    mdiPrincipal.CarregarEmpresaForm()
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

  Private Sub fEmpresaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim regras As rEmpresa
    Dim empresas As ColecaoEmpresa
    Dim linha As DataGridViewRow

    Try

      regras = New rEmpresa

      empresas = regras.Consultar(filtro)

      If Not IsNothing(empresas) Then
        For Each empresa As dEmpresa In empresas
          linha = dgvEmpresa.Rows(dgvEmpresa.Rows.Add())
          linha.Cells("cid").Value = empresa.cid
          linha.Cells("RazaoSocial").Value = empresa.razaoSocial
          linha.Cells("Cnpj").Value = empresa.cnpj
          linha.Cells("Uf").Value = empresa.uf
        Next
      End If
      dgvEmpresa.Refresh()

    Catch nex As ExcecaoNascomercio

      MessageBox.Show(nex.Message)

    Catch ex As Exception

      MessageBox.Show("Erro na consulta da Empresa [" & Me.ToString() & "]")

    End Try
  End Sub

  Private Sub fEmpresaLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

  Private Sub dgvEmpresa_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmpresa.CellDoubleClick
    SelecionarItem()
  End Sub

End Class
