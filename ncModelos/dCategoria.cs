using System;
using System.Collections.Generic;

namespace nsCategoria
{
    public class ColecaoCategoria : List<dCategoria> { }

    public class dCategoria
    {
        public int? cid { get; set; }
        public string nome { get; set; }
        public string situacao { get; set; }
    }
}
