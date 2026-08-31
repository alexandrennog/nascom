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


                sqlSelect = " SELECT e.fabricante, e.cid, p.descricao, e.referencia, e.item, e.valorCompra, e.valorVenda, e.valor, c.nome as cor"

                sqlWhere = String.Empty
                sqlFrom = " FROM nascomercio.produtos as p "
                sqlFrom += "  INNER JOIN nascomercio.v_estoque as e ON e.cid = p.cid "
                sqlFrom += "  INNER Join nascomercio.cor as c ON c.cid = p.cor_cid "

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
