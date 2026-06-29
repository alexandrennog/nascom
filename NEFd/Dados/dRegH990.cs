using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoH990 : List<dRegH990> { }

    public class dRegH990
    {
        public string reg { get; set; }
        public int? qtd_lin_h { get; set; }
    }
}
