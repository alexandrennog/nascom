Imports ncDados.nsVenda
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

    Public Class pPreVendaProduto

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


                comandoSQL = " Select controle, produto, item, quantidade, codigobarras, descricao, referencia, valor From prevendaproduto"

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
                Throw New ExcecaoNascomercio("Erro em Listar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

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


                sqlSelect = " SELECT pv.controle, pv.produto, pv.item, pv.quantidade, pv.codigobarras, pv.descricao, pv.referencia, pv.valor, p.aliquota "
                sqlWhere = String.Empty
                sqlFrom = " FROM prevendaproduto pv INNER JOIN produtos p ON pv.produto = p.cid "

                '-- controle
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.controle, "controle")

                '-- usuarioId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.itemId, "item")

                '-- clienteId
                'sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtoId, "produto")

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
                                item.aliquota = cFuncoes.RetornarTexto(row("aliquota"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " INSERT INTO " &
                    " prevendaproduto (controle, produto, item, quantidade, codigobarras, descricao, referencia, valor) " &
                    " VALUES (" &
                    cFuncoes.PersistirTexto(dados.controle) & "," &
                    cFuncoes.PersistirTexto(dados.produtoId) & "," &
                    cFuncoes.PersistirTexto(dados.itemId) & "," &
                    cFuncoes.PersistirDecimal(dados.quantidade) & "," &
                    cFuncoes.PersistirTexto(dados.codigobarras) & "," &
                    cFuncoes.PersistirTexto(dados.descricao) & "," &
                    cFuncoes.PersistirTexto(dados.referencia) & "," &
                    cFuncoes.PersistirDecimal(dados.valor) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String


            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE prevendaproduto SET " &
                    " produto = " & cFuncoes.PersistirTexto(dados.produtoId) & "," &
                    " item = " & cFuncoes.PersistirTexto(dados.itemId) & "," &
                    " quantidade = " & cFuncoes.PersistirDecimal(dados.quantidade) & "," &
                    " codigobarras = " & cFuncoes.PersistirTexto(dados.codigobarras) & "," &
                    " descricao = " & cFuncoes.PersistirTexto(dados.descricao) & "," &
                    " referencia = " & cFuncoes.PersistirTexto(dados.referencia) & "," &
                    " valor = " & cFuncoes.PersistirDecimal(dados.valor) &
                    " WHERE " &
                    " controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM prevendaproduto " & _
                    " WHERE controle = " & dados.controle.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
