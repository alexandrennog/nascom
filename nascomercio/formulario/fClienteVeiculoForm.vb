Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncRegras.nsVeiculos
Imports ncDados.nsVeiculos

Public Class fClienteVeiculoForm

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
                IncluirItem()
            Case Keys.F2
                ExcluirItem()
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
                Salvar()
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

    Private Sub Filtrar()
        mdiPrincipal.CarregarClienteFiltro()
    End Sub

    Private Sub ExibirInformacoes()

        Try

            If Not Me.cliente_cid.Equals(Nothing) Then
                If Not Me.cliente_cid.Equals(0) Then
                    txtNome.Text = Me.cliente_nome
                    CarregarVeiculos()
                End If
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Cliente.")

        End Try
    End Sub

    Private Sub CarregarVeiculos()
        Dim linha As DataGridViewRow
        Dim veiculos As ColecaoVeiculos

        Dim dadosVeiculos As New dVeiculos
        Dim regraVeiculo As New rVeiculos

        dadosVeiculos.clienteId = cliente_cid

        Try
            veiculos = regraVeiculo.Consultar(dadosVeiculos)

            If Not IsNothing(veiculos) Then

                dgvVeiculos.Rows.Clear()

                ' crediario
                For Each dadosVeiculos In veiculos
                    linha = dgvVeiculos.Rows(dgvVeiculos.Rows.Add())
                    linha.Cells(0).Tag = dadosVeiculos.cid
                    linha.Cells(0).Value = dadosVeiculos.Placa
                    linha.Cells(1).Value = dadosVeiculos.Marca
                    linha.Cells(2).Value = dadosVeiculos.Modelo
                    linha.Cells(3).Value = dadosVeiculos.Cor
                    linha.Cells(4).Value = dadosVeiculos.Ano
                    linha.Cells(5).Value = dadosVeiculos.Combustivel
                Next
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Veiculos.")

        End Try

    End Sub

    Private Sub btoSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExibirInformacoes()

    End Sub

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ExibirInformacoes()
    End Sub

    Private Sub btoFinanceiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFinanceiro.Click
        CarregarFinanceiro()
    End Sub

    Private Sub cboCrediario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExibirInformacoes()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        Salvar()
        ExibirInformacoes()
    End Sub

    Private Sub btoCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCheques.Click
        mdiPrincipal.CarregarCheques(cliente_nome)
    End Sub

    Private Sub btoVendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoVendas.Click
        mdiPrincipal.CarregarVendas(cliente_nome)
    End Sub

    Private Sub btoIncluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoIncluirItem.Click
        IncluirItem()
    End Sub

    Private Sub btoExcluirItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoExcluirItem.Click
        ExcluirItem()
    End Sub

    Private Sub IncluirItem()
        If dgvVeiculos.Columns.Count > 0 Then
            dgvVeiculos.Rows.Add()
            dgvVeiculos.Refresh()
        End If


    End Sub

    Private Sub ExcluirItem()

        Dim rVeiculos As New ncRegras.nsVeiculos.rVeiculos
        Dim veiculo As ncDados.nsVeiculos.dVeiculos

        If dgvVeiculos.Rows.Count > 0 Then
            Try

                If MessageBox.Show("Confirma Exclusão?", "Veículos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                    veiculo = New ncDados.nsVeiculos.dVeiculos()
                    veiculo.cid = dgvVeiculos.CurrentRow.Cells(0).Tag
                    veiculo.clienteId = Me.cliente_cid

                    rVeiculos.Excluir(veiculo)
                    dgvVeiculos.Rows.RemoveAt(dgvVeiculos.CurrentRow.Index)

                End If
            Catch nex As ExcecaoNascomercio

                MessageBox.Show(nex.Message)

            Catch ex As Exception

                MessageBox.Show("Erro na gravação dos dados de Crediário.")

            End Try
        End If
    End Sub


    Private Sub Salvar()
        Dim rVeiculos As New ncRegras.nsVeiculos.rVeiculos
        Dim veiculosAdd As New ncDados.nsVeiculos.ColecaoVeiculos
        Dim veiculosAlt As New ncDados.nsVeiculos.ColecaoVeiculos
        Dim veiculo As ncDados.nsVeiculos.dVeiculos

        Try

            If MessageBox.Show("Confirma gravação das informações?", "Veículos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                For Each linha As DataGridViewRow In dgvVeiculos.Rows
                    If linha.Cells(1).Value <> "" Then
                        veiculo = New ncDados.nsVeiculos.dVeiculos()
                        veiculo.cid = linha.Cells(0).Tag
                        veiculo.clienteId = Me.cliente_cid
                        veiculo.Placa = linha.Cells(0).Value
                        veiculo.Marca = linha.Cells(1).Value
                        veiculo.Modelo = linha.Cells(2).Value
                        veiculo.Cor = linha.Cells(3).Value
                        veiculo.Ano = linha.Cells(4).Value
                        veiculo.Combustivel = linha.Cells(5).Value
                        If IsNothing(veiculo.cid) Then
                            veiculosAdd.Add(veiculo)
                        Else
                            veiculosAlt.Add(veiculo)
                        End If
                    End If
                Next

                veiculo = New ncDados.nsVeiculos.dVeiculos()
                veiculo.clienteId = Me.cliente_cid
                rVeiculos.Alterar(veiculosAlt)
                rVeiculos.Incluir(veiculosAdd)

                If dgvVeiculos.Rows.Count <= 0 Then
                    If MessageBox.Show("Deseja excluir veículo(s)?", "Veículos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        veiculo = New ncDados.nsVeiculos.dVeiculos()
                        veiculo.clienteId = Me.cliente_cid
                        rVeiculos.ExcluirVeiculosCliente(veiculo)
                    End If
                End If

            End If

            ExibirInformacoes()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na gravação dos dados de Crediário.")

        End Try
    End Sub

End Class