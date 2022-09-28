Imports ncDados.nsParametro
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsParametro

    Public Class pParametro

        Public Function Listar() As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParametro
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, descricao, valor From Parametros "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParametro

                            For Each row In dt.Rows
                                item = New dParametro

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
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

                Throw New ExcecaoNascomercio("Erro em Listar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dParametro) As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParametro
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, descricao, valor "
                sqlWhere = String.Empty
                sqlFrom = " From Parametros "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- descricao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descricao, "descricao")

                '-- valor
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParametro

                            For Each row In dt.Rows
                                item = New dParametro

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
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

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " Parametros ( descricao, valor ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    cFuncoes.PersistirTexto(dados.valor) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE Parametros SET " & _
                    " descricao = " & cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    " valor = " & cFuncoes.PersistirTexto(dados.valor) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM Parametros " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
