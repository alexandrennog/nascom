Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncDados.nsCrediario
Imports ncRegras.nsCrediario

Public Class fClienteCrediarioForm

    Public cliente_cid As Nullable(Of Integer)
    Public cliente_nome As String

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        CarregarCadastro()
    End Sub

    Private Sub btoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEndereco.Click
        CarregarEndereco()
    End Sub

    Private Sub btoProfissional_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoProfissional.Click
        CarregarProfissional()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If MessageBox.Show("Deseja sair da tela?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Me.Modal Then
                Me.Close()
            Else
                mdiPrincipal.FecharTela()
            End If
        End If
    End Sub

    Private Sub fClienteFinanceiroForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Me.Modal Then
                    Me.Close()
                Else
                    mdiPrincipal.FecharTela()
                End If
            Case Keys.F1
                CarregarParcelas(True)
            Case Keys.F5
                Filtrar()
            Case Keys.F6
                CarregarCadastro()
            Case Keys.F7
                CarregarEndereco()
            Case Keys.F8
                CarregarProfissional()
            Case Keys.F9, Keys.F1
                CarregarFinanceiro()
            Case Keys.Enter
                If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
                    MessageBox.Show("Usuário sem permissão para renegociar parcelas.", "Nascomercio")
                Else
                    CarregarParcelas(False)
                End If
        End Select
    End Sub

    Private Sub CarregarCadastro()
        fClienteForm.cid = Me.cliente_cid
        mdiPrincipal.CarregarClienteForm()
    End Sub

    Private Sub CarregarEndereco()
        fClienteEnderecoForm.cliente_cid = Me.cliente_cid
        fClienteEnderecoForm.cliente_nome = Me.txtNome.Text
        mdiPrincipal.CarregarClienteEnderecoForm()
    End Sub

    Private Sub CarregarFinanceiro()
        fClienteFinanceiroForm.cliente_cid = Me.cliente_cid
        fClienteFinanceiroForm.cliente_nome = Me.txtNome.Text
        mdiPrincipal.CarregarClienteFinanceiroForm()
    End Sub

    Private Sub CarregarProfissional()
        fClienteProfissionalForm.cliente_cid = Me.cliente_cid
        fClienteProfissionalForm.cliente_nome = Me.txtNome.Text
        mdiPrincipal.CarregarClienteProfissionalForm()
    End Sub

    Private Function CarregarParcelas(ByVal incluir As Boolean) As Boolean
        Dim janela As fClienteCrediarioParcelasForm
        Dim linha As DataGridViewRow
        Dim parcelas As ColecaoParcelas

        Dim dadosParcela As New dParcelas
        Dim regraparcela As New rCrediario

        If incluir Then
            dadosParcela.crediarioId = 0
        Else
            If dgvCrediario.Rows.Count > 0 Then
                dadosParcela.crediarioId = dgvCrediario.CurrentRow.Cells(0).Tag
            Else
                MessageBox.Show("Nenhum crediário selecionado.")
                Exit Function
            End If
        End If

        janela = New fClienteCrediarioParcelasForm()

        Try
            If Not incluir Then
                parcelas = regraparcela.ConsultarParcelas(dadosParcela)
                If Not IsNothing(parcelas) Then
                    ' crediario
                    For Each dadosParcela In parcelas
                        linha = janela.dgvCrediario.Rows(janela.dgvCrediario.Rows.Add())
                        linha.Cells(0).Tag = dadosParcela.cid
                        linha.Cells(0).Value = dadosParcela.codigoBarras
                        linha.Cells(1).Value = dadosParcela.dataEmissao.ToString("dd/MM/yyyy")
                        linha.Cells(2).Value = dadosParcela.dataVecimento.ToString("dd/MM/yyyy")
                        linha.Cells(3).Value = dadosParcela.valor.ToString("N")
                        linha.Cells(4).Value = dadosParcela.valorPago.ToString("N")
                        If dadosParcela.dataPagamento.HasValue Then
                            linha.Cells(5).Value = dadosParcela.dataPagamento.Value.ToString("dd/MM/yyyy")
                        End If
                        linha.Cells(6).Value = dadosParcela.observacao
                        linha.Cells(7).Value = dadosParcela.situacao
                        If dadosParcela.situacao = "01" Then
                            linha.Cells(0).Style.ForeColor = Color.Green
                            linha.Cells(1).Style.ForeColor = Color.Green
                            linha.Cells(2).Style.ForeColor = Color.Green
                            linha.Cells(3).Style.ForeColor = Color.Green
                            linha.Cells(4).Style.ForeColor = Color.Green
                            linha.Cells(5).Style.ForeColor = Color.Green
                            linha.Cells(6).Style.ForeColor = Color.Green
                        ElseIf dadosParcela.situacao = "00" And dadosParcela.valorPago < dadosParcela.valor Then
                            linha.Cells(0).Style.ForeColor = Color.Red
                            linha.Cells(1).Style.ForeColor = Color.Red
                            linha.Cells(2).Style.ForeColor = Color.Red
                            linha.Cells(3).Style.ForeColor = Color.Red
                            linha.Cells(4).Style.ForeColor = Color.Red
                            linha.Cells(5).Style.ForeColor = Color.Red
                            linha.Cells(6).Style.ForeColor = Color.Red
                        Else
                            linha.Cells(0).Style.ForeColor = Color.Black
                            linha.Cells(1).Style.ForeColor = Color.Black
                            linha.Cells(2).Style.ForeColor = Color.Black
                            linha.Cells(3).Style.ForeColor = Color.Black
                            linha.Cells(4).Style.ForeColor = Color.Black
                            linha.Cells(5).Style.ForeColor = Color.Black
                            linha.Cells(6).Style.ForeColor = Color.Black
                        End If
                    Next
                    janela.txtControle.Tag = dadosParcela.crediarioId
                Else
                    janela.txtControle.Tag = dgvCrediario.CurrentRow.Cells(0).Tag
                End If
                janela.lblTotal.Text = dgvCrediario.CurrentRow.Cells(4).Value
                janela.lblFalta.Text = dgvCrediario.CurrentRow.Cells(3).Value
                janela.txtControle.Text = dgvCrediario.CurrentRow.Cells(5).Value
            Else
                janela.lblTotal.Text = 0
                janela.lblFalta.Text = 0
                janela.txtControle.Text = 0
            End If
            janela.StartPosition = FormStartPosition.CenterParent
            janela.txtCliente.Text = Me.cliente_nome
            janela.txtCliente.Tag = Me.cliente_cid
            janela.lblVendedor.Text = mdiPrincipal.gUsuario.usuario
            janela.lblVendedor.Tag = mdiPrincipal.gUsuario.cid
            janela.lblLoja.Text = mdiPrincipal.gLoja.nomeFantasia
            janela.lblLoja.Tag = mdiPrincipal.gLoja.cid
        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try

        janela.ShowDialog()

        Return janela.pago

    End Function

    Private Sub Filtrar()
        mdiPrincipal.CarregarClienteFiltro()
    End Sub

    Private Sub LimparCampos()
        txtLimite.Text = String.Empty
        txtDisponivel.Text = String.Empty
    End Sub

    Private Sub ExibirInformacoes()
        Dim regras As rClienteFinanceiro
        Dim dados As dClienteFinanceiro
        Dim colecao As ColecaoClienteFinanceiro
        Dim regrasCrediario As ncRegras.nsCrediario.rCrediario
        Dim dadosCrediario As ncDados.nsCrediario.dCrediario
        Dim dadosListaCrediario As ncDados.nsCrediario.ColecaoCrediario
        Dim linha As DataGridViewRow
        Dim parcelas As ColecaoParcelas
        Dim devedor As Boolean = False

        Dim dadosParcela As New dParcelas
        Dim regraparcela As New rCrediario

        If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
            btoSalvar.Visible = False
            btnIncluir.Visible = False
        End If

        Try

            If Not Me.cliente_cid.Equals(Nothing) Then
                If Not Me.cliente_cid.Equals(0) Then

                    txtNome.Text = Me.cliente_nome

                    regras = New rClienteFinanceiro()
                    dados = New dClienteFinanceiro()

                    dados.cliente_cid = Me.cliente_cid
                    colecao = regras.Consultar(dados)

                    If Not colecao Is Nothing Then
                        If colecao.Count > 0 Then
                            dados = colecao(0)

                            txtLimite.Text = cFuncoes.RetornarTexto(dados.limite)
                            txtDisponivel.Text = cFuncoes.RetornarTexto(dados.limite)
                        End If
                    End If

                    ' Consulta dados de crediário
                    dgvCrediario.Rows.Clear()
                    regrasCrediario = New ncRegras.nsCrediario.rCrediario
                    dadosCrediario = New ncDados.nsCrediario.dCrediario
                    dadosCrediario.clienteId = Me.cliente_cid
                    dadosListaCrediario = regrasCrediario.Consultar(dadosCrediario)

                    If Not IsNothing(dadosListaCrediario) Then
                        For Each dadosCrediario In dadosListaCrediario
                            'Busca parcelas
                            dadosParcela = New ncDados.nsCrediario.dParcelas()
                            dadosParcela.crediarioId = dadosCrediario.cid
                            parcelas = regraparcela.ConsultarParcelas(dadosParcela)
                            devedor = False

                            If cboCrediario.Text = "Todos" Then
                                linha = dgvCrediario.Rows(dgvCrediario.Rows.Add())
                                linha.Cells(0).Tag = dadosCrediario.cid
                                If Not IsNothing(parcelas) Then
                                    For Each dadosParcela In parcelas
                                        linha.Cells(0).Value = dadosParcela.dataVecimento.ToString("dd/MM/yyyy")
                                    Next
                                End If
                                linha.Cells(1).Value = dadosCrediario.Parcelas.ToString
                                linha.Cells(2).Value = dadosCrediario.ValorPago.ToString("N")
                                linha.Cells(3).Value = dadosCrediario.SaldoDevedor.ToString("N")
                                linha.Cells(4).Value = dadosCrediario.ValorTotal.ToString("N")
                                linha.Cells(5).Value = dadosCrediario.controle

                                If dadosCrediario.SaldoDevedor > 0 Then
                                    linha.Cells(0).Style.ForeColor = Color.Red
                                    linha.Cells(1).Style.ForeColor = Color.Red
                                    linha.Cells(2).Style.ForeColor = Color.Red
                                    linha.Cells(3).Style.ForeColor = Color.Red
                                    linha.Cells(4).Style.ForeColor = Color.Red
                                    linha.Cells(5).Style.ForeColor = Color.Red
                                End If
                            ElseIf cboCrediario.Text = "A Pagar" Then
                                If Not IsNothing(parcelas) Then
                                    For Each dadosParcela In parcelas
                                        If dadosParcela.valorReceber > 0 Then
                                            devedor = True
                                        End If
                                    Next
                                End If
                                If devedor Then
                                    linha = dgvCrediario.Rows(dgvCrediario.Rows.Add())
                                    linha.Cells(0).Tag = dadosCrediario.cid
                                    If Not IsNothing(parcelas) Then
                                        For Each dadosParcela In parcelas
                                            If dadosParcela.valorPago = 0.0 Then
                                                linha.Cells(0).Value = dadosParcela.dataVecimento.ToString("dd/MM/yyyy")
                                            End If
                                        Next
                                    End If
                                    linha.Cells(1).Value = dadosCrediario.Parcelas.ToString
                                    linha.Cells(2).Value = dadosCrediario.ValorPago.ToString("N")
                                    linha.Cells(3).Value = dadosCrediario.SaldoDevedor.ToString("N")
                                    linha.Cells(4).Value = dadosCrediario.ValorTotal.ToString("N")
                                    linha.Cells(5).Value = dadosCrediario.controle
                                    linha.Cells(0).Style.ForeColor = Color.Red
                                    linha.Cells(1).Style.ForeColor = Color.Red
                                    linha.Cells(2).Style.ForeColor = Color.Red
                                    linha.Cells(3).Style.ForeColor = Color.Red
                                    linha.Cells(4).Style.ForeColor = Color.Red
                                    linha.Cells(5).Style.ForeColor = Color.Red
                                End If
                            ElseIf cboCrediario.Text = "Pagos" Then
                                If Not IsNothing(parcelas) Then
                                    For Each dadosParcela In parcelas
                                        If dadosParcela.valorReceber > 0 Then
                                            devedor = True
                                        End If
                                    Next
                                End If
                                If Not devedor Then
                                    linha = dgvCrediario.Rows(dgvCrediario.Rows.Add())
                                    linha.Cells(0).Tag = dadosCrediario.cid
                                    If Not IsNothing(parcelas) Then
                                        For Each dadosParcela In parcelas
                                            linha.Cells(0).Value = dadosParcela.dataVecimento.ToString("dd/MM/yyyy")
                                        Next
                                    End If
                                    linha.Cells(1).Value = dadosCrediario.Parcelas.ToString
                                    linha.Cells(2).Value = dadosCrediario.ValorPago.ToString("N")
                                    linha.Cells(3).Value = dadosCrediario.SaldoDevedor.ToString("N")
                                    linha.Cells(4).Value = dadosCrediario.ValorTotal.ToString("N")
                                    linha.Cells(5).Value = dadosCrediario.controle
                                End If
                            End If
                            txtDisponivel.Text = CDec(CDec(IIf(txtDisponivel.Text.Equals(""), 0, txtDisponivel.Text)) - dadosCrediario.SaldoDevedor).ToString("N")
                        Next
                    End If
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try
    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSalvar.Click
        CarregarParcelas(False)
        ExibirInformacoes()

    End Sub

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LimparCampos()
        cboCrediario.Text = "A Pagar"
        ExibirInformacoes()
    End Sub

    Private Sub btoFinanceiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFinanceiro.Click
        CarregarFinanceiro()
    End Sub

    Private Sub cboCrediario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCrediario.SelectedIndexChanged
        LimparCampos()
        ExibirInformacoes()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        CarregarParcelas(True)
        ExibirInformacoes()
    End Sub

    Private Sub btoCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCheques.Click
        mdiPrincipal.CarregarCheques(cliente_nome)
    End Sub

    Private Sub btoVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVendas.Click
        mdiPrincipal.CarregarVendas(cliente_nome)
    End Sub
End Class