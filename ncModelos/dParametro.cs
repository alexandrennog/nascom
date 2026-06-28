using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoParametro : List<dParametro> { }

    public class dParametro
    {
        public int? cid { get; set; }
        public string descricao { get; set; }
        public string valor { get; set; }
    }

}
