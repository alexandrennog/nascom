using System;
using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoServico : List<dServico> { }

    public class dServico
    {
        public int? cid { get; set; }
        public string nome { get; set; }
        public string situacao { get; set; }
        public decimal valor { get; set; }
    }

}
