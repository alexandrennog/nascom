Imports System.Transactions

Imports ncDados.nsVenda
Imports ncPersistencia.nsVenda
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

    Public Class rVendaProduto

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim persistencia As pVendaProduto
            Dim retornoPersistencia As ColecaoVendaProduto

            Try

                retorno = New ColecaoVendaProduto

                persistencia = New pVendaProduto
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
                Throw New ExcecaoNascomercio("Erro em Listar Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dVendaProduto) As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim persistencia As pVendaProduto
            Dim retornoPersistencia As ColecaoVendaProduto

            Try

                retorno = New ColecaoVendaProduto

                persistencia = New pVendaProduto
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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return (retorno)

        End Function

        Public Function ConsultarTroca(ByVal dados As dVendaProduto) As ColecaoVendaProduto

            Dim retorno As ColecaoVendaProduto
            Dim persistencia As pVendaProduto
            Dim retornoPersistencia As ColecaoVendaProduto

            Try

                retorno = New ColecaoVendaProduto

                persistencia = New pVendaProduto
                retornoPersistencia = persistencia.ConsultarTroca(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope

                    persistencia = New pVendaProduto
                    retorno = persistencia.Incluir(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope
                    persistencia = New pVendaProduto
                    retorno = persistencia.Alterar(dados)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope
                    persistencia = New pVendaProduto
                    retorno = persistencia.Excluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ExcluirTroca(ByVal dados As dVendaProduto) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope
                    persistencia = New pVendaProduto
                    retorno = persistencia.Excluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Troca [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ExcluirControle(ByVal controle As Integer) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope
                    persistencia = New pVendaProduto
                    retorno = persistencia.ExcluirControle(controle)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

        Public Function ExcluirControleTroca(ByVal controle As Integer) As Integer

            Dim retorno As Integer
            Dim persistencia As pVendaProduto

            Try

                Using ts As New TransactionScope
                    persistencia = New pVendaProduto
                    retorno = persistencia.ExcluirControleTroca(controle)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Troca [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Return retorno

        End Function

    End Class

End Namespace
