Imports ncDados.nsParametro
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao
Imports ncDados.nsdParametroEstoque
Imports ncDados
Imports System.Security.Cryptography

Namespace nsParametro

    Public Class pParametro

        Public Function Listar() As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParametro
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " Select cid, descricao, valor From Parametros "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParametro

                            For Each row In dt.Rows
                                item = New dParametro

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
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

                Throw New ExcecaoNascomercio("Erro em Listar Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Listar = retorno

        End Function

        Public Function Consultar(ByVal dados As dParametro) As ColecaoParametro

            Dim retorno As ColecaoParametro
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dParametro
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                sqlSelect = " Select cid, descricao, valor "
                sqlWhere = String.Empty
                sqlFrom = " From Parametros "

                '-- cid
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.cid, "cid")

                '-- descricao
                sqlWhere = cFuncoes.MontarParametrosSQL(sqlWhere, dados.descricao, "descricao")

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
                            retorno = New ColecaoParametro

                            For Each row In dt.Rows
                                item = New dParametro

                                item.cid = cFuncoes.RetornarInteiro(row("cid"))
                                item.descricao = cFuncoes.RetornarTexto(row("descricao"))
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

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Consultar = retorno

        End Function

        Public Function ConsultarEstoque(ByVal dados As dParametroEstoque) As ColecaoParametroEstoque

            Dim retorno As ColecaoParametroEstoque
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim item As dEstoque
            Dim sqlSelect As String
            Dim sqlWhere As String
            Dim sqlFrom As String

            Try

                acessoBanco = New cAcessoBD


                ' "e.item" (v_estoque) e' so' o numero sequencial da linha de caracteristica (produtoitem.item),
                ' NAO e' o tamanho/numeracao do calcado -- isso fica em outra linha da mesma tabela produtoitem,
                ' com caracteristicas_cid apontando pra caracteristica de codigo 'tamanho' (mesmo produtos_cid + item).
                ' Por isso o join extra com produtoitem/caracteristicas abaixo, pra trazer o valor de verdade
                ' (ex: "35", "36"...) em vez do indice interno (1, 2, 3...).
                sqlSelect = " SELECT e.fabricante, e.cid, p.descricao, e.referencia, pit.valor as item, e.valorCompra, e.valorVenda, e.valor, c.nome as cor"

                sqlWhere = String.Empty
                sqlFrom = " FROM nascomercio.produtos as p "
                sqlFrom += "  INNER JOIN nascomercio.v_estoque as e ON e.cid = p.cid "
                sqlFrom += "  INNER Join nascomercio.cor as c ON c.cid = p.cor_cid "
                sqlFrom += "  INNER JOIN nascomercio.produtoitem as pit ON pit.produtos_cid = e.produtos_cid AND pit.item = e.item "
                sqlFrom += "  INNER JOIN nascomercio.caracteristicas as ct ON ct.cid = pit.caracteristicas_cid AND ct.codigo = 'tamanho' "

                If dados.valor = 1 Then
                    sqlWhere = sqlWhere + " e.valor > 0"
                Else
                    sqlWhere = sqlWhere + " e.valor = 0"
                End If

                If dados.cidGrupo > 0 Then
                    sqlWhere = sqlWhere + " AND p.grupo_cid = " + dados.cidGrupo.ToString
                End If

                If dados.cidFornecedor > 0 Then
                    sqlWhere = sqlWhere + " AND e.fornecedor_cid = " + dados.cidFornecedor.ToString
                End If

                If dados.cidFabricante > 0 Then
                    sqlWhere = sqlWhere + " AND e.fabricante_cid = " + dados.cidFabricante.ToString
                End If

                If Not String.IsNullOrEmpty(dados.descricao) Then
                    sqlWhere = sqlWhere + "AND descricao = '" + dados.descricao + "'"
                End If

                If Not String.IsNullOrEmpty(dados.numeracao) Then
                    sqlWhere = sqlWhere + " AND pit.valor = '" + dados.numeracao + "'"
                End If

                ' Filtro por periodo de cadastro do produto (dataInclusao). dados.dataCadastroInicio/Fim ja chegam
                ' validados e normalizados para AAAA-MM-DD (cFuncoes.FormatarData), entao entram direto no BETWEEN.
                If Not String.IsNullOrEmpty(dados.dataCadastroInicio) And Not String.IsNullOrEmpty(dados.dataCadastroFim) Then
                    sqlWhere = sqlWhere + " AND p.dataInclusao BETWEEN '" + dados.dataCadastroInicio + "' AND '" + dados.dataCadastroFim + "'"
                ElseIf Not String.IsNullOrEmpty(dados.dataCadastroInicio) Then
                    sqlWhere = sqlWhere + " AND p.dataInclusao >= '" + dados.dataCadastroInicio + "'"
                ElseIf Not String.IsNullOrEmpty(dados.dataCadastroFim) Then
                    sqlWhere = sqlWhere + " AND p.dataInclusao <= '" + dados.dataCadastroFim + "'"
                End If


                If Not sqlWhere.Equals(String.Empty) Then
                    sqlWhere = " WHERE " & sqlWhere
                End If

                ds = acessoBanco.ExecutarDS(sqlSelect & " " & sqlFrom & " " & sqlWhere + " order by p.codigo, e.item")

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        If dt.Rows.Count > 0 Then
                            retorno = New ColecaoParametroEstoque

                            For Each row In dt.Rows
                                item = New dEstoque
                                item.Fabricante = cFuncoes.RetornarTexto(row("fabricante"))
                                item.CID = cFuncoes.RetornarTexto(row("cid"))
                                item.Descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.Referencia = cFuncoes.RetornarTexto(row("referencia"))
                                item.Item = cFuncoes.RetornarTexto(row("item"))
                                item.ValorCompra = cFuncoes.RetornarDecimal(row("valorCompra"))
                                item.ValorVenda = cFuncoes.RetornarDecimal(row("valorVenda"))
                                item.Descricao = cFuncoes.RetornarTexto(row("descricao"))
                                item.Valor = cFuncoes.RetornarDecimal(row("valor"))
                                item.Cor = cFuncoes.RetornarTexto(row("cor"))
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

            Catch nex As ExcecaoNascomercio

                Throw

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Consultar Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ConsultarEstoque = retorno

        End Function

        ' Lista os valores distintos de numeração/tamanho (produtoitem.valor, na linha cuja
        ' caracteristica tem codigo = 'tamanho') ja usados nos produtos, pra alimentar o combo
        ' de filtro do Relatório de Estoque (ver fRelatorioEstoque.vb / CarregarComboNumeracao).
        ' IMPORTANTE: NAO e' a coluna "item" da view v_estoque -- aquela e' só o índice sequencial
        ' interno da linha (1, 2, 3...), não o tamanho de verdade (35, 36...).
        Public Function ListarNumeracoes() As List(Of String)

            Dim retorno As New List(Of String)
            Dim acessoBanco As cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim row As DataRow
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                ' Nao filtra nenhum valor (fica tudo na lista, inclusive lixo cadastrado errado tipo
                ' "0".."28" ou "491".."494"), so' ordena pra mostrar primeiro quem tem cara de
                ' numeracao de calcado de verdade: numero de 2 digitos entre 14 e 48, combinacao tipo
                ' "17/18", ou os rotulos especiais (Tamanho Unico/Único, RN, PP, P, M, G, GG, XG) --
                ' o resto (lixo) fica depois, numeros em ordem numerica e so' depois texto em ordem
                ' alfabetica (sem isso "100" aparecia antes de "11" porque o banco ordenava como texto).
                comandoSQL = " SELECT DISTINCT pit.valor as tamanho " & _
                    " FROM nascomercio.produtoitem as pit " & _
                    " INNER JOIN nascomercio.caracteristicas as ct ON ct.cid = pit.caracteristicas_cid AND ct.codigo = 'tamanho' " & _
                    " WHERE pit.valor IS NOT NULL AND pit.valor <> '' " & _
                    " ORDER BY " & _
                    "   CASE " & _
                    "     WHEN pit.valor REGEXP '^[0-9]{2}$' AND CAST(pit.valor AS UNSIGNED) BETWEEN 14 AND 48 THEN 0 " & _
                    "     WHEN pit.valor REGEXP '^[0-9]{1,2}/[0-9]{1,2}$' THEN 0 " & _
                    "     WHEN pit.valor REGEXP '^Tamanho[ _]?[UÚ]nico$' THEN 0 " & _
                    "     WHEN pit.valor REGEXP '^(RN|PP|P|M|G|GG|XG)(;(RN|PP|P|M|G|GG|XG))*$' THEN 0 " & _
                    "     ELSE 1 " & _
                    "   END, " & _
                    "   (pit.valor REGEXP '^[0-9]+$') DESC, CAST(pit.valor AS UNSIGNED) DESC, pit.valor DESC "

                ds = acessoBanco.ExecutarDS(comandoSQL)

                If Not ds Is Nothing Then
                    If ds.Tables.Count > 0 Then
                        dt = ds.Tables(0)

                        For Each row In dt.Rows
                            retorno.Add(cFuncoes.RetornarTexto(row("tamanho")))
                        Next
                    End If
                End If

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em ListarNumeracoes Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            ListarNumeracoes = retorno

        End Function

        Public Function Incluir(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " INSERT INTO " & _
                    " Parametros ( descricao, valor ) " & _
                    " VALUES (" & _
                    cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    cFuncoes.PersistirTexto(dados.valor) & ")"

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Incluir Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Incluir = retorno

        End Function

        Public Function Alterar(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD


                comandoSQL = " UPDATE Parametros SET " & _
                    " descricao = " & cFuncoes.PersistirTexto(dados.descricao) & "," & _
                    " valor = " & cFuncoes.PersistirTexto(dados.valor) & _
                    " WHERE " & _
                    " cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Alterar Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Alterar = retorno

        End Function

        Public Function Excluir(ByVal dados As dParametro) As Integer

            Dim retorno As Integer
            Dim acessoBanco As cAcessoBD
            Dim comandoSQL As String

            Try

                acessoBanco = New cAcessoBD

                comandoSQL = " DELETE FROM Parametros " & _
                    " WHERE cid = " & dados.cid.ToString()

                retorno = acessoBanco.ExecutarINT(comandoSQL)

            Catch ex As Exception

                retorno = Nothing
                Throw New ExcecaoNascomercio("Erro em Excluir Parametro [" & Me.ToString() & "] - " & ex.Message, ex)

            End Try

            Excluir = retorno

        End Function

    End Class

End Namespace
