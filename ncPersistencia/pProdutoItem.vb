Imports ncDados.nsProduto
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

    Public Class pProdutoItem

        Public Function Listar() As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProdutoItem
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select produtos_cid, item, caracteristicas_cid, valor From produtoitem "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProdutoItem

                            For Each row In dt.Rows
                                item = New dProdutoItem

                                item.produtos_cid = cFuncoes.RetornarInteiro(row("produtos_cid"))
                                item.item = cFuncoes.RetornarInteiro(row("item"))
                                item.caracteristicas_cid = cFuncoes.RetornarInteiro(row("caracteristicas_cid"))
                                item.valor = cFuncoes.RetornarTexto(row("valor"))

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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dProdutoItem) As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProdutoItem
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select pi.produtos_cid, pi.item, pi.caracteristicas_cid, pi.valor, c.nome, c.codigo "
                sqlWhere = String.Empty
                sqlFrom = " From produtoitem pi Inner Join caracteristicas c " & _
                    " On c.cid = pi.caracteristicas_cid "

                '-- produtos_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtos_cid, "produtos_cid")

                '-- item
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.item, "item")

                '-- caracteristicas_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.caracteristicas_cid, "caracteristicas_cid")

                '-- valor
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by pi.produtos_cid, pi.item ")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProdutoItem

                            For Each row In dt.Rows
                                item = New dProdutoItem

                                item.produtos_cid = cFuncoes.RetornarInteiro(row("produtos_cid"))
                                item.item = cFuncoes.RetornarInteiro(row("item"))
                                item.caracteristicas_cid = cFuncoes.RetornarInteiro(row("caracteristicas_cid"))
                                item.valor = cFuncoes.RetornarTexto(row("valor"))
                                item.caracteristicas_nome = cFuncoes.RetornarTexto(row("nome"))
                                item.caracteristicas_codigo = cFuncoes.RetornarTexto(row("codigo"))

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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarProdutoItem(ByVal descricao As String, ByVal codigoBarras As String, ByVal referencia As String, ByVal emEstoque As Boolean) As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProdutoItem
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " select p.cid as 'produtos_cid', p.descricao as 'descricao', p.referencia as 'referencia', p.valorVenda as 'valorVenda', " & _
                    " pi.valor as 'valor', pi.item as 'item', pi2.valor as 'estoque', pi3.valor as 'tamanho', co.nome as 'cor' "
                sqlWhere = " c.codigo = 'codigoBarras' and c2.codigo = 'estoque' and c3.codigo = 'tamanho'"
                sqlFrom = " from produtos p " & _
                    " inner join cor co on co.cid = p.cor_cid " & _
                    " inner join produtoitem pi on pi.produtos_cid = p.cid " & _
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " & _
                    " inner join produtoitem pi2 on pi2.produtos_cid = p.cid and pi2.item = pi.item " & _
                    " inner join caracteristicas c2 on c2.cid = pi2.caracteristicas_cid " & _
                    " inner join produtoitem pi3  on pi3.produtos_cid = p.cid and pi3.item = pi.item " & _
                    " inner join caracteristicas c3  on c3.cid = pi3.caracteristicas_cid "

                '-- produtoItem - estoque
                If emEstoque Then
                    sqlWhere += " and pi2.valor > 0 "
                End If

                '-- produtos - descricao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, descricao, "p.descricao", True)

                '-- produtos - referencia
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, referencia, "p.referencia", True)

                '-- produtoItem - codigoBarras
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, codigoBarras, "pi.valor")


                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by p.descricao, p.referencia, co.nome, pi3.valor")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProdutoItem

                            For Each row In dt.Rows
                                item = New dProdutoItem

                                item.produtos_descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.produtos_estoque = cFuncoes.RetornarTexto(row("estoque"))
                                item.produtos_cid = cFuncoes.RetornarTexto(row("produtos_cid"))
                                item.item = cFuncoes.RetornarTexto(row("item"))
                                item.valor = cFuncoes.RetornarTexto(row("valor"))
                                item.Produtos_ValorVenda = cFuncoes.RetornarDecimal(row("ValorVenda"))
                                item.Produtos_Referencia = cFuncoes.RetornarTexto(row("Referencia"))
                                item.Produtos_Tamanho = cFuncoes.RetornarTexto(row("tamanho"))
                                item.Produtos_Cor = cFuncoes.RetornarTexto(row("cor"))

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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarProdutoItem = retorno

        End Function

        Public Function ConsultarEstoque(ByVal codigoBarras As String) As Decimal

            Dim retorno As Decimal
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim sqlSelect As String

            Try

                retorno = 0

                acessoBanco = New cAcessoBD

                sqlSelect = " select pi1.valor " &
                    " from produtoitem pi1 " &
                    " inner join produtoitem pi2 " &
                    " on pi2.item = pi1.item " &
                    " and pi2.produtos_cid = pi1.produtos_cid " &
                    " inner join caracteristicas c1 " &
                    " on c1.cid = pi1.caracteristicas_cid " &
                    " and c1.codigo = 'estoque' " &
                    " where pi2.valor = '" & codigoBarras & "' "

                '" inner join caracteristicas c2 " & _
                '" on c2.cid = pi2.caracteristicas_cid " & _
                '" and c2.codigo = 'codigoBarras' " & _

                ds = acessoBanco.ExecutarDS(sqlSelect)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            row = dt.Rows(0)

                            retorno = cFuncoes.RetornarTexto(row("valor"))
                        Else
                            retorno = 0
                        End If
                    Else
                        retorno = 0
                    End If
                Else
                    retorno = 0
                End If

            Catch ex As Exception

                retorno = 0
                Throw New ExcecaoNascomercio("Erro em Consultar Estoque [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarEstoque = retorno

        End Function

        Public Function ConsultarQuantidadeItem(ByVal produto_cid As Integer) As ColecaoProdutoItem

            Dim retorno As ColecaoProdutoItem
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProdutoItem
            Dim sqlSelect As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select distinct pi.produtos_cid, pi.item From produtoitem pi " & _
                    " WHERE produtos_cid = " & produto_cid

                ds = acessoBanco.ExecutarDS(sqlSelect)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProdutoItem

                            For Each row In dt.Rows
                                item = New dProdutoItem

                                item.produtos_cid = cFuncoes.RetornarInteiro(row("produtos_cid"))
                                item.item = cFuncoes.RetornarInteiro(row("item"))

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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarQuantidadeItem = retorno

        End Function

        Public Function ConsultarUltimoItem(ByVal produto_cid As Integer) As Nullable(Of Integer)

            Dim retorno As Nullable(Of Integer) = Nothing
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim sqlSelect As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " select max(pi.item) as item from produtoitem pi " & _
                    " where pi.produtos_cid = " & _
                    cFuncoes.PersistirInteiro(produto_cid)

                ds = acessoBanco.ExecutarDS(sqlSelect)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = cFuncoes.RetornarInteiro(dt.Rows(0)("item"))
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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarUltimoItem = retorno

        End Function

        Public Function ConsultarUltimoCodigoBarras() As String

            Dim retorno As String = Nothing
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim sqlSelect As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " select ifnull(max(pi.valor), '10000000000000') as codigoBarras " & _
                    " from produtoitem pi " & _
                    " inner join caracteristicas c on c.cid = pi.caracteristicas_cid " & _
                    " and c.codigo = 'codigoBarras' " & _
                    " where convert(ifnull(pi.valor, 0),unsigned) > 10000000000000 "

                ds = acessoBanco.ExecutarDS(sqlSelect)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = dt.Rows(0)("codigoBarras").ToString()
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

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarUltimoItem ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarUltimoCodigoBarras = retorno

        End Function

        Public Function Incluir(ByVal dados As dProdutoItem) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " produtoitem (produtos_cid, item, caracteristicas_cid, valor ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirInteiro(dados.produtos_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.item) & "," & _
                    cFuncoes.PersistirInteiro(dados.caracteristicas_cid) & "," & _
                    cFuncoes.PersistirTexto(dados.valor) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dProdutoItem) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE produtoitem SET " & _
                    " valor = " & cFuncoes.PersistirTexto(dados.valor) & _
                    " WHERE " & _
                    " produtos_cid = " & cFuncoes.PersistirInteiro(dados.produtos_cid) & " AND " & _
                    " item = " & cFuncoes.PersistirInteiro(dados.item) & " AND " & _
                    " caracteristicas_cid = " & cFuncoes.PersistirInteiro(dados.caracteristicas_cid)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dProdutoItem) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " DELETE FROM produtoitem " & _
                    " WHERE " & _
                    " produtos_cid = " & cFuncoes.PersistirInteiro(dados.produtos_cid) & " AND " & _
                    " item = " & cFuncoes.PersistirInteiro(dados.item) & " AND " & _
                    " caracteristicas_cid = " & cFuncoes.PersistirInteiro(dados.caracteristicas_cid)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        Public Function ExcluirPorProduto(ByVal dados As dProdutoItem) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " DELETE FROM produtoitem " & _
                    " WHERE " & _
                    " produtos_cid = " & cFuncoes.PersistirInteiro(dados.produtos_cid)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ExcluirPorProduto ProdutoItem [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ExcluirPorProduto = retorno

        End Function

    End Class

End Namespace
