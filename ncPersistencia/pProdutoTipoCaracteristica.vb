Imports ncDados.nsProduto
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

  Public Class pProdutoTipoCaracteristica

    Public Function Listar() As ColecaoProdutoTipoCaracteristica

      Dim retorno As ColecaoProdutoTipoCaracteristica
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dProdutoTipoCaracteristica
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " Select ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome, c.codigo " & _
          " From produtotipocaracteristica ptc " & _
          " inner join caracteristicas c on c.cid = ptc.caracteristica_cid "

        ds = acessoBanco.ExecutarDS(comandoSQL)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoProdutoTipoCaracteristica

              For Each row In dt.Rows
                item = New dProdutoTipoCaracteristica

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.produtoTipo_cid = cFuncoes.RetornarInteiro(row("produtoTipo_cid"))
                item.caracteristica_cid = cFuncoes.RetornarInteiro(row("caracteristica_cid"))
                item.caracteristica_nome = cFuncoes.RetornarTexto(row("nome"))
                item.caracteristica_codigo = cFuncoes.RetornarTexto(row("codigo"))

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
        Throw New ExcecaoNascomercio("Erro em Listar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Listar = retorno

    End Function

    Public Function ConsultarPorProdutoTipo(ByVal produtoTipo_cid As Integer) As ColecaoProdutoTipoCaracteristica

      Dim retorno As ColecaoProdutoTipoCaracteristica
      Dim dados As dProdutoTipoCaracteristica

      Try

        dados = New dProdutoTipoCaracteristica()

        dados.produtoTipo_cid = produtoTipo_cid

        retorno = Consultar(dados)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarPorProdutoTipo = retorno

    End Function

    Public Function Consultar(ByVal dados As dProdutoTipoCaracteristica) As ColecaoProdutoTipoCaracteristica

      Dim retorno As ColecaoProdutoTipoCaracteristica
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dProdutoTipoCaracteristica
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String


      Try

        acessoBanco = New cAcessoBD


        sqlSelect = " Select ptc.cid, ptc.produtoTipo_cid, ptc.caracteristica_cid, c.nome, c.codigo, " & _
          " (select count(*) from caracteristicaitem where caracteristicas_cid = ptc.caracteristica_cid) as quantidade "
        sqlWhere = String.Empty
        sqlFrom = " From produtotipocaracteristica ptc " & _
          " inner join caracteristicas c on c.cid = ptc.caracteristica_cid "

        '-- cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

        '-- produtoTipo_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtoTipo_cid, "produtoTipo_cid")

        '-- caracteristica_cid
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.caracteristica_cid, "caracteristica_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by c.nome ")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoProdutoTipoCaracteristica

              For Each row In dt.Rows
                item = New dProdutoTipoCaracteristica

                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                item.produtoTipo_cid = cFuncoes.RetornarInteiro(row("produtoTipo_cid"))
                item.caracteristica_cid = cFuncoes.RetornarInteiro(row("caracteristica_cid"))
                item.caracteristica_nome = cFuncoes.RetornarTexto(row("nome"))
                item.caracteristica_codigo = cFuncoes.RetornarTexto(row("codigo"))
                                item.quantidade = cFuncoes.RetornarDecimal(row("quantidade"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Consultar = retorno

    End Function

    Public Function Incluir(ByVal dados As dProdutoTipoCaracteristica) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String


      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " INSERT INTO " & _
            " produtotipocaracteristica (produtoTipo_cid, caracteristica_cid ) " & _
            " VALUES (" & _
            cFuncoes.PersistirInteiro(dados.produtoTipo_cid) & "," & _
            cFuncoes.PersistirInteiro(dados.caracteristica_cid) & ")"

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Incluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Incluir = retorno

    End Function

    Public Function ExcluirPorProdutoTipo(ByVal produtoTipo_cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " DELETE FROM produtotipocaracteristica " & _
            " WHERE " & _
            " produtoTipo_cid = " & cFuncoes.PersistirInteiro(produtoTipo_cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorProdutoTipo = retorno

    End Function

    Public Function ExcluirPorCaracteristica(ByVal caracteristica_cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD


        comandoSQL = " DELETE FROM produtotipocaracteristica " & _
            " WHERE " & _
            " caracteristica_cid = " & cFuncoes.PersistirInteiro(caracteristica_cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ExcluirPorCaracteristica = retorno

    End Function

    Public Function Excluir(ByVal cid As Integer) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

        comandoSQL = " DELETE FROM produtotipocaracteristica " & _
            " WHERE " & _
            " cid = " & cFuncoes.PersistirInteiro(cid)

        retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Excluir ProdutoTipoCaracteristica [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Excluir = retorno

    End Function

  End Class

End Namespace
