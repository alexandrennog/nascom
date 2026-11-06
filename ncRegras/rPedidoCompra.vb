Imports ncDados.nsPedidoCompra
Imports ncPersistencia.nsPedidoCompra
Imports ncComum.nsExcecao

Namespace nsPedidoCompra

    ' Regras do Pedido de Compra (validacoes antes de gravar e baixa automatica
    ' chamada pela tela de Entrada de Estoque).
    Public Class rPedidoCompra

        Public Function Listar(ByVal fabricante_cid As Nullable(Of Integer),
                               ByVal dataInicial As Nullable(Of DateTime),
                               ByVal dataFinal As Nullable(Of DateTime),
                               ByVal situacao As String) As ColecaoPedidoCompra
            Try
                Return New pPedidoCompra().Listar(fabricante_cid, dataInicial, dataFinal, situacao)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Listar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function Consultar(ByVal cid As Integer) As dPedidoCompra
            Try
                Return New pPedidoCompra().Consultar(cid)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Consultar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function ListarProdutosFabricante(ByVal fabricante_cid As Integer) As ColecaoPedidoCompraProduto
            Try
                Return New pPedidoCompra().ListarProdutosFabricante(fabricante_cid)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em ListarProdutosFabricante PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Function ListarGradeProduto(ByVal produtos_cid As Integer) As ColecaoPedidoCompraGrade
            Try
                Return New pPedidoCompra().ListarGradeProduto(produtos_cid)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em ListarGradeProduto PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        ' Confere o pedido antes de gravar. Devolve a lista de problemas
        ' encontrados (vazia = pode gravar). "original" e o pedido como esta no
        ' banco (Nothing quando e pedido novo), para comparar com o que ja foi
        ' entregue.
        Public Function Validar(ByVal dados As dPedidoCompra, ByVal original As dPedidoCompra, ByVal cidsExcluidos As List(Of Integer)) As List(Of String)

            Dim erros As New List(Of String)
            Dim totalBruto As Decimal = 0
            Dim totalPares As Integer = 0
            Dim chaves As New List(Of String)

            If Not dados.fabricante_cid.HasValue OrElse dados.fabricante_cid.Value <= 0 Then
                erros.Add("Informe o fabricante (marca).")
            End If

            If Not dados.data.HasValue Then
                erros.Add("Informe a data do pedido.")
            End If

            If dados.previsaoEntrega.HasValue AndAlso dados.data.HasValue AndAlso dados.previsaoEntrega.Value.Date < dados.data.Value.Date Then
                erros.Add("A previsão de entrega não pode ser antes da data do pedido.")
            End If

            For Each item As dPedidoCompraItem In dados.itens
                Dim nome As String = item.referencia & " " & item.cor & " tam. " & item.tamanho

                If item.quantidade < 0 Then
                    erros.Add(nome & ": quantidade não pode ser negativa.")
                End If

                If item.valorUnitario < 0 Then
                    erros.Add(nome & ": valor não pode ser negativo.")
                End If

                If item.quantidade < item.quantidadeEntregue Then
                    erros.Add(nome & ": já foram entregues " & item.quantidadeEntregue & " pares; a quantidade pedida não pode ser menor que isso.")
                End If

                Dim chave As String = item.produtos_cid.ToString() & "|" & item.codigoBarras
                If chaves.Contains(chave) Then
                    erros.Add(nome & ": item repetido no pedido.")
                Else
                    chaves.Add(chave)
                End If

                totalBruto += item.quantidade * item.valorUnitario
                totalPares += item.quantidade
            Next

            If totalPares <= 0 Then
                erros.Add("O pedido precisa ter pelo menos um item com quantidade.")
            End If

            If dados.descontoValor < 0 Then
                erros.Add("O desconto não pode ser negativo.")
            ElseIf dados.descontoValor > totalBruto Then
                erros.Add("O desconto (R$ " & dados.descontoValor.ToString("N2") & ") é maior que o valor bruto do pedido (R$ " & totalBruto.ToString("N2") & ").")
            End If

            If Not original Is Nothing Then
                If original.situacao = "C" Then
                    erros.Add("Pedido cancelado não pode ser alterado. Reabra o pedido antes.")
                End If

                ' Fabricante nao pode mudar depois que ja houve entrega
                If original.fabricante_cid.GetValueOrDefault() <> dados.fabricante_cid.GetValueOrDefault() Then
                    For Each itemOriginal As dPedidoCompraItem In original.itens
                        If itemOriginal.quantidadeEntregue > 0 Then
                            erros.Add("Este pedido já teve entregas; o fabricante não pode ser trocado.")
                            Exit For
                        End If
                    Next
                End If

                If Not cidsExcluidos Is Nothing Then
                    For Each itemOriginal As dPedidoCompraItem In original.itens
                        If itemOriginal.cid.HasValue AndAlso cidsExcluidos.Contains(itemOriginal.cid.Value) AndAlso itemOriginal.quantidadeEntregue > 0 Then
                            erros.Add(itemOriginal.referencia & " " & itemOriginal.cor & " tam. " & itemOriginal.tamanho & ": já teve entrega e não pode ser removido do pedido.")
                        End If
                    Next
                End If
            End If

            Return erros

        End Function

        ' Grava (inclui ou altera). Itens com quantidade 0 que ainda nao existem
        ' no banco sao ignorados; itens existentes que ficaram com 0 e sem
        ' entrega sao removidos. Devolve o cid do pedido.
        Public Function Salvar(ByVal dados As dPedidoCompra, ByVal cidsExcluidos As List(Of Integer)) As Integer

            Dim persistencia As New pPedidoCompra
            Dim original As dPedidoCompra = Nothing
            Dim erros As List(Of String)
            Dim excluir As New List(Of Integer)
            Dim itensGravar As New ColecaoPedidoCompraItem

            Try

                If Not cidsExcluidos Is Nothing Then
                    excluir.AddRange(cidsExcluidos)
                End If

                For Each item As dPedidoCompraItem In dados.itens
                    If item.quantidade = 0 AndAlso item.quantidadeEntregue = 0 Then
                        If item.cid.HasValue AndAlso item.cid.Value > 0 AndAlso Not excluir.Contains(item.cid.Value) Then
                            excluir.Add(item.cid.Value)
                        End If
                    Else
                        itensGravar.Add(item)
                    End If
                Next

                dados.itens = itensGravar

                If dados.cid.HasValue AndAlso dados.cid.Value > 0 Then
                    original = persistencia.Consultar(dados.cid.Value)
                    If original Is Nothing Then
                        Throw New ExcecaoNascomercio("Pedido não encontrado. Ele pode ter sido excluído em outro terminal.")
                    End If

                    ' O "entregue" que vale e o do banco, nao o da tela: pode ter
                    ' entrado mercadoria (baixa automatica em outro terminal)
                    ' enquanto este pedido estava aberto para edicao.
                    For Each item As dPedidoCompraItem In dados.itens
                        If item.cid.HasValue Then
                            Dim cidItem As Integer = item.cid.Value
                            Dim noBanco As dPedidoCompraItem = original.itens.Find(Function(i) i.cid.HasValue AndAlso i.cid.Value = cidItem)
                            If Not noBanco Is Nothing Then
                                item.quantidadeEntregue = noBanco.quantidadeEntregue
                            End If
                        End If
                    Next
                End If

                erros = Validar(dados, original, excluir)

                If erros.Count > 0 Then
                    Throw New ExcecaoNascomercio("Não foi possível gravar o pedido:" & vbCrLf & vbCrLf & "- " & String.Join(vbCrLf & "- ", erros.ToArray()))
                End If

                If original Is Nothing Then
                    Return persistencia.Incluir(dados)
                Else
                    persistencia.Alterar(dados, excluir)
                    Return dados.cid.Value
                End If

            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Salvar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try

        End Function

        ' Exclui o pedido. Devolve False (sem excluir) se ele ja teve entrega -
        ' nesse caso o certo e cancelar.
        Public Function Excluir(ByVal cid As Integer) As Boolean
            Try
                Return New pPedidoCompra().Excluir(cid)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Excluir PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

        Public Sub Cancelar(ByVal cid As Integer)
            Try
                Dim persistencia As New pPedidoCompra
                persistencia.AlterarCancelamento(cid, True)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Cancelar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        Public Sub Reabrir(ByVal cid As Integer)
            Try
                Dim persistencia As New pPedidoCompra
                persistencia.AlterarCancelamento(cid, False)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Reabrir PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Sub

        ' Baixa automatica: chamada pela Entrada de Estoque para cada tamanho
        ' que entrou. Nao faz nada para quantidade <= 0 (saida de estoque).
        Public Function Baixar(ByVal produtos_cid As Integer, ByVal codigoBarras As String, ByVal quantidade As Integer,
                               ByVal notaFiscalNumero As String, ByVal notaFiscalSerie As String,
                               ByVal usuario_cid As Nullable(Of Integer)) As dPedidoCompraBaixa
            Try
                If quantidade <= 0 OrElse String.IsNullOrEmpty(codigoBarras) Then
                    Return New dPedidoCompraBaixa()
                End If

                Return New pPedidoCompra().Baixar(produtos_cid, codigoBarras.Trim(), quantidade, notaFiscalNumero, notaFiscalSerie, usuario_cid)
            Catch nex As ExcecaoNascomercio
                Throw
            Catch ex As Exception
                Throw New ExcecaoNascomercio("Erro em Baixar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)
            End Try
        End Function

    End Class

End Namespace
