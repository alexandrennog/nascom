Imports ncDados.nsGradeItem
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsGradeItem

  Public Class pGradeItem

    Public Function ConsultarReferencia(ByVal dados As dGradeItem) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGradeItem
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " select p.referencia, p.descricao "
        sqlWhere = String.Empty
        sqlFrom = " from produtos p "

        '-- fornecedor
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "p.fornecedor_cid")

        '-- fabricante
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.fabricante_cid, "p.fabricante_cid")

        '-- grupo
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.grupo_cid, "p.grupo_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        If dados.ordem = True Then
          ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " group by p.referencia order by p.descricao ")
        Else
          ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " group by p.referencia ")
        End If


        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGradeItem

              For Each row In dt.Rows
                item = New dGradeItem

                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                item.descricao = cFuncoes.RetornarTexto(row("descricao"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Referência [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarReferencia = retorno

    End Function

    Public Function ConsultarUltimaVenda(ByVal referencia As String, ByVal gradeItem As dGradeItem) As dGradeItem

      Dim retorno As dGradeItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " select v.data, c.nome "
        sqlFrom = " from vendasprodutos vp " & _
                  " inner join vendas v " & _
                  "   on v.controle = vp.controle " & _
                  " inner join produtos p " & _
                  "   on p.cid = vp.produto " & _
                  " inner join cor c " & _
                  "   on c.cid = p.cor_cid "
        sqlWhere = String.Empty

        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, referencia, "p.referencia")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.fabricante_cid, "p.fabricante_cid")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.fornecedor_cid, "p.fornecedor_cid")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.grupo_cid, "p.grupo_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by v.data desc limit 1 ")

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New dGradeItem
              row = dt.Rows(0)

              retorno.dataUltimaVenda = cFuncoes.RetornarData(row("data"))
              retorno.corMaterial = cFuncoes.RetornarTexto(row("nome"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar Ultima Venda [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarUltimaVenda = retorno

    End Function

    Public Function ConsultarProdutos(ByVal referencia As String, ByVal gradeItem As dGradeItem) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGradeItem
      Dim sqlSelect As String
      Dim sqlWhere As String
      Dim sqlFrom As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " select p.cid, c.nome as corMat "
        sqlWhere = String.Empty
        sqlFrom = " from produtos p " & _
                  "   inner join cor c " & _
                  "     on c.cid = p.cor_cid "

        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, referencia, "p.referencia")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.fabricante_cid, "p.fabricante_cid")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.fornecedor_cid, "p.fornecedor_cid")
        sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, gradeItem.grupo_cid, "p.grupo_cid")

        If Not sqlWhere.Equals(String.Empty) Then
          sqlWhere = " WHERE " & sqlWhere
        End If

        If gradeItem.ordem = True Then
          ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere & " order by c.nome ")
        Else
          ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)
        End If

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGradeItem

              For Each row In dt.Rows
                item = New dGradeItem

                item.produto_cid = cFuncoes.RetornarInteiro(row("cid"))
                item.corMaterial = cFuncoes.RetornarTexto(row("corMat"))

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
        Throw New ExcecaoNascomercio("Erro em Consultar Produtos [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarProdutos = retorno

    End Function

    Public Function ConsultarItens(ByVal pProdutoCid As Integer) As ColecaoGradeItem

      Dim retorno As ColecaoGradeItem
      Dim acessoBanco As cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim row As DataRow
      Dim item As dGradeItem
      Dim sqlSelect As String

      Try

        acessoBanco = New cAcessoBD

        sqlSelect = " select " & _
            "   tabProduto.produto, tabProduto.item, tabProduto.tamanho, " & _
            "   tabProduto.estoque, tabProduto.codigoBarras, tabProduto.dataEntrada, " & _
            "   ifnull(sum(le2.quantidade), 0) as quantidade " & _
            " from " & _
            "   ( " & _
            " select distinct " & _
            "   pi.produtos_cid as produto, pi.item, tabTamanho.valor as tamanho, " & _
            "   tabEstoque.valor as estoque, tabBarra.valor as codigoBarras, " & _
            "   tabData.data as dataEntrada " & _
            " from " & _
            "   produtoitem pi " & _
            "   inner join " & _
            "     ( " & _
            "       select pi1.* from produtoitem pi1 " & _
            "       where pi1.produtos_cid = " & pProdutoCid.ToString() & " and pi1.caracteristicas_cid = 3 " & _
            "     ) as tabTamanho " & _
            "     on tabTamanho.produtos_cid = pi.produtos_cid and tabTamanho.item = pi.item " & _
            "   inner join " & _
            "     ( " & _
            "       select pi2.* from produtoitem pi2 " & _
            "       where pi2.produtos_cid = " & pProdutoCid.ToString() & " and pi2.caracteristicas_cid = 2 " & _
            "     ) as tabEstoque " & _
            "     on tabEstoque.produtos_cid = pi.produtos_cid and tabEstoque.item = pi.item " & _
            "   inner join " & _
            "     ( " & _
            "       select pi3.* from produtoitem pi3 " & _
            "       where pi3.produtos_cid = " & pProdutoCid.ToString() & " and pi3.caracteristicas_cid = 1 " & _
            "     ) as tabBarra " & _
            "     on tabBarra.produtos_cid = pi.produtos_cid and tabBarra.item = pi.item " & _
            "   left outer join " & _
            "     ( " & _
            "       select distinct DATE_FORMAT(le1.data,'%Y-%m-%d') as data, le1.produto_cid " & _
            "       from logestoque le1 where le1.produto_cid = " & pProdutoCid.ToString() & " " & _
            "       order by le1.data desc limit 1 " & _
            "     ) as tabData " & _
            "     on tabData.produto_cid = pi.produtos_cid " & _
            " where " & _
            "   pi.produtos_cid = " & pProdutoCid.ToString() & " " & _
            "   ) as tabProduto " & _
            " left outer join " & _
            "   logestoque le2 " & _
            "   on le2.produto_cid = tabProduto.produto and " & _
            "      le2.produtoItem_codigoBarras = tabProduto.codigoBarras and " & _
            "      DATE_FORMAT(le2.data,'%Y-%m-%d') = DATE_FORMAT(tabProduto.dataEntrada,'%Y-%m-%d') " & _
            " group by " & _
            "   tabProduto.produto, tabProduto.item, tabProduto.tamanho, " & _
            "   tabProduto.estoque, tabProduto.codigoBarras, tabProduto.dataEntrada " & _
            " order by " & _
            "   tabProduto.tamanho "

        ds = acessoBanco.ExecutarDS(sqlSelect)

        If Not ds Is Nothing Then
          If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
              retorno = New ColecaoGradeItem

              For Each row In dt.Rows
                item = New dGradeItem

                item.produto_cid = cFuncoes.RetornarInteiro(row("produto"))
                item.item = cFuncoes.RetornarInteiro(row("item"))
                item.tamanho = cFuncoes.RetornarTexto(row("tamanho"))
                item.estoque = cFuncoes.RetornarTexto(row("estoque"))
                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                item.dataEntrada = cFuncoes.RetornarData(row("dataEntrada"))
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
        Throw New ExcecaoNascomercio("Erro em Consultar Itens [" & Me.ToString() & "] - " & ex.Message)

      End Try

      ConsultarItens = retorno

    End Function

  End Class

End Namespace