Imports ncDados.nsVenda
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

    Public Class pVendaProduto

        Public Function Listar() As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendaProduto
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " Select controle, produto, quantidade, item, valor From vendasprodutos"

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVendaProduto

                            For Each row In dt.Rows
                                item = New dVendaProduto

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.produtoId = cFuncoes.RetornarInteiro(row("produto"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))
                                item.itemId = cFuncoes.RetornarInteiro(row("item"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dVendaProduto) As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendaProduto
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " SELECT controle, produto, v.item, quantidade, pi.valor as codigobarras, descricao, referencia, v.valor "
                sqlWhere = String.Empty
                sqlFrom = " From vendasprodutos v "
                sqlFrom += " inner join produtos p on cid = produto "
                sqlFrom += " inner join produtoitem pi on produtos_cid = produto and v.item = pi.item and caracteristicas_cid =1 "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- item
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.itemId, "item")

                '-- produto
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtoId, "produto")

                '-- quantidade
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.quantidade, "quantidade")

                '-- valor
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVendaProduto

                            For Each row In dt.Rows
                                item = New dVendaProduto

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.produtoId = cFuncoes.RetornarInteiro(row("produto"))
                                item.itemId = cFuncoes.RetornarInteiro(row("item"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))
                                item.codigobarras = cFuncoes.RetornarTexto(row("codigobarras"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarTroca(ByVal dados As dVendaProduto) As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dVendaProduto
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String


            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " SELECT controle, produto, v.item, quantidade, pi.valor as codigobarras, descricao, referencia, v.valor "
                sqlWhere = String.Empty
                sqlFrom = " From valesprodutos v "
                sqlFrom += " inner join produtos p on cid = produto "
                sqlFrom += " inner join produtoitem pi on produtos_cid = produto and v.item = pi.item and caracteristicas_cid =1 "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- item
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.itemId, "item")

                '-- produto
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtoId, "produto")

                '-- quantidade
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.quantidade, "quantidade")

                '-- valor
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoVendaProduto

                            For Each row In dt.Rows
                                item = New dVendaProduto

                                item.controle = cFuncoes.RetornarInteiro(row("controle"))
                                item.produtoId = cFuncoes.RetornarInteiro(row("produto"))
                                item.itemId = cFuncoes.RetornarInteiro(row("item"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))
                                item.codigobarras = cFuncoes.RetornarTexto(row("codigobarras"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.valor = cFuncoes.RetornarDecimal(row("valor"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar troca [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
                    " vendasprodutos (controle, produto, quantidade, item, valor) " &
                    " VALUES (" &
                    cFuncoes.PersistirInteiro(dados.controle) & "," &
                    cFuncoes.PersistirInteiro(dados.produtoId) & "," &
                    cFuncoes.PersistirDecimal(dados.quantidade) & "," &
                    cFuncoes.PersistirInteiro(dados.itemId) & "," &
                    cFuncoes.PersistirDecimal(dados.valor) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function IncluirTroca(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
                    " valesprodutos (controle, produto, quantidade, item, valor) " &
                    " VALUES (" &
                    cFuncoes.PersistirInteiro(dados.controle) & "," &
                    cFuncoes.PersistirInteiro(dados.produtoId) & "," &
                    cFuncoes.PersistirDecimal(dados.quantidade) & "," &
                    cFuncoes.PersistirInteiro(dados.itemId) & "," &
                    cFuncoes.PersistirDecimal(dados.valor) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Troca [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Alterar(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE vendasprodutos SET " &
                    " valor = " & cFuncoes.PersistirDecimal(dados.valor) & "," &
                    " quantidade = " & cFuncoes.PersistirDecimal(dados.quantidade) &
                    " WHERE " &
                    " controle = " & cFuncoes.PersistirInteiro(dados.controle) &
                    " and produto = " & cFuncoes.PersistirInteiro(dados.produtoId) &
                    " and item = " & cFuncoes.PersistirInteiro(dados.itemId)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM vendasprodutos " & _
                    " WHERE " & _
                    " controle = " & cFuncoes.PersistirInteiro(dados.controle) & _
                    " and produto = " & cFuncoes.PersistirInteiro(dados.produtoId) & _
                    " and item = " & cFuncoes.PersistirInteiro(dados.itemId)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ExcluirControle(ByVal controle As Integer) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM vendasprodutos " & _
                    " WHERE " & _
                    " controle = " & cFuncoes.PersistirInteiro(controle)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ExcluirControleTroca(ByVal controle As Integer) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM valesprodutos " & _
                    " WHERE " & _
                    " controle = " & cFuncoes.PersistirInteiro(controle)

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
