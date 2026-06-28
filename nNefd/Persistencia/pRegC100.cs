using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;


namespace nsEfd
{
    public class pRegC100
    {
        public ColecaoC100 Consultar(DateTime dataInicio, DateTime dataFim)
        {
            ColecaoC100 retorno = null;
            var acessoBanco = new cAcessoBD();
            var comando = new StringBuilder();

            comando.Append(" SELECT ");
            comando.Append(" nff.tipoFluxo_cid, nff.tipoEmissao_cid, nff.fornecedor_cid, nff.tipoNotaFiscal_cid, ");
            comando.Append(" nff.situacaoNotaFiscal_cid, nff.serie, nff.numero, nff.chaveNotaFiscalEletronica, ");
            comando.Append(" nff.dataEmissao, nff.dataEntrada, nff.valorTotalNota, nff.tipoPagamento_cid, nff.valorAbatimento, ");
            comando.Append(" nff.valorDesconto, nff.valorTotalProdutos, nff.tipoFrete_cid, nff.valorFrete, ");
            comando.Append(" nff.valorSeguro, nff.valorOutrasDespesas, nff.valorBaseIcms, nff.valorIcms, ");
            comando.Append(" nff.valorBaseIcmsSubstituicao, nff.valorIcmsSubstituicao, nff.valorTotalIpi, nff.valorTotalPis, ");
            comando.Append(" nff.valorTotalCofins, nff.valorPisRetidoSubstituicao, nff.valorCofinsRetidoSubstituicao ");
            comando.Append(" FROM notafiscalfornecedor nff LEFT OUTER JOIN fornecedores f ON f.cid = nff.fornecedor_cid ");
            comando.Append(" WHERE nff.dataEmissao BETWEEN '");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataInicio.ToString())));
            comando.Append("  00:00:00.000' AND ' ");
            comando.Append(ncNComum.cFuncoes.FormatarDataUniversal(ncNComum.cFuncoes.FormatarDataBarras(dataFim.ToString())));
            comando.Append("  23:59:59.999' ");

            DataSet ds = acessoBanco.ExecutarDS(comando.ToString());

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    retorno = new ColecaoC100();
                    foreach (DataRow linha in dt.Rows)
                    {
                        var item = new dRegC100();
                        item.cod_part = ncNComum.cFuncoes.RetornarTexto(linha["fornecedor_cid"]);
                        item.ser = ncNComum.cFuncoes.RetornarTexto(linha["serie"]);
                        item.num_doc = ncNComum.cFuncoes.RetornarTexto(linha["numero"]);
                        item.chv_nfe = ncNComum.cFuncoes.RetornarTexto(linha["chaveNotaFiscalEletronica"]);
                        item.dt_doc = ncNComum.cFuncoes.RetornarData(linha["dataEmissao"]);
                        item.dt_e_s = ncNComum.cFuncoes.RetornarData(linha["dataEntrada"]);
                        item.vl_doc = ncNComum.cFuncoes.RetornarDecimal(linha["valorTotalNota"]);
                        item.vl_desc = ncNComum.cFuncoes.RetornarDecimal(linha["valorDesconto"]);
                        item.vl_abat_nt = ncNComum.cFuncoes.RetornarDecimal(linha["valorAbatimento"]);
                        item.vl_merc = ncNComum.cFuncoes.RetornarDecimal(linha["valorTotalProdutos"]);
                        item.vl_frt = ncNComum.cFuncoes.RetornarDecimal(linha["valorFrete"]);
                        item.vl_seg = ncNComum.cFuncoes.RetornarDecimal(linha["valorSeguro"]);
                        item.vl_out_da = ncNComum.cFuncoes.RetornarDecimal(linha["valorOutrasDespesas"]);
                        item.vl_bc_icms = ncNComum.cFuncoes.RetornarDecimal(linha["valorBaseIcms"]);
                        item.vl_icms = ncNComum.cFuncoes.RetornarDecimal(linha["valorIcms"]);
                        item.vl_bc_icms_st = ncNComum.cFuncoes.RetornarDecimal(linha["valorBaseIcmsSubstituicao"]);
                        item.vl_icms_st = ncNComum.cFuncoes.RetornarDecimal(linha["valorIcmsSubstituicao"]);
                        item.vl_ipi = ncNComum.cFuncoes.RetornarDecimal(linha["valorTotalIpi"]);
                        item.vl_pis = ncNComum.cFuncoes.RetornarDecimal(linha["valorTotalPis"]);
                        item.vl_cofins = ncNComum.cFuncoes.RetornarDecimal(linha["valorTotalCofins"]);
                        item.vl_pis_st = ncNComum.cFuncoes.RetornarDecimal(linha["valorPisRetidoSubstituicao"]);
                        item.vl_cofins_st = ncNComum.cFuncoes.RetornarDecimal(linha["valorCofinsRetidoSubstituicao"]);
                        item.tipoFluxo = ncNComum.cFuncoes.RetornarInteiro(linha["tipoFluxo_cid"]);
                        item.tipoEmissao = ncNComum.cFuncoes.RetornarInteiro(linha["tipoEmissao_cid"]);
                        item.tipoNF = ncNComum.cFuncoes.RetornarInteiro(linha["tipoNotaFiscal_cid"]);
                        item.situacaoNF = ncNComum.cFuncoes.RetornarInteiro(linha["situacaoNotaFiscal_cid"]);
                        item.tipoPagto = ncNComum.cFuncoes.RetornarInteiro(linha["tipoPagamento_cid"]);
                        item.tipoFrete = ncNComum.cFuncoes.RetornarInteiro(linha["tipoFrete_cid"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
