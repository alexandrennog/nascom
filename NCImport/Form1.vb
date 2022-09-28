Imports System.IO
Imports ncDados.nsFabricante
Imports ncRegras.nsFabricante
Imports ncDados.nsCor
Imports ncRegras.nsCor
Imports ncDados.nsCheques
Imports ncRegras.nsCheques
Imports ncDados.nsGrupo
Imports ncRegras.nsGrupo
Imports ncDados.nsFornecedor
Imports ncRegras.nsFornecedor
Imports ncDados.nsEstado
Imports ncRegras.nsEstado
Imports ncDados.nsProduto
Imports ncRegras.nsProduto
Imports ncDados.nsCrediario
Imports ncRegras.nsCrediario
Imports ncDados.nsCliente
Imports ncRegras.nsCliente
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum

Public Class Form1

    Private colecaoItensProdutos As ColecaoItensProdutos
    Private dadosProduto As dProduto
    Private itensProduto As String
    Private caracs As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789. ^~`¥-_&+[]{}(),!@#*?%:$;<>√¡¿ƒ¬…»À ÕÃœŒ’”“÷‘⁄Ÿ‹€«„·‡‰‚ÈËÎÍÌÏÔÓıÛÚˆÙ˙˘¸˚Á"
    'Private carEsp As String = "√¡¿ƒ¬…»À ÕÃœŒ’”“÷‘⁄Ÿ‹€«„·‡‰‚ÈËÎÍÌÏÔÓıÛÚˆÙ˙˘¸˚Á'"
    'Private carSub As String = "AAAAAEEEEIIIIOOOOOUUUUCaaaaaeeeeiiiiooooouuuuc`"
    Private carEsp As String = "'µß¶êÄâ/\""" '
    Private carSub As String = "`√oa…«    " '

    Private Sub btoArquivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoArquivo.Click
        ofd.ShowDialog()
        txtArquivo.Text = ofd.FileName
    End Sub

    Private Sub btoImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImportar.Click
        If ValidarDados() Then
            Select Case cboTipo.SelectedItem.ToString().Trim().ToLower()
                Case "cor"
                    ImportarCor()
                Case "fabricante"
                    ImportarFabricante()
                Case "fornecedor"
                    ImportarFornecedor()
                Case "grupo"
                    ImportarGrupo()
                Case "produto"
                    ImportarProduto2()
                Case "cliente"
                    ImportarArquivoCliente()
                Case "crediario"
                    ImportarArquivoCrediario()
                Case "prodcor-bd"
                    ImportarBDProdCor()
                Case "cheques"
                    ImportarCheques()
            End Select
        End If
    End Sub

    Private Function ValidarDados() As Boolean
        Try
            If IO.File.Exists(txtArquivo.Text) Then
                Return ValidarImportacao()
            Else
                MessageBox.Show("Erro na validaÁ„o [Arquivo n„o encontrado]")
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Erro na validaÁ„o [" & Err.Description & "]")
            Return False
        End Try
    End Function

    Private Sub ImportarFabricante()
        Dim conteudo As IO.StreamReader = Nothing
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dFabricante
        Dim regras As rFabricante = New rFabricante()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dFabricante()
                dados.nome = linha.Substring(31, 15).Trim()

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    regras.Incluir(dados)
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de Fabricantes concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImportarCor()
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dCor
        Dim regras As rCor = New rCor()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dCor()
                dados.cid = Convert.ToInt32(linha.Substring(0, 4).Trim())
                dados.nome = linha.Substring(4, 15).Trim()

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    regras.Importar(dados)
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de Cores concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImportarCheques()
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dCheques
        Dim regras As rCheques = New rCheques()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dCheques()
                If linha.Substring(8, 6).Trim() <> "" Then
                    dados.clienteId = linha.Substring(8, 6).Trim()
                    If ((linha.Substring(20, 2) + linha.Substring(18, 2) + linha.Substring(14, 4)) = "00000000") Then
                        dados.dataDeposito = VerificarData("01", "01", "1900")
                    Else
                        dados.dataDeposito = VerificarData(linha.Substring(20, 2), linha.Substring(18, 2), linha.Substring(14, 4))
                    End If
                    dados.dataEmissao = Now().Year.ToString().PadLeft(4, "0"c) + "-" + _
                      Now().Month.ToString().PadLeft(2, "0"c) + "-" + _
                      Now().Day.ToString().PadLeft(2, "0"c) + " " + _
                      Now().Hour.ToString().PadLeft(2, "0"c) + ":" + _
                      Now().Minute.ToString().PadLeft(2, "0"c) + ":" + _
                      Now().Second.ToString().PadLeft(2, "0"c)
                    dados.bancoCodigo = linha.Substring(28, 6).Trim()
                    dados.bancoNome = linha.Substring(34, 10).Trim()
                    dados.Numero = linha.Substring(44, 10).Trim()
                    dados.valor = CDec(linha.Substring(54, 11).Trim() + "," + linha.Substring(65, 2).Trim())
                    dados.baixado = IIf(linha.Substring(67, 1).Trim() = "", "N", linha.Substring(67, 1).Trim())
                    'dados.vendasId = 
                    'dados.agencia = 
                    'dados.conta = 

                    regras.Incluir(dados)

                    barra.Increment(linha.Length)
                End If
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de Cheques concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImportarFornecedor()
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dFornecedor
        Dim regras As rFornecedor = New rFornecedor()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dFornecedor()
                dados.cid = Convert.ToInt32(linha.Substring(0, 3).Trim())

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    dados.nome = linha.Substring(3, 30).Trim()
                    dados.logradouro = linha.Substring(33, 40).Trim()
                    dados.bairro = linha.Substring(73, 20).Trim()
                    'dados.cidade = linha.Substring(93, 20).Trim()
                    dados.cep = linha.Substring(113, 8).Trim()

                    '-- sigla uf
                    Dim dadosEstado As dEstado = New dEstado()
                    Dim regrasEstado As rEstado = New rEstado()
                    Dim colEstado As ColecaoEstado

                    dadosEstado.sigla = linha.Substring(121, 2).Trim()
                    colEstado = regrasEstado.Consultar(dadosEstado)
                    If colEstado IsNot Nothing Then
                        If colEstado.Count > 0 Then
                            dados.estado_cid = colEstado(0).cid
                        End If
                    End If

                    dados.cnpj = linha.Substring(123, 14).Trim()
                    dados.inscricaoEstadual = linha.Substring(137, 12).Trim()
                    dados.telefone = linha.Substring(149, 20).Trim()
                    dados.nomeContato = linha.Substring(169, 15).Trim()
                    regras.Importar(dados)
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de Fornecedores concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImportarGrupo()
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dGrupo
        Dim regras As rGrupo = New rGrupo()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dGrupo()
                dados.cid = Convert.ToInt32(linha.Substring(0, 3).Trim())

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    dados.nome = linha.Substring(3, 15).Trim()
                    regras.Importar(dados)
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de Grupos concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ValidarProduto() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim regras As rProduto = New rProduto()
        Dim itens As String
        Dim numLinha As Integer = 0
        '-- cor
        Dim dadosCor As dCor = New dCor()
        Dim regrasCor As rCor = New rCor()
        Dim colCor As ColecaoCor
        '-- fabricante
        Dim dadosFab As dFabricante = New dFabricante()
        Dim regrasFab As rFabricante = New rFabricante()
        Dim colFab As ColecaoFabricante

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()
            numLinha += 1

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 1673)
                linha = ValidarCaracteres(linha)

                dadosProduto = New dProduto()
                dadosProduto.cid = linha.Substring(0, 6).Trim()
                dadosProduto.codigo = Convert.ToInt32(linha.Substring(0, 6).Trim()).ToString()
                dadosProduto.fornecedor_cid = linha.Substring(6, 3).Trim()
                dadosProduto.descricao = linha.Substring(9, 20).Trim()
                dadosProduto.grupo_cid = linha.Substring(61, 3).Trim()
                dadosProduto.referencia = linha.Substring(82, 15).Trim()
                dadosProduto.dataInclusao = Now().Year.ToString().PadLeft(4, "0"c) + "-" + _
                  Now().Month.ToString().PadLeft(2, "0"c) + "-" + _
                  Now().Day.ToString().PadLeft(2, "0"c) + " " + _
                  Now().Hour.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Minute.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Second.ToString().PadLeft(2, "0"c)
                dadosProduto.produtoTipo_cid = 1
                dadosProduto.estoqueMinimo = 0

                '-- cor
                dadosCor = New dCor()
                dadosCor.nome = linha.Substring(130, 15).Trim()
                colCor = regrasCor.Consultar(dadosCor)
                If colCor IsNot Nothing Then
                    If colCor.Count > 0 Then
                        dadosProduto.cor_cid = colCor(0).cid
                    End If
                End If

                '-- fabricante
                dadosFab = New dFabricante()
                dadosFab.nome = linha.Substring(31, 15).Trim()
                colFab = regrasFab.Consultar(dadosFab)
                If colFab IsNot Nothing Then
                    If colFab.Count > 0 Then
                        dadosProduto.fabricante_cid = colFab(0).cid
                    End If
                End If

                dadosProduto.situacao = "A"
                itens = linha.Substring(145, 1464).Trim()

                ValidarProdutoItem(dadosProduto, itens)

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                numLinha += 1
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Produtos concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de produtos [linha " & numLinha.ToString() & "] - " & ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Sub ValidarProdutoItem(ByVal produto As dProduto, ByVal itensProduto As String)
        Dim tamanho As Integer = 0
        Dim contItem As Integer = 0
        Dim item As String = String.Empty
        Dim itemProduto As dProdutoItem
        Dim colecaoPI As ColecaoProdutoItem
        Dim qtde As Integer = 0
        Dim compra As Decimal = 0
        Dim venda As Decimal = 0

        colecaoItensProdutos = New ColecaoItensProdutos()

        Do While itensProduto.Length > 0
            qtde = 0
            compra = 0
            venda = 0
            item = itensProduto.Substring(0, 24)

            qtde = Convert.ToInt32(item.Substring(0, 4))
            compra = Convert.ToDecimal(item.Substring(4, 8) & "," & item.Substring(12, 2))
            venda = Convert.ToDecimal(item.Substring(14, 8) & "," & item.Substring(22, 2))

            '-- ProdutoItem: codigo produto, item, codigo caracteristica, valor

            If (tamanho > 0) And ((compra > 0) Or (venda > 0) Or (qtde > 0)) Then
                colecaoPI = New ColecaoProdutoItem()

                '-- codigo de barras - 1
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 1
                itemProduto.valor = (produto.fornecedor_cid.ToString().PadLeft(3, "0"c) & _
                    produto.codigo.PadLeft(6, "0"c).Substring(1, 5) & _
                    produto.cor_cid.ToString().PadLeft(4, "0"c).Substring(1, 3) & _
                    tamanho.ToString().PadLeft(2, "0"c)).PadLeft(14, "0"c)
                colecaoPI.Add(itemProduto)

                '-- estoque - 2 
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 2
                itemProduto.valor = qtde.ToString()
                colecaoPI.Add(itemProduto)

                '-- tamanho - 3
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 3
                itemProduto.valor = tamanho.ToString()
                colecaoPI.Add(itemProduto)

                contItem += 1
                colecaoItensProdutos.Add(colecaoPI)

                dadosProduto.valorCompra = compra
                dadosProduto.valorVenda = venda
            End If

            tamanho += 1
            itensProduto = itensProduto.Substring(24)
        Loop

    End Sub

    Private Sub btoValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoValidar.Click
        ValidarImportacao()
    End Sub

    Private Function ValidarImportacao() As Boolean
        Try
            Select Case cboTipo.SelectedItem.ToString().Trim().ToLower()
                Case "cor"
                    Return ValidarCor()
                Case "fabricante"
                    Return ValidarFabricante()
                Case "fornecedor"
                    Return ValidarFornecedor()
                Case "grupo"
                    Return ValidarGrupo()
                Case "produto"
                    Return ValidarProduto()
                Case "cliente"
                    Return ValidarArquivoCliente()
                Case "crediario"
                    Return ValidarArquivoCrediario()
                Case "prodcor-bd"
                    Return ValidarBDProdCor()
                Case "cheques"
                    Return ValidarCheques()
            End Select
        Catch ex As Exception
            Return False
        End Try

        Return False
    End Function

    Private Function ValidarFabricante() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dFabricante
        Dim regras As rFabricante = New rFabricante()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 1673)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dFabricante()
                dados.nome = linha.Substring(31, 15).Trim()

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Fabricantes concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Fabricantes [linha " + numLinha.ToString() + "] - " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarBDProdCor() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 136)
                linha = ValidarCaracteres(linha)
                numLinha += 1

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de BDProdCor concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de BDProdCor [linha " + numLinha.ToString() + "] - " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarCor() As Boolean
        Dim conteudo As IO.StreamReader = Nothing
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dCor
        Dim regras As rCor = New rCor()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 19)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dCor()
                dados.cid = Convert.ToInt32(linha.Substring(0, 4).Trim())
                dados.nome = linha.Substring(4, 15).Trim()

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Cores concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Cores [linha " + numLinha.ToString() + "] - " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarCheques() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dCheques
        Dim regras As rCheques = New rCheques()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 68)

                linha = ValidarCaracteres(linha)
                numLinha += 1
                dados = New dCheques()
                If linha.Substring(8, 6).Trim() <> "" Then
                    dados.clienteId = linha.Substring(8, 6).Trim()
                    If ((linha.Substring(20, 2) + linha.Substring(18, 2) + linha.Substring(14, 4)) = "00000000") Then
                        dados.dataDeposito = VerificarData("01", "01", "1900")
                    Else
                        dados.dataDeposito = VerificarData(linha.Substring(20, 2), linha.Substring(18, 2), linha.Substring(14, 4))
                    End If
                    dados.dataEmissao = Now().Year.ToString().PadLeft(4, "0"c) + "-" + _
                      Now().Month.ToString().PadLeft(2, "0"c) + "-" + _
                      Now().Day.ToString().PadLeft(2, "0"c) + " " + _
                      Now().Hour.ToString().PadLeft(2, "0"c) + ":" + _
                      Now().Minute.ToString().PadLeft(2, "0"c) + ":" + _
                      Now().Second.ToString().PadLeft(2, "0"c)
                    dados.bancoCodigo = linha.Substring(28, 6).Trim()
                    dados.bancoNome = linha.Substring(34, 10).Trim()
                    dados.Numero = linha.Substring(44, 10).Trim()
                    dados.valor = CDec(linha.Substring(54, 11).Trim() + "," + linha.Substring(65, 2).Trim())
                    dados.baixado = IIf(linha.Substring(67, 1).Trim() = "", "N", linha.Substring(67, 1).Trim())
                    'dados.vendasId = 
                    'dados.agencia = 
                    'dados.conta = 

                    barra.Increment(linha.Length)
                End If

                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Cheques concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Cheques [linha " + numLinha.ToString() + "] - " + ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarFornecedor() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dFornecedor
        Dim regras As rFornecedor = New rFornecedor()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()
            numLinha += 1

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 184)
                linha = ValidarCaracteres(linha)
                dados = New dFornecedor()
                dados.cid = Convert.ToInt32(linha.Substring(0, 3).Trim())

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    dados.nome = linha.Substring(3, 30).Trim()
                    dados.logradouro = linha.Substring(33, 40).Trim()
                    dados.bairro = linha.Substring(73, 20).Trim()
                    'dados.cidade_cid = linha.Substring(93, 20).Trim()
                    dados.cep = linha.Substring(113, 8).Trim()

                    '-- sigla uf
                    Dim dadosEstado As dEstado = New dEstado()
                    Dim regrasEstado As rEstado = New rEstado()
                    Dim colEstado As ColecaoEstado

                    dadosEstado.sigla = linha.Substring(121, 2).Trim()
                    colEstado = regrasEstado.Consultar(dadosEstado)
                    If colEstado IsNot Nothing Then
                        If colEstado.Count > 0 Then
                            dados.estado_cid = colEstado(0).cid
                        End If
                    End If

                    dados.cnpj = linha.Substring(123, 14).Trim()
                    dados.inscricaoEstadual = linha.Substring(137, 12).Trim()
                    dados.telefone = linha.Substring(149, 20).Trim()
                    dados.nomeContato = linha.Substring(169, 15).Trim()
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                numLinha += 1
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Fornecedores concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Fornecedores [linha " & numLinha.ToString() & "] - " & ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarGrupo() As Boolean
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim dados As dGrupo
        Dim regras As rGrupo = New rGrupo()
        Dim numLinha As Integer = 0

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()
            numLinha += 1

            While Not String.IsNullOrEmpty(linha)
                ValidarTamanhoLinha(linha, 18)
                linha = ValidarCaracteres(linha)
                dados = New dGrupo()
                dados.cid = Convert.ToInt32(linha.Substring(0, 3).Trim())

                If regras.Consultar(dados) Is Nothing Then
                    dados.situacao = "A"
                    dados.nome = linha.Substring(3, 15).Trim()
                End If

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                numLinha += 1
                barra.Refresh()
                Me.Refresh()
            End While

            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("ValidaÁ„o de Grupos concluÌda com sucesso! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            If Not conteudo.Equals(Nothing) Then
                conteudo.Close()
                conteudo.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Grupos [linha " + numLinha.ToString() + "] - " & ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function ValidarArquivoCrediario() As Boolean
        Dim fluxoTexto As System.IO.StreamReader
        Dim linhaTexto As String = Nothing
        Dim count As Integer = 0
        Dim numLinha As Integer = 0

        Try

            If IO.File.Exists(txtArquivo.Text) Then
                fluxoTexto = New System.IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)

                linhaTexto = fluxoTexto.ReadLine
                numLinha += 1

                While linhaTexto <> Nothing
                    ValidarTamanhoLinha(linhaTexto, 102)
                    linhaTexto = ValidarCaracteres(linhaTexto)
                    count += 1
                    linhaTexto = fluxoTexto.ReadLine
                    numLinha += 1
                End While

                barra.Value = 0
                barra.Maximum = count

                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If
                MessageBox.Show("ValidaÁ„o de Crediario concluÌda com sucesso! [" & numLinha.ToString() & "]")

                Return True

            Else
                MessageBox.Show("Arquivo n„o existe")
                Return False
            End If
        Catch ex As Exception
            If Not fluxoTexto.Equals(Nothing) Then
                fluxoTexto.Close()
                fluxoTexto.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Crediario [linha " + numLinha.ToString() + "] - " & ex.Message)
            Return False
        End Try

    End Function

    Private Function ValidarArquivoCliente() As Boolean
        Dim fluxoTexto As System.IO.StreamReader
        Dim linhaTexto As String = Nothing
        Dim count As Integer = 0
        Dim numLinha As Integer = 0
        Dim arquivo As FileInfo

        Try

            If IO.File.Exists(txtArquivo.Text) Then
                fluxoTexto = New System.IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)

                arquivo = New FileInfo(txtArquivo.Text)
                barra.Minimum = 0
                barra.Maximum = arquivo.Length
                barra.Value = 0

                linhaTexto = fluxoTexto.ReadLine
                numLinha += 1

                While linhaTexto <> Nothing
                    ValidarTamanhoLinha(linhaTexto, 884)
                    linhaTexto = ValidarCaracteres(linhaTexto)
                    count += 1
                    barra.Value += linhaTexto.Length
                    barra.Refresh()

                    linhaTexto = fluxoTexto.ReadLine
                    numLinha += 1
                End While

                fluxoTexto.Close()

                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If

                MessageBox.Show("ValidaÁ„o de Clientes concluÌda com sucesso! [" & numLinha.ToString() & "]")
                Return True

            Else
                MessageBox.Show("Arquivo n„o existe!")
                Return False
            End If

        Catch ex As Exception
            If Not fluxoTexto.Equals(Nothing) Then
                fluxoTexto.Close()
                fluxoTexto.Dispose()
            End If
            MessageBox.Show("Erro na validaÁ„o de Clientes [linha " + numLinha.ToString() + "] - " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub ImportarArquivoCliente()
        Dim fluxoTexto As System.IO.StreamReader = Nothing
        Dim linhaTexto As String = Nothing
        Dim arquivo As FileInfo
        Dim numLinha As Integer = 0

        If IO.File.Exists(txtArquivo.Text) Then
            Try
                fluxoTexto = New System.IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
                linhaTexto = fluxoTexto.ReadLine
                numLinha += 1

                arquivo = New FileInfo(txtArquivo.Text)
                barra.Minimum = 0
                barra.Maximum = arquivo.Length
                barra.Value = 0

                While linhaTexto <> Nothing
                    barra.Value += linhaTexto.Length
                    barra.Refresh()

                    linhaTexto = ValidarCaracteres(linhaTexto)
                    'If rbtAbcd.Checked Then
                    CadastrarCliente(linhaTexto)
                    'ElseIf rbtOutros.Checked Then
                    '  CadastrarClienteOrange(linhaTexto)
                    'End If
                    linhaTexto = fluxoTexto.ReadLine
                    numLinha += 1
                End While

                fluxoTexto.Close()

                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If

                NegativarClientes()

                MessageBox.Show("ImportaÁ„o ConcluÌda [" & numLinha.ToString() & "]")
                barra.Value = 0

            Catch ex As Exception
                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If
                MessageBox.Show(ex.Message & " - linha [" & numLinha.ToString() & "]")
            End Try
        Else
            MessageBox.Show("Arquivo n„o existe")
        End If

    End Sub

    Private Sub ImportarArquivoCrediario()
        Dim fluxoTexto As System.IO.StreamReader = Nothing
        Dim linhaTexto As String = Nothing
        Dim numLinha As Integer = 0

        If IO.File.Exists(txtArquivo.Text) Then
            Try
                fluxoTexto = New System.IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)

                linhaTexto = fluxoTexto.ReadLine
                numLinha += 1

                While linhaTexto <> Nothing
                    linhaTexto = ValidarCaracteres(linhaTexto)
                    CadastrarCrediario(linhaTexto)
                    barra.Increment(1)
                    linhaTexto = fluxoTexto.ReadLine
                    numLinha += 1
                End While

                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If
                MessageBox.Show("ImportaÁ„o ConcluÌda [" & numLinha.ToString() & "]")
                barra.Value = 0

            Catch ex As Exception
                If Not fluxoTexto.Equals(Nothing) Then
                    fluxoTexto.Close()
                    fluxoTexto.Dispose()
                End If
                MessageBox.Show(ex.Message & " - linha [" & numLinha.ToString() & "]")
            End Try
        Else
            MessageBox.Show("Arquivo n„o existe")
        End If

    End Sub

    Private Sub CadastrarCrediario(ByVal linha As String)
        Dim regraCrediario As New ncRegras.nsCrediario.rCrediario
        Dim crediario As New ncDados.nsCrediario.dCrediario
        Dim parcela As New ncDados.nsCrediario.dParcelas
        Dim listacrediario As ncDados.nsCrediario.ColecaoCrediario
        Dim regraCliente As ncRegras.nsCliente.rCliente
        Dim dadosCliente As ncDados.nsCliente.dCliente

        regraCliente = New ncRegras.nsCliente.rCliente()

        Try
            ' Credi·rio
            crediario.LojaId = linha.Substring(0, 3) ' 3
            crediario.clienteId = linha.Substring(10, 6) ' 16 
            dadosCliente = regraCliente.ConsultarPorCID(crediario.clienteId)
            If dadosCliente IsNot Nothing Then
                crediario.controle = linha.Substring(3, 6).Trim()  ' 9
                crediario.NotaFiscal = linha.Substring(16, 7).Trim()  ' 23 nota fiscal
                If ((linha.Substring(32, 2) + linha.Substring(30, 2) + linha.Substring(26, 4)) = "00000000") Then
                    crediario.DataVenda = VerificarData("01", "01", "1900")
                Else
                    crediario.DataVenda = VerificarData(linha.Substring(32, 2), linha.Substring(30, 2), linha.Substring(26, 4)) ' 34
                End If
                crediario.Terminal = linha.Substring(99, 3).Trim()
                crediario.ValorVenda = CDec(linha.Substring(34, 10)) / 100 ' 44
                listacrediario = regraCrediario.Consultar(crediario)
                If IsNothing(listacrediario) Then
                    crediario.ValorTotal = CDec(linha.Substring(52, 10)) / 100 ' 62
                    crediario.ValorPago = CDec(linha.Substring(70, 10)) / 100 ' 80
                    crediario.SaldoDevedor = crediario.ValorTotal - crediario.ValorPago
                    crediario.Parcelas = 1
                    parcela.crediarioId = regraCrediario.IncluirCrediario(crediario)
                Else
                    crediario = listacrediario(0)
                    crediario.ValorTotal += CDec(linha.Substring(52, 10)) / 100 ' 62
                    crediario.ValorPago += CDec(linha.Substring(70, 10)) / 100 ' 80
                    crediario.SaldoDevedor = crediario.ValorTotal - crediario.ValorPago
                    If crediario.SaldoDevedor < 0 Then
                        crediario.SaldoDevedor = 0
                    End If
                    crediario.Parcelas += 1
                    regraCrediario.AlterarCrediario(crediario)
                    parcela.crediarioId = crediario.cid
                End If
                ' parcelas
                parcela.codigoBarras = linha.Substring(3, 7).Trim()  ' 10
                ' 23 + 3 = 26 loja
                If ((linha.Substring(32, 2) + linha.Substring(30, 2) + linha.Substring(26, 4)) = "00000000") Then
                    parcela.dataEmissao = VerificarData("01", "01", "1900") ' 34
                Else
                    parcela.dataEmissao = VerificarData(linha.Substring(32, 2), linha.Substring(30, 2), linha.Substring(26, 4)) ' 34
                End If
                If ((linha.Substring(50, 2) + linha.Substring(48, 2) + linha.Substring(44, 4)) = "00000000") Then
                    parcela.dataVecimento = VerificarData("01", "01", "1900") ' 52
                Else
                    parcela.dataVecimento = VerificarData(linha.Substring(50, 2), linha.Substring(48, 2), linha.Substring(44, 4)) ' 52
                End If
                parcela.valor = CDec(linha.Substring(52, 10)) / 100 ' 62
                If linha.Substring(62, 8).Trim() <> "00000000" Then
                    parcela.dataPagamento = VerificarData(linha.Substring(68, 2), linha.Substring(66, 2), linha.Substring(62, 4)) ' 70 
                End If
                parcela.valorPago = CDec(linha.Substring(70, 10)) / 100 ' 80
                parcela.situacao = linha.Substring(80, 2).Trim() ' 82
                If parcela.situacao = "00" Then
                    parcela.valorReceber = parcela.valor
                End If
                ' 82 + 3 = 85 loja
                ' 85 + 6 = 91 cliente
                ' 91 + 8 = 99 vencimento

                regraCrediario.IncluirParcela(parcela)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function VerificarData(ByVal pDia As String, ByVal pMes As String, ByVal pAno As String) As String
        Dim diaAux As String
        Dim mesAux As String
        Dim anoAux As String
        Dim mes30 As String = "|04|06|09|11|"
        Dim dataAux As DateTime

        diaAux = pDia
        mesAux = pMes
        anoAux = pAno

        If anoAux.Length <= 2 Then
            anoAux = "19" + anoAux.PadLeft(2, "0")
        End If

        If IsNumeric(diaAux) And IsNumeric(mesAux) And IsNumeric(anoAux) Then
            If mesAux.Equals("02") Then
                If Convert.ToInt32(anoAux) Mod 4 = 0 Then '-- Bisexto 29
                    If Convert.ToInt32(diaAux) > 29 Then
                        diaAux = "29"
                    End If
                Else '-- 28
                    If Convert.ToInt32(diaAux) > 28 Then
                        diaAux = "28"
                    End If
                End If
            ElseIf mes30.Contains("|" + mesAux + "|") Then
                If Convert.ToInt32(diaAux) > 30 Then
                    diaAux = "30"
                End If
            End If
        Else
            anoAux = "1900"
            mesAux = "01"
            diaAux = "01"
        End If

        If Not DateTime.TryParse(anoAux + "-" + mesAux + "-" + diaAux, dataAux) Then
            anoAux = "1900"
            mesAux = "01"
            diaAux = "01"
        End If

        VerificarData = anoAux + "-" + mesAux + "-" + diaAux
    End Function

    Private Sub CadastrarCliente(ByVal linha As String)

        Dim regraCliente As rCliente
        Dim regraClienteEndereco As rClienteEndereco
        Dim regraClienteFinanceiro As rClienteFinanceiro
        Dim regraClienteProfissional As rClienteProfissional

        Dim estado As ncDados.nsEstado.dEstado
        Dim listaestado As ncDados.nsEstado.ColecaoEstado
        Dim regraEstado As ncRegras.nsEstado.rEstado

        Dim clienteEndereco As dClienteEndereco
        Dim cliente As New dCliente
        Dim clienteFinanceiro As New dClienteFinanceiro
        Dim clienteProfissional As New dClienteProfissional

        Try

            ' Dados do cliente
            ' 0 + 3 = 3
            cliente.cid = linha.Substring(3, 6)
            cliente.codigo = linha.Substring(3, 6)  ' 9
            cliente.nome = linha.Substring(9, 40).Trim()  ' 49
            cliente.telefone = linha.Substring(129, 12).Trim().Replace(" ", "") ' 141
            cliente.dataNascimento = VerificarData(linha.Substring(245, 2), linha.Substring(247, 2), linha.Substring(249, 2)) ' 251
            cliente.naturalidade = linha.Substring(251, 20).Trim() & " " & linha.Substring(271, 2).Trim() ' 271' 273 
            cliente.estadoCivil = linha.Substring(273, 1).Trim() '273 + 12 ' 285
            If linha.Substring(285, 1) = "X" Then ' 286
                cliente.sexo = "M"
            ElseIf linha.Substring(286, 1) = "X" Then ' 287
                cliente.sexo = "F"
            End If
            cliente.carteiraProfissional = linha.Substring(287, 8).Trim() & " " & linha.Substring(295, 8).Trim() ' 295 ' 303
            cliente.cpf = linha.Substring(303, 14).Trim() ' 318
            cliente.rg = linha.Substring(317, 14).Trim() ' 331
            cliente.nomeMae = linha.Substring(342, 34).Trim() ' 376
            cliente.nomePai = linha.Substring(376, 34).Trim() ' 410
            cliente.dataInclusao = VerificarData(linha.Substring(835, 2), linha.Substring(837, 2), linha.Substring(839, 2)) ' 841
            cliente.situacao = "A"

            regraCliente = New rCliente()
            cliente.cid = regraCliente.IncluirImportacao(cliente)

            ' EndereÁo atual 
            clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
            clienteEndereco.cliente_cid = cliente.cid
            clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAtual
            clienteEndereco.logradouro = linha.Substring(49, 35).Trim() ' 84
            clienteEndereco.bairro = linha.Substring(84, 15).Trim() ' 99
            clienteEndereco.cidade = linha.Substring(99, 20).Trim() ' 119
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(119, 2).Trim  ' 121
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteEndereco.estado_cid = listaestado(0).cid
                End If
            End If
            clienteEndereco.cep = linha.Substring(121, 8).Trim() ' 129
            If linha.Substring(141, 1) = "X" Then ' 142
                clienteEndereco.tipoResidencia = "P"
            ElseIf linha.Substring(142, 1) = "X" Then ' 143
                clienteEndereco.tipoResidencia = "R"
            ElseIf linha.Substring(143, 1) = "X" Then ' 144
                clienteEndereco.tipoResidencia = "A"
            End If
            clienteEndereco.valor = CDec(linha.Substring(144, 11)) / 100 ' 155
            clienteEndereco.tempo = linha.Substring(155, 10).Trim() ' 165

            regraClienteEndereco = New rClienteEndereco()
            regraClienteEndereco.Incluir(clienteEndereco)

            ' EndereÁo anterior
            clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
            clienteEndereco.cliente_cid = cliente.cid
            clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAnterior
            clienteEndereco.logradouro = linha.Substring(165, 35).Trim() ' 200
            clienteEndereco.bairro = linha.Substring(200, 15).Trim() ' 215
            clienteEndereco.cidade = linha.Substring(215, 20).Trim() ' 235
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(235, 2).Trim() ' 237
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteEndereco.estado_cid = listaestado(0).cid
                End If
            End If
            clienteEndereco.cep = linha.Substring(237, 8).Trim() ' 245

            regraClienteEndereco = New rClienteEndereco()
            regraClienteEndereco.Incluir(clienteEndereco)

            ' Dados Profissionais
            clienteProfissional.cliente_cid = cliente.cid
            clienteProfissional.empresa = linha.Substring(410, 30).Trim() ' 440
            clienteProfissional.logradouro = linha.Substring(440, 30).Trim() ' 470
            clienteProfissional.bairro = linha.Substring(470, 15).Trim() ' 485
            clienteProfissional.cidade = linha.Substring(485, 15).Trim() ' 500
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(500, 2).Trim() ' 502
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteProfissional.estado_cid = listaestado(0).cid
                End If
            End If
            clienteProfissional.cep = linha.Substring(502, 8).Trim() ' 510
            clienteProfissional.telefone = linha.Substring(510, 12).Trim().Replace(" ", "")  ' 522
            clienteProfissional.ramal = linha.Substring(522, 5).Trim() ' 527
            clienteProfissional.cargo = linha.Substring(527, 15).Trim() ' 542
            clienteProfissional.dataAdmissao = linha.Substring(542, 6).Trim() ' 548
            clienteProfissional.salario = TratarDecimal(CDec(linha.Substring(548, 11)) / 100) ' 559

            regraClienteProfissional = New rClienteProfissional()
            regraClienteProfissional.Incluir(clienteProfissional)

            ' TODO: Dados conjuge '559 + 170 = 729

            ' Dados Financeiros
            clienteFinanceiro.cliente_cid = cliente.cid
            clienteFinanceiro.limite = CDec(linha.Substring(331, 10)) / 100 ' 341
            clienteFinanceiro.situacaoCrediario = linha.Substring(341, 1) ' 342
            clienteFinanceiro.observacoes = linha.Substring(729, 40).Trim() ' 769
            ' Filler 769 + 30 = 799
            clienteFinanceiro.dataNegativacao = linha.Substring(799, 6).Trim() ' 805
            clienteFinanceiro.motivo = linha.Substring(805, 30).Trim() ' 835

            regraClienteFinanceiro = New rClienteFinanceiro()
            regraClienteFinanceiro.Incluir(clienteFinanceiro)

            ' Indic Cli 841 + 3 = 844
            ' Nome Indic Cli 844 + 40 = 884
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CadastrarClienteOrange(ByVal linha As String)

        Dim regraCliente As rCliente
        Dim regraClienteEndereco As rClienteEndereco
        Dim regraClienteFinanceiro As rClienteFinanceiro
        Dim regraClienteProfissional As rClienteProfissional

        Dim estado As ncDados.nsEstado.dEstado
        Dim listaestado As ncDados.nsEstado.ColecaoEstado
        Dim regraEstado As ncRegras.nsEstado.rEstado

        Dim clienteEndereco As dClienteEndereco
        Dim cliente As New dCliente
        Dim clienteFinanceiro As New dClienteFinanceiro
        Dim clienteProfissional As New dClienteProfissional

        Try

            ' Dados do cliente
            ' 0 + 3 = 3
            cliente.codigo = linha.Substring(3, 6)  ' 9
            cliente.nome = linha.Substring(9, 40).Trim()  ' 49
            cliente.telefone = linha.Substring(129, 12).Trim().Replace(" ", "") ' 141
            cliente.dataNascimento = linha.Substring(245, 6).Trim() ' 251
            cliente.naturalidade = linha.Substring(251, 20).Trim() & " " & linha.Substring(271, 2).Trim() ' 271' 273 
            cliente.estadoCivil = linha.Substring(273, 1).Trim() '273 + 12 ' 285
            If linha.Substring(285, 1) = "X" Then ' 286
                cliente.sexo = "M"
            ElseIf linha.Substring(286, 1) = "X" Then ' 287
                cliente.sexo = "F"
            End If
            cliente.carteiraProfissional = linha.Substring(287, 8).Trim() & " " & linha.Substring(295, 8).Trim() ' 295 ' 303
            cliente.cpf = linha.Substring(303, 14).Trim() ' 318
            cliente.rg = linha.Substring(317, 14).Trim() ' 331
            cliente.nomeMae = linha.Substring(342, 34).Trim() ' 376
            cliente.nomePai = linha.Substring(376, 34).Trim() ' 410
            cliente.dataInclusao = linha.Substring(805, 6).Trim() ' 841
            cliente.situacao = "A"

            regraCliente = New rCliente()
            cliente.cid = regraCliente.IncluirImportacao(cliente)

            ' EndereÁo atual 
            clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
            clienteEndereco.cliente_cid = cliente.cid
            clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAtual
            clienteEndereco.logradouro = linha.Substring(49, 35).Trim() ' 84
            clienteEndereco.bairro = linha.Substring(84, 15).Trim() ' 99
            clienteEndereco.cidade = linha.Substring(99, 20).Trim() ' 119
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(119, 2).Trim  ' 121
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteEndereco.estado_cid = listaestado(0).cid
                End If
            End If
            clienteEndereco.cep = linha.Substring(121, 8).Trim() ' 129
            If linha.Substring(141, 1) = "X" Then ' 142
                clienteEndereco.tipoResidencia = "P"
            ElseIf linha.Substring(142, 1) = "X" Then ' 143
                clienteEndereco.tipoResidencia = "R"
            ElseIf linha.Substring(143, 1) = "X" Then ' 144
                clienteEndereco.tipoResidencia = "A"
            End If
            clienteEndereco.valor = CDec(linha.Substring(144, 11)) / 100 ' 155
            clienteEndereco.tempo = linha.Substring(155, 10).Trim() ' 165

            regraClienteEndereco = New rClienteEndereco()
            regraClienteEndereco.Incluir(clienteEndereco)

            ' EndereÁo anterior
            clienteEndereco = New ncDados.nsCliente.dClienteEndereco()
            clienteEndereco.cliente_cid = cliente.cid
            clienteEndereco.tipoEndereco = ncComum.nsConstantes.cConstantes.EnderecoAnterior
            clienteEndereco.logradouro = linha.Substring(165, 35).Trim() ' 200
            clienteEndereco.bairro = linha.Substring(200, 15).Trim() ' 215
            clienteEndereco.cidade = linha.Substring(215, 20).Trim() ' 235
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(235, 2).Trim() ' 237
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteEndereco.estado_cid = listaestado(0).cid
                End If
            End If
            clienteEndereco.cep = linha.Substring(237, 8).Trim() ' 245

            regraClienteEndereco = New rClienteEndereco()
            regraClienteEndereco.Incluir(clienteEndereco)

            ' Dados Profissionais
            clienteProfissional.cliente_cid = cliente.cid
            clienteProfissional.empresa = linha.Substring(410, 30).Trim() ' 440
            clienteProfissional.logradouro = linha.Substring(440, 30).Trim() ' 470
            clienteProfissional.bairro = linha.Substring(470, 15).Trim() ' 485
            clienteProfissional.cidade = linha.Substring(485, 15).Trim() ' 500
            estado = New ncDados.nsEstado.dEstado()
            estado.sigla = linha.Substring(500, 2).Trim() ' 502
            If estado.sigla <> "" Then
                regraEstado = New ncRegras.nsEstado.rEstado
                listaestado = regraEstado.Consultar(estado)
                If Not IsNothing(listaestado) Then
                    clienteProfissional.estado_cid = listaestado(0).cid
                End If
            End If
            clienteProfissional.cep = linha.Substring(502, 8).Trim() ' 510
            clienteProfissional.telefone = linha.Substring(510, 12).Trim().Replace(" ", "")  ' 522
            clienteProfissional.ramal = linha.Substring(522, 5).Trim() ' 527
            clienteProfissional.cargo = linha.Substring(527, 15).Trim() ' 542
            clienteProfissional.dataAdmissao = linha.Substring(542, 6).Trim() ' 548
            clienteProfissional.salario = CDec(linha.Substring(548, 11)) / 100 ' 559

            regraClienteProfissional = New rClienteProfissional()
            regraClienteProfissional.Incluir(clienteProfissional)

            ' TODO: Dados conjuge '559 + 170 = 729

            ' Dados Financeiros
            clienteFinanceiro.cliente_cid = cliente.cid
            clienteFinanceiro.limite = CDec(linha.Substring(331, 10)) / 100 ' 341
            clienteFinanceiro.situacaoCrediario = linha.Substring(341, 1) ' 342
            clienteFinanceiro.observacoes = linha.Substring(729, 40).Trim() ' 769
            ' Filler 769 + 30 = 799
            clienteFinanceiro.dataNegativacao = linha.Substring(799, 6).Trim() ' 805
            clienteFinanceiro.motivo = linha.Substring(805, 30).Trim() ' 835

            regraClienteFinanceiro = New rClienteFinanceiro()
            regraClienteFinanceiro.Incluir(clienteFinanceiro)

            ' Indic Cli 841 + 3 = 844
            ' Nome Indic Cli 844 + 40 = 884
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btoCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim usuario As String = String.Empty
        Dim senha As String = String.Empty
        Dim banco As String = String.Empty
        Dim destino As String = String.Empty
        Dim aplicativo As String = String.Empty

        usuario = System.Configuration.ConfigurationManager.AppSettings("BD_USUARIO")
        senha = System.Configuration.ConfigurationManager.AppSettings("BD_SENHA")
        banco = System.Configuration.ConfigurationManager.AppSettings("BD_NOMEBANCO")
        aplicativo = System.Configuration.ConfigurationManager.AppSettings("BD_APLICATIVO")
        destino = Environment.CurrentDirectory & "\nascomercio_" & _
            Now().Year.ToString().PadLeft(4, "0"c) & _
            Now().Month.ToString().PadLeft(2, "0"c) & _
            Now().Day.ToString().PadLeft(2, "0"c) & "_" & _
            Now().Hour.ToString().PadLeft(2, "0"c) & _
            Now().Minute.ToString().PadLeft(2, "0"c) & _
            Now().Second.ToString().PadLeft(2, "0"c) & ".sql"

        'System.Diagnostics.Process.Start("cmd.exe /C " & aplicativo & "mysqldump.exe", "-u " & usuario & " -p" & senha & " " & banco & " > " & destino)
        System.Diagnostics.Process.Start(Environment.CurrentDirectory & "\backup\backup.bat", """" & aplicativo & """ " & usuario & " " & senha & " " & banco & " " & destino)

        MessageBox.Show("Backup Realizado: " & destino, "Nascomercio", MessageBoxButtons.OK)

    End Sub

    Private Sub ImportarProduto()
        Dim conteudo As IO.StreamReader
        Dim linha As String
        Dim arquivo As FileInfo
        Dim regras As rProduto = New rProduto()
        Dim itens As String
        Dim numLinha As Integer = 0
        '-- cor
        Dim dadosCor As dCor = New dCor()
        Dim regrasCor As rCor = New rCor()
        Dim colCor As ColecaoCor
        '-- fabricante
        Dim dadosFab As dFabricante = New dFabricante()
        Dim regrasFab As rFabricante = New rFabricante()
        Dim colFab As ColecaoFabricante

        Try
            arquivo = New FileInfo(txtArquivo.Text)
            barra.Minimum = 0
            barra.Maximum = arquivo.Length
            barra.Value = 0

            conteudo = New IO.StreamReader(txtArquivo.Text, System.Text.Encoding.Default)
            linha = conteudo.ReadLine()

            While Not String.IsNullOrEmpty(linha)
                linha = ValidarCaracteres(linha)
                numLinha += 1
                dadosProduto = New dProduto()
                dadosProduto.cid = linha.Substring(0, 6).Trim()
                dadosProduto.codigo = Convert.ToInt32(linha.Substring(0, 6).Trim()).ToString()
                dadosProduto.fornecedor_cid = linha.Substring(6, 3).Trim()
                dadosProduto.descricao = linha.Substring(9, 20).Trim()
                dadosProduto.grupo_cid = linha.Substring(61, 3).Trim()
                dadosProduto.referencia = linha.Substring(82, 15).Trim()
                dadosProduto.dataInclusao = Now().Year.ToString().PadLeft(4, "0"c) + "-" + _
                  Now().Month.ToString().PadLeft(2, "0"c) + "-" + _
                  Now().Day.ToString().PadLeft(2, "0"c) + " " + _
                  Now().Hour.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Minute.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Second.ToString().PadLeft(2, "0"c)
                dadosProduto.produtoTipo_cid = 1
                dadosProduto.estoqueMinimo = 0

                '-- cor
                dadosCor = New dCor()
                dadosCor.nome = linha.Substring(130, 15).Trim()
                colCor = regrasCor.Consultar(dadosCor)
                If colCor IsNot Nothing Then
                    If colCor.Count > 0 Then
                        dadosProduto.cor_cid = colCor(0).cid
                    End If
                End If

                '-- fabricante
                dadosFab = New dFabricante()
                dadosFab.nome = linha.Substring(31, 15).Trim()
                colFab = regrasFab.Consultar(dadosFab)
                If colFab IsNot Nothing Then
                    If colFab.Count > 0 Then
                        dadosProduto.fabricante_cid = colFab(0).cid
                    End If
                End If

                dadosProduto.situacao = "A"
                itens = linha.Substring(145, 1464).Trim()

                ListarProdutoItem(dadosProduto, itens)

                regras.Importar(dadosProduto)
                ImportarProdutoItem(itens)

                barra.Increment(linha.Length)
                linha = conteudo.ReadLine()
                barra.Refresh()
                Me.Refresh()
            End While

            conteudo.Close()
            MessageBox.Show("ImportaÁ„o de Produtos concluÌda! [" & numLinha.ToString() & "]")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListarProdutoItem(ByVal produto As dProduto, ByVal itensProduto As String)
        Dim tamanho As Integer = 0
        Dim contItem As Integer = 0
        Dim item As String = String.Empty
        Dim itemProduto As dProdutoItem
        Dim colecaoPI As ColecaoProdutoItem
        Dim qtde As Integer = 0
        Dim compra As Decimal = 0
        Dim venda As Decimal = 0

        colecaoItensProdutos = New ColecaoItensProdutos()

        Do While itensProduto.Length > 0
            qtde = 0
            compra = 0
            venda = 0
            item = itensProduto.Substring(0, 24)

            qtde = Convert.ToInt32(item.Substring(0, 4))
            compra = Convert.ToDecimal(item.Substring(4, 8) & "," & item.Substring(12, 2))
            venda = Convert.ToDecimal(item.Substring(14, 8) & "," & item.Substring(22, 2))

            '-- ProdutoItem: codigo produto, item, codigo caracteristica, valor

            If (tamanho > 0) And ((compra > 0) Or (venda > 0) Or (qtde > 0)) Then
                colecaoPI = New ColecaoProdutoItem()

                '-- codigo de barras - 1
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 1
                itemProduto.valor = (produto.fornecedor_cid.ToString().PadLeft(3, "0"c) & _
                    produto.codigo.PadLeft(6, "0"c).Substring(1, 5) & _
                    produto.cor_cid.ToString().PadLeft(4, "0"c).Substring(1, 3) & _
                    tamanho.ToString().PadLeft(2, "0"c)).PadLeft(14, "0"c)
                colecaoPI.Add(itemProduto)

                '-- estoque - 2 
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 2
                itemProduto.valor = qtde.ToString()
                colecaoPI.Add(itemProduto)

                '-- tamanho - 3
                itemProduto = New dProdutoItem()
                itemProduto.produtos_cid = produto.cid
                itemProduto.item = contItem
                itemProduto.caracteristicas_cid = 3
                itemProduto.valor = tamanho.ToString()
                colecaoPI.Add(itemProduto)

                contItem += 1
                colecaoItensProdutos.Add(colecaoPI)

                If dadosProduto.valorCompra.Equals(Nothing) Then
                    dadosProduto.valorCompra = compra
                Else
                    If compra > dadosProduto.valorCompra Then
                        dadosProduto.valorCompra = compra
                    End If
                End If

                If dadosProduto.valorVenda.Equals(Nothing) Then
                    dadosProduto.valorVenda = venda
                Else
                    If venda > dadosProduto.valorVenda Then
                        dadosProduto.valorVenda = venda
                    End If
                End If
            End If

            tamanho += 1
            itensProduto = itensProduto.Substring(24)
        Loop

    End Sub

    Private Sub ImportarProdutoItem(ByVal itens As String)
        Dim regraPI As rProdutoItem = New rProdutoItem()

        For Each _itemIP As ColecaoProdutoItem In colecaoItensProdutos
            For Each _item As dProdutoItem In _itemIP
                regraPI.Incluir(_item)
            Next
        Next
    End Sub

    Private Sub ImportarProduto2()

        Dim nomeArqPRODUTOS As String
        Dim arqPRODUTOS As FileInfo
        Dim conteudoPRODUTOS As IO.StreamReader = Nothing
        Dim linhaPRODUTOS As String
        Dim linhaPRODCOR As String
        Dim colecaoPRODCOR As ColecaoBDProdCor = Nothing
        Dim dadosPesquisa As dProduto
        Dim regraProduto As rProduto = New rProduto()
        Dim colProduto As ColecaoProduto
        Dim tamanho As String
        Dim qtde As String
        Dim nlp As Integer = 0
        Dim dadosProdutoCodigo As String
        Dim dadosProdcorCorCID As String
        Dim itens As String

        '-- fabricante
        Dim dadosFab As dFabricante = New dFabricante()
        Dim regrasFab As rFabricante = New rFabricante()
        Dim colFab As ColecaoFabricante

        '-- fornecedor
        Dim dadosFor As dFornecedor = New dFornecedor()
        Dim regrasFor As rFornecedor = New rFornecedor()

        Try
            nomeArqPRODUTOS = txtArquivo.Text
            arqPRODUTOS = New FileInfo(nomeArqPRODUTOS)

            barra.Minimum = 0
            barra.Maximum = arqPRODUTOS.Length
            barra.Value = 0

            '-- Produtos
            conteudoPRODUTOS = New IO.StreamReader(nomeArqPRODUTOS, System.Text.Encoding.Default)
            linhaPRODUTOS = conteudoPRODUTOS.ReadLine()
            '-- Para cada PRODUTOS...
            While Not String.IsNullOrEmpty(linhaPRODUTOS)
                nlp += 1

                linhaPRODUTOS = ValidarCaracteres(linhaPRODUTOS)

                '-- Carrega dados do PRODUTOS
                dadosProduto = New dProduto()
                dadosProdutoCodigo = linhaPRODUTOS.Substring(0, 6)
                dadosProduto.codigo = Convert.ToInt32(dadosProdutoCodigo.Trim()).ToString()
                dadosProduto.cid = dadosProduto.codigo
                dadosProduto.fornecedor_cid = linhaPRODUTOS.Substring(6, 3).Trim()

                dadosFor = regrasFor.Consultar(dadosProduto.fornecedor_cid)
                If dadosFor Is Nothing Then
                    dadosFor = New dFornecedor()
                    dadosFor.cid = linhaPRODUTOS.Substring(6, 3).Trim()
                    dadosFor.nome = linhaPRODUTOS.Substring(31, 15).Trim()
                    dadosFor.estado_cid = 1
                    dadosFor.cep = 0
                    dadosFor.inscricaoEstadual = "000000000000"
                    dadosFor.cnpj = "00000000000000"
                    dadosFor.situacao = "A"

                    regrasFor.Importar(dadosFor)
                End If

                dadosProduto.descricao = linhaPRODUTOS.Substring(9, 20).Trim()
                dadosProduto.grupo_cid = linhaPRODUTOS.Substring(61, 3).Trim()
                dadosProduto.referencia = linhaPRODUTOS.Substring(82, 15).Trim()
                dadosProduto.dataInclusao = Now().Year.ToString().PadLeft(4, "0"c) + "-" + _
                  Now().Month.ToString().PadLeft(2, "0"c) + "-" + _
                  Now().Day.ToString().PadLeft(2, "0"c) + " " + _
                  Now().Hour.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Minute.ToString().PadLeft(2, "0"c) + ":" + _
                  Now().Second.ToString().PadLeft(2, "0"c)
                dadosProduto.produtoTipo_cid = 1
                dadosProduto.estoqueMinimo = 0
                dadosProduto.situacao = "A"
                itensProduto = linhaPRODUTOS.Substring(145, 1464).Trim()

                '-- fabricante
                dadosFab = New dFabricante()
                dadosFab.nome = linhaPRODUTOS.Substring(31, 15).Trim()
                colFab = regrasFab.Consultar(dadosFab)
                If colFab IsNot Nothing Then
                    If colFab.Count > 0 Then
                        dadosProduto.fabricante_cid = colFab(0).cid
                    End If
                End If

                '-- Produto / COR
                colecaoPRODCOR = ConsultarBDProdCor(dadosProdutoCodigo)
                If colecaoPRODCOR IsNot Nothing Then
                    '-- Para cada PRODCOR...
                    For Each linhaPRODCOR In colecaoPRODCOR
                        dadosProdcorCorCID = linhaPRODCOR.Substring(9, 4)
                        dadosProduto.codigo = Convert.ToInt32(dadosProdutoCodigo.Trim() + dadosProdcorCorCID)
                        dadosProduto.cid = dadosProduto.codigo
                        dadosProduto.cor_cid = Convert.ToInt32(dadosProdcorCorCID.Trim()).ToString()
                        tamanho = linhaPRODCOR.Substring(13, 2)
                        qtde = linhaPRODCOR.Substring(15, 6)

                        ObterPrecos(tamanho)

                        dadosPesquisa = New dProduto()
                        dadosPesquisa.codigo = dadosProduto.codigo
                        colProduto = regraProduto.Consultar(dadosPesquisa)
                        '-- Se produto n„o existe, inclui
                        If colProduto Is Nothing Then
                            regraProduto.Importar(dadosProduto)
                        Else
                            If colProduto.Count <= 0 Then
                                regraProduto.Importar(dadosProduto)
                            End If
                        End If

                        '-- Incluir Item
                        ImportarProdutoItem2(dadosProduto.codigo, dadosProduto.fornecedor_cid, linhaPRODUTOS.Substring(1, 5) + linhaPRODCOR.Substring(9, 4), tamanho, qtde)
                    Next
                Else
                    itens = linhaPRODUTOS.Substring(145, 1464).Trim()

                    ListarProdutoItem(dadosProduto, itens)

                    regraProduto.Importar(dadosProduto)
                    ImportarProdutoItem(itens)

                End If

                barra.Increment(linhaPRODUTOS.Length)
                barra.Refresh()
                Me.Refresh()

                linhaPRODUTOS = conteudoPRODUTOS.ReadLine()
            End While

            If Not conteudoPRODUTOS.Equals(Nothing) Then
                conteudoPRODUTOS.Close()
                conteudoPRODUTOS.Dispose()
            End If

            ResolverTamanhosTipos()

            MessageBox.Show("ImportaÁ„o de Produtos concluÌda! [" & nlp.ToString() & "]")
        Catch ex As Exception
            If Not conteudoPRODUTOS.Equals(Nothing) Then
                conteudoPRODUTOS.Close()
                conteudoPRODUTOS.Dispose()
            End If
            MessageBox.Show("Erro na importaÁ„o de produtos [" + ex.Message + "] linha P[" + nlp.ToString() + "]")
        End Try

    End Sub

    Private Sub ImportarProdutoItem2(ByVal produtoCid As Integer, ByVal fornecedorCid As Integer, _
        ByVal produtoCodigo As String, ByVal tamanho As String, ByVal qtde As String)
        Dim regraPI As rProdutoItem = New rProdutoItem()
        Dim dadosPI As dProdutoItem
        Dim ultimoItem As Nullable(Of Integer) = Nothing

        Try
            ultimoItem = regraPI.ConsultarUltimoItem(produtoCid)
            If ultimoItem.Equals(Nothing) Then
                ultimoItem = 0
            Else
                ultimoItem = Convert.ToInt32(ultimoItem) + 1
            End If

            '-- codigo de barras - 1
            dadosPI = New dProdutoItem()
            dadosPI.produtos_cid = produtoCid
            dadosPI.item = ultimoItem
            dadosPI.caracteristicas_cid = 1
            dadosPI.valor = (fornecedorCid.ToString().PadLeft(3, "0"c) & _
                produtoCodigo.PadLeft(8, "0"c) & _
                tamanho.ToString().PadLeft(2, "0"c)).PadLeft(14, "0"c)
            'produto.cor_cid.ToString().PadLeft(4, "0"c).Substring(1, 3) & _
            regraPI.Incluir(dadosPI)

            '-- estoque - 2 
            dadosPI = New dProdutoItem()
            dadosPI.produtos_cid = produtoCid
            dadosPI.item = ultimoItem
            dadosPI.caracteristicas_cid = 2
            dadosPI.valor = Convert.ToInt32(qtde).ToString()
            regraPI.Incluir(dadosPI)

            '-- tamanho - 3
            dadosPI = New dProdutoItem()
            dadosPI.produtos_cid = produtoCid
            dadosPI.item = ultimoItem
            dadosPI.caracteristicas_cid = 3
            dadosPI.valor = Convert.ToInt32(tamanho).ToString()
            regraPI.Incluir(dadosPI)
        Catch ex As Exception
            MessageBox.Show("Erro na importaÁ„o de itens de produto [" + ex.Message + "]")
            Throw ex
        End Try
    End Sub

    Private Sub ObterPrecos(ByVal tamanho As String)
        Dim conteudo As String
        Dim compra As Decimal = 0
        Dim venda As Decimal = 0

        Try
            conteudo = itensProduto.Substring(tamanho * 24, 24)

            compra = Convert.ToDecimal(conteudo.Substring(4, 8) & "," & conteudo.Substring(12, 2))
            venda = Convert.ToDecimal(conteudo.Substring(14, 8) & "," & conteudo.Substring(22, 2))

            dadosProduto.valorCompra = compra
            dadosProduto.valorVenda = venda
        Catch ex As Exception
            MessageBox.Show("Erro na ObterPrecos de produto [" + ex.Message + "]")
            Throw ex
        End Try
    End Sub

    Private Sub ImportarBDProdCor()
        Dim nomeArqPRODCOR As String
        Dim arqPRODCOR As FileInfo
        Dim conteudoPRODCOR As IO.StreamReader = Nothing
        Dim linhaPRODCOR As String
        Dim codigo As String
        Dim prodcor As String
        Dim nlpc As Integer = 0

        Try
            nomeArqPRODCOR = txtArquivo.Text
            arqPRODCOR = New FileInfo(nomeArqPRODCOR)

            barra.Minimum = 0
            barra.Maximum = arqPRODCOR.Length
            barra.Value = 0

            '-- Produto / COR
            conteudoPRODCOR = New IO.StreamReader(nomeArqPRODCOR, System.Text.Encoding.Default)
            linhaPRODCOR = conteudoPRODCOR.ReadLine()

            '-- Para cada PRODCOR...
            While Not String.IsNullOrEmpty(linhaPRODCOR)
                nlpc += 1

                'ValidarTamanhoLinha(linhaPRODCOR, 136)
                linhaPRODCOR = ValidarCaracteres(linhaPRODCOR)

                codigo = linhaPRODCOR.Substring(3, 6)
                prodcor = linhaPRODCOR

                GravarBDProdCor(codigo, prodcor)

                barra.Increment(linhaPRODCOR.Length)
                barra.Refresh()
                Me.Refresh()

                linhaPRODCOR = conteudoPRODCOR.ReadLine()
            End While

            If conteudoPRODCOR IsNot Nothing Then
                conteudoPRODCOR.Close()
                conteudoPRODCOR.Dispose()
            End If
            MessageBox.Show("ImportaÁ„o de prodcor-bd concluÌda! [" & nlpc.ToString() & "]")
        Catch ex As Exception
            If conteudoPRODCOR IsNot Nothing Then
                conteudoPRODCOR.Close()
                conteudoPRODCOR.Dispose()
            End If
            MessageBox.Show("Erro na importaÁ„o de prodcor-bd [" + ex.Message + "] linha P[" + nlpc.ToString() + "]")
        End Try
    End Sub

    Private Sub btoImportar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btoImportar2.Click
        Select Case cboTipo.SelectedItem.ToString().Trim().ToLower()
            Case "cor"
                ImportarCor()
            Case "fabricante"
                ImportarFabricante()
            Case "fornecedor"
                ImportarFornecedor()
            Case "grupo"
                ImportarGrupo()
            Case "produto"
                ImportarProduto2()
            Case "cliente"
                ImportarArquivoCliente()
            Case "crediario"
                ImportarArquivoCrediario()
            Case "prodcor-bd"
                ImportarBDProdCor()
            Case "cheques"
                ImportarCheques()
        End Select
    End Sub

    Public Sub GravarBDProdCor(ByVal c1 As String, ByVal conteudo As String)

        Dim retorno As Integer
        Dim acessoBanco As nsAcessoBD.cAcessoBD
        Dim comandoSQL As String

        Try

            acessoBanco = New nsAcessoBD.cAcessoBD()

            comandoSQL = " INSERT INTO importacao (c1, conteudo) VALUES ('" & c1 & "','" & conteudo & "')"

            retorno = acessoBanco.ExecutarINT(comandoSQL)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ConsultarBDProdCor(ByVal codigo As String) As ColecaoBDProdCor

        Dim retorno As ColecaoBDProdCor = Nothing
        Dim acessoBanco As nsAcessoBD.cAcessoBD
        Dim ds As DataSet
        Dim dt As DataTable
        Dim row As DataRow
        Dim item As String
        Dim sqlSelect As String

        Try

            acessoBanco = New nsAcessoBD.cAcessoBD()

            sqlSelect = " Select conteudo From importacao Where c1 = '" & codigo & "'"

            ds = acessoBanco.ExecutarDS(sqlSelect)

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New ColecaoBDProdCor()

                        For Each row In dt.Rows
                            item = nsFuncoes.cFuncoes.RetornarTexto(row("conteudo"))

                            retorno.Add(item)
                        Next
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If
            Else
                retorno = Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try

        ConsultarBDProdCor = retorno

    End Function

    Private Function ValidarCaracteres(ByRef linha As String) As String
        Dim _linha As String = ""
        Dim _posicao As Integer

        Try

            For i As Int32 = 0 To linha.Length - 1 Step 1
                If linha.Substring(i, 1).Equals(vbNullChar) Then
                    _linha += " "
                Else
                    If caracs.Contains(linha.Substring(i, 1)) Then
                        _linha += linha.Substring(i, 1)
                    Else
                        _posicao = carEsp.IndexOf(linha.Substring(i, 1))
                        If _posicao >= 0 Then
                            _linha += carSub.Substring(_posicao, 1)
                        Else
                            Throw New Exception("Caracter [" & linha.Substring(i, 1) & "] inv·lido encontrado!")
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return _linha
    End Function

    Private Function ValidarTamanhoLinha(ByRef linha As String, ByVal tamanho As Int32) As Boolean
        Try

            If linha.Length <> tamanho Then
                Throw New Exception("Tamanho [" + tamanho.ToString() + "] inv·lido [" + linha.Length.ToString() + "]")
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function

    Private Sub NegativarClientes()
        Dim acessoBanco As nsAcessoBD.cAcessoBD
        Dim sqlSelect As String

        Try

            acessoBanco = New nsAcessoBD.cAcessoBD()

            '-- negativao dos clientes com ***
            sqlSelect = " update clientefinanceiro cf " & _
              " inner join clientes c on c.cid = cf.cliente_cid " & _
              " set cf.situacaoCrediario = 'N' " & _
              " where (c.nome Like '%***%') "
            acessoBanco.ExecutarINT(sqlSelect)

            '-- retirada do *** do nome dos clientes
            sqlSelect = " update clientes c " & _
              " set c.nome = Replace(c.nome, '***', '') " & _
              " where c.nome like '%***%' "
            acessoBanco.ExecutarINT(sqlSelect)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ResolverTamanhosTipos()
        Dim acessoBanco As nsAcessoBD.cAcessoBD
        Dim sqlSelect As String

        Try

            acessoBanco = New nsAcessoBD.cAcessoBD()

            '-- Tamanhos
            sqlSelect = " update produtoitem set valor = 'RN' where valor = '0' and caracteristicas_cid = 3 " '-- RN
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'PP' where valor = '1' and caracteristicas_cid = 3 " '-- PP
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'P' where valor = '2' and caracteristicas_cid = 3 " '-- P
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'M' where valor = '3' and caracteristicas_cid = 3 " '-- M
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'G' where valor = '4' and caracteristicas_cid = 3 " '-- G
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'GG' where valor = '5' and caracteristicas_cid = 3 " '-- GG
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'XG' where valor = '6' and caracteristicas_cid = 3 " '-- XG
            acessoBanco.ExecutarINT(sqlSelect)
            sqlSelect = " update produtoitem set valor = 'Unico' where valor = '8' and caracteristicas_cid = 3 " '-- Unico
            acessoBanco.ExecutarINT(sqlSelect)

            '-- altera tudo pra calÁado
            sqlSelect = " update produtos set produtoTipo_cid = 2 "
            acessoBanco.ExecutarINT(sqlSelect)

            '-- altera 'Unico' pra acessorios
            sqlSelect = " update produtos set produtoTipo_cid = 3 where cid in ( " & _
              " select distinct pi.produtos_cid " & _
              " from produtoitem pi " & _
              " where pi.caracteristicas_cid = 3 " & _
              " and pi.valor in ('Unico')) "
            acessoBanco.ExecutarINT(sqlSelect)

            '-- altera 'RN','PP','P','M','G','GG','XG' pra vestu·rio
            sqlSelect = " update produtos set produtoTipo_cid = 1 where cid in ( " & _
              " select distinct pi.produtos_cid " & _
              " from produtoitem pi " & _
              " where pi.caracteristicas_cid = 3 " & _
              " and pi.valor in ('RN','PP','P','M','G','GG','XG')) "
            acessoBanco.ExecutarINT(sqlSelect)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

Public Class ColecaoBDProdCor
    Inherits List(Of String)
End Class
