using System;
using System.Collections.Generic;

namespace nsNotaFiscalFornecedor
{
    public class ColecaoNotaFiscalFornecedor : List<dNotaFiscalFornecedor> { }

    public class dNotaFiscalFornecedor
    {
        public int? cid { get; set; }
        public string numero { get; set; }
        public string serie { get; set; }
        public int? fornecedor_cid { get; set; }
        public string fornecedorNome { get; set; }
        public string dataEmissao { get; set; }
        public DateTime? dataInclusao { get; set; }
        public decimal? valorBaseIcms { get; set; }
        public decimal? valorIcms { get; set; }
        public decimal? valorBaseIcmsSubstituicao { get; set; }
        public decimal? valorIcmsSubstituicao { get; set; }
        public decimal? valorTotalIpi { get; set; }
        public decimal? valorTotalProdutos { get; set; }
        public decimal? valorTotalNota { get; set; }
        public int? tipoFluxo_cid { get; set; }
        public int? tipoEmissao_cid { get; set; }
        public int? tipoNotaFiscal_cid { get; set; }
        public int? tipoPagamento_cid { get; set; }
        public int? tipoFrete_cid { get; set; }
        public int? situacaoNotaFiscal_cid { get; set; }
        public string chaveNotaFiscalEletronica { get; set; }
        public DateTime? dataEntrada { get; set; }
        public decimal? valorFrete { get; set; }
        public decimal? valorSeguro { get; set; }
        public decimal? valorDesconto { get; set; }
        public decimal? valorOutrasDespesas { get; set; }
        public decimal? valorAbatimento { get; set; }
        public decimal? valorTotalPis { get; set; }
        public decimal? valorPisRetidoSubstituicao { get; set; }
        public decimal? valorTotalCofins { get; set; }
        public decimal? valorCofinsRetidoSubstituicao { get; set; }
        public string produtoCodigo { get; set; }
    }
}
