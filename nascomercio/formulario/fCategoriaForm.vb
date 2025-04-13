Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsCategoria
Imports ncRegras.nsCategoria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Public Class fCategoriaForm

    Public cid As Nullable(Of Integer)

    Private Function Validar() As Boolean
        Try

            If String.IsNullOrEmpty(txtNome.Text.Trim()) Then
                MessageBox.Show("É necessário informar o Nome!")
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub Salvar()
        Dim dados As dCategoria
        Dim regras As rCategoria
        Dim tipoMsg As String = String.Empty
        Dim tipoAcao As String = String.Empty
        Dim novoCID As Integer

        Try

            If Not Validar() Then
                Exit Sub
            End If

            tipoMsg = "INCLUSÃO"
            tipoAcao = "i"

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.ToString().Equals(String.Empty) Then
                    If Not Me.cid.Equals(0) Then
                        tipoMsg = "ALTERAÇÃO"
                        tipoAcao = "a"
                    End If
                End If
            End If

            If MessageBox.Show("Confirma " & tipoMsg & " das informações?", tipoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                dados = New dCategoria
                regras = New rCategoria

                dados.cid = Me.cid
                dados.nome = cFuncoes.TratarTexto(txtNome.Text)
                dados.situacao = cFuncoes.TratarTexto(cboSituacao.SelectedValue)

                If tipoAcao.Equals("i") Then
                    If IsNothing(regras.Consultar(dados)) Then
                        novoCID = regras.Incluir(dados)
                    Else
                        MessageBox.Show("Categoria já cadastrada.")
                    End If

                    Me.cid = novoCID
                    ExibirInformacoesTela()
                ElseIf tipoAcao.Equals("a") Then
                    regras.Alterar(dados)

                    ExibirInformacoesTela()
                End If

                SelecionarNovaCategoria()
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na " & tipoMsg.ToLower() & " dos dados da Categoria.")

        End Try
    End Sub

    Private Sub Excluir()
        Dim dados As dCategoria
        Dim regras As rCategoria

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.ToString().Equals(String.Empty) Then
                    If Not Me.cid.Equals(0) Then
                        If MessageBox.Show("Confirma EXCLUSÃO das informações?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                            dados = New dCategoria
                            regras = New rCategoria

                            dados.cid = cFuncoes.TratarInteiro(Me.cid)

                            regras.Excluir(dados)

                            Me.cid = Nothing
                            LimparCampos()
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na exclusão dos dados da Categoria.")

        End Try
    End Sub

    Private Sub CarregarComboSituacao()
        Dim regras As rSituacao
        Dim colecao As ColecaoSituacao

        Try

            cboSituacao.DataSource = Nothing
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

    Private Sub ExibirInformacoesTela()
        Dim regras As rCategoria
        Dim dados As dCategoria

        Try

            If Not Me.cid.Equals(Nothing) Then
                If Not Me.cid.Equals(0) Then

                    regras = New rCategoria()

                    dados = regras.Consultar(Me.cid)

                    If Not dados Is Nothing Then
                        txtNome.Text = cFuncoes.RetornarTexto(dados.nome)
                        If cboSituacao.Items.Count > 0 Then
                            cboSituacao.SelectedIndex = 0
                        End If
                        If cFuncoes.ValidarValor(dados.situacao) Then
                            cboSituacao.SelectedValue = cFuncoes.RetornarTexto(dados.situacao)
                        End If
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados da Categoria.")

        End Try

    End Sub

    Private Sub LimparCampos()
        txtNome.Text = String.Empty
        If cboSituacao.Items.Count > 0 Then
            cboSituacao.SelectedIndex = 0
        End If
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarCategoriaFiltro()
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        Salvar()
    End Sub

    Private Sub btoExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluir.Click
        Excluir()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Sair()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub fCategoriaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Modal = True Then
            btoFiltro.Visible = False
            btoExcluir.Visible = False
        End If

        LimparCampos()
        CarregarComboSituacao()
        ExibirInformacoesTela()
    End Sub

    Private Sub fCategoriaForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Sair()
            Case Keys.F5
                Filtrar()
            Case Keys.Enter
                Salvar()
            Case Keys.F12
                Excluir()
        End Select
    End Sub

    Private Sub SelecionarNovaCategoria()
        If Me.Modal = True Then
            If Not Me.cid.Equals(Nothing) Then
                fProdutoForm.SelecionarNovaCategoria(Me.cid)
            End If

            Sair()
        End If
    End Sub

    Private Sub Sair()
        If Me.Modal = True Then
            Me.Close()
        Else
            If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                mdiPrincipal.FecharTela()
            End If
        End If
    End Sub

End Class