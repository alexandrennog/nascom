Imports ncDados.nsImpostoCofins
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsImpostoCofins

  Public Class pImpostoCofins

    Public Function Listar() As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoCofins
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id_regra as regra_cid, cst, aliquota From imposto_cofins Order By id_regra "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoImpostoCofins

              For Each row In dt.Rows
                item = New dImpostoCofins

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
        Throw New ExcecaoNascomercio("Erro em Listar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dImpostoCofins) As ColecaoImpostoCofins

      Dim retorno As ColecaoImpostoCofins
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dImpostoCofins
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id_regra as regra_cid, cst, aliquota "
        sqlWhere = String.Empty
        sqlFrom = " From imposto_cofins "

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
              retorno = New ColecaoImpostoCofins

              For Each row In dt.Rows
                item = New dImpostoCofins

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
        Throw New ExcecaoNascomercio("Erro em Consultar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " imposto_cofins ( id_regra, cst, aliquota ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & "," & _
            cFuncoes.PersistirTexto(dados.cst) & "," & _
            cFuncoes.PersistirDecimal(dados.aliquota) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Alterar(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " UPDATE imposto_cofins SET " & _
            " cst = " & cFuncoes.PersistirTexto(dados.cst) & "," & _
            " aliquota = " & cFuncoes.PersistirDecimal(dados.aliquota) & _
            " WHERE " & _
            " id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

    Public Function Excluir(ByVal dados As dImpostoCofins) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM imposto_cofins " & _
            " WHERE id_regra = " & dados.regra_cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ImpostoCofins [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
