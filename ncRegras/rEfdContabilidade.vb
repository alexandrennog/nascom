Imports System.Transactions

Imports ncDados.nsEFD
Imports ncPersistencia.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdContabilidade

#Region "Métodos de controle ( Várias chamadas; Controle de transação )"

    Public Function Salvar(ByVal dados As dEfdContabilidade) As Integer

      Dim retorno As Integer
      Dim retEfdContabilidade As dEfdContabilidade
      retEfdContabilidade = Nothing

      '-- consultar
      retEfdContabilidade = fConsultar()

      '-- se retornar 0
      If retEfdContabilidade Is Nothing Then
        '-- incluir
        retorno = fIncluir(dados)
      Else '-- se retornar 1
        '-- alterar
        retorno = fAlterar(dados)
      End If

      Return retorno

    End Function

    Public Function Consultar() As dEfdContabilidade

      Dim retorno As dEfdContabilidade

      Try

        retorno = fConsultar()

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdContabilidade) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdContabilidade) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

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
        Throw New ExcecaoNascomercio("Erro em Excluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

#End Region

#Region "Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )"

    Public Function fConsultar() As dEfdContabilidade

      Dim retorno As dEfdContabilidade
      Dim persistencia As pEfdContabilidade
      Dim retornoPersistencia As dEfdContabilidade

      Try

        retorno = New dEfdContabilidade

        persistencia = New pEfdContabilidade
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
        Throw New ExcecaoNascomercio("Erro em fConsultar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEfdContabilidade) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdContabilidade

      Try

        persistencia = New pEfdContabilidade
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEfdContabilidade) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdContabilidade

      Try

        persistencia = New pEfdContabilidade
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir() As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdContabilidade

      Try

        persistencia = New pEfdContabilidade
        retorno = persistencia.Excluir()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir EfdContabilidade [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

#End Region

  End Class

End Namespace
