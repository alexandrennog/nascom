Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

    Public Class pReg0200

        Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As Colecao0200

            Dim retorno As Colecao0200 = Nothing
            Dim acessoBanco As cAcessoBD = New cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim comando As StringBuilder = New StringBuilder()

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" tmp.codigo, tmp.descricao, tmp.aliquotaIcms, tmp.efdUnidadeMedidaCodigo ")
            comando.Append(" FROM ( ")

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" p.cid as codigo, p.descricao AS descricao, ")
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo ")
            comando.Append(" FROM produtos p INNER JOIN vendasprodutos vp ON vp.produto = p.cid INNER JOIN vendas v ON v.controle = vp.controle ")
            comando.Append(" INNER JOIN produtoitem pi ON pi.produtos_cid = p.cid AND pi.item = vp.item AND pi.caracteristicas_cid = 1 ")
            comando.Append(" WHERE v.data BETWEEN '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
            comando.Append("  00:00:00.000' AND ' ")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
            comando.Append("  23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 AND pi.valor > 0")

            comando.Append(" UNION ALL ")

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" le.produto_cid AS codigo, p.descricao AS descricao,  ")
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo ")
            comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid ")
            comando.Append(" INNER JOIN produtoitem pt ON pt.produtos_cid = p.cid AND pt.caracteristicas_cid = 1 AND pt.valor = le.produtoItem_codigoBarras ")
            comando.Append(" WHERE le.data BETWEEN '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
            comando.Append(" 00:00:00.000' AND '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
            comando.Append(" 23:59:59.999' AND IFNULL(p.efdIntegracao, 1) = 1 AND pt.valor > 0 ")

            comando.Append(" ORDER BY 1, 2 ")

            comando.Append(" ) AS tmp ")

            ds = acessoBanco.ExecutarDS(comando.ToString())

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New Colecao0200()

                        For Each linha As DataRow In dt.Rows
                            Dim _dReg0200 As dReg0200 = New dReg0200()

                            _dReg0200.cod_item = RetornarTexto(linha.Item("codigo"))
                            _dReg0200.descr_item = RetornarTexto(linha.Item("descricao"))
                            '_dReg0200.cod_barra = RetornarTexto(linha.Item("codigobarras"))
                            _dReg0200.aliq_icms = RetornarTexto(linha.Item("aliquotaIcms"))
                            _dReg0200.unid_inv = RetornarTexto(linha.Item("efdUnidadeMedidaCodigo"))

                            retorno.Add(_dReg0200)
                        Next
                    End If
                End If
            End If

            Consultar = retorno

        End Function

    End Class

End Namespace