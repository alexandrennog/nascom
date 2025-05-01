Imports ncDados.nsCrediario
Imports ncDados.nsProduto
Imports ncDados.nsLoja
Imports ncDados.nsEtiquetaProdutoImpressao
Imports ncComum.Impressao
Imports ncRegras.nsParametro
Imports ncDados.nsParametro
Imports ncComum.nsConstantes



Namespace nsEtiqueta

    Public Class ColecaoLinha
        Inherits List(Of String)
    End Class

    Public Class ColecaoEtiqueta
        Inherits List(Of ColecaoLinha)
    End Class

    Public Class EtiquetaProduto

        Private _campo1 As String
        Private _campo2 As String
        Private _campo3 As String
        Private _campo4 As String
        Private _campo5 As String
        Private _campo6 As String
        Private _campo7 As String
        Private _campo8 As String
        Private _codigoBarras As String
        Private colecaoLinha As ColecaoLinha
        Private colecaoEtiqueta As ColecaoEtiqueta



        Public WriteOnly Property campo1() As String
            Set(ByVal value As String)
                _campo1 = (value)
            End Set
        End Property

        Public WriteOnly Property campo2() As String
            Set(ByVal value As String)
                _campo2 = (value)
            End Set
        End Property

        Public WriteOnly Property campo3() As String
            Set(ByVal value As String)
                _campo3 = (value)
            End Set
        End Property

        Public WriteOnly Property campo4() As String
            Set(ByVal value As String)
                _campo4 = (value)
            End Set
        End Property

        Public WriteOnly Property campo5() As String
            Set(ByVal value As String)
                _campo5 = (value)
            End Set
        End Property

        Public WriteOnly Property campo6() As String
            Set(ByVal value As String)
                _campo6 = (value)
            End Set
        End Property

        Public WriteOnly Property campo7() As String
            Set(ByVal value As String)
                _campo7 = (value)
            End Set
        End Property

        Public WriteOnly Property campo8() As String
            Set(ByVal value As String)
                _campo8 = (value)
            End Set
        End Property

        Public WriteOnly Property codigoBarras() As String
            Set(ByVal value As String)
                _codigoBarras = (value)
            End Set
        End Property

        Private Sub MontarCamposEtiquetaProduto(ByVal loja As String, ByVal fabricante As String,
              ByVal produto As dProduto, ByVal colecaoItem As ColecaoProdutoItem, ByVal cor As String,
              ByVal imprimirPreco As Boolean, ByVal imprimeDataEtiqueta As String)
            Dim tamanho As String = String.Empty
            Dim codigoBarras As String = String.Empty
            Dim data As String = String.Empty


            For Each _item As dProdutoItem In colecaoItem
                Select Case _item.caracteristicas_codigo
                    Case "codigoBarras"
                        codigoBarras = _item.valor
                    Case "tamanho"
                        tamanho = _item.valor
                End Select
            Next

            data = Now().Day.ToString().PadLeft(2, "0"c) & Now().Month.ToString().PadLeft(2, "0"c) & Now().Year.ToString().PadLeft(4, "0"c)

            If imprimeDataEtiqueta.Equals("1") Then
                data = Now().Day.ToString().PadLeft(2, "0"c) & Now().Month.ToString().PadLeft(2, "0"c) & Now().Year.ToString().PadLeft(4, "0"c)
            Else
                data = String.Empty
            End If

            '-- Loja
            _campo1 = IIf(loja.Equals(Nothing), String.Empty, loja)
            '-- Referencia
            _campo2 = IIf(produto.referencia Is Nothing, String.Empty, produto.referencia)
            '-- Fornecedor
            _campo3 = IIf(fabricante Is Nothing, String.Empty, fabricante)
            '-- Data Atual
            _campo4 = IIf(data Is Nothing, String.Empty, data)
            '-- Descrição Produto
            _campo5 = IIf(produto.descricao Is Nothing, String.Empty, produto.descricao)
            '-- Cor
            _campo6 = IIf(cor Is Nothing, String.Empty, cor)
            '-- Tamanho
            _campo7 = IIf(tamanho Is Nothing, String.Empty, tamanho)
            If imprimirPreco Then
                '-- Valor
                _campo8 = IIf(produto.valorVenda.Equals(Nothing), String.Empty, produto.valorVenda)
            Else
                '-- sem Valor
                _campo8 = String.Empty
            End If
            '-- Codigo de Barras
            _codigoBarras = IIf(codigoBarras Is Nothing, String.Empty, codigoBarras)

        End Sub

        Public Sub ImprimirColecaoEtiquetaProduto(ByVal colecao As ColecaoEtiquetaProdutoImpressao, ByVal imprimirPreco As Boolean, ByVal tamanho As String, ByVal imprimeDataEtiqueta As String)

            Dim impressao As ncComum.Impressao
            Dim linha As String
            Dim contador As Integer

            If colecao.Count > 0 Then
                colecaoEtiqueta = New ColecaoEtiqueta()
                impressao = New ncComum.Impressao
                contador = 1

                For Each itemEtiqueta As dEtiquetaProdutoImpressao In colecao
                    If contador Mod 2 <> 0 Then
                        MontarEtiquetaProdutoInicio()
                        MontarCamposEtiquetaProduto(itemEtiqueta.loja, itemEtiqueta.fabricante, itemEtiqueta.produto, itemEtiqueta.colecaoProdutoItem, itemEtiqueta.corNome, imprimirPreco, imprimeDataEtiqueta)
                        MontarEtiquetaProdutoEsquerda(tamanho)
                    End If

                    If contador Mod 2 = 0 Then
                        MontarCamposEtiquetaProduto(itemEtiqueta.loja, itemEtiqueta.fabricante, itemEtiqueta.produto, itemEtiqueta.colecaoProdutoItem, itemEtiqueta.corNome, imprimirPreco, imprimeDataEtiqueta)
                        MontarEtiquetaProdutoDireita(tamanho)
                        MontarEtiquetaProdutoFim()
                    End If

                    contador = contador + 1
                Next

                If contador Mod 2 = 0 Then
                    MontarEtiquetaProdutoFim()
                End If

                '-- Imprimir etiqueta
                impressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("ETIQUETA"))
                For Each colecaoLinha In colecaoEtiqueta
                    For Each linha In colecaoLinha
                        impressao.Write(linha)
                    Next
                Next
                impressao.EndWrite()
            End If

        End Sub

        Private Sub MontarEtiquetaProdutoInicio()
            colecaoLinha = New ColecaoLinha()

            colecaoLinha.Add(Chr(2) & "L" & Chr(13))
            colecaoLinha.Add(Chr(2) & "m" & Chr(13))
            'colecaoLinha.Add(Chr(2) & "e" & Chr(13))
            colecaoLinha.Add(Chr(2) & "r" & Chr(13))
            colecaoLinha.Add("PC" & Chr(13))
            colecaoLinha.Add("D11" & Chr(13))
            colecaoLinha.Add("H14" & Chr(13))
            colecaoLinha.Add("z" & Chr(13))
            colecaoLinha.Add(Chr(13))

            colecaoEtiqueta.Add(colecaoLinha)
        End Sub

        Private Sub MontarEtiquetaProdutoEsquerda(ByVal tamanho As String)
            Dim c1 As String = ""
            Dim c2 As String = ""
            Dim c3 As String = ""
            Dim c4 As String = ""
            Dim c5 As String = ""
            Dim c6 As String = ""
            Dim c7 As String = ""
            Dim c8 As String = ""
            Dim cb As String = ""

            c1 = _campo1.PadRight(22, " "c).Substring(0, 22)
            c2 = _campo2.PadRight(15, " "c).Substring(0, 15)
            c3 = _campo3.PadRight(14, " "c).Substring(0, 14)
            c4 = _campo4.PadLeft(14, " "c).Substring(0, 14)
            c5 = _campo5.PadRight(14, " "c).Substring(0, 14)
            c6 = _campo6.PadLeft(14, " "c).Substring(0, 14)
            c7 = _campo7.PadRight(11, " "c).Substring(0, 11)
            c8 = _campo8.PadLeft(11, " "c).Substring(0, 11)
            cb = _codigoBarras.PadLeft(14, " "c).Substring(0, 14).Trim()

            colecaoLinha = New ColecaoLinha()
            If tamanho.Equals("50x70") Then
                colecaoLinha.Add("122200005900030" & c1 & Chr(13))
                colecaoLinha.Add("113200005000030" & c2 & Chr(13))
                colecaoLinha.Add("121100004200030" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("121100003600030" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d7307002600030" & cb & Chr(13))
                colecaoLinha.Add("112200001600100" & cb & Chr(13))
                colecaoLinha.Add("121200000500030" & c7 & "       " & c8 & Chr(13))
            Else
                colecaoLinha.Add("121100002100050" & c1 & Chr(13))
                colecaoLinha.Add("112100001900050" & c2 & Chr(13))
                colecaoLinha.Add("111100001700050" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("111100001500050" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d6207000700050" & cb & Chr(13))
                colecaoLinha.Add("121100000400120" & cb & Chr(13))
                colecaoLinha.Add("121100000100050" & c7 & " " & c8 & Chr(13))
            End If
            colecaoEtiqueta.Add(colecaoLinha)
        End Sub

        Private Sub MontarEtiquetaProdutoDireita(ByVal tamanho As String)
            Dim c1 As String = ""
            Dim c2 As String = ""
            Dim c3 As String = ""
            Dim c4 As String = ""
            Dim c5 As String = ""
            Dim c6 As String = ""
            Dim c7 As String = ""
            Dim c8 As String = ""
            Dim cb As String = ""

            c1 = _campo1.PadRight(22, " "c).Substring(0, 22)
            c2 = _campo2.PadRight(15, " "c).Substring(0, 15)
            c3 = _campo3.PadRight(14, " "c).Substring(0, 14)
            c4 = _campo4.PadLeft(14, " "c).Substring(0, 14)
            c5 = _campo5.PadRight(14, " "c).Substring(0, 14)
            c6 = _campo6.PadLeft(14, " "c).Substring(0, 14)
            c7 = _campo7.PadRight(11, " "c).Substring(0, 11)
            c8 = _campo8.PadLeft(11, " "c).Substring(0, 11)
            cb = _codigoBarras.PadLeft(14, " "c).Substring(0, 14).Trim()

            colecaoLinha = New ColecaoLinha()

            If tamanho.Equals("50x70") Then
                colecaoLinha.Add("122200005900535" & c1 & Chr(13))
                colecaoLinha.Add("113200005000535" & c2 & Chr(13))
                colecaoLinha.Add("121100004200535" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("121100003600535" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d7307002600535" & cb & Chr(13))
                colecaoLinha.Add("112200001600585" & cb & Chr(13))
                colecaoLinha.Add("121200000500535" & c7 & "       " & c8 & Chr(13))
            Else
                colecaoLinha.Add("121100002100475" & c1 & Chr(13))
                colecaoLinha.Add("112100001900475" & c2 & Chr(13))
                colecaoLinha.Add("111100001700475" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("111100001500475" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d6207000700475" & cb & Chr(13))
                colecaoLinha.Add("121100000400525" & cb & Chr(13))
                colecaoLinha.Add("121100000100475" & c7 & " " & c8 & Chr(13))
            End If

            colecaoEtiqueta.Add(colecaoLinha)
        End Sub

        Private Sub MontarEtiquetaProdutoFim()
            colecaoLinha = New ColecaoLinha()

            colecaoLinha.Add(Chr(13))
            colecaoLinha.Add("Q0001" + Chr(13))
            colecaoLinha.Add(Chr(2) + "E" + Chr(13))

            colecaoEtiqueta.Add(colecaoLinha)
        End Sub

        Public Sub ImprimirEtiquetaProduto(ByVal loja As String, ByVal fornecedor As String,
            ByVal produto As dProduto, ByVal colecaoItem As ColecaoProdutoItem, ByVal quantidade As Integer,
            ByVal cor As String, ByVal imprimirPreco As Boolean, ByVal tamanho As String, ByVal imprimeDataEtiqueta As String)

            Dim impressao As ncComum.Impressao
            Dim linha As String

            impressao = New ncComum.Impressao

            MontarEtiquetaProduto(loja, fornecedor, produto, colecaoItem, quantidade, cor, imprimirPreco, tamanho, imprimeDataEtiqueta)

            '-- Imprimir etiqueta
            impressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("ETIQUETA"))
            For Each colecaoLinha In colecaoEtiqueta
                For Each linha In colecaoLinha
                    impressao.Write(linha)
                Next
            Next
            impressao.EndWrite()

        End Sub

        Private Sub MontarEtiquetaProduto(ByVal loja As String, ByVal fornecedor As String,
            ByVal produto As dProduto, ByVal colecaoItem As ColecaoProdutoItem, ByVal quantidade As Integer,
            ByVal cor As String, ByVal imprimirPreco As Boolean, ByVal tamanho As String, ByVal imprimeDataEtiqueta As String)
            Dim qtdeLinha As Integer
            Dim cont As Integer
            Dim colunaDireita As Boolean

            MontarCamposEtiquetaProduto(loja, fornecedor, produto, colecaoItem, cor, imprimirPreco, imprimeDataEtiqueta)

            cont = 0
            If (quantidade Mod 2) > 0 Then
                qtdeLinha = ((quantidade - 1) / 2) + 1
                colunaDireita = False
            Else
                qtdeLinha = quantidade / 2
                colunaDireita = True
            End If

            colecaoEtiqueta = New ColecaoEtiqueta()

            For cont = 1 To qtdeLinha
                If cont = qtdeLinha Then
                    PreencherDadosEtiquetaProduto(colunaDireita, tamanho)
                Else
                    PreencherDadosEtiquetaProduto(True, tamanho)
                End If
            Next
        End Sub

        Private Sub PreencherDadosEtiquetaProduto(ByVal colunaDireita As Boolean, ByVal tamanho As String)
            Dim c1 As String = ""
            Dim c2 As String = ""
            Dim c3 As String = ""
            Dim c4 As String = ""
            Dim c5 As String = ""
            Dim c6 As String = ""
            Dim c7 As String = ""
            Dim c8 As String = ""
            Dim cb As String = ""

            c1 = _campo1.PadRight(22, " "c).Substring(0, 22)
            c2 = _campo2.PadRight(15, " "c).Substring(0, 15)
            c3 = _campo3.PadRight(14, " "c).Substring(0, 14)
            c4 = _campo4.PadLeft(14, " "c).Substring(0, 14)
            c5 = _campo5.PadRight(14, " "c).Substring(0, 14)
            c6 = _campo6.PadLeft(14, " "c).Substring(0, 14)
            c7 = _campo7.PadRight(11, " "c).Substring(0, 11)
            c8 = _campo8.PadLeft(11, " "c).Substring(0, 11)
            cb = _codigoBarras.PadLeft(14, " "c).Substring(0, 14).Trim()

            colecaoLinha = New ColecaoLinha()

            colecaoLinha.Add(Chr(2) & "L" & Chr(13))
            colecaoLinha.Add(Chr(2) & "m" & Chr(13))
            'colecaoLinha.Add(Chr(2) & "e" & Chr(13))
            colecaoLinha.Add(Chr(2) & "r" & Chr(13))
            colecaoLinha.Add("PC" & Chr(13))
            colecaoLinha.Add("D11" & Chr(13))
            colecaoLinha.Add("H14" & Chr(13))
            colecaoLinha.Add("z" & Chr(13))
            colecaoLinha.Add(Chr(13))
            If colunaDireita = True Then
                If tamanho.Equals("50x70") Then
                    colecaoLinha.Add("122200005900535" & c1 & Chr(13))
                    colecaoLinha.Add("113200005000535" & c2 & Chr(13))
                    colecaoLinha.Add("121100004200535" & c3 & "  " & c4 & Chr(13))
                    colecaoLinha.Add("121100003600535" & c5 & "  " & c6 & Chr(13))
                    colecaoLinha.Add("1d7307002600535" & cb & Chr(13))
                    colecaoLinha.Add("112200001600585" & cb & Chr(13))
                    colecaoLinha.Add("121200000500535" & c7 & "       " & c8 & Chr(13))
                Else
                    colecaoLinha.Add("121100002100450" & c1 & Chr(13))
                    colecaoLinha.Add("112100001900450" & c2 & Chr(13))
                    colecaoLinha.Add("111100001700450" & c3 & "  " & c4 & Chr(13))
                    colecaoLinha.Add("111100001500450" & c5 & "  " & c6 & Chr(13))
                    colecaoLinha.Add("1d6207000700450" & cb & Chr(13))
                    colecaoLinha.Add("121100000400520" & cb & Chr(13))
                    colecaoLinha.Add("121100000100450" & c7 & " " & c8 & Chr(13))
                End If
            End If
            If tamanho.Equals("50x70") Then
                colecaoLinha.Add("122200005900030" & c1 & Chr(13))
                colecaoLinha.Add("113200005000030" & c2 & Chr(13))
                colecaoLinha.Add("121100004200030" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("121100003600030" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d7307002600030" & cb & Chr(13))
                colecaoLinha.Add("112200001600100" & cb & Chr(13))
                colecaoLinha.Add("121200000500030" & c7 & "       " & c8 & Chr(13))
            Else
                colecaoLinha.Add("121100002100050" & c1 & Chr(13))
                colecaoLinha.Add("112100001900050" & c2 & Chr(13))
                colecaoLinha.Add("111100001700050" & c3 & "  " & c4 & Chr(13))
                colecaoLinha.Add("111100001500050" & c5 & "  " & c6 & Chr(13))
                colecaoLinha.Add("1d6207000700050" & cb & Chr(13))
                colecaoLinha.Add("121100000400120" & cb & Chr(13))
                colecaoLinha.Add("121100000100050" & c7 & " " & c8 & Chr(13))
            End If
            colecaoLinha.Add(Chr(13))
            colecaoLinha.Add("Q0001" + Chr(13))
            colecaoLinha.Add(Chr(2) + "E" + Chr(13))

            colecaoEtiqueta.Add(colecaoLinha)
        End Sub

    End Class

    Public Class ColecaoEtiquetaMalaDireta
        Inherits List(Of dEtiquetaMalaDireta)
    End Class

    Public Class dEtiquetaMalaDireta
        Private _nomeCliente As String
        Private _logradouro As String
        Private _numero As String
        Private _complemento As String
        Private _bairro As String
        Private _cidade As String
        Private _estado As String
        Private _cep As String

        Public Property NomeCliente() As String
            Set(ByVal value As String)
                _nomeCliente = value
            End Set
            Get
                Return _nomeCliente
            End Get
        End Property

        Public Property Logradouro() As String
            Set(ByVal value As String)
                _logradouro = value
            End Set
            Get
                Return _logradouro
            End Get
        End Property

        Public Property Numero() As String
            Set(ByVal value As String)
                _numero = value
            End Set
            Get
                Return _numero
            End Get
        End Property

        Public Property Complemento() As String
            Set(ByVal value As String)
                _complemento = value
            End Set
            Get
                Return _complemento
            End Get
        End Property

        Public Property Bairro() As String
            Set(ByVal value As String)
                _bairro = value
            End Set
            Get
                Return _bairro
            End Get
        End Property

        Public Property Cidade() As String
            Set(ByVal value As String)
                _cidade = value
            End Set
            Get
                Return _cidade
            End Get
        End Property

        Public Property Estado() As String
            Set(ByVal value As String)
                _estado = value
            End Set
            Get
                Return _estado
            End Get
        End Property

        Public Property Cep() As String
            Get
                Return _cep
            End Get
            Set(ByVal value As String)
                _cep = value
            End Set
        End Property

        Public Sub New()
            Me.NomeCliente = String.Empty
            Me.Logradouro = String.Empty
            Me.Numero = String.Empty
            Me.Complemento = String.Empty
            Me.Bairro = String.Empty
            Me.Cidade = String.Empty
            Me.Estado = String.Empty
            Me.Cep = String.Empty
        End Sub

        Public Sub New(ByVal nome As String, ByVal logradouro As String, ByVal numero As String, ByVal complemento As String, ByVal bairro As String, ByVal cidade As String, ByVal estado As String, ByVal cep As String)
            If IsNothing(nome) Then
                Me.NomeCliente = String.Empty
            Else
                Me.NomeCliente = nome
            End If

            If IsNothing(logradouro) Then
                Me.Logradouro = String.Empty
            Else
                Me.Logradouro = logradouro
            End If

            If IsNothing(numero) Then
                Me.Numero = String.Empty
            Else
                Me.Numero = numero
            End If

            If IsNothing(complemento) Then
                Me.Complemento = String.Empty
            Else
                Me.Complemento = complemento
            End If

            If IsNothing(bairro) Then
                Me.Bairro = String.Empty
            Else
                Me.Bairro = bairro
            End If

            If IsNothing(cidade) Then
                Me.Cidade = String.Empty
            Else
                Me.Cidade = cidade
            End If

            If IsNothing(estado) Then
                Me.Estado = String.Empty
            Else
                Me.Estado = estado
            End If

            If IsNothing(cep) Then
                Me.Cep = String.Empty
            Else
                Me.Cep = cep
            End If

        End Sub

        Public Sub ImprimirEtiquetaMalaDireta(ByVal colecaoEtiquetaMalaDireta As ColecaoEtiquetaMalaDireta)

            Dim ColecaoLinha As New ColecaoLinha()
            Dim colecaoEtiqueta As New ColecaoEtiqueta

            Dim impressao As ncComum.Impressao
            Dim linha As String

            For Each etiqueta As dEtiquetaMalaDireta In colecaoEtiquetaMalaDireta
                ColecaoLinha.Add(Chr(2) & "L" & Chr(13))
                ColecaoLinha.Add(Chr(2) & "m" & Chr(13))
                'ColecaoLinha.Add(Chr(2) & "e" & Chr(13))
                ColecaoLinha.Add(Chr(2) & "r" & Chr(13))
                ColecaoLinha.Add("PC" & Chr(13))
                ColecaoLinha.Add("D11" & Chr(13))
                ColecaoLinha.Add("H14" & Chr(13))
                ColecaoLinha.Add("z" & Chr(13))
                ColecaoLinha.Add(Chr(13))
                ColecaoLinha.Add("131100202100050" & etiqueta.NomeCliente & Chr(13))
                ColecaoLinha.Add("131100201700050" & etiqueta.Logradouro & " " & etiqueta.Numero & " " & etiqueta.Complemento & Chr(13))
                ColecaoLinha.Add("131100201300050" & etiqueta.Bairro & Chr(13))
                ColecaoLinha.Add("131100200900050" & etiqueta.Cidade & " - " & etiqueta.Estado & Chr(13))
                ColecaoLinha.Add("131100200500050" & etiqueta.Cep & Chr(13))
                ColecaoLinha.Add(Chr(13))
                ColecaoLinha.Add("Q0001" + Chr(13))
                ColecaoLinha.Add(Chr(2) + "E" + Chr(13))
                colecaoEtiqueta.Add(ColecaoLinha)
            Next

            impressao = New ncComum.Impressao

            '-- Imprimir etiqueta
            impressao.StartWrite(System.Configuration.ConfigurationManager.AppSettings("ETIQUETA"))
            For Each ColecaoLinha In colecaoEtiqueta
                For Each linha In ColecaoLinha
                    impressao.Write(linha)
                Next
            Next
            impressao.EndWrite()
        End Sub
    End Class

    Public Class EtiquetaCrediario

        Private _nomeLoja As String
        Private _nomeCliente As String
        Private _crediario As dCrediario
        Private _colecaoParcelas As ColecaoParcelas
        Private _colecaoLinha As ColecaoLinha
        Private _colecaoEtiqueta As ColecaoEtiqueta
        Private _contEtiqueta As Integer

        Public WriteOnly Property nomeLoja() As String
            Set(ByVal value As String)
                _nomeLoja = (value)
            End Set
        End Property

        Public WriteOnly Property nomeCliente() As String
            Set(ByVal value As String)
                _nomeCliente = (value)
            End Set
        End Property

        Public Function MontarEtiqueta(ByVal colecaoParcelas As ColecaoParcelas, ByVal crediario As dCrediario, ByVal NomeCliente As String, ByVal nomeLoja As String, ByVal tamanho As String) As ColecaoEtiqueta
            Dim qtdeResumo As Integer
            Dim qtdeParcelas As Integer
            Dim contador As Integer

            _colecaoParcelas = colecaoParcelas
            _crediario = crediario
            _nomeCliente = NomeCliente
            _nomeLoja = nomeLoja

            qtdeParcelas = _colecaoParcelas.Count
            _contEtiqueta = 1
            _colecaoEtiqueta = New ColecaoEtiqueta()

            '_colecaoLinha = New ColecaoLinha()
            '_colecaoLinha.Add(Chr(2) & "f320" & Chr(13))
            '_colecaoEtiqueta.Add(_colecaoLinha)

            '-- Calcular qtde de etiquetas de resumo
            qtdeResumo = qtdeParcelas \ 7

            If qtdeParcelas Mod 7 > 0 Then
                qtdeResumo = qtdeResumo + 1
            End If

            For contador = 1 To qtdeResumo
                '-- Se etiqueta IMPAR, monta inicio
                If _contEtiqueta Mod 2 <> 0 Then
                    _colecaoLinha = New ColecaoLinha()
                    MontarEtiquetaInicio()
                End If

                MontarEtiquetaResumo(contador, tamanho)

                '-- Se etiqueta PAR, monta fim
                If _contEtiqueta Mod 2 = 0 Then
                    MontarEtiquetaFim()
                    _colecaoEtiqueta.Add(_colecaoLinha)
                End If

                _contEtiqueta = _contEtiqueta + 1
            Next

            For contador = 1 To qtdeParcelas
                '-- Se etiqueta IMPAR, monta inicio
                If _contEtiqueta Mod 2 <> 0 Then
                    _colecaoLinha = New ColecaoLinha()
                    MontarEtiquetaInicio()
                End If

                MontarEtiquetaParcela(contador, tamanho)

                '-- Se etiqueta PAR, monta fim
                If _contEtiqueta Mod 2 = 0 Then
                    MontarEtiquetaFim()
                    _colecaoEtiqueta.Add(_colecaoLinha)
                End If

                _contEtiqueta = _contEtiqueta + 1
            Next

            If _contEtiqueta Mod 2 = 0 Then
                MontarEtiquetaFim()
                _colecaoEtiqueta.Add(_colecaoLinha)
            End If

            '_colecaoLinha = New ColecaoLinha()
            '_colecaoLinha.Add(Chr(2) & "F" & Chr(13))
            '_colecaoEtiqueta.Add(_colecaoLinha)

            MontarEtiqueta = _colecaoEtiqueta

        End Function

        Private Sub MontarEtiquetaResumo(ByVal contador As Integer, ByVal tamanho As String)
            Dim posicao As String
            Dim indice As Integer
            Dim parcela As dParcelas

            '-- Se impar, etiqueta esquerda
            If _contEtiqueta Mod 2 <> 0 Then
                posicao = "0040"
            Else '-- Se par, etiqueta direita
                posicao = "0435"
            End If

            If tamanho.Equals("50x70") Then
                _colecaoLinha.Add("12220000240" & posicao & _nomeLoja)
                _colecaoLinha.Add("12110000210" & posicao & _crediario.clienteId & "-" & _nomeCliente)

            Else
                _colecaoLinha.Add("12110000215" & posicao & _nomeLoja)
                _colecaoLinha.Add("11110000195" & posicao & _crediario.clienteId & "-" & _nomeCliente)

            End If

            indice = (((contador - 1) * 7) + 1)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000175" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 2)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000155" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 3)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000135" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 4)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000115" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 5)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000095" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 6)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000075" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            indice = (((contador - 1) * 7) + 7)
            If (_colecaoParcelas.Count >= indice) Then
                parcela = _colecaoParcelas(indice - 1)
                _colecaoLinha.Add("11110000055" & posicao & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
            End If

            If tamanho.Equals("50x70") Then
                _colecaoLinha.Add("12110000030" & posicao & "TOTAL -->  " & _crediario.ValorTotal.ToString("C"))
                _colecaoLinha.Add("12110000001" & posicao & _crediario.DataVenda & "  CT:" & _crediario.controle.ToString())
            Else
                _colecaoLinha.Add("12110000027" & posicao & "TOTAL -->  " & _crediario.ValorTotal.ToString("C"))
                _colecaoLinha.Add("11110000010" & posicao & _crediario.DataVenda & "  CT:" & _crediario.controle.ToString())
            End If
        End Sub

        Private Sub MontarEtiquetaInicio()
            _colecaoLinha.Add(Chr(2) & "L" & Chr(13))
            _colecaoLinha.Add(Chr(2) & "m" & Chr(13))
            '_colecaoLinha.Add(Chr(2) & "e" & Chr(13))
            _colecaoLinha.Add(Chr(2) & "r" & Chr(13))
            _colecaoLinha.Add("PC" & Chr(13))
            _colecaoLinha.Add("D11" & Chr(13))
            _colecaoLinha.Add("H14" & Chr(13))
            _colecaoLinha.Add("z" & Chr(13))
            _colecaoLinha.Add(Chr(13))
        End Sub

        Private Sub MontarEtiquetaFim()
            _colecaoLinha.Add(Chr(13))
            _colecaoLinha.Add("Q0001" + Chr(13))
            _colecaoLinha.Add(Chr(2) + "E" + Chr(13))
        End Sub

        Private Sub MontarEtiquetaParcela(ByVal indice As Integer, ByVal tamanho As String)
            Dim parcela As dParcelas

            parcela = _colecaoParcelas(indice - 1)

            If tamanho.Equals("50x70") Then
                '-- Se impar, etiqueta esquerda
                If _contEtiqueta Mod 2 <> 0 Then
                    _colecaoLinha.Add("122200002800040" & _nomeLoja)
                    _colecaoLinha.Add("121100002400040" & _crediario.clienteId & "-" & _nomeCliente)
                    _colecaoLinha.Add("121100002100035" & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
                    _colecaoLinha.Add("1d6208501000055" & _colecaoParcelas(indice - 1).codigoBarras)
                    _colecaoLinha.Add("121100000400100" & _colecaoParcelas(indice - 1).codigoBarras)
                Else '-- Se par, etiqueta direita
                    _colecaoLinha.Add("122200002800550" & _nomeLoja)
                    _colecaoLinha.Add("121100002400550" & _crediario.clienteId & "-" & _nomeCliente)
                    _colecaoLinha.Add("121100002100550" & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
                    _colecaoLinha.Add("1d6208501000565" & _colecaoParcelas(indice - 1).codigoBarras)
                    _colecaoLinha.Add("121100000400600" & _colecaoParcelas(indice - 1).codigoBarras)
                End If
            Else
                '-- Se impar, etiqueta esquerda
                If _contEtiqueta Mod 2 <> 0 Then
                    _colecaoLinha.Add("121100002100040" & _nomeLoja)
                    _colecaoLinha.Add("111100001900040" & _crediario.clienteId & "-" & _nomeCliente)
                    _colecaoLinha.Add("121100001600035" & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
                    _colecaoLinha.Add("1d6208500500055" & _colecaoParcelas(indice - 1).codigoBarras)
                    _colecaoLinha.Add("121100000200100" & _colecaoParcelas(indice - 1).codigoBarras)
                Else '-- Se par, etiqueta direita
                    _colecaoLinha.Add("121100002100460" & _nomeLoja)
                    _colecaoLinha.Add("111100001900460" & _crediario.clienteId & "-" & _nomeCliente)
                    _colecaoLinha.Add("121100001600450" & indice.ToString().PadLeft(2, " "c) & "." & _colecaoParcelas(indice - 1).dataVecimento.ToString("dd/MM/yyyy") & " " & _colecaoParcelas(indice - 1).valorReceber.ToString("C"))
                    _colecaoLinha.Add("1d6208500500475" & _colecaoParcelas(indice - 1).codigoBarras)
                    _colecaoLinha.Add("121100000200500" & _colecaoParcelas(indice - 1).codigoBarras)
                End If
            End If

        End Sub

    End Class

End Namespace
