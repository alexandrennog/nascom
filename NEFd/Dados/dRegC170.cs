using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoC170 : List<dRegC170> { }

    public class dRegC170
    {
        public string reg { get; set; }
        public string num_item { get; set; }
        public string num_doc { get; set; }
        public string cod_item { get; set; }
        public string descr_compl { get; set; }
        public decimal? qtd { get; set; }
        public string unid { get; set; }
        public decimal? vl_item { get; set; }
        public decimal? vl_desc { get; set; }
        public string ind_mov { get; set; }
        public string cst_icms { get; set; }
        public string cfop { get; set; }
        public string cod_nat { get; set; }
        public decimal? vl_bc_icms { get; set; }
        public decimal? aliq_icms { get; set; }
        public decimal? vl_icms { get; set; }
        public decimal? vl_bc_icms_st { get; set; }
        public decimal? aliq_st { get; set; }
        public decimal? vl_icms_st { get; set; }
        public string ind_apur { get; set; }
        public string cst_ipi { get; set; }
        public string cod_enq { get; set; }
        public decimal? vl_bc_ipi { get; set; }
        public decimal? aliq_ipi { get; set; }
        public decimal? vl_ipi { get; set; }
        public string cst_pis { get; set; }
        public decimal? vl_bc_pis { get; set; }
        public decimal? aliq_pis { get; set; }
        public decimal? quant_bc_pis { get; set; }
        public decimal? aliq_pis_r { get; set; }
        public decimal? vl_pis { get; set; }
        public string cst_cofins { get; set; }
        public decimal? vl_bc_cofins { get; set; }
        public decimal? aliq_cofins { get; set; }
        public decimal? quant_bc_cofins { get; set; }
        public decimal? aliq_cofins_r { get; set; }
        public decimal? vl_cofins { get; set; }
        public string cod_cta { get; set; }
    }
}
