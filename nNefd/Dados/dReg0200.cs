using System.Collections.Generic;

namespace nsEfd
{
    public class Colecao0200 : List<dReg0200> { }

    public class dReg0200
    {
        public string reg { get; set; }
        public string cod_item { get; set; }
        public string descr_item { get; set; }
        public string cod_barra { get; set; }
        public string cod_ant_item { get; set; }
        public string unid_inv { get; set; }
        public string tipo_item { get; set; }
        public string cod_ncm { get; set; }
        public string ex_ipi { get; set; }
        public string cod_gen { get; set; }
        public string cod_lst { get; set; }
        public string aliq_icms { get; set; }
    }
}
