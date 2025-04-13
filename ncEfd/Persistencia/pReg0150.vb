Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pReg0150

    Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As Colecao0150

      Dim retorno As Colecao0150 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT ")
      comando.Append(" f.cid, f.nome, f.cnpj, f.inscricaoEstadual, m.codigo_ibge, ")
      comando.Append(" f.logradouro, f.numero, f.complemento, f.bairro ")
      comando.Append(" FROM fornecedores f ")
      comando.Append(" INNER JOIN notafiscalfornecedor nff ON nff.fornecedor_cid = f.cid ")
      comando.Append(" INNER JOIN municipios m ON m.cid = f.cidade_cid ")
      comando.Append(" WHERE nff.dataEmissao BETWEEN '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
      comando.Append(" 00:00:00.000' AND '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
      comando.Append(" 23:59:59.999' ")
      comando.Append(" ORDER BY f.cid ")

      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New Colecao0150()

            For Each linha As DataRow In dt.Rows
              Dim _dReg0150 As dReg0150 = New dReg0150()

              _dReg0150.cod_part = RetornarTexto(linha.Item("cid"))
              _dReg0150.nome = RetornarTexto(linha.Item("nome"))
              _dReg0150.cnpj = RetornarTexto(linha.Item("cnpj"))
              _dReg0150.ie = RetornarTexto(linha.Item("inscricaoEstadual"))
              _dReg0150.cod_mun = RetornarTexto(linha.Item("codigo_ibge"))
              _dReg0150.ende = RetornarTexto(linha.Item("logradouro"))
              _dReg0150.num = RetornarTexto(linha.Item("numero"))
              _dReg0150.compl = RetornarTexto(linha.Item("complemento"))
              _dReg0150.bairro = RetornarTexto(linha.Item("bairro"))

              retorno.Add(_dReg0150)
            Next
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace