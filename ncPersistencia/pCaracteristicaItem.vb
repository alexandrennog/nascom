Imports ncDados.nsCaracteristica
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsCaracteristica

  Public Class pCaracteristicaItem

    Public Function Listar() As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCaracteristicaItem
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select cid, caracteristicas_cid, valor From caracteristicaitem "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCaracteristicaItem

              For Each row In dt.Rows
                item = New dCaracteristicaItem

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.caracteristicas_cid = cFuncoes.RetornarInteiro(row("caracteristicas_cid"))
                item.valor = cFuncoes.RetornarTexto(row("valor"))

                retorno.Add(item)
              Next
            Else
              retorno = Nothing
            End If
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Listar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dCaracteristicaItem) As ColecaoCaracteristicaItem

      Dim retorno As ColecaoCaracteristicaItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dCaracteristicaItem
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select cid, caracteristicas_cid, valor "
        sqlWhere = String.Empty
        sqlFrom = " From caracteristicaitem "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- caracteristicas_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.caracteristicas_cid, "caracteristicas_cid")

        '-- valor
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valor, "valor")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoCaracteristicaItem

              For Each row In dt.Rows
                item = New dCaracteristicaItem

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.caracteristicas_cid = cFuncoes.RetornarInteiro(row("caracteristicas_cid"))
                item.valor = cFuncoes.RetornarTexto(row("valor"))

                retorno.Add(item)
              Next
            Else
              retorno = Nothing
            End If
          Else
            retorno = Nothing
          End If
        Else
          retorno = Nothing
        End If

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " caracteristicaitem ( caracteristicas_cid, valor ) " & _
            " VALUES (" & _
            cFuncoes.PersistirTexto(dados.caracteristicas_cid) & "," & _
            cFuncoes.PersistirTexto(dados.valor) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE caracteristicaitem SET " & _
            " caracteristicas_cid = " & cFuncoes.PersistirTexto(dados.caracteristicas_cid) & "," & _
            " valor = " & cFuncoes.PersistirTexto(dados.valor) & _
            " WHERE " & _
            " cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dCaracteristicaItem) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM caracteristicaitem " & _
            " WHERE cid = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir CaracteristicaItem [" & Me.ToString() & "] - " & ex.Message, ex)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
