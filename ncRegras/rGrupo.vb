Imports System.Transactions

Imports ncDados.nsGrupo
Imports ncPersistencia.nsGrupo
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGrupo

    Public Class rGrupo

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoGrupo

            Dim retorno As ColecaoGrupo

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dGrupo) As ColecaoGrupo

            Dim retorno As ColecaoGrupo

            Try

                retorno = fConsultar(dados)

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Consultar(ByVal cid As Integer) As dGrupo

            Dim retorno As dGrupo
            Dim dados As dGrupo
            Dim colecao As ColecaoGrupo


            Try

                dados = New dGrupo()


                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dGrupo

                        item = colecao(0)

                        retorno = New dGrupo()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.nome = cFuncoes.RetornarTexto(item.nome)
                        retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Importar(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fImportar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Importar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Importar = retorno

        End Function

        Public Function Alterar(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoGrupo

            Dim retorno As ColecaoGrupo
            Dim persistencia As pGrupo
            Dim retornoPersistencia As ColecaoGrupo

            Try

                retorno = New ColecaoGrupo

                persistencia = New pGrupo
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
                Throw New ExcecaoNascomercio("Erro em fListar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dGrupo) As ColecaoGrupo

            Dim retorno As ColecaoGrupo
            Dim persistencia As pGrupo
            Dim retornoPersistencia As ColecaoGrupo

            Try

                retorno = New ColecaoGrupo

                persistencia = New pGrupo
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

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fConsultar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fConsultar = retorno

        End Function

        Public Function fIncluir(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer
            Dim persistencia As pGrupo

            Try

                persistencia = New pGrupo
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fIncluir = retorno

        End Function

        Public Function fImportar(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer
            Dim persistencia As pGrupo

            Try

                persistencia = New pGrupo
                retorno = persistencia.Importar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fImportar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fImportar = retorno

        End Function

        Public Function fAlterar(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer
            Dim persistencia As pGrupo

            Try

                persistencia = New pGrupo
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dGrupo) As Integer

            Dim retorno As Integer
            Dim persistencia As pGrupo

            Try

                persistencia = New pGrupo
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir Grupo [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace
