Imports System.Transactions

Imports ncDados.nsCaixa
Imports ncPersistencia.nsCaixa
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCaixa

    Public Class rCaixa

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoCaixa

            Dim retorno As ColecaoCaixa

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dCaixa) As ColecaoCaixa

            Dim retorno As ColecaoCaixa

            Try

                retorno = fConsultar(dados)

            Catch nex As ExcecaoNascomercio

                Throw nex

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Consultar(ByVal cid As Integer) As dCaixa

            Dim retorno As dCaixa
            Dim dados As dCaixa
            Dim colecao As ColecaoCaixa


            Try

                dados = New dCaixa()


                dados.cid = cid

                colecao = fConsultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        Dim item As dCaixa

                        item = colecao(0)

                        retorno = New dCaixa()

                        retorno.cid = cFuncoes.RetornarInteiro(item.cid)
                        retorno.nome = cFuncoes.RetornarTexto(item.nome)
                        retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
                        retorno.Data = cFuncoes.RetornarData(item.Data)
                        retorno.usuario = cFuncoes.RetornarTexto(item.usuario)
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
                Throw New ExcecaoNascomercio("Erro em Consultar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function Incluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fAlterar(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoCaixa

            Dim retorno As ColecaoCaixa
            Dim persistencia As pCaixa
            Dim retornoPersistencia As ColecaoCaixa

            Try

                retorno = New ColecaoCaixa

                persistencia = New pCaixa
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
                Throw New ExcecaoNascomercio("Erro em fListar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dCaixa) As ColecaoCaixa

            Dim retorno As ColecaoCaixa
            Dim persistencia As pCaixa
            Dim retornoPersistencia As ColecaoCaixa

            Try

                retorno = New ColecaoCaixa

                persistencia = New pCaixa
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
                Throw New ExcecaoNascomercio("Erro em fConsultar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fConsultar = retorno

        End Function

        Public Function fIncluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim persistencia As pCaixa

            Try

                persistencia = New pCaixa
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fIncluir = retorno

        End Function

        Public Function fAlterar(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim persistencia As pCaixa

            Try

                persistencia = New pCaixa
                retorno = persistencia.Alterar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fAlterar Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fAlterar = retorno

        End Function

        Public Function fExcluir(ByVal dados As dCaixa) As Integer

            Dim retorno As Integer
            Dim persistencia As pCaixa

            Try

                persistencia = New pCaixa
                retorno = persistencia.Excluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir Caixa [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace
