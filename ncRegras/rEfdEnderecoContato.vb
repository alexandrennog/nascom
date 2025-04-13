Imports System.Transactions

Imports ncDados.nsEFD
Imports ncPersistencia.nsEFD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEFD

  Public Class rEfdEnderecoContato

#Region "Métodos de controle ( Várias chamadas; Controle de transação )"

    Public Function Salvar(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer
      Dim retEfdEnderecoContato As dEfdEnderecoContato
      retEfdEnderecoContato = Nothing

      '-- consultar
      retEfdEnderecoContato = fConsultar()

      '-- se retornar 0
      If retEfdEnderecoContato Is Nothing Then
        '-- incluir
        retorno = fIncluir(dados)
      Else '-- se retornar 1
        '-- alterar
        retorno = fAlterar(dados)
      End If

      Return retorno

    End Function

    Public Function Consultar() As dEfdEnderecoContato

      Dim retorno As dEfdEnderecoContato

      Try

        retorno = fConsultar()

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

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
        Throw New ExcecaoNascomercio("Erro em Excluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

#End Region

#Region "Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )"

    Public Function fConsultar() As dEfdEnderecoContato

      Dim retorno As dEfdEnderecoContato
      Dim persistencia As pEfdEnderecoContato
      Dim retornoPersistencia As dEfdEnderecoContato

      Try

        retorno = New dEfdEnderecoContato

        persistencia = New pEfdEnderecoContato
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
        Throw New ExcecaoNascomercio("Erro em fConsultar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEnderecoContato

      Try

        persistencia = New pEfdEnderecoContato
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEfdEnderecoContato) As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEnderecoContato

      Try

        persistencia = New pEfdEnderecoContato
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir() As Integer

      Dim retorno As Integer
      Dim persistencia As pEfdEnderecoContato

      Try

        persistencia = New pEfdEnderecoContato
        retorno = persistencia.Excluir()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir EfdEnderecoContato [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

#End Region

  End Class

End Namespace
