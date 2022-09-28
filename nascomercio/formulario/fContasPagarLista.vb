Imports ncRegras.nsContasPagar
Imports ncDados.nsContasPagar
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes.cFuncoes

Public Class fContasPagarLista

    Public filtro As dContasPagar

    Private Sub Cadastrar()
        mdiPrincipal.CarregarContasPagarForm()
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarContasPagarFiltro()
    End Sub

    Private Sub SelecionarItem()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim cid As Nullable(Of Integer)

        Try
            If dgvContasPagar.Rows.Count > 0 Then

                indice = dgvContasPagar.CurrentRow.Index

                linha = dgvContasPagar.Rows(indice)

                cid = linha.Cells("cid").Value

            End If
        Catch ex As Exception

            cid = Nothing

        End Try

        fContasPagarForm.cid = cid

        mdiPrincipal.CarregarContasPagarForm()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub fContasPagarLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim regras As rContasPagar
        Dim lista As ColecaoContasPagar
        Dim linha As DataGridViewRow

        Try

            regras = New rContasPagar

            lista = regras.Consultar(filtro)

            If Not IsNothing(lista) Then
                For Each item As dContasPagar In lista
                    linha = dgvContasPagar.Rows(dgvContasPagar.Rows.Add())
                    linha.Cells("cid").Value = item.cid
                    linha.Cells("codigo").Value = item.codigo
                    linha.Cells("valor").Value = RetornarTexto(item.valor)
                    linha.Cells("data").Value = RetornarData(item.dataVencimento).Value.ToString("dd/MM/yyyy")
                Next
            End If
            dgvContasPagar.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do ContasPagar [" & Me.ToString() & "]")

        End Try
    End Sub

    Private Sub fContasPagarLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub btoSelecionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSelecionar.Click
        SelecionarItem()
    End Sub

    Private Sub dgvContasPagar_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContasPagar.CellDoubleClick
        SelecionarItem()
    End Sub

End Class