Imports System.Transactions

Imports ncDados.nsEFD
Imports ncPersistencia.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdEntidade

#Region "Métodos de controle ( Várias chamadas; Controle de transação )"

    Public Function Salvar(ByVal dados As dEfdEntidade) As Integer

      Dim retorno As Integer
      Dim retEfdEntidade As dEfdEntidade
      retEfdEntidade = Nothing

      '-- consultar
      retEfdEntidade = fConsultar()

      '-- se retornar 0
      If retEfdEntidade Is Nothing Then
        '-- incluir
        retorno = fIncluir(dados)
      Else '-- se retornar 1
        '-- alterar
        retorno = fAlterar(dados)
      End If

      Return retorno

    End Function

    Public Function Consultar() As dEfdEntidade

      Dim retorno As dEfdEntidade

      Try

        retorno = fConsultar()

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdEntidade) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdEntidade) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir() As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir()
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

#End Region

#Region "Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )"

    Public Function fConsultar() As dEfdEntidade

      Dim retorno As dEfdEntidade
      Dim persistencia As pEfdEntidade
      Dim retornoPersistencia As dEfdEntidade

      Try

        retorno = New dEfdEntidade

        persistencia = New pEfdEntidade
        retornoPersistencia = persistencia.Consultar()

        If Not retornoPersistencia Is Nothing Then
          If retornoPersistencia IsNot Nothing Then
            retorno = retornoPersistencia
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
        Throw New ExcecaoNascomercio("Erro em fConsultar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEfdEntidade) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEntidade

      Try

        persistencia = New pEfdEntidade
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEfdEntidade) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEntidade

      Try

        persistencia = New pEfdEntidade
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir() As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEntidade

      Try

        persistencia = New pEfdEntidade
        retorno = persistencia.Excluir()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir EfdEntidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

#End Region

  End Class

End Namespace
