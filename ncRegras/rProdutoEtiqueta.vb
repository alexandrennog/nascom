Imports System.Transactions

Imports ncDados.nsProdutoEtiqueta
Imports ncPersistencia.nsProdutoEtiqueta
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsProdutoEtiqueta

  Public Class rProdutoEtiqueta

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar(ByVal dataDe As String, ByVal dataAte As String) As ColecaoProdutoEtiqueta

      Dim retorno As ColecaoProdutoEtiqueta

      Try

        retorno = fListar(dataDe, dataAte)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Alterar(ByVal data As String, ByVal produto As String, ByVal codigoBarras As String) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(data, produto, codigoBarras)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ProdutoEtiqueta [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar(ByVal dataDe As String, ByVal dataAte As String) As ColecaoProdutoEtiqueta

      Dim retorno As ColecaoProdutoEtiqueta
      Dim persistencia As pProdutoEtiqueta
      Dim retornoPersistencia As ColecaoProdutoEtiqueta

      Try

        retorno = New ColecaoProdutoEtiqueta

        persistencia = New pProdutoEtiqueta
        retornoPersistencia = persistencia.Listar(dataDe, dataAte)

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
        Throw New ExcecaoNascomercio("Erro em fListar ProdutoEtiqueta [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fAlterar(ByVal data As String, ByVal produto As String, ByVal codigoBarras As String) As Integer

      Dim retorno As Integer
      Dim persistencia As pProdutoEtiqueta

      Try

        persistencia = New pProdutoEtiqueta
        retorno = persistencia.Alterar(data, produto, codigoBarras)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ProdutoEtiqueta [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

  End Class

End Namespace