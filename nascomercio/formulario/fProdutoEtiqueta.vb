Imports ncDados.nsDados
Imports ncRegras.nsRegras
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsCrediario
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsEtiqueta
Imports ncComum.Impressao
Imports ncComum.nsExcecao
Imports ncDados.nsCor
Imports ncRegras.nsCor
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes

Public Class fProdutoEtiqueta

    Public produto_cid As Nullable(Of Integer)
    Public item As Nullable(Of Integer)

    Private Sub btoSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoSair.Click
        Me.Close()
    End Sub

    Private Sub btoImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim dadosParametro As dParametro
        Dim regraParametro As New rParametro
        Dim tamanhoEtiqueta As String
        Dim imprimeDataEtiqueta As String

        Dim etiqueta As EtiquetaProduto
        Dim produto As dProduto
        Dim regraP As rProduto
        Dim regraPI As rProdutoItem
        Dim colecaoItem As ColecaoProdutoItem
        Dim dadosPI As dProdutoItem
        Dim regraF As rFabricante
        Dim dadosF As dFabricante
        Dim quantidade As Decimal

        Dim regraC As rCor = New rCor()
        Dim dadosC As dCor = New dCor()
        Dim imprimirPreco As Boolean

        Try

            If Integer.TryParse(txtQuantidade.Text, quantidade) Then
                If MessageBox.Show("Imprimir etiquetas?", "NasComercio", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    etiqueta = New EtiquetaProduto()
                    produto = New dProduto()
                    regraP = New rProduto()
                    regraPI = New rProdutoItem()
                    dadosPI = New dProdutoItem()
                    regraF = New rFabricante()
                    dadosF = New dFabricante()
                    colecaoItem = New ColecaoProdutoItem()
                    regraC = New rCor()
                    dadosC = New dCor()

                    produto = regraP.Consultar(Me.produto_cid)

                    dadosF = regraF.Consultar(produto.fabricante_cid)

                    dadosC = regraC.Consultar(produto.cor_cid)
                    colecaoItem = regraPI.ConsultarProdutoItem(Nothing, txtCodigoBarras.Text, Nothing, False)
                    dadosPI.produtos_cid = colecaoItem(0).produtos_cid
                    dadosPI.item = colecaoItem(0).item
                    colecaoItem = regraPI.Consultar(dadosPI)

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

                    etiqueta.ImprimirEtiquetaProduto(mdiPrincipal.gLoja.nomeFantasia, dadosF.nome, produto, colecaoItem, txtQuantidade.Text, dadosC.nome, imprimirPreco, tamanhoEtiqueta, imprimeDataEtiqueta)
                End If
            Else
                MessageBox.Show("Quantidade inválida.", "Impressão de Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Não foi possível imprimir as etiquetas.", "Impressão de Etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub fProdutoEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarDadosProduto()
    End Sub

    Private Sub CarregarDadosProduto()
        Dim regras As rProduto
        Dim dados As dProduto
        Dim regrasItem As rProdutoItem
        Dim dadosItem As dProdutoItem
        Dim colecao As ColecaoProdutoItem

        Try

            If Not Me.produto_cid.Equals(Nothing) Then
                If Not Me.produto_cid.Equals(0) Then

                    regras = New rProduto()

                    dados = regras.Consultar(Me.produto_cid)

                    txtProduto.Text = dados.descricao
                End If
            End If

            If Not Me.item.Equals(Nothing) Then
                regrasItem = New rProdutoItem()
                dadosItem = New dProdutoItem()

                dadosItem.produtos_cid = Me.produto_cid
                dadosItem.item = Me.item

                colecao = regrasItem.Consultar(dadosItem)

                For Each dadosItem In colecao
                    If dadosItem.caracteristicas_codigo.Equals("codigoBarras") Then
                        txtCodigoBarras.Text = dadosItem.valor
                    End If
                Next
            End If

        Catch nex As ExcecaoNascomercio

            MessageBox.Show(nex.Message)

        Catch ex As Exception

            MessageBox.Show("Erro na consulta dos dados de Produto.")

        End Try
    End Sub


    Private Sub fProdutoEtiqueta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Imprimir()
        End Select

    End Sub
End Class