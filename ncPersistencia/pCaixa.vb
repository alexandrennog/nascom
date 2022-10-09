Imports ncDados.nsCaixa
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncDados

Namespace nsCaixa

    Public Class pCaixa

        Public Function Listar() As ColecaoCaixa

            Dim retorno As ColecaoCaixa
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCaixa
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, nome, situacao, data From Caixa Order By nome "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCaixa

                            For Each row In dt.Rows
                                item = New dCaixa

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.nome = cFuncoes.RetornarTexto(row("nome"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.Data = cFuncoes.RetornarData(row("data"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dCaixa) As ColecaoCaixa

            Dim retorno As ColecaoCaixa
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dCaixa
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, nome, situacao, data "
                sqlWhere = String.Empty
                sqlFrom = " From Caixa "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- nome
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.nome, "nome")

                '-- situacao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")


                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By nome")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoCaixa

                            For Each row In dt.Rows
                                item = New dCaixa

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.nome = cFuncoes.RetornarTexto(row("nome"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.Data = cFuncoes.RetornarData(row("data"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function
        Public Function ConsultarFechamento(ByVal dados As dCaixa) As dCaixaFechamento

            Dim retorno As ColecaoCaixaFechamento
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim item As dCaixaFechamento
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, nome, situacao, data, valor, quantidade "
                sqlWhere = String.Empty
                sqlFrom = " From v_fechamento "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- situacao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.Data.ToString("yyyy-MM-dd"), $"DATE_FORMAT(data,'%Y-%m-%d')")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By nome")

                item = New dCaixaFechamento

                item.cid = cFuncoes.RetornarInteiro(ds.Tables(0).Rows(0).Item("cid"))
                item.nome = cFuncoes.RetornarTexto(ds.Tables(0).Rows(0).Item("nome"))
                item.situacao = cFuncoes.RetornarTexto(ds.Tables(0).Rows(0).Item("situacao"))
                item.Data = cFuncoes.RetornarData(ds.Tables(0).Rows(0).Item("data"))
                item.valor = cFuncoes.RetornarDecimal(ds.Tables(0).Rows(0).Item("valor"))
                item.quantidade = cFuncoes.RetornarInteiro(ds.Tables(0).Rows(0).Item("quantidade"))


            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Fechamento do Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarFechamento = item

        End Function

        Public Function Incluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " Caixa ( nome, data, usuario, situacao ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.nome) & "," & _
                    cFuncoes.PersistirData(dados.Data) & "," & _
                    cFuncoes.PersistirTexto(dados.usuario) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE Caixa SET " & _
                    " nome = " & cFuncoes.PersistirTexto(dados.nome) & "," & _
                    " data = " & cFuncoes.PersistirData(dados.Data) & "," & _
                    " usuario = " & cFuncoes.PersistirTexto(dados.usuario) & "," & _
                    " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM Caixa " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
