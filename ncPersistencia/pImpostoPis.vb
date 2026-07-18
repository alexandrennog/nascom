Imports ncDados.nsImpostoPis
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoPis

  Public Class pImpostoPis

    Public Function Listar() As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoPis
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_regra as regra_cid, cst, aliquota From imposto_pis Order By id_regra "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoPis

              For Each row In dt.Rows
                item = New dImpostoPis

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cst = cFuncoes.RetornarTexto(row("cst"))
                item.aliquota = cFuncoes.RetornarDecimal(row("aliquota"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoPis) As ColecaoImpostoPis

      Dim retorno As ColecaoImpostoPis
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoPis
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_regra as regra_cid, cst, aliquota "
        sqlWhere = String.Empty
        sqlFrom = " From imposto_pis "

        '-- regra_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.regra_cid, "id_regra")

        '-- cst
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cst, "cst")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By id_regra")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoPis

              For Each row In dt.Rows
                item = New dImpostoPis

                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cst = cFuncoes.RetornarTexto(row("cst"))
                item.aliquota = cFuncoes.RetornarDecimal(row("aliquota"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " imposto_pis ( id_regra, cst, aliquota ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & "," & _
            cFuncoes.PersistirTexto(dados.cst) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquota) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE imposto_pis SET " & _
            " cst = " & cFuncoes.PersistirTexto(dados.cst) & "," & _
            " aliquota = " & cFuncoes.PersistirDecimal(dados.aliquota) & _
            " WHERE " & _
            " id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoPis) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM imposto_pis " & _
            " WHERE id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoPis [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
