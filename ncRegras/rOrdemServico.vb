Imports System.Transactions

Imports ncDados.nsOrdemServico
Imports ncPersistencia.nsOrdemServico
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsOrdemServico

    Public Class rOrdemServico

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoOrdemServico

            Dim retorno As ColecaoOrdemServico
            Dim persistencia As pOrdemServico
            Dim retornoPersistencia As ColecaoOrdemServico

            Try

                retorno = New ColecaoOrdemServico

                persistencia = New pOrdemServico
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
                Throw New ExcecaoNascomercio("Erro em Listar OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dOrdemServico) As ColecaoOrdemServico

            Dim retorno As ColecaoOrdemServico
            Dim persistencia As pOrdemServico
            Dim retornoPersistencia As ColecaoOrdemServico

            Try

                retorno = New ColecaoOrdemServico

                persistencia = New pOrdemServico
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

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarMax() As Integer

            Dim retorno As Integer
            Dim persistencia As pOrdemServico

            Try

                persistencia = New pOrdemServico
                retorno = persistencia.ConsultarMax()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarMax OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ConsultarMax = retorno

        End Function

        Public Function Incluir(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim persistencia As pOrdemServico

            Try

                Using ts As New TransactionScope

                    persistencia = New pOrdemServico
                    retorno = persistencia.Incluir(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim persistencia As pOrdemServico

            Try

                Using ts As New TransactionScope
                    persistencia = New pOrdemServico
                    retorno = persistencia.Alterar(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dOrdemServico) As Integer

            Dim retorno As Integer
            Dim persistencia As pOrdemServico
            'Dim persistenciaProduto As pOrdemServicoProduto
            'Dim dadosOrdemServicoProduto As dOrdemServicoProduto

            Try

                Using ts As New TransactionScope
                    ' Exclui primeiro produtos
                    'persistenciaProduto = New pOrdemServicoProduto
                    'dadosOrdemServicoProduto = New dOrdemServicoProduto
                    'dadosOrdemServicoProduto.controle = dados.controle
                    'retorno = persistenciaProduto.Excluir(dadosOrdemServicoProduto)

                    ' Exclui pre OrdemServico
                    persistencia = New pOrdemServico
                    retorno = persistencia.Excluir(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir OrdemServico [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
