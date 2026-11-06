Imports System.Transactions

Imports ncDados.nsProduto
Imports ncPersistencia.nsProduto
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

  Public Class rProdutoTipo

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoProdutoTipo

      Dim retorno As ColecaoProdutoTipo

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dProdutoTipo) As ColecaoProdutoTipo

      Dim retorno As ColecaoProdutoTipo

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dProdutoTipo

      Dim retorno As dProdutoTipo
      Dim dados As dProdutoTipo
      Dim colecao As ColecaoProdutoTipo


      Try

        dados = New dProdutoTipo()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dProdutoTipo

            item = colecao(0)

            retorno = New dProdutoTipo()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoProdutoTipo

      Dim retorno As ColecaoProdutoTipo
      Dim persistencia As pProdutoTipo
      Dim retornoPersistencia As ColecaoProdutoTipo

      Try

        retorno = New ColecaoProdutoTipo

        persistencia = New pProdutoTipo
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
        Throw New ExcecaoNascomercio("Erro em fListar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dProdutoTipo) As ColecaoProdutoTipo

      Dim retorno As ColecaoProdutoTipo
      Dim persistencia As pProdutoTipo
      Dim retornoPersistencia As ColecaoProdutoTipo

      Try

        retorno = New ColecaoProdutoTipo

        persistencia = New pProdutoTipo
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoTipo

      Try

        persistencia = New pProdutoTipo
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoTipo

      Try

        persistencia = New pProdutoTipo
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dProdutoTipo) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoTipo

      Try

        persistencia = New pProdutoTipo
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ProdutoTipo [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
