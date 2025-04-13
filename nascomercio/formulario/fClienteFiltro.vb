Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fClienteFiltro

    Private Sub btoCliSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub fClienteFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Cadastrar()
            Case Keys.Enter
                Pesquisar()
        End Select
    End Sub

    Private Sub Cadastrar()
        mdiPrincipal.CarregarClienteForm()
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        Pesquisar()
    End Sub

    Private Sub Pesquisar()
        Dim filtro As dCliente

        filtro = New dCliente

        fClienteLista.filtro = filtro

        filtro.cid = cFuncoes.TratarInteiro(txtCodigo.Text)
        filtro.nome = cFuncoes.TratarTexto(txtNome.Text)
        filtro.dataNascimento = cFuncoes.TratarTexto(txtDataNascimento.Text)
        filtro.naturalidade = cFuncoes.TratarTexto(txtNaturalidade.Text)
        filtro.nacionalidade = cFuncoes.TratarTexto(txtNacionalidade.Text)
        filtro.estadoCivil = cFuncoes.TratarTexto(cboEstadoCivil.SelectedValue)
        filtro.sexo = cFuncoes.TratarTexto(cboSexo.SelectedValue)
        filtro.cpf = cFuncoes.TratarTexto(txtCPF.Text)
        filtro.rg = cFuncoes.TratarTexto(txtRG.Text)
        filtro.carteiraProfissional = cFuncoes.TratarTexto(txtCarteiraProfissional.Text)
        filtro.nomePai = cFuncoes.TratarTexto(txtNomePai.Text)
        filtro.nomeMae = cFuncoes.TratarTexto(txtNomeMae.Text)
        filtro.email = cFuncoes.TratarTexto(txtEmail.Text)
        filtro.ddd = cFuncoes.TratarTexto(txtDDD.Text)
        filtro.telefone = cFuncoes.TratarTexto(txtTelefone.Text)
        filtro.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)
        filtro.veiculo = cFuncoes.TratarTexto(txtVeiculo.Text)

        mdiPrincipal.CarregarClienteLista()
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

    Private Sub fClienteFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarComboSituacao()
    End Sub

End Class