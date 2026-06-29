using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoC990 : List<dRegC990> { }

    public class dRegC990
    {
        public string reg { get; set; }
        public int? qtd_lin_c { get; set; }
    }
}
