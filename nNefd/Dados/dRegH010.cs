using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoH010 : List<dRegH010> { }

    public class dRegH010
    {
        public string reg { get; set; }
        public string cod_item { get; set; }
        public string unid { get; set; }
        public int? qtd { get; set; }
        public decimal? vl_unit { get; set; }
        public decimal? vl_item { get; set; }
        public string ind_prop { get; set; }
        public string cod_part { get; set; }
        public string txt_compl { get; set; }
        public string cod_cta { get; set; }
        public decimal? vl_item_ir { get; set; }
    }
}
