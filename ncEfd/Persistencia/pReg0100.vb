Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pReg0100

    Public Function Consultar() As dReg0100

      Dim retorno As dReg0100 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT ")
      comando.Append(" c.nomeContador, c.cpfContador, c.crcContador, c.cnpjEscritorio, c.logradouro, c.numero, ")
      comando.Append(" c.complemento, c.bairro, c.cep, c.dddTelefone, c.dddFax, c.email, m.codigo_ibge ")
      comando.Append(" FROM EfdContabilidade c INNER JOIN municipios m ON m.cid = c.municipio ")

      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New dReg0100()

            retorno.nome = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeContador"))
            retorno.cpf = cFuncoes.RetornarTexto(dt.Rows(0).Item("cpfContador"))
            retorno.crc = cFuncoes.RetornarTexto(dt.Rows(0).Item("crcContador"))
            retorno.cnpj = cFuncoes.RetornarTexto(dt.Rows(0).Item("cnpjEscritorio"))
            retorno.cep = cFuncoes.RetornarTexto(dt.Rows(0).Item("cep"))
            retorno.ende = cFuncoes.RetornarTexto(dt.Rows(0).Item("logradouro"))
            retorno.num = cFuncoes.RetornarTexto(dt.Rows(0).Item("numero"))
            retorno.compl = cFuncoes.RetornarTexto(dt.Rows(0).Item("complemento"))
            retorno.bairro = cFuncoes.RetornarTexto(dt.Rows(0).Item("bairro"))
            retorno.fone = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddTelefone"))
            retorno.fax = cFuncoes.RetornarTexto(dt.Rows(0).Item("dddFax"))
            retorno.email = cFuncoes.RetornarTexto(dt.Rows(0).Item("email"))
            retorno.cod_mun = cFuncoes.RetornarTexto(dt.Rows(0).Item("codigo_ibge"))
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace
