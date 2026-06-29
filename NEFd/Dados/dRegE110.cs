using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoE110 : List<dRegE110> { }

    public class dRegE110
    {
        public string reg { get; set; }
        public decimal? vl_tot_debitos { get; set; }
        public decimal? vl_aj_debitos { get; set; }
        public decimal? vl_tot_aj_debitos { get; set; }
        public decimal? vl_estornos_cred { get; set; }
        public decimal? vl_tot_creditos { get; set; }
        public decimal? vl_aj_creditos { get; set; }
        public decimal? vl_tot_aj_creditos { get; set; }
        public decimal? vl_estornos_deb { get; set; }
        public decimal? vl_sld_credor_ant { get; set; }
        public decimal? vl_sld_apurado { get; set; }
        public decimal? vl_tot_ded { get; set; }
        public decimal? vl_icms_recolher { get; set; }
        public decimal? vl_sld_credor_transportar { get; set; }
        public decimal? deb_esp { get; set; }
    }
}
