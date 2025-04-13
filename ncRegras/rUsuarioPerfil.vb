Imports System.Transactions

Imports ncDados.nsUsuarioPerfil
Imports ncPersistencia.nsUsuarioPerfil
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsUsuarioPerfil

  Public Class rUsuarioPerfil

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As colecaoUsuarioPerfil

      Dim retorno As colecaoUsuarioPerfil

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dUsuarioPerfil) As colecaoUsuarioPerfil

      Dim retorno As colecaoUsuarioPerfil

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dUsuarioPerfil

      Dim retorno As dUsuarioPerfil
      Dim dados As dUsuarioPerfil
      Dim colecao As colecaoUsuarioPerfil


      Try

        dados = New dUsuarioPerfil()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dUsuarioPerfil

            item = colecao(0)

            retorno = New dUsuarioPerfil()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.codigo = cFuncoes.RetornarTexto(item.codigo)
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
        Throw New ExcecaoNascomercio("Erro em Consultar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoUsuarioPerfil

      Dim retorno As ColecaoUsuarioPerfil
      Dim persistencia As pUsuarioPerfil
      Dim retornoPersistencia As ColecaoUsuarioPerfil

      Try

        retorno = New ColecaoUsuarioPerfil

        persistencia = New pUsuarioPerfil
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
        Throw New ExcecaoNascomercio("Erro em fListar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dUsuarioPerfil) As ColecaoUsuarioPerfil

      Dim retorno As colecaoUsuarioPerfil
      Dim persistencia As pUsuarioPerfil
      Dim retornoPersistencia As colecaoUsuarioPerfil

      Try

        retorno = New colecaoUsuarioPerfil

        persistencia = New pUsuarioPerfil
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
        Throw New ExcecaoNascomercio("Erro em fConsultar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuarioPerfil

      Try

        persistencia = New pUsuarioPerfil
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuarioPerfil

      Try

        persistencia = New pUsuarioPerfil
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dUsuarioPerfil) As Integer

      Dim retorno As Integer
      Dim persistencia As pUsuarioPerfil

      Try

        persistencia = New pUsuarioPerfil
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir UsuarioPerfil [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
