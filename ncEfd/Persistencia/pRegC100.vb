Imports System.Text
Imports ncComum.nsAcessoBD
Imports ncComum.nsFuncoes.cFuncoes
Imports ncComum.nsExcecao

Namespace nsEfd

  Public Class pRegC100

    Public Function Consultar(ByVal dataInicio As Date, ByVal dataFim As Date) As ColecaoC100

      Dim retorno As ColecaoC100 = Nothing
      Dim acessoBanco As cAcessoBD = New cAcessoBD
      Dim ds As DataSet
      Dim dt As DataTable
      Dim comando As StringBuilder = New StringBuilder()

      comando.Append(" SELECT ")
      comando.Append(" nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.fornecedor_cid, nff.tipoNotaFiscal_cid, ")
      comando.Append(" nff.situacaoNotaFiscal_cid, nff.serie, nff.numero, nff.chaveNotaFiscalEletronica, ")
      comando.Append(" nff.dataEmissao, nff.dataEntrada, nff.valorTotalNota, nff.tipoPagamento_cid, nff.valorAbatimento, ")
      comando.Append(" nff.valorDesconto, nff.valorTotalProdutos, nff.tipoFrete_cid, nff.valorFrete, ")
      comando.Append(" nff.valorSeguro, nff.valorOutrasDespesas, nff.valorBaseIcms, nff.valorIcms, ")
      comando.Append(" nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, nff.valorTotalIpi, nff.valorTotalPis, ")
      comando.Append(" nff.valorTotalCofins, nff.valorPisRetidoSubstituicao, nff.valorCofinsRetidoSubstituicao ")
      comando.Append(" FROM notafiscalfornecedor nff LEFT OUTER JOIN fornecedores f ON f.cid = nff.fornecedor_cid ")
      comando.Append(" WHERE nff.dataEmissao BETWEEN '")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)))
      comando.Append("  00:00:00.000' AND ' ")
      comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)))
      comando.Append("  23:59:59.999' ")

      ds = acessoBanco.ExecutarDS(comando.ToString())

      If Not ds Is Nothing Then
        If ds.Tables.Count > 0 Then
          dt = ds.Tables(0)

          If dt.Rows.Count > 0 Then
            retorno = New ColecaoC100()

            For Each linha As DataRow In dt.Rows
              Dim _dRegC100 As dRegC100 = New dRegC100()

              _dRegC100.cod_part = RetornarTexto(linha.Item("fornecedor_cid"))
              _dRegC100.ser = RetornarTexto(linha.Item("serie"))
              _dRegC100.num_doc = RetornarTexto(linha.Item("numero"))
              _dRegC100.chv_nfe = RetornarTexto(linha.Item("chaveNotaFiscalEletronica"))
              _dRegC100.dt_doc = RetornarData(linha.Item("dataEmissao"))
              _dRegC100.dt_e_s = RetornarData(linha.Item("dataEntrada"))
              _dRegC100.vl_doc = RetornarDecimal(linha.Item("valorTotalNota"))
              _dRegC100.vl_desc = RetornarDecimal(linha.Item("valorDesconto"))
              _dRegC100.vl_abat_nt = RetornarDecimal(linha.Item("valorAbatimento"))
              _dRegC100.vl_merc = RetornarDecimal(linha.Item("valorTotalProdutos"))
              _dRegC100.vl_frt = RetornarDecimal(linha.Item("valorFrete"))
              _dRegC100.vl_seg = RetornarDecimal(linha.Item("valorSeguro"))
              _dRegC100.vl_out_da = RetornarDecimal(linha.Item("valorOutrasDespesas"))
              _dRegC100.vl_bc_icms = RetornarDecimal(linha.Item("valorBaseIcms"))
              _dRegC100.vl_icms = RetornarDecimal(linha.Item("valorIcms"))
              _dRegC100.vl_bc_icms_st = RetornarDecimal(linha.Item("valorBaseIcmsSubstituicao"))
              _dRegC100.vl_icms_st = RetornarDecimal(linha.Item("valorIcmsSubstituicao"))
              _dRegC100.vl_ipi = RetornarDecimal(linha.Item("valorTotalIpi"))
              _dRegC100.vl_pis = RetornarDecimal(linha.Item("valorTotalPis"))
              _dRegC100.vl_cofins = RetornarDecimal(linha.Item("valorTotalCofins"))
              _dRegC100.vl_pis_st = RetornarDecimal(linha.Item("valorPisRetidoSubstituicao"))
              _dRegC100.vl_cofins_st = RetornarDecimal(linha.Item("valorCofinsRetidoSubstituicao"))

              _dRegC100.tipoFluxo = RetornarInteiro(linha.Item("tipoFluxo_cid"))
              _dRegC100.tipoEmissao = RetornarInteiro(linha.Item("tipoEmissao_cid"))
              _dRegC100.tipoNF = RetornarInteiro(linha.Item("tipoNotaFiscal_cid"))
              _dRegC100.situacaoNF = RetornarInteiro(linha.Item("situacaoNotaFiscal_cid"))
              _dRegC100.tipoPagto = RetornarInteiro(linha.Item("tipoPagamento_cid"))
              _dRegC100.tipoFrete = RetornarInteiro(linha.Item("tipoFrete_cid"))

              retorno.Add(_dRegC100)
            Next
          End If
        End If
      End If

      Consultar = retorno

    End Function

  End Class

End Namespace