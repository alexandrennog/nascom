Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsCor
Imports ncRegras.nsCor
Imports ncDados.nsProdutoEtiqueta
Imports ncRegras.nsProdutoEtiqueta
Imports ncDados.nsEtiquetaProdutoImpressao
Imports ncComum.nsExcecao
Imports ncComum.nsEtiqueta
Imports ncComum.nsFuncoes.cFuncoes
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fProdutoEtiquetaES

    Private Sub fProdutoEtiquetaES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub fProdutoEtiquetaES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtDataDe.Text = DateAdd(DateInterval.Day, -1, Today).ToString("dd/MM/yyyy")
        Me.txtDataAte.Text = DateAdd(DateInterval.Day, 1, Today).ToString("dd/MM/yyyy")

        If ValidarCampos() = True Then

            ListarProdutos()
        End If
    End Sub

    Private Function ValidarCampos() As Boolean
        Dim retorno As Boolean = True
        Dim data As DateTime = Nothing

        Try

            If Not txtDataDe.Text.Equals(String.Empty) Then
                If Not ValidarData(txtDataDe.Text) = True Then
                    MessageBox.Show("Data inicial inválida!", "Impressão de etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    retorno = False
                    Exit Try
                End If
            End If

            If Not txtDataAte.Text.Equals(String.Empty) Then
                If Not ValidarData(txtDataAte.Text) = True Then
                    MessageBox.Show("Data final inválida!", "Impressão de etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    retorno = False
                    Exit Try
                End If
            End If

        Catch ex As Exception
            retorno = False
        End Try

        ValidarCampos = retorno
    End Function

    Private Sub ListarProdutos()
        Dim regras As rProdutoEtiqueta
        Dim colecao As ColecaoProdutoEtiqueta
        Dim linha As DataGridViewRow
        Dim dataDe As String = Nothing
        Dim dataAte As String = Nothing
        Dim ImprimeTodos As Integer = 0


        Try

            dgvProdutos.Rows.Clear()

            If txtDataDe.Text.Trim().Equals(String.Empty) = False Then
                dataDe = FormatarData(txtDataDe.Text)
            End If

            If txtDataAte.Text.Trim().Equals(String.Empty) = False Then
                dataAte = FormatarData(txtDataAte.Text)
            End If

            ImprimeTodos = rdbTodos.Checked

            regras = New rProdutoEtiqueta
            colecao = regras.Listar(dataDe, dataAte, ImprimeTodos)

            If Not IsNothing(colecao) Then
                For Each produto As dProdutoEtiqueta In colecao
                    linha = dgvProdutos.Rows(dgvProdutos.Rows.Add())
                    linha.Cells("data").Value = produto.data
                    linha.Cells("impressao").Value = IIf(produto.impressao Is Nothing, "N", produto.impressao)
                    linha.Cells("produto_cid").Value = produto.produto_cid
                    linha.Cells("produtoItem_codigoBarras").Value = produto.produtoItem_codigoBarras
                    linha.Cells("quantidade").Value = produto.quantidade
                    linha.Cells("referencia").Value = produto.referencia
                    linha.Cells("cor").Value = produto.cor
                    'linha.Cells("usuario_cid").Value = produto.usuario_cid
                    'linha.Cells("usuario_nomeCompleto").Value = produto.usuario_nomeCompleto
                Next
            End If

            dgvProdutos.Refresh()

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta da lista de Produtos.")

        End Try
    End Sub

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub btoImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImprimir.Click

        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim tamanhoEtiqueta As String
        Dim imprimeDataEtiqueta As String
        Dim etiqueta As EtiquetaProduto
        Dim regraPE As rProdutoEtiqueta
        Dim colecaoEtiquetas As ColecaoEtiquetaProdutoImpressao = New ColecaoEtiquetaProdutoImpressao()
        Dim etiquetaProdutoImpressao As dEtiquetaProdutoImpressao

        Dim loja As String = String.Empty
        Dim fabricante As String = String.Empty
        Dim produto As dProduto = New dProduto()
        Dim colecaoItem As ColecaoProdutoItem = New ColecaoProdutoItem()
        Dim quantidade As Decimal = 0

        Dim check As Boolean = False
        Dim produto_cid As Integer = 0
        Dim impressao As String = String.Empty
        Dim codigoBarras As String = String.Empty
        Dim data As String = String.Empty

        Dim regraP As rProduto = New rProduto()
        Dim regraPI As rProdutoItem = New rProdutoItem()
        Dim regraF As rFabricante = New rFabricante()
        Dim dadosPI As dProdutoItem = New dProdutoItem()
        Dim dadosF As dFabricante = New dFabricante()
        Dim regraC As rCor = New rCor()
        Dim dadosC As dCor = New dCor()
        Dim imprimirPreco As Boolean

        Try

            If MessageBox.Show("Confirma impressão de etiquetas?", "Impressão de Etiquetas", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                etiqueta = New EtiquetaProduto()
                regraPE = New rProdutoEtiqueta()

                loja = mdiPrincipal.gLoja.nomeFantasia

                For Each linha As DataGridViewRow In dgvProdutos.Rows

                    check = linha.Cells("check").Value
                    codigoBarras = linha.Cells("produtoItem_codigoBarras").Value

                    If check = True Then
                        impressao = linha.Cells("impressao").Value
                        produto_cid = linha.Cells("produto_cid").Value
                        quantidade = linha.Cells("quantidade").Value
                        data = linha.Cells("data").Value

                        etiqueta = New EtiquetaProduto()
                        regraP = New rProduto()
                        regraPI = New rProdutoItem()
                        dadosPI = New dProdutoItem()
                        regraF = New rFabricante()
                        dadosF = New dFabricante()
                        regraC = New rCor()
                        dadosC = New dCor()

                        produto = regraP.Consultar(produto_cid)
                        dadosF = regraF.Consultar(produto.fabricante_cid)
                        dadosC = regraC.Consultar(produto.cor_cid)
                        colecaoItem = regraPI.ConsultarProdutoItem(Nothing, codigoBarras, Nothing, False)
                        dadosPI.produtos_cid = colecaoItem(0).produtos_cid
                        dadosPI.item = colecaoItem(0).item
                        colecaoItem = regraPI.Consultar(dadosPI)
                        fabricante = dadosF.nome

                        For i As Integer = 1 To quantidade
                            '-- Colocar todas as etiquetas na coleção (não imprime agora) ------------
                            etiquetaProdutoImpressao = New dEtiquetaProdutoImpressao()

                            etiquetaProdutoImpressao.loja = loja
                            etiquetaProdutoImpressao.fabricante = fabricante
                            etiquetaProdutoImpressao.produto = produto
                            etiquetaProdutoImpressao.colecaoProdutoItem = colecaoItem
                            etiquetaProdutoImpressao.corNome = dadosC.nome
                            etiquetaProdutoImpressao.data = data
                            etiquetaProdutoImpressao.produto_cid = produto_cid.ToString()
                            etiquetaProdutoImpressao.codigoBarras = codigoBarras

                            colecaoEtiquetas.Add(etiquetaProdutoImpressao)
                            '--------------------------------------------------------------------------
                        Next
                    End If
                Next

                imprimirPreco = (MessageBox.Show("Imprimir Preço?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes)

                ' Tamanho Etiqueta
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.TamanhoEtiqueta)
                If Not IsNothing(dadosParametro) Then
                    tamanhoEtiqueta = dadosParametro.valor
                Else
                    tamanhoEtiqueta = ""
                End If

                ' Imprime data etiqueta
                dadosParametro = regraParametro.Consultar(cConstantes.Parametros.ImprimeDataEtiqueta)
                If Not IsNothing(dadosParametro) Then
                    imprimeDataEtiqueta = dadosParametro.valor
                Else
                    imprimeDataEtiqueta = ""
                End If

                '-- Imprimir coleção de etiquetas
                etiqueta.ImprimirColecaoEtiquetaProduto(colecaoEtiquetas, imprimirPreco, tamanhoEtiqueta, imprimeDataEtiqueta)

                If MessageBox.Show("As etiquetas foram impressas com sucesso?", "Impressão de Etiquetas", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    For Each itemEtiqueta As dEtiquetaProdutoImpressao In colecaoEtiquetas
                        '-- Atualizar situação (impresso: Sim/Nao) do registro
                        regraPE.fAlterar(itemEtiqueta.data, itemEtiqueta.produto_cid, itemEtiqueta.codigoBarras)
                    Next
                End If

                ListarProdutos()

            End If

        Catch ex As Exception

            MessageBox.Show("Não foi possível imprimir as etiquetas!", "Impressão de etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub
    Private Sub marcarTodos(ByVal mark As Integer)
        For Each linha As DataGridViewRow In dgvProdutos.Rows
            linha.Cells("check").Value = mark
        Next
    End Sub
    Private Sub btoPesquisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoPesquisar.Click
        If ValidarCampos() = True Then
            ListarProdutos()
        End If
    End Sub

    Private Sub chkMarcarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarTodos.CheckedChanged
        marcarTodos(chkMarcarTodos.Checked)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub rdbNaoImpresso_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNaoImpresso.CheckedChanged
        If ValidarCampos() = True Then
            ListarProdutos()
        End If
    End Sub

    Private Sub rdbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTodos.CheckedChanged
        If ValidarCampos() = True Then
            ListarProdutos()
        End If
    End Sub
End Class