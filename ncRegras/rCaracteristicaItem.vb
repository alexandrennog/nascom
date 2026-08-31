Imports System.Transactions

Imports ncDados.nsCaracteristica
Imports ncPersistencia.nsCaracteristica
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCaracteristica

  Public Class rCaracteristicaItem

    '-- Métodos de controle ( Várias chamadas; Controle de transação )

    Public Function Listar() As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem

      Try

        retorno = fListar()

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCaracteristicaItem) As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem

      Try

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function ConsultarPorCID(ByVal cid As Integer) As dCaracteristicaItem

      Dim retorno As dCaracteristicaItem
      Dim dados As dCaracteristicaItem
      Dim colecao As ColecaoCaracteristicaItem


      Try

        dados = New dCaracteristicaItem()


        dados.cid = cid

        colecao = fConsultar(dados)

        If Not colecao Is Nothing Then
          If colecao.Count > 0 Then
            Dim item As dCaracteristicaItem

            item = colecao(0)

            retorno = New dCaracteristicaItem()

            retorno.cid = cFuncoes.RetornarInteiro(item.cid)
            retorno.caracteristicas_cid = cFuncoes.RetornarInteiro(item.caracteristicas_cid)
            retorno.valor = cFuncoes.RetornarTexto(item.valor)
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorCID CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarPorCID = retorno

    End Function

    Public Function ConsultarPorCaracteristica(ByVal caracteristica_cid As Integer) As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem
      Dim dados As dCaracteristicaItem

      Try

        dados = New dCaracteristicaItem()

        dados.caracteristicas_cid = caracteristica_cid

        retorno = fConsultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em ConsultarPorCaracteristica CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarPorCaracteristica = retorno

    End Function

    Public Function Incluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fIncluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fAlterar(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer

      Try

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

    Public Function ExcluirPorCID(ByVal cid As Integer) As Integer

      Dim retorno As Integer
      Dim dados As dCaracteristicaItem

      Try

        dados = New dCaracteristicaItem()

        dados.cid = cid

        Using ts As New TransactionScope
          retorno = fExcluir(dados)
          ts.Complete()
        End Using

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ExcluirPorCID = retorno

    End Function

    '-- Métodos padrão ( Incluir; Alterar; Excluir; Consultar; Listar )

    Public Function fListar() As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem
      Dim persistencia As pCaracteristicaItem
      Dim retornoPersistencia As ColecaoCaracteristicaItem

      Try

        retorno = New ColecaoCaracteristicaItem

        persistencia = New pCaracteristicaItem
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
        Throw New ExcecaoNascomercio("Erro em fListar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fListar = retorno

    End Function

    Public Function fConsultar(ByVal dados As dCaracteristicaItem) As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem
      Dim persistencia As pCaracteristicaItem
      Dim retornoPersistencia As ColecaoCaracteristicaItem

      Try

        retorno = New ColecaoCaracteristicaItem

        persistencia = New pCaracteristicaItem
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
        Throw New ExcecaoNascomercio("Erro em fConsultar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fConsultar = retorno

    End Function

    Public Function fIncluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristicaItem

      Try

        persistencia = New pCaracteristicaItem
        retorno = persistencia.Incluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fIncluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fIncluir = retorno

    End Function

    Public Function fAlterar(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristicaItem

      Try

        persistencia = New pCaracteristicaItem
        retorno = persistencia.Alterar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fAlterar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fAlterar = retorno

    End Function

    Public Function fExcluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim persistencia As pCaracteristicaItem

      Try

        persistencia = New pCaracteristicaItem
        retorno = persistencia.Excluir(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em fExcluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      fExcluir = retorno

    End Function

  End Class

End Namespace
