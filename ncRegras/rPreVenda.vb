Imports System.Transactions

Imports ncDados.nsVenda
Imports ncPersistencia.nsVenda
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsVenda

  Public Class rPreVenda

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoVenda

      Dim retorno As ColecaoVenda
      Dim persistencia As pPreVenda
      Dim retornoPersistencia As ColecaoVenda

      Try

        retorno = New ColecaoVenda

        persistencia = New pPreVenda
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

    Public Function Consultar(ByVal dados As dVenda) As ColecaoVenda

      Dim retorno As ColecaoVenda
      Dim persistencia As pPreVenda
      Dim retornoPersistencia As ColecaoVenda

      Try

        retorno = New ColecaoVenda

        persistencia = New pPreVenda
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

      Consultar = retorno

    End Function

    Public Function ConsultarMax() As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVenda

      Try

        persistencia = New pPreVenda
        retorno = persistencia.ConsultarMax()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarMax Venda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarMax = retorno

    End Function

    Public Function Incluir(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVenda

      Try

        Using ts As New TransactionScope

          persistencia = New pPreVenda
          retorno = persistencia.Incluir(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Venda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVenda

      Try

        Using ts As New TransactionScope
          persistencia = New pPreVenda
          retorno = persistencia.Alterar(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Venda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dVenda) As Integer

      Dim retorno As Integer
      Dim persistencia As pPreVenda
      Dim persistenciaProduto As pPreVendaProduto
      Dim dadosVendaProduto As dVendaProduto

      Try

        Using ts As New TransactionScope
          ' Exclui primeiro produtos
          persistenciaProduto = New pPreVendaProduto
          dadosVendaProduto = New dVendaProduto
          dadosVendaProduto.controle = dados.controle
          retorno = persistenciaProduto.Excluir(dadosVendaProduto)
          ' Exclui pre venda
          persistencia = New pPreVenda
          retorno = persistencia.Excluir(dados)

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Venda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
