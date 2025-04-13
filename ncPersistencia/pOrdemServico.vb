Imports ncDados.nsOrdemServico
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsOrdemServico

    Public Class pOrdemServico

        Public Function Listar() As ColecaoOrdemServico

            Dim retorno As ColecaoOrdemServico
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dOrdemServico
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao  From OrdemServico "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoOrdemServico

                            For Each row In dt.Rows
                                item = New dOrdemServico

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.observacoes = cFuncoes.RetornarTexto(row("observacoes"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))

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
                Throw New ExcecaoNascomercio("Erro em Listar OS [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dOrdemServico) As ColecaoOrdemServico

            Dim retorno As ColecaoOrdemServico
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dOrdemServico
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao "
                sqlWhere = String.Empty
                sqlFrom = " From OrdemServico "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- situacao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "situacao")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoOrdemServico

                            For Each row In dt.Rows
                                item = New dOrdemServico

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.clienteid = cFuncoes.RetornarInteiro(row("clienteid"))
                                item.veiculoid = cFuncoes.RetornarInteiro(row("veiculoid"))
                                item.observacoes = cFuncoes.RetornarTexto(row("observacoes"))
                                item.emissao = cFuncoes.RetornarTexto(row("emissao"))
                                item.vendedor = cFuncoes.RetornarTexto(row("vendedor"))
                                item.loja = cFuncoes.RetornarTexto(row("loja"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar OS [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarMax() As Integer

            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim sqlSelect As String
            Dim sqlFrom As String
            Dim retorno As Integer

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select MAX(cid) as cid"
                sqlFrom = " From ordemservico "

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then

                            For Each row In dt.Rows
                                retorno = IIf(row("cid") Is DBNull.Value, 0, cFuncoes.RetornarInteiro(row("cid")))
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
                Throw New ExcecaoNascomercio("Erro em ConsultarMax ordemservico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarMax = retorno

        End Function

        Public Function Incluir(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " OrdemServico ( clienteid, veiculoid, observacoes, emissao, vendedor, loja, situacao ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirInteiro(dados.clienteid) & "," & _
                    cFuncoes.PersistirInteiro(dados.veiculoid) & "," & _
                    cFuncoes.PersistirTexto(dados.observacoes) & "," & _
                    cFuncoes.PersistirDataHora(dados.emissao) & "," & _
                    cFuncoes.PersistirTexto(dados.vendedor) & "," & _
                    cFuncoes.PersistirTexto(dados.loja) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir OS [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE OrdemServico SET " & _
                    " clienteid = " & cFuncoes.PersistirInteiro(dados.clienteid) & "," & _
                    " veiculoid = " & cFuncoes.PersistirInteiro(dados.veiculoid) & "," & _
                    " observacoes = " & cFuncoes.PersistirTexto(dados.observacoes) & "," & _
                    " vendedor = " & cFuncoes.PersistirTexto(dados.vendedor) & "," & _
                    " loja = " & cFuncoes.PersistirTexto(dados.loja) & "," & _
                    " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar OS [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM OrdemServico " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir OS [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
