Imports System.Transactions

Imports ncDados.nsVenda
Imports ncPersistencia.nsVenda
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

  Public Class rVenda

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoVenda

      Dim retorno As ColecaoVenda
      Dim persistencia As pVenda
      Dim retornoPersistencia As ColecaoVenda

      Try

        retorno = New ColecaoVenda

        persistencia = New pVenda
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
        Throw New ExcecaoNascomercio("Erro em Listar Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dVenda) As ColecaoVenda

      Dim retorno As ColecaoVenda
      Dim persistencia As pVenda
      Dim retornoPersistencia As ColecaoVenda

      Try

        retorno = New ColecaoVenda

        persistencia = New pVenda
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
        Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function
        Public Function ConsultarPix(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim persistencia As pVenda
            Dim retornoPersistencia As ColecaoVenda

            Try

                retorno = New ColecaoVenda

                persistencia = New pVenda
                retornoPersistencia = persistencia.ConsultarPix(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarVendasPorVendedor(ByVal dados As dVendasPorVendedor) As ColecaoVendasPorVendedor

            Dim retorno As ColecaoVendasPorVendedor
            Dim persistencia As pVenda
            Dim retornoPersistencia As ColecaoVendasPorVendedor

            Try

                retorno = New ColecaoVendasPorVendedor

                persistencia = New pVenda
                retornoPersistencia = persistencia.ConsultarVendasPorVendedor(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarVendasDaLoja(ByVal dados As dVendasPorVendedor) As ColecaoVendasPorVendedor

            Dim retorno As ColecaoVendasPorVendedor
            Dim persistencia As pVenda
            Dim retornoPersistencia As ColecaoVendasPorVendedor

            Try

                retorno = New ColecaoVendasPorVendedor

                persistencia = New pVenda
                retornoPersistencia = persistencia.ConsultarVendasDaLoja(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarCrediarioPix(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim persistencia As pVenda
            Dim retornoPersistencia As ColecaoVenda

            Try

                retorno = New ColecaoVenda

                persistencia = New pVenda
                retornoPersistencia = persistencia.ConsultarCrediarioPix(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
        Public Function ConsultarTroca(ByVal dados As dVenda) As ColecaoVenda

      Dim retorno As ColecaoVenda
      Dim persistencia As pVenda
      Dim retornoPersistencia As ColecaoVenda

      Try

        retorno = New ColecaoVenda

        persistencia = New pVenda
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
        Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function ConsultarUltimaVenda(ByVal produto_cid As Integer) As dVenda

      Dim retorno As dVenda
      Dim persistencia As pVenda

      Try

        retorno = New dVenda

        persistencia = New pVenda
        retorno = persistencia.ConsultarUltimaVenda(produto_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarUltimaVenda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarUltimaVenda = retorno

    End Function

    Public Function ConsultarMax() As Integer

      Dim persistencia As pVenda
      Dim retornoPersistencia As Integer

      Try

        persistencia = New pVenda
        retornoPersistencia = persistencia.ConsultarMax()

      Catch ex As Exception

        retornoPersistencia = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarMax Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarMax = retornoPersistencia

    End Function

    Public Function Incluir(ByVal dados As dVenda, ByVal dadosProdutos As ColecaoVendaProduto) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda
      Dim persistenciaProduto As pVendaProduto

      Try

        Using ts As New TransactionScope

          persistencia = New pVenda
          retorno = persistencia.Incluir(dados)

          persistenciaProduto = New pVendaProduto()
          If Not IsNothing(dadosProdutos) Then
            For Each produto As dVendaProduto In dadosProdutos
              produto.controle = retorno
              persistenciaProduto.Incluir(produto)
            Next
          End If

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function IncluirTroca(ByVal dados As dVenda, ByVal dadosProdutos As ColecaoVendaProduto) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda
      Dim persistenciaProduto As pVendaProduto

      Try

        Using ts As New TransactionScope

          persistencia = New pVenda
          retorno = persistencia.IncluirVale(dados)

          persistenciaProduto = New pVendaProduto()
          If Not IsNothing(dadosProdutos) Then
            For Each produto As dVendaProduto In dadosProdutos
              produto.controle = retorno
              persistenciaProduto.IncluirTroca(produto)
            Next
          End If

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function IncluirVale(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda

      Try

        Using ts As New TransactionScope

          persistencia = New pVenda
          retorno = persistencia.IncluirVale(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Vale [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function IncluirCrediarioPagamento(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda

      Try

        Using ts As New TransactionScope

          persistencia = New pVenda
          retorno = persistencia.IncluirCrediarioPagamento(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Pagamento de Crediário [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function Alterar(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda

      Try

        Using ts As New TransactionScope
          persistencia = New pVenda
          retorno = persistencia.Alterar(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

        Public Function Alterar(ByVal controle As String, ByVal chave As String) As Integer

            Dim retorno As Integer
            Dim persistencia As pVenda

            Try

                Using ts As New TransactionScope
                    persistencia = New pVenda
                    retorno = persistencia.Alterar(controle, chave)

                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Alterar = retorno

        End Function
        Public Function Excluir(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pVenda

      Try

        Using ts As New TransactionScope
          persistencia = New pVenda
          retorno = persistencia.Excluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

            Return retorno

    End Function

        Public Function ExcluirVale(ByVal dados As dVenda) As Integer

            Dim retorno As Integer
            Dim persistencia As pVenda

            Try

                Using ts As New TransactionScope
                    persistencia = New pVenda
                    retorno = persistencia.ExcluirVale(dados)
                    ts.Complete()
                End Using

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Vale [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function

        Public Function ConsultarFechamento(ByVal dados As dVenda) As ColecaoVenda

            Dim retorno As ColecaoVenda
            Dim persistencia As pVenda
            Dim retornoPersistencia As ColecaoVenda

            Try

                retorno = New ColecaoVenda

                persistencia = New pVenda
                retornoPersistencia = persistencia.ConsultarFechamento(dados)

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
                Throw New ExcecaoNascomercio("Erro em Consultar Venda [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Return retorno

        End Function
    End Class

End Namespace
