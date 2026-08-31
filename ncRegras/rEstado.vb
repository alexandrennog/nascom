Imports System.Transactions

Imports ncDados.nsEstado
Imports ncPersistencia.nsEstado
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEstado

  Public Class rEstado

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As colecaoEstado

      Dim retorno As colecaoEstado

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dEstado) As colecaoEstado

      Dim retorno As colecaoEstado

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dEstado

      Dim retorno As dEstado
      Dim dados As dEstado
      Dim colecao As colecaoEstado


      Try

        dados = New dEstado()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dEstado

            item = colecao(0)

            retorno = New dEstado()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.sigla = cFuncoes.RetornarTexto(item.sigla)
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
        Throw New ExcecaoNascomercio("Erro em Consultar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dEstado) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dEstado) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dEstado) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoEstado

      Dim retorno As ColecaoEstado
      Dim persistencia As pEstado
      Dim retornoPersistencia As ColecaoEstado

      Try

        retorno = New ColecaoEstado

        persistencia = New pEstado
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
        Throw New ExcecaoNascomercio("Erro em fListar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dEstado) As ColecaoEstado

      Dim retorno As colecaoEstado
      Dim persistencia As pEstado
      Dim retornoPersistencia As colecaoEstado

      Try

        retorno = New colecaoEstado

        persistencia = New pEstado
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dEstado) As Integer

      Dim retorno As Integer
      Dim persistencia As pEstado

      Try

        persistencia = New pEstado
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dEstado) As Integer

      Dim retorno As Integer
      Dim persistencia As pEstado

      Try

        persistencia = New pEstado
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dEstado) As Integer

      Dim retorno As Integer
      Dim persistencia As pEstado

      Try

        persistencia = New pEstado
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Estado [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
