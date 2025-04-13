Imports System.Transactions

Imports ncDados.nsProduto
Imports ncPersistencia.nsProduto
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

    Public Class rProdutoTipoCaracteristica

        '-- Métodos de controle ( Várias chamadas; Controle de transação )

        Public Function Listar() As ColecaoProdutoTipoCaracteristica

            Dim retorno As ColecaoProdutoTipoCaracteristica

            Try

                retorno = fListar()

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dProdutoTipoCaracteristica) As ColecaoProdutoTipoCaracteristica

            Dim retorno As ColecaoProdutoTipoCaracteristica

            Try

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarPorProdutoTipo(ByVal produtoTipo_cid As Integer) As ColecaoProdutoTipoCaracteristica

            Dim retorno As ColecaoProdutoTipoCaracteristica
            Dim dados As dProdutoTipoCaracteristica

            Try

                dados = New dProdutoTipoCaracteristica()

                dados.produtoTipo_cid = produtoTipo_cid

                retorno = fConsultar(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ConsultarPorProdutoTipo ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function Incluir(ByVal dados As dProdutoTipoCaracteristica) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fIncluir(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Incluir = retorno

        End Function

        Public Function ExcluirPorProdutoTipo(ByVal produtoTipo_cid As Integer) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluirPorProdutoTipo(produtoTipo_cid)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ExcluirPorProdutoTipo = retorno

        End Function

        Public Function ExcluirPorCaracteristica(ByVal caracteristica_cid As Integer) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluirPorCaracteristica(caracteristica_cid)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            ExcluirPorCaracteristica = retorno

        End Function

        Public Function Excluir(ByVal cid As Integer) As Integer

            Dim retorno As Integer

            Try

                Using ts As New TransactionScope
                    retorno = fExcluir(cid)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Excluir = retorno

        End Function

        '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

        Public Function fListar() As ColecaoProdutoTipoCaracteristica

            Dim retorno As ColecaoProdutoTipoCaracteristica
            Dim persistencia As pProdutoTipoCaracteristica
            Dim retornoPersistencia As ColecaoProdutoTipoCaracteristica

            Try

                retorno = New ColecaoProdutoTipoCaracteristica

                persistencia = New pProdutoTipoCaracteristica
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
                Throw New ExcecaoNascomercio("Erro em fListar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fListar = retorno

        End Function

        Public Function fConsultar(ByVal dados As dProdutoTipoCaracteristica) As ColecaoProdutoTipoCaracteristica

            Dim retorno As ColecaoProdutoTipoCaracteristica
            Dim persistencia As pProdutoTipoCaracteristica
            Dim retornoPersistencia As ColecaoProdutoTipoCaracteristica

            Try

                retorno = New ColecaoProdutoTipoCaracteristica

                persistencia = New pProdutoTipoCaracteristica
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
                Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function fIncluir(ByVal dados As dProdutoTipoCaracteristica) As Integer

            Dim retorno As Integer
            Dim persistencia As pProdutoTipoCaracteristica

            Try

                persistencia = New pProdutoTipoCaracteristica
                retorno = persistencia.Incluir(dados)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fIncluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fIncluir = retorno

        End Function

        Public Function fExcluirPorProdutoTipo(ByVal produtoTipo_cid As Integer) As Integer

            Dim retorno As Integer
            Dim persistencia As pProdutoTipoCaracteristica

            Try

                persistencia = New pProdutoTipoCaracteristica
                retorno = persistencia.ExcluirPorProdutoTipo(produtoTipo_cid)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluirPorProdutoTipo = retorno

        End Function

        Public Function fExcluirPorCaracteristica(ByVal caracteristica_cid As Integer) As Integer

            Dim retorno As Integer
            Dim persistencia As pProdutoTipoCaracteristica

            Try

                persistencia = New pProdutoTipoCaracteristica
                retorno = persistencia.ExcluirPorCaracteristica(caracteristica_cid)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluirPorCaracteristica = retorno

        End Function

        Public Function fExcluir(ByVal cid As Integer) As Integer

            Dim retorno As Integer
            Dim persistencia As pProdutoTipoCaracteristica

            Try

                persistencia = New pProdutoTipoCaracteristica
                retorno = persistencia.Excluir(cid)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

            End Try

            fExcluir = retorno

        End Function

    End Class

End Namespace
