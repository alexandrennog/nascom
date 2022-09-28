Imports System.Transactions

Imports ncDados.nsCondicao
Imports ncPersistencia.nsCondicao
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCondicao

  Public Class rCondicao

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoCondicao

      Dim retorno As ColecaoCondicao

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCondicao) As ColecaoCondicao

      Dim retorno As ColecaoCondicao

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dCondicao

      Dim retorno As dCondicao
      Dim dados As dCondicao
      Dim colecao As ColecaoCondicao


      Try

        dados = New dCondicao()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dCondicao

            item = colecao(0)

            retorno = New dCondicao()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.desconto = cFuncoes.RetornarDecimal(item.desconto)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
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
        Throw New ExcecaoNascomercio("Erro em Consultar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoCondicao

      Dim retorno As ColecaoCondicao
      Dim persistencia As pCondicao
      Dim retornoPersistencia As ColecaoCondicao

      Try

        retorno = New ColecaoCondicao

        persistencia = New pCondicao
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
        Throw New ExcecaoNascomercio("Erro em fListar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dCondicao) As ColecaoCondicao

      Dim retorno As ColecaoCondicao
      Dim persistencia As pCondicao
      Dim retornoPersistencia As ColecaoCondicao

      Try

        retorno = New ColecaoCondicao

        persistencia = New pCondicao
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

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer
      Dim persistencia As pCondicao

      Try

        persistencia = New pCondicao
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer
      Dim persistencia As pCondicao

      Try

        persistencia = New pCondicao
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dCondicao) As Integer

      Dim retorno As Integer
      Dim persistencia As pCondicao

      Try

        persistencia = New pCondicao
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Condição [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
