using System;
using System.Data;
using System.Text;
using ncNComum.nsAcessoBD;
using static ncNComum.nsFuncoes.cFuncoes;

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
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataInicio)));
            comando.Append("  00:00:00.000' AND ' ");
            comando.Append(FormatarDataUniversal(FormatarDataBarras(dataFim)));
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
                        item.cod_part = RetornarTexto(linha["fornecedor_cid"]);
                        item.ser = RetornarTexto(linha["serie"]);
                        item.num_doc = RetornarTexto(linha["numero"]);
                        item.chv_nfe = RetornarTexto(linha["chaveNotaFiscalEletronica"]);
                        item.dt_doc = RetornarData(linha["dataEmissao"]);
                        item.dt_e_s = RetornarData(linha["dataEntrada"]);
                        item.vl_doc = RetornarDecimal(linha["valorTotalNota"]);
                        item.vl_desc = RetornarDecimal(linha["valorDesconto"]);
                        item.vl_abat_nt = RetornarDecimal(linha["valorAbatimento"]);
                        item.vl_merc = RetornarDecimal(linha["valorTotalProdutos"]);
                        item.vl_frt = RetornarDecimal(linha["valorFrete"]);
                        item.vl_seg = RetornarDecimal(linha["valorSeguro"]);
                        item.vl_out_da = RetornarDecimal(linha["valorOutrasDespesas"]);
                        item.vl_bc_icms = RetornarDecimal(linha["valorBaseIcms"]);
                        item.vl_icms = RetornarDecimal(linha["valorIcms"]);
                        item.vl_bc_icms_st = RetornarDecimal(linha["valorBaseIcmsSubstituicao"]);
                        item.vl_icms_st = RetornarDecimal(linha["valorIcmsSubstituicao"]);
                        item.vl_ipi = RetornarDecimal(linha["valorTotalIpi"]);
                        item.vl_pis = RetornarDecimal(linha["valorTotalPis"]);
                        item.vl_cofins = RetornarDecimal(linha["valorTotalCofins"]);
                        item.vl_pis_st = RetornarDecimal(linha["valorPisRetidoSubstituicao"]);
                        item.vl_cofins_st = RetornarDecimal(linha["valorCofinsRetidoSubstituicao"]);
                        item.tipoFluxo = RetornarInteiro(linha["tipoFluxo_cid"]);
                        item.tipoEmissao = RetornarInteiro(linha["tipoEmissao_cid"]);
                        item.tipoNF = RetornarInteiro(linha["tipoNotaFiscal_cid"]);
                        item.situacaoNF = RetornarInteiro(linha["situacaoNotaFiscal_cid"]);
                        item.tipoPagto = RetornarInteiro(linha["tipoPagamento_cid"]);
                        item.tipoFrete = RetornarInteiro(linha["tipoFrete_cid"]);
                        retorno.Add(item);
                    }
                }
            }

            return retorno;
        }
    }
}
