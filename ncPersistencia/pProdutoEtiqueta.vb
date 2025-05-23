Imports ncDados.nsProdutoEtiqueta
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsProdutoEtiqueta

  Public Class pProdutoEtiqueta

        Public Function Listar(ByVal dataDe As String, ByVal dataAte As String, ByVal ImprimeTodos As Integer) As ColecaoProdutoEtiqueta

            Dim retorno As ColecaoProdutoEtiqueta
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProdutoEtiqueta
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select data, impressao, produto_cid, produtoItem_codigoBarras, quantidade, " &
            " usuario_cid, usuario_nomeCompleto, referencia, c.nome as cor"
                sqlWhere = String.Empty
                sqlFrom = " From LogEstoque le " &
        " inner join produtos p on p.cid = le.produto_cid " &
        " inner join cor c on p.cor_cid = c.cid " &
        " inner join produtoitem pi on pi.valor = le.produtoItem_codigoBarras "

                '-- dataDe
                If String.IsNullOrEmpty(dataDe) = False Then
                    If Not sqlWhere.Trim().Equals(String.Empty) Then
                        sqlWhere = sqlWhere + " AND "
                    End If
                    sqlWhere = sqlWhere + " data >= '" + dataDe + "'"
                End If

                '-- dataAte
                If String.IsNullOrEmpty(dataAte) = False Then
                    If Not sqlWhere.Trim().Equals(String.Empty) Then
                        sqlWhere = sqlWhere + " AND "
                    End If
                    sqlWhere = sqlWhere + " data <= '" + dataAte + "'"
                End If

                '-- impressao
                If ImprimeTodos = 0 Then
                    If Not sqlWhere.Trim().Equals(String.Empty) Then
                        sqlWhere = sqlWhere + " AND "
                    End If
                    sqlWhere = sqlWhere + " impressao is null"
                End If

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProdutoEtiqueta

                            For Each row In dt.Rows
                                item = New dProdutoEtiqueta

                                item.data = RetornarData(row("data"))
                                item.impressao = RetornarTexto(row("impressao"))
                                item.produto_cid = RetornarInteiro(row("produto_cid"))
                                item.produtoItem_codigoBarras = RetornarTexto(row("produtoItem_codigoBarras"))
                                item.quantidade = RetornarDecimal(row("quantidade"))
                                item.usuario_cid = RetornarInteiro(row("usuario_cid"))
                                item.usuario_nomeCompleto = RetornarTexto(row("usuario_nomeCompleto"))
                                item.referencia = RetornarTexto(row("referencia"))
                                item.cor = RetornarTexto(row("cor"))

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
                Throw New ExcecaoNascomercio("Erro em Listar ProdutoEtiqueta [" & Me.ToString() & "] - " & ex.Message)

            End Try

            Listar = retorno

        End Function

        Public Function Alterar(ByVal data As String, ByVal produto As String, ByVal codigoBarras As String) As Integer

      Dim retorno As Integer
      Dim acessoBanco As cAcessoBD
      Dim comandoSQL As String

      Try

        acessoBanco = New cAcessoBD

                comandoSQL = " UPDATE logEstoque SET " &
            " impressao = 'S' " &
            " WHERE " &
            " produto_cid = " & PersistirInteiro(produto) & " AND " &
            " produtoItem_codigoBarras = " & PersistirTexto(codigoBarras)

                '" data = " & PersistirData(data) & " AND " & _

                retorno = acessoBanco.ExecutarINT(comandoSQL)

      Catch ex As Exception

        retorno = Nothing
        Throw New ExcecaoNascomercio("Erro em Alterar Produto [" & Me.ToString() & "] - " & ex.Message)

      End Try

      Alterar = retorno

    End Function

  End Class

End Namespace