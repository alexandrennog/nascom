Imports System.Transactions

Imports ncDados.nsServico
Imports ncPersistencia.nsServico
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsServico

  Public Class rServico

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoServico

      Dim retorno As ColecaoServico

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dServico) As ColecaoServico

      Dim retorno As ColecaoServico

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal cid As Integer) As dServico

      Dim retorno As dServico
      Dim dados As dServico
      Dim colecao As ColecaoServico


      Try

        dados = New dServico()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dServico

            item = colecao(0)

            retorno = New dServico()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.nome = cFuncoes.RetornarTexto(item.nome)
            retorno.valor = cFuncoes.RetornarTexto(item.valor)
            retorno.situacao = cFuncoes.RetornarTexto(item.situacao)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch nex As ExcecaoNascomercio

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dServico) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dServico) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Return retorno

    End Function

    Public Function Excluir(ByVal dados As dServico) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Return retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoServico

      Dim retorno As ColecaoServico
      Dim persistencia As pServico
      Dim retornoPersistencia As ColecaoServico

      Try

        retorno = New ColecaoServico

        persistencia = New pServico
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
        Throw New ExcecaoNascomercio("Erro em fListar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dServico) As ColecaoServico

      Dim retorno As ColecaoServico
      Dim persistencia As pServico
      Dim retornoPersistencia As ColecaoServico

      Try

        retorno = New ColecaoServico

        persistencia = New pServico
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

        Throw

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fConsultar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dServico) As Integer

      Dim retorno As Integer
      Dim persistencia As pServico

      Try

        persistencia = New pServico
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dServico) As Integer

      Dim retorno As Integer
      Dim persistencia As pServico

      Try

        persistencia = New pServico
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dServico) As Integer

      Dim retorno As Integer
      Dim persistencia As pServico

      Try

        persistencia = New pServico
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Servico [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
