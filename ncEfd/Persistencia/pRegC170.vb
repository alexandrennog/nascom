Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

    Public Class pRegC170

        Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As ColecaoC170

            Dim retorno As ColecaoC170 = Nothing
            Dim acessoBanco As cAcessoBD = New cAcessoBD
            Dim ds As DataSet
            Dim dt As DataTable
            Dim comando As StringBuilder = New StringBuilder()

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" tmp.codigo, tmp.descricao, tmp.aliquotaIcms, tmp.efdUnidadeMedidaCodigo, tmp.quantidade, tmp.valorCompra, notaFiscalNumero  ")
            comando.Append(" FROM ( ")

            comando.Append(" SELECT DISTINCT ")
            comando.Append(" le.produto_cid AS codigo, p.descricao AS descricao, p.valorCompra, ")
            comando.Append(" p.aliquota AS aliquotaIcms, p.efdUnidadeMedidaCodigo, le.quantidade, le.notaFiscalNumero ")
            comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid AND IFNULL(p.efdIntegracao, 1) = 1 ")
            comando.Append(" INNER JOIN notafiscalfornecedor nff ON le.notaFiscalNumero = nff.numero ")
            comando.Append(" WHERE nff.dataEmissao BETWEEN '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
            comando.Append(" 00:00:00.000' AND '")
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
            comando.Append(" 23:59:59.999' AND notaFiscalNumero is not null ")

            comando.Append(" ORDER BY 1, 2 ")

            comando.Append(" ) AS tmp ")

            ds = acessoBanco.ExecutarDS(comando.ToString())

            If Not ds Is Nothing Then
                If ds.Tables.Count > 0 Then
                    dt = ds.Tables(0)

                    If dt.Rows.Count > 0 Then
                        retorno = New ColecaoC170()

                        For Each linha As DataRow In dt.Rows
                            Dim _dRegC170 As dRegC170 = New dRegC170()

                            _dRegC170.cod_item = RetornarTexto(linha.Item("codigo"))
                            _dRegC170.descr_compl = RetornarTexto(linha.Item("descricao"))
                            _dRegC170.aliq_icms = RetornarTexto(linha.Item("aliquotaIcms"))
                            _dRegC170.unid = RetornarTexto(linha.Item("efdUnidadeMedidaCodigo"))
                            _dRegC170.qtd = RetornarInteiro(linha.Item("quantidade"))
                            _dRegC170.vl_item = RetornarDecimal(linha.Item("valorCompra"))
                            _dRegC170.num_doc = RetornarTexto(linha.Item("notaFiscalNumero"))

                            retorno.Add(_dRegC170)
                        Next
                    End If
                End If
            End If

            Consultar = retorno

        End Function

    End Class

End Namespace