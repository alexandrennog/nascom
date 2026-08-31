Imports System.Transactions

Imports ncDados.nsGradeItem
Imports ncPersistencia.nsGradeItem
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGradeItem

  Public Class rGradeItem

    Public Function ConsultarReferencia(ByVal pFiltro As dGradeItem) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim persistencia As pGradeItem
      Dim retornoPersistencia As ColecaoGradeItem

      Try

        retorno = New ColecaoGradeItem

        persistencia = New pGradeItem
        retornoPersistencia = persistencia.ConsultarReferencia(pFiltro)

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
        Throw New ExcecaoNascomercio("Erro em Consultar Referencia [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarReferencia = retorno

    End Function

    Public Function ConsultarProdutos(ByVal pReferencia As String, ByVal pGradeItem As dGradeItem) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim persistencia As pGradeItem
      Dim retornoPersistencia As ColecaoGradeItem

      Try

        retorno = New ColecaoGradeItem

        persistencia = New pGradeItem
        retornoPersistencia = persistencia.ConsultarProdutos(pReferencia, pGradeItem)

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
        Throw New ExcecaoNascomercio("Erro em Consultar Produtos [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarProdutos = retorno

    End Function

    Public Function ConsultarItens(ByVal pProdutoCid As Integer) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim persistencia As pGradeItem
      Dim retornoPersistencia As ColecaoGradeItem

      Try

        retorno = New ColecaoGradeItem

        persistencia = New pGradeItem
        retornoPersistencia = persistencia.ConsultarItens(pProdutoCid)

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
        Throw New ExcecaoNascomercio("Erro em Consultar Itens [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarItens = retorno

    End Function

    Public Function ConsultarUltimaVenda(ByVal referencia As String, ByVal gradeItem As dGradeItem) As dGradeItem

      Dim retorno As dGradeItem
      Dim persistencia As pGradeItem
      Dim retornoPersistencia As dGradeItem

      Try

        retorno = Nothing

        persistencia = New pGradeItem
        retornoPersistencia = persistencia.ConsultarUltimaVenda(referencia, gradeItem)

        If Not retornoPersistencia Is Nothing Then
          retorno = retornoPersistencia
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar Ultima Venda [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      ConsultarUltimaVenda = retorno

    End Function

  End Class

End Namespace
