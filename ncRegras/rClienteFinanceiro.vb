Imports System.Transactions

Imports ncDados.nsCliente
Imports ncPersistencia.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class rClienteFinanceiro

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteFinanceiro) As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluirPorCliente(cliente_cid)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ExcluirPorCliente = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro
      Dim persistencia As pClienteFinanceiro
      Dim retornoPersistencia As ColecaoClienteFinanceiro

      Try

        retorno = New ColecaoClienteFinanceiro

        persistencia = New pClienteFinanceiro
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
        Throw New ExcecaoNascomercio("Erro em fListar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dClienteFinanceiro) As ColecaoClienteFinanceiro

      Dim retorno As ColecaoClienteFinanceiro
      Dim persistencia As pClienteFinanceiro
      Dim retornoPersistencia As ColecaoClienteFinanceiro

      Try

        retorno = New ColecaoClienteFinanceiro

        persistencia = New pClienteFinanceiro
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteFinanceiro

      Try

        persistencia = New pClienteFinanceiro
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dClienteFinanceiro) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteFinanceiro

      Try

        persistencia = New pClienteFinanceiro
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteFinanceiro

      Try

        persistencia = New pClienteFinanceiro
        retorno = persistencia.ExcluirPorCliente(cliente_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Cliente - Financeiro [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluirPorCliente = retorno

    End Function

  End Class

End Namespace

