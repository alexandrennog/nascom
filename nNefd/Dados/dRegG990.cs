using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoG990 : List<dRegG990> { }

    public class dRegG990
    {
        public string reg { get; set; }
        public int? qtd_lin_g { get; set; }
    }
}
