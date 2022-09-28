Imports ncRegras.nsCategoria
Imports ncDados.nsCategoria
Imports ncComum.nsExcecao

Public Class fCategoriaLista

    Public filtro As dCategoria

    Private Sub Cadastrar()
        mdiPrincipal.CarregarCategoriaForm()
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarCategoriaFiltro()
    End Sub

    Private Sub SelecionarItem()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim cid As Nullable(Of Integer)

        Try
            If dgvCategoria.Rows.Count > 0 Then

                indice = dgvCategoria.CurrentRow.Index

                linha = dgvCategoria.Rows(indice)

                cid = linha.Cells("cid").Value

            End If
        Catch ex As Exception

            cid = Nothing

        End Try

        fCategoriaForm.cid = cid

        mdiPrincipal.CarregarCategoriaForm()
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

    Private Sub fCategoriaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim regras As rCategoria
        Dim Categorias As ColecaoCategoria
        Dim linha As DataGridViewRow

        Try

            regras = New rCategoria

            Categorias = regras.Consultar(filtro)

            If Not IsNothing(Categorias) Then
                For Each Categoria As dCategoria In Categorias
                    linha = dgvCategoria.Rows(dgvCategoria.Rows.Add())
                    linha.Cells("cid").Value = Categoria.cid
                    linha.Cells("Nome").Value = Categoria.nome
                    linha.Cells("Situacao").Value = Categoria.situacao
                Next
            End If
            dgvCategoria.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do Categoria [" & Me.ToString() & "]")

        End Try
    End Sub

    Private Sub fCategoriaLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub dgvCategoria_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategoria.CellDoubleClick
        SelecionarItem()
    End Sub

End Class