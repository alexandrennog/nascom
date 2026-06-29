using System.Collections.Generic;

namespace NEFd
{
    public class ColecaoE990 : List<dRegE990> { }

    public class dRegE990
    {
        public string reg { get; set; }
        public int? qtd_lin_e { get; set; }
    }
}
