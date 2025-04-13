Imports System.Transactions

Imports ncDados.nsEFD
Imports ncPersistencia.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdUnidadeMedida

#Region "Métodos de controle ( Várias chamadas; Controle de transação )"

    Public Function Salvar(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim retEfdUnidadeMedida As dEfdUnidadeMedida
      retEfdUnidadeMedida = Nothing

      '-- consultar
      retEfdUnidadeMedida = fConsultar(dados)

      '-- se retornar 0
      If retEfdUnidadeMedida Is Nothing Then
        '-- incluir
        retorno = fIncluir(dados)
      Else '-- se retornar 1
        '-- alterar
        retorno = fAlterar(dados)
      End If

      Return retorno

    End Function

    Public Function Listar() As ColecaoEfdUnidadeMedida

      Dim retorno As ColecaoEfdUnidadeMedida

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dEfdUnidadeMedida) As dEfdUnidadeMedida

      Dim retorno As dEfdUnidadeMedida

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

#End Region

#Region "Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )"

    Public Function fListar() As ColecaoEfdUnidadeMedida

      Dim retorno As ColecaoEfdUnidadeMedida
      Dim persistencia As pEfdUnidadeMedida
      Dim retornoPersistencia As ColecaoEfdUnidadeMedida

      Try

        retorno = New ColecaoEfdUnidadeMedida

        persistencia = New pEfdUnidadeMedida
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
        Throw New ExcecaoNascomercio("Erro em fListar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dEfdUnidadeMedida) As dEfdUnidadeMedida

      Dim retorno As dEfdUnidadeMedida
      Dim persistencia As pEfdUnidadeMedida
      Dim retornoPersistencia As dEfdUnidadeMedida

      Try

        retorno = New dEfdUnidadeMedida

        persistencia = New pEfdUnidadeMedida
        retornoPersistencia = persistencia.Consultar(dados)

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
        Throw New ExcecaoNascomercio("Erro em fConsultar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdUnidadeMedida

      Try

        persistencia = New pEfdUnidadeMedida
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdUnidadeMedida

      Try

        persistencia = New pEfdUnidadeMedida
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dEfdUnidadeMedida) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdUnidadeMedida

      Try

        persistencia = New pEfdUnidadeMedida
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir EfdUnidadeMedida [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

#End Region

  End Class

End Namespace
