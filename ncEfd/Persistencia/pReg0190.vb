Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pReg0190

    Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As Colecao0190

      Dim retorno As Colecao0190 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT DISTINCT ")
      comando.Append(" tmp.efdUnidadeMedidaCodigo as codigo, um.descricao ")
      comando.Append(" FROM ( ")

      comando.Append(" SELECT DISTINCT  ")
      comando.Append(" p.efdUnidadeMedidaCodigo ")
      comando.Append(" FROM produtos p ")
      comando.Append(" INNER JOIN vendasprodutos vp on vp.produto = p.cid INNER JOIN vendas v ON v.controle = vp.controle ")
      comando.Append(" WHERE IFNULL(p.efdIntegracao, 1) = 1 AND V.DATA BETWEEN '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
      comando.Append(" 00:00:00.000' AND '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
      comando.Append(" 23:59:59.999' ")

      comando.Append(" UNION ALL ")

      comando.Append(" SELECT DISTINCT ")
      comando.Append(" p.efdUnidadeMedidaCodigo ")
      comando.Append(" FROM logestoque le INNER JOIN produtos p ON p.cid = le.produto_cid ")
      comando.Append(" WHERE IFNULL(p.efdIntegracao, 1) = 1 AND le.data BETWEEN '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
      comando.Append(" 00:00:00.000' AND '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
      comando.Append(" 23:59:59.999' ")

      comando.Append(" ) AS tmp ")
      comando.Append(" INNER JOIN efdUnidadeMedida um ON um.codigo = tmp.efdUnidadeMedidaCodigo ")
      comando.Append(" WHERE tmp.efdUnidadeMedidaCodigo IS NOT NULL ")

      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New Colecao0190()

            For Each linha As DataRow In dt.Rows
              Dim _dReg0190 As dReg0190 = New dReg0190()

              _dReg0190.unid = RetornarTexto(linha.Item("codigo"))
              _dReg0190.descr = RetornarTexto(linha.Item("descricao"))

              retorno.Add(_dReg0190)
            Next
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace