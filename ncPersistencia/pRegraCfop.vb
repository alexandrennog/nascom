Imports ncDados.nsRegraCfop
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsRegraCfop

  Public Class pRegraCfop

    Public Function Listar() As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dRegraCfop
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id as cid, id_regra as regra_cid, cfop From regra_cfop Order By id "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoRegraCfop

              For Each row In dt.Rows
                item = New dRegraCfop

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cfop = cFuncoes.RetornarTexto(row("cfop"))

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
        Throw New ExcecaoNascomercio("Erro em Listar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dRegraCfop) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dRegraCfop
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id as cid, id_regra as regra_cid, cfop "
        sqlWhere = String.Empty
        sqlFrom = " From regra_cfop "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "id")

        '-- regra_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.regra_cid, "id_regra")

        '-- cfop
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cfop, "cfop")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By id")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoRegraCfop

              For Each row In dt.Rows
                item = New dRegraCfop

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cfop = cFuncoes.RetornarTexto(row("cfop"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ListarPorRegra(ByVal regra_cid As Integer) As ColecaoRegraCfop

      Dim retorno As ColecaoRegraCfop
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dRegraCfop
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id as cid, id_regra as regra_cid, cfop " & _
            " From regra_cfop " & _
            " WHERE id_regra = " & regra_cid.ToString() & _
            " Order By cfop "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoRegraCfop

              For Each row In dt.Rows
                item = New dRegraCfop

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))
                item.cfop = cFuncoes.RetornarTexto(row("cfop"))

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
        Throw New ExcecaoNascomercio("Erro em ListarPorRegra RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ListarPorRegra = retorno

    End Function

    Public Function Incluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " regra_cfop ( id_regra, cfop ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & "," & _
            cFuncoes.PersistirTexto(dados.cfop) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Excluir(ByVal dados As dRegraCfop) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM regra_cfop " & _
            " WHERE id = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir RegraCfop [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
