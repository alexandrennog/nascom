Imports ncComum.nsExcecao

Public Class fConfiguracaoes

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub fProdutoLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, rbtCores.KeyDown, rbtParametros.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.Enter
                SelecionarItem()
        End Select
    End Sub

    Private Sub SelecionarItem()

        If rbtParametros.Checked Then
            mdiPrincipal.CarregarParametros()
        ElseIf rbtCores.Checked Then
            mdiPrincipal.CarregarCorFiltro()
        ElseIf rbtGrupo.Checked Then
            mdiPrincipal.CarregarEstadoFiltro()
        ElseIf rbtTipoProduto.Checked Then
            mdiPrincipal.CarregarProdutoTipoFiltro()
        ElseIf rbtCaracteristicas.Checked Then
            mdiPrincipal.CarregarCaracteristicaFiltro()
        ElseIf rbtCondicoes.Checked Then
            mdiPrincipal.CarregarCondicaoFiltro()
        ElseIf rbtBackup.Checked Then
            mdiPrincipal.CarregarBackup()
        ElseIf rbtFabricantes.Checked Then
            mdiPrincipal.CarregarFabricanteFiltro()
        ElseIf rbtCategorias.Checked Then
            mdiPrincipal.CarregarCategoriaFiltro()
        ElseIf rbtChaveValidacao.Checked Then
            mdiPrincipal.CarregarChaveValidacao()
        ElseIf rbtPIx.Checked Then
            mdiPrincipal.CarregarPix()
        ElseIf rbtEmpresas.Checked Then
            mdiPrincipal.CarregarEmpresaFiltro()
        End If
    End Sub


    Private Sub btoFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoFiltro.Click
        SelecionarItem()
    End Sub

    Private Sub rbtCategorias_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCategorias.CheckedChanged

    End Sub

    Private Sub rbtCores_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCores.CheckedChanged

    End Sub
End Class