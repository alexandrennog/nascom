Imports ncRegras.nsServico
Imports ncDados.nsServico
Imports ncComum.nsExcecao

Public Class fServicoLista

    Public filtro As dServico

    Private Sub Cadastrar()
        mdiPrincipal.CarregarServicoForm()
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarServicoFiltro()
    End Sub

    Private Sub SelecionarItem()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim cid As Nullable(Of Integer)

        Try
            If dgvServico.Rows.Count > 0 Then

                indice = dgvServico.CurrentRow.Index

                linha = dgvServico.Rows(indice)

                cid = linha.Cells("cid").Value

            End If
        Catch ex As Exception

            cid = Nothing

        End Try

        fServicoForm.cid = cid

        mdiPrincipal.CarregarServicoForm()
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

    Private Sub fServicoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim regras As rServico
        Dim Servicos As ColecaoServico
        Dim linha As DataGridViewRow

        Try

            regras = New rServico

            Servicos = regras.Consultar(filtro)

            If Not IsNothing(Servicos) Then
                For Each Servico As dServico In Servicos
                    linha = dgvServico.Rows(dgvServico.Rows.Add())
                    linha.Cells("cid").Value = Servico.cid
                    linha.Cells("Nome").Value = Servico.nome
                    linha.Cells("Valor").Value = Servico.valor
                    linha.Cells("Situacao").Value = Servico.situacao
                Next
            End If
            dgvServico.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta do Servico [" & Me.ToString() & "]")

        End Try
    End Sub

    Private Sub fServicoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub dgvServico_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServico.CellDoubleClick
        If Me.Modal Then
            SelecionarItemOS()
            Me.Close()
        Else
            SelecionarItem()
        End If
    End Sub

    Private Sub SelecionarItemOS()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        indice = dgvServico.CurrentRow.Index
        linha = dgvServico.Rows(indice)
        Me.filtro.cid = linha.Cells("cid").Value
        Me.filtro.nome = linha.Cells("nome").Value
        Me.filtro.valor = linha.Cells("valor").Value
        Me.filtro.situacao = IIf(linha.Cells("cid").Style.ForeColor = Color.Red, "N", "A")

    End Sub

End Class