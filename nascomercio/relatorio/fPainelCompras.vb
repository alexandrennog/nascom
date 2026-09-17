Imports ncRegras.nsDashboardCompras
Imports ncDados.nsDashboardCompras
Imports ncComum.nsExcecao
Imports ncComum.nsFuncoes

' Painel de Compras: responde direto (sem precisar interpretar um relatorio
' cru) o que a cliente pediu - ticket medio, marca campea e o que precisa
' repor. Reaproveita as procedures sp_dashboard_compras_resumo e
' sp_dashboard_compras_reposicao (script "38 - dashboard_compras.sql"), que por
' sua vez reaproveitam sp_curva_abc / sp_curva_abc_por_fabricante (script
' "37 - curva_abc_unificada.sql").
Public Class fPainelCompras

    Private Sub ConfigurarListView()
        Me.lstReposicao.View = View.Details
        Me.lstReposicao.GridLines = True
        Me.lstReposicao.FullRowSelect = True
        Me.lstReposicao.Columns.Clear()
        Me.lstReposicao.Items.Clear()

        Me.lstReposicao.Columns.Add("Referência").Width = 90
        Me.lstReposicao.Columns.Add("Descrição").Width = 220
        Me.lstReposicao.Columns.Add("Fabricante").Width = 130
        Me.lstReposicao.Columns.Add("Qtd. Vendida").Width = 90
        Me.lstReposicao.Columns.Add("Estoque Atual").Width = 90
        Me.lstReposicao.Columns.Add("Classe").Width = 60
    End Sub

    Private Sub LimparResumo()
        Me.lblFaturamentoValor.Text = "-"
        Me.lblTicketMedioValor.Text = "-"
        Me.lblQtdVendasValor.Text = "-"
        Me.lblMarcaValorValor.Text = "-"
        Me.lblMarcaQtdValor.Text = "-"
    End Sub

    Private Sub Atualizar()
        Dim dataIni As String
        Dim dataFim As String
        Dim regras As New rDashboardCompras
        Dim resumo As dDashboardResumo
        Dim reposicao As ColecaoDashboardReposicao

        Try
            ConfigurarListView()
            LimparResumo()

            dataIni = cFuncoes.FormatarData(txtDataInicial.Text)
            dataFim = cFuncoes.FormatarData(txtDataFinal.Text)

            resumo = regras.ConsultarResumo(dataIni, dataFim)

            If Not resumo Is Nothing Then
                Me.lblFaturamentoValor.Text = resumo.faturamentoTotal.ToString("N2")
                Me.lblTicketMedioValor.Text = resumo.ticketMedio.ToString("N2")
                Me.lblQtdVendasValor.Text = resumo.qtdVendas.ToString()

                If Not String.IsNullOrEmpty(resumo.marcaCampeaValor) Then
                    Me.lblMarcaValorValor.Text = resumo.marcaCampeaValor & " (R$ " & resumo.marcaCampeaValorTotal.ToString("N2") & ")"
                End If

                If Not String.IsNullOrEmpty(resumo.marcaCampeaQuantidade) Then
                    Me.lblMarcaQtdValor.Text = resumo.marcaCampeaQuantidade & " (" & resumo.marcaCampeaQuantidadeTotal.ToString("N0") & " un.)"
                End If
            End If

            reposicao = regras.ListarReposicao(dataIni, dataFim)

            If Not reposicao Is Nothing Then
                For Each item As dDashboardReposicaoItem In reposicao
                    Dim li As New ListViewItem(item.referencia)
                    li.SubItems.Add(item.descricao)
                    li.SubItems.Add(item.fabricante)
                    li.SubItems.Add(item.quantidadeVendida.ToString("N0"))
                    li.SubItems.Add(item.estoqueAtual.ToString("N0"))
                    li.SubItems.Add(item.classeAbc)
                    Me.lstReposicao.Items.Add(li)
                Next
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show("Erro ao carregar o painel de compras: " & nex.Message,
                             "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception

            MessageBox.Show("Erro inesperado no painel de compras: " & ex.Message,
                             "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub fPainelCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDataInicial.Text = New DateTime(Today.Year, Today.Month, 1).ToString("dd/MM/yyyy")
        Me.txtDataFinal.Text = Today.ToString("dd/MM/yyyy")

        Atualizar()
    End Sub

    Private Sub btoAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoAtualizar.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Atualizar()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub fPainelCompras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F5
                Atualizar()
        End Select
    End Sub

End Class
