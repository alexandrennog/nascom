Imports System.Transactions

Imports ncDados.nsCheques
Imports ncPersistencia.nsCheques
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCheques

  Public Class rCheques

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoCheques

      Dim retorno As ColecaoCheques
      Dim persistencia As pCheques
      Dim retornoPersistencia As ColecaoCheques

      Try

        retorno = New ColecaoCheques

        persistencia = New pCheques
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
        Throw New ExcecaoNascomercio("Erro em Listar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCheques) As ColecaoCheques

      Dim retorno As ColecaoCheques
      Dim persistencia As pCheques
      Dim retornoPersistencia As ColecaoCheques

      Try

        retorno = New ColecaoCheques

        persistencia = New pCheques
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
        Throw New ExcecaoNascomercio("Erro em Consultar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ConsultarCheques(ByVal dados As dCheques) As ColecaoCheques

      Dim retorno As ColecaoCheques
      Dim persistencia As pCheques
      Dim retornoPersistencia As ColecaoCheques

      Try

        retorno = New ColecaoCheques

        persistencia = New pCheques
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
        Throw New ExcecaoNascomercio("Erro em Consultar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function

    Public Function Incluir(ByVal dadosCheques As ColecaoCheques) As Integer

      Dim retorno As Integer
      Dim persistenciaCheques As pCheques

      Try

        Using ts As New TransactionScope

          persistenciaCheques = New pCheques()
          For Each cheques As dCheques In dadosCheques
            persistenciaCheques.Incluir(cheques)
          Next

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Incluir(ByVal dados As dCheques) As Integer

      Dim retorno As Integer
      Dim persistenciaCheques As pCheques

      Try

        Using ts As New TransactionScope

          persistenciaCheques = New pCheques()
          persistenciaCheques.Incluir(dados)
          
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCheques, ByVal dadosCheques As ColecaoCheques) As Integer

      Dim retorno As Integer
      Dim persistencia As pCheques
      Dim persistenciaCheques As pCheques

      Try

        Using ts As New TransactionScope
          persistencia = New pCheques
          retorno = persistencia.Alterar(dados)

          persistenciaCheques = New pCheques()
          For Each Cheques As dCheques In dadosCheques
            persistenciaCheques.Alterar(Cheques)
          Next


          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Baixar() As Integer

      Dim retorno As Integer
      Dim persistencia As pCheques

      Try

        Using ts As New TransactionScope
          persistencia = New pCheques
          retorno = persistencia.Baixar()

          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Baixar Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Return retorno

    End Function
    Public Function Excluir(ByVal dados As dCheques) As Integer

      Dim retorno As Integer
      Dim persistencia As pCheques

      Try

        Using ts As New TransactionScope
          persistencia = New pCheques
          retorno = persistencia.Excluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cheques [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
