using System.Collections.Generic;

namespace ncModelos
{
    public class ColecaoSimNao : List<dSimNao> { }

    public class dSimNao
    {
        public string codigo { get; set; }
        public string descricao { get; set; }
    }

}
