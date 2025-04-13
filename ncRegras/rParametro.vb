Imports System.Transactions

Imports ncDados.nsParametro
Imports ncPersistencia.nsParametro
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncDados.nsdParametroEstoque

Namespace nsParametro

    Public Class rParametro

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim persistencia As pParametro
            Dim retornoPersistencia As ColecaoParametro

            Try

                retorno = New ColecaoParametro

                persistencia = New pParametro
                retornoPersistencia = persistencia.Listar()

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
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

            Try

                retorno = fConsultar(dados)

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarEstoque(ByVal dados As dParametroEstoque) As ColecaoParametroEstoque

            Dim retorno As ColecaoParametroEstoque

            Try

                retorno = fConsultarEstoque(dados)

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarEstoque = retorno

        End Function

        Public Function Consultar(ByVal cid As Integer) As dParametro

            Dim retorno As dParametro
            Dim dados As dParametro
            Dim colecao As ColecaoParametro


            Try

                dados = New dParametro()

                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dParametro

                        item = colecao(0)

                        retorno = New dParametro()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.descricao = cFuncoes.RetornarTexto(item.descricao)
                        retorno.valor = cFuncoes.RetornarTexto(item.valor)
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
            Dim persistencia As pParametro

            Try

                Using ts As New TransactionScope
                    persistencia = New pParametro
                    retorno = persistencia.Incluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim persistencia As pParametro

            Try

                Using ts As New TransactionScope
                    persistencia = New pParametro
                    retorno = persistencia.Alterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim persistencia As pParametro

            Try

                Using ts As New TransactionScope
                    persistencia = New pParametro
                    retorno = persistencia.Excluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function


        Private Function fConsultar(ByVal dados As dParametro) As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim persistencia As pParametro
            Dim retornoPersistencia As ColecaoParametro

            Try

                retorno = New ColecaoParametro

                persistencia = New pParametro
                retornoPersistencia = persistencia.Consultar(dados)

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
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
                Throw New ExcecaoNascomercio("Erro em fConsultar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultar = retorno

        End Function

        Public Function fConsultarEstoque(ByVal dados As dParametroEstoque) As ColecaoParametroEstoque

            Dim retorno As ColecaoParametroEstoque
            Dim persistencia As pParametro
            Dim retornoPersistencia As ColecaoParametroEstoque

            Try

                retorno = New ColecaoParametroEstoque

                persistencia = New pParametro
                retornoPersistencia = persistencia.ConsultarEstoque(dados)

                If Not retornoPersistencia Is Nothing Then
                    If retornoPersistencia.Count > 0 Then
                        retorno.AddRange(retornoPersistencia)
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
                Throw New ExcecaoNascomercio("Erro em fConsultar Parametro [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultarEstoque = retorno

        End Function

    End Class

End Namespace
