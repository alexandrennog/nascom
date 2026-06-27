using System.Collections.Generic;

namespace nsEfd
{
    public class Colecao1990 : List<dReg1990> { }

    public class dReg1990
    {
        public string reg { get; set; }
        public int? qtd_lin_1 { get; set; }
    }
}
