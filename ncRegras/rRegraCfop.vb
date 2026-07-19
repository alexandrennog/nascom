Imports System.Transactions

Imports ncDados.nsRegraCfop
Imports ncPersistencia.nsRegraCfop
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegraCfop

  Public Class rRegraCfop

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dRegraCfop) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop

      Try

        retorno = fConsultar(dados)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ListarPorRegra(ByVal regra_cid As Integer) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop

      Try

        retorno = fListarPorRegra(regra_cid)

      Catch nex As ExcecaoNascomercio

        Throw nex

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ListarPorRegra RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ListarPorRegra = retorno

    End Function

    Public Function Incluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Excluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim persistencia As pRegraCfop
      Dim retornoPersistencia As ColecaoRegraCfop

      Try

        retorno = New ColecaoRegraCfop

        persistencia = New pRegraCfop
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
        Throw New ExcecaoNascomercio("Erro em fListar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dRegraCfop) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim persistencia As pRegraCfop
      Dim retornoPersistencia As ColecaoRegraCfop

      Try

        retorno = New ColecaoRegraCfop

        persistencia = New pRegraCfop
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
        Throw New ExcecaoNascomercio("Erro em fConsultar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fListarPorRegra(ByVal regra_cid As Integer) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim persistencia As pRegraCfop
      Dim retornoPersistencia As ColecaoRegraCfop

      Try

        retorno = New ColecaoRegraCfop

        persistencia = New pRegraCfop
        retornoPersistencia = persistencia.ListarPorRegra(regra_cid)

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
        Throw New ExcecaoNascomercio("Erro em fListarPorRegra RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListarPorRegra = retorno

    End Function

    Public Function fIncluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraCfop

      Try

        persistencia = New pRegraCfop
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fExcluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer
      Dim persistencia As pRegraCfop

      Try

        persistencia = New pRegraCfop
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
