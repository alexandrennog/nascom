
namespace Modelos
{
    ﻿using System.Collections.Generic;

    public class ColecaoEstado : List<dEstado>
    {
    }

    public class dEstado
    {
        public int? cid { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public string situacao { get; set; }
    }
}
