Imports System.Transactions

Imports ncDados.nsImpostoPis
Imports ncPersistencia.nsImpostoPis
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoPis

  Public Class rImpostoPis

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoPis) As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Consultar(ByVal regra_cid As Integer) As dImpostoPis

      Dim retorno As dImpostoPis
      Dim dados As dImpostoPis
      Dim colecao As ColecaoImpostoPis


      Try

        dados = New dImpostoPis()


        dados.regra_cid = regra_cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dImpostoPis

            item = colecao(0)

            retorno = New dImpostoPis()

            retorno.regra_cid = cFuncoes.RetornarInteiro(item.regra_cid)
            retorno.cst = cFuncoes.RetornarTexto(item.cst)
            retorno.aliquota = item.aliquota
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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis
      Dim persistencia As pImpostoPis
      Dim retornoPersistencia As ColecaoImpostoPis

      Try

        retorno = New ColecaoImpostoPis

        persistencia = New pImpostoPis
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
        Throw New ExcecaoNascomercio("Erro em fListar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dImpostoPis) As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis
      Dim persistencia As pImpostoPis
      Dim retornoPersistencia As ColecaoImpostoPis

      Try

        retorno = New ColecaoImpostoPis

        persistencia = New pImpostoPis
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
        Throw New ExcecaoNascomercio("Erro em fConsultar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoPis

      Try

        persistencia = New pImpostoPis
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoPis

      Try

        persistencia = New pImpostoPis
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim persistencia As pImpostoPis

      Try

        persistencia = New pImpostoPis
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
