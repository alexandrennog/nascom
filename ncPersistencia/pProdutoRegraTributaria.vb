Imports ncDados.nsProdutoRegraTributaria
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProdutoRegraTributaria

  Public Class pProdutoRegraTributaria

    Public Function Listar() As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dProdutoRegraTributaria
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id as cid, id_produto as produto_cid, id_regra as regra_cid From produto_regra_tributaria Order By id "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoProdutoRegraTributaria

              For Each row In dt.Rows
                item = New dProdutoRegraTributaria

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.produto_cid = cFuncoes.RetornarInteiro(row("produto_cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function Consultar(ByVal dados As dProdutoRegraTributaria) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dProdutoRegraTributaria
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select id as cid, id_produto as produto_cid, id_regra as regra_cid "
        sqlWhere = String.Empty
        sqlFrom = " From produto_regra_tributaria "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "id")

        '-- produto_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produto_cid, "id_produto")

        '-- regra_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.regra_cid, "id_regra")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " Order By id")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoProdutoRegraTributaria

              For Each row In dt.Rows
                item = New dProdutoRegraTributaria

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.produto_cid = cFuncoes.RetornarInteiro(row("produto_cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function ListarPorProduto(ByVal produto_cid As Integer) As ColecaoProdutoRegraTributaria

      Dim retorno As ColecaoProdutoRegraTributaria
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dProdutoRegraTributaria
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select id as cid, id_produto as produto_cid, id_regra as regra_cid " & _
            " From produto_regra_tributaria " & _
            " WHERE id_produto = " & produto_cid.ToString() & _
            " Order By id "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoProdutoRegraTributaria

              For Each row In dt.Rows
                item = New dProdutoRegraTributaria

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.produto_cid = cFuncoes.RetornarInteiro(row("produto_cid"))
                item.regra_cid = cFuncoes.RetornarInteiro(row("regra_cid"))

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
        Throw New ExcecaoNascomercio("Erro em ListarPorProduto ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ListarPorProduto = retorno

    End Function

    Public Function Incluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " produto_regra_tributaria ( id_produto, id_regra ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.produto_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.regra_cid) & ")"

        retorno = acessoBanco.ExecutarCID(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function Excluir(ByVal dados As dProdutoRegraTributaria) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM produto_regra_tributaria " & _
            " WHERE id = " & dados.cid.ToString()

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoRegraTributaria [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
