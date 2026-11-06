Imports ncDados.nsProduto
Imports ncDados.nsGradeItem
Imports ncDados.nsGradeEntrada
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsProduto

    Public Class pProduto

        Public Function Listar() As ColecaoProduto

            Dim retorno As ColecaoProduto
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProduto
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " Select cid, codigo, descricao, situacao, produtoTipo_cid, fornecedor_cid, fabricante_cid, " & _
                    " dataInclusao, valorCompra, valorVenda, referencia, imagem, estoqueMinimo, cor_cid, " & _
                    " grupo_cid, aliquota, efdUnidadeMedidaCodigo, efdIntegracao " & _
                    " From produtos "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProduto

                            For Each row In dt.Rows
                                item = New dProduto

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.dataInclusao = cFuncoes.RetornarTexto(row("dataInclusao"))
                                item.valorCompra = cFuncoes.RetornarDecimal(row("valorCompra"))
                                item.valorVenda = cFuncoes.RetornarDecimal(row("valorVenda"))
                                item.produtoTipo_cid = cFuncoes.RetornarInteiro(row("produtoTipo_cid"))
                                item.fornecedor_cid = cFuncoes.RetornarInteiro(row("fornecedor_cid"))
                                item.fabricante_cid = cFuncoes.RetornarInteiro(row("fabricante_cid"))
                                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.imagem = cFuncoes.RetornarTexto(row("imagem"))
                                item.cor_cid = cFuncoes.RetornarInteiro(row("cor_cid"))
                                item.grupo_cid = cFuncoes.RetornarInteiro(row("grupo_cid"))
                                item.aliquota = cFuncoes.RetornarTexto(row("aliquota"))
                                item.estoqueMinimo = cFuncoes.RetornarInteiro(row("estoqueMinimo"))
                                item.efdUnidadeMedidaCodigo = cFuncoes.RetornarTexto(row("efdUnidadeMedidaCodigo"))
                                item.efdIntegracao = cFuncoes.RetornarBoleano(row("efdIntegracao"))

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
                Throw New ExcecaoNascomercio("Erro em Listar Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dProduto) As ColecaoProduto

            Dim retorno As ColecaoProduto
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dProduto
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " Select Distinct p.cid, p.codigo, p.descricao, p.situacao, p.produtoTipo_cid, p.fornecedor_cid, p.fabricante_cid, " & _
                    " p.dataInclusao, p.valorCompra, p.valorVenda, p.referencia, p.imagem, p.estoqueMinimo, p.cor_cid, " & _
                    " p.grupo_cid, p.aliquota, c.nome as cor, g.nome as grupo, p.efdUnidadeMedidaCodigo, p.efdCodigoCategoria, p.efdIntegracao, ct.nome as categoria "
                sqlFrom = " From produtos p " & _
                    " Left Outer Join produtoitem pi On pi.produtos_cid = p.cid " & _
                    " And pi.caracteristicas_cid = 1 " & _
                    " Left Outer Join cor c On c.cid = p.cor_cid " & _
                    " Left Outer Join categoria ct On ct.cid = p.efdCodigoCategoria " & _
                    " Left Outer Join grupo g On g.cid = p.grupo_cid "
                sqlWhere = String.Empty

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "p.cid")

                '-- codigo
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigo, "p.codigo")

                '-- descricao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descricao, "p.descricao", True)

                '-- situacao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.situacao, "p.situacao")

                '-- dataInclusao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.dataInclusao, "p.dataInclusao")

                '-- valorCompra
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valorCompra, "p.valorCompra")

                '-- valorVenda
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.valorVenda, "p.valorVenda")

                '-- produtoTipo_cid
                ' sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.produtoTipo_cid, "p.produtoTipo_cid")

                '-- fornecedor_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.fornecedor_cid, "p.fornecedor_cid")

                '-- fabricante_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.fabricante_cid, "p.fabricante_cid")

                '-- referencia
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.referencia, "p.referencia")

                '-- imagem
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.imagem, "p.imagem")

                '-- cor_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cor_cid, "p.cor_cid")

                '-- grupo_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.grupo_cid, "p.grupo_cid")

                '-- aliquota
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.aliquota, "p.aliquota")

                '-- estoqueMinimo
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.estoqueMinimo, "p.estoqueMinimo")

                '-- codigoBarras
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.codigoBarras, "pi.valor")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoProduto

                            For Each row In dt.Rows
                                item = New dProduto

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.codigo = cFuncoes.RetornarTexto(row("codigo"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.situacao = cFuncoes.RetornarTexto(row("situacao"))
                                item.dataInclusao = cFuncoes.RetornarTexto(row("dataInclusao"))
                                item.valorCompra = cFuncoes.RetornarDecimal(row("valorCompra"))
                                item.valorVenda = cFuncoes.RetornarDecimal(row("valorVenda"))
                                item.produtoTipo_cid = cFuncoes.RetornarInteiro(row("produtoTipo_cid"))
                                item.fornecedor_cid = cFuncoes.RetornarInteiro(row("fornecedor_cid"))
                                item.fabricante_cid = cFuncoes.RetornarInteiro(row("fabricante_cid"))
                                item.referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.imagem = cFuncoes.RetornarTexto(row("imagem"))
                                item.cor_cid = cFuncoes.RetornarInteiro(row("cor_cid"))
                                item.cor = cFuncoes.RetornarTexto(row("cor"))
                                item.grupo_cid = cFuncoes.RetornarInteiro(row("grupo_cid"))
                                item.grupo = cFuncoes.RetornarTexto(row("grupo"))
                                item.aliquota = cFuncoes.RetornarTexto(row("aliquota"))
                                item.estoqueMinimo = cFuncoes.RetornarInteiro(row("estoqueMinimo"))
                                item.efdUnidadeMedidaCodigo = cFuncoes.RetornarTexto(row("efdUnidadeMedidaCodigo"))
                                item.efdCodigoCategoria = cFuncoes.RetornarTexto(row("efdCodigoCategoria"))
                                item.efdIntegracao = cFuncoes.RetornarBoleano(row("efdIntegracao"))
                                item.efdCategoria = cFuncoes.RetornarTexto(row("categoria"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarGradeEntrada(ByVal dados As dProduto) As ColecaoGradeEntrada

            Dim retorno As ColecaoGradeEntrada
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dGradeEntrada
            Dim sqlSelect1 As String
            Dim sqlWhere As String
            Dim sqlSelect2 As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect1 = " select " & _
                    "   le.produto_cid as 'produto', " & _
                    "   le.produtoitem_codigobarras as 'codigoBarras', " & _
                    "   DATE_FORMAT(le.data,'%Y-%m-%d') as 'entrada_data', " & _
                    "   pi.item as 'item', " & _
                    "   ( " & _
                    "     select pi2.valor " & _
                    "     from produtoitem pi2 " & _
                    "     where pi2.produtos_cid = produto_cid " & _
                    "       and pi2.item = pi.item " & _
                    "       and pi2.caracteristicas_cid = 3 " & _
                    "   ) as 'tamanho', " & _
                    "   sum(le.quantidade) as 'entrada_qtde' " & _
                    " from " & _
                    "   logestoque le " & _
                    "   inner join produtoitem pi " & _
                    "     on " & _
                    "       ( " & _
                    "         pi.valor = le.produtoitem_codigobarras " & _
                    "         and " & _
                    "         pi.caracteristicas_cid = 1 " & _
                    "       ) "

                sqlSelect2 = " group by " & _
                    "   le.produto_cid, le.produtoitem_codigobarras, entrada_data, item, tamanho " & _
                    " order by " & _
                    "   produto_cid, entrada_data, produtoitem_codigobarras ; "

                sqlWhere = String.Empty

                '-- Data inicio/fim
                sqlWhere = sqlWhere & " ( DATE_FORMAT(le.data,'%Y-%m-%d') between '" & dados.dataInicio & "' and '" & dados.dataFinal & "' ) "

                '-- produto_cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "le.produto_cid")

                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " where " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect1 & " " & sqlWhere & " " & sqlSelect2)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoGradeEntrada

                            For Each row In dt.Rows
                                item = New dGradeEntrada

                                item.produto_cid = cFuncoes.RetornarInteiro(row("produto"))
                                item.item = cFuncoes.RetornarInteiro(row("item"))
                                item.codigoBarras = cFuncoes.RetornarTexto(row("codigoBarras"))
                                item.tamanho = cFuncoes.RetornarTexto(row("tamanho"))
                                item.entrada_data = cFuncoes.RetornarTexto(row("entrada_data"))
                                item.entrada_qtde = cFuncoes.RetornarInteiro(row("entrada_qtde"))

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
                Throw New ExcecaoNascomercio("Erro em Consultar Grade Entrada [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarGradeEntrada = retorno

        End Function

        Public Function ConsultarProximoCID() As Integer

            Dim retorno As Integer = 0
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim sqlSelect As String

            Try

                acessoBanco = New cAcessoBD

                sqlSelect = " select max(p.cid) as cid from produtos p "

                ds = acessoBanco.ExecutarDS(sqlSelect)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0).Item("cid") IsNot DBNull.Value Then
                                retorno = cFuncoes.RetornarInteiro(dt.Rows(0).Item("cid"))
                            Else
                                retorno = 0
                            End If
                        Else
                            retorno = 0
                        End If
                    Else
                        retorno = 0
                    End If
                Else
                    retorno = 0
                End If

            Catch ex As Exception

                retorno = 0
                Throw New ExcecaoNascomercio("Erro em ConsultarProximoCID Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarProximoCID = retorno

        End Function

        Public Function Incluir(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " produtos (codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, " & _
                    " referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao, " & _
                    " efdUnidadeMedidaCodigo, efdCodigoCategoria, efdIntegracao ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.codigo) & "," & _
                    cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    cFuncoes.PersistirInteiro(dados.produtoTipo_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.fornecedor_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.fabricante_cid) & "," & _
                    cFuncoes.PersistirDecimal(dados.valorCompra) & "," & _
                    cFuncoes.PersistirDecimal(dados.valorVenda) & "," & _
                    cFuncoes.PersistirTexto(dados.referencia) & "," & _
                    cFuncoes.PersistirTexto(dados.imagem) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    cFuncoes.PersistirInteiro(dados.cor_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.grupo_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.estoqueMinimo) & "," & _
                    cFuncoes.PersistirTexto(dados.aliquota) & "," & _
                    cFuncoes.PersistirTexto(dados.dataInclusao) & "," & _
                    cFuncoes.PersistirTexto(dados.efdUnidadeMedidaCodigo) & "," & _
                    cFuncoes.PersistirTexto(dados.efdCodigoCategoria) & "," & _
                    cFuncoes.PersistirBoleano(dados.efdIntegracao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Importar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " produtos (cid, codigo, descricao, produtoTipo_cid, fornecedor_cid, fabricante_cid, valorCompra, valorVenda, " & _
                    " referencia, imagem, situacao, cor_cid, grupo_cid, estoqueMinimo, aliquota, dataInclusao ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirInteiro(dados.cid) & "," & _
                    cFuncoes.PersistirTexto(dados.codigo) & "," & _
                    cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    cFuncoes.PersistirInteiro(dados.produtoTipo_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.fornecedor_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.fabricante_cid) & "," & _
                    cFuncoes.PersistirDecimal(dados.valorCompra) & "," & _
                    cFuncoes.PersistirDecimal(dados.valorVenda) & "," & _
                    cFuncoes.PersistirTexto(dados.referencia) & "," & _
                    cFuncoes.PersistirTexto(dados.imagem) & "," & _
                    cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    cFuncoes.PersistirInteiro(dados.cor_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.grupo_cid) & "," & _
                    cFuncoes.PersistirInteiro(dados.estoqueMinimo) & "," & _
                    cFuncoes.PersistirTexto(dados.aliquota) & "," & _
                    cFuncoes.PersistirTexto(dados.dataInclusao) & ")"

                retorno = acessoBanco.ExecutarCID(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Importar Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Importar = retorno

        End Function

        Public Function Alterar(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE produtos SET " & _
                    " codigo = " & cFuncoes.PersistirTexto(dados.codigo) & "," & _
                    " descricao = " & cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    " produtoTipo_cid = " & cFuncoes.PersistirInteiro(dados.produtoTipo_cid) & "," & _
                    " fornecedor_cid = " & cFuncoes.PersistirInteiro(dados.fornecedor_cid) & "," & _
                    " fabricante_cid = " & cFuncoes.PersistirInteiro(dados.fabricante_cid) & "," & _
                    " valorCompra = " & cFuncoes.PersistirDecimal(dados.valorCompra) & "," & _
                    " valorVenda = " & cFuncoes.PersistirDecimal(dados.valorVenda) & "," & _
                    " imagem = " & cFuncoes.PersistirTexto(dados.imagem) & "," & _
                    " referencia = " & cFuncoes.PersistirTexto(dados.referencia) & "," & _
                    " situacao = " & cFuncoes.PersistirTexto(dados.situacao) & "," & _
                    " cor_cid = " & cFuncoes.PersistirInteiro(dados.cor_cid) & "," & _
                    " grupo_cid = " & cFuncoes.PersistirInteiro(dados.grupo_cid) & "," & _
                    " estoqueMinimo = " & cFuncoes.PersistirInteiro(dados.estoqueMinimo) & "," & _
                    " aliquota = " & cFuncoes.PersistirTexto(dados.aliquota) & "," & _
                    " dataInclusao = " & cFuncoes.PersistirTexto(dados.dataInclusao) & "," & _
                    " efdUnidadeMedidaCodigo = " & cFuncoes.PersistirTexto(dados.efdUnidadeMedidaCodigo) & "," & _
                    " efdCodigoCategoria = " & cFuncoes.PersistirTexto(dados.efdCodigoCategoria) & "," & _
                    " efdIntegracao = " & cFuncoes.PersistirBoleano(dados.efdIntegracao) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dProduto) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM produtos " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Produto [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
