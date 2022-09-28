Imports ncRegras.nsCliente
Imports ncRegras.nsCrediario
Imports ncDados.nsCliente
Imports ncDados.nsCrediario
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes

Public Class fClienteLista

    Public filtro As dCliente
    Private clientes As ColecaoCliente

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        If Me.Modal Then
            Me.Close()
        Else
            mdiPrincipal.FecharTela()
        End If
    End Sub

    Private Sub Cadastrar()
        mdiPrincipal.CarregarClienteForm()
    End Sub

    Private Sub Filtrar()
        If Me.Modal Then
            filtro.cid = cFuncoes.TratarInteiro(txtCodigo.Text)
            filtro.nome = cFuncoes.TratarTexto(txtCliente.Text)
            filtro.cpf = cFuncoes.TratarTexto(txtCPF.Text)
            filtro.situacao = "A"
            If txtCodigo.Text.Trim = "" And txtCliente.Text.Length < 3 And txtCPF.Text.Length < 3 Then
                MessageBox.Show("Informe os dados do cliente!")
            Else
                CarregarClientes()
            End If
        Else
            mdiPrincipal.CarregarClienteFiltro()
        End If

    End Sub

    Private Sub fClienteLista_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Me.Modal Then
            txtCodigo.Focus()
        End If
    End Sub

    Private Sub fClienteLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                If Me.Modal Then
                    Me.Close()
                Else
                    mdiPrincipal.FecharTela()
                End If
            Case Keys.F5
                If Me.Modal Then
                    Me.Close()
                End If
                Cadastrar()
            Case Keys.F6
                Filtrar()
            Case Keys.Enter
                If Me.Modal Then
                    If Me.dgvCliente.Rows.Count > 0 Then
                        SelecionarItemCaixa()
                        Me.Close()
                    Else
                        Filtrar()
                    End If
                Else
                    SelecionarItem()
                End If
        End Select
    End Sub

    Private Sub btoCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoCadastro.Click
        Cadastrar()
    End Sub

    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        Filtrar()
    End Sub

    Private Sub fClienteLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.Modal Then
            lblCodigo.Visible = True
            txtCodigo.Visible = True
            lblCliente.Visible = True
            txtCliente.Visible = True
            lblCPF.Visible = True
            txtCPF.Visible = True
            btoCadastro.Visible = False
            txtCodigo.Focus()
        Else
            lblCodigo.Visible = False
            txtCodigo.Visible = False
            lblCliente.Visible = False
            txtCliente.Visible = False
            lblCPF.Visible = False
            txtCPF.Visible = False
            btoCadastro.Visible = True
            CarregarClientes()
        End If

    End Sub

    Private Sub dgvCliente_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCliente.CellDoubleClick
        If Me.Modal Then
            SelecionarItemCaixa()
            Me.Close()
        Else
            SelecionarItem()
        End If
    End Sub

    Private Sub SelecionarItemCaixa()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        indice = dgvCliente.CurrentRow.Index
        linha = dgvCliente.Rows(indice)
        Me.filtro.cid = linha.Cells("cid").Value
        Me.filtro.nome = linha.Cells("nome").Value
        Me.filtro.ddd = linha.Cells("ddd").Value
        Me.filtro.telefone = linha.Cells("telefone").Value
        Me.filtro.dddcel = linha.Cells("dddcel").Value
        Me.filtro.celular = linha.Cells("celular").Value
        If linha.Cells("cid").Style.ForeColor = Color.Red Then
            Me.filtro.situacao = "N"
        ElseIf linha.Cells("cid").Style.ForeColor = Color.Orange Then
            Me.filtro.situacao = "O"
        Else
            Me.filtro.situacao = "A"
        End If
        Me.filtro.cpf = linha.Cells("cpf").Value

    End Sub

    Private Sub SelecionarItem()
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim cid As Nullable(Of Integer)

        Try
            If dgvCliente.Rows.Count > 0 Then

                indice = dgvCliente.CurrentRow.Index

                linha = dgvCliente.Rows(indice)

                cid = linha.Cells("cid").Value

            End If
        Catch ex As Exception

            cid = Nothing

        End Try

        fClienteForm.cid = cid

        mdiPrincipal.CarregarClienteForm()
    End Sub

    Private Sub CarregarClientes()
        Dim regras As rCliente
        Dim regrasFinanceiro As rClienteFinanceiro
        Dim regrasCrediario As rCrediario
        Dim clientefinanceiro As ColecaoClienteFinanceiro
        Dim dadosFinanceiros As dClienteFinanceiro
        Dim parcelasVencidas As ColecaoParcelas
        Dim linha As DataGridViewRow

        Try

            dgvCliente.Rows.Clear()

            regras = New rCliente
            regrasFinanceiro = New rClienteFinanceiro
            regrasCrediario = New rCrediario

            clientes = regras.Consultar(filtro)

            If Not IsNothing(clientes) Then
                For Each cliente As dCliente In clientes
                    dadosFinanceiros = New dClienteFinanceiro()
                    dadosFinanceiros.cliente_cid = cliente.cid
                    clientefinanceiro = regrasFinanceiro.Consultar(dadosFinanceiros)
                    If Me.Modal Then
                        linha = dgvCliente.Rows(dgvCliente.Rows.Add())
                        If Not IsNothing(clientefinanceiro) Then
                            If clientefinanceiro(0).situacaoCrediario = "N" Then
                                linha.Cells("cid").Style.ForeColor = Color.Red
                                linha.Cells("Nome").Style.ForeColor = Color.Red
                            Else
                                parcelasVencidas = regrasCrediario.ConsultarParcelasVencidas(cliente.cid)
                                If Not IsNothing(parcelasVencidas) Then
                                    For Each dadosParcela As dParcelas In parcelasVencidas
                                        If dadosParcela.valorReceber > 0 Then
                                            linha.Cells("cid").Style.ForeColor = Color.Orange
                                            linha.Cells("Nome").Style.ForeColor = Color.Orange
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        linha.Cells("cid").Value = cliente.cid
                        linha.Cells("Nome").Value = cliente.nome
                        linha.Cells("Cpf").Value = cliente.cpf
                        linha.Cells("Rg").Value = cliente.rg
                        linha.Cells("Situacao").Value = cliente.situacao
                        linha.Cells("Ddd").Value = cliente.ddd
                        linha.Cells("Telefone").Value = cliente.telefone
                        linha.Cells("Dddcel").Value = cliente.dddcel
                        linha.Cells("Celular").Value = cliente.celular
                        linha.Cells("Email").Value = cliente.email
                    Else
                        If cliente.cid.Value > 1 Then
                            linha = dgvCliente.Rows(dgvCliente.Rows.Add())
                            If Not IsNothing(clientefinanceiro) Then
                                If clientefinanceiro(0).situacaoCrediario = "N" Then
                                    linha.Cells("cid").Style.ForeColor = Color.Red
                                    linha.Cells("Nome").Style.ForeColor = Color.Red
                                Else
                                    parcelasVencidas = regrasCrediario.ConsultarParcelasVencidas(cliente.cid)
                                    If Not IsNothing(parcelasVencidas) Then
                                        For Each dadosParcela As dParcelas In parcelasVencidas
                                            If dadosParcela.valorReceber > 0 Then
                                                linha.Cells("cid").Style.ForeColor = Color.Orange
                                                linha.Cells("Nome").Style.ForeColor = Color.Orange
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                            linha.Cells("cid").Value = cliente.cid
                            linha.Cells("Nome").Value = cliente.nome
                            linha.Cells("Cpf").Value = cliente.cpf
                            linha.Cells("Rg").Value = cliente.rg
                            linha.Cells("Situacao").Value = cliente.situacao
                            linha.Cells("Ddd").Value = cliente.ddd
                            linha.Cells("Telefone").Value = cliente.telefone
                            linha.Cells("Dddcel").Value = cliente.dddcel
                            linha.Cells("Celular").Value = cliente.celular
                            linha.Cells("Email").Value = cliente.email
                        End If
                    End If
                Next
            End If

            dgvCliente.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Clientes.")

        End Try
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btoMalaDireta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoMalaDireta.Click
        Dim janelaMalaDireta As New fClienteMalaDireta
        janelaMalaDireta.listaClientes = clientes
        mdiPrincipal.FecharTela()
        mdiPrincipal.formulario = janelaMalaDireta
        mdiPrincipal.AbrirTela()
        'janelaMalaDireta.Show()

    End Sub

End Class