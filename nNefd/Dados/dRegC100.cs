using System;
using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoC100 : List<dRegC100> { }

    public class dRegC100
    {
        public string reg { get; set; }
        public string ind_oper { get; set; }
        public string ind_emit { get; set; }
        public string cod_part { get; set; }
        public string cod_mod { get; set; }
        public string cod_sit { get; set; }
        public string ser { get; set; }
        public string num_doc { get; set; }
        public string chv_nfe { get; set; }
        public DateTime? dt_doc { get; set; }
        public DateTime? dt_e_s { get; set; }
        public decimal? vl_doc { get; set; }
        public string ind_pagto { get; set; }
        public decimal? vl_desc { get; set; }
        public decimal? vl_abat_nt { get; set; }
        public decimal? vl_merc { get; set; }
        public string ind_frt { get; set; }
        public decimal? vl_frt { get; set; }
        public decimal? vl_seg { get; set; }
        public decimal? vl_out_da { get; set; }
        public decimal? vl_bc_icms { get; set; }
        public decimal? vl_icms { get; set; }
        public decimal? vl_bc_icms_st { get; set; }
        public decimal? vl_icms_st { get; set; }
        public decimal? vl_ipi { get; set; }
        public decimal? vl_pis { get; set; }
        public decimal? vl_cofins { get; set; }
        public decimal? vl_pis_st { get; set; }
        public decimal? vl_cofins_st { get; set; }
        public int? tipoEmissao { get; set; }
        public int? tipoFluxo { get; set; }
        public int? tipoFrete { get; set; }
        public int? tipoNF { get; set; }
        public int? tipoPagto { get; set; }
        public int? situacaoNF { get; set; }
    }
}
