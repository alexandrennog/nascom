using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoC190 : List<dRegC190> { }

    public class dRegC190
    {
        public string reg { get; set; }
        public string cst_icms { get; set; }
        public string cfop { get; set; }
        public decimal? aliq_icms { get; set; }
        public decimal? vl_opr { get; set; }
        public decimal? vl_bc_icms { get; set; }
        public decimal? vl_icms { get; set; }
        public decimal? vl_bc_icms_st { get; set; }
        public decimal? vl_icms_st { get; set; }
        public decimal? vl_red_bc { get; set; }
        public decimal? vl_ipi { get; set; }
        public string cod_obs { get; set; }
    }
}
