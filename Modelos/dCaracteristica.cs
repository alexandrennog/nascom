using System;
using System.Collections.Generic;

namespace Modelos
{
    public class ColecaoCaracteristica : List<dCaracteristica> { }

    public class dCaracteristica
    {
        public int? cid { get; set; }
        public string nome { get; set; }
        public string situacao { get; set; }
        public string codigo { get; set; }
    }

}
