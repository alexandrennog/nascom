Imports System.Transactions

Imports ncDados.nsProdutoRegraTributaria
Imports ncPersistencia.nsProdutoRegraTributaria
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProdutoRegraTributaria

  Public Class rProdutoRegraTributaria

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dProdutoRegraTributaria) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ListarPorProduto(ByVal produto_cid As Integer) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria

      Try

        retorno = fListarPorProduto(produto_cid)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ListarPorProduto ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ListarPorProduto = retorno

    End Function

    Public Function Incluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Excluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim persistencia As pProdutoRegraTributaria
      Dim retornoPersistencia As ColecaoProdutoRegraTributaria

      Try

        retorno = New ColecaoProdutoRegraTributaria

        persistencia = New pProdutoRegraTributaria
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
        Throw New ExcecaoNascomercio("Erro em fListar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dProdutoRegraTributaria) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim persistencia As pProdutoRegraTributaria
      Dim retornoPersistencia As ColecaoProdutoRegraTributaria

      Try

        retorno = New ColecaoProdutoRegraTributaria

        persistencia = New pProdutoRegraTributaria
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fListarPorProduto(ByVal produto_cid As Integer) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim persistencia As pProdutoRegraTributaria
      Dim retornoPersistencia As ColecaoProdutoRegraTributaria

      Try

        retorno = New ColecaoProdutoRegraTributaria

        persistencia = New pProdutoRegraTributaria
        retornoPersistencia = persistencia.ListarPorProduto(produto_cid)

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
        Throw New ExcecaoNascomercio("Erro em fListarPorProduto ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListarPorProduto = retorno

    End Function

    Public Function fIncluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoRegraTributaria

      Try

        persistencia = New pProdutoRegraTributaria
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fExcluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoRegraTributaria

      Try

        persistencia = New pProdutoRegraTributaria
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
