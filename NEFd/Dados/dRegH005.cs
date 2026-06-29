using System;
using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoH005 : List<dRegH005> { }

    public class dRegH005
    {
        public string reg { get; set; }
        public DateTime? dt_inv { get; set; }
        public decimal? vl_inv { get; set; }
        public string mot_inv { get; set; }
    }
}
