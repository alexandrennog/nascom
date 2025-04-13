Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

    Public Class pRegH010

        Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As ColecaoH010

            Dim retorno As ColecaoH010 = Nothing
            Dim acessoBanco As cAcessoBD = New cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim comando As StringBuilder = New StringBuilder()

            comando.Append(" SELECT DISTINCT ")
            'comando.Append(" RIGHT(CONCAT(RIGHT(CONCAT('0000000000', CONVERT(tmp.codigo, CHAR(10))), 10), RIGHT(CONCAT('00', CONVERT(tmp.item, CHAR(2))), 2)), 12) AS codigoEfd, ")
            comando.Append(" tmp.codigo AS codigoEfd, ")
            comando.Append(" sum(pi.valor) AS quantidade, tmp.unidadeMedidaCodigo, tmp.valorVenda AS valorUnitario,")
            comando.Append(" CONVERT(sum(ABS(pi.valor)) * tmp.valorVenda, DECIMAL(10,2))  AS valorItem, ")
            comando.Append(" ec.contaAnaliticaContabil ")
            comando.Append(" FROM ( ")

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" p.cid as codigo, vp.item AS item, p.efdUnidadeMedidaCodigo AS unidadeMedidaCodigo, p.valorVenda ")
            comando.Append(" FROM produtos p INNER JOIN vendasprodutos vp ON vp.produto = p.cid ")
            comando.Append(" INNER JOIN vendas v ON v.controle = vp.controle INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid AND pi.item = vp.item AND pi.caracteristicas_cid = 1 ")
            comando.Append(" WHERE v.data BETWEEN '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
            comando.Append(" 00:00:00.000' AND '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 ")

            comando.Append(" UNION ALL ")

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" le.produto_cid AS codigo, pt.item AS item, p.efdUnidadeMedidaCodigo AS unidadeMedidaCodigo, p.valorVenda ")
            comando.Append(" FROM logestoque le ")
            comando.Append(" INNER JOIN produtos p ON p.cid = le.produto_cid AND IFNULL(p.efdIntegracao, 1) = 1 ")
            comando.Append(" INNER JOIN produtoitem pt ON pt.produtos_cid = p.cid AND pt.caracteristicas_cid = 1 AND pt.valor = le.produtoItem_codigoBarras ")
            comando.Append(" WHERE le.data BETWEEN '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
            comando.Append(" 00:00:00.000' AND '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 ")

            comando.Append(" ORDER BY 1, 2 ")

            comando.Append(" ) AS tmp ")
            comando.Append(" INNER JOIN produtoitem pi ON pi.produtos_cid = tmp.codigo AND pi.item = tmp.item AND pi.caracteristicas_cid = 2, ")
            comando.Append(" efdcontabilidade AS ec GROUP BY tmp.codigo")

            ds = acessoBanco.ExecutarDS(comando.ToString())

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New ColecaoH010()

                        For Each linha As DataRow In dt.Rows
                            Dim _dRegH010 As dRegH010 = New dRegH010()

                            _dRegH010.cod_item = RetornarTexto(linha.Item("codigoEfd"))
                            _dRegH010.unid = RetornarTexto(linha.Item("unidadeMedidaCodigo"))
                            _dRegH010.qtd = RetornarInteiro(linha.Item("quantidade"))
                            _dRegH010.vl_unit = RetornarDecimal(linha.Item("valorUnitario"))
                            _dRegH010.vl_item = RetornarDecimal(linha.Item("valorItem"))
                            _dRegH010.cod_cta = RetornarTexto(linha.Item("contaAnaliticaContabil"))

                            retorno.Add(_dRegH010)
                        Next
                    End If
                End If
            End If

            Consultar = retorno

        End Function

    End Class

End Namespace