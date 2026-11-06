Imports System.Globalization
Imports ncDados.nsPedidoCompra
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsPedidoCompra

    ' Acesso ao banco do Pedido de Compra (tabelas pedidocompra,
    ' pedidocompraitem e pedidocomprabaixa - script "41 - pedido_compra.sql").
    '
    ' Todo valor que vai para o SQL passa por SqlTexto/SqlDecimal/SqlData/
    ' SqlInteiro abaixo, que escapam aspas e usam sempre ponto como separador
    ' decimal (independente da configuracao regional do Windows da loja).
    Public Class pPedidoCompra

        Private Const MARCADOR_PEDIDO As String = "{PEDIDO_CID}"

#Region "Consultas"

        Public Function Listar(ByVal fabricante_cid As Nullable(Of Integer),
                               ByVal dataInicial As Nullable(Of DateTime),
                               ByVal dataFinal As Nullable(Of DateTime),
                               ByVal situacao As String) As ColecaoPedidoCompra

            Dim retorno As New ColecaoPedidoCompra
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet
            Dim sql As String
            Dim filtro As New List(Of String)

            Try

                If fabricante_cid.HasValue Then
                    filtro.Add("p.fabricante_cid = " & SqlInteiro(fabricante_cid))
                End If

                If dataInicial.HasValue Then
                    filtro.Add("p.data >= " & SqlData(dataInicial))
                End If

                If dataFinal.HasValue Then
                    filtro.Add("p.data <= " & SqlData(dataFinal))
                End If

                If Not String.IsNullOrEmpty(situacao) Then
                    filtro.Add("p.situacao = " & SqlTexto(situacao))
                End If

                sql = " SELECT p.cid, p.numero, p.fabricante_cid, f.nome AS fabricante, p.data, p.previsaoEntrega, " &
                      "        p.descontoValor, p.situacao, p.observacao, " &
                      "        COALESCE(SUM(i.quantidade), 0) AS totalPares, " &
                      "        COALESCE(SUM(i.quantidade * i.valorUnitario), 0) AS totalBruto, " &
                      "        COALESCE(SUM(i.quantidadeEntregue), 0) AS totalEntregue " &
                      "   FROM pedidocompra p " &
                      "  INNER JOIN fabricantes f ON f.cid = p.fabricante_cid " &
                      "   LEFT JOIN pedidocompraitem i ON i.pedidocompra_cid = p.cid "

                If filtro.Count > 0 Then
                    sql &= " WHERE " & String.Join(" AND ", filtro.ToArray())
                End If

                sql &= " GROUP BY p.cid, p.numero, p.fabricante_cid, f.nome, p.data, p.previsaoEntrega, p.descontoValor, p.situacao, p.observacao " &
                       " ORDER BY p.data DESC, p.cid DESC "

                ds = acessoBanco.ExecutarDS(sql)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    For Each row As DataRow In ds.Tables(0).Rows
                        Dim item As dPedidoCompra = LerCabecalho(row)
                        item.totalPares = CInt(RetornarDecimalOuZero(row("totalPares")))
                        item.totalBruto = RetornarDecimalOuZero(row("totalBruto"))
                        item.totalEntregue = CInt(RetornarDecimalOuZero(row("totalEntregue")))
                        retorno.Add(item)
                    Next
                End If

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Listar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        ' Cabecalho + itens de um pedido (Nothing se nao existir)
        Public Function Consultar(ByVal cid As Integer) As dPedidoCompra

            Dim retorno As dPedidoCompra = Nothing
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet
            Dim sql As String

            Try

                sql = " SELECT p.cid, p.numero, p.fabricante_cid, f.nome AS fabricante, p.data, p.previsaoEntrega, " &
                      "        p.descontoValor, p.situacao, p.observacao " &
                      "   FROM pedidocompra p " &
                      "  INNER JOIN fabricantes f ON f.cid = p.fabricante_cid " &
                      "  WHERE p.cid = " & SqlInteiro(cid)

                ds = acessoBanco.ExecutarDS(sql)

                If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                    Return Nothing
                End If

                retorno = LerCabecalho(ds.Tables(0).Rows(0))

                sql = " SELECT i.cid, i.pedidocompra_cid, i.produtos_cid, pr.referencia, pr.descricao, co.nome AS cor, " &
                      "        i.codigoBarras, i.tamanho, i.quantidade, i.valorUnitario, i.quantidadeEntregue " &
                      "   FROM pedidocompraitem i " &
                      "  INNER JOIN produtos pr ON pr.cid = i.produtos_cid " &
                      "   LEFT JOIN cor co ON co.cid = pr.cor_cid " &
                      "  WHERE i.pedidocompra_cid = " & SqlInteiro(cid) &
                      "  ORDER BY pr.referencia, co.nome, i.tamanho, i.cid "

                ds = acessoBanco.ExecutarDS(sql)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    For Each row As DataRow In ds.Tables(0).Rows
                        Dim item As New dPedidoCompraItem
                        item.cid = cFuncoes.RetornarInteiro(row("cid"))
                        item.pedidocompra_cid = cFuncoes.RetornarInteiro(row("pedidocompra_cid"))
                        item.produtos_cid = cFuncoes.RetornarInteiro(row("produtos_cid"))
                        item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                        item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                        item.cor = cFuncoes.RetornarTexto(row("cor"))
                        item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                        item.tamanho = cFuncoes.RetornarTexto(row("tamanho"))
                        item.quantidade = CInt(RetornarDecimalOuZero(row("quantidade")))
                        item.valorUnitario = RetornarDecimalOuZero(row("valorUnitario"))
                        item.quantidadeEntregue = CInt(RetornarDecimalOuZero(row("quantidadeEntregue")))
                        retorno.itens.Add(item)
                    Next
                End If

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Consultar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        ' Produtos (referencia + cor) ativos de um fabricante
        Public Function ListarProdutosFabricante(ByVal fabricante_cid As Integer) As ColecaoPedidoCompraProduto

            Dim retorno As New ColecaoPedidoCompraProduto
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet
            Dim sql As String

            Try

                sql = " SELECT p.cid, p.referencia, p.descricao, co.nome AS cor, p.valorCompra " &
                      "   FROM produtos p " &
                      "   LEFT JOIN cor co ON co.cid = p.cor_cid " &
                      "  WHERE p.fabricante_cid = " & SqlInteiro(fabricante_cid) &
                      "    AND IFNULL(p.situacao, 'A') <> 'I' " &
                      "  ORDER BY p.referencia, p.descricao, co.nome "

                ds = acessoBanco.ExecutarDS(sql)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    For Each row As DataRow In ds.Tables(0).Rows
                        Dim item As New dPedidoCompraProduto
                        item.cid = CInt(RetornarDecimalOuZero(row("cid")))
                        item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                        item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                        item.cor = cFuncoes.RetornarTexto(row("cor"))
                        item.valorCompra = RetornarDecimalOuZero(row("valorCompra"))
                        retorno.Add(item)
                    Next
                End If

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em ListarProdutosFabricante PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        ' Tamanhos (com o codigo de barras de cada um) da grade de um produto.
        ' Mesma estrutura de produtoitem usada em pProdutoItem.ConsultarProdutoItem:
        ' cada "item" da grade tem uma linha por caracteristica (codigoBarras,
        ' tamanho, estoque...).
        Public Function ListarGradeProduto(ByVal produtos_cid As Integer) As ColecaoPedidoCompraGrade

            Dim retorno As New ColecaoPedidoCompraGrade
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet
            Dim sql As String

            Try

                sql = " SELECT pt.valor AS tamanho, pb.valor AS codigoBarras " &
                      "   FROM produtoitem pb " &
                      "  INNER JOIN caracteristicas cb ON cb.cid = pb.caracteristicas_cid AND cb.codigo = 'codigoBarras' " &
                      "   LEFT JOIN produtoitem pt ON pt.produtos_cid = pb.produtos_cid AND pt.item = pb.item " &
                      "        AND pt.caracteristicas_cid = (SELECT ct.cid FROM caracteristicas ct WHERE ct.codigo = 'tamanho' LIMIT 1) " &
                      "  WHERE pb.produtos_cid = " & SqlInteiro(produtos_cid) &
                      "    AND IFNULL(pb.valor, '') <> '' " &
                      "  ORDER BY pb.item "

                ds = acessoBanco.ExecutarDS(sql)

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    For Each row As DataRow In ds.Tables(0).Rows
                        Dim item As New dPedidoCompraGrade
                        item.tamanho = cFuncoes.RetornarTexto(row("tamanho"))
                        item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                        retorno.Add(item)
                    Next
                End If

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em ListarGradeProduto PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

