Imports ncRegras.nsProduto
Imports ncDados.nsProduto
Imports ncComum.nsExcecao

Public Class fProdutoEntradaSaidaLista

    Public filtro As dProduto
    Private produto_cid As Integer

    Private Sub fProdutoEntradaSaidaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim regras As rProduto
        Dim produtos As ColecaoProduto
        Dim linha As DataGridViewRow

        Try

            regras = New rProduto

            produtos = regras.Consultar(filtro)
            If Not IsNothing(produtos) Then
                For Each produto As dProduto In produtos
                    linha = dgvProduto.Rows(dgvProduto.Rows.Add())
                    linha.Cells("cid").Value = produto.cid
                    linha.Cells("codigo").Value = produto.codigo
                    linha.Cells("descricao").Value = produto.descricao
                    linha.Cells("referencia").Value = produto.referencia
                    If produto.valorCompra.HasValue = True Then
                        linha.Cells("valorCompra").Value = produto.valorCompra.Value.ToString("N")
                    End If
                    If produto.valorVenda.HasValue = True Then
                        linha.Cells("valorVenda").Value = produto.valorVenda.Value.ToString("N")
                    End If
                    linha.Cells("cor").Value = produto.cor
                    linha.Cells("efdCategoria").Value = produto.efdCategoria
                Next
            End If
            dgvProduto.Refresh()
            ExibirInformacoesTela()
        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Produtos.")

        End Try

    End Sub
    Private Sub ExibirInformacoesTela()
        If mdiPrincipal.gUsuario.usuarioPerfil_codigo = "c" Then
            btoBalanco.Visible = False
        End If
    End Sub
    Private Sub fProdutoEntradaSaidaLista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                mdiPrincipal.FecharTela()
            Case Keys.F1
                Transferir()
            Case Keys.Enter
                AtualizarEstoque()
            Case Keys.F5
                CarregarProdutoEntradaSaidaFiltro()
            Case Keys.F8
                CarregarProdutoBalancoFiltro()
        End Select
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        mdiPrincipal.FecharTela()
    End Sub

    Private Sub CarregarProdutoEntradaSaidaFiltro()
        mdiPrincipal.CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        CarregarProdutoEntradaSaidaFiltro()
    End Sub

    Private Sub btoTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoTransferir.Click
        Transferir()
    End Sub

    Private Sub btoEstoque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoEstoque.Click
        AtualizarEstoque()
    End Sub

    Private Sub Transferir()
        If SelecionarProduto() = True Then

            fProdutoEntradaSaidaTransferencia.produto_cid = Me.produto_cid

            mdiPrincipal.CarregarProdutoEntradaSaidaTransferencia()

        End If
    End Sub

    Private Sub AtualizarEstoque()
        If SelecionarProduto() = True Then

            fProdutoEntradaSaidaEstoque.produto_cid = Me.produto_cid

            mdiPrincipal.CarregarProdutoEntradaSaidaEstoque()

        End If
    End Sub

    Private Function SelecionarProduto() As Boolean
        Dim indice As Integer
        Dim linha As DataGridViewRow
        Dim retorno As Boolean = False

        If dgvProduto.Rows.Count > 0 Then
            indice = dgvProduto.CurrentRow.Index

            linha = dgvProduto.Rows(indice)

            produto_cid = linha.Cells("cid").Value

            retorno = True
        End If

        SelecionarProduto = retorno
    End Function

    Private Sub btoBalanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoBalanco.Click
        CarregarProdutoBalancoFiltro()
    End Sub

    Private Sub CarregarProdutoBalancoFiltro()
        mdiPrincipal.CarregarProdutoBalancoFiltro()
    End Sub

End Class