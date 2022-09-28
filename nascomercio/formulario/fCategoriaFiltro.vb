Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsCategoria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fCategoriaFiltro

    Private Sub Cadastrar()
        mdiPrincipal.CarregarCategoriaForm()
    End Sub

    Private Sub Pesquisar()
        Dim filtro As dCategoria

        filtro = New dCategoria

        filtro.nome = cFuncoes.TratarTexto(txtNome.Text)
        filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

        fCategoriaLista.filtro = filtro

        mdiPrincipal.CarregarCategoriaLista()
    End Sub

    Private Sub CarregarComboSituacao()
        Dim regras As rSituacao
        Dim colecao As ColecaoSituacao

        Try

            cboSituacao.Items.Clear()

            regras = New rSituacao()
            colecao = regras.Listar()

            If Not colecao Is Nothing Then


                cboSituacao.ValueMember = "codigo"
                cboSituacao.DisplayMember = "descricao"
                cboSituacao.DataSource = colecao
                cboSituacao.Refresh()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Situação.")

        End Try
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub fCategoriaFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarComboSituacao()
    End Sub

    Private Sub fCategoriaFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Cadastrar()
            Case Keys.Enter
                Pesquisar()
        End Select
    End Sub
End Class