Imports System.Transactions

Imports ncDados.nsCliente
Imports ncPersistencia.nsCliente
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCliente

  Public Class rClienteProfissional

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dClienteProfissional) As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function ExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluirPorCliente(cliente_cid)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorCliente = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional
      Dim persistencia As pClienteProfissional
      Dim retornoPersistencia As ColecaoClienteProfissional

      Try

        retorno = New ColecaoClienteProfissional

        persistencia = New pClienteProfissional
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
        Throw New ExcecaoNascomercio("Erro em fListar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dClienteProfissional) As ColecaoClienteProfissional

      Dim retorno As ColecaoClienteProfissional
      Dim persistencia As pClienteProfissional
      Dim retornoPersistencia As ColecaoClienteProfissional

      Try

        retorno = New ColecaoClienteProfissional

        persistencia = New pClienteProfissional
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
        Throw New ExcecaoNascomercio("Erro em fConsultar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteProfissional

      Try

        persistencia = New pClienteProfissional
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dClienteProfissional) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteProfissional

      Try

        persistencia = New pClienteProfissional
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluirPorCliente(ByVal cliente_cid As Integer) As Integer

      Dim retorno As Integer
      Dim persistencia As pClienteProfissional

      Try

        persistencia = New pClienteProfissional
        retorno = persistencia.ExcluirPorCliente(cliente_cid)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir Cliente - Profissional [" & Me.ToString() & "] - " & ex.Message)

      End Try

      fExcluirPorCliente = retorno

    End Function

  End Class

End Namespace

