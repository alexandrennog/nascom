using System;
using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoE100 : List<dRegE100> { }

    public class dRegE100
    {
        public string reg { get; set; }
        public DateTime? dt_ini { get; set; }
        public DateTime? dt_fin { get; set; }
    }
}
