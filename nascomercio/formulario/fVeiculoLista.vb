Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncRegras.nsVeiculos
Imports ncDados.nsVeiculos

Public Class fVeiculoLista

    Public filtro As dVeiculos


    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If Me.Modal Then
            Me.Close()
        Else
            mdiPrincipal.FecharTela()
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
        End Select
    End Sub

    Private Sub Filtrar()
        mdiPrincipal.CarregarClienteFiltro()
    End Sub

    Private Sub ExibirInformacoes()

        Try

            If Not Me.filtro.Equals(Nothing) Then
                If Not Me.filtro.clienteId.Equals(0) Then
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

        dadosVeiculos.clienteId = Me.filtro.clienteId

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

    Private Sub fClienteFinanceiroForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ExibirInformacoes()
    End Sub

    Private Sub dgvVeiculos_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVeiculos.CellContentDoubleClick
        If Me.Modal Then
            SelecionarItemOS()
            Me.Close()
        Else
            'SelecionarItem()
        End If
    End Sub

    Private Sub SelecionarItemOS()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        indice = dgvVeiculos.CurrentRow.Index
        linha = dgvVeiculos.Rows(indice)
        Me.filtro.cid = linha.Cells("placa").Tag
        Me.filtro.Placa = linha.Cells("placa").Value
        Me.filtro.Marca = linha.Cells("marca").Value
        Me.filtro.Modelo = linha.Cells("modelo").Value
        Me.filtro.Ano = linha.Cells("ano").Value
        Me.filtro.Cor = linha.Cells("cor").Value
        Me.filtro.Combustivel = linha.Cells("combustivel").Value

    End Sub

End Class