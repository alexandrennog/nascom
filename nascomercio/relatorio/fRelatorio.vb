Imports ncComum.nsExcecao
Imports ncComum.DFW

Public Class fRelatorio

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, rbtMaisVendidos.KeyDown, rbtEstoque.KeyDown, rbtCrediario.KeyDown, rbtClientes.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.Enter
                SelecionarItem()
        End Select
    End Sub

    Private Sub SelecionarItem()

        If rbtCrediario.Checked Then
            mdiPrincipal.Crediario()
        ElseIf rbtEstoque.Checked Then
            mdiPrincipal.CarregarEstoque()
        ElseIf rbtCategoria.Checked Then
            mdiPrincipal.CarregarGrupoProduto()
        ElseIf rbtFechamento.Checked Then
            mdiPrincipal.CarregarFechamento()
        ElseIf rbtClientes.Checked Then
            mdiPrincipal.CarregarClientes()
        ElseIf rbtMaisVendidos.Checked Then
            mdiPrincipal.CarregarVendas("")
        ElseIf rdbVendasSintetico.Checked Then
            mdiPrincipal.CarregarVendasSintetico("")
        ElseIf rbtVendasVendedor.Checked Then
            mdiPrincipal.CarregarVendasVendedor("")
        ElseIf rbtNegativar.Checked Then
            mdiPrincipal.CarregarClientesNegativar()
        ElseIf rbtVendasPendentes.Checked Then
            mdiPrincipal.CarregarVendasPendentes()
        ElseIf rbtCheques.Checked Then
            mdiPrincipal.CarregarCheques("")
        ElseIf rbtAuditoria.Checked Then
            mdiPrincipal.CarregarAuditoria()
        ElseIf rbtGrade.Checked Then
            mdiPrincipal.CarregarRelatorioGrade()
        ElseIf rbtBalanco.Checked Then
            mdiPrincipal.CarregarRelatorioBalanco()
        ElseIf rbtSPED.Checked Then
            mdiPrincipal.CarregarTelaSPED()
        ElseIf rbtNFe.Checked Then
            mdiPrincipal.CarregarTelaNFe()
        ElseIf rbtConsultaVendas.Checked Then
            mdiPrincipal.ConsultaVendas()
        ElseIf rdbVendasFabricantes.Checked Then
            mdiPrincipal.CarregarGrupoProduto()
        ElseIf rbtTransferencia.Checked Then
            mdiPrincipal.CarregarTransferencia()
        ElseIf rbtLeituraX.Checked Then
            Declaracoes.iRetorno = Declaracoes.iLeituraX_ECF_Daruma()
            If Declaracoes.iRetorno <> 1 Then
                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
            End If
        ElseIf rbtReducaoZ.Checked Then
            Declaracoes.iRetorno = Declaracoes.iReducaoZ_ECF_Daruma("", "")
            If Declaracoes.iRetorno <> 1 Then
                MessageBox.Show(Declaracoes.TrataRetorno(Declaracoes.iRetorno))
            End If
        ElseIf rbtSAT.Checked Then
            mdiPrincipal.CarregarVendaSAT()
        ElseIf rbtPix.Checked Then
            mdiPrincipal.CarregarRelPix()
        ElseIf rbtCrediarioPix.Checked Then
            mdiPrincipal.CarregarRelCrediPix()
        ElseIf rbtCobrancaPIX.Checked Then
            mdiPrincipal.CarregarRelCobrancaCrediarioPix()
        ElseIf rbtVendasPorVendedor.Checked Then
            mdiPrincipal.CarregarRelVendasPorVendedor()
        ElseIf rbtVendasPorLoja.Checked Then
            mdiPrincipal.CarregarRelVendasPorLoja()
        End If





    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        SelecionarItem()
    End Sub

    Private Sub fRelatorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case mdiPrincipal.gUsuario.usuarioPerfil_codigo
            Case "a", "g"
                rbtCrediario.Visible = True
                rbtEstoque.Visible = True
                rbtFechamento.Visible = True
                rbtClientes.Visible = True
                rbtMaisVendidos.Visible = True
                rdbVendasSintetico.Visible = True
                rbtNegativar.Visible = True
                rbtVendasPendentes.Visible = True
                rbtCheques.Visible = True
                If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
                    rbtLeituraX.Visible = True
                    rbtReducaoZ.Visible = True
                    rbtSAT.Visible = False
                ElseIf System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "SAT" Then
                    rbtLeituraX.Visible = False
                    rbtReducaoZ.Visible = False
                    rbtSAT.Visible = True
                Else
                    rbtSAT.Visible = False
                    rbtLeituraX.Visible = False
                    rbtReducaoZ.Visible = False
                End If

                If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "a" Then
                    rbtAuditoria.Visible = True
                Else
                    rbtAuditoria.Visible = False
                End If
            Case "c"
                rbtCrediario.Visible = True
                rbtEstoque.Visible = True
                rbtFechamento.Visible = True
                rbtClientes.Visible = False
                rdbVendasSintetico.Visible = False
                rbtMaisVendidos.Visible = False
                rbtNegativar.Visible = False
                rbtVendasPendentes.Visible = True
                rbtCheques.Visible = True
                rbtAuditoria.Visible = False
                rbtLeituraX.Visible = True
                rbtReducaoZ.Visible = True
                rbtCobrancaPIX.Visible = True
                If System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "ECF" Then
                    rbtLeituraX.Visible = True
                    rbtReducaoZ.Visible = True
                    rbtSAT.Visible = False
                ElseIf System.Configuration.ConfigurationManager.AppSettings("FISCAL") = "SAT" Then
                    rbtLeituraX.Visible = False
                    rbtReducaoZ.Visible = False
                    rbtSAT.Visible = True
                Else
                    rbtSAT.Visible = False
                    rbtLeituraX.Visible = False
                    rbtReducaoZ.Visible = False
                End If
        End Select
    End Sub

    Private Sub rbtPix_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPix.CheckedChanged

    End Sub

    Private Sub rbtCrediarioPix_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCrediarioPix.CheckedChanged

    End Sub

    Private Sub rbtCobrancaPIX_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCobrancaPIX.CheckedChanged

    End Sub

    Private Sub rbtVendasPorVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVendasPorVendedor.CheckedChanged

    End Sub
End Class