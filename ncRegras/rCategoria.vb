Imports System.Transactions

Imports ncDados.nsCategoria
Imports ncPersistencia.nsCategoria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCategoria

    Public Class rCategoria

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoCategoria

            Dim retorno As ColecaoCategoria

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dCategoria) As ColecaoCategoria

            Dim retorno As ColecaoCategoria

            Try

                retorno = fConsultar(dados)

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Consultar(ByVal cid As Integer) As dCategoria

            Dim retorno As dCategoria
            Dim dados As dCategoria
            Dim colecao As ColecaoCategoria


            Try

                dados = New dCategoria()


                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dCategoria

                        item = colecao(0)

                        retorno = New dCategoria()

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
                Throw New ExcecaoNascomercio("Erro em Consultar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Importar(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fImportar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Importar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Importar = retorno

        End Function

        Public Function Alterar(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoCategoria

            Dim retorno As ColecaoCategoria
            Dim persistencia As pCategoria
            Dim retornoPersistencia As ColecaoCategoria

            Try

                retorno = New ColecaoCategoria

                persistencia = New pCategoria
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
                Throw New ExcecaoNascomercio("Erro em fListar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dCategoria) As ColecaoCategoria

            Dim retorno As ColecaoCategoria
            Dim persistencia As pCategoria
            Dim retornoPersistencia As ColecaoCategoria

            Try

                retorno = New ColecaoCategoria

                persistencia = New pCategoria
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
                Throw New ExcecaoNascomercio("Erro em fConsultar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fConsultar = retorno

        End Function

        Public Function fIncluir(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer
            Dim persistencia As pCategoria

            Try

                persistencia = New pCategoria
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fIncluir = retorno

        End Function

        Public Function fImportar(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer
            Dim persistencia As pCategoria

            Try

                persistencia = New pCategoria
                retorno = persistencia.Importar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fImportar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fImportar = retorno

        End Function

        Public Function fAlterar(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer
            Dim persistencia As pCategoria

            Try

                persistencia = New pCategoria
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dCategoria) As Integer

            Dim retorno As Integer
            Dim persistencia As pCategoria

            Try

                persistencia = New pCategoria
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir Categoria [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace
