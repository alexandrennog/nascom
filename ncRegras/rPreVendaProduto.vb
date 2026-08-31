Imports System.Transactions

Imports ncDados.nsVenda
Imports ncPersistencia.nsVenda
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

  Public Class rPreVendaProduto

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoVendaProduto

      Dim retorno As ColecaoVendaProduto
      Dim persistencia As pPreVendaProduto
      Dim retornoPersistencia As ColecaoVendaProduto

      Try

        retorno = New ColecaoVendaProduto

        persistencia = New pPreVendaProduto
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
        Throw New ExcecaoNascomercio("Erro em Listar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dVendaProduto) As ColecaoVendaProduto

      Dim retorno As ColecaoVendaProduto
      Dim persistencia As pPreVendaProduto
      Dim retornoPersistencia As ColecaoVendaProduto

      Try

        retorno = New ColecaoVendaProduto

        persistencia = New pPreVendaProduto
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
        Throw New ExcecaoNascomercio("Erro em Consultar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dVendaProduto) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVendaProduto

      Try

        Using ts As New TransactionScope

          persistencia = New pPreVendaProduto
          retorno = persistencia.Incluir(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dVendaProduto) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVendaProduto

      Try

        Using ts As New TransactionScope
          persistencia = New pPreVendaProduto
          retorno = persistencia.Alterar(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dVendaProduto) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVendaProduto

      Try

        Using ts As New TransactionScope
          persistencia = New pPreVendaProduto
          retorno = persistencia.Excluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir PreVenda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