#End Region

#Region "Gravacao"

        ' Grava um pedido novo (cabecalho + itens) numa unica transacao.
        ' Devolve o cid gerado.
        Public Function Incluir(ByVal dados As dPedidoCompra) As Integer

            Dim acessoBanco As New cAcessoBD
            Dim comandos As New List(Of String)
            Dim sqlCabecalho As String

            Try

                sqlCabecalho = " INSERT INTO pedidocompra " &
                               " (numero, fabricante_cid, data, previsaoEntrega, descontoValor, situacao, observacao, usuario_cid, dataInclusao) " &
                               " VALUES (" &
                               SqlTexto(dados.numero) & ", " &
                               SqlInteiro(dados.fabricante_cid) & ", " &
                               SqlData(dados.data) & ", " &
                               SqlData(dados.previsaoEntrega) & ", " &
                               SqlDecimal(dados.descontoValor) & ", " &
                               "'A', " &
                               SqlTexto(dados.observacao) & ", " &
                               SqlInteiro(dados.usuario_cid) & ", " &
                               "NOW())"

                For Each item As dPedidoCompraItem In dados.itens
                    comandos.Add(SqlIncluirItem(item, MARCADOR_PEDIDO))
                Next

                comandos.Add("CALL sp_pedidocompra_atualizar_situacao(" & MARCADOR_PEDIDO & ")")

                Return acessoBanco.ExecutarTransacao(sqlCabecalho, comandos, MARCADOR_PEDIDO)

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Incluir PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

        End Function

        ' Grava as alteracoes de um pedido existente numa unica transacao:
        ' atualiza o cabecalho, altera os itens que ja existiam, inclui os novos
        ' e exclui os que sairam da tela (cidsExcluidos). Item que ja teve
        ' entrega nunca e excluido aqui (a regra de negocio ja barra antes, e o
        ' WHERE quantidadeEntregue = 0 garante no banco).
        Public Sub Alterar(ByVal dados As dPedidoCompra, ByVal cidsExcluidos As List(Of Integer))

            Dim acessoBanco As New cAcessoBD
            Dim comandos As New List(Of String)
            Dim pedidoCid As String = SqlInteiro(dados.cid)

            Try

                comandos.Add(" UPDATE pedidocompra SET " &
                             "   numero = " & SqlTexto(dados.numero) & ", " &
                             "   fabricante_cid = " & SqlInteiro(dados.fabricante_cid) & ", " &
                             "   data = " & SqlData(dados.data) & ", " &
                             "   previsaoEntrega = " & SqlData(dados.previsaoEntrega) & ", " &
                             "   descontoValor = " & SqlDecimal(dados.descontoValor) & ", " &
                             "   observacao = " & SqlTexto(dados.observacao) &
                             " WHERE cid = " & pedidoCid)

                If Not cidsExcluidos Is Nothing Then
                    For Each cidItem As Integer In cidsExcluidos
                        comandos.Add(" DELETE FROM pedidocompraitem " &
                                     "  WHERE cid = " & SqlInteiro(cidItem) &
                                     "    AND pedidocompra_cid = " & pedidoCid &
                                     "    AND quantidadeEntregue = 0 ")
                    Next
                End If

                For Each item As dPedidoCompraItem In dados.itens
                    If item.cid.HasValue AndAlso item.cid.Value > 0 Then
                        comandos.Add(" UPDATE pedidocompraitem SET " &
                                     "   quantidade = " & SqlInteiro(item.quantidade) & ", " &
                                     "   valorUnitario = " & SqlDecimal(item.valorUnitario) &
                                     " WHERE cid = " & SqlInteiro(item.cid) &
                                     "   AND pedidocompra_cid = " & pedidoCid &
                                     "   AND quantidadeEntregue <= " & SqlInteiro(item.quantidade))
                    Else
                        comandos.Add(SqlIncluirItem(item, pedidoCid))
                    End If
                Next

                comandos.Add("CALL sp_pedidocompra_atualizar_situacao(" & pedidoCid & ")")

                acessoBanco.ExecutarTransacao(Nothing, comandos, Nothing)

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Alterar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

        End Sub

        ' Exclui o pedido inteiro. So e chamado para pedido sem nenhuma entrega
        ' (a regra de negocio confere antes); o WHERE repete a protecao no banco.
        Public Function Excluir(ByVal cid As Integer) As Boolean

            Dim acessoBanco As New cAcessoBD
            Dim comandos As New List(Of String)
            Dim ds As DataSet

            Try

                ds = acessoBanco.ExecutarDS(" SELECT COALESCE(SUM(quantidadeEntregue), 0) AS entregue FROM pedidocompraitem WHERE pedidocompra_cid = " & SqlInteiro(cid))

                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    If RetornarDecimalOuZero(ds.Tables(0).Rows(0)("entregue")) > 0 Then
                        Return False
                    End If
                End If

                comandos.Add(" DELETE FROM pedidocompraitem WHERE pedidocompra_cid = " & SqlInteiro(cid))
                comandos.Add(" DELETE FROM pedidocompra WHERE cid = " & SqlInteiro(cid))

                acessoBanco.ExecutarTransacao(Nothing, comandos, Nothing)

                Return True

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Excluir PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

        End Function

        ' Cancela (situacao C) ou reabre (recalcula A/P/E pelos itens) um pedido
        Public Sub AlterarCancelamento(ByVal cid As Integer, ByVal cancelar As Boolean)

            Dim acessoBanco As New cAcessoBD
            Dim comandos As New List(Of String)

            Try

                If cancelar Then
                    comandos.Add(" UPDATE pedidocompra SET situacao = 'C' WHERE cid = " & SqlInteiro(cid))
                Else
                    comandos.Add(" UPDATE pedidocompra SET situacao = 'A' WHERE cid = " & SqlInteiro(cid) & " AND situacao = 'C'")
                    comandos.Add(" CALL sp_pedidocompra_atualizar_situacao(" & SqlInteiro(cid) & ")")
                End If

                acessoBanco.ExecutarTransacao(Nothing, comandos, Nothing)

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em AlterarCancelamento PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

        End Sub

        ' Baixa automatica de uma entrada de estoque nos pedidos em aberto
        ' (procedure sp_pedidocompra_baixar - ver script 41).
        Public Function Baixar(ByVal produtos_cid As Integer, ByVal codigoBarras As String, ByVal quantidade As Integer,
                               ByVal notaFiscalNumero As String, ByVal notaFiscalSerie As String,
                               ByVal usuario_cid As Nullable(Of Integer)) As dPedidoCompraBaixa

            Dim retorno As New dPedidoCompraBaixa
            Dim acessoBanco As New cAcessoBD
            Dim ds As DataSet
            Dim sql As String

            Try

                sql = "CALL sp_pedidocompra_baixar(" &
                      SqlInteiro(produtos_cid) & ", " &
                      SqlTexto(codigoBarras) & ", " &
                      SqlInteiro(quantidade) & ", " &
                      SqlTexto(notaFiscalNumero) & ", " &
                      SqlTexto(notaFiscalSerie) & ", " &
                      SqlInteiro(usuario_cid) & ")"

                ds = acessoBanco.ExecutarDS(sql)

                ' A procedure devolve um unico resultset no final; lemos sempre
                ' o ultimo, por seguranca (mesmo cuidado do pDashboardCompras).
                If Not ds Is Nothing AndAlso ds.Tables.Count > 0 Then
                    Dim dt As DataTable = ds.Tables(ds.Tables.Count - 1)
                    If dt.Rows.Count > 0 Then
                        retorno.quantidadeBaixada = CInt(RetornarDecimalOuZero(dt.Rows(0)("quantidade_baixada")))
                        retorno.quantidadeSemPedido = CInt(RetornarDecimalOuZero(dt.Rows(0)("quantidade_sem_pedido")))
                        retorno.pedidos = cFuncoes.RetornarTexto(dt.Rows(0)("pedidos"))
                    End If
                End If

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                Throw New ExcecaoNascomercio("Erro em Baixar PedidoCompra [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

#End Region

#Region "Auxiliares"

        Private Function SqlIncluirItem(ByVal item As dPedidoCompraItem, ByVal pedidoCid As String) As String
            Return " INSERT INTO pedidocompraitem " &
                   " (pedidocompra_cid, produtos_cid, codigoBarras, tamanho, quantidade, valorUnitario, quantidadeEntregue) " &
                   " VALUES (" &
                   pedidoCid & ", " &
                   SqlInteiro(item.produtos_cid) & ", " &
                   SqlTexto(item.codigoBarras) & ", " &
                   SqlTexto(item.tamanho) & ", " &
                   SqlInteiro(item.quantidade) & ", " &
                   SqlDecimal(item.valorUnitario) & ", " &
                   "0)"
        End Function

        Private Function LerCabecalho(ByVal row As DataRow) As dPedidoCompra
            Dim item As New dPedidoCompra
            item.cid = cFuncoes.RetornarInteiro(row("cid"))
            item.numero = cFuncoes.RetornarTexto(row("numero"))
            item.fabricante_cid = cFuncoes.RetornarInteiro(row("fabricante_cid"))
            item.fabricanteNome = cFuncoes.RetornarTexto(row("fabricante"))
            item.data = RetornarDataOuNada(row("data"))
            item.previsaoEntrega = RetornarDataOuNada(row("previsaoEntrega"))
            item.descontoValor = RetornarDecimalOuZero(row("descontoValor"))
            item.situacao = cFuncoes.RetornarTexto(row("situacao"))
            item.observacao = cFuncoes.RetornarTexto(row("observacao"))
            Return item
        End Function

        ' Texto entre aspas, com aspas e barras escapadas; vazio vira NULL
        Private Shared Function SqlTexto(ByVal valor As String) As String
            If valor Is Nothing OrElse valor.Trim().Length = 0 Then
                Return "NULL"
            End If
            Return "'" & valor.Trim().Replace("\", "\\").Replace("'", "''") & "'"
        End Function

        Private Shared Function SqlInteiro(ByVal valor As Nullable(Of Integer)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return valor.Value.ToString(CultureInfo.InvariantCulture)
        End Function

        Private Shared Function SqlDecimal(ByVal valor As Decimal) As String
            Return Math.Round(valor, 2).ToString("0.00", CultureInfo.InvariantCulture)
        End Function

        Private Shared Function SqlData(ByVal valor As Nullable(Of DateTime)) As String
            If Not valor.HasValue Then
                Return "NULL"
            End If
            Return "'" & valor.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) & "'"
        End Function

        Private Shared Function RetornarDecimalOuZero(ByVal valor As Object) As Decimal
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return 0D
            End If
            Return Convert.ToDecimal(valor, CultureInfo.InvariantCulture)
        End Function

        Private Shared Function RetornarDataOuNada(ByVal valor As Object) As Nullable(Of DateTime)
            If valor Is Nothing OrElse IsDBNull(valor) Then
                Return Nothing
            End If
            If TypeOf valor Is DateTime Then
                Return CType(valor, DateTime)
            End If
            ' MySqlDateTime (datas vindas do conector antigo) ou texto
            Dim data As DateTime
            If DateTime.TryParse(valor.ToString(), data) Then
                Return data
            End If
            Return Nothing
        End Function

#End Region

    End Class

End Namespace
