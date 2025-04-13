Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pReg0000

    Public Function Consultar() As dReg0000

      Dim retorno As dReg0000 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT ")
      comando.Append(" a.versaoLeiaute, a.finalidadeArquivo, e.nomeEmpresarial, e.tipoPessoa, e.cpfCnpj, uf.sigla, e.inscricaoEstadual, ")
      comando.Append(" m.codigo_ibge, e.inscricaoMunicipal, e.inscricaoSuframa, a.perfilArquivoFiscal, e.tipoAtividade ")
      comando.Append(" FROM EfdEntidade e ")
      comando.Append(" INNER JOIN municipios m ON m.cid = e.codigoMunicipio ")
            comando.Append(" INNER JOIN estados uf ON uf.cid = m.estados_cid")
      comando.Append(" , EfdArquivo a ")

      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New dReg0000()

            retorno.cod_ver = cFuncoes.RetornarTexto(dt.Rows(0).Item("versaoLeiaute"))
            retorno.cod_fin = cFuncoes.RetornarTexto(dt.Rows(0).Item("finalidadeArquivo"))
            retorno.nome = cFuncoes.RetornarTexto(dt.Rows(0).Item("nomeEmpresarial"))
            retorno.cpfCnpj = cFuncoes.RetornarTexto(dt.Rows(0).Item("cpfCnpj"))
            retorno.uf = cFuncoes.RetornarTexto(dt.Rows(0).Item("sigla"))
            retorno.ie = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoEstadual"))
            retorno.cod_mun = cFuncoes.RetornarTexto(dt.Rows(0).Item("codigo_ibge"))
            retorno.im = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoMunicipal"))
            retorno.suframa = cFuncoes.RetornarTexto(dt.Rows(0).Item("inscricaoSuframa"))
            retorno.ind_perfil = cFuncoes.RetornarTexto(dt.Rows(0).Item("perfilArquivoFiscal"))
            retorno.ind_ativ = cFuncoes.RetornarTexto(dt.Rows(0).Item("tipoAtividade"))
            retorno.tipoPessoa = cFuncoes.RetornarTexto(dt.Rows(0).Item("tipoPessoa"))
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace
