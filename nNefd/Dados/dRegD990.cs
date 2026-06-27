using System.Collections.Generic;

namespace nsEfd
{
    public class ColecaoD990 : List<dRegD990> { }

    public class dRegD990
    {
        public string reg { get; set; }
        public int? qtd_lin_d { get; set; }
    }
}
