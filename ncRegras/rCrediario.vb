Imports System.Transactions

Imports ncDados.nsCrediario
Imports ncPersistencia.nsCrediario
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncComum.nsLog.cLog

Namespace nsCrediario

    Public Class rCrediario

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoCrediario

            Dim retorno As ColecaoCrediario
            Dim persistencia As pCrediario
            Dim retornoPersistencia As ColecaoCrediario

            Try

                retorno = New ColecaoCrediario

                persistencia = New pCrediario
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
                Throw New ExcecaoNascomercio("Erro em Listar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function ConsultarMax() As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario

            Try

                persistencia = New pCrediario
                retorno = persistencia.ConsultarMax()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarMax Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarMax = retorno

        End Function

        Public Function Consultar(ByVal dados As dCrediario) As ColecaoCrediario

            Dim retorno As ColecaoCrediario
            Dim persistencia As pCrediario
            Dim retornoPersistencia As ColecaoCrediario

            Try

                retorno = New ColecaoCrediario

                persistencia = New pCrediario
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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcelas(ByVal dados As dParcelas) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim persistencia As pParcela
            Dim retornoPersistencia As ColecaoParcelas

            Try

                retorno = New ColecaoParcelas

                persistencia = New pParcela
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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcelasPagamentos(ByVal dados As dParcelas) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim persistencia As pParcela
            Dim retornoPersistencia As ColecaoParcelas

            Try

                retorno = New ColecaoParcelas

                persistencia = New pParcela
                retornoPersistencia = persistencia.ConsultarPagamentos(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Pagamentos [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcela(ByVal cid As Integer) As dParcelas
            Dim colecao As ColecaoParcelas
            Dim dados As dParcelas = New dParcelas()
            Dim persistencia As pParcela
            Dim retorno As dParcelas

            Try

                dados.cid = cid
                persistencia = New pParcela
                colecao = persistencia.Consultar(dados)

                If Not colecao Is Nothing Then
                    If colecao.Count > 0 Then
                        retorno = colecao(0)
                    Else
                        retorno = Nothing
                    End If
                Else
                    retorno = Nothing
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarParcela [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcelasCliente(ByVal codCliente As Integer) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim persistencia As pParcela
            Dim retornoPersistencia As ColecaoParcelas

            Try

                retorno = New ColecaoParcelas

                persistencia = New pParcela
                retornoPersistencia = persistencia.ConsultarParcelasCliente(codCliente)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ConsultarParcelasVencidas(ByVal codCliente As Integer) As ColecaoParcelas

            Dim retorno As ColecaoParcelas
            Dim persistencia As pParcela
            Dim retornoPersistencia As ColecaoParcelas

            Try

                retorno = New ColecaoParcelas

                persistencia = New pParcela
                retornoPersistencia = persistencia.ConsultarParcelasVencidas(codCliente)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dCrediario, ByVal dadosParcelas As ColecaoParcelas) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario
            Dim persistenciaParcelas As pParcela

            Try

                Using ts As New TransactionScope

                    persistencia = New pCrediario
                    retorno = persistencia.Incluir(dados)

                    persistenciaParcelas = New pParcela()
                    For Each parcela As dParcelas In dadosParcelas
                        parcela.crediarioId = retorno
                        persistenciaParcelas.Incluir(parcela)
                    Next

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function IncluirCrediario(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario

            Try

                Using ts As New TransactionScope

                    persistencia = New pCrediario
                    retorno = persistencia.Incluir(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function IncluirParcela(ByVal dadosParcela As dParcelas) As Integer

            Dim retorno As Integer
            Dim persistenciaParcelas As pParcela

            Try

                Using ts As New TransactionScope

                    persistenciaParcelas = New pParcela()
                    persistenciaParcelas.Incluir(dadosParcela)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Parcela [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Alterar(ByVal dados As dCrediario, ByVal dadosParcelas As ColecaoParcelas) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario
            Dim persistenciaParcelas As pParcela

            Try

                Using ts As New TransactionScope
                    persistencia = New pCrediario
                    retorno = persistencia.Alterar(dados)

                    persistenciaParcelas = New pParcela()
                    For Each parcela As dParcelas In dadosParcelas
                        persistenciaParcelas.Alterar(parcela)
                    Next


                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function GravarPagamentoParcelas(ByVal dadosParcelas As ColecaoParcelas) As Integer

            Dim retorno As Integer
            Dim persistenciaParcelas As pParcela

            Try

                Using ts As New TransactionScope

                    persistenciaParcelas = New pParcela()
                    For Each parcela As dParcelas In dadosParcelas
                        persistenciaParcelas.IncluirPagamento(parcela)
                    Next

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Gravar Pagamento Parcela [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Renegociar(ByVal dados As dCrediario, ByVal dadosParcelas As ColecaoParcelas) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario
            Dim persistenciaParcelas As pParcela

            Try

                Using ts As New TransactionScope
                    persistencia = New pCrediario
                    If dados.cid <> 0 Then
                        retorno = persistencia.Alterar(dados)
                    Else
                        retorno = persistencia.Incluir(dados)
                    End If

                    persistencia.ExcluirParcelas(dados)

                    persistenciaParcelas = New pParcela()
                    For Each parcela As dParcelas In dadosParcelas
                        If parcela.crediarioId = 0 Then
                            parcela.crediarioId = retorno
                        End If
                        persistenciaParcelas.Incluir(parcela)
                    Next

                    GravarLog(dados.usuarioId, "Renegociação de dívida - valor " & dados.ValorTotal & " cliente: " & dados.clienteId)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function AlterarCrediario(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario

            Try

                Using ts As New TransactionScope
                    persistencia = New pCrediario
                    retorno = persistencia.Alterar(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function AlterarControle(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario

            Try

                Using ts As New TransactionScope
                    persistencia = New pCrediario
                    retorno = persistencia.AlterarControle(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Excluir(ByVal dados As dCrediario) As Integer

            Dim retorno As Integer
            Dim persistencia As pCrediario

            Try

                Using ts As New TransactionScope
                    persistencia = New pCrediario
                    retorno = persistencia.Excluir(dados)

                    GravarLog(dados.usuarioId, "Exclusão de crediário - valor " & dados.ValorTotal & " cliente: " & dados.clienteId)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Crediario [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function CorrigirParcelas() As Integer

            Dim retorno As Integer
            Dim persistencia As pParcela

            Try

                Using ts As New TransactionScope
                    persistencia = New pParcela
                    retorno = persistencia.Corrigir()
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro ao corrigir parcelas [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
